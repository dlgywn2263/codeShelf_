namespace Main
{
    partial class Start
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
            this.lblId = new System.Windows.Forms.Label();
            this.lblPw = new System.Windows.Forms.Label();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.BtnSignup = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtPw = new System.Windows.Forms.TextBox();
            this.BtnPasswd = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblId.Location = new System.Drawing.Point(176, 137);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(76, 30);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "아이디";
            // 
            // lblPw
            // 
            this.lblPw.AutoSize = true;
            this.lblPw.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPw.Location = new System.Drawing.Point(176, 197);
            this.lblPw.Name = "lblPw";
            this.lblPw.Size = new System.Drawing.Size(97, 30);
            this.lblPw.TabIndex = 1;
            this.lblPw.Text = "비밀번호";
            // 
            // BtnLogin
            // 
            this.BtnLogin.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnLogin.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnLogin.Location = new System.Drawing.Point(306, 283);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(197, 76);
            this.BtnLogin.TabIndex = 2;
            this.BtnLogin.Text = "로그인";
            this.BtnLogin.UseVisualStyleBackColor = false;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // BtnSignup
            // 
            this.BtnSignup.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnSignup.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnSignup.Location = new System.Drawing.Point(54, 283);
            this.BtnSignup.Name = "BtnSignup";
            this.BtnSignup.Size = new System.Drawing.Size(197, 76);
            this.BtnSignup.TabIndex = 3;
            this.BtnSignup.Text = "회원가입";
            this.BtnSignup.UseVisualStyleBackColor = false;
            this.BtnSignup.Click += new System.EventHandler(this.BtnSignup_Click);
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtId.Location = new System.Drawing.Point(340, 134);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(260, 35);
            this.txtId.TabIndex = 4;
            // 
            // txtPw
            // 
            this.txtPw.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPw.Location = new System.Drawing.Point(340, 194);
            this.txtPw.Name = "txtPw";
            this.txtPw.PasswordChar = '●';
            this.txtPw.Size = new System.Drawing.Size(260, 35);
            this.txtPw.TabIndex = 5;
            // 
            // BtnPasswd
            // 
            this.BtnPasswd.BackColor = System.Drawing.Color.LightGray;
            this.BtnPasswd.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnPasswd.Location = new System.Drawing.Point(560, 283);
            this.BtnPasswd.Name = "BtnPasswd";
            this.BtnPasswd.Size = new System.Drawing.Size(197, 76);
            this.BtnPasswd.TabIndex = 6;
            this.BtnPasswd.Text = "비밀번호찾기";
            this.BtnPasswd.UseVisualStyleBackColor = false;
            this.BtnPasswd.Click += new System.EventHandler(this.BtnPasswd_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.title.Location = new System.Drawing.Point(289, 51);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(246, 32);
            this.title.TabIndex = 7;
            this.title.Text = "충전기를 대여하세요!";
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 452);
            this.Controls.Add(this.title);
            this.Controls.Add(this.BtnPasswd);
            this.Controls.Add(this.txtPw);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.BtnSignup);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.lblPw);
            this.Controls.Add(this.lblId);
            this.Name = "Start";
            this.Text = "로그인";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblPw;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.Button BtnSignup;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtPw;
        private System.Windows.Forms.Button BtnPasswd;
        private System.Windows.Forms.Label title;
    }
}