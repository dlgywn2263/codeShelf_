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
                rental_id,
                member_id,
                charger_id,
                rate_id,
                rental_time,
                return_time,
                charge_amount
            FROM rental
            WHERE return_time BETWEEN :start_date AND :end_date
            ORDER BY rental_id
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
                dgvSettlement.Columns["RATE_ID"].HeaderText = "요금제 ID";
                dgvSettlement.Columns["RENTAL_TIME"].HeaderText = "대여 시간";
                dgvSettlement.Columns["RETURN_TIME"].HeaderText = "반납 시간";
                dgvSettlement.Columns["CHARGE_AMOUNT"].HeaderText = "총 요금";

                dgvSettlement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                SUM(charge_amount) AS SUM_PRICE,
                SUM(charge_amount) AS SUM_TOTAL,
                AVG(charge_amount) AS AVG_TOTAL
            FROM rental
            WHERE return_time BETWEEN :start_date AND :end_date
        ";

                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(":start_date", dtpStart.Value);
                cmd.Parameters.Add(":end_date", dtpEnd.Value);

                OracleDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtTotalCount.Text = SafeDecimal(dr["CNT"]).ToString();
                    txtSumPrice.Text = SafeDecimal(dr["SUM_PRICE"]).ToString();
                    txtLateSum.Text = "0"; // late_fee 없음
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
