namespace Main
{
    partial class MemberForm
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
            this.btnMemberDelete = new System.Windows.Forms.Button();
            this.btnMemberUpdate = new System.Windows.Forms.Button();
            this.txtMemberName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMemberTrust = new System.Windows.Forms.TextBox();
            this.txtMemberPw = new System.Windows.Forms.TextBox();
            this.txtLoginId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvMember = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMember)).BeginInit();
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1011, 29);
            this.menuStrip1.TabIndex = 1;
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
            this.단가관리ToolStripMenuItem.Click += new System.EventHandler(this.단가관리ToolStripMenuItem_Click);
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
            this.groupBox1.Controls.Add(this.btnMemberDelete);
            this.groupBox1.Controls.Add(this.btnMemberUpdate);
            this.groupBox1.Controls.Add(this.txtMemberName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboStatus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMemberTrust);
            this.groupBox1.Controls.Add(this.txtMemberPw);
            this.groupBox1.Controls.Add(this.txtLoginId);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(686, 70);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(298, 359);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "회원 정보 입력";
            // 
            // btnMemberDelete
            // 
            this.btnMemberDelete.BackColor = System.Drawing.Color.LightGray;
            this.btnMemberDelete.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMemberDelete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMemberDelete.Location = new System.Drawing.Point(182, 278);
            this.btnMemberDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnMemberDelete.Name = "btnMemberDelete";
            this.btnMemberDelete.Size = new System.Drawing.Size(78, 41);
            this.btnMemberDelete.TabIndex = 16;
            this.btnMemberDelete.Text = "삭제";
            this.btnMemberDelete.UseVisualStyleBackColor = false;
            this.btnMemberDelete.Click += new System.EventHandler(this.btnMemberDelete_Click);
            // 
            // btnMemberUpdate
            // 
            this.btnMemberUpdate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMemberUpdate.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMemberUpdate.Location = new System.Drawing.Point(40, 278);
            this.btnMemberUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnMemberUpdate.Name = "btnMemberUpdate";
            this.btnMemberUpdate.Size = new System.Drawing.Size(108, 41);
            this.btnMemberUpdate.TabIndex = 15;
            this.btnMemberUpdate.Text = "상태 갱신";
            this.btnMemberUpdate.UseVisualStyleBackColor = false;
            this.btnMemberUpdate.Click += new System.EventHandler(this.btnMemberUpdate_Click);
            // 
            // txtMemberName
            // 
            this.txtMemberName.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMemberName.Location = new System.Drawing.Point(122, 64);
            this.txtMemberName.Margin = new System.Windows.Forms.Padding(2);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.ReadOnly = true;
            this.txtMemberName.Size = new System.Drawing.Size(138, 29);
            this.txtMemberName.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(39, 67);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 21);
            this.label5.TabIndex = 13;
            this.label5.Text = "이름: ";
            // 
            // comboStatus
            // 
            this.comboStatus.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboStatus.FormattingEnabled = true;
            this.comboStatus.Location = new System.Drawing.Point(122, 224);
            this.comboStatus.Margin = new System.Windows.Forms.Padding(2);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(138, 29);
            this.comboStatus.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(39, 222);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "상태: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtMemberTrust
            // 
            this.txtMemberTrust.Location = new System.Drawing.Point(122, 182);
            this.txtMemberTrust.Margin = new System.Windows.Forms.Padding(2);
            this.txtMemberTrust.Name = "txtMemberTrust";
            this.txtMemberTrust.Size = new System.Drawing.Size(138, 29);
            this.txtMemberTrust.TabIndex = 10;
            // 
            // txtMemberPw
            // 
            this.txtMemberPw.Location = new System.Drawing.Point(122, 140);
            this.txtMemberPw.Margin = new System.Windows.Forms.Padding(2);
            this.txtMemberPw.Name = "txtMemberPw";
            this.txtMemberPw.PasswordChar = '●';
            this.txtMemberPw.ReadOnly = true;
            this.txtMemberPw.Size = new System.Drawing.Size(138, 29);
            this.txtMemberPw.TabIndex = 9;
            // 
            // txtLoginId
            // 
            this.txtLoginId.Location = new System.Drawing.Point(122, 98);
            this.txtLoginId.Margin = new System.Windows.Forms.Padding(2);
            this.txtLoginId.Name = "txtLoginId";
            this.txtLoginId.ReadOnly = true;
            this.txtLoginId.Size = new System.Drawing.Size(138, 29);
            this.txtLoginId.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(39, 185);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "신뢰도: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(36, 143);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "비밀번호: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(36, 105);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "아이디: ";
            // 
            // dgvMember
            // 
            this.dgvMember.ColumnHeadersHeight = 46;
            this.dgvMember.Location = new System.Drawing.Point(16, 34);
            this.dgvMember.Margin = new System.Windows.Forms.Padding(2);
            this.dgvMember.Name = "dgvMember";
            this.dgvMember.RowHeadersWidth = 82;
            this.dgvMember.RowTemplate.Height = 37;
            this.dgvMember.Size = new System.Drawing.Size(613, 354);
            this.dgvMember.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvMember);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(22, 41);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(649, 409);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "회원 목록";
            // 
            // MemberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1011, 472);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MemberForm";
            this.Text = "회원관리";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMember)).EndInit();
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
      
        private System.Windows.Forms.TextBox txtMemberTrust;
        private System.Windows.Forms.TextBox txtMemberPw;
        private System.Windows.Forms.TextBox txtLoginId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvMember;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMemberName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnMemberDelete;
        private System.Windows.Forms.Button btnMemberUpdate;
    }
}