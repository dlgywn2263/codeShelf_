using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Main
{
    public partial class UserHistoryForm : Form
    {
        private bool isFormLoaded = false; // 🔥 폼 생성 완료 체크

        public UserHistoryForm()
        {
            InitializeComponent();

            InitializeFilters();  // 콤보박스 기본값 설정 (이때 이벤트 발생 막힘)

            string userId = GetLoginUserId();
            this.Text = $"{userId}님의 사용 내역입니다.";
            title.Text = $"{userId}님의 사용 내역 입니다.";

            isFormLoaded = true;  // 폼 준비 완료 표시
            LoadHistory(); // 🔥 폼 로딩 끝난 후 안전하게 호출
        }

        // =============================================
        // 🔥 필터 초기화
        // =============================================
        private void InitializeFilters()
        {
            // 이벤트 비활성화
            cbSort.SelectedIndexChanged -= cbSort_SelectedIndexChanged;
            cbDateFilter.SelectedIndexChanged -= cbDateFilter_SelectedIndexChanged;

            cbSort.Items.Clear();
            // 정렬 옵션
            cbSort.Items.AddRange(new string[]
            {
                "최신순",
                "오래된순",
                "요금 높은순",
                "요금 낮은순"
            });
            cbSort.SelectedIndex = 0;

            cbDateFilter.Items.Clear();
            // 기간 옵션
            cbDateFilter.Items.AddRange(new string[]
            {
                "전체",
                "오늘",
                "이번 주",
                "이번 달"
            });
            cbDateFilter.SelectedIndex = 0;

            // 이벤트 다시 활성화
            cbSort.SelectedIndexChanged += cbSort_SelectedIndexChanged;
            cbDateFilter.SelectedIndexChanged += cbDateFilter_SelectedIndexChanged;
        }

        // =============================================
        // 🔥 DB에서 사용 내역 로드
        // =============================================
        private void LoadHistory()
        {
            if (!isFormLoaded) return;

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string keyword = txtSearch.Text.Trim();
                string orderBy = "ORDER BY r.rental_id DESC";

                // 🔥 정렬 조건 적용
                switch (cbSort.SelectedItem?.ToString())
                {
                    case "오래된순":
                        orderBy = "ORDER BY r.rental_id ASC";
                        break;

                    case "요금 높은순":
                        orderBy = "ORDER BY r.charge_amount DESC";
                        break;

                    case "요금 낮은순":
                        orderBy = "ORDER BY r.charge_amount ASC";
                        break;
                }

                // 🔥 기간 필터링 조건
                string dateFilter = "";
                DateTime today = DateTime.Today;

                int diff = today.DayOfWeek == DayOfWeek.Sunday ? 6 : (int)today.DayOfWeek - 1;
                DateTime weekStart = today.AddDays(-diff);
                DateTime monthStart = new DateTime(today.Year, today.Month, 1);

                switch (cbDateFilter.SelectedItem?.ToString())
                {
                    case "오늘":
                        dateFilter = " AND TRUNC(r.rental_time) = TRUNC(SYSDATE) ";
                        break;

                    case "이번 주":
                        dateFilter =
                            $" AND r.rental_time >= TO_DATE('{weekStart:yyyy-MM-dd}', 'YYYY-MM-DD') " +
                            $" AND r.rental_time < TO_DATE('{weekStart.AddDays(7):yyyy-MM-dd}', 'YYYY-MM-DD') ";
                        break;

                    case "이번 달":
                        dateFilter =
                            $" AND r.rental_time >= TO_DATE('{monthStart:yyyy-MM-dd}', 'YYYY-MM-DD') " +
                            $" AND r.rental_time < ADD_MONTHS(TO_DATE('{monthStart:yyyy-MM-dd}', 'YYYY-MM-DD'), 1) ";
                        break;
                }

                string sql = $@"
                    SELECT 
                        r.rental_id AS ""대여번호"",
                        c.charger_type AS ""유형"",
                        r.rental_time AS ""대여시간"",
                        r.return_time AS ""반납시간"",
                        r.charge_amount AS ""요금""
                    FROM rental r
                    JOIN charger c ON r.charger_id = c.charger_id
                    WHERE r.member_id = :mid
                      AND (
                            c.charger_type LIKE '%' || :keyword || '%' OR
                            TO_CHAR(r.rental_time, 'YYYY-MM-DD HH24:MI') LIKE '%' || :keyword || '%' OR
                            TO_CHAR(r.return_time, 'YYYY-MM-DD HH24:MI') LIKE '%' || :keyword || '%' OR
                            TO_CHAR(r.charge_amount) LIKE '%' || :keyword || '%'
                          )
                      {dateFilter}
                    {orderBy}
                ";

                using (OracleDataAdapter da = new OracleDataAdapter(sql, conn))
                {
                    da.SelectCommand.Parameters.Add(":mid", UserSession.MemberId);
                    da.SelectCommand.Parameters.Add(":keyword", keyword);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvHistory.DataSource = dt;
                }
            }
        }

        // =============================================
        // 🔥 이벤트 핸들러
        // =============================================



        private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isFormLoaded)
                LoadHistory();
        }

        private void cbDateFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isFormLoaded)
                LoadHistory();
        }

        // =============================================
        // 🔥 로그인한 사용자 ID 가져오기
        // =============================================
        private string GetLoginUserId()
        {
            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = "SELECT id FROM member WHERE member_id = :mid";
                OracleCommand cmd = new OracleCommand(sql, conn);

                cmd.Parameters.Add(":mid", UserSession.MemberId);

                object result = cmd.ExecuteScalar();
                return result?.ToString() ?? "사용자";
            }
        }

        // =============================================
        // 🔥 메뉴 이동
        // =============================================
        private void menuMain_Click(object sender, EventArgs e)
        {
            new UserMainForm().Show();
            this.Close();
        }

        private void menuBroken_Click(object sender, EventArgs e)
        {
            new BrokenForm().Show();
            this.Close();
        }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            new Start().Show();
            this.Close();
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            LoadHistory();
        }

        private void txtSearch_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadHistory();
                e.SuppressKeyPress = true;
            }
        }
    }
}
