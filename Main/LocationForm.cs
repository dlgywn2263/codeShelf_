using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Main
{
    public partial class LocationForm : Form
    {
        public LocationForm()
        {
            InitializeComponent();
            dgvLocation.AutoGenerateColumns = true;

            LoadLocationList();
        }

        // =========================================================
        // 🔥 1) 충전기 + 지점명 목록 불러오기
        // =========================================================
        private void LoadLocationList()
        {
            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
                    SELECT 
                        c.charger_id,
                        c.charger_type,
                        NVL(l.location_name, '미배정') AS location_name,
                        c.status
                    FROM charger c
                    LEFT JOIN location l 
                        ON c.location_id = l.location_id
                    ORDER BY c.charger_id
                ";

                OracleDataAdapter da = new OracleDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvLocation.DataSource = dt;

                dgvLocation.Columns["CHARGER_ID"].HeaderText = "충전기 ID";
                dgvLocation.Columns["CHARGER_TYPE"].HeaderText = "종류";
                dgvLocation.Columns["LOCATION_NAME"].HeaderText = "지점명";
                dgvLocation.Columns["STATUS"].HeaderText = "상태";
            }
        }

        // =========================================================
        // 🔥 2) 클릭 시 상세 정보 표시
        // =========================================================
        private void dgvLocation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvLocation.Rows[e.RowIndex];

            txtChargerId.Text = row.Cells["CHARGER_ID"].Value?.ToString();
            txtLocationName.Text = row.Cells["LOCATION_NAME"].Value?.ToString();
        }

        // =========================================================
        // 🔥 3) 위치 등록 (location_id 업데이트)
        // =========================================================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtChargerId.Text == "" || txtLocationName.Text == "")
            {
                MessageBox.Show("충전기 ID와 지점명을 입력하세요.");
                return;
            }

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                // 입력한 지점명이 실제 location 테이블에 있는지 확인
                string sqlCheck = "SELECT location_id FROM location WHERE location_name = :name";
                OracleCommand checkCmd = new OracleCommand(sqlCheck, conn);
                checkCmd.Parameters.Add(":name", txtLocationName.Text.Trim());

                object result = checkCmd.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("존재하지 않는 지점명입니다.");
                    return;
                }

                int locationId = Convert.ToInt32(result);

                string sql = @"
                    UPDATE charger
                    SET location_id = :loc
                    WHERE charger_id = :cid
                ";

                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(":loc", locationId);
                cmd.Parameters.Add(":cid", txtChargerId.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("위치 등록 완료!");
            }

            LoadLocationList();
        }

        // =========================================================
        // 🔥 4) 위치 수정 (동일한 로직)
        // =========================================================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtChargerId.Text == "" || txtLocationName.Text == "")
            {
                MessageBox.Show("수정할 항목을 선택하고 지점명을 입력하세요.");
                return;
            }

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sqlCheck = "SELECT location_id FROM location WHERE location_name = :name";
                OracleCommand checkCmd = new OracleCommand(sqlCheck, conn);
                checkCmd.Parameters.Add(":name", txtLocationName.Text.Trim());

                object result = checkCmd.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("존재하지 않는 지점명입니다.");
                    return;
                }

                int locationId = Convert.ToInt32(result);

                string sql = @"
                    UPDATE charger
                    SET location_id = :loc
                    WHERE charger_id = :cid
                ";

                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(":loc", locationId);
                cmd.Parameters.Add(":cid", txtChargerId.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("위치 수정 완료!");
            }

            LoadLocationList();
        }

        // =========================================================
        // 🔥 5) 위치 삭제 (NULL 처리)
        // =========================================================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtChargerId.Text == "")
            {
                MessageBox.Show("삭제할 충전기를 선택하세요.");
                return;
            }

            using (OracleConnection conn = DB.GetConn())
            {
                conn.Open();

                string sql = @"
                    UPDATE charger
                    SET location_id = NULL
                    WHERE charger_id = :cid
                ";

                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(":cid", txtChargerId.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("위치 삭제 완료!");
            }

            LoadLocationList();
        }

        // 🔙 돌아가기
        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            main.Show();
            this.Close();
        }
    }
}
