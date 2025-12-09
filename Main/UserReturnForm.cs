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

        public UserReturnForm()
        {
            InitializeComponent();
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
                l.location_name AS ""지점명"",
                r.rental_time AS ""대여시간"",
                rt.hours || '시간' AS ""예약시간"",
                rt.price || '원' AS ""대여요금""
            FROM rental r
            JOIN charger c ON r.charger_id = c.charger_id
            JOIN location l ON c.location_id = l.location_id
            JOIN rate rt ON r.rate_id = rt.rate_id
            WHERE r.member_id = :mid
              AND r.return_time IS NULL
        ";

                OracleDataAdapter da = new OracleDataAdapter(sql, conn);
                da.SelectCommand.Parameters.Add(":mid", UserSession.MemberId);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;  // ← 네가 사용하는 정확한 DataGridView 이름
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

            // 반납 계산은 "시간 올림"
            int roundedHours = (int)Math.Ceiling(usedHours);

            TxtUsedTime.Text = $"{roundedHours}시간 (실제 {usedHours:F1}시간)";

            // 추가요금 0으로 초기화
            int extraFee = 0;

            // *** 초과한 경우만 late_price 적용 ***
            if (roundedHours > reservedHours)
            {
                int extraHours = roundedHours - reservedHours;
                extraFee = extraHours * latePrice;
            }

            // 최종 요금 = 기본 요금 + 연체 요금
            int finalPrice = basePrice + extraFee;

            TxtFinalPrice.Text = finalPrice.ToString();
        }


        // ------------------------------------------------------
        // 3) DB 반납 처리
        // ------------------------------------------------------
        private void BtnReturnDo_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();
                OracleTransaction tran = conn.BeginTransaction();

                try
                {
                    // rental 업데이트
                    string sql1 = @"
                        UPDATE rental
                        SET return_time = SYSDATE,
                            charge_amount = :amount
                        WHERE member_id = :mid
                          AND return_time IS NULL
                    ";

                    using (OracleCommand cmd1 = new OracleCommand(sql1, conn))
                    {
                        cmd1.Transaction = tran;
                        cmd1.Parameters.Add(":amount", Convert.ToInt32(TxtFinalPrice.Text));
                        cmd1.Parameters.Add(":mid", UserSession.MemberId);
                        cmd1.ExecuteNonQuery();
                    }

                    // 충전기 상태 초기화
                    string sql2 = "UPDATE charger SET status='대기' WHERE charger_id=:cid";

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

            MessageBox.Show(
                $"반납 완료!\n" +
                $"사용시간: {TxtUsedTime.Text}\n" +
                $"최종 요금: {TxtFinalPrice.Text}원"
            );

            new UserMainForm().Show();
            this.Close();
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
    }
}
