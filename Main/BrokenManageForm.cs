using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Main
{
    public partial class BrokenManageForm : Form
    {
        private int selectedBrokenId = -1;
        private int selectedMemberId = -1;

        public BrokenManageForm()
        {
            InitializeComponent();

            dgvBroken.AutoGenerateColumns = true;

            // 상태 콤보박스 설정
            cmbFaultStatus.Items.Clear();
            cmbFaultStatus.Items.Add("지연");   // 기본 미처리
            cmbFaultStatus.Items.Add("정상");   // 처리 완료
            cmbFaultStatus.Items.Add("폐기");   // 처리 완료

            LoadBrokenList();
            LoadStatusCounts();

            dgvBroken.CellClick += dgvBroken_CellClick;
        }

        // ===========================================================
        // 1) 고장 신고 전체 조회
        // ===========================================================
        private void LoadBrokenList()
        {
            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
                    SELECT 
                        b.broken_id,
                        b.charger_id,
                        NVL(r.member_id, 0) AS member_id,
                        b.symptom,
                        b.repair_detail,
                        b.repair_status,
                        TO_CHAR(b.report_time, 'YYYY-MM-DD HH24:MI') AS report_time
                    FROM broken b
                    LEFT JOIN rental r ON b.rental_id = r.rental_id
                    ORDER BY b.broken_id DESC
                ";

                OracleDataAdapter da = new OracleDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvBroken.DataSource = dt;
                FormatGrid();
            }
        }

        // 🔧 테이블 헤더 정리
        private void FormatGrid()
        {
            if (dgvBroken.Columns["BROKEN_ID"] != null)
                dgvBroken.Columns["BROKEN_ID"].HeaderText = "ID";

            if (dgvBroken.Columns["CHARGER_ID"] != null)
                dgvBroken.Columns["CHARGER_ID"].HeaderText = "충전기";

            if (dgvBroken.Columns["MEMBER_ID"] != null)
                dgvBroken.Columns["MEMBER_ID"].HeaderText = "회원";

            if (dgvBroken.Columns["SYMPTOM"] != null)
                dgvBroken.Columns["SYMPTOM"].HeaderText = "고장 유형";

            if (dgvBroken.Columns["REPAIR_DETAIL"] != null)
                dgvBroken.Columns["REPAIR_DETAIL"].HeaderText = "고장 내용";

            if (dgvBroken.Columns["REPAIR_STATUS"] != null)
                dgvBroken.Columns["REPAIR_STATUS"].HeaderText = "처리 상태";
        }

        // ===========================================================
        // 2) 상태 개수 카운트
        // ===========================================================
        private void LoadStatusCounts()
        {
            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                Total.Text =
                    $"{Count(conn, "SELECT COUNT(*) FROM broken")} 건";

                Pending.Text =
                    $"{Count(conn, "SELECT COUNT(*) FROM broken WHERE repair_status='지연'")} 건";

                Done.Text =
                    $"{Count(conn, "SELECT COUNT(*) FROM broken WHERE repair_status IN ('정상', '폐기')")} 건";
            }
        }

        private int Count(OracleConnection conn, string sql)
        {
            return Convert.ToInt32(new OracleCommand(sql, conn).ExecuteScalar());
        }

        // ===========================================================
        // 3) 목록 클릭 → 상세 패널 채우기
        // ===========================================================
        private void dgvBroken_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvBroken.Rows[e.RowIndex];

            selectedBrokenId = Convert.ToInt32(row.Cells["BROKEN_ID"].Value);
            txtChargerId.Text = row.Cells["CHARGER_ID"].Value?.ToString() ?? "";

            selectedMemberId = Convert.ToInt32(row.Cells["MEMBER_ID"].Value);
            txtMemberId.Text = selectedMemberId == 0 ? "" : selectedMemberId.ToString();

            cmbFaultType.Text = row.Cells["SYMPTOM"].Value?.ToString() ?? "";
            txtFaultText.Text = row.Cells["REPAIR_DETAIL"].Value?.ToString() ?? "";
            cmbFaultStatus.Text = row.Cells["REPAIR_STATUS"].Value?.ToString() ?? "";
        }

        // ===========================================================
        // 4) 상태 수정 + 신뢰도 차감 반영
        // ===========================================================
        private void btnProcess_Click_1(object sender, EventArgs e)
        {
            if (selectedBrokenId == -1)
            {
                MessageBox.Show("신고 항목을 선택하세요.");
                return;
            }

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();
                OracleTransaction tran = conn.BeginTransaction();

                try
                {
                    // -------------------------------------------------------------------
                    // 1) broken 상태 및 상세 내용 업데이트
                    // -------------------------------------------------------------------
                    string sql1 = @"
                        UPDATE broken
                        SET repair_status = :status,
                            repair_detail = :detail,
                            symptom = :symptom
                        WHERE broken_id = :bid
                    ";

                    OracleCommand cmd1 = new OracleCommand(sql1, conn);
                    cmd1.Transaction = tran;

                    cmd1.Parameters.Add(":symptom", cmbFaultType.Text.Trim()); 
                    cmd1.Parameters.Add(":status", cmbFaultStatus.Text.Trim());
                    cmd1.Parameters.Add(":detail", txtFaultText.Text.Trim());
                    cmd1.Parameters.Add(":bid", selectedBrokenId);

                    cmd1.ExecuteNonQuery();


                    // -------------------------------------------------------------------
                    // 2) 충전기 상태 자동 변경 (정상 or 폐기 → 충전기 상태 '대기')
                    // -------------------------------------------------------------------
                    string newStatus = cmbFaultStatus.Text.Trim();

                    if (newStatus == "정상" || newStatus == "폐기")
                    {
                        string sql3 = @"
                            UPDATE charger
                            SET status = '대기'
                            WHERE charger_id = :cid
                        ";

                        OracleCommand cmd3 = new OracleCommand(sql3, conn);
                        cmd3.Transaction = tran;
                        cmd3.Parameters.Add(":cid", txtChargerId.Text.Trim());
                        cmd3.ExecuteNonQuery();
                    }


                    // -------------------------------------------------------------------
                    // 3) 신뢰도 차감 (회원 ID가 0인 경우 제외)
                    // -------------------------------------------------------------------
                    int minus = (int)numMinusCredibility.Value;

                    if (minus > 0 && selectedMemberId > 0)
                    {
                        string sql2 = @"
                            UPDATE member
                            SET reliability = reliability - :minus_val
                            WHERE member_id = :mid_val
                        ";

                        OracleCommand cmd2 = new OracleCommand(sql2, conn);
                        cmd2.Transaction = tran;
                        cmd2.Parameters.Add(":minus_val", minus);
                        cmd2.Parameters.Add(":mid_val", selectedMemberId);

                        cmd2.ExecuteNonQuery();
                    }

                    // 상태 자동 업데이트
                    string sqlStatus = @"
                        UPDATE member
                        SET status = CASE
                                        WHEN reliability <= 50 THEN '활동정지'
                                        ELSE '활동'
                                     END
                        WHERE member_id = :mid
                    ";

                    if (selectedMemberId > 0)
                    {
                        OracleCommand cmdStatus = new OracleCommand(sqlStatus, conn);
                        cmdStatus.Transaction = tran;
                        cmdStatus.Parameters.Add(":mid", selectedMemberId);
                        cmdStatus.ExecuteNonQuery();
                    }

                    // 성공 처리
                    tran.Commit();
                    MessageBox.Show("상태가 성공적으로 수정되었습니다!");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("DB 오류: " + ex.Message);
                }
            }
            LoadBrokenList();
            LoadStatusCounts();
        }

        // 뒤로가기
        private void BtnBack_Click(object sender, EventArgs e)
        {
            new MainForm().Show();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // 입력 초기화
            selectedBrokenId = -1;
            txtChargerId.Clear();
            txtMemberId.Clear();
            cmbFaultType.SelectedIndex = -1;
            cmbFaultStatus.SelectedIndex = -1;
            txtFaultText.Clear();
            numMinusCredibility.Value = 0;
        }
    }
}
