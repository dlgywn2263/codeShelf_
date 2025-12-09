using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Main
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        // ============================================================
        //  로그인 버튼
        // ============================================================

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string id = txtId.Text.Trim();
            string pw = txtPw.Text.Trim();

            if (id == "" || pw == "")
            {
                MessageBox.Show("아이디와 비밀번호를 입력하세요.");
                return;
            }

            // 1) 사용자 정보 조회
            var user = GetUserInfo(id, pw);

            if (user == null)
            {
                MessageBox.Show("아이디 또는 비밀번호가 올바르지 않습니다.");
                return;
            }

            // 2) 정지 계정 여부 확인
            if (user.Status != "활동")
            {
                MessageBox.Show("현재 정지된 계정입니다.");
                return;
            }

            // 3) 세션 저장
            UserSession.MemberId = user.MemberId;

            // 4) 역할에 따른 분기
            if (user.Role == "admin")
            {
                MainForm admin = new MainForm();
                admin.Show();
                this.Hide();
            }
            else
            {
                UserMainForm userForm = new UserMainForm();
                userForm.Show();
                this.Hide();
            }
        }


        // ============================================================
        //  회원가입 버튼
        // ============================================================
        private void BtnSignup_Click(object sender, EventArgs e)
        {
            SignupForm signup = new SignupForm();
            signup.Show();
            this.Hide();
        }


        // ============================================================
        // ⭐ 사용자 정보 조회 (role + member_id + status)
        // ============================================================
        private MemberDTO GetUserInfo(string userId, string pw)
        {
            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
                    SELECT member_id, role, status
                    FROM member
                    WHERE id = :userId AND password = :pw";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":userId", userId);
                    cmd.Parameters.Add(":pw", pw);

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new MemberDTO
                            {
                                MemberId = reader.GetInt32(0),
                                Role = reader.GetString(1),
                                Status = reader.GetString(2)
                            };
                        }
                    }
                }
            }
            return null;
        }

        // ============================================================
        //  비밀번호 찾기 페이지 이동
        // ============================================================
        private void BtnPasswd_Click(object sender, EventArgs e)
        {
            Passwd pw = new Passwd();
            pw.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtId_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPw.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtPw_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnLogin_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }
    }

    // ==============================
    // DTO 클래스 추가
    // ==============================
    public class MemberDTO
    {
        public int MemberId { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
    }

}
