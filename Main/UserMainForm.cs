using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Main
{
    public partial class UserMainForm : Form
    {
        private string userName;   // 로그인한 사용자 이름
        private string userId;     // 로그인한 사용자 아이디

        public UserMainForm()
        {
            InitializeComponent();

            LoadLoginUserInfo();  // 로그인 사용자 정보 불러오기

            // 창 제목
            this.Text = $"{userId}님, 환영합니다!";

            // 화면 중앙 문구
            labelWelcome.Text = $"{userId}님, 환영합니다!";
        }

        // ============================================================
        // 로그인한 사용자 정보 불러오기 (member 테이블 기반)
        // ============================================================
        private void LoadLoginUserInfo()
        {
            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
                    SELECT name, id 
                    FROM member 
                    WHERE member_id = :mid
                ";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":mid", UserSession.MemberId);

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userName = reader.GetString(0);   // name
                            userId = reader.GetString(1);     // id
                        }
                        else
                        {
                            // 로그인 정보가 없을 경우 대비
                            userName = "사용자";
                            userId = "";
                        }
                    }
                }
            }
        }

        // ============================================================
        // 버튼 이벤트 (대여 / 반납 / 고장신고 / 사용내역)
        // ============================================================
        private void BtnRent_Click(object sender, EventArgs e)
        {
            new UserRentalForm().Show();
            this.Close();
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            new UserReturnForm().Show();
            this.Close();
        }

        private void BtnBroken_Click(object sender, EventArgs e)
        {
            new BrokenForm().Show();
            this.Close();
        }



        // ============================================================
        // 메뉴 이벤트
        // ============================================================
        private void menuBroken_Click(object sender, EventArgs e)
        {
            new BrokenForm().Show();
            this.Close();
        }

        private void menuHistory_Click(object sender, EventArgs e)
        {
            new UserHistoryForm().Show();
            this.Close();
        }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            new Start().Show();
            this.Close();
        }

        private void BtnHistory_Click_1(object sender, EventArgs e)
        {
            new UserHistoryForm().Show();
            this.Close();
        }
    }
}
