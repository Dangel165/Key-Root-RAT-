using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RAT.Shared.Models;

namespace RAT.ControlPanel.Forms
{
    public partial class frmPower : Form
    {
        private ClientInfo client;
        private MainForm mainForm;
        
        public frmPower(ClientInfo client, MainForm mainForm)
        {
            this.client = client;
            this.mainForm = mainForm;
            InitializeComponent();
            this.Text = $"Power - {client.ClientId}";
            
            // MainForm에 이 폼 등록
            mainForm.RegisterForm(client.ClientId, this);
        }
        
        // ===== Shutdown =====
        
        private async void btnShutdown_Click(object sender, EventArgs e)
        {
            bool force = chkForce.Checked;
            
            if (MessageBox.Show($"Shutdown the client?{(force ? " (Force)" : "")}", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                await SendCommand(new { type = "power_shutdown", force = force });
                ShowStatus("Shutdown command sent");
            }
        }
        
        // ===== Reboot =====
        
        private async void btnReboot_Click(object sender, EventArgs e)
        {
            bool force = chkForce.Checked;
            
            if (MessageBox.Show($"Reboot the client?{(force ? " (Force)" : "")}", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                await SendCommand(new { type = "power_reboot", force = force });
                ShowStatus("Reboot command sent");
            }
        }
        
        // ===== Logoff =====
        
        private async void btnLogoff_Click(object sender, EventArgs e)
        {
            bool force = chkForce.Checked;
            
            if (MessageBox.Show($"Logoff the client?{(force ? " (Force)" : "")}", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                await SendCommand(new { type = "power_logoff", force = force });
                ShowStatus("Logoff command sent");
            }
        }
        
        // ===== Hibernate =====
        
        private async void btnHibernate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hibernate the client?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await SendCommand(new { type = "power_hibernate" });
                ShowStatus("Hibernate command sent");
            }
        }
        
        // ===== Sleep =====
        
        private async void btnSleep_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sleep the client?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await SendCommand(new { type = "power_sleep" });
                ShowStatus("Sleep command sent");
            }
        }
        
        // ===== Lock =====
        
        private async void btnLock_Click(object sender, EventArgs e)
        {
            await SendCommand(new { type = "power_lock" });
            ShowStatus("Lock command sent");
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
                MessageBox.Show(response.message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
