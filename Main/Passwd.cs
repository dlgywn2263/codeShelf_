using System;
using System.Linq;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Main
{
    public partial class Passwd : Form
    {
        private bool isVerified = false;

        public Passwd()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // ------------------------------------
        // 전화번호 자동 하이픈
        // ------------------------------------


        private void BtnCheck_Click(object sender, EventArgs e)
        {
            string userId = txtId.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (userId == "" || phone == "")
            {
                MessageBox.Show("아이디와 전화번호를 모두 입력해주세요.");
                return;
            }

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"SELECT COUNT(*) 
                               FROM member 
                               WHERE id = :id AND phone = :phone";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":id", userId);
                    cmd.Parameters.Add(":phone", phone);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 1)
                    {
                        MessageBox.Show("본인 인증이 완료되었습니다!");

                        isVerified = true;

                        txtPwReset.Enabled = true;
                        txtPwReset2.Enabled = true;
                        BtnReset.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("입력한 정보가 일치하지 않습니다.");
                    }
                }
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            if (!isVerified)
            {
                MessageBox.Show("먼저 아이디와 전화번호 인증을 완료해주세요.");
                return;
            }

            string pw1 = txtPwReset.Text.Trim();
            string pw2 = txtPwReset2.Text.Trim();
            string userId = txtId.Text.Trim();

            if (pw1 == "" || pw2 == "")
            {
                MessageBox.Show("비밀번호를 모두 입력해주세요.");
                return;
            }

            if (pw1 != pw2)
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.");
                return;
            }

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"UPDATE member 
                               SET password = :pw 
                               WHERE id = :id";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":pw", pw1);
                    cmd.Parameters.Add(":id", userId);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("비밀번호가 성공적으로 변경되었습니다!");

                        Start s = new Start();
                        s.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("비밀번호 변경 실패. 다시 시도해주세요.");
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

        private void Passwd_Load(object sender, EventArgs e)
        {
            txtPwReset.Enabled = false;
            txtPwReset2.Enabled = false;
            BtnReset.Enabled = false;
        }

        private void txtPhone_TextChanged_1(object sender, EventArgs e)
        {
            string digits = new string(txtPhone.Text.Where(char.IsDigit).ToArray());

            if (digits.Length > 11)
                digits = digits.Substring(0, 11);

            string formatted = "";

            if (digits.Length < 4)
                formatted = digits;
            else if (digits.Length < 8)
                formatted = digits.Substring(0, 3) + "-" + digits.Substring(3);
            else
                formatted = digits.Substring(0, 3) + "-" +
                            digits.Substring(3, 4) + "-" +
                            digits.Substring(7);

            int pos = txtPhone.SelectionStart;
            txtPhone.Text = formatted;
            txtPhone.SelectionStart = Math.Min(pos, txtPhone.Text.Length);
        }
    }
}
