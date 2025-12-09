using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class Payment : Form
    {
        public bool IsConfirmed = false;

        public Payment(string dateText, string spotText, string contentText, int payment)
        {
            InitializeComponent();

            // 네가 디자인에서 만든 라벨 이름에 맞춰서 값 넣기
            date.Text = dateText;                          // 날짜
            spot.Text = spotText;                          // 지점명
            content.Text = contentText;                    // 일반 / 1시간
            price.Text = payment.ToString() + "원";        // 금액
        }

        private void btnPay_Click_1(object sender, EventArgs e)
        {
            IsConfirmed = true;
            this.Close();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            IsConfirmed = false;
            this.Close();
        }
    }


}
