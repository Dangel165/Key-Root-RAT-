using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace RAT.ControlPanel.Forms
{
    public partial class frmSettings : Form
    {
        private Settings settings;
        private const string SETTINGS_FILE = "settings.json";
        
        public frmSettings()
        {
            InitializeComponent();
            LoadSettings();
        }
        
        private void frmSettings_Load(object sender, EventArgs e)
        {
            ApplySettingsToUI();
        }
        
        private void LoadSettings()
        {
            try
            {
                if (File.Exists(SETTINGS_FILE))
                {
                    string json = File.ReadAllText(SETTINGS_FILE);
                    settings = JsonConvert.DeserializeObject<Settings>(json);
                }
                else
                {
                    // 기본 설정
                    settings = new Settings
                    {
                        ListenIP = "0.0.0.0",
                        ServerPort = 4444,
                        AutoStart = false,
                        MaxClients = 100,
                        RefreshInterval = 2000,
                        EnableLogging = true,
                        LogPath = "logs",
                        Theme = "Dark",
                        EnableNotifications = true,
                        Language = "en",
                        AutoReconnect = true,
                        ConnectionTimeout = 30,
                        EnableEncryption = true,
                        CompressionEnabled = false
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                settings = new Settings();
            }
        }
        
        private void ApplySettingsToUI()
        {
            // Server Settings
            txtListenIP.Text = settings.ListenIP ?? "0.0.0.0";
            numPort.Value = settings.ServerPort;
            chkAutoStart.Checked = settings.AutoStart;
            numMaxClients.Value = settings.MaxClients;
            numRefreshInterval.Value = settings.RefreshInterval;
            
            // Logging Settings
            chkEnableLogging.Checked = settings.EnableLogging;
            txtLogPath.Text = settings.LogPath;
            
            // UI Settings
            comboTheme.SelectedItem = settings.Theme;
            chkEnableNotifications.Checked = settings.EnableNotifications;
            comboLanguage.SelectedItem = settings.Language == "ko" ? "한국어" : "English";
            
            // Connection Settings
            chkAutoReconnect.Checked = settings.AutoReconnect;
            numConnectionTimeout.Value = settings.ConnectionTimeout;
            
            // Security Settings
            chkEnableEncryption.Checked = settings.EnableEncryption;
            chkCompressionEnabled.Checked = settings.CompressionEnabled;
        }
        
        private void ApplyUIToSettings()
        {
            // Server Settings
            settings.ListenIP = txtListenIP.Text.Trim();
            settings.ServerPort = (int)numPort.Value;
            settings.AutoStart = chkAutoStart.Checked;
            settings.MaxClients = (int)numMaxClients.Value;
            settings.RefreshInterval = (int)numRefreshInterval.Value;
            
            // Logging Settings
            settings.EnableLogging = chkEnableLogging.Checked;
            settings.LogPath = txtLogPath.Text;
            
            // UI Settings
            settings.Theme = comboTheme.SelectedItem.ToString();
            settings.EnableNotifications = chkEnableNotifications.Checked;
            settings.Language = comboLanguage.SelectedItem.ToString() == "한국어" ? "ko" : "en";
            
            // Connection Settings
            settings.AutoReconnect = chkAutoReconnect.Checked;
            settings.ConnectionTimeout = (int)numConnectionTimeout.Value;
            
            // Security Settings
            settings.EnableEncryption = chkEnableEncryption.Checked;
            settings.CompressionEnabled = chkCompressionEnabled.Checked;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ApplyUIToSettings();
                
                string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
                File.WriteAllText(SETTINGS_FILE, json);
                
                MessageBox.Show("Settings saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
        private void btnReset_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to reset all settings to default?", 
                "Confirm Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                settings = new Settings
                {
                    ListenIP = "0.0.0.0",
                    ServerPort = 4444,
                    AutoStart = false,
                    MaxClients = 100,
                    RefreshInterval = 2000,
                    EnableLogging = true,
                    LogPath = "logs",
                    Theme = "Dark",
                    EnableNotifications = true,
                    Language = "en",
                    AutoReconnect = true,
                    ConnectionTimeout = 30,
                    EnableEncryption = true,
                    CompressionEnabled = false
                };
                
                ApplySettingsToUI();
                MessageBox.Show("Settings reset to default values.", "Reset Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void btnBrowseLogPath_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select Log Directory";
                fbd.SelectedPath = txtLogPath.Text;
                
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtLogPath.Text = fbd.SelectedPath;
                }
            }
        }
        
        public Settings GetSettings()
        {
            return settings;
        }
    }
    
    public class Settings
    {
        // Server Settings
        public string ListenIP { get; set; }
        public int ServerPort { get; set; }
        public bool AutoStart { get; set; }
        public int MaxClients { get; set; }
        public int RefreshInterval { get; set; }
        
        // Logging Settings
        public bool EnableLogging { get; set; }
        public string LogPath { get; set; }
        
        // UI Settings
        public string Theme { get; set; }
        public bool EnableNotifications { get; set; }
        public string Language { get; set; }
        
        // Connection Settings
        public bool AutoReconnect { get; set; }
        public int ConnectionTimeout { get; set; }
        
        // Security Settings
        public bool EnableEncryption { get; set; }
        public bool CompressionEnabled { get; set; }
    }
}
