using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Main
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadSystemStatus();   // 🔥 관리자 메인에서 실시간 DB 현황 표시
        }

        // -------------------------------------------------------------
        // 🔥 관리자 메인 화면 — 실시간 충전기 / 연체 / 반납 현황
        // -------------------------------------------------------------
        private void LoadSystemStatus()
        {
            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                //-------------------------------
                // 1) 전체 충전기 수
                //-------------------------------
                int totalCount = ExecuteCount(conn,
                    "SELECT COUNT(*) FROM charger");

                //-------------------------------
                // 2) 사용 중 충전기
                //-------------------------------
                int usingCount = ExecuteCount(conn,
                    "SELECT COUNT(*) FROM charger WHERE status = '사용중'");

                //-------------------------------
                // 3) 대기 중 충전기
                //-------------------------------
                int waitCount = ExecuteCount(conn,
                    "SELECT COUNT(*) FROM charger WHERE status = '대기'");

                //-------------------------------
                // 4) 고장 충전기
                //-------------------------------
                int brokenCount = ExecuteCount(conn,
                    "SELECT COUNT(*) FROM charger WHERE status = '고장'");

                //-------------------------------
                // 5) 연체 중: 반납 안했고(return_time NULL), 예정시간 < 지금
                //-------------------------------
                int lateCount = ExecuteCount(conn,
                    @"SELECT COUNT(*)
                      FROM rental
                      WHERE return_time IS NULL
                        AND rental_time + (rate_id / 24) < SYSDATE");

                //-------------------------------
                // 6) 오늘 반납 예정: 반납 안한 상태(return_time IS NULL)
                //-------------------------------
                int dueToday = ExecuteCount(conn,
                    @"SELECT COUNT(*)
                      FROM rental
                      WHERE return_time IS NULL
                        AND TRUNC(rental_time + (rate_id / 24)) = TRUNC(SYSDATE)");

                //-------------------------------
                // 📌 UI 출력
                //-------------------------------
                lblTotal.Text = $"- 전체 충전기: {totalCount}대";
                lblUsing.Text = $"- 사용중: {usingCount}대";
                lblWait.Text = $"- 대기 중: {waitCount}대";

                lblBroken.Text = $"- 고장 신고: {brokenCount}건";
                lblLate.Text = $"- 연체 중: {lateCount}건";
                lblDueToday.Text = $"- 오늘 반납 예정: {dueToday}건";
            }
        }

        // -------------------------------------------------------------
        // 📌 공통 COUNT 기능
        // -------------------------------------------------------------
        private int ExecuteCount(OracleConnection conn, string query)
        {
            return Convert.ToInt32(new OracleCommand(query, conn).ExecuteScalar());
        }

        // -------------------------------------------------------------
        // 🔥 관리자 메뉴 버튼 이동
        // -------------------------------------------------------------
        private void 회원관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MemberForm().Show();
            Close();
        }

        private void 충전기관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ChargerForm().Show();
            Close();
        }

        private void 대여반납ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RentalForm().Show();
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

        private void btnGoBroken_Click(object sender, EventArgs e)
        {
            new BrokenManageForm().Show();
            Close();
        }

        private void btnGoLocation_Click(object sender, EventArgs e)
        {
            new LocationForm().Show();
            Close();
        }

        private void btnSettlement_Click(object sender, EventArgs e)
        {
            new SettlementForm().Show();
            Close();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadSystemStatus();
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            new StatsForm().Show();
            Close();
        }
    }
}
