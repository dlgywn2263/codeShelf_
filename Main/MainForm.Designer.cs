namespace Main
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
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
            this.lblDueToday = new System.Windows.Forms.Label();
            this.lblWait = new System.Windows.Forms.Label();
            this.lblLate = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblBroken = new System.Windows.Forms.Label();
            this.lblUsing = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSettlement = new System.Windows.Forms.Button();
            this.btnBrokenManage = new System.Windows.Forms.Button();
            this.btnStats = new System.Windows.Forms.Button();
            this.btnLocation = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(588, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 메인화면ToolStripMenuItem
            // 
            this.메인화면ToolStripMenuItem.Name = "메인화면ToolStripMenuItem";
            this.메인화면ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.메인화면ToolStripMenuItem.Text = "메인화면";
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
            this.groupBox1.Controls.Add(this.lblDueToday);
            this.groupBox1.Controls.Add(this.lblWait);
            this.groupBox1.Controls.Add(this.lblLate);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.lblBroken);
            this.groupBox1.Controls.Add(this.lblUsing);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(70, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 158);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "현황 요약";
            // 
            // lblDueToday
            // 
            this.lblDueToday.AutoSize = true;
            this.lblDueToday.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDueToday.Location = new System.Drawing.Point(229, 108);
            this.lblDueToday.Name = "lblDueToday";
            this.lblDueToday.Size = new System.Drawing.Size(195, 25);
            this.lblDueToday.TabIndex = 3;
            this.lblDueToday.Text = "- 오늘 반납 예정: 4건";
            // 
            // lblWait
            // 
            this.lblWait.AutoSize = true;
            this.lblWait.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWait.Location = new System.Drawing.Point(21, 110);
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(131, 25);
            this.lblWait.TabIndex = 4;
            this.lblWait.Text = "- 대기 중: 7대";
            // 
            // lblLate
            // 
            this.lblLate.AutoSize = true;
            this.lblLate.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLate.Location = new System.Drawing.Point(229, 73);
            this.lblLate.Name = "lblLate";
            this.lblLate.Size = new System.Drawing.Size(131, 25);
            this.lblLate.TabIndex = 2;
            this.lblLate.Text = "- 연체 중: 1건";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTotal.Location = new System.Drawing.Point(21, 39);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(179, 25);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "- 전체 충전기: 15대";
            // 
            // lblBroken
            // 
            this.lblBroken.AutoSize = true;
            this.lblBroken.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBroken.Location = new System.Drawing.Point(229, 39);
            this.lblBroken.Name = "lblBroken";
            this.lblBroken.Size = new System.Drawing.Size(150, 25);
            this.lblBroken.TabIndex = 1;
            this.lblBroken.Text = "- 고장 신고: 3건";
            // 
            // lblUsing
            // 
            this.lblUsing.AutoSize = true;
            this.lblUsing.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUsing.Location = new System.Drawing.Point(21, 74);
            this.lblUsing.Name = "lblUsing";
            this.lblUsing.Size = new System.Drawing.Size(124, 25);
            this.lblUsing.TabIndex = 0;
            this.lblUsing.Text = "- 사용중: 3대";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSettlement);
            this.groupBox2.Controls.Add(this.btnBrokenManage);
            this.groupBox2.Controls.Add(this.btnStats);
            this.groupBox2.Controls.Add(this.btnLocation);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(70, 298);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 267);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "빠른 이동 메뉴";
            // 
            // btnSettlement
            // 
            this.btnSettlement.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSettlement.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSettlement.Location = new System.Drawing.Point(234, 149);
            this.btnSettlement.Name = "btnSettlement";
            this.btnSettlement.Size = new System.Drawing.Size(187, 79);
            this.btnSettlement.TabIndex = 4;
            this.btnSettlement.Text = "정산 관리";
            this.btnSettlement.UseCompatibleTextRendering = true;
            this.btnSettlement.UseVisualStyleBackColor = false;
            this.btnSettlement.Click += new System.EventHandler(this.btnSettlement_Click);
            // 
            // btnBrokenManage
            // 
            this.btnBrokenManage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBrokenManage.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBrokenManage.Location = new System.Drawing.Point(25, 48);
            this.btnBrokenManage.Name = "btnBrokenManage";
            this.btnBrokenManage.Size = new System.Drawing.Size(187, 79);
            this.btnBrokenManage.TabIndex = 3;
            this.btnBrokenManage.Text = "고장신고 관리";
            this.btnBrokenManage.UseVisualStyleBackColor = false;
            this.btnBrokenManage.Click += new System.EventHandler(this.btnGoBroken_Click);
            // 
            // btnStats
            // 
            this.btnStats.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnStats.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStats.Location = new System.Drawing.Point(234, 48);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(187, 79);
            this.btnStats.TabIndex = 2;
            this.btnStats.Text = "통계 관리";
            this.btnStats.UseVisualStyleBackColor = false;
            this.btnStats.Click += new System.EventHandler(this.btnStats_Click);
            // 
            // btnLocation
            // 
            this.btnLocation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLocation.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLocation.Location = new System.Drawing.Point(25, 149);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Size = new System.Drawing.Size(187, 79);
            this.btnLocation.TabIndex = 1;
            this.btnLocation.Text = "위치 관리";
            this.btnLocation.UseCompatibleTextRendering = true;
            this.btnLocation.UseVisualStyleBackColor = false;
            this.btnLocation.Click += new System.EventHandler(this.btnGoLocation_Click);
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnReload.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReload.Location = new System.Drawing.Point(391, 230);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(127, 48);
            this.btnReload.TabIndex = 3;
            this.btnReload.Text = "새로고침";
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 598);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "관리자메인화면";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblBroken;
        private System.Windows.Forms.Label lblUsing;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnStats;
        private System.Windows.Forms.Button btnLocation;
        private System.Windows.Forms.Button btnBrokenManage;
        private System.Windows.Forms.Button btnSettlement;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Label lblWait;
        private System.Windows.Forms.Label lblDueToday;
        private System.Windows.Forms.Label lblLate;
    }
}

