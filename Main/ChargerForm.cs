using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Main
{
    public partial class ChargerForm : Form
    {
        public ChargerForm()
        {
            InitializeComponent();

            dgvCharger.AutoGenerateColumns = true;

            LoadStatusList();
            LoadTypeList();
            LoadChargerList();

            dgvCharger.CellClick += dgvCharger_CellClick;
        }

        //------------------------------------------------------------
        // 상태 목록
        //------------------------------------------------------------
        private void LoadStatusList()
        {
            cmbChargerStatus.Items.Clear();
            cmbChargerStatus.Items.Add("대기");
            cmbChargerStatus.Items.Add("사용중");
            cmbChargerStatus.Items.Add("고장");
        }

        //------------------------------------------------------------
        // 유형 목록
        //------------------------------------------------------------
        private void LoadTypeList()
        {
            cmbChargerType.Items.Clear();
            cmbChargerType.Items.Add("일반");
            cmbChargerType.Items.Add("고속");
        }

        //------------------------------------------------------------
        // 🔥 DB에서 charger 목록 불러오기
        //------------------------------------------------------------
        private void LoadChargerList()
        {
            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
                    SELECT 
                        charger_id,
                        location_id,
                        rate_id,
                        status,
                        battery_remain,
                        charger_type
                    FROM charger
                    ORDER BY charger_id";

                OracleDataAdapter da = new OracleDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvCharger.DataSource = dt;
            }

            dgvCharger.Columns["CHARGER_ID"].HeaderText = "ID";
            dgvCharger.Columns["LOCATION_ID"].HeaderText = "위치 ID";
            dgvCharger.Columns["RATE_ID"].HeaderText = "단가 ID";
            dgvCharger.Columns["STATUS"].HeaderText = "상태";
            dgvCharger.Columns["BATTERY_REMAIN"].HeaderText = "배터리(%)";
            dgvCharger.Columns["CHARGER_TYPE"].HeaderText = "유형";
        }

        //------------------------------------------------------------
        // 🔥 DataGridView 클릭 → 상세 정보에 반영
        //------------------------------------------------------------
        private void dgvCharger_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvCharger.Rows[e.RowIndex];

            txtChargerId.Text = row.Cells["CHARGER_ID"].Value.ToString();
            txtLocationId.Text = row.Cells["LOCATION_ID"].Value.ToString();
            txtRateId.Text = row.Cells["RATE_ID"].Value.ToString();
            txtBattery.Text = row.Cells["BATTERY_REMAIN"].Value.ToString();

            cmbChargerStatus.Text = row.Cells["STATUS"].Value.ToString();
            cmbChargerType.Text = row.Cells["CHARGER_TYPE"].Value.ToString();
        }

        //------------------------------------------------------------
        // 🔥 충전기 추가
        //------------------------------------------------------------
        private void btnChargerAdd_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLocationId.Text) ||
         string.IsNullOrWhiteSpace(txtRateId.Text) ||
         string.IsNullOrWhiteSpace(cmbChargerType.Text))
            {
                MessageBox.Show("위치ID / 단가ID / 유형은 반드시 입력해야 합니다.");
                return;
            }

            int battery = txtBattery.Text == "" ? 100 : int.Parse(txtBattery.Text);

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
            INSERT INTO charger
            (charger_id, location_id, rate_id, status, battery_remain, charger_type)
            VALUES (SEQ_CHARGER.NEXTVAL, :loc, :rate, '대기', :battery, :type)";

                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(":loc", txtLocationId.Text);
                cmd.Parameters.Add(":rate", txtRateId.Text);
                cmd.Parameters.Add(":battery", battery);
                cmd.Parameters.Add(":type", cmbChargerType.Text);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("충전기 등록 완료!");
            LoadChargerList();
        }

        //------------------------------------------------------------
        // 🔥 충전기 수정
        //------------------------------------------------------------
        private void btnChargerUpdate_Click_1(object sender, EventArgs e)
        {
            if (txtChargerId.Text == "")
            {
                MessageBox.Show("수정할 충전기를 선택하세요.");
                return;
            }

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
                    UPDATE charger
                    SET 
                        location_id = :loc,
                        rate_id = :rate,
                        status = :status,
                        battery_remain = :battery,
                        charger_type = :type
                    WHERE charger_id = :id";

                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(":loc", txtLocationId.Text);
                cmd.Parameters.Add(":rate", txtRateId.Text);
                cmd.Parameters.Add(":status", cmbChargerStatus.Text);
                cmd.Parameters.Add(":battery", txtBattery.Text);
                cmd.Parameters.Add(":type", cmbChargerType.Text);
                cmd.Parameters.Add(":id", txtChargerId.Text);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("충전기 정보 수정 완료!");
            LoadChargerList();
        }

        //------------------------------------------------------------
        // 🔥 충전기 삭제
        //------------------------------------------------------------
        private void btnChargerDelete_Click_1(object sender, EventArgs e)
        {
            if (txtChargerId.Text == "")
            {
                MessageBox.Show("삭제할 충전기를 선택하세요.");
                return;
            }

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = "DELETE FROM charger WHERE charger_id = :id";

                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(":id", txtChargerId.Text);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("충전기 삭제 완료!");
            LoadChargerList();
        }

        //------------------------------------------------------------
        // 메뉴 이동
        //------------------------------------------------------------
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

        private void 단가관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RateForm().Show();
            this.Close();
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Start().Show();
            this.Close();
        }
    }
}
