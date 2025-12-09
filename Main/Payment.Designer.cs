namespace Main
{
    partial class Payment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDate = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.lblSpot = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.spot = new System.Windows.Forms.Label();
            this.content = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDate.Location = new System.Drawing.Point(31, 90);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(67, 30);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "날짜: ";
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.date.Location = new System.Drawing.Point(274, 90);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(70, 30);
            this.date.TabIndex = 1;
            this.date.Text = "label2";
            // 
            // lblSpot
            // 
            this.lblSpot.AutoSize = true;
            this.lblSpot.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSpot.Location = new System.Drawing.Point(31, 141);
            this.lblSpot.Name = "lblSpot";
            this.lblSpot.Size = new System.Drawing.Size(88, 30);
            this.lblSpot.TabIndex = 2;
            this.lblSpot.Text = "지점명: ";
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblContent.Location = new System.Drawing.Point(31, 190);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(116, 30);
            this.lblContent.TabIndex = 3;
            this.lblContent.Text = "결제 내용: ";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPrice.Location = new System.Drawing.Point(35, 237);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(165, 30);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "최종 결제 금액: ";
            // 
            // spot
            // 
            this.spot.AutoSize = true;
            this.spot.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.spot.Location = new System.Drawing.Point(274, 141);
            this.spot.Name = "spot";
            this.spot.Size = new System.Drawing.Size(70, 30);
            this.spot.TabIndex = 5;
            this.spot.Text = "label6";
            // 
            // content
            // 
            this.content.AutoSize = true;
            this.content.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.content.Location = new System.Drawing.Point(274, 190);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(70, 30);
            this.content.TabIndex = 6;
            this.content.Text = "label7";
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.price.Location = new System.Drawing.Point(274, 237);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(70, 30);
            this.price.TabIndex = 7;
            this.price.Text = "label8";
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPay.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPay.Location = new System.Drawing.Point(36, 319);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(145, 66);
            this.btnPay.TabIndex = 8;
            this.btnPay.Text = "결제하기";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click_1);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(233, 319);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(145, 66);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.title.Location = new System.Drawing.Point(138, 24);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(118, 32);
            this.title.TabIndex = 28;
            this.title.Text = "결제 정보";
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 409);
            this.Controls.Add(this.title);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.price);
            this.Controls.Add(this.content);
            this.Controls.Add(this.spot);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.lblSpot);
            this.Controls.Add(this.date);
            this.Controls.Add(this.lblDate);
            this.Name = "Payment";
            this.Text = "결제 정보";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Label lblSpot;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label spot;
        private System.Windows.Forms.Label content;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label title;
    }
}