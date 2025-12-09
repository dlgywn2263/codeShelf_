namespace Main
{
    partial class ChargerForm
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
            this.txtBattery = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRateId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLocationId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbChargerType = new System.Windows.Forms.ComboBox();
            this.cmbChargerStatus = new System.Windows.Forms.ComboBox();
            this.txtChargerId = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.btnChargerDelete = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnChargerUpdate = new System.Windows.Forms.Button();
            this.lblChargerId = new System.Windows.Forms.Label();
            this.btnChargerAdd = new System.Windows.Forms.Button();
            this.dgvCharger = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCharger)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(1174, 29);
            this.menuStrip1.TabIndex = 2;
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
            this.groupBox1.Controls.Add(this.txtBattery);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtRateId);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtLocationId);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbChargerType);
            this.groupBox1.Controls.Add(this.cmbChargerStatus);
            this.groupBox1.Controls.Add(this.txtChargerId);
            this.groupBox1.Controls.Add(this.lblType);
            this.groupBox1.Controls.Add(this.btnChargerDelete);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.btnChargerUpdate);
            this.groupBox1.Controls.Add(this.lblChargerId);
            this.groupBox1.Controls.Add(this.btnChargerAdd);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(756, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 418);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "충전기 상세 정보";
            // 
            // txtBattery
            // 
            this.txtBattery.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBattery.Location = new System.Drawing.Point(184, 291);
            this.txtBattery.Name = "txtBattery";
            this.txtBattery.ReadOnly = true;
            this.txtBattery.Size = new System.Drawing.Size(156, 29);
            this.txtBattery.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(55, 293);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 21);
            this.label3.TabIndex = 13;
            this.label3.Text = "배터리 :";
            // 
            // txtRateId
            // 
            this.txtRateId.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtRateId.Location = new System.Drawing.Point(184, 243);
            this.txtRateId.Name = "txtRateId";
            this.txtRateId.Size = new System.Drawing.Size(156, 29);
            this.txtRateId.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(55, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 21);
            this.label2.TabIndex = 11;
            this.label2.Text = "단가 ID :";
            // 
            // txtLocationId
            // 
            this.txtLocationId.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLocationId.Location = new System.Drawing.Point(184, 194);
            this.txtLocationId.Name = "txtLocationId";
            this.txtLocationId.Size = new System.Drawing.Size(156, 29);
            this.txtLocationId.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(55, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "위치 ID :";
            // 
            // cmbChargerType
            // 
            this.cmbChargerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChargerType.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbChargerType.FormattingEnabled = true;
            this.cmbChargerType.Items.AddRange(new object[] {
            "일반",
            "고속"});
            this.cmbChargerType.Location = new System.Drawing.Point(184, 144);
            this.cmbChargerType.Name = "cmbChargerType";
            this.cmbChargerType.Size = new System.Drawing.Size(156, 29);
            this.cmbChargerType.TabIndex = 8;
            // 
            // cmbChargerStatus
            // 
            this.cmbChargerStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChargerStatus.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbChargerStatus.FormattingEnabled = true;
            this.cmbChargerStatus.Items.AddRange(new object[] {
            "대기",
            "사용 중",
            "고장"});
            this.cmbChargerStatus.Location = new System.Drawing.Point(184, 94);
            this.cmbChargerStatus.Name = "cmbChargerStatus";
            this.cmbChargerStatus.Size = new System.Drawing.Size(156, 29);
            this.cmbChargerStatus.TabIndex = 7;
            // 
            // txtChargerId
            // 
            this.txtChargerId.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtChargerId.Location = new System.Drawing.Point(184, 46);
            this.txtChargerId.Name = "txtChargerId";
            this.txtChargerId.Size = new System.Drawing.Size(156, 29);
            this.txtChargerId.TabIndex = 6;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblType.Location = new System.Drawing.Point(55, 147);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(52, 21);
            this.lblType.TabIndex = 5;
            this.lblType.Text = "유형 :";
            // 
            // btnChargerDelete
            // 
            this.btnChargerDelete.BackColor = System.Drawing.Color.LightGray;
            this.btnChargerDelete.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnChargerDelete.Location = new System.Drawing.Point(257, 348);
            this.btnChargerDelete.Name = "btnChargerDelete";
            this.btnChargerDelete.Size = new System.Drawing.Size(112, 43);
            this.btnChargerDelete.TabIndex = 8;
            this.btnChargerDelete.Text = "삭제";
            this.btnChargerDelete.UseVisualStyleBackColor = false;
            this.btnChargerDelete.Click += new System.EventHandler(this.btnChargerDelete_Click_1);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStatus.Location = new System.Drawing.Point(55, 97);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 21);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "상태 :";
            // 
            // btnChargerUpdate
            // 
            this.btnChargerUpdate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnChargerUpdate.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnChargerUpdate.Location = new System.Drawing.Point(139, 348);
            this.btnChargerUpdate.Name = "btnChargerUpdate";
            this.btnChargerUpdate.Size = new System.Drawing.Size(112, 43);
            this.btnChargerUpdate.TabIndex = 7;
            this.btnChargerUpdate.Text = "수정";
            this.btnChargerUpdate.UseVisualStyleBackColor = false;
            this.btnChargerUpdate.Click += new System.EventHandler(this.btnChargerUpdate_Click_1);
            // 
            // lblChargerId
            // 
            this.lblChargerId.AutoSize = true;
            this.lblChargerId.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblChargerId.Location = new System.Drawing.Point(55, 49);
            this.lblChargerId.Name = "lblChargerId";
            this.lblChargerId.Size = new System.Drawing.Size(91, 21);
            this.lblChargerId.TabIndex = 3;
            this.lblChargerId.Text = "충전기 ID :";
            // 
            // btnChargerAdd
            // 
            this.btnChargerAdd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnChargerAdd.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnChargerAdd.Location = new System.Drawing.Point(21, 348);
            this.btnChargerAdd.Name = "btnChargerAdd";
            this.btnChargerAdd.Size = new System.Drawing.Size(112, 43);
            this.btnChargerAdd.TabIndex = 6;
            this.btnChargerAdd.Text = "추가";
            this.btnChargerAdd.UseVisualStyleBackColor = false;
            this.btnChargerAdd.Click += new System.EventHandler(this.btnChargerAdd_Click_1);
            // 
            // dgvCharger
            // 
            this.dgvCharger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCharger.Location = new System.Drawing.Point(13, 27);
            this.dgvCharger.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCharger.Name = "dgvCharger";
            this.dgvCharger.RowHeadersWidth = 82;
            this.dgvCharger.RowTemplate.Height = 37;
            this.dgvCharger.Size = new System.Drawing.Size(690, 374);
            this.dgvCharger.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvCharger);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(21, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(718, 418);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "충전기 목록";
            // 
            // ChargerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 483);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ChargerForm";
            this.Text = "충전기관리";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCharger)).EndInit();
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
        private System.Windows.Forms.Button btnChargerDelete;
        private System.Windows.Forms.Button btnChargerUpdate;
        private System.Windows.Forms.Button btnChargerAdd;
        private System.Windows.Forms.DataGridView dgvCharger;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblChargerId;
        private System.Windows.Forms.TextBox txtChargerId;
        private System.Windows.Forms.ComboBox cmbChargerType;
        private System.Windows.Forms.ComboBox cmbChargerStatus;
        private System.Windows.Forms.TextBox txtRateId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLocationId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBattery;
        private System.Windows.Forms.Label label3;
    }
}