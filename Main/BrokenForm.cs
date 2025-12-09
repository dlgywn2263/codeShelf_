using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Main
{
    public partial class BrokenForm : Form
    {
        public BrokenForm()
        {
            InitializeComponent();
            LoadSymptomList();
        }

        // ========================================
        // 🔥 폼 로드 시
        // ========================================
        private void BrokenForm_Load(object sender, EventArgs e)
        {
            DatePickerDate.Format = DateTimePickerFormat.Custom;
            DatePickerDate.CustomFormat = "yyyy-MM-dd";

            LoadUserRentalList();
        }

        // ========================================
        // 🔥 1) 대여 중 충전기 목록 로드
        // ========================================
        private void LoadUserRentalList()
        {
            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
                    SELECT 
                        r.rental_id,
                        r.charger_id,
                        l.location_name,
                        r.rental_time,
                        c.charger_type
                    FROM rental r
                    JOIN charger c ON r.charger_id = c.charger_id
                    JOIN location l ON c.location_id = l.location_id
                    WHERE r.member_id = :mid
                      AND r.return_time IS NULL
                ";

                OracleDataAdapter da = new OracleDataAdapter(sql, conn);
                da.SelectCommand.Parameters.Add(":mid", UserSession.MemberId);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvRentCharger.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("현재 대여 중인 충전기가 없습니다.");
                }

                // 컬럼명 설정 (대문자 기준)
                dgvRentCharger.Columns["RENTAL_ID"].HeaderText = "대여 ID";
                dgvRentCharger.Columns["CHARGER_ID"].HeaderText = "충전기 ID";
                dgvRentCharger.Columns["LOCATION_NAME"].HeaderText = "지점";
                dgvRentCharger.Columns["RENTAL_TIME"].HeaderText = "대여 시간";
                dgvRentCharger.Columns["CHARGER_TYPE"].HeaderText = "유형";

                dgvRentCharger.ClearSelection();
            }
        }

        // ========================================
        // 🔥 2) 증상 리스트
        // ========================================
        private void LoadSymptomList()
        {
            ComboSymptom.Items.Add("케이블 단선 의심");
            ComboSymptom.Items.Add("LED 표시 오류");
            ComboSymptom.Items.Add("포트 접속 불량");
            ComboSymptom.Items.Add("충전이 중간에 끊김");
            ComboSymptom.Items.Add("과열");
            ComboSymptom.Items.Add("기타");
        }

        // ========================================
        // 🔥 3) 고장 신고 저장
        // ========================================
        private void BtnReport_Click(object sender, EventArgs e)
        {
            // 1) 선택한 충전기 확인
            if (dgvRentCharger.SelectedRows.Count == 0)
            {
                MessageBox.Show("고장 신고할 충전기를 선택해주세요.");
                return;
            }

            DataGridViewRow row = dgvRentCharger.SelectedRows[0];
            int rentalId = Convert.ToInt32(row.Cells["RENTAL_ID"].Value);
            int chargerId = Convert.ToInt32(row.Cells["CHARGER_ID"].Value);

            if (ComboSymptom.Text == "")
            {
                MessageBox.Show("고장 증상을 선택해주세요.");
                return;
            }

            DateTime reportTime = DatePickerDate.Value;
            string symptom = ComboSymptom.Text;
            string detail = TxtDetail.Text.Trim();

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();
                OracleTransaction tran = conn.BeginTransaction();

                try
                {
                    // -------------------------------
                    // 1️⃣ broken 테이블 INSERT
                    // -------------------------------
                    string sql1 = @"
                INSERT INTO broken
                    (broken_id, charger_id, rental_id, report_time, symptom, repair_detail, repair_status)
                VALUES 
                    (seq_broken.NEXTVAL, :cid, :rid, :rtime, :sym, :detail, '지연')
            ";

                    using (OracleCommand cmd1 = new OracleCommand(sql1, conn))
                    {
                        cmd1.Transaction = tran;
                        cmd1.Parameters.Add(":cid", chargerId);
                        cmd1.Parameters.Add(":rid", rentalId);
                        cmd1.Parameters.Add(":rtime", reportTime);
                        cmd1.Parameters.Add(":sym", symptom);
                        cmd1.Parameters.Add(":detail", detail);

                        cmd1.ExecuteNonQuery();
                    }

                    // -------------------------------
                    // 2️⃣ charger 테이블 상태 변경 → '고장'
                    // -------------------------------
                    string sql2 = @"
                UPDATE charger
                SET status = '고장'
                WHERE charger_id = :cid
            ";

                    using (OracleCommand cmd2 = new OracleCommand(sql2, conn))
                    {
                        cmd2.Transaction = tran;
                        cmd2.Parameters.Add(":cid", chargerId);
                        cmd2.ExecuteNonQuery();
                    }

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("DB 오류: " + ex.Message);
                    return;
                }
            }

            // -------------------------------
            // 3️⃣ 사용자 알림
            // -------------------------------
            MessageBox.Show(
                "고장 신고가 접수되었습니다!\n\n" +
                $"충전기 ID: {chargerId}\n" +
                $"대여 ID: {rentalId}\n" +
                $"신고 일자: {reportTime:yyyy-MM-dd}\n" +
                $"증상: {symptom}\n" +
                "해당 충전기는 자동으로 '고장' 상태로 변경되었습니다."
            );

            // -------------------------------
            // 4️⃣ 메인 화면 이동
            // -------------------------------
            new UserMainForm().Show();
            this.Close();
        }


        // ========================================
        // 메뉴 이동
        // ========================================
        private void menuMain_Click(object sender, EventArgs e)
        {
            new UserMainForm().Show();
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
    }
}
