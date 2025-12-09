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

            lblReady.Text = $"대기 : {wait}대";
            lblUsing.Text = $"사용중 : {usingCount}대";
            lblBroken.Text = $"고장 : {broken}대";
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

            card.Controls.Add(lbl);

            card.DoubleClick += (s, e) =>
            {
                MessageBox.Show(
                    $"[충전기 정보]\n\n" +
                    $"ID : {id}\n" +
                    $"종류 : {type}\n" +
                    $"배터리 : {battery}%\n" +
                    $"상태 : {status}",
                    "충전기 상세정보");
            };

            flowPanelChargers.Controls.Add(card);
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
    }
}
