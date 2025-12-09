using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Main
{
    public partial class MemberForm : Form
    {
        private int currentMemberId = -1;

        public MemberForm()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None; // 🔥 폼 크기 자동 확대 방지

            LoadMemberList();

            dgvMember.CellClick += dgvMember_CellClick;

            comboStatus.Items.Add("활동");
            comboStatus.Items.Add("활동정지");
        }

        // ==========================================================
        // 1) 회원 목록 로드
        // ==========================================================
        private void LoadMemberList()
        {
            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
                    SELECT 
                        member_id,
                        name,
                        id,
                        password,
                        reliability,
                        status
                    FROM member
                    ORDER BY member_id
                ";

                OracleDataAdapter da = new OracleDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvMember.DataSource = dt;
            }

            dgvMember.Columns["MEMBER_ID"].Visible = false;
            dgvMember.Columns["NAME"].HeaderText = "이름";
            dgvMember.Columns["ID"].HeaderText = "아이디";
            dgvMember.Columns["PASSWORD"].HeaderText = "비밀번호";
            dgvMember.Columns["RELIABILITY"].HeaderText = "신뢰도";
            dgvMember.Columns["STATUS"].HeaderText = "상태";
        }

        // ==========================================================
        // 2) 회원 목록 클릭 → 입력창 표시
        // ==========================================================
        private void dgvMember_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvMember.Rows[e.RowIndex];

            currentMemberId = Convert.ToInt32(row.Cells["MEMBER_ID"].Value);

            txtMemberName.Text = row.Cells["NAME"].Value.ToString();
            txtLoginId.Text = row.Cells["ID"].Value.ToString();
            txtMemberPw.Text = row.Cells["PASSWORD"].Value.ToString();
            txtMemberTrust.Text = row.Cells["RELIABILITY"].Value.ToString();
            comboStatus.Text = row.Cells["STATUS"].Value.ToString();
        }

        // ==========================================================
        // 3) 회원 정보 수정
        // ==========================================================
      

        // ==========================================================
        // 4) 회원 삭제
        // ==========================================================
       

        private void ClearInput()
        {
            txtMemberName.Text = "";
            txtLoginId.Text = "";
            txtMemberPw.Text = "";
            txtMemberTrust.Text = "";
            comboStatus.Text = "";
        }

        // ==========================================================
        // 메뉴 이동 (그대로 유지)
        // ==========================================================
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

        private void btnMemberUpdate_Click(object sender, EventArgs e)
        {
            if (currentMemberId == -1)
            {
                MessageBox.Show("수정할 회원을 선택하세요.");
                return;
            }

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
            UPDATE member
            SET 
                name = :name,
                id = :loginId,
                password = :pw,
                reliability = :cred,
                status = :status
            WHERE member_id = :mid
        ";

                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(":name", txtMemberName.Text.Trim());
                cmd.Parameters.Add(":loginId", txtLoginId.Text.Trim());   // ✔ 수정됨
                cmd.Parameters.Add(":pw", txtMemberPw.Text.Trim());
                cmd.Parameters.Add(":cred", txtMemberTrust.Text.Trim());
                cmd.Parameters.Add(":status", comboStatus.Text.Trim());   // ✔ 상태 반영
                cmd.Parameters.Add(":mid", currentMemberId);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("회원 정보가 정상적으로 수정되었습니다!");
            LoadMemberList();
        }

        private void btnMemberDelete_Click(object sender, EventArgs e)
        {
            if (currentMemberId == -1)
            {
                MessageBox.Show("삭제할 회원을 선택하세요.");
                return;
            }

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();
                OracleTransaction tran = conn.BeginTransaction();

                try
                {
                    // 🔥 1. 먼저 rental_id 목록 가져오기
                    string rentalIdSql = "SELECT rental_id FROM rental WHERE member_id = :mid";
                    OracleCommand cmdRentalId = new OracleCommand(rentalIdSql, conn);
                    cmdRentalId.Transaction = tran;
                    cmdRentalId.Parameters.Add(":mid", currentMemberId);

                    List<int> rentalList = new List<int>();
                    using (OracleDataReader reader = cmdRentalId.ExecuteReader())
                    {
                        while (reader.Read())
                            rentalList.Add(reader.GetInt32(0));
                    }

                    // 🔥 2. broken 삭제 (rental_id들에 연결된 신고 삭제)
                    string deleteBrokenSql = "DELETE FROM broken WHERE rental_id = :rid";
                    foreach (int rid in rentalList)
                    {
                        OracleCommand cmdBroken = new OracleCommand(deleteBrokenSql, conn);
                        cmdBroken.Transaction = tran;
                        cmdBroken.Parameters.Add(":rid", rid);
                        cmdBroken.ExecuteNonQuery();
                    }

                    // 🔥 3. rental 삭제
                    string deleteRentalSql = "DELETE FROM rental WHERE member_id = :mid";
                    OracleCommand cmdRental = new OracleCommand(deleteRentalSql, conn);
                    cmdRental.Transaction = tran;
                    cmdRental.Parameters.Add(":mid", currentMemberId);
                    cmdRental.ExecuteNonQuery();

                    // 🔥 4. member 삭제
                    string deleteMemberSql = "DELETE FROM member WHERE member_id = :mid";
                    OracleCommand cmdMember = new OracleCommand(deleteMemberSql, conn);
                    cmdMember.Transaction = tran;
                    cmdMember.Parameters.Add(":mid", currentMemberId);
                    cmdMember.ExecuteNonQuery();

                    tran.Commit();
                    MessageBox.Show("회원 삭제 완료!");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("삭제 오류: " + ex.Message);
                }
            }

            LoadMemberList();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
