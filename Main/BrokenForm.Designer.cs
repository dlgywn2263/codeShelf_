namespace Main
{
    partial class BrokenForm
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
            this.DatePickerDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDetail = new System.Windows.Forms.TextBox();
            this.BtnReport = new System.Windows.Forms.Button();
            this.ComboSymptom = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuMain = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBroken = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvRentCharger = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentCharger)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DatePickerDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtDetail);
            this.groupBox1.Controls.Add(this.BtnReport);
            this.groupBox1.Controls.Add(this.ComboSymptom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(1338, 149);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(685, 889);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "고장 신고";
            // 
            // DatePickerDate
            // 
            this.DatePickerDate.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DatePickerDate.Location = new System.Drawing.Point(224, 63);
            this.DatePickerDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DatePickerDate.Name = "DatePickerDate";
            this.DatePickerDate.Size = new System.Drawing.Size(408, 50);
            this.DatePickerDate.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(29, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 50);
            this.label3.TabIndex = 0;
            this.label3.Text = "해당 날짜 :";
            // 
            // TxtDetail
            // 
            this.TxtDetail.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TxtDetail.Location = new System.Drawing.Point(224, 219);
            this.TxtDetail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtDetail.Multiline = true;
            this.TxtDetail.Name = "TxtDetail";
            this.TxtDetail.Size = new System.Drawing.Size(430, 540);
            this.TxtDetail.TabIndex = 9;
            // 
            // BtnReport
            // 
            this.BtnReport.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnReport.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnReport.Location = new System.Drawing.Point(438, 784);
            this.BtnReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnReport.Name = "BtnReport";
            this.BtnReport.Size = new System.Drawing.Size(216, 86);
            this.BtnReport.TabIndex = 8;
            this.BtnReport.Text = "제출하기";
            this.BtnReport.UseVisualStyleBackColor = false;
            this.BtnReport.Click += new System.EventHandler(this.BtnReport_Click);
            // 
            // ComboSymptom
            // 
            this.ComboSymptom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboSymptom.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ComboSymptom.FormattingEnabled = true;
            this.ComboSymptom.Items.AddRange(new object[] {
            ""});
            this.ComboSymptom.Location = new System.Drawing.Point(224, 144);
            this.ComboSymptom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComboSymptom.Name = "ComboSymptom";
            this.ComboSymptom.Size = new System.Drawing.Size(408, 53);
            this.ComboSymptom.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(29, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 45);
            this.label2.TabIndex = 1;
            this.label2.Text = "상세 설명 : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(29, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "고장 증상 : ";
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(2035, 55);
            this.menuStrip1.TabIndex = 5;
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
            // dgvRentCharger
            // 
            this.dgvRentCharger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentCharger.Location = new System.Drawing.Point(27, 64);
            this.dgvRentCharger.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvRentCharger.Name = "dgvRentCharger";
            this.dgvRentCharger.RowHeadersWidth = 82;
            this.dgvRentCharger.RowTemplate.Height = 37;
            this.dgvRentCharger.Size = new System.Drawing.Size(1258, 850);
            this.dgvRentCharger.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvRentCharger);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(16, 88);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Size = new System.Drawing.Size(1302, 950);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "대여 목록";
            // 
            // BrokenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(2035, 1102);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BrokenForm";
            this.Text = "고장신고";
            this.Load += new System.EventHandler(this.BrokenForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentCharger)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComboSymptom;
        private System.Windows.Forms.TextBox TxtDetail;
        private System.Windows.Forms.Button BtnReport;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuBroken;
        private System.Windows.Forms.ToolStripMenuItem menuHistory;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DatePickerDate;
        private System.Windows.Forms.DataGridView dgvRentCharger;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}