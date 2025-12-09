namespace Main
{
    partial class BrokenManageForm
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
            this.dgvBroken = new System.Windows.Forms.DataGridView();
            this.BtnBack = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.cmbFaultType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numMinusCredibility = new System.Windows.Forms.NumericUpDown();
            this.cmbFaultStatus = new System.Windows.Forms.ComboBox();
            this.txtFaultText = new System.Windows.Forms.TextBox();
            this.txtMemberId = new System.Windows.Forms.TextBox();
            this.txtChargerId = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pnlDone = new System.Windows.Forms.Panel();
            this.Done = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlPending = new System.Windows.Forms.Panel();
            this.Pending = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.Total = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBroken)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinusCredibility)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.pnlDone.SuspendLayout();
            this.pnlPending.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvBroken);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(36, 59);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(1524, 889);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "신고내역";
            // 
            // dgvBroken
            // 
            this.dgvBroken.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBroken.Location = new System.Drawing.Point(26, 55);
            this.dgvBroken.Margin = new System.Windows.Forms.Padding(6);
            this.dgvBroken.Name = "dgvBroken";
            this.dgvBroken.RowHeadersWidth = 82;
            this.dgvBroken.RowTemplate.Height = 23;
            this.dgvBroken.Size = new System.Drawing.Size(1466, 803);
            this.dgvBroken.TabIndex = 0;
            this.dgvBroken.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBroken_CellClick);
            // 
            // BtnBack
            // 
            this.BtnBack.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnBack.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnBack.Location = new System.Drawing.Point(1666, 1062);
            this.BtnBack.Margin = new System.Windows.Forms.Padding(6);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(254, 102);
            this.BtnBack.TabIndex = 9;
            this.BtnBack.Text = "돌아가기";
            this.BtnBack.UseVisualStyleBackColor = false;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnProcess);
            this.groupBox2.Controls.Add(this.cmbFaultType);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.numMinusCredibility);
            this.groupBox2.Controls.Add(this.cmbFaultStatus);
            this.groupBox2.Controls.Add(this.txtFaultText);
            this.groupBox2.Controls.Add(this.txtMemberId);
            this.groupBox2.Controls.Add(this.txtChargerId);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(1600, 73);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(631, 844);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "신고 상세정보";
            // 
            // btnProcess
            // 
            this.btnProcess.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnProcess.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnProcess.Location = new System.Drawing.Point(97, 710);
            this.btnProcess.Margin = new System.Windows.Forms.Padding(6);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(214, 90);
            this.btnProcess.TabIndex = 19;
            this.btnProcess.Text = "상태 수정";
            this.btnProcess.UseVisualStyleBackColor = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click_1);
            // 
            // cmbFaultType
            // 
            this.cmbFaultType.FormattingEnabled = true;
            this.cmbFaultType.Items.AddRange(new object[] {
            "충전 불량",
            "배터리 문제",
            "포트 고장",
            "기타"});
            this.cmbFaultType.Location = new System.Drawing.Point(262, 204);
            this.cmbFaultType.Margin = new System.Windows.Forms.Padding(6);
            this.cmbFaultType.Name = "cmbFaultType";
            this.cmbFaultType.Size = new System.Drawing.Size(323, 53);
            this.cmbFaultType.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(45, 210);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 45);
            this.label6.TabIndex = 17;
            this.label6.Text = "고장 종류 : ";
            // 
            // numMinusCredibility
            // 
            this.numMinusCredibility.Location = new System.Drawing.Point(262, 618);
            this.numMinusCredibility.Margin = new System.Windows.Forms.Padding(6);
            this.numMinusCredibility.Name = "numMinusCredibility";
            this.numMinusCredibility.Size = new System.Drawing.Size(327, 50);
            this.numMinusCredibility.TabIndex = 16;
            // 
            // cmbFaultStatus
            // 
            this.cmbFaultStatus.FormattingEnabled = true;
            this.cmbFaultStatus.Items.AddRange(new object[] {
            "미처리",
            "처리완료"});
            this.cmbFaultStatus.Location = new System.Drawing.Point(262, 528);
            this.cmbFaultStatus.Margin = new System.Windows.Forms.Padding(6);
            this.cmbFaultStatus.Name = "cmbFaultStatus";
            this.cmbFaultStatus.Size = new System.Drawing.Size(323, 53);
            this.cmbFaultStatus.TabIndex = 15;
            // 
            // txtFaultText
            // 
            this.txtFaultText.Location = new System.Drawing.Point(262, 286);
            this.txtFaultText.Margin = new System.Windows.Forms.Padding(6);
            this.txtFaultText.Multiline = true;
            this.txtFaultText.Name = "txtFaultText";
            this.txtFaultText.Size = new System.Drawing.Size(323, 210);
            this.txtFaultText.TabIndex = 14;
            // 
            // txtMemberId
            // 
            this.txtMemberId.Location = new System.Drawing.Point(262, 126);
            this.txtMemberId.Margin = new System.Windows.Forms.Padding(6);
            this.txtMemberId.Name = "txtMemberId";
            this.txtMemberId.Size = new System.Drawing.Size(323, 50);
            this.txtMemberId.TabIndex = 13;
            // 
            // txtChargerId
            // 
            this.txtChargerId.Location = new System.Drawing.Point(262, 56);
            this.txtChargerId.Margin = new System.Windows.Forms.Padding(6);
            this.txtChargerId.Name = "txtChargerId";
            this.txtChargerId.Size = new System.Drawing.Size(323, 50);
            this.txtChargerId.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(345, 710);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(214, 90);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(45, 622);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(191, 45);
            this.label5.TabIndex = 4;
            this.label5.Text = "신뢰도 감수";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(45, 534);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 45);
            this.label4.TabIndex = 3;
            this.label4.Text = "처리 상태";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(45, 292);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 45);
            this.label3.TabIndex = 2;
            this.label3.Text = "고장 내용";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(45, 132);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 45);
            this.label2.TabIndex = 1;
            this.label2.Text = "회원 ID : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(45, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "충전기 ID : ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pnlDone);
            this.groupBox3.Controls.Add(this.pnlPending);
            this.groupBox3.Controls.Add(this.pnlTotal);
            this.groupBox3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox3.Location = new System.Drawing.Point(425, 960);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox3.Size = new System.Drawing.Size(990, 308);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "상태현황";
            // 
            // pnlDone
            // 
            this.pnlDone.BackColor = System.Drawing.Color.LightGreen;
            this.pnlDone.Controls.Add(this.Done);
            this.pnlDone.Controls.Add(this.label8);
            this.pnlDone.Location = new System.Drawing.Point(693, 70);
            this.pnlDone.Margin = new System.Windows.Forms.Padding(6);
            this.pnlDone.Name = "pnlDone";
            this.pnlDone.Size = new System.Drawing.Size(243, 176);
            this.pnlDone.TabIndex = 25;
            // 
            // Done
            // 
            this.Done.AutoSize = true;
            this.Done.Location = new System.Drawing.Point(150, 88);
            this.Done.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Done.Name = "Done";
            this.Done.Size = new System.Drawing.Size(52, 45);
            this.Done.TabIndex = 23;
            this.Done.Text = "건";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(50, 32);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 42);
            this.label8.TabIndex = 20;
            this.label8.Text = "처리완료";
            // 
            // pnlPending
            // 
            this.pnlPending.BackColor = System.Drawing.Color.LightCoral;
            this.pnlPending.Controls.Add(this.Pending);
            this.pnlPending.Controls.Add(this.label10);
            this.pnlPending.Location = new System.Drawing.Point(371, 70);
            this.pnlPending.Margin = new System.Windows.Forms.Padding(6);
            this.pnlPending.Name = "pnlPending";
            this.pnlPending.Size = new System.Drawing.Size(243, 176);
            this.pnlPending.TabIndex = 24;
            // 
            // Pending
            // 
            this.Pending.AutoSize = true;
            this.Pending.Location = new System.Drawing.Point(130, 88);
            this.Pending.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Pending.Name = "Pending";
            this.Pending.Size = new System.Drawing.Size(52, 45);
            this.Pending.TabIndex = 22;
            this.Pending.Text = "건";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(71, 32);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 42);
            this.label10.TabIndex = 20;
            this.label10.Text = "미처리";
            // 
            // pnlTotal
            // 
            this.pnlTotal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTotal.Controls.Add(this.Total);
            this.pnlTotal.Controls.Add(this.label7);
            this.pnlTotal.Location = new System.Drawing.Point(52, 70);
            this.pnlTotal.Margin = new System.Windows.Forms.Padding(6);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(243, 176);
            this.pnlTotal.TabIndex = 23;
            // 
            // Total
            // 
            this.Total.AutoSize = true;
            this.Total.Location = new System.Drawing.Point(173, 88);
            this.Total.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(52, 45);
            this.Total.TabIndex = 21;
            this.Total.Text = "건";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(22, 32);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(199, 42);
            this.label7.TabIndex = 20;
            this.label7.Text = "총 신고 개수";
            // 
            // BrokenManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2244, 1156);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "BrokenManageForm";
            this.Text = "고장신고관리";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBroken)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinusCredibility)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.pnlDone.ResumeLayout(false);
            this.pnlDone.PerformLayout();
            this.pnlPending.ResumeLayout(false);
            this.pnlPending.PerformLayout();
            this.pnlTotal.ResumeLayout(false);
            this.pnlTotal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvBroken;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFaultStatus;
        private System.Windows.Forms.TextBox txtFaultText;
        private System.Windows.Forms.TextBox txtMemberId;
        private System.Windows.Forms.TextBox txtChargerId;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numMinusCredibility;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.ComboBox cmbFaultType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlDone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnlPending;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label Done;
        private System.Windows.Forms.Label Pending;
        private System.Windows.Forms.Label Total;
    }
}