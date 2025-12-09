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
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMain,
            this.menuBroken,
            this.menuHistory,
            this.menuLogout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1267, 29);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuMain
            // 
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(86, 25);
            this.menuMain.Text = "메인화면";
            this.menuMain.Click += new System.EventHandler(this.menuMain_Click);
            // 
            // menuBroken
            // 
            this.menuBroken.Name = "menuBroken";
            this.menuBroken.Size = new System.Drawing.Size(86, 25);
            this.menuBroken.Text = "고장신고";
            this.menuBroken.Click += new System.EventHandler(this.menuBroken_Click);
            // 
            // menuHistory
            // 
            this.menuHistory.Name = "menuHistory";
            this.menuHistory.Size = new System.Drawing.Size(86, 25);
            this.menuHistory.Text = "사용내역";
            this.menuHistory.Click += new System.EventHandler(this.menuHistory_Click);
            // 
            // menuLogout
            // 
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.Size = new System.Drawing.Size(86, 25);
            this.menuLogout.Text = "로그아웃";
            this.menuLogout.Click += new System.EventHandler(this.menuLogout_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(35, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(761, 460);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "충전기 반납 목록";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(705, 407);
            this.dataGridView1.TabIndex = 0;
            // 
            // BtnReturnDo
            // 
            this.BtnReturnDo.BackColor = System.Drawing.Color.LightGray;
            this.BtnReturnDo.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnReturnDo.Location = new System.Drawing.Point(132, 236);
            this.BtnReturnDo.Name = "BtnReturnDo";
            this.BtnReturnDo.Size = new System.Drawing.Size(164, 72);
            this.BtnReturnDo.TabIndex = 4;
            this.BtnReturnDo.Text = "반납하기";
            this.BtnReturnDo.UseVisualStyleBackColor = false;
            this.BtnReturnDo.Click += new System.EventHandler(this.BtnReturnDo_Click);
            // 
            // LblUsedTime
            // 
            this.LblUsedTime.AutoSize = true;
            this.LblUsedTime.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblUsedTime.Location = new System.Drawing.Point(18, 76);
            this.LblUsedTime.Name = "LblUsedTime";
            this.LblUsedTime.Size = new System.Drawing.Size(123, 30);
            this.LblUsedTime.TabIndex = 5;
            this.LblUsedTime.Text = "사용 시간 : ";
            // 
            // LblFinalPrice
            // 
            this.LblFinalPrice.AutoSize = true;
            this.LblFinalPrice.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblFinalPrice.Location = new System.Drawing.Point(18, 151);
            this.LblFinalPrice.Name = "LblFinalPrice";
            this.LblFinalPrice.Size = new System.Drawing.Size(123, 30);
            this.LblFinalPrice.TabIndex = 7;
            this.LblFinalPrice.Text = "최종 요금 : ";
            // 
            // TxtFinalPrice
            // 
            this.TxtFinalPrice.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TxtFinalPrice.Location = new System.Drawing.Point(166, 148);
            this.TxtFinalPrice.Name = "TxtFinalPrice";
            this.TxtFinalPrice.ReadOnly = true;
            this.TxtFinalPrice.Size = new System.Drawing.Size(216, 35);
            this.TxtFinalPrice.TabIndex = 8;
            // 
            // TxtUsedTime
            // 
            this.TxtUsedTime.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TxtUsedTime.Location = new System.Drawing.Point(166, 73);
            this.TxtUsedTime.Name = "TxtUsedTime";
            this.TxtUsedTime.ReadOnly = true;
            this.TxtUsedTime.Size = new System.Drawing.Size(216, 35);
            this.TxtUsedTime.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtFinalPrice);
            this.groupBox1.Controls.Add(this.TxtUsedTime);
            this.groupBox1.Controls.Add(this.BtnReturnDo);
            this.groupBox1.Controls.Add(this.LblUsedTime);
            this.groupBox1.Controls.Add(this.LblFinalPrice);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(818, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 388);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "충전기 반납하기";
            // 
            // UserReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1267, 531);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.Name = "UserReturnForm";
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
    }
}