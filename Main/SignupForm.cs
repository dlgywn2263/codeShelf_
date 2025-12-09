using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Main
{
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;  // DPI 대응
            this.StartPosition = FormStartPosition.CenterScreen; // 중앙정렬
        }

        private void BtnSignup_Click(object sender, EventArgs e)
        {
            string userName = txtName.Text.Trim();
            string userId = txtId.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string pw = txtPw.Text.Trim();
            string pw2 = txtPw2.Text.Trim();

            // ---------------------------
            // 1. 입력값 검증
            // ---------------------------
            if (userName == "" || userId == "" || phone == "" || pw == "" || pw2 == "")
            {
                MessageBox.Show("모든 항목을 입력해주세요.");
                return;
            }

            if (pw != pw2)
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.");
                return;
            }

            // ---------------------------
            // 2. DB 연결
            // ---------------------------
            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                // ---------------------------
                // 3. ID 중복 체크
                // ---------------------------
                string checkSql = "SELECT COUNT(*) FROM member WHERE id = :id";
                using (OracleCommand checkCmd = new OracleCommand(checkSql, conn))
                {
                    checkCmd.Parameters.Add(":id", userId);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("이미 사용 중인 ID입니다.");
                        return;
                    }
                }

                // ---------------------------
                // 4. 회원 INSERT
                //    ⚠ 테이블 컬럼 순서에 맞춰 정확히 작성함!!
                // ---------------------------
                string insertSql = @"
                    INSERT INTO member 
                        (member_id, name, id, password, phone, reliability, role, status)
                    VALUES 
                        (seq_member.NEXTVAL, :name, :id, :password, :phone, 100, 'user', '활동')
                ";

                using (OracleCommand insertCmd = new OracleCommand(insertSql, conn))
                {
                    insertCmd.Parameters.Add(":name", userName);
                    insertCmd.Parameters.Add(":id", userId);
                    insertCmd.Parameters.Add(":password", pw);
                    insertCmd.Parameters.Add(":phone", phone);

                    int result = insertCmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("회원가입이 완료되었습니다!");

                        Start start = new Start();
                        start.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("회원가입에 실패했습니다. 다시 시도해주세요.");
                    }
                }
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Start s = new Start();
            s.Show();
            this.Close();
        }

        // 전화번호 숫자만 입력 허용
        private void txtPhone_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    

        private void txtPhone_TextChanged_1(object sender, EventArgs e)
        {
            string numbersOnly = new string(txtPhone.Text.Where(char.IsDigit).ToArray());

            if (numbersOnly.Length >= 11)
                numbersOnly = numbersOnly.Substring(0, 11);

            string formatted = "";

            if (numbersOnly.Length < 4)  // 010
            {
                formatted = numbersOnly;
            }
            else if (numbersOnly.Length < 8)  // 010-0000
            {
                formatted = numbersOnly.Substring(0, 3) + "-" +
                            numbersOnly.Substring(3);
            }
            else   // 010-0000-0000
            {
                formatted = numbersOnly.Substring(0, 3) + "-" +
                            numbersOnly.Substring(3, 4) + "-" +
                            numbersOnly.Substring(7);
            }

            // 커서 위치가 튀지 않도록 처리
            int selectionStart = txtPhone.SelectionStart;
            txtPhone.Text = formatted;
            txtPhone.SelectionStart = Math.Min(selectionStart, txtPhone.Text.Length);
        }
    }
}
