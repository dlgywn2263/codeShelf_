using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Main
{
    public partial class RentalForm : Form
    {
        public RentalForm()
        {
            InitializeComponent();

            LoadChargerCards();
            UpdateStatusCount();
        }

        private void UpdateStatusCount()
        {
            int wait = 0, usingCount = 0, broken = 0;

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = "SELECT STATUS FROM CHARGER";
                OracleCommand cmd = new OracleCommand(sql, conn);
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string status = dr.GetString(0);

                    if (status == "대기") wait++;
                    else if (status == "사용중") usingCount++;
                    else if (status == "고장") broken++;
                }
            }

            //lblReady.Text = $"대기 : {wait}대";
            //lblUsing.Text = $"사용중 : {usingCount}대";
            //lblBroken.Text = $"고장 : {broken}대";
        }

        private void CreateChargerCard(DataRow row)
        {
            Panel card = new Panel();
            card.Width = 180;
            card.Height = 110;
            card.Margin = new Padding(10);
            card.Padding = new Padding(10);
            card.Cursor = Cursors.Hand;

            int id = Convert.ToInt32(row["CHARGER_ID"]);
            string type = row["CHARGER_TYPE"].ToString();
            int battery = Convert.ToInt32(row["BATTERY_REMAIN"]);
            string status = row["STATUS"].ToString();

            if (status == "대기")
            {
                if (battery == 0)
                    card.BackColor = Color.FromArgb(255, 128, 128);
                else
                    card.BackColor = Color.FromArgb(180, 220, 255);
            }
            else if (status == "사용중")
            {
                card.BackColor = Color.FromArgb(180, 255, 180);
                card.BorderStyle = BorderStyle.Fixed3D;
            }
            else if (status == "고장")
            {
                card.BackColor = Color.FromArgb(200, 200, 200);
            }

            Label lbl = new Label();
            lbl.Dock = DockStyle.Fill;
            lbl.Font = new Font("맑은 고딕", 9, FontStyle.Bold);
            lbl.Text =
                $"충전기 ID : {id}\n" +
                $"종류 : {type}\n" +
                $"배터리 : {battery}%";

            // 🔥 Label도 클릭 이벤트 연결
            card.Click += (s, e) =>
            {
                // 1️⃣ 기본 충전기 정보 먼저 표시
                lblDetailCharger.Text = $"충전기 ID : {id}";
                lblDetailStatus.Text = $"현재 상태 : {status}";
                lblDetailUser.Text = "사용자 : -";
                lblDetailRentalTime.Text = "대여 시각 : -";
                lblDetailReturnTime.Text = "반납 예정 : -";
                lblDetailLate.Text = "연체 여부 : -";

                // 2️⃣ 대여 중이면 상세 정보 덮어쓰기
                LoadRentalDetail(id);

                // 3️⃣ 대여 이력
                LoadRentalHistory(id);
            };


            card.Controls.Add(lbl);

            // Panel 클릭도 유지
            card.Click += (s, e) =>
            {
                LoadRentalDetail(id);
                LoadRentalHistory(id);
            };


            flowPanelChargers.Controls.Add(card);
        }
        private void LoadRentalHistory(int chargerId)
        {
            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
            SELECT
                r.rental_id   AS ""대여번호"",
                m.name        AS ""사용자"",
            
                r.rental_time AS ""대여시각"",
                r.return_time AS ""반납시각"",
                r.charge_amount AS ""결제금액""
            FROM rental r
            JOIN member m  ON r.member_id = m.member_id
            JOIN charger c ON r.charger_id = c.charger_id
            WHERE r.charger_id = :charger_id
            ORDER BY r.rental_time DESC
        ";

                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(":charger_id", chargerId);

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvRentalHistory.DataSource = dt;

                // 보기 좋게
                dgvRentalHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvRentalHistory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvRentalHistory.RowTemplate.Height = 40;

                // 전체 기본은 줄바꿈 X
                dgvRentalHistory.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

                // 날짜 컬럼만 줄바꿈
                dgvRentalHistory.Columns["대여시각"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvRentalHistory.Columns["반납시각"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            }
        }




        private void LoadRentalDetail(int chargerId)
        {
            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
            SELECT
                r.member_id,
                m.name,
                r.rental_time,
                r.return_time,
                r.rental_time + NUMTODSINTERVAL(rt.hours, 'HOUR') AS expected_return
            FROM rental r
            JOIN member m ON r.member_id = m.member_id
            JOIN rate rt ON r.rate_id = rt.rate_id
            WHERE r.charger_id = :charger_id
            AND r.return_time IS NULL
        ";

                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(":charger_id", chargerId);

                OracleDataReader dr = cmd.ExecuteReader();

                lblDetailCharger.Text = $"충전기 ID : {chargerId}";

                if (dr.Read())
                {
                    DateTime expected = Convert.ToDateTime(dr["EXPECTED_RETURN"]);

                    lblDetailStatus.Text = "현재 상태 : 사용중";
                    lblDetailUser.Text = $"사용자 : {dr["NAME"]}";
                    lblDetailRentalTime.Text = $"대여 시각 : {dr["RENTAL_TIME"]}";
                    lblDetailReturnTime.Text = $"반납 예정 : {expected}";

                    lblDetailLate.Text =
                        DateTime.Now > expected ? "연체 여부 : 연체" : "연체 여부 : 정상";
                }
                else
                {
                    lblDetailStatus.Text = "현재 상태 : 대기";
                    lblDetailUser.Text = "사용자 : -";
                    lblDetailRentalTime.Text = "대여 시각 : -";
                    lblDetailReturnTime.Text = "반납 예정 : -";
                    lblDetailLate.Text = "연체 여부 : -";
                }
            }
        }
        private void RentalForm_Load(object sender, EventArgs e)
        {
            lblDetailCharger.Text = "충전기를 선택하세요";
            lblDetailStatus.Text = "";
            lblDetailUser.Text = "";
            lblDetailRentalTime.Text = "";
            lblDetailReturnTime.Text = "";
            lblDetailLate.Text = "";
        }


        private void LoadChargerCards()
        {
            flowPanelChargers.Controls.Clear();

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();
                string sql = @"
                    SELECT charger_id, charger_type, battery_remain, status
                    FROM charger ORDER BY charger_id";

                OracleDataAdapter da = new OracleDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                    CreateChargerCard(row);
            }
        }

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

        private void 충전기관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ChargerForm().Show();
            Close();
        }

        private void 단가관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RateForm().Show();
            Close();
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Start().Show();
            this.Close();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblDetailLate_Click(object sender, EventArgs e)
        {

        }
    }
}
