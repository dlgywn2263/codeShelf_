using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Main
{
    public partial class UserRentalForm : Form
    {
        public UserRentalForm()
        {
            InitializeComponent();
            LoadTypes();
            LoadTimes();
        }

        // ----------------------------------------
        // 1) 유형 / 시간 콤보박스 로드
        // ----------------------------------------
        private void LoadTypes()
        {
            ComboType.Items.Add("일반");
            ComboType.Items.Add("고속");
        }

        private void LoadTimes()
        {
            ComboTime.Items.Add("1시간");
            ComboTime.Items.Add("2시간");
            ComboTime.Items.Add("3시간");
        }

        // ----------------------------------------
        // 2) rate 정보 가져오기
        // ----------------------------------------
        private (int rateId, int price, int latePrice) GetRateInfo(string type, int hours)
        {
            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
                    SELECT rate_id, price, late_price
                    FROM rate
                    WHERE charger_type = :type
                    AND hours = :hours
                ";

                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(":type", type);
                cmd.Parameters.Add(":hours", hours);

                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return (
                        dr.GetInt32(0),
                        dr.GetInt32(1),
                        dr.GetInt32(2)
                    );
                }
            }

            return (0, 0, 0);
        }

        // ----------------------------------------
        // 3) 가격 자동 표시
        // ----------------------------------------
        private void UpdatePrice()
        {
            if (ComboType.Text == "" || ComboTime.Text == "")
                return;

            int hours = Convert.ToInt32(ComboTime.Text.Replace("시간", ""));
            var rate = GetRateInfo(ComboType.Text, hours);

            TxtPrice.Text = rate.price.ToString();
        }

        private void ComboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePrice();
        }

        private void ComboTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePrice();
        }

        // ----------------------------------------
        // 4) 사용 가능한 충전기 1개 가져오기
        // ----------------------------------------
        private string GetAvailableCharger(string type)
        {
            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
                    SELECT charger_id
                    FROM charger
                    WHERE charger_type = :type
                    AND status = '대기'
                    AND ROWNUM = 1
                ";

                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(":type", type);

                object result = cmd.ExecuteScalar();
                return result?.ToString();
            }
        }

        // ----------------------------------------
        // 5) location 테이블에서 지점명 가져오기
        // ----------------------------------------
        private string GetChargerSpot(string chargerId)
        {
            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
            SELECT L.location_name
            FROM charger C
            JOIN location L ON C.location_id = L.location_id
            WHERE C.charger_id = :cid
        ";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":cid", chargerId);

                    object result = cmd.ExecuteScalar();
                    return result?.ToString() ?? "지점 정보 없음";
                }
            }
        }

        // ----------------------------------------
        // 6) 대여하기 버튼
        // ----------------------------------------
        private void BtnRentDo_Click(object sender, EventArgs e)
        {
            if (ComboType.Text == "" || ComboTime.Text == "")
            {
                MessageBox.Show("충전기 유형과 사용 시간을 선택하세요.");
                return;
            }

            string type = ComboType.Text;
            int hours = Convert.ToInt32(ComboTime.Text.Replace("시간", ""));

            // 1) 충전기 배정
            string chargerId = GetAvailableCharger(type);
            if (chargerId == null)
            {
                MessageBox.Show("현재 대기 중인 충전기가 없습니다.");
                return;
            }

            // 2) 요금 정보 가져오기
            var rate = GetRateInfo(type, hours);
            int rateId = rate.rateId;
            int price = rate.price;

            // 3) 지점명 가져오기
            string spot = GetChargerSpot(chargerId);
            string content = $"{type} / {hours}시간";
            string today = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            // 4) 결제창
            Payment payForm = new Payment(today, spot, content, price);
            payForm.ShowDialog();

            if (!payForm.IsConfirmed)
            {
                MessageBox.Show("결제가 취소되었습니다.");
                return;
            }

            // 5) DB INSERT + 충전기 상태 변경
            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();
                OracleTransaction tran = conn.BeginTransaction();

                try
                {
                    // rental INSERT
                    string sql1 = @"
                        INSERT INTO rental
                        (rental_id, member_id, charger_id, rate_id, rental_time, charge_amount)
                        VALUES
                        (seq_rental.NEXTVAL, :mid, :cid, :rid, SYSDATE, :amount)
                    ";

                    OracleCommand cmd1 = new OracleCommand(sql1, conn);
                    cmd1.Transaction = tran;

                    cmd1.Parameters.Add(":mid", UserSession.MemberId);
                    cmd1.Parameters.Add(":cid", chargerId);
                    cmd1.Parameters.Add(":rid", rateId);
                    cmd1.Parameters.Add(":amount", price);

                    cmd1.ExecuteNonQuery();

                    // charger 상태 변경
                    string sql2 = "UPDATE charger SET status='사용중' WHERE charger_id=:cid";

                    OracleCommand cmd2 = new OracleCommand(sql2, conn);
                    cmd2.Transaction = tran;
                    cmd2.Parameters.Add(":cid", chargerId);
                    cmd2.ExecuteNonQuery();

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("DB 오류: " + ex.Message);
                    return;
                }
            }

            // 완료 메시지
            MessageBox.Show(
                $"대여 완료!\n\n" +
                $"충전기 ID : {chargerId}\n" +
                $"유형      : {type}\n" +
                $"시간      : {hours}시간\n" +
                $"요금      : {price}원"
            );

            // 메인 화면으로 이동
            new UserMainForm().Show();
            this.Close();
        }

        // ----------------------------------------
        // 메뉴 이동
        // ----------------------------------------
        private void menuMain_Click(object sender, EventArgs e)
        {
            new UserMainForm().Show();
            this.Close();
        }

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
    }
}
