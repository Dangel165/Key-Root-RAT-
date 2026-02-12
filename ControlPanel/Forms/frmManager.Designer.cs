namespace RAT.ControlPanel.Forms
{
    partial class frmManager
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
            this.tabFileManager = new System.Windows.Forms.TabPage();
            this.listViewFiles = new System.Windows.Forms.ListView();
            this.colFileName = new System.Windows.Forms.ColumnHeader();
            this.colFileSize = new System.Windows.Forms.ColumnHeader();
            this.colFileModified = new System.Windows.Forms.ColumnHeader();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFileRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnFileDownload = new System.Windows.Forms.ToolStripButton();
            this.btnFileDelete = new System.Windows.Forms.ToolStripButton();
            this.btnFileExecute = new System.Windows.Forms.ToolStripButton();
            this.tabProcessManager = new System.Windows.Forms.TabPage();
            this.listViewProcesses = new System.Windows.Forms.ListView();
            this.colProcessName = new System.Windows.Forms.ColumnHeader();
            this.colProcessPID = new System.Windows.Forms.ColumnHeader();
            this.colProcessMemory = new System.Windows.Forms.ColumnHeader();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnProcessRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnProcessKill = new System.Windows.Forms.ToolStripButton();
            this.tabRegistryEditor = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewRegistry = new System.Windows.Forms.TreeView();
            this.listViewRegistry = new System.Windows.Forms.ListView();
            this.colRegName = new System.Windows.Forms.ColumnHeader();
            this.colRegType = new System.Windows.Forms.ColumnHeader();
            this.colRegValue = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRegistryDelete = new System.Windows.Forms.Button();
            this.btnRegistryWrite = new System.Windows.Forms.Button();
            this.txtRegistryValue = new System.Windows.Forms.TextBox();
            this.txtRegistryName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabServiceManager = new System.Windows.Forms.TabPage();
            this.listViewServices = new System.Windows.Forms.ListView();
            this.colServiceName = new System.Windows.Forms.ColumnHeader();
            this.colServiceDisplay = new System.Windows.Forms.ColumnHeader();
            this.colServiceStatus = new System.Windows.Forms.ColumnHeader();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.btnServiceRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnServiceStart = new System.Windows.Forms.ToolStripButton();
            this.btnServiceStop = new System.Windows.Forms.ToolStripButton();
            
            this.tabControl1.SuspendLayout();
            this.tabFileManager.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabProcessManager.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabRegistryEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabServiceManager.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.SuspendLayout();
            
            // tabControl1
            this.tabControl1.Controls.Add(this.tabFileManager);
            this.tabControl1.Controls.Add(this.tabProcessManager);
            this.tabControl1.Controls.Add(this.tabRegistryEditor);
            this.tabControl1.Controls.Add(this.tabServiceManager);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1000, 600);
            this.tabControl1.TabIndex = 0;
            
            // tabFileManager
            this.tabFileManager.Controls.Add(this.listViewFiles);
            this.tabFileManager.Controls.Add(this.toolStrip1);
            this.tabFileManager.Location = new System.Drawing.Point(4, 24);
            this.tabFileManager.Name = "tabFileManager";
            this.tabFileManager.Padding = new System.Windows.Forms.Padding(3);
            this.tabFileManager.Size = new System.Drawing.Size(992, 572);
            this.tabFileManager.TabIndex = 0;
            this.tabFileManager.Text = "File Manager";
            this.tabFileManager.UseVisualStyleBackColor = true;
            
            // listViewFiles
            this.listViewFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colFileName,
                this.colFileSize,
                this.colFileModified});
            this.listViewFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFiles.FullRowSelect = true;
            this.listViewFiles.Location = new System.Drawing.Point(3, 28);
            this.listViewFiles.Name = "listViewFiles";
            this.listViewFiles.Size = new System.Drawing.Size(986, 541);
            this.listViewFiles.TabIndex = 1;
            this.listViewFiles.UseCompatibleStateImageBehavior = false;
            this.listViewFiles.View = System.Windows.Forms.View.Details;
            
            this.colFileName.Text = "Name";
            this.colFileName.Width = 400;
            this.colFileSize.Text = "Size";
            this.colFileSize.Width = 150;
            this.colFileModified.Text = "Modified";
            this.colFileModified.Width = 200;
            
            // toolStrip1
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.btnFileRefresh,
                this.btnFileDownload,
                this.btnFileDelete,
                this.btnFileExecute});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(986, 25);
            this.toolStrip1.TabIndex = 0;
            
            this.btnFileRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFileRefresh.Name = "btnFileRefresh";
            this.btnFileRefresh.Size = new System.Drawing.Size(50, 22);
            this.btnFileRefresh.Text = "Refresh";
            this.btnFileRefresh.Click += new System.EventHandler(this.btnFileRefresh_Click);
            
            this.btnFileDownload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFileDownload.Name = "btnFileDownload";
            this.btnFileDownload.Size = new System.Drawing.Size(65, 22);
            this.btnFileDownload.Text = "Download";
            this.btnFileDownload.Click += new System.EventHandler(this.btnFileDownload_Click);
            
            this.btnFileDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFileDelete.Name = "btnFileDelete";
            this.btnFileDelete.Size = new System.Drawing.Size(45, 22);
            this.btnFileDelete.Text = "Delete";
            this.btnFileDelete.Click += new System.EventHandler(this.btnFileDelete_Click);
            
            this.btnFileExecute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFileExecute.Name = "btnFileExecute";
            this.btnFileExecute.Size = new System.Drawing.Size(52, 22);
            this.btnFileExecute.Text = "Execute";
            this.btnFileExecute.Click += new System.EventHandler(this.btnFileExecute_Click);
            
            // tabProcessManager
            this.tabProcessManager.Controls.Add(this.listViewProcesses);
            this.tabProcessManager.Controls.Add(this.toolStrip2);
            this.tabProcessManager.Location = new System.Drawing.Point(4, 24);
            this.tabProcessManager.Name = "tabProcessManager";
            this.tabProcessManager.Padding = new System.Windows.Forms.Padding(3);
            this.tabProcessManager.Size = new System.Drawing.Size(992, 572);
            this.tabProcessManager.TabIndex = 1;
            this.tabProcessManager.Text = "Process Manager";
            this.tabProcessManager.UseVisualStyleBackColor = true;
            
            // listViewProcesses
            this.listViewProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colProcessName,
                this.colProcessPID,
                this.colProcessMemory});
            this.listViewProcesses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewProcesses.FullRowSelect = true;
            this.listViewProcesses.Location = new System.Drawing.Point(3, 28);
            this.listViewProcesses.Name = "listViewProcesses";
            this.listViewProcesses.Size = new System.Drawing.Size(986, 541);
            this.listViewProcesses.TabIndex = 1;
            this.listViewProcesses.UseCompatibleStateImageBehavior = false;
            this.listViewProcesses.View = System.Windows.Forms.View.Details;
            
            this.colProcessName.Text = "Name";
            this.colProcessName.Width = 300;
            this.colProcessPID.Text = "PID";
            this.colProcessPID.Width = 100;
            this.colProcessMemory.Text = "Memory";
            this.colProcessMemory.Width = 150;
            
            // toolStrip2
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.btnProcessRefresh,
                this.btnProcessKill});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(986, 25);
            this.toolStrip2.TabIndex = 0;
            
            this.btnProcessRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnProcessRefresh.Name = "btnProcessRefresh";
            this.btnProcessRefresh.Size = new System.Drawing.Size(50, 22);
            this.btnProcessRefresh.Text = "Refresh";
            this.btnProcessRefresh.Click += new System.EventHandler(this.btnProcessRefresh_Click);
            
            this.btnProcessKill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnProcessKill.Name = "btnProcessKill";
            this.btnProcessKill.Size = new System.Drawing.Size(30, 22);
            this.btnProcessKill.Text = "Kill";
            this.btnProcessKill.Click += new System.EventHandler(this.btnProcessKill_Click);
            
            // tabRegistryEditor
            this.tabRegistryEditor.Controls.Add(this.splitContainer1);
            this.tabRegistryEditor.Location = new System.Drawing.Point(4, 24);
            this.tabRegistryEditor.Name = "tabRegistryEditor";
            this.tabRegistryEditor.Size = new System.Drawing.Size(992, 572);
            this.tabRegistryEditor.TabIndex = 2;
            this.tabRegistryEditor.Text = "Registry Editor";
            this.tabRegistryEditor.UseVisualStyleBackColor = true;
            
            // splitContainer1
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1.Controls.Add(this.treeViewRegistry);
            this.splitContainer1.Panel2.Controls.Add(this.listViewRegistry);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(992, 572);
            this.splitContainer1.SplitterDistance = 330;
            this.splitContainer1.TabIndex = 0;
            
            // treeViewRegistry
            this.treeViewRegistry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewRegistry.Location = new System.Drawing.Point(0, 0);
            this.treeViewRegistry.Name = "treeViewRegistry";
            this.treeViewRegistry.Size = new System.Drawing.Size(330, 572);
            this.treeViewRegistry.TabIndex = 0;
            this.treeViewRegistry.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewRegistry_AfterSelect);
            
            // listViewRegistry
            this.listViewRegistry.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colRegName,
                this.colRegType,
                this.colRegValue});
            this.listViewRegistry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewRegistry.FullRowSelect = true;
            this.listViewRegistry.Location = new System.Drawing.Point(0, 0);
            this.listViewRegistry.Name = "listViewRegistry";
            this.listViewRegistry.Size = new System.Drawing.Size(658, 472);
            this.listViewRegistry.TabIndex = 1;
            this.listViewRegistry.UseCompatibleStateImageBehavior = false;
            this.listViewRegistry.View = System.Windows.Forms.View.Details;
            
            this.colRegName.Text = "Name";
            this.colRegName.Width = 200;
            this.colRegType.Text = "Type";
            this.colRegType.Width = 100;
            this.colRegValue.Text = "Value";
            this.colRegValue.Width = 300;
            
            // panel1
            this.panel1.Controls.Add(this.btnRegistryDelete);
            this.panel1.Controls.Add(this.btnRegistryWrite);
            this.panel1.Controls.Add(this.txtRegistryValue);
            this.panel1.Controls.Add(this.txtRegistryName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 472);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(658, 100);
            this.panel1.TabIndex = 0;
            
            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            
            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Value:";
            
            // txtRegistryName
            this.txtRegistryName.Location = new System.Drawing.Point(70, 12);
            this.txtRegistryName.Name = "txtRegistryName";
            this.txtRegistryName.Size = new System.Drawing.Size(300, 23);
            this.txtRegistryName.TabIndex = 2;
            
            // txtRegistryValue
            this.txtRegistryValue.Location = new System.Drawing.Point(70, 42);
            this.txtRegistryValue.Name = "txtRegistryValue";
            this.txtRegistryValue.Size = new System.Drawing.Size(300, 23);
            this.txtRegistryValue.TabIndex = 3;
            
            // btnRegistryWrite
            this.btnRegistryWrite.Location = new System.Drawing.Point(380, 12);
            this.btnRegistryWrite.Name = "btnRegistryWrite";
            this.btnRegistryWrite.Size = new System.Drawing.Size(75, 23);
            this.btnRegistryWrite.TabIndex = 4;
            this.btnRegistryWrite.Text = "Write";
            this.btnRegistryWrite.UseVisualStyleBackColor = true;
            this.btnRegistryWrite.Click += new System.EventHandler(this.btnRegistryWrite_Click);
            
            // btnRegistryDelete
            this.btnRegistryDelete.Location = new System.Drawing.Point(380, 42);
            this.btnRegistryDelete.Name = "btnRegistryDelete";
            this.btnRegistryDelete.Size = new System.Drawing.Size(75, 23);
            this.btnRegistryDelete.TabIndex = 5;
            this.btnRegistryDelete.Text = "Delete";
            this.btnRegistryDelete.UseVisualStyleBackColor = true;
            this.btnRegistryDelete.Click += new System.EventHandler(this.btnRegistryDelete_Click);
            
            // tabServiceManager
            this.tabServiceManager.Controls.Add(this.listViewServices);
            this.tabServiceManager.Controls.Add(this.toolStrip3);
            this.tabServiceManager.Location = new System.Drawing.Point(4, 24);
            this.tabServiceManager.Name = "tabServiceManager";
            this.tabServiceManager.Size = new System.Drawing.Size(992, 572);
            this.tabServiceManager.TabIndex = 3;
            this.tabServiceManager.Text = "Service Manager";
            this.tabServiceManager.UseVisualStyleBackColor = true;
            
            // listViewServices
            this.listViewServices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colServiceName,
                this.colServiceDisplay,
                this.colServiceStatus});
            this.listViewServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewServices.FullRowSelect = true;
            this.listViewServices.Location = new System.Drawing.Point(0, 25);
            this.listViewServices.Name = "listViewServices";
            this.listViewServices.Size = new System.Drawing.Size(992, 547);
            this.listViewServices.TabIndex = 1;
            this.listViewServices.UseCompatibleStateImageBehavior = false;
            this.listViewServices.View = System.Windows.Forms.View.Details;
            
            this.colServiceName.Text = "Name";
            this.colServiceName.Width = 250;
            this.colServiceDisplay.Text = "Display Name";
            this.colServiceDisplay.Width = 400;
            this.colServiceStatus.Text = "Status";
            this.colServiceStatus.Width = 150;
            
            // toolStrip3
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.btnServiceRefresh,
                this.btnServiceStart,
                this.btnServiceStop});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(992, 25);
            this.toolStrip3.TabIndex = 0;
            
            this.btnServiceRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnServiceRefresh.Name = "btnServiceRefresh";
            this.btnServiceRefresh.Size = new System.Drawing.Size(50, 22);
            this.btnServiceRefresh.Text = "Refresh";
            this.btnServiceRefresh.Click += new System.EventHandler(this.btnServiceRefresh_Click);
            
            this.btnServiceStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnServiceStart.Name = "btnServiceStart";
            this.btnServiceStart.Size = new System.Drawing.Size(35, 22);
            this.btnServiceStart.Text = "Start";
            this.btnServiceStart.Click += new System.EventHandler(this.btnServiceStart_Click);
            
            this.btnServiceStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnServiceStop.Name = "btnServiceStop";
            this.btnServiceStop.Size = new System.Drawing.Size(35, 22);
            this.btnServiceStop.Text = "Stop";
            this.btnServiceStop.Click += new System.EventHandler(this.btnServiceStop_Click);
            
            // frmManager
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manager";
            this.Load += new System.EventHandler(this.frmManager_Load);
            
            this.tabControl1.ResumeLayout(false);
            this.tabFileManager.ResumeLayout(false);
            this.tabFileManager.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabProcessManager.ResumeLayout(false);
            this.tabProcessManager.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabRegistryEditor.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabServiceManager.ResumeLayout(false);
            this.tabServiceManager.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabFileManager;
        private System.Windows.Forms.ListView listViewFiles;
        private System.Windows.Forms.ColumnHeader colFileName;
        private System.Windows.Forms.ColumnHeader colFileSize;
        private System.Windows.Forms.ColumnHeader colFileModified;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnFileRefresh;
        private System.Windows.Forms.ToolStripButton btnFileDownload;
        private System.Windows.Forms.ToolStripButton btnFileDelete;
        private System.Windows.Forms.ToolStripButton btnFileExecute;
        private System.Windows.Forms.TabPage tabProcessManager;
        private System.Windows.Forms.ListView listViewProcesses;
        private System.Windows.Forms.ColumnHeader colProcessName;
        private System.Windows.Forms.ColumnHeader colProcessPID;
        private System.Windows.Forms.ColumnHeader colProcessMemory;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnProcessRefresh;
        private System.Windows.Forms.ToolStripButton btnProcessKill;
        private System.Windows.Forms.TabPage tabRegistryEditor;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewRegistry;
        private System.Windows.Forms.ListView listViewRegistry;
        private System.Windows.Forms.ColumnHeader colRegName;
        private System.Windows.Forms.ColumnHeader colRegType;
        private System.Windows.Forms.ColumnHeader colRegValue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRegistryDelete;
        private System.Windows.Forms.Button btnRegistryWrite;
        private System.Windows.Forms.TextBox txtRegistryValue;
        private System.Windows.Forms.TextBox txtRegistryName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabServiceManager;
        private System.Windows.Forms.ListView listViewServices;
        private System.Windows.Forms.ColumnHeader colServiceName;
        private System.Windows.Forms.ColumnHeader colServiceDisplay;
        private System.Windows.Forms.ColumnHeader colServiceStatus;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton btnServiceRefresh;
        private System.Windows.Forms.ToolStripButton btnServiceStart;
        private System.Windows.Forms.ToolStripButton btnServiceStop;
    }
}
