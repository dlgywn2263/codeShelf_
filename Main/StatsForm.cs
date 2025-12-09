using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace Main
{
    public partial class StatsForm : Form
    {
        public StatsForm()
        {
            InitializeComponent();
            chartStats.Series.Clear();
            LoadSummaryStats();
        }

        // =========================================
        //  📌 요약 정보 (상단 레이블들)
        // =========================================
        private void LoadSummaryStats()
        {
            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                // 1) 평균 대여 횟수 (회원당)
                //    회원별 rental 갯수를 먼저 구해서, 그 갯수들의 평균을 냄
                string sqlAvgRent = @"
                    SELECT NVL(AVG(CAST(rent_cnt AS BINARY_DOUBLE)), 0)
                    FROM (
                        SELECT COUNT(*) AS rent_cnt
                        FROM rental
                        GROUP BY member_id
                    )
                ";

                using (OracleCommand cmd = new OracleCommand(sqlAvgRent, conn))
                {
                    object r = cmd.ExecuteScalar();

                    double avgRent = 0;
                    if (r != DBNull.Value)
                    {
                        double.TryParse(r.ToString(), out avgRent);
                    }

                    lblAvgRent.Text = $"평균 대여 횟수 : {Math.Round(avgRent, 1)} 회";
                }

                // 2) 고장률 = (고장 충전기 수 / 전체 충전기 수) * 100
                int brokenCount = 0;
                int totalCharger = 0;

                using (OracleCommand cmdBroken = new OracleCommand(
                    "SELECT COUNT(*) FROM charger WHERE status = '고장'", conn))
                {
                    brokenCount = Convert.ToInt32(cmdBroken.ExecuteScalar());
                }

                using (OracleCommand cmdTotal = new OracleCommand(
                    "SELECT COUNT(*) FROM charger", conn))
                {
                    totalCharger = Convert.ToInt32(cmdTotal.ExecuteScalar());
                }

                double failRate = (totalCharger == 0)
                    ? 0
                    : brokenCount * 100.0 / totalCharger;

                lblFailureRate.Text = $"고장률 : {Math.Round(failRate, 1)}%";

                // 3) 평균 요금 (rental.charge_amount 사용)
                string sqlAvgFee = @"
                    SELECT NVL(AVG(CAST(charge_amount AS BINARY_DOUBLE)), 0)
                    FROM rental
                    WHERE charge_amount IS NOT NULL
                ";

                using (OracleCommand cmd = new OracleCommand(sqlAvgFee, conn))
                {
                    object r = cmd.ExecuteScalar();
                    
                    double avgFee = 0;
                    if (r != DBNull.Value)
                    {
                        double.TryParse(r.ToString(), out avgFee);
                    }

                    lblAvgFee.Text = $"평균 요금 : {Math.Round(avgFee, 0):N0} 원";
                }

                // 4) 일반 / 고속 선호도
                string sqlPref = @"
                    SELECT c.charger_type, COUNT(*) AS cnt
                    FROM rental r
                    JOIN charger c ON r.charger_id = c.charger_id
                    GROUP BY c.charger_type
                ";

                int normal = 0;
                int fast = 0;

                using (OracleCommand cmd = new OracleCommand(sqlPref, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string type = dr.GetString(0);
                        int cnt = dr.GetInt32(1);

                        if (type == "일반") normal = cnt;
                        else if (type == "고속") fast = cnt;
                    }
                }

                int total = normal + fast;
                int pNormal = total == 0 ? 0 : (normal * 100 / total);
                int pFast = total == 0 ? 0 : (fast * 100 / total);

                lblPref.Text = $"일반/고속 선호도 : {pNormal}% / {pFast}%";
            }
        }

        // =========================================
        //  📈 버튼별 그래프
        // =========================================

        // ▶ 평균 대여 횟수 (회원별 대여 count 막대그래프)
        private void btnAvgRent_Click(object sender, EventArgs e)
        {
            chartStats.Series.Clear();
            chartStats.Legends[0].Enabled = true;

            // 축 색상
            var ca = chartStats.ChartAreas[0];
            ca.AxisX.LineColor = Color.FromArgb(80, Color.Gray);
            ca.AxisY.LineColor = Color.FromArgb(80, Color.Gray);
            ca.AxisX.MajorGrid.LineColor = Color.FromArgb(50, Color.LightGray);
            ca.AxisY.MajorGrid.LineColor = Color.FromArgb(50, Color.LightGray);

            Series s = new Series("대여횟수");
            s.ChartType = SeriesChartType.Column;
            s.IsValueShownAsLabel = true;

            s.Color = Color.LightSkyBlue;

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
                    SELECT member_id, COUNT(*) AS cnt
                    FROM rental
                    GROUP BY member_id
                    ORDER BY member_id
                ";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int memberId = dr.GetInt32(0);
                        int cnt = dr.GetInt32(1);
                        s.Points.AddXY(memberId, cnt);
                    }
                }
            }

            foreach (DataPoint p in s.Points)
            {
                p.Font = new Font("맑은 고딕", 12, FontStyle.Bold);
                p.LabelForeColor = Color.Black;
            }

            chartStats.Series.Add(s);
        }

        // ▶ 고장률 (도넛 차트)
        private void btnFailureRate_Click(object sender, EventArgs e)
        {
            chartStats.Series.Clear();
            chartStats.Legends[0].Enabled = true;

            Series s = new Series("고장률");
            s.ChartType = SeriesChartType.Doughnut;
            s.IsValueShownAsLabel = true;

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                int broken = Convert.ToInt32(
                    new OracleCommand("SELECT COUNT(*) FROM charger WHERE status='고장'", conn)
                    .ExecuteScalar());

                int total = Convert.ToInt32(
                    new OracleCommand("SELECT COUNT(*) FROM charger", conn)
                    .ExecuteScalar());

                s.Points.AddXY("고장", broken);
                s.Points.AddXY("정상", total - broken);
            }

            foreach (DataPoint p in s.Points)
            {
                if (p.AxisLabel == "정상") p.Color = Color.LightGreen;
                if (p.AxisLabel == "고장") p.Color = Color.LightCoral;
                p.Font = new Font("맑은 고딕", 16, FontStyle.Bold);
                p.LabelForeColor = Color.Black;
            }

            chartStats.Series.Add(s);
        }

        // ▶ 요금 (대여건별 charge_amount 막대그래프)
        private void btnAvgFee_Click(object sender, EventArgs e)
        {
            chartStats.Series.Clear();
            chartStats.Legends[0].Enabled = true;

            var ca = chartStats.ChartAreas[0];
            ca.AxisX.LineColor = Color.FromArgb(80, Color.Gray);
            ca.AxisY.LineColor = Color.FromArgb(80, Color.Gray);
            ca.AxisX.MajorGrid.LineColor = Color.FromArgb(50, Color.LightGray);
            ca.AxisY.MajorGrid.LineColor = Color.FromArgb(50, Color.LightGray);

            Series s = new Series("요금");
            s.ChartType = SeriesChartType.Column;
            s.IsValueShownAsLabel = true;

            s.Color = Color.LightSkyBlue;

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
                    SELECT rental_id, charge_amount
                    FROM rental
                    WHERE charge_amount IS NOT NULL
                    ORDER BY rental_id
                ";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int rentalId = dr.GetInt32(0);
                        double amount = dr.GetDouble(1);
                        s.Points.AddXY(rentalId, amount);
                    }
                }
            }

            foreach (DataPoint p in s.Points)
            {
                p.Font = new Font("맑은 고딕", 9, FontStyle.Bold);
                p.LabelForeColor = Color.Black;
            }

            chartStats.Series.Add(s);
        }

        // ▶ 선호도 (일반 vs 고속 파이차트)
        private void btnPreference_Click(object sender, EventArgs e)
        {
            chartStats.Series.Clear();
            chartStats.Legends[0].Enabled = true;

            Series s = new Series("선호도");
            s.ChartType = SeriesChartType.Pie;
            s.IsValueShownAsLabel = true;

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
                    SELECT c.charger_type, COUNT(*) AS cnt
                    FROM rental r
                    JOIN charger c ON r.charger_id = c.charger_id
                    GROUP BY c.charger_type
                ";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string type = dr.GetString(0);
                        int cnt = dr.GetInt32(1);
                        s.Points.AddXY(type, cnt);
                    }
                }
            }

            foreach (DataPoint p in s.Points)
            {
                if (p.AxisLabel == "일반") p.Color = Color.LightSkyBlue;
                if (p.AxisLabel == "고속") p.Color = Color.LightCoral;
                p.Font = new Font("맑은 고딕", 16, FontStyle.Bold);
                p.LabelForeColor = Color.Black;
            }

            chartStats.Series.Add(s);
        }

        // ▶ 돌아가기
        private void btnBack_Click(object sender, EventArgs e)
        {
            new MainForm().Show();
            this.Close();
        }
    }
}
