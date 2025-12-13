namespace Main
{
    partial class UserReturnForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuMain = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBroken = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BtnReturnDo = new System.Windows.Forms.Button();
            this.LblUsedTime = new System.Windows.Forms.Label();
            this.LblFinalPrice = new System.Windows.Forms.Label();
            this.TxtFinalPrice = new System.Windows.Forms.TextBox();
            this.TxtUsedTime = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtBasePrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtLateFee = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(2577, 57);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(15, 92);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(1778, 925);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "충전기 반납 목록";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 58);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1730, 852);
            this.dataGridView1.TabIndex = 0;
            // 
            // BtnReturnDo
            // 
            this.BtnReturnDo.BackColor = System.Drawing.Color.LightGray;
            this.BtnReturnDo.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnReturnDo.Location = new System.Drawing.Point(247, 632);
            this.BtnReturnDo.Margin = new System.Windows.Forms.Padding(6);
            this.BtnReturnDo.Name = "BtnReturnDo";
            this.BtnReturnDo.Size = new System.Drawing.Size(305, 144);
            this.BtnReturnDo.TabIndex = 4;
            this.BtnReturnDo.Text = "반납하기";
            this.BtnReturnDo.UseVisualStyleBackColor = false;
            this.BtnReturnDo.Click += new System.EventHandler(this.BtnReturnDo_Click);
            // 
            // LblUsedTime
            // 
            this.LblUsedTime.AutoSize = true;
            this.LblUsedTime.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblUsedTime.Location = new System.Drawing.Point(33, 152);
            this.LblUsedTime.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LblUsedTime.Name = "LblUsedTime";
            this.LblUsedTime.Size = new System.Drawing.Size(249, 57);
            this.LblUsedTime.TabIndex = 5;
            this.LblUsedTime.Text = "사용 시간 : ";
            // 
            // LblFinalPrice
            // 
            this.LblFinalPrice.AutoSize = true;
            this.LblFinalPrice.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblFinalPrice.Location = new System.Drawing.Point(33, 491);
            this.LblFinalPrice.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LblFinalPrice.Name = "LblFinalPrice";
            this.LblFinalPrice.Size = new System.Drawing.Size(249, 57);
            this.LblFinalPrice.TabIndex = 7;
            this.LblFinalPrice.Text = "최종 요금 : ";
            // 
            // TxtFinalPrice
            // 
            this.TxtFinalPrice.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TxtFinalPrice.Location = new System.Drawing.Point(308, 485);
            this.TxtFinalPrice.Margin = new System.Windows.Forms.Padding(6);
            this.TxtFinalPrice.Name = "TxtFinalPrice";
            this.TxtFinalPrice.ReadOnly = true;
            this.TxtFinalPrice.Size = new System.Drawing.Size(398, 63);
            this.TxtFinalPrice.TabIndex = 8;
            // 
            // TxtUsedTime
            // 
            this.TxtUsedTime.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TxtUsedTime.Location = new System.Drawing.Point(308, 146);
            this.TxtUsedTime.Margin = new System.Windows.Forms.Padding(6);
            this.TxtUsedTime.Name = "TxtUsedTime";
            this.TxtUsedTime.ReadOnly = true;
            this.TxtUsedTime.Size = new System.Drawing.Size(398, 63);
            this.TxtUsedTime.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtBasePrice);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtLateFee);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtFinalPrice);
            this.groupBox1.Controls.Add(this.TxtUsedTime);
            this.groupBox1.Controls.Add(this.BtnReturnDo);
            this.groupBox1.Controls.Add(this.LblUsedTime);
            this.groupBox1.Controls.Add(this.LblFinalPrice);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(1814, 150);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(744, 839);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "충전기 반납하기";
            // 
            // TxtBasePrice
            // 
            this.TxtBasePrice.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TxtBasePrice.Location = new System.Drawing.Point(308, 259);
            this.TxtBasePrice.Margin = new System.Windows.Forms.Padding(6);
            this.TxtBasePrice.Name = "TxtBasePrice";
            this.TxtBasePrice.ReadOnly = true;
            this.TxtBasePrice.Size = new System.Drawing.Size(398, 63);
            this.TxtBasePrice.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(33, 265);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 57);
            this.label2.TabIndex = 12;
            this.label2.Text = "기본 요금 : ";
            // 
            // TxtLateFee
            // 
            this.TxtLateFee.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TxtLateFee.Location = new System.Drawing.Point(308, 376);
            this.TxtLateFee.Margin = new System.Windows.Forms.Padding(6);
            this.TxtLateFee.Name = "TxtLateFee";
            this.TxtLateFee.ReadOnly = true;
            this.TxtLateFee.Size = new System.Drawing.Size(398, 63);
            this.TxtLateFee.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(33, 382);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 57);
            this.label1.TabIndex = 10;
            this.label1.Text = "연체 요금 : ";
            // 
            // UserReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2577, 1062);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "UserReturnForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "반납";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuBroken;
        private System.Windows.Forms.ToolStripMenuItem menuHistory;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BtnReturnDo;
        private System.Windows.Forms.Label LblUsedTime;
        private System.Windows.Forms.Label LblFinalPrice;
        private System.Windows.Forms.TextBox TxtFinalPrice;
        private System.Windows.Forms.TextBox TxtUsedTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtBasePrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtLateFee;
        private System.Windows.Forms.Label label1;
    }
}