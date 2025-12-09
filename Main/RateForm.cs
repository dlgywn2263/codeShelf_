using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Main
{
    public partial class RateForm : Form
    {
        private int selectedRateId = -1; // 🔥 선택된 요금 ID 저장

        public RateForm()
        {
            InitializeComponent();

            dgvRate.AutoGenerateColumns = true;
            dgvRate.CellClick += dgvRate_CellClick;

            this.AutoScaleMode = AutoScaleMode.None;

            cmbRateType.Items.Add("일반");
            cmbRateType.Items.Add("고속");

            LoadRateList();
            cmbRateType.SelectedIndexChanged += cmbRateType_SelectedIndexChanged;
        }

        // 유형 선택 시 기본값 자동 설정
        private void cmbRateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBaseFee.Clear();
            txtFee2.Clear();
            txtFee3.Clear();
            txtOverFee.Clear();

            if (cmbRateType.Text == "일반")
            {
                txtBaseFee.Text = "3000";
                txtFee2.Text = "5000";
                txtFee3.Text = "7000";
                txtOverFee.Text = "2000";
            }
            else if (cmbRateType.Text == "고속")
            {
                txtBaseFee.Text = "6000";
                txtFee2.Text = "10000";
                txtFee3.Text = "15000";
                txtOverFee.Text = "3000";
            }
        }

        // 요금 목록 로드
        private void LoadRateList()
        {
            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
                    SELECT rate_id, charger_type, hours, price, late_price
                    FROM rate
                    ORDER BY charger_type, hours";

                OracleDataAdapter da = new OracleDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvRate.DataSource = dt;
            }

            dgvRate.Columns["RATE_ID"].HeaderText = "ID";
            dgvRate.Columns["CHARGER_TYPE"].HeaderText = "유형";
            dgvRate.Columns["HOURS"].HeaderText = "시간";
            dgvRate.Columns["PRICE"].HeaderText = "요금";
            dgvRate.Columns["LATE_PRICE"].HeaderText = "연체요금";
        }

        // Grid 클릭
        private void dgvRate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            selectedRateId = Convert.ToInt32(dgvRate.Rows[e.RowIndex].Cells["RATE_ID"].Value); // 🔥 선택된 ID 저장

            string type = dgvRate.Rows[e.RowIndex].Cells["CHARGER_TYPE"].Value.ToString();
            cmbRateType.Text = type;

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
                    SELECT hours, price, late_price
                    FROM rate
                    WHERE charger_type = :type
                    ORDER BY hours";

                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(":type", type);

                OracleDataReader dr = cmd.ExecuteReader();
                bool lateSet = false;

                while (dr.Read())
                {
                    int h = dr.GetInt32(0);
                    int price = dr.GetInt32(1);
                    int late = dr.GetInt32(2);

                    if (h == 1) txtBaseFee.Text = price.ToString();
                    if (h == 2) txtFee2.Text = price.ToString();
                    if (h == 3) txtFee3.Text = price.ToString();

                    if (!lateSet)
                    {
                        txtOverFee.Text = late.ToString();
                        lateSet = true;
                    }
                }
            }
        }

        // INSERT
        private void InsertRate(OracleConnection conn, string type, int hours, string price)
        {
            string sql = @"
                INSERT INTO rate(rate_id, charger_type, hours, price, late_price)
                VALUES(seq_rate.NEXTVAL, :type, :hours, :price, :late)";

            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.Parameters.Add(":type", type);
            cmd.Parameters.Add(":hours", hours);
            cmd.Parameters.Add(":price", price);
            cmd.Parameters.Add(":late", txtOverFee.Text);
            cmd.ExecuteNonQuery();
        }

        // UPDATE
        private void UpdateRate(OracleConnection conn, string type, int hours, string price)
        {
            string sql = @"
                UPDATE rate
                SET price = :price,
                    late_price = :late
                WHERE charger_type = :type AND hours = :hours";

            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.Parameters.Add(":price", price);
            cmd.Parameters.Add(":late", txtOverFee.Text);
            cmd.Parameters.Add(":type", type);
            cmd.Parameters.Add(":hours", hours);
            cmd.ExecuteNonQuery();
        }

        // DELETE — 🔥 선택된 rate_id 1개만 삭제
        private void DeleteRate(OracleConnection conn, int rateId)
        {
            string sql = @"DELETE FROM rate WHERE rate_id = :id";

            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.Parameters.Add(":id", rateId);
            cmd.ExecuteNonQuery();
        }

        // 추가
        private void btnRateAdd_Click_1(object sender, EventArgs e)
        {
            if (cmbRateType.Text == "")
            {
                MessageBox.Show("유형을 선택하세요.");
                return;
            }

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();
                OracleTransaction tran = conn.BeginTransaction();

                try
                {
                    InsertRate(conn, cmbRateType.Text, 1, txtBaseFee.Text);
                    InsertRate(conn, cmbRateType.Text, 2, txtFee2.Text);
                    InsertRate(conn, cmbRateType.Text, 3, txtFee3.Text);

                    tran.Commit();
                    MessageBox.Show("단가 추가 완료!");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("오류: " + ex.Message);
                }
            }

            LoadRateList();
        }

        // 수정
        private void btnRateUpdate_Click_1(object sender, EventArgs e)
        {
            if (cmbRateType.Text == "")
            {
                MessageBox.Show("수정할 유형을 선택하세요.");
                return;
            }

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();
                OracleTransaction tran = conn.BeginTransaction();

                try
                {
                    UpdateRate(conn, cmbRateType.Text, 1, txtBaseFee.Text);
                    UpdateRate(conn, cmbRateType.Text, 2, txtFee2.Text);
                    UpdateRate(conn, cmbRateType.Text, 3, txtFee3.Text);

                    tran.Commit();
                    MessageBox.Show("단가 수정 완료!");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("오류: " + ex.Message);
                }
            }

            LoadRateList();
        }

        // 삭제
        private void btnRateDelete_Click_1(object sender, EventArgs e)
        {
            if (selectedRateId == -1)
            {
                MessageBox.Show("삭제할 항목을 선택하세요.");
                return;
            }

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();
                OracleTransaction tran = conn.BeginTransaction();

                try
                {
                    DeleteRate(conn, selectedRateId);

                    tran.Commit();
                    MessageBox.Show("삭제 완료!");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("삭제 오류: " + ex.Message);
                }
            }

            LoadRateList();
        }

        // 메뉴 이동
        private void 메인화면ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MainForm().Show();
            this.Close();
        }

        private void 회원관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MemberForm().Show();
            this.Close();
        }

        private void 대여반납ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RentalForm().Show();
            this.Close();
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Start().Show();
            this.Close();
        }

        private void 충전기관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ChargerForm().Show();
            Close();
        }
    }
}
