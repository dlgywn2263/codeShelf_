namespace Main
{
    partial class UserRentalForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtPrice = new System.Windows.Forms.TextBox();
            this.LblPrice = new System.Windows.Forms.Label();
            this.ComboTime = new System.Windows.Forms.ComboBox();
            this.BtnRentDo = new System.Windows.Forms.Button();
            this.ComboType = new System.Windows.Forms.ComboBox();
            this.LblTime = new System.Windows.Forms.Label();
            this.LblType = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuMain = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBroken = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtPrice);
            this.groupBox1.Controls.Add(this.LblPrice);
            this.groupBox1.Controls.Add(this.ComboTime);
            this.groupBox1.Controls.Add(this.BtnRentDo);
            this.groupBox1.Controls.Add(this.ComboType);
            this.groupBox1.Controls.Add(this.LblTime);
            this.groupBox1.Controls.Add(this.LblType);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(121, 106);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(1363, 740);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "충전기 대여하기";
            // 
            // TxtPrice
            // 
            this.TxtPrice.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TxtPrice.Location = new System.Drawing.Point(618, 360);
            this.TxtPrice.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.TxtPrice.Name = "TxtPrice";
            this.TxtPrice.ReadOnly = true;
            this.TxtPrice.Size = new System.Drawing.Size(453, 63);
            this.TxtPrice.TabIndex = 6;
            // 
            // LblPrice
            // 
            this.LblPrice.AutoSize = true;
            this.LblPrice.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblPrice.Location = new System.Drawing.Point(273, 366);
            this.LblPrice.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LblPrice.Name = "LblPrice";
            this.LblPrice.Size = new System.Drawing.Size(249, 57);
            this.LblPrice.TabIndex = 5;
            this.LblPrice.Text = "기본 요금 : ";
            // 
            // ComboTime
            // 
            this.ComboTime.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ComboTime.FormattingEnabled = true;
            this.ComboTime.Location = new System.Drawing.Point(618, 242);
            this.ComboTime.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ComboTime.Name = "ComboTime";
            this.ComboTime.Size = new System.Drawing.Size(453, 65);
            this.ComboTime.TabIndex = 4;
            this.ComboTime.SelectedIndexChanged += new System.EventHandler(this.ComboTime_SelectedIndexChanged);
            // 
            // BtnRentDo
            // 
            this.BtnRentDo.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnRentDo.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnRentDo.Location = new System.Drawing.Point(503, 504);
            this.BtnRentDo.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.BtnRentDo.Name = "BtnRentDo";
            this.BtnRentDo.Size = new System.Drawing.Size(357, 150);
            this.BtnRentDo.TabIndex = 3;
            this.BtnRentDo.Text = "대여하기";
            this.BtnRentDo.UseVisualStyleBackColor = false;
            this.BtnRentDo.Click += new System.EventHandler(this.BtnRentDo_Click);
            // 
            // ComboType
            // 
            this.ComboType.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ComboType.FormattingEnabled = true;
            this.ComboType.Location = new System.Drawing.Point(618, 120);
            this.ComboType.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ComboType.Name = "ComboType";
            this.ComboType.Size = new System.Drawing.Size(453, 65);
            this.ComboType.TabIndex = 2;
            this.ComboType.SelectedIndexChanged += new System.EventHandler(this.ComboType_SelectedIndexChanged);
            // 
            // LblTime
            // 
            this.LblTime.AutoSize = true;
            this.LblTime.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblTime.Location = new System.Drawing.Point(273, 248);
            this.LblTime.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LblTime.Name = "LblTime";
            this.LblTime.Size = new System.Drawing.Size(249, 57);
            this.LblTime.TabIndex = 1;
            this.LblTime.Text = "사용 시간 : ";
            // 
            // LblType
            // 
            this.LblType.AutoSize = true;
            this.LblType.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblType.Location = new System.Drawing.Point(273, 126);
            this.LblType.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(291, 57);
            this.LblType.TabIndex = 0;
            this.LblType.Text = "충전기 유형 : ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMain,
            this.menuBroken,
            this.menuHistory,
            this.menuLogout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1636, 57);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuMain
            // 
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(168, 49);
            this.menuMain.Text = "메인화면";
            this.menuMain.Click += new System.EventHandler(this.menuMain_Click);
            // 
            // menuBroken
            // 
            this.menuBroken.Name = "menuBroken";
            this.menuBroken.Size = new System.Drawing.Size(168, 49);
            this.menuBroken.Text = "고장신고";
            this.menuBroken.Click += new System.EventHandler(this.menuBroken_Click);
            // 
            // menuHistory
            // 
            this.menuHistory.Name = "menuHistory";
            this.menuHistory.Size = new System.Drawing.Size(168, 49);
            this.menuHistory.Text = "사용내역";
            this.menuHistory.Click += new System.EventHandler(this.menuHistory_Click);
            // 
            // menuLogout
            // 
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.Size = new System.Drawing.Size(168, 49);
            this.menuLogout.Text = "로그아웃";
            this.menuLogout.Click += new System.EventHandler(this.menuLogout_Click);
            // 
            // UserRentalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1636, 954);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "UserRentalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "대여";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LblType;
        private System.Windows.Forms.ComboBox ComboTime;
        private System.Windows.Forms.Button BtnRentDo;
        private System.Windows.Forms.ComboBox ComboType;
        private System.Windows.Forms.Label LblTime;
        private System.Windows.Forms.Label LblPrice;
        private System.Windows.Forms.TextBox TxtPrice;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuBroken;
        private System.Windows.Forms.ToolStripMenuItem menuHistory;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
    }
}