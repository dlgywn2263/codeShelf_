using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Main
{
    public partial class UserReturnForm : Form
    {
        private DateTime rentalTime;
        private int rateId;
        private int chargerId;
        private int reservedHours;     // 사용자가 선택한 시간 (1,2,3)
        private int basePrice;         // 대여 시 저장된 요금
        private int latePrice;         // 연체요금
        private int selectedRentalId = -1;


        public UserReturnForm()
        {
            InitializeComponent();
            dataGridView1.CellClick += DataGridView1_CellClick;

            LoadRentalGrid();
            LoadCurrentRental();
            CalculateUsageAndPrice();
        }

        // ------------------------------------------------------
        // 1) 로그인된 유저의 미반납 대여 정보 불러오기
        // ------------------------------------------------------

        private void LoadRentalGrid()
        {
            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
            SELECT 
                r.rental_id AS ""대여번호"",
                c.charger_id AS ""충전기ID"",
                c.charger_type AS ""충전기유형"",  
                l.location_name AS ""지점명"",
                r.rental_time AS ""대여시간"",
                rt.hours || '시간' AS ""예약시간"",
                rt.price || '원' AS ""대여요금"",
                m.reliability AS ""신뢰도"" 
            FROM rental r
            JOIN charger c ON r.charger_id = c.charger_id
            JOIN location l ON c.location_id = l.location_id
            JOIN rate rt ON r.rate_id = rt.rate_id
            JOIN member m ON r.member_id = m.member_id
            WHERE r.member_id = :mid
              AND r.return_time IS NULL
        ";

                OracleDataAdapter da = new OracleDataAdapter(sql, conn);
                da.SelectCommand.Parameters.Add(":mid", UserSession.MemberId);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;  // ← 네가 사용하는 정확한 DataGridView 이름
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }


        private void LoadCurrentRental()
        {
            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
                    SELECT rental_time, rate_id, charger_id, charge_amount
                    FROM rental
                    WHERE member_id = :mid
                      AND return_time IS NULL
                ";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":mid", UserSession.MemberId);

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            rentalTime = reader.GetDateTime(0);
                            rateId = reader.GetInt32(1);
                            chargerId = reader.GetInt32(2);
                            basePrice = reader.GetInt32(3);
                        }
                        else
                        {
                            MessageBox.Show("현재 대여 중인 충전기가 없습니다.");
                            this.Close();
                            return;
                        }
                    }
                }

                // 🔥 rate 테이블에서 hours, price, late_price 불러오기
                string sql2 = @"
                    SELECT hours, price, late_price
                    FROM rate
                    WHERE rate_id = :rid
                ";

                using (OracleCommand cmd2 = new OracleCommand(sql2, conn))
                {
                    cmd2.Parameters.Add(":rid", rateId);

                    using (OracleDataReader dr = cmd2.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            reservedHours = dr.GetInt32(0);   // 예약 시간 (1/2/3)
                            latePrice = dr.GetInt32(2);      // 연체 요금(2000/3000)
                        }
                    }
                }
            }
        }

        // ------------------------------------------------------
        // 2) 사용 시간 및 연체요금 계산
        // ------------------------------------------------------
        private void CalculateUsageAndPrice()
        {
            DateTime now = DateTime.Now;
            TimeSpan used = now - rentalTime;

            double usedHours = used.TotalHours;

            // UI 표시용
            TxtUsedTime.Text = $"{Math.Ceiling(usedHours)}시간 (실제 {usedHours:F1}시간)";

            // ⭐ 15분 유예 포함 허용 시간
            double allowedHours = reservedHours + 0.25;

            int lateFee = 0;

            if (usedHours > allowedHours)
            {
                double overdueHours = usedHours - allowedHours;

                // 연체는 시간 단위 올림
                int chargedLateHours = (int)Math.Ceiling(overdueHours);

                lateFee = chargedLateHours * latePrice;
            }

            int finalPrice = basePrice + lateFee;

            TxtBasePrice.Text = basePrice.ToString();
            TxtLateFee.Text = lateFee.ToString();
            TxtFinalPrice.Text = finalPrice.ToString();
        }



        // ------------------------------------------------------
        // 3) DB 반납 처리
        // ------------------------------------------------------
        private void BtnReturnDo_Click(object sender, EventArgs e)
        {
            if (selectedRentalId == -1)
            {
                MessageBox.Show("반납할 충전기를 선택하세요.");
                return;
            }

            int credChange = 0;

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();
                OracleTransaction tran = conn.BeginTransaction();

                try
                {
                    // ① rental 테이블 반납 업데이트
                    string sql1 = @"
                UPDATE rental
                SET return_time = SYSDATE,
                    charge_amount = :amount
                WHERE rental_id = :rid
            ";

                    using (OracleCommand cmd1 = new OracleCommand(sql1, conn))
                    {
                        cmd1.Transaction = tran;
                        cmd1.Parameters.Add(":amount", Convert.ToInt32(TxtFinalPrice.Text));
                        cmd1.Parameters.Add(":rid", selectedRentalId);
                        cmd1.ExecuteNonQuery();
                    }

                    // ② 충전기 상태를 대기로 변경
                    string sql2 = "UPDATE charger SET status='대기' WHERE charger_id=:cid";

                    using (OracleCommand cmd2 = new OracleCommand(sql2, conn))
                    {
                        cmd2.Transaction = tran;
                        cmd2.Parameters.Add(":cid", chargerId);
                        cmd2.ExecuteNonQuery();
                    }

                    // ----------------------------------------------------------
                    // ⭐⭐ ③ 신뢰도(reliability) 계산 — 네가 원하는 규칙 적용 ⭐⭐
                    // ----------------------------------------------------------

                    // 🔥 연체일 계산
                    DateTime now = DateTime.Now;
                    DateTime expectedReturn = rentalTime.AddHours(reservedHours);

                    int overdueDays = (now - expectedReturn).Days;
                    if (overdueDays < 0) overdueDays = 0;

                    // 🔥 신뢰도 변화 계산 규칙
                    if (overdueDays == 0)
                    {
                        credChange = 5;  // 제시간 반납 → +5점
                    }
                    else if (overdueDays >= 1 && overdueDays <= 5)
                    {
                        // 1~5일 연체 → 연체 점수 감소 후 +5 보정
                        credChange = (overdueDays * -10) + 5;
                    }
                    else
                    {
                        // 6일 이상 → 보정 없음
                        credChange = overdueDays * -10;
                    }

                    // 🔥 기존 신뢰도 가져오기
                    int currentReliability = 0;
                    string sqlGetCred = "SELECT reliability FROM member WHERE member_id = :mid";

                    using (OracleCommand cmdGet = new OracleCommand(sqlGetCred, conn))
                    {
                        cmdGet.Transaction = tran;
                        cmdGet.Parameters.Add(":mid", UserSession.MemberId);
                        currentReliability = Convert.ToInt32(cmdGet.ExecuteScalar());
                    }

                    // 🔥 최종 신뢰도 계산
                    int newReliability = currentReliability + credChange;

                    if (newReliability < 0) newReliability = 0;
                    if (newReliability > 100) newReliability = 100;

                    // 🔥 DB에 신뢰도 업데이트
                    string sqlCred = @"
                UPDATE member
                SET reliability = :newCred
                WHERE member_id = :mid
            ";

                    using (OracleCommand cmdCred = new OracleCommand(sqlCred, conn))
                    {
                        cmdCred.Transaction = tran;
                        cmdCred.Parameters.Add(":newCred", newReliability);
                        cmdCred.Parameters.Add(":mid", UserSession.MemberId);
                        cmdCred.ExecuteNonQuery();
                    }

                    // ----------------------------------------------------------
                    // ⭐⭐ ④ 상태(status) 결정 규칙 적용 ⭐⭐
                    // 0~5일 연체 → 활동
                    // 6일 이상 → 활동정지
                    // 7일 이상 → 계속 정지
                    // ----------------------------------------------------------

                    string newStatus = (overdueDays <= 5) ? "활동" : "활동정지";

                    string sqlStatus = @"
                UPDATE member
                SET status = :status
                WHERE member_id = :mid
            ";

                    using (OracleCommand cmdStatus = new OracleCommand(sqlStatus, conn))
                    {
                        cmdStatus.Transaction = tran;
                        cmdStatus.Parameters.Add(":status", newStatus);
                        cmdStatus.Parameters.Add(":mid", UserSession.MemberId);
                        cmdStatus.ExecuteNonQuery();
                    }

                    // ----------------------------------------------------------
                    // ⭐⭐ 트랜잭션 커밋 ⭐⭐
                    // ----------------------------------------------------------
                    tran.Commit();

                    // 사용자에게 결과 출력
                    MessageBox.Show(
                        $"반납 완료!\n" +
                        $"사용시간: {TxtUsedTime.Text}\n" +
                        $"연체일수: {overdueDays}일\n" +
                        $"신뢰도 변화: {credChange}점\n" +
                        $"현재 신뢰도: {newReliability}점\n" +
                        $"상태: {newStatus}"
                    );
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("DB 오류: " + ex.Message);
                    return;
                }
            }

            new UserMainForm().Show();
            this.Close();
        }
        private void LoadSelectedRental(int rentalId)
        {
            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
            SELECT rental_time, rate_id, charger_id, charge_amount
            FROM rental
            WHERE rental_id = :rid
        ";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":rid", rentalId);

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            rentalTime = reader.GetDateTime(0);
                            rateId = reader.GetInt32(1);
                            chargerId = reader.GetInt32(2);
                            basePrice = reader.GetInt32(3);
                        }
                    }
                }

                // rate 정보 로딩
                string sql2 = @"SELECT hours, price, late_price FROM rate WHERE rate_id = :rateId";

                using (OracleCommand cmd2 = new OracleCommand(sql2, conn))
                {
                    cmd2.Parameters.Add(":rateId", rateId);

                    using (OracleDataReader dr = cmd2.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            reservedHours = dr.GetInt32(0);
                            latePrice = dr.GetInt32(2);
                        }
                    }
                }
            }

            // 최종적으로 UI 업데이트
            CalculateUsageAndPrice();
        }


        private void menuMain_Click(object sender, EventArgs e)
        {
            new UserMainForm().Show();
            this.Close();

        }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            new Start().Show();
            this.Close();
        }

        private void menuHistory_Click(object sender, EventArgs e)
        {
            new UserHistoryForm().Show();
            this.Close();
        }

        private void menuBroken_Click(object sender, EventArgs e)
        {
            new BrokenForm().Show();
            this.Close();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            selectedRentalId = Convert.ToInt32(row.Cells["대여번호"].Value);
            chargerId = Convert.ToInt32(row.Cells["충전기ID"].Value);

            LoadSelectedRental(selectedRentalId);
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
