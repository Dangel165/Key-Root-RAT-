namespace RAT.ControlPanel.Forms
{
    partial class frmBuilder
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
            this.groupBoxConnection = new System.Windows.Forms.GroupBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxOutput = new System.Windows.Forms.GroupBox();
            this.btnSelectIcon = new System.Windows.Forms.Button();
            this.txtIconPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.chkObfuscate = new System.Windows.Forms.CheckBox();
            this.chkPersistence = new System.Windows.Forms.CheckBox();
            this.chkAntiDebug = new System.Windows.Forms.CheckBox();
            this.chkAntiVM = new System.Windows.Forms.CheckBox();
            this.chkMelt = new System.Windows.Forms.CheckBox();
            this.comboStartupMethod = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkHideFile = new System.Windows.Forms.CheckBox();
            this.chkStartup = new System.Windows.Forms.CheckBox();
            this.groupBoxBuildOutput = new System.Windows.Forms.GroupBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnBuild = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBoxConnection.SuspendLayout();
            this.groupBoxOutput.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            this.groupBoxBuildOutput.SuspendLayout();
            this.SuspendLayout();
            
            // groupBoxConnection
            this.groupBoxConnection.Controls.Add(this.txtPort);
            this.groupBoxConnection.Controls.Add(this.label2);
            this.groupBoxConnection.Controls.Add(this.txtHost);
            this.groupBoxConnection.Controls.Add(this.label1);
            this.groupBoxConnection.Location = new System.Drawing.Point(12, 12);
            this.groupBoxConnection.Name = "groupBoxConnection";
            this.groupBoxConnection.Size = new System.Drawing.Size(360, 100);
            this.groupBoxConnection.TabIndex = 0;
            this.groupBoxConnection.TabStop = false;
            this.groupBoxConnection.Text = "Connection";
            
            // txtPort
            this.txtPort.Location = new System.Drawing.Point(100, 60);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(240, 23);
            this.txtPort.TabIndex = 3;
            
            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            
            // txtHost
            this.txtHost.Location = new System.Drawing.Point(100, 30);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(240, 23);
            this.txtHost.TabIndex = 1;
            
            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host:";
            
            // groupBoxOutput
            this.groupBoxOutput.Controls.Add(this.btnSelectIcon);
            this.groupBoxOutput.Controls.Add(this.txtIconPath);
            this.groupBoxOutput.Controls.Add(this.label4);
            this.groupBoxOutput.Controls.Add(this.txtFileName);
            this.groupBoxOutput.Controls.Add(this.label3);
            this.groupBoxOutput.Location = new System.Drawing.Point(12, 120);
            this.groupBoxOutput.Name = "groupBoxOutput";
            this.groupBoxOutput.Size = new System.Drawing.Size(360, 120);
            this.groupBoxOutput.TabIndex = 1;
            this.groupBoxOutput.TabStop = false;
            this.groupBoxOutput.Text = "Output";
            
            // btnSelectIcon
            this.btnSelectIcon.Location = new System.Drawing.Point(265, 77);
            this.btnSelectIcon.Name = "btnSelectIcon";
            this.btnSelectIcon.Size = new System.Drawing.Size(75, 23);
            this.btnSelectIcon.TabIndex = 4;
            this.btnSelectIcon.Text = "Browse...";
            this.btnSelectIcon.UseVisualStyleBackColor = true;
            this.btnSelectIcon.Click += new System.EventHandler(this.btnSelectIcon_Click);
            
            // txtIconPath
            this.txtIconPath.Location = new System.Drawing.Point(100, 78);
            this.txtIconPath.Name = "txtIconPath";
            this.txtIconPath.ReadOnly = true;
            this.txtIconPath.Size = new System.Drawing.Size(150, 23);
            this.txtIconPath.TabIndex = 3;
            
            // label4
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Icon:";
            
            // txtFileName
            this.txtFileName.Location = new System.Drawing.Point(100, 40);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(240, 23);
            this.txtFileName.TabIndex = 1;
            
            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "File Name:";
            
            // groupBoxOptions
            this.groupBoxOptions.Controls.Add(this.chkObfuscate);
            this.groupBoxOptions.Controls.Add(this.chkPersistence);
            this.groupBoxOptions.Controls.Add(this.chkAntiDebug);
            this.groupBoxOptions.Controls.Add(this.chkAntiVM);
            this.groupBoxOptions.Controls.Add(this.chkMelt);
            this.groupBoxOptions.Controls.Add(this.comboStartupMethod);
            this.groupBoxOptions.Controls.Add(this.label5);
            this.groupBoxOptions.Controls.Add(this.chkHideFile);
            this.groupBoxOptions.Controls.Add(this.chkStartup);
            this.groupBoxOptions.Location = new System.Drawing.Point(390, 12);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(360, 228);
            this.groupBoxOptions.TabIndex = 2;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Options";
            
            // chkObfuscate
            this.chkObfuscate.AutoSize = true;
            this.chkObfuscate.Location = new System.Drawing.Point(20, 190);
            this.chkObfuscate.Name = "chkObfuscate";
            this.chkObfuscate.Size = new System.Drawing.Size(80, 19);
            this.chkObfuscate.TabIndex = 8;
            this.chkObfuscate.Text = "Obfuscate";
            this.chkObfuscate.UseVisualStyleBackColor = true;
            
            // chkPersistence
            this.chkPersistence.AutoSize = true;
            this.chkPersistence.Location = new System.Drawing.Point(20, 160);
            this.chkPersistence.Name = "chkPersistence";
            this.chkPersistence.Size = new System.Drawing.Size(85, 19);
            this.chkPersistence.TabIndex = 7;
            this.chkPersistence.Text = "Persistence";
            this.chkPersistence.UseVisualStyleBackColor = true;
            
            // chkAntiDebug
            this.chkAntiDebug.AutoSize = true;
            this.chkAntiDebug.Location = new System.Drawing.Point(20, 130);
            this.chkAntiDebug.Name = "chkAntiDebug";
            this.chkAntiDebug.Size = new System.Drawing.Size(90, 19);
            this.chkAntiDebug.TabIndex = 6;
            this.chkAntiDebug.Text = "Anti-Debug";
            this.chkAntiDebug.UseVisualStyleBackColor = true;
            
            // chkAntiVM
            this.chkAntiVM.AutoSize = true;
            this.chkAntiVM.Location = new System.Drawing.Point(20, 100);
            this.chkAntiVM.Name = "chkAntiVM";
            this.chkAntiVM.Size = new System.Drawing.Size(75, 19);
            this.chkAntiVM.TabIndex = 5;
            this.chkAntiVM.Text = "Anti-VM";
            this.chkAntiVM.UseVisualStyleBackColor = true;
            
            // chkMelt
            this.chkMelt.AutoSize = true;
            this.chkMelt.Location = new System.Drawing.Point(200, 70);
            this.chkMelt.Name = "chkMelt";
            this.chkMelt.Size = new System.Drawing.Size(50, 19);
            this.chkMelt.TabIndex = 4;
            this.chkMelt.Text = "Melt";
            this.chkMelt.UseVisualStyleBackColor = true;
            
            // comboStartupMethod
            this.comboStartupMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStartupMethod.FormattingEnabled = true;
            this.comboStartupMethod.Items.AddRange(new object[] {
                "Registry (HKCU)",
                "Registry (HKLM)",
                "Startup Folder",
                "Task Scheduler"});
            this.comboStartupMethod.Location = new System.Drawing.Point(140, 38);
            this.comboStartupMethod.Name = "comboStartupMethod";
            this.comboStartupMethod.Size = new System.Drawing.Size(200, 23);
            this.comboStartupMethod.TabIndex = 3;
            
            // label5
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Startup Method:";
            
            // chkHideFile
            this.chkHideFile.AutoSize = true;
            this.chkHideFile.Location = new System.Drawing.Point(20, 70);
            this.chkHideFile.Name = "chkHideFile";
            this.chkHideFile.Size = new System.Drawing.Size(75, 19);
            this.chkHideFile.TabIndex = 1;
            this.chkHideFile.Text = "Hide File";
            this.chkHideFile.UseVisualStyleBackColor = true;
            
            // chkStartup
            this.chkStartup.AutoSize = true;
            this.chkStartup.Location = new System.Drawing.Point(20, 20);
            this.chkStartup.Name = "chkStartup";
            this.chkStartup.Size = new System.Drawing.Size(100, 19);
            this.chkStartup.TabIndex = 0;
            this.chkStartup.Text = "Add to Startup";
            this.chkStartup.UseVisualStyleBackColor = true;
            
            // groupBoxBuildOutput
            this.groupBoxBuildOutput.Controls.Add(this.txtOutput);
            this.groupBoxBuildOutput.Location = new System.Drawing.Point(12, 250);
            this.groupBoxBuildOutput.Name = "groupBoxBuildOutput";
            this.groupBoxBuildOutput.Size = new System.Drawing.Size(738, 250);
            this.groupBoxBuildOutput.TabIndex = 3;
            this.groupBoxBuildOutput.TabStop = false;
            this.groupBoxBuildOutput.Text = "Build Output";
            
            // txtOutput
            this.txtOutput.BackColor = System.Drawing.Color.Black;
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtOutput.ForeColor = System.Drawing.Color.Lime;
            this.txtOutput.Location = new System.Drawing.Point(3, 19);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(732, 228);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.WordWrap = false;
            
            // progressBar
            this.progressBar.Location = new System.Drawing.Point(12, 510);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(738, 23);
            this.progressBar.TabIndex = 4;
            
            // btnBuild
            this.btnBuild.BackColor = System.Drawing.Color.LightGreen;
            this.btnBuild.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBuild.Location = new System.Drawing.Point(550, 545);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(120, 40);
            this.btnBuild.TabIndex = 5;
            this.btnBuild.Text = "Build";
            this.btnBuild.UseVisualStyleBackColor = false;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            
            // btnReset
            this.btnReset.Location = new System.Drawing.Point(80, 545);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 40);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            
            // frmBuilder
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 597);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnBuild);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBoxBuildOutput);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.groupBoxOutput);
            this.Controls.Add(this.groupBoxConnection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmBuilder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client Builder";
            this.Load += new System.EventHandler(this.frmBuilder_Load);
            this.groupBoxConnection.ResumeLayout(false);
            this.groupBoxConnection.PerformLayout();
            this.groupBoxOutput.ResumeLayout(false);
            this.groupBoxOutput.PerformLayout();
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.groupBoxBuildOutput.ResumeLayout(false);
            this.groupBoxBuildOutput.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox groupBoxConnection;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxOutput;
        private System.Windows.Forms.Button btnSelectIcon;
        private System.Windows.Forms.TextBox txtIconPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.CheckBox chkObfuscate;
        private System.Windows.Forms.CheckBox chkPersistence;
        private System.Windows.Forms.CheckBox chkAntiDebug;
        private System.Windows.Forms.CheckBox chkAntiVM;
        private System.Windows.Forms.CheckBox chkMelt;
        private System.Windows.Forms.ComboBox comboStartupMethod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkHideFile;
        private System.Windows.Forms.CheckBox chkStartup;
        private System.Windows.Forms.GroupBox groupBoxBuildOutput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.Button btnReset;
    }
}
