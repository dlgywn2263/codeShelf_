using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Main
{
    public partial class BrokenManageForm : Form
    {
        private int selectedBrokenId = -1;
        private int selectedMemberId = -1;

        private DateTime currentStart;
        private DateTime currentEnd;

        public BrokenManageForm()
        {
            InitializeComponent();

            dgvBroken.AutoGenerateColumns = true;
            cmbFaultStatus.DropDownStyle = ComboBoxStyle.DropDownList;


            // 상태 콤보박스 설정
            cmbFaultStatus.Items.Clear();
            cmbFaultStatus.Items.Add("지연");   // 기본 미처리
            cmbFaultStatus.Items.Add("정상");   // 처리 완료
            cmbFaultStatus.Items.Add("폐기");   // 처리 완료

            // 필터링
            cbStatus.Items.Clear();
            cbStatus.Items.Add("전체");
            cbStatus.Items.Add("지연");
            cbStatus.Items.Add("정상");
            cbStatus.Items.Add("폐기");
            cbStatus.SelectedIndex = 0;

            // 필터 기본값
            currentStart = DateTime.Today;
            currentEnd = DateTime.Today.AddDays(1).AddSeconds(-1);

            dtpStart.Value = currentStart;
            dtpEnd.Value = currentStart;

            LoadBrokenList();
            LoadStatusCounts();

            dgvBroken.CellClick += dgvBroken_CellClick;
            cbStatus.SelectedIndexChanged += cbStatus_SelectedIndexChanged;

        }
        private void LoadBrokenList()
        {
            LoadBrokenList(null, null, "전체");
        }

        // ===========================================================
        // 1) 고장 신고 전체 조회
        // ===========================================================
        private void LoadBrokenList(DateTime? start, DateTime? end, string status)
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
                    WHERE 1=1
                ";

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;

                // 날짜 필터
                if (start.HasValue && end.HasValue)
                {
                    sql += " AND b.report_time BETWEEN :startDate AND :endDate";
                    cmd.Parameters.Add(":startDate", start.Value);
                    cmd.Parameters.Add(":endDate", end.Value);
                }

                // 상태 필터
                if (!string.IsNullOrEmpty(status) && status != "전체")
                {
                    sql += " AND b.repair_status = :status";
                    cmd.Parameters.Add(":status", status);
                }

                sql += " ORDER BY b.broken_id DESC";
                cmd.CommandText = sql;

                OracleDataAdapter da = new OracleDataAdapter(cmd);
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
            if (dgvBroken.Columns["REPORT_TIME"] != null)
                dgvBroken.Columns["REPORT_TIME"].HeaderText = "신고시간";

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

            // ✅ Text로 넣어도 DropDownList는 목록 값만 표시됨
            cmbFaultType.Text = row.Cells["SYMPTOM"].Value?.ToString() ?? "";
            txtFaultText.Text = row.Cells["REPAIR_DETAIL"].Value?.ToString() ?? "";
            cmbFaultStatus.Text = row.Cells["REPAIR_STATUS"].Value?.ToString() ?? "지연";

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
            // ✅ 무조건 Text로 가져오기 (SelectedItem 쓰면 NULL 터짐)
            string status = cmbFaultStatus.Text.Trim();
            string symptom = cmbFaultType.Text.Trim();
            string detail = txtFaultText.Text.Trim();
            string chargerIdText = txtChargerId.Text.Trim();

            // ✅ 필수값 검증
            if (string.IsNullOrEmpty(chargerIdText))
            {
                MessageBox.Show("충전기 ID가 비어있습니다. 목록에서 다시 선택하세요.");
                return;
            }

            if (string.IsNullOrEmpty(symptom))
            {
                MessageBox.Show("고장 유형을 선택/입력하세요.");
                return;
            }

            // ✅ CHECK 제약(정상/폐기/지연) 방지
            if (status != "정상" && status != "폐기" && status != "지연")
            {
                MessageBox.Show("처리 상태는 '정상/폐기/지연' 중 하나여야 합니다.");
                return;
            }

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();
                OracleTransaction tran = conn.BeginTransaction();

                try
                {
                    // 1) broken 업데이트
                    string sql1 = @"
                        UPDATE broken
                        SET repair_status = :status,
                            repair_detail = :detail,
                            symptom = :symptom
                        WHERE broken_id = :bid
                    ";

                    using (OracleCommand cmd1 = new OracleCommand(sql1, conn))
                    {
                        cmd1.Transaction = tran;
                        cmd1.Parameters.Add(":status", status);
                        cmd1.Parameters.Add(":detail", detail);
                        cmd1.Parameters.Add(":symptom", symptom);
                        cmd1.Parameters.Add(":bid", selectedBrokenId);
                        cmd1.ExecuteNonQuery();
                    }

                    // 2) 충전기 상태 업데이트 (원하는 정책에 맞게)
                    // 정상 -> 대기 / 지연 -> 고장 / 폐기 -> 고장(또는 폐기 상태 칼럼 있으면 그걸로)
                    string chargerStatus =
                        (status == "정상") ? "대기" :
                        (status == "지연") ? "고장" :
                        /* 폐기 */          "고장";

                    string sql3 = @"
                        UPDATE charger
                        SET status = :cstatus
                        WHERE charger_id = :cid
                    ";

                    using (OracleCommand cmd3 = new OracleCommand(sql3, conn))
                    {
                        cmd3.Transaction = tran;
                        cmd3.Parameters.Add(":cstatus", chargerStatus);
                        cmd3.Parameters.Add(":cid", Convert.ToInt32(chargerIdText));
                        cmd3.ExecuteNonQuery();
                    }

                    // 3) 신뢰도 차감
                    int minus = (int)numMinusCredibility.Value;

                    if (minus > 0 && selectedMemberId > 0)
                    {
                        string sql2 = @"
                            UPDATE member
                            SET reliability = reliability - :minus_val
                            WHERE member_id = :mid_val
                        ";

                        using (OracleCommand cmd2 = new OracleCommand(sql2, conn))
                        {
                            cmd2.Transaction = tran;
                            cmd2.Parameters.Add(":minus_val", minus);
                            cmd2.Parameters.Add(":mid_val", selectedMemberId);
                            cmd2.ExecuteNonQuery();
                        }

                        // reliability 범위 보정(0~100) 필요하면 여기서 추가 가능
                        string sqlFix = @"
                            UPDATE member
                            SET reliability = CASE
                                WHEN reliability < 0 THEN 0
                                WHEN reliability > 100 THEN 100
                                ELSE reliability
                            END
                            WHERE member_id = :mid
                        ";

                        using (OracleCommand cmdFix = new OracleCommand(sqlFix, conn))
                        {
                            cmdFix.Transaction = tran;
                            cmdFix.Parameters.Add(":mid", selectedMemberId);
                            cmdFix.ExecuteNonQuery();
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

                        using (OracleCommand cmdStatus = new OracleCommand(sqlStatus, conn))
                        {
                            cmdStatus.Transaction = tran;
                            cmdStatus.Parameters.Add(":mid", selectedMemberId);
                            cmdStatus.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                    MessageBox.Show("상태가 성공적으로 수정되었습니다!");

                    LoadBrokenList();
                    LoadStatusCounts();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("DB 오류: " + ex.Message);
                }
            }

            //LoadBrokenList();
            //LoadStatusCounts();
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
            selectedMemberId = -1;

            txtChargerId.Clear();
            txtMemberId.Clear();
            txtFaultText.Clear();

            cmbFaultType.SelectedIndex = -1;
            cmbFaultStatus.SelectedIndex = -1;
            
            numMinusCredibility.Value = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            currentStart = dtpStart.Value.Date;
            currentEnd = dtpEnd.Value.Date.AddDays(1).AddSeconds(-1);

            LoadBrokenList(currentStart, currentEnd, cbStatus.Text);
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string status = cbStatus.Text;
            LoadBrokenList(currentStart, currentEnd, cbStatus.Text);
        }
    }
}
