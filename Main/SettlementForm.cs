using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Main
{
    public partial class SettlementForm : Form
    {
        public SettlementForm()
        {
            InitializeComponent();
        }

        // ================================
        // 📌 조회 버튼 클릭
        // ================================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadSettlementList();
            LoadSummary();
        }

        // ================================
        // 📌 정산 목록 조회
        // ================================
        private void LoadSettlementList()
        {
            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
            SELECT 
                r.rental_id,
                r.member_id,
                r.charger_id,
                r.rental_time,
                r.return_time,
                rt.price AS base_price,
                rt.late_price AS late_price,
                (rt.price + rt.late_price) AS total_price
            FROM rental r
            JOIN rate rt ON r.rate_id = rt.rate_id
            WHERE r.return_time BETWEEN :start_date AND :end_date
            ORDER BY r.rental_id
        ";

                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(":start_date", dtpStart.Value);
                cmd.Parameters.Add(":end_date", dtpEnd.Value);

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvSettlement.DataSource = dt;

                dgvSettlement.Columns["RENTAL_ID"].HeaderText = "대여 ID";
                dgvSettlement.Columns["MEMBER_ID"].HeaderText = "회원 ID";
                dgvSettlement.Columns["CHARGER_ID"].HeaderText = "충전기 ID";
                dgvSettlement.Columns["RENTAL_TIME"].HeaderText = "대여 시간";
                dgvSettlement.Columns["RETURN_TIME"].HeaderText = "반납 시간";
                dgvSettlement.Columns["BASE_PRICE"].HeaderText = "기본 요금";
                dgvSettlement.Columns["LATE_PRICE"].HeaderText = "연체 요금";
                dgvSettlement.Columns["TOTAL_PRICE"].HeaderText = "총 요금";

                dgvSettlement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvSettlement.Columns["RENTAL_TIME"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvSettlement.Columns["RETURN_TIME"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dgvSettlement.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvSettlement.RowTemplate.Height = 40;

            }
        }



        private decimal SafeDecimal(object val)
        {
            if (val == DBNull.Value || val == null)
                return 0;

            decimal result;
            if (decimal.TryParse(val.ToString(), out result))
                return result;

            return 0;
        }





        // ================================
        // 📌 요약 정보 계산 (SUM, AVG, COUNT)
        // ================================
        private void LoadSummary()
        {
            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
            SELECT 
                COUNT(*) AS CNT,
                SUM(rt.price) AS SUM_BASE,
                SUM(rt.late_price) AS SUM_LATE,
                SUM(rt.price + rt.late_price) AS SUM_TOTAL,
                AVG(rt.price + rt.late_price) AS AVG_TOTAL
            FROM rental r
            JOIN rate rt ON r.rate_id = rt.rate_id
            WHERE r.return_time BETWEEN :start_date AND :end_date
        ";

                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(":start_date", dtpStart.Value);
                cmd.Parameters.Add(":end_date", dtpEnd.Value);

                OracleDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtTotalCount.Text = SafeDecimal(dr["CNT"]).ToString();
                    txtSumPrice.Text = SafeDecimal(dr["SUM_BASE"]).ToString();
                    txtLateSum.Text = SafeDecimal(dr["SUM_LATE"]).ToString();   // 🔥 연체요금 합
                    txtTotalSum.Text = SafeDecimal(dr["SUM_TOTAL"]).ToString();
                    txtAvgPrice.Text = SafeDecimal(dr["AVG_TOTAL"]).ToString();
                }
            }
        }




        private void btnBack_Click(object sender, EventArgs e)
        {
            new MainForm().Show();
            this.Close();
        }

        private void txtTotalCount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
