namespace RAT.ControlPanel.Forms
{
    partial class frmSettings
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabServer = new System.Windows.Forms.TabPage();
            this.groupBoxServer = new System.Windows.Forms.GroupBox();
            this.txtListenIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numRefreshInterval = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numMaxClients = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tabLogging = new System.Windows.Forms.TabPage();
            this.groupBoxLogging = new System.Windows.Forms.GroupBox();
            this.btnBrowseLogPath = new System.Windows.Forms.Button();
            this.txtLogPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkEnableLogging = new System.Windows.Forms.CheckBox();
            this.tabUI = new System.Windows.Forms.TabPage();
            this.groupBoxUI = new System.Windows.Forms.GroupBox();
            this.chkEnableNotifications = new System.Windows.Forms.CheckBox();
            this.comboLanguage = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboTheme = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabConnection = new System.Windows.Forms.TabPage();
            this.groupBoxConnection = new System.Windows.Forms.GroupBox();
            this.numConnectionTimeout = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.chkAutoReconnect = new System.Windows.Forms.CheckBox();
            this.tabSecurity = new System.Windows.Forms.TabPage();
            this.groupBoxSecurity = new System.Windows.Forms.GroupBox();
            this.chkCompressionEnabled = new System.Windows.Forms.CheckBox();
            this.chkEnableEncryption = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabServer.SuspendLayout();
            this.groupBoxServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRefreshInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxClients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.tabLogging.SuspendLayout();
            this.groupBoxLogging.SuspendLayout();
            this.tabUI.SuspendLayout();
            this.groupBoxUI.SuspendLayout();
            this.tabConnection.SuspendLayout();
            this.groupBoxConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numConnectionTimeout)).BeginInit();
            this.tabSecurity.SuspendLayout();
            this.groupBoxSecurity.SuspendLayout();
            this.SuspendLayout();
            
            // tabControl1
            this.tabControl1.Controls.Add(this.tabServer);
            this.tabControl1.Controls.Add(this.tabLogging);
            this.tabControl1.Controls.Add(this.tabUI);
            this.tabControl1.Controls.Add(this.tabConnection);
            this.tabControl1.Controls.Add(this.tabSecurity);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(560, 350);
            this.tabControl1.TabIndex = 0;
            
            // tabServer
            this.tabServer.Controls.Add(this.groupBoxServer);
            this.tabServer.Location = new System.Drawing.Point(4, 24);
            this.tabServer.Name = "tabServer";
            this.tabServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabServer.Size = new System.Drawing.Size(552, 322);
            this.tabServer.TabIndex = 0;
            this.tabServer.Text = "Server";
            this.tabServer.UseVisualStyleBackColor = true;
            
            // groupBoxServer
            this.groupBoxServer.Controls.Add(this.txtListenIP);
            this.groupBoxServer.Controls.Add(this.label2);
            this.groupBoxServer.Controls.Add(this.numRefreshInterval);
            this.groupBoxServer.Controls.Add(this.label4);
            this.groupBoxServer.Controls.Add(this.numMaxClients);
            this.groupBoxServer.Controls.Add(this.label3);
            this.groupBoxServer.Controls.Add(this.chkAutoStart);
            this.groupBoxServer.Controls.Add(this.numPort);
            this.groupBoxServer.Controls.Add(this.label1);
            this.groupBoxServer.Location = new System.Drawing.Point(20, 20);
            this.groupBoxServer.Name = "groupBoxServer";
            this.groupBoxServer.Size = new System.Drawing.Size(512, 280);
            this.groupBoxServer.TabIndex = 0;
            this.groupBoxServer.TabStop = false;
            this.groupBoxServer.Text = "Server Settings";
            
            // numRefreshInterval
            this.numRefreshInterval.Location = new System.Drawing.Point(200, 120);
            this.numRefreshInterval.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numRefreshInterval.Minimum = new decimal(new int[] { 500, 0, 0, 0 });
            this.numRefreshInterval.Name = "numRefreshInterval";
            this.numRefreshInterval.Size = new System.Drawing.Size(120, 23);
            this.numRefreshInterval.TabIndex = 6;
            this.numRefreshInterval.Value = new decimal(new int[] { 2000, 0, 0, 0 });
            
            // label4
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Refresh Interval (ms):";
            
            // numMaxClients
            this.numMaxClients.Location = new System.Drawing.Point(200, 120);
            this.numMaxClients.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numMaxClients.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numMaxClients.Name = "numMaxClients";
            this.numMaxClients.Size = new System.Drawing.Size(120, 23);
            this.numMaxClients.TabIndex = 4;
            this.numMaxClients.Value = new decimal(new int[] { 100, 0, 0, 0 });
            
            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Max Clients:";
            
            // chkAutoStart
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.Location = new System.Drawing.Point(30, 160);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(200, 19);
            this.chkAutoStart.TabIndex = 2;
            this.chkAutoStart.Text = "Auto-start server on launch";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            
            // numPort
            this.numPort.Location = new System.Drawing.Point(200, 40);
            this.numPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            this.numPort.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(120, 23);
            this.numPort.TabIndex = 1;
            this.numPort.Value = new decimal(new int[] { 4444, 0, 0, 0 });
            
            // txtListenIP
            this.txtListenIP.Location = new System.Drawing.Point(200, 40);
            this.txtListenIP.Name = "txtListenIP";
            this.txtListenIP.Size = new System.Drawing.Size(200, 23);
            this.txtListenIP.TabIndex = 8;
            this.txtListenIP.Text = "0.0.0.0";
            
            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Listen IP:";
            
            // numPort
            this.numPort.Location = new System.Drawing.Point(200, 80);
            this.numPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            this.numPort.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(120, 23);
            this.numPort.TabIndex = 1;
            this.numPort.Value = new decimal(new int[] { 4444, 0, 0, 0 });
            
            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Port:";
            
            // tabLogging
            this.tabLogging.Controls.Add(this.groupBoxLogging);
            this.tabLogging.Location = new System.Drawing.Point(4, 24);
            this.tabLogging.Name = "tabLogging";
            this.tabLogging.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogging.Size = new System.Drawing.Size(552, 322);
            this.tabLogging.TabIndex = 1;
            this.tabLogging.Text = "Logging";
            this.tabLogging.UseVisualStyleBackColor = true;
            
            // groupBoxLogging
            this.groupBoxLogging.Controls.Add(this.btnBrowseLogPath);
            this.groupBoxLogging.Controls.Add(this.txtLogPath);
            this.groupBoxLogging.Controls.Add(this.label5);
            this.groupBoxLogging.Controls.Add(this.chkEnableLogging);
            this.groupBoxLogging.Location = new System.Drawing.Point(20, 20);
            this.groupBoxLogging.Name = "groupBoxLogging";
            this.groupBoxLogging.Size = new System.Drawing.Size(512, 280);
            this.groupBoxLogging.TabIndex = 0;
            this.groupBoxLogging.TabStop = false;
            this.groupBoxLogging.Text = "Logging Settings";
            
            // btnBrowseLogPath
            this.btnBrowseLogPath.Location = new System.Drawing.Point(420, 77);
            this.btnBrowseLogPath.Name = "btnBrowseLogPath";
            this.btnBrowseLogPath.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseLogPath.TabIndex = 3;
            this.btnBrowseLogPath.Text = "Browse...";
            this.btnBrowseLogPath.UseVisualStyleBackColor = true;
            this.btnBrowseLogPath.Click += new System.EventHandler(this.btnBrowseLogPath_Click);
            
            // txtLogPath
            this.txtLogPath.Location = new System.Drawing.Point(120, 78);
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.Size = new System.Drawing.Size(280, 23);
            this.txtLogPath.TabIndex = 2;
            
            // label5
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Log Path:";
            
            // chkEnableLogging
            this.chkEnableLogging.AutoSize = true;
            this.chkEnableLogging.Location = new System.Drawing.Point(30, 40);
            this.chkEnableLogging.Name = "chkEnableLogging";
            this.chkEnableLogging.Size = new System.Drawing.Size(120, 19);
            this.chkEnableLogging.TabIndex = 0;
            this.chkEnableLogging.Text = "Enable Logging";
            this.chkEnableLogging.UseVisualStyleBackColor = true;
            
            // tabUI
            this.tabUI.Controls.Add(this.groupBoxUI);
            this.tabUI.Location = new System.Drawing.Point(4, 24);
            this.tabUI.Name = "tabUI";
            this.tabUI.Size = new System.Drawing.Size(552, 322);
            this.tabUI.TabIndex = 2;
            this.tabUI.Text = "UI";
            this.tabUI.UseVisualStyleBackColor = true;
            
            // groupBoxUI
            this.groupBoxUI.Controls.Add(this.chkEnableNotifications);
            this.groupBoxUI.Controls.Add(this.comboLanguage);
            this.groupBoxUI.Controls.Add(this.label8);
            this.groupBoxUI.Controls.Add(this.comboTheme);
            this.groupBoxUI.Controls.Add(this.label6);
            this.groupBoxUI.Location = new System.Drawing.Point(20, 20);
            this.groupBoxUI.Name = "groupBoxUI";
            this.groupBoxUI.Size = new System.Drawing.Size(512, 280);
            this.groupBoxUI.TabIndex = 0;
            this.groupBoxUI.TabStop = false;
            this.groupBoxUI.Text = "UI Settings";
            
            // chkEnableNotifications
            this.chkEnableNotifications.AutoSize = true;
            this.chkEnableNotifications.Location = new System.Drawing.Point(30, 120);
            this.chkEnableNotifications.Name = "chkEnableNotifications";
            this.chkEnableNotifications.Size = new System.Drawing.Size(140, 19);
            this.chkEnableNotifications.TabIndex = 4;
            this.chkEnableNotifications.Text = "Enable Notifications";
            this.chkEnableNotifications.UseVisualStyleBackColor = true;
            
            // comboLanguage
            this.comboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLanguage.FormattingEnabled = true;
            this.comboLanguage.Items.AddRange(new object[] { "English", "한국어" });
            this.comboLanguage.Location = new System.Drawing.Point(120, 80);
            this.comboLanguage.Name = "comboLanguage";
            this.comboLanguage.Size = new System.Drawing.Size(150, 23);
            this.comboLanguage.TabIndex = 3;
            
            // label8
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "Language:";
            
            // comboTheme
            this.comboTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTheme.FormattingEnabled = true;
            this.comboTheme.Items.AddRange(new object[] { "Dark", "Light" });
            this.comboTheme.Location = new System.Drawing.Point(120, 40);
            this.comboTheme.Name = "comboTheme";
            this.comboTheme.Size = new System.Drawing.Size(150, 23);
            this.comboTheme.TabIndex = 1;
            
            // label6
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Theme:";
            
            // tabConnection
            this.tabConnection.Controls.Add(this.groupBoxConnection);
            this.tabConnection.Location = new System.Drawing.Point(4, 24);
            this.tabConnection.Name = "tabConnection";
            this.tabConnection.Size = new System.Drawing.Size(552, 322);
            this.tabConnection.TabIndex = 3;
            this.tabConnection.Text = "Connection";
            this.tabConnection.UseVisualStyleBackColor = true;
            
            // groupBoxConnection
            this.groupBoxConnection.Controls.Add(this.numConnectionTimeout);
            this.groupBoxConnection.Controls.Add(this.label7);
            this.groupBoxConnection.Controls.Add(this.chkAutoReconnect);
            this.groupBoxConnection.Location = new System.Drawing.Point(20, 20);
            this.groupBoxConnection.Name = "groupBoxConnection";
            this.groupBoxConnection.Size = new System.Drawing.Size(512, 280);
            this.groupBoxConnection.TabIndex = 0;
            this.groupBoxConnection.TabStop = false;
            this.groupBoxConnection.Text = "Connection Settings";
            
            // numConnectionTimeout
            this.numConnectionTimeout.Location = new System.Drawing.Point(200, 80);
            this.numConnectionTimeout.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            this.numConnectionTimeout.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            this.numConnectionTimeout.Name = "numConnectionTimeout";
            this.numConnectionTimeout.Size = new System.Drawing.Size(120, 23);
            this.numConnectionTimeout.TabIndex = 2;
            this.numConnectionTimeout.Value = new decimal(new int[] { 30, 0, 0, 0 });
            
            // label7
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Connection Timeout (s):";
            
            // chkAutoReconnect
            this.chkAutoReconnect.AutoSize = true;
            this.chkAutoReconnect.Location = new System.Drawing.Point(30, 40);
            this.chkAutoReconnect.Name = "chkAutoReconnect";
            this.chkAutoReconnect.Size = new System.Drawing.Size(180, 19);
            this.chkAutoReconnect.TabIndex = 0;
            this.chkAutoReconnect.Text = "Auto-reconnect on disconnect";
            this.chkAutoReconnect.UseVisualStyleBackColor = true;
            
            // tabSecurity
            this.tabSecurity.Controls.Add(this.groupBoxSecurity);
            this.tabSecurity.Location = new System.Drawing.Point(4, 24);
            this.tabSecurity.Name = "tabSecurity";
            this.tabSecurity.Size = new System.Drawing.Size(552, 322);
            this.tabSecurity.TabIndex = 4;
            this.tabSecurity.Text = "Security";
            this.tabSecurity.UseVisualStyleBackColor = true;
            
            // groupBoxSecurity
            this.groupBoxSecurity.Controls.Add(this.chkCompressionEnabled);
            this.groupBoxSecurity.Controls.Add(this.chkEnableEncryption);
            this.groupBoxSecurity.Location = new System.Drawing.Point(20, 20);
            this.groupBoxSecurity.Name = "groupBoxSecurity";
            this.groupBoxSecurity.Size = new System.Drawing.Size(512, 280);
            this.groupBoxSecurity.TabIndex = 0;
            this.groupBoxSecurity.TabStop = false;
            this.groupBoxSecurity.Text = "Security Settings";
            
            // chkCompressionEnabled
            this.chkCompressionEnabled.AutoSize = true;
            this.chkCompressionEnabled.Location = new System.Drawing.Point(30, 80);
            this.chkCompressionEnabled.Name = "chkCompressionEnabled";
            this.chkCompressionEnabled.Size = new System.Drawing.Size(180, 19);
            this.chkCompressionEnabled.TabIndex = 1;
            this.chkCompressionEnabled.Text = "Enable Data Compression";
            this.chkCompressionEnabled.UseVisualStyleBackColor = true;
            
            // chkEnableEncryption
            this.chkEnableEncryption.AutoSize = true;
            this.chkEnableEncryption.Location = new System.Drawing.Point(30, 40);
            this.chkEnableEncryption.Name = "chkEnableEncryption";
            this.chkEnableEncryption.Size = new System.Drawing.Size(180, 19);
            this.chkEnableEncryption.TabIndex = 0;
            this.chkEnableEncryption.Text = "Enable Encryption (AES-256)";
            this.chkEnableEncryption.UseVisualStyleBackColor = true;
            
            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.LightGreen;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(300, 375);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            
            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(420, 375);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            
            // btnReset
            this.btnReset.Location = new System.Drawing.Point(60, 375);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 35);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            
            // frmSettings
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 421);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabServer.ResumeLayout(false);
            this.groupBoxServer.ResumeLayout(false);
            this.groupBoxServer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRefreshInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.tabLogging.ResumeLayout(false);
            this.groupBoxLogging.ResumeLayout(false);
            this.groupBoxLogging.PerformLayout();
            this.tabUI.ResumeLayout(false);
            this.groupBoxUI.ResumeLayout(false);
            this.groupBoxUI.PerformLayout();
            this.tabConnection.ResumeLayout(false);
            this.groupBoxConnection.ResumeLayout(false);
            this.groupBoxConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numConnectionTimeout)).EndInit();
            this.tabSecurity.ResumeLayout(false);
            this.groupBoxSecurity.ResumeLayout(false);
            this.groupBoxSecurity.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabServer;
        private System.Windows.Forms.GroupBox groupBoxServer;
        private System.Windows.Forms.TextBox txtListenIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private System.Windows.Forms.NumericUpDown numMaxClients;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numRefreshInterval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabLogging;
        private System.Windows.Forms.GroupBox groupBoxLogging;
        private System.Windows.Forms.CheckBox chkEnableLogging;
        private System.Windows.Forms.TextBox txtLogPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBrowseLogPath;
        private System.Windows.Forms.TabPage tabUI;
        private System.Windows.Forms.GroupBox groupBoxUI;
        private System.Windows.Forms.ComboBox comboTheme;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkEnableNotifications;
        private System.Windows.Forms.ComboBox comboLanguage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabConnection;
        private System.Windows.Forms.GroupBox groupBoxConnection;
        private System.Windows.Forms.CheckBox chkAutoReconnect;
        private System.Windows.Forms.NumericUpDown numConnectionTimeout;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabSecurity;
        private System.Windows.Forms.GroupBox groupBoxSecurity;
        private System.Windows.Forms.CheckBox chkEnableEncryption;
        private System.Windows.Forms.CheckBox chkCompressionEnabled;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnReset;
    }
}
