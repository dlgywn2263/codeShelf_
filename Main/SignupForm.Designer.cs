namespace Main
{
    partial class SignupForm
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
            this.lblPw2 = new System.Windows.Forms.Label();
            this.BtnSignup = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtPw = new System.Windows.Forms.TextBox();
            this.txtPw2 = new System.Windows.Forms.TextBox();
            this.BtnBack = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lbPhone = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblId.Location = new System.Drawing.Point(211, 366);
            this.lblId.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(151, 57);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "아이디";
            // 
            // lblPw
            // 
            this.lblPw.AutoSize = true;
            this.lblPw.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPw.Location = new System.Drawing.Point(211, 570);
            this.lblPw.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPw.Name = "lblPw";
            this.lblPw.Size = new System.Drawing.Size(193, 57);
            this.lblPw.TabIndex = 2;
            this.lblPw.Text = "비밀번호";
            // 
            // lblPw2
            // 
            this.lblPw2.AutoSize = true;
            this.lblPw2.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPw2.Location = new System.Drawing.Point(211, 686);
            this.lblPw2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPw2.Name = "lblPw2";
            this.lblPw2.Size = new System.Drawing.Size(292, 57);
            this.lblPw2.TabIndex = 3;
            this.lblPw2.Text = "비밀번호 확인";
            // 
            // BtnSignup
            // 
            this.BtnSignup.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnSignup.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnSignup.Location = new System.Drawing.Point(220, 844);
            this.BtnSignup.Margin = new System.Windows.Forms.Padding(6);
            this.BtnSignup.Name = "BtnSignup";
            this.BtnSignup.Size = new System.Drawing.Size(364, 146);
            this.BtnSignup.TabIndex = 4;
            this.BtnSignup.Text = "회원가입";
            this.BtnSignup.UseVisualStyleBackColor = false;
            this.BtnSignup.Click += new System.EventHandler(this.BtnSignup_Click);
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtId.Location = new System.Drawing.Point(630, 360);
            this.txtId.Margin = new System.Windows.Forms.Padding(6);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(439, 63);
            this.txtId.TabIndex = 5;
            this.txtId.TextChanged += new System.EventHandler(this.txtId_TextChanged);
            // 
            // txtPw
            // 
            this.txtPw.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPw.Location = new System.Drawing.Point(630, 564);
            this.txtPw.Margin = new System.Windows.Forms.Padding(6);
            this.txtPw.Name = "txtPw";
            this.txtPw.PasswordChar = '●';
            this.txtPw.Size = new System.Drawing.Size(439, 63);
            this.txtPw.TabIndex = 6;
            // 
            // txtPw2
            // 
            this.txtPw2.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPw2.Location = new System.Drawing.Point(630, 680);
            this.txtPw2.Margin = new System.Windows.Forms.Padding(6);
            this.txtPw2.Name = "txtPw2";
            this.txtPw2.PasswordChar = '●';
            this.txtPw2.Size = new System.Drawing.Size(439, 63);
            this.txtPw2.TabIndex = 7;
            // 
            // BtnBack
            // 
            this.BtnBack.BackColor = System.Drawing.Color.LightGray;
            this.BtnBack.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnBack.Location = new System.Drawing.Point(710, 844);
            this.BtnBack.Margin = new System.Windows.Forms.Padding(6);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(364, 146);
            this.BtnBack.TabIndex = 8;
            this.BtnBack.Text = "돌아가기";
            this.BtnBack.UseVisualStyleBackColor = false;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtName.Location = new System.Drawing.Point(630, 256);
            this.txtName.Margin = new System.Windows.Forms.Padding(6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(439, 63);
            this.txtName.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(211, 262);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 57);
            this.label1.TabIndex = 9;
            this.label1.Text = "이름";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPhone.Location = new System.Drawing.Point(630, 460);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(6);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(439, 63);
            this.txtPhone.TabIndex = 12;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged_1);
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress_1);
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbPhone.Location = new System.Drawing.Point(211, 466);
            this.lbPhone.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(193, 57);
            this.lbPhone.TabIndex = 11;
            this.lbPhone.Text = "전화번호";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.title.Location = new System.Drawing.Point(394, 112);
            this.title.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(524, 65);
            this.title.TabIndex = 27;
            this.title.Text = "회원가입을 해주세요 :)";
            // 
            // SignupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1299, 1278);
            this.Controls.Add(this.title);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lbPhone);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.txtPw2);
            this.Controls.Add(this.txtPw);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.BtnSignup);
            this.Controls.Add(this.lblPw2);
            this.Controls.Add(this.lblPw);
            this.Controls.Add(this.lblId);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "SignupForm";
            this.Text = "회원가입";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblPw;
        private System.Windows.Forms.Label lblPw2;
        private System.Windows.Forms.Button BtnSignup;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtPw;
        private System.Windows.Forms.TextBox txtPw2;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.Label title;
    }
}