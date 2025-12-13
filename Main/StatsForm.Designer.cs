namespace Main
{
    partial class StatsForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAvgRent = new System.Windows.Forms.Button();
            this.btnFailureRate = new System.Windows.Forms.Button();
            this.btnAvgFee = new System.Windows.Forms.Button();
            this.btnPreference = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chartStats = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPref = new System.Windows.Forms.Label();
            this.lblAvgRent = new System.Windows.Forms.Label();
            this.lblFailureRate = new System.Windows.Forms.Label();
            this.lblAvgFee = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.groupBoxPeriod = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartStats)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBoxPeriod.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAvgRent);
            this.groupBox2.Controls.Add(this.btnFailureRate);
            this.groupBox2.Controls.Add(this.btnAvgFee);
            this.groupBox2.Controls.Add(this.btnPreference);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(24, 389);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(717, 114);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "통계 상세";
            // 
            // btnAvgRent
            // 
            this.btnAvgRent.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAvgRent.Location = new System.Drawing.Point(21, 28);
            this.btnAvgRent.Name = "btnAvgRent";
            this.btnAvgRent.Size = new System.Drawing.Size(152, 61);
            this.btnAvgRent.TabIndex = 16;
            this.btnAvgRent.Text = "평균 대여 횟수";
            this.btnAvgRent.UseVisualStyleBackColor = true;
            this.btnAvgRent.Click += new System.EventHandler(this.btnAvgRent_Click);
            // 
            // btnFailureRate
            // 
            this.btnFailureRate.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFailureRate.Location = new System.Drawing.Point(193, 28);
            this.btnFailureRate.Name = "btnFailureRate";
            this.btnFailureRate.Size = new System.Drawing.Size(152, 61);
            this.btnFailureRate.TabIndex = 17;
            this.btnFailureRate.Text = "고장률";
            this.btnFailureRate.UseVisualStyleBackColor = true;
            this.btnFailureRate.Click += new System.EventHandler(this.btnFailureRate_Click);
            // 
            // btnAvgFee
            // 
            this.btnAvgFee.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAvgFee.Location = new System.Drawing.Point(367, 28);
            this.btnAvgFee.Name = "btnAvgFee";
            this.btnAvgFee.Size = new System.Drawing.Size(152, 61);
            this.btnAvgFee.TabIndex = 18;
            this.btnAvgFee.Text = "평균요금";
            this.btnAvgFee.UseVisualStyleBackColor = true;
            this.btnAvgFee.Click += new System.EventHandler(this.btnAvgFee_Click);
            // 
            // btnPreference
            // 
            this.btnPreference.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPreference.Location = new System.Drawing.Point(539, 28);
            this.btnPreference.Name = "btnPreference";
            this.btnPreference.Size = new System.Drawing.Size(152, 61);
            this.btnPreference.TabIndex = 19;
            this.btnPreference.Text = "선호도";
            this.btnPreference.UseVisualStyleBackColor = true;
            this.btnPreference.Click += new System.EventHandler(this.btnPreference_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chartStats);
            this.groupBox3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox3.Location = new System.Drawing.Point(24, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(717, 362);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "통계 그래프";
            // 
            // chartStats
            // 
            chartArea6.Name = "ChartArea1";
            this.chartStats.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chartStats.Legends.Add(legend6);
            this.chartStats.Location = new System.Drawing.Point(26, 28);
            this.chartStats.Name = "chartStats";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chartStats.Series.Add(series6);
            this.chartStats.Size = new System.Drawing.Size(665, 312);
            this.chartStats.TabIndex = 16;
            this.chartStats.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPref);
            this.groupBox1.Controls.Add(this.lblAvgRent);
            this.groupBox1.Controls.Add(this.lblFailureRate);
            this.groupBox1.Controls.Add(this.lblAvgFee);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(765, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 218);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "통계 요약";
            // 
            // lblPref
            // 
            this.lblPref.AutoSize = true;
            this.lblPref.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPref.Location = new System.Drawing.Point(29, 160);
            this.lblPref.Name = "lblPref";
            this.lblPref.Size = new System.Drawing.Size(151, 21);
            this.lblPref.TabIndex = 15;
            this.lblPref.Text = "일반/고속 선호도 : ";
            // 
            // lblAvgRent
            // 
            this.lblAvgRent.AutoSize = true;
            this.lblAvgRent.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAvgRent.Location = new System.Drawing.Point(29, 45);
            this.lblAvgRent.Name = "lblAvgRent";
            this.lblAvgRent.Size = new System.Drawing.Size(134, 21);
            this.lblAvgRent.TabIndex = 12;
            this.lblAvgRent.Text = "평균 대여 횟수 : ";
            // 
            // lblFailureRate
            // 
            this.lblFailureRate.AutoSize = true;
            this.lblFailureRate.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblFailureRate.Location = new System.Drawing.Point(29, 120);
            this.lblFailureRate.Name = "lblFailureRate";
            this.lblFailureRate.Size = new System.Drawing.Size(74, 21);
            this.lblFailureRate.TabIndex = 14;
            this.lblFailureRate.Text = "고장률 : ";
            // 
            // lblAvgFee
            // 
            this.lblAvgFee.AutoSize = true;
            this.lblAvgFee.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAvgFee.Location = new System.Drawing.Point(29, 82);
            this.lblAvgFee.Name = "lblAvgFee";
            this.lblAvgFee.Size = new System.Drawing.Size(96, 21);
            this.lblAvgFee.TabIndex = 13;
            this.lblAvgFee.Text = "평균 요금 : ";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBack.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBack.Location = new System.Drawing.Point(927, 417);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(150, 61);
            this.btnBack.TabIndex = 15;
            this.btnBack.Text = "돌아가기";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // groupBoxPeriod
            // 
            this.groupBoxPeriod.Controls.Add(this.btnSearch);
            this.groupBoxPeriod.Controls.Add(this.dtpEnd);
            this.groupBoxPeriod.Controls.Add(this.dtpStart);
            this.groupBoxPeriod.Controls.Add(this.label2);
            this.groupBoxPeriod.Controls.Add(this.label1);
            this.groupBoxPeriod.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBoxPeriod.Location = new System.Drawing.Point(765, 244);
            this.groupBoxPeriod.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxPeriod.Name = "groupBoxPeriod";
            this.groupBoxPeriod.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxPeriod.Size = new System.Drawing.Size(312, 139);
            this.groupBoxPeriod.TabIndex = 20;
            this.groupBoxPeriod.TabStop = false;
            this.groupBoxPeriod.Text = "기간 선택";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSearch.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.Location = new System.Drawing.Point(204, 95);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(88, 36);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(65, 61);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(2);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(228, 29);
            this.dtpEnd.TabIndex = 3;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(65, 28);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(2);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(228, 29);
            this.dtpStart.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(15, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "종료일:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "시작일:";
            // 
            // StatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1044, 519);
            this.Controls.Add(this.groupBoxPeriod);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBack);
            this.Name = "StatsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "통계관리";
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartStats)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxPeriod.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAvgRent;
        private System.Windows.Forms.Button btnFailureRate;
        private System.Windows.Forms.Button btnAvgFee;
        private System.Windows.Forms.Button btnPreference;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStats;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPref;
        private System.Windows.Forms.Label lblAvgRent;
        private System.Windows.Forms.Label lblFailureRate;
        private System.Windows.Forms.Label lblAvgFee;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox groupBoxPeriod;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}