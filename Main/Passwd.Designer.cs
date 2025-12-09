namespace Main
{
    partial class Passwd
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
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lbPhone = new System.Windows.Forms.Label();
            this.BtnBack = new System.Windows.Forms.Button();
            this.txtPwReset2 = new System.Windows.Forms.TextBox();
            this.txtPwReset = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.BtnReset = new System.Windows.Forms.Button();
            this.lblPw2 = new System.Windows.Forms.Label();
            this.lblPw = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.BtnCheck = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPhone.Location = new System.Drawing.Point(290, 173);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(238, 35);
            this.txtPhone.TabIndex = 24;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged_1);
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbPhone.Location = new System.Drawing.Point(64, 176);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(146, 30);
            this.lbPhone.TabIndex = 23;
            this.lbPhone.Text = "전화번호 확인";
            // 
            // BtnBack
            // 
            this.BtnBack.BackColor = System.Drawing.Color.LightGray;
            this.BtnBack.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnBack.Location = new System.Drawing.Point(332, 353);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(196, 76);
            this.BtnBack.TabIndex = 20;
            this.BtnBack.Text = "돌아가기";
            this.BtnBack.UseVisualStyleBackColor = false;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // txtPwReset2
            // 
            this.txtPwReset2.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPwReset2.Location = new System.Drawing.Point(290, 276);
            this.txtPwReset2.Name = "txtPwReset2";
            this.txtPwReset2.PasswordChar = '●';
            this.txtPwReset2.Size = new System.Drawing.Size(238, 35);
            this.txtPwReset2.TabIndex = 19;
            // 
            // txtPwReset
            // 
            this.txtPwReset.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPwReset.Location = new System.Drawing.Point(290, 225);
            this.txtPwReset.Name = "txtPwReset";
            this.txtPwReset.PasswordChar = '●';
            this.txtPwReset.Size = new System.Drawing.Size(238, 35);
            this.txtPwReset.TabIndex = 18;
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtId.Location = new System.Drawing.Point(290, 123);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(238, 35);
            this.txtId.TabIndex = 17;
            // 
            // BtnReset
            // 
            this.BtnReset.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnReset.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnReset.Location = new System.Drawing.Point(68, 353);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(196, 76);
            this.BtnReset.TabIndex = 16;
            this.BtnReset.Text = "재설정하기";
            this.BtnReset.UseVisualStyleBackColor = false;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // lblPw2
            // 
            this.lblPw2.AutoSize = true;
            this.lblPw2.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPw2.Location = new System.Drawing.Point(64, 279);
            this.lblPw2.Name = "lblPw2";
            this.lblPw2.Size = new System.Drawing.Size(146, 30);
            this.lblPw2.TabIndex = 15;
            this.lblPw2.Text = "비밀번호 확인";
            // 
            // lblPw
            // 
            this.lblPw.AutoSize = true;
            this.lblPw.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPw.Location = new System.Drawing.Point(64, 228);
            this.lblPw.Name = "lblPw";
            this.lblPw.Size = new System.Drawing.Size(167, 30);
            this.lblPw.TabIndex = 14;
            this.lblPw.Text = "비밀번호 재설정";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblId.Location = new System.Drawing.Point(64, 126);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(76, 30);
            this.lblId.TabIndex = 13;
            this.lblId.Text = "아이디";
            // 
            // BtnCheck
            // 
            this.BtnCheck.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnCheck.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnCheck.Location = new System.Drawing.Point(534, 170);
            this.BtnCheck.Name = "BtnCheck";
            this.BtnCheck.Size = new System.Drawing.Size(82, 42);
            this.BtnCheck.TabIndex = 25;
            this.BtnCheck.Text = "확인";
            this.BtnCheck.UseVisualStyleBackColor = false;
            this.BtnCheck.Click += new System.EventHandler(this.BtnCheck_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.title.Location = new System.Drawing.Point(148, 46);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(297, 32);
            this.title.TabIndex = 26;
            this.title.Text = "비밀번호를 까먹으셨나요?";
            // 
            // Passwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 480);
            this.Controls.Add(this.title);
            this.Controls.Add(this.BtnCheck);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lbPhone);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.txtPwReset2);
            this.Controls.Add(this.txtPwReset);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.lblPw2);
            this.Controls.Add(this.lblPw);
            this.Controls.Add(this.lblId);
            this.Name = "Passwd";
            this.Text = "비밀번호 찾기";
            this.Load += new System.EventHandler(this.Passwd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.TextBox txtPwReset2;
        private System.Windows.Forms.TextBox txtPwReset;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Label lblPw2;
        private System.Windows.Forms.Label lblPw;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button BtnCheck;
        private System.Windows.Forms.Label title;
    }
}