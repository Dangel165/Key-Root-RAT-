namespace RAT.ControlPanel.Forms
{
    partial class frmMultiRunScript
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
            this.groupBoxScript = new System.Windows.Forms.GroupBox();
            this.btnLoadTemplate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtScript = new System.Windows.Forms.TextBox();
            this.comboScriptType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxClients = new System.Windows.Forms.GroupBox();
            this.listViewClients = new System.Windows.Forms.ListView();
            this.colIndex = new System.Windows.Forms.ColumnHeader();
            this.colClientId = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.colResult = new System.Windows.Forms.ColumnHeader();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnUncheckAll = new System.Windows.Forms.Button();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBoxScript.SuspendLayout();
            this.groupBoxClients.SuspendLayout();
            this.groupBoxActions.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            
            // groupBoxScript
            this.groupBoxScript.Controls.Add(this.btnLoadTemplate);
            this.groupBoxScript.Controls.Add(this.btnClear);
            this.groupBoxScript.Controls.Add(this.txtScript);
            this.groupBoxScript.Controls.Add(this.comboScriptType);
            this.groupBoxScript.Controls.Add(this.label1);
            this.groupBoxScript.Location = new System.Drawing.Point(12, 12);
            this.groupBoxScript.Name = "groupBoxScript";
            this.groupBoxScript.Size = new System.Drawing.Size(860, 250);
            this.groupBoxScript.TabIndex = 0;
            this.groupBoxScript.TabStop = false;
            this.groupBoxScript.Text = "Script";
            
            // btnLoadTemplate
            this.btnLoadTemplate.Location = new System.Drawing.Point(750, 25);
            this.btnLoadTemplate.Name = "btnLoadTemplate";
            this.btnLoadTemplate.Size = new System.Drawing.Size(100, 25);
            this.btnLoadTemplate.TabIndex = 4;
            this.btnLoadTemplate.Text = "Load Template";
            this.btnLoadTemplate.UseVisualStyleBackColor = true;
            this.btnLoadTemplate.Click += new System.EventHandler(this.btnLoadTemplate_Click);
            
            // btnClear
            this.btnClear.Location = new System.Drawing.Point(650, 25);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 25);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            
            // txtScript
            this.txtScript.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtScript.Location = new System.Drawing.Point(20, 60);
            this.txtScript.Multiline = true;
            this.txtScript.Name = "txtScript";
            this.txtScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtScript.Size = new System.Drawing.Size(830, 175);
            this.txtScript.TabIndex = 2;
            this.txtScript.WordWrap = false;
            
            // comboScriptType
            this.comboScriptType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboScriptType.FormattingEnabled = true;
            this.comboScriptType.Items.AddRange(new object[] {
                "PowerShell",
                "Batch",
                "VBScript"});
            this.comboScriptType.Location = new System.Drawing.Point(100, 27);
            this.comboScriptType.Name = "comboScriptType";
            this.comboScriptType.Size = new System.Drawing.Size(150, 23);
            this.comboScriptType.TabIndex = 1;
            
            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Script Type:";
            
            // groupBoxClients
            this.groupBoxClients.Controls.Add(this.listViewClients);
            this.groupBoxClients.Location = new System.Drawing.Point(12, 270);
            this.groupBoxClients.Name = "groupBoxClients";
            this.groupBoxClients.Size = new System.Drawing.Size(860, 250);
            this.groupBoxClients.TabIndex = 1;
            this.groupBoxClients.TabStop = false;
            this.groupBoxClients.Text = "Clients";
            
            // listViewClients
            this.listViewClients.CheckBoxes = true;
            this.listViewClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colIndex,
                this.colClientId,
                this.colStatus,
                this.colResult});
            this.listViewClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewClients.FullRowSelect = true;
            this.listViewClients.Location = new System.Drawing.Point(3, 19);
            this.listViewClients.Name = "listViewClients";
            this.listViewClients.Size = new System.Drawing.Size(854, 228);
            this.listViewClients.TabIndex = 0;
            this.listViewClients.UseCompatibleStateImageBehavior = false;
            this.listViewClients.View = System.Windows.Forms.View.Details;
            
            // colIndex
            this.colIndex.Text = "#";
            this.colIndex.Width = 50;
            
            // colClientId
            this.colClientId.Text = "Client ID";
            this.colClientId.Width = 350;
            
            // colStatus
            this.colStatus.Text = "Status";
            this.colStatus.Width = 150;
            
            // colResult
            this.colResult.Text = "Result";
            this.colResult.Width = 250;
            
            // groupBoxActions
            this.groupBoxActions.Controls.Add(this.progressBar);
            this.groupBoxActions.Controls.Add(this.btnExecute);
            this.groupBoxActions.Controls.Add(this.btnUncheckAll);
            this.groupBoxActions.Controls.Add(this.btnCheckAll);
            this.groupBoxActions.Location = new System.Drawing.Point(12, 530);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Size = new System.Drawing.Size(860, 90);
            this.groupBoxActions.TabIndex = 2;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Actions";
            
            // progressBar
            this.progressBar.Location = new System.Drawing.Point(20, 55);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(830, 23);
            this.progressBar.TabIndex = 3;
            
            // btnExecute
            this.btnExecute.BackColor = System.Drawing.Color.LightGreen;
            this.btnExecute.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExecute.Location = new System.Drawing.Point(260, 20);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(120, 30);
            this.btnExecute.TabIndex = 2;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = false;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            
            // btnUncheckAll
            this.btnUncheckAll.Location = new System.Drawing.Point(140, 20);
            this.btnUncheckAll.Name = "btnUncheckAll";
            this.btnUncheckAll.Size = new System.Drawing.Size(100, 30);
            this.btnUncheckAll.TabIndex = 1;
            this.btnUncheckAll.Text = "Uncheck All";
            this.btnUncheckAll.UseVisualStyleBackColor = true;
            this.btnUncheckAll.Click += new System.EventHandler(this.btnUncheckAll_Click);
            
            // btnCheckAll
            this.btnCheckAll.Location = new System.Drawing.Point(20, 20);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(100, 30);
            this.btnCheckAll.TabIndex = 0;
            this.btnCheckAll.Text = "Check All";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            
            // statusStrip1
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 628);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(884, 22);
            this.statusStrip1.TabIndex = 3;
            
            // lblStatus
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 17);
            this.lblStatus.Text = "Clients: 0";
            
            // frmMultiRunScript
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 650);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBoxActions);
            this.Controls.Add(this.groupBoxClients);
            this.Controls.Add(this.groupBoxScript);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmMultiRunScript";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multi Run Script";
            this.Load += new System.EventHandler(this.frmMultiRunScript_Load);
            this.groupBoxScript.ResumeLayout(false);
            this.groupBoxScript.PerformLayout();
            this.groupBoxClients.ResumeLayout(false);
            this.groupBoxActions.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.GroupBox groupBoxScript;
        private System.Windows.Forms.Button btnLoadTemplate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtScript;
        private System.Windows.Forms.ComboBox comboScriptType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxClients;
        private System.Windows.Forms.ListView listViewClients;
        private System.Windows.Forms.ColumnHeader colIndex;
        private System.Windows.Forms.ColumnHeader colClientId;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colResult;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnUncheckAll;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}
