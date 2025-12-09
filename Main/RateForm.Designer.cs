namespace Main
{
    partial class RateForm
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
            this.메인화면ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.회원관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.충전기관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.대여반납ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.단가관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFee3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFee2 = new System.Windows.Forms.TextBox();
            this.txtOverFee = new System.Windows.Forms.TextBox();
            this.txtBaseFee = new System.Windows.Forms.TextBox();
            this.cmbRateType = new System.Windows.Forms.ComboBox();
            this.btnRateDelete = new System.Windows.Forms.Button();
            this.btnRateUpdate = new System.Windows.Forms.Button();
            this.btnRateAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRate = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRate)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.메인화면ToolStripMenuItem,
            this.회원관리ToolStripMenuItem,
            this.충전기관리ToolStripMenuItem,
            this.대여반납ToolStripMenuItem,
            this.단가관리ToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(982, 27);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 메인화면ToolStripMenuItem
            // 
            this.메인화면ToolStripMenuItem.Name = "메인화면ToolStripMenuItem";
            this.메인화면ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.메인화면ToolStripMenuItem.Text = "메인화면";
            this.메인화면ToolStripMenuItem.Click += new System.EventHandler(this.메인화면ToolStripMenuItem_Click);
            // 
            // 회원관리ToolStripMenuItem
            // 
            this.회원관리ToolStripMenuItem.Name = "회원관리ToolStripMenuItem";
            this.회원관리ToolStripMenuItem.Size = new System.Drawing.Size(92, 25);
            this.회원관리ToolStripMenuItem.Text = "회원 관리";
            this.회원관리ToolStripMenuItem.Click += new System.EventHandler(this.회원관리ToolStripMenuItem_Click);
            // 
            // 충전기관리ToolStripMenuItem
            // 
            this.충전기관리ToolStripMenuItem.Name = "충전기관리ToolStripMenuItem";
            this.충전기관리ToolStripMenuItem.Size = new System.Drawing.Size(108, 25);
            this.충전기관리ToolStripMenuItem.Text = "충전기 관리";
            this.충전기관리ToolStripMenuItem.Click += new System.EventHandler(this.충전기관리ToolStripMenuItem_Click);
            // 
            // 대여반납ToolStripMenuItem
            // 
            this.대여반납ToolStripMenuItem.Name = "대여반납ToolStripMenuItem";
            this.대여반납ToolStripMenuItem.Size = new System.Drawing.Size(104, 25);
            this.대여반납ToolStripMenuItem.Text = "대여 / 반납";
            this.대여반납ToolStripMenuItem.Click += new System.EventHandler(this.대여반납ToolStripMenuItem_Click);
            // 
            // 단가관리ToolStripMenuItem
            // 
            this.단가관리ToolStripMenuItem.Name = "단가관리ToolStripMenuItem";
            this.단가관리ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.단가관리ToolStripMenuItem.Text = "단가관리";
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.종료ToolStripMenuItem.Text = "로그아웃";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtFee3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtFee2);
            this.groupBox1.Controls.Add(this.txtOverFee);
            this.groupBox1.Controls.Add(this.txtBaseFee);
            this.groupBox1.Controls.Add(this.cmbRateType);
            this.groupBox1.Controls.Add(this.btnRateDelete);
            this.groupBox1.Controls.Add(this.btnRateUpdate);
            this.groupBox1.Controls.Add(this.btnRateAdd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(656, 66);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(313, 347);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "충전기 상세 정보";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(39, 137);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 21);
            this.label4.TabIndex = 23;
            this.label4.Text = "2시간 :";
            // 
            // txtFee3
            // 
            this.txtFee3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtFee3.Location = new System.Drawing.Point(152, 176);
            this.txtFee3.Margin = new System.Windows.Forms.Padding(1);
            this.txtFee3.Name = "txtFee3";
            this.txtFee3.Size = new System.Drawing.Size(123, 29);
            this.txtFee3.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(39, 180);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 21);
            this.label5.TabIndex = 21;
            this.label5.Text = "3시간 :";
            // 
            // txtFee2
            // 
            this.txtFee2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtFee2.Location = new System.Drawing.Point(152, 134);
            this.txtFee2.Margin = new System.Windows.Forms.Padding(1);
            this.txtFee2.Name = "txtFee2";
            this.txtFee2.Size = new System.Drawing.Size(123, 29);
            this.txtFee2.TabIndex = 20;
            // 
            // txtOverFee
            // 
            this.txtOverFee.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtOverFee.Location = new System.Drawing.Point(152, 214);
            this.txtOverFee.Margin = new System.Windows.Forms.Padding(1);
            this.txtOverFee.Name = "txtOverFee";
            this.txtOverFee.Size = new System.Drawing.Size(123, 29);
            this.txtOverFee.TabIndex = 18;
            // 
            // txtBaseFee
            // 
            this.txtBaseFee.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBaseFee.Location = new System.Drawing.Point(152, 94);
            this.txtBaseFee.Margin = new System.Windows.Forms.Padding(1);
            this.txtBaseFee.Name = "txtBaseFee";
            this.txtBaseFee.Size = new System.Drawing.Size(123, 29);
            this.txtBaseFee.TabIndex = 12;
            // 
            // cmbRateType
            // 
            this.cmbRateType.AutoCompleteCustomSource.AddRange(new string[] {
            "일반",
            "고속"});
            this.cmbRateType.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbRateType.FormattingEnabled = true;
            this.cmbRateType.Location = new System.Drawing.Point(152, 51);
            this.cmbRateType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbRateType.Name = "cmbRateType";
            this.cmbRateType.Size = new System.Drawing.Size(123, 29);
            this.cmbRateType.TabIndex = 17;
            // 
            // btnRateDelete
            // 
            this.btnRateDelete.BackColor = System.Drawing.Color.LightGray;
            this.btnRateDelete.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRateDelete.Location = new System.Drawing.Point(213, 284);
            this.btnRateDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnRateDelete.Name = "btnRateDelete";
            this.btnRateDelete.Size = new System.Drawing.Size(83, 39);
            this.btnRateDelete.TabIndex = 16;
            this.btnRateDelete.Text = "삭제";
            this.btnRateDelete.UseVisualStyleBackColor = false;
            this.btnRateDelete.Click += new System.EventHandler(this.btnRateDelete_Click_1);
            // 
            // btnRateUpdate
            // 
            this.btnRateUpdate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRateUpdate.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRateUpdate.Location = new System.Drawing.Point(117, 284);
            this.btnRateUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnRateUpdate.Name = "btnRateUpdate";
            this.btnRateUpdate.Size = new System.Drawing.Size(83, 39);
            this.btnRateUpdate.TabIndex = 15;
            this.btnRateUpdate.Text = "수정";
            this.btnRateUpdate.UseVisualStyleBackColor = false;
            this.btnRateUpdate.Click += new System.EventHandler(this.btnRateUpdate_Click_1);
            // 
            // btnRateAdd
            // 
            this.btnRateAdd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRateAdd.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRateAdd.Location = new System.Drawing.Point(22, 284);
            this.btnRateAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnRateAdd.Name = "btnRateAdd";
            this.btnRateAdd.Size = new System.Drawing.Size(83, 39);
            this.btnRateAdd.TabIndex = 14;
            this.btnRateAdd.Text = "추가";
            this.btnRateAdd.UseVisualStyleBackColor = false;
            this.btnRateAdd.Click += new System.EventHandler(this.btnRateAdd_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(38, 218);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "연체요금 : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(39, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "1시간 :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(39, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "유형 : ";
            // 
            // dgvRate
            // 
            this.dgvRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRate.Location = new System.Drawing.Point(16, 33);
            this.dgvRate.Margin = new System.Windows.Forms.Padding(1);
            this.dgvRate.Name = "dgvRate";
            this.dgvRate.RowHeadersWidth = 82;
            this.dgvRate.RowTemplate.Height = 37;
            this.dgvRate.Size = new System.Drawing.Size(589, 334);
            this.dgvRate.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvRate);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(13, 46);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(625, 389);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "요금 목록";
            // 
            // RateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(982, 454);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RateForm";
            this.Text = "단가관리";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRate)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 메인화면ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 회원관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 충전기관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 대여반납ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 단가관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRateDelete;
        private System.Windows.Forms.Button btnRateUpdate;
        private System.Windows.Forms.Button btnRateAdd;
        private System.Windows.Forms.ComboBox cmbRateType;
        private System.Windows.Forms.TextBox txtOverFee;
        private System.Windows.Forms.TextBox txtBaseFee;
        private System.Windows.Forms.TextBox txtFee3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFee2;
        private System.Windows.Forms.DataGridView dgvRate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
    }
}