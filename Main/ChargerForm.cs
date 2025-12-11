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

            // 🔥 지점명, 단가는 수정 못 하게
            //txtLocationName.ReadOnly = true;
            //txtPrice.ReadOnly = true;

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
                c.charger_id,
                c.location_id,
                l.location_name,
                c.rate_id,
                r.price,
                c.status,
                c.battery_remain,
                c.charger_type
            FROM charger c
            LEFT JOIN location l ON c.location_id = l.location_id
            LEFT JOIN rate r ON c.rate_id = r.rate_id
            ORDER BY c.charger_id";

                OracleDataAdapter da = new OracleDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvCharger.DataSource = dt;
            }

            dgvCharger.Columns["CHARGER_ID"].HeaderText = "ID";
            dgvCharger.Columns["LOCATION_ID"].HeaderText = "지점 ID";
            dgvCharger.Columns["LOCATION_NAME"].HeaderText = "지점명";
            dgvCharger.Columns["RATE_ID"].HeaderText = "단가 ID";
            dgvCharger.Columns["PRICE"].HeaderText = "단가";
            dgvCharger.Columns["STATUS"].HeaderText = "상태";
            dgvCharger.Columns["BATTERY_REMAIN"].HeaderText = "배터리(%)";
            dgvCharger.Columns["CHARGER_TYPE"].HeaderText = "유형";
            dgvCharger.Columns["LOCATION_ID"].Visible = false;
            dgvCharger.Columns["RATE_ID"].Visible = false;

        }


        //------------------------------------------------------------
        // 🔥 DataGridView 클릭 → 상세 정보에 반영
        //------------------------------------------------------------
        private void dgvCharger_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvCharger.Rows[e.RowIndex];

            txtChargerId.Text = row.Cells["CHARGER_ID"].Value.ToString();
            txtLocationName.Text = row.Cells["LOCATION_NAME"].Value.ToString();
            txtPrice.Text = row.Cells["PRICE"].Value.ToString();
            txtBattery.Text = row.Cells["BATTERY_REMAIN"].Value.ToString();

            cmbChargerStatus.Text = row.Cells["STATUS"].Value.ToString();
            cmbChargerType.Text = row.Cells["CHARGER_TYPE"].Value.ToString();
        }




        //------------------------------------------------------------
        // 🔥 충전기 추가
        //------------------------------------------------------------
        private void btnChargerAdd_Click_1(object sender, EventArgs e)
        {
            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                // -----------------------------
                // 1) location_id 조회
                // -----------------------------
                string sqlLoc = "SELECT location_id FROM location WHERE location_name = :name";
                OracleCommand cmdLoc = new OracleCommand(sqlLoc, conn);
                cmdLoc.Parameters.Add(":name", txtLocationName.Text);
                int locationId = Convert.ToInt32(cmdLoc.ExecuteScalar());

                // -----------------------------
                // 2) rate_id 조회
                // -----------------------------
                string sqlRate = "SELECT rate_id FROM rate WHERE price = :price";
                OracleCommand cmdRate = new OracleCommand(sqlRate, conn);
                cmdRate.Parameters.Add(":price", txtPrice.Text);
                int rateId = Convert.ToInt32(cmdRate.ExecuteScalar());

                int battery = txtBattery.Text == "" ? 100 : int.Parse(txtBattery.Text);

                // -----------------------------
                // 3) charger 테이블에 INSERT
                // -----------------------------
                string sql = @"
            INSERT INTO charger
                (charger_id, location_id, rate_id, status, battery_remain, charger_type)
            VALUES 
                (SEQ_CHARGER.NEXTVAL, :loc, :rate, '대기', :battery, :type)";

                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(":loc", locationId);
                cmd.Parameters.Add(":rate", rateId);
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
            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                // 1) location_id 조회
                string sqlLoc = "SELECT location_id FROM location WHERE location_name = :name";
                OracleCommand cmdLoc = new OracleCommand(sqlLoc, conn);
                cmdLoc.Parameters.Add(":name", txtLocationName.Text);
                int locationId = Convert.ToInt32(cmdLoc.ExecuteScalar());

                // 2) rate_id 조회
                string sqlRate = "SELECT rate_id FROM rate WHERE price = :price";
                OracleCommand cmdRate = new OracleCommand(sqlRate, conn);
                cmdRate.Parameters.Add(":price", txtPrice.Text);
                int rateId = Convert.ToInt32(cmdRate.ExecuteScalar());

                // 3) UPDATE 요청
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
                cmd.Parameters.Add(":loc", locationId);
                cmd.Parameters.Add(":rate", rateId);
                cmd.Parameters.Add(":status", cmbChargerStatus.Text);
                cmd.Parameters.Add(":battery", txtBattery.Text);
                cmd.Parameters.Add(":type", cmbChargerType.Text);
                cmd.Parameters.Add(":id", txtChargerId.Text);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("충전기 수정 완료!");
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
