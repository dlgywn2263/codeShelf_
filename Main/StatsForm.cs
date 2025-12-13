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
        private DateTime currentStart;
        private DateTime currentEnd;

        public StatsForm()
        {
            InitializeComponent();
            chartStats.Series.Clear();

            currentStart = DateTime.Today;
            currentEnd = DateTime.Today.AddDays(1).AddSeconds(-1);

            LoadSummaryStats(currentStart, currentEnd);
        }

        // =========================================
        //  📌 요약 정보 (상단 레이블들)
        // =========================================
        private void LoadSummaryStats(DateTime start, DateTime end)
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
                        WHERE rental_time BETWEEN :startDate AND :endDate
                        GROUP BY member_id
                    )
                ";

                using (OracleCommand cmd = new OracleCommand(sqlAvgRent, conn))
                {
                    cmd.Parameters.Add(":startDate", start);
                    cmd.Parameters.Add(":endDate", end);

                    double avgRent = Convert.ToDouble(cmd.ExecuteScalar());
                    lblAvgRent.Text = $"평균 대여 횟수 : {Math.Round(avgRent, 1)} 회";
                }

                // 2) 고장률 = (고장 충전기 수 / 전체 충전기 수) * 100
                int broken = Convert.ToInt32(
                    new OracleCommand("SELECT COUNT(*) FROM charger WHERE status='고장'", conn)
                    .ExecuteScalar());

                 int total = Convert.ToInt32(
                     new OracleCommand("SELECT COUNT(*) FROM charger", conn)
                     .ExecuteScalar());

                double rate = total == 0 ? 0 : broken * 100.0 / total;
                lblFailureRate.Text = $"고장률 : {Math.Round(rate, 1)}%";

                // 3) 평균 요금 (rental.charge_amount 사용)
                string sqlAvgFee = @"
                    SELECT NVL(AVG(CAST(charge_amount AS BINARY_DOUBLE)), 0)
                    FROM rental
                    WHERE charge_amount IS NOT NULL
                      AND return_time BETWEEN :startDate AND :endDate
                ";

                using (OracleCommand cmd = new OracleCommand(sqlAvgFee, conn))
                {
                    cmd.Parameters.Add(":startDate", start);
                    cmd.Parameters.Add(":endDate", end);

                    double avgFee = Convert.ToDouble(cmd.ExecuteScalar());
                    lblAvgFee.Text = $"평균 요금 : {Math.Round(avgFee, 0):N0} 원";
                }

                // 4) 일반 / 고속 선호도
                string sqlPref = @"
                    SELECT c.charger_type, COUNT(*)
                    FROM rental r
                    JOIN charger c ON r.charger_id = c.charger_id
                    WHERE r.rental_time BETWEEN :startDate AND :endDate
                    GROUP BY c.charger_type
                ";

                int normal = 0;
                int fast = 0;

                using (OracleCommand cmd = new OracleCommand(sqlPref, conn))
                {
                    cmd.Parameters.Add(":startDate", start);
                    cmd.Parameters.Add(":endDate", end);

                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (dr.GetString(0) == "일반") normal = dr.GetInt32(1);
                            else if (dr.GetString(0) == "고속") fast = dr.GetInt32(1);
                        }
                    }
                }

                int sum = normal + fast;
                lblPref.Text = sum == 0
                    ? "일반/고속 선호도 : 0% / 0%"
                    : $"일반/고속 선호도 : {normal * 100 / sum}% / {fast * 100 / sum}%";
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

            // 축 설명tats.ChartAreas[0];
            var ca = chartStats.ChartAreas[0];
            ca.AxisX.Title = "회원 ID";
            ca.AxisY.Title = "대여 횟수";

            // 축 색상
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
                    WHERE rental_time BETWEEN :startDate AND :endDate
                    GROUP BY member_id
                    ORDER BY member_id
                ";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":startDate", currentStart);
                    cmd.Parameters.Add(":endDate", currentEnd);

                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            s.Points.AddXY(dr.GetInt32(0), dr.GetInt32(1));
                        }
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

            int broken = 0;
            int normal = 0;

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
                    SELECT c.status, COUNT(*)
                    FROM rental r
                    JOIN charger c ON r.charger_id = c.charger_id
                    WHERE r.rental_time BETWEEN :startDate AND :endDate
                    GROUP BY c.status
                ";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":startDate", currentStart);
                    cmd.Parameters.Add(":endDate", currentEnd);

                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (dr.GetString(0) == "고장") broken += dr.GetInt32(1);
                            else normal += dr.GetInt32(1);
                        }
                    }
                }
            }

            int total = broken + normal;
            if (total == 0) return;

            double brokenRate = broken * 100.0 / total;
            double normalRate = normal * 100.0 / total;

            DataPoint pBroken = new DataPoint
            {
                YValues = new double[] { broken },
                Label = broken == 0 ? "" : $"{brokenRate:0.#}%",
                LegendText = $"고장 ({broken}건)",
                Color = Color.LightCoral
            };

            DataPoint pNormal = new DataPoint
            {
                YValues = new double[] { normal },
                Label = normal == 0 ? "" : $"{normalRate:0.#}%",
                LegendText = $"정상 ({normal}건)",
                Color = Color.LightGreen
            };

            if (broken > 0) s.Points.Add(pBroken);
            if (normal > 0) s.Points.Add(pNormal);

            s.Font = new Font("맑은 고딕", 14, FontStyle.Bold);
            chartStats.Legends[0].Font = new Font("맑은 고딕", 12, FontStyle.Regular);

            foreach (DataPoint p in s.Points)
            {
                p.Font = new Font("맑은 고딕", 14, FontStyle.Bold);
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

            // 축 설명
            ca.AxisX.Title = "대여 번호";
            ca.AxisY.Title = "요금 (원)";

            // 축 색상
            ca.AxisX.LineColor = Color.FromArgb(80, Color.Gray);
            ca.AxisY.LineColor = Color.FromArgb(80, Color.Gray);
            ca.AxisX.MajorGrid.LineColor = Color.FromArgb(50, Color.LightGray);
            ca.AxisY.MajorGrid.LineColor = Color.FromArgb(50, Color.LightGray);

            Series s = new Series("요금");
            s.ChartType = SeriesChartType.Column;
            s.IsValueShownAsLabel = false;

            s.Color = Color.LightSkyBlue;

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
                    SELECT rental_id, charge_amount
                    FROM rental
                    WHERE charge_amount IS NOT NULL
                      AND return_time BETWEEN :startDate AND :endDate
                    ORDER BY rental_id
                ";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":startDate", currentStart);
                    cmd.Parameters.Add(":endDate", currentEnd);

                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            s.Points.AddXY(dr.GetInt32(0), dr.GetDouble(1));
                        }
                    }
                }
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

            int normal = 0;
            int fast = 0;

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
                    SELECT c.charger_type, COUNT(*)
                    FROM rental r
                    JOIN charger c ON r.charger_id = c.charger_id
                    WHERE r.rental_time BETWEEN :startDate AND :endDate
                    GROUP BY c.charger_type
                ";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":startDate", currentStart);
                    cmd.Parameters.Add(":endDate", currentEnd);

                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (dr.GetString(0).Contains("일반")) normal += dr.GetInt32(1);
                            else if (dr.GetString(0).Contains("고속")) fast += dr.GetInt32(1);
                        }
                    }
                }
            }

            int total = normal + fast;
            if (total == 0) return;

            double nRate = normal * 100.0 / total;
            double fRate = fast * 100.0 / total;

            s.Points.Add(new DataPoint
            {
                YValues = new double[] { normal },
                Label = normal == 0 ? "" : $"{nRate:0.#}%",
                LegendText = $"일반 ({normal}회)",
                Color = Color.LightSkyBlue
            });

            s.Points.Add(new DataPoint
            {
                YValues = new double[] { fast },
                Label = fast == 0 ? "" : $"{fRate:0.#}%",
                LegendText = $"고속 ({fast}회)",
                Color = Color.LightCoral
            });

            s.Font = new Font("맑은 고딕", 14, FontStyle.Bold);
            chartStats.Legends[0].Font = new Font("맑은 고딕", 12, FontStyle.Regular);

            foreach (DataPoint p in s.Points)
            {
                p.Font = new Font("맑은 고딕", 14, FontStyle.Bold);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            currentStart = dtpStart.Value.Date;
            currentEnd = dtpEnd.Value.Date.AddDays(1).AddSeconds(-1);

            LoadSummaryStats(currentStart, currentEnd);

            // 기본 그래프 자동 표시
            btnAvgRent_Click(null, null);
        }
    }
}
