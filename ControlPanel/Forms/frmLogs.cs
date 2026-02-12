using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace RAT.ControlPanel.Forms
{
    public partial class frmLogs : Form
    {
        private List<LogEntry> logs;
        private string logFilePath = "logs/rat_log.txt";
        
        public frmLogs()
        {
            InitializeComponent();
            logs = new List<LogEntry>();
        }
        
        private void frmLogs_Load(object sender, EventArgs e)
        {
            // 로그 레벨 필터 초기화
            comboLogLevel.SelectedIndex = 0;
            
            // 로그 파일 로드
            LoadLogs();
            
            // 타이머 시작 (자동 새로고침)
            timerRefresh.Start();
        }
        
        private void LoadLogs()
        {
            try
            {
                if (File.Exists(logFilePath))
                {
                    var lines = File.ReadAllLines(logFilePath);
                    logs.Clear();
                    
                    foreach (var line in lines)
                    {
                        var entry = ParseLogEntry(line);
                        if (entry != null)
                        {
                            logs.Add(entry);
                        }
                    }
                    
                    ApplyFilter();
                }
                else
                {
                    // 로그 디렉토리 생성
                    Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));
                    
                    // 샘플 로그 추가
                    AddLog("INFO", "Application started");
                    AddLog("INFO", "Server initialized on port 4444");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load logs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private LogEntry ParseLogEntry(string line)
        {
            try
            {
                // 형식: [2024-02-12 10:30:45] [INFO] Message
                if (line.StartsWith("[") && line.Contains("]"))
                {
                    var parts = line.Split(new[] { "] [", "] " }, StringSplitOptions.None);
                    if (parts.Length >= 3)
                    {
                        var timestamp = parts[0].Substring(1);
                        var level = parts[1];
                        var message = string.Join("] ", parts.Skip(2));
                        
                        return new LogEntry
                        {
                            Timestamp = DateTime.Parse(timestamp),
                            Level = level,
                            Message = message
                        };
                    }
                }
            }
            catch { }
            
            return null;
        }
        
        private void ApplyFilter()
        {
            listViewLogs.Items.Clear();
            
            string levelFilter = comboLogLevel.SelectedItem.ToString();
            string searchText = txtSearch.Text.ToLower();
            
            var filteredLogs = logs.AsEnumerable();
            
            // 레벨 필터
            if (levelFilter != "All")
            {
                filteredLogs = filteredLogs.Where(l => l.Level == levelFilter);
            }
            
            // 검색 필터
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                filteredLogs = filteredLogs.Where(l => l.Message.ToLower().Contains(searchText));
            }
            
            // ListView에 추가
            foreach (var log in filteredLogs.OrderByDescending(l => l.Timestamp))
            {
                var item = new ListViewItem(log.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
                item.SubItems.Add(log.Level);
                item.SubItems.Add(log.Message);
                item.Tag = log;
                
                // 색상 코딩
                switch (log.Level)
                {
                    case "ERROR":
                        item.ForeColor = Color.Red;
                        break;
                    case "WARNING":
                        item.ForeColor = Color.Orange;
                        break;
                    case "INFO":
                        item.ForeColor = Color.Blue;
                        break;
                    case "SUCCESS":
                        item.ForeColor = Color.Green;
                        break;
                    case "DEBUG":
                        item.ForeColor = Color.Gray;
                        break;
                }
                
                listViewLogs.Items.Add(item);
            }
            
            lblStatus.Text = $"Total: {logs.Count} | Filtered: {listViewLogs.Items.Count}";
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLogs();
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to clear all logs?", 
                "Confirm Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                logs.Clear();
                listViewLogs.Items.Clear();
                
                try
                {
                    if (File.Exists(logFilePath))
                    {
                        File.Delete(logFilePath);
                    }
                    
                    AddLog("INFO", "Logs cleared");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to clear logs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void btnExport_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text Files|*.txt|CSV Files|*.csv|All Files|*.*";
                sfd.FileName = $"rat_logs_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var lines = logs.Select(l => $"[{l.Timestamp:yyyy-MM-dd HH:mm:ss}] [{l.Level}] {l.Message}");
                        File.WriteAllLines(sfd.FileName, lines);
                        
                        MessageBox.Show("Logs exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to export logs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        
        private void comboLogLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        
        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            // 자동 새로고침 (파일 변경 감지)
            if (chkAutoRefresh.Checked)
            {
                LoadLogs();
            }
        }
        
        public void AddLog(string level, string message)
        {
            var entry = new LogEntry
            {
                Timestamp = DateTime.Now,
                Level = level,
                Message = message
            };
            
            logs.Add(entry);
            
            // 파일에 저장
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));
                string logLine = $"[{entry.Timestamp:yyyy-MM-dd HH:mm:ss}] [{entry.Level}] {entry.Message}";
                File.AppendAllText(logFilePath, logLine + Environment.NewLine);
            }
            catch { }
            
            // UI 업데이트
            if (InvokeRequired)
            {
                Invoke(new Action(() => ApplyFilter()));
            }
            else
            {
                ApplyFilter();
            }
        }
        
        private void listViewLogs_DoubleClick(object sender, EventArgs e)
        {
            if (listViewLogs.SelectedItems.Count > 0)
            {
                var log = listViewLogs.SelectedItems[0].Tag as LogEntry;
                if (log != null)
                {
                    MessageBox.Show($"Timestamp: {log.Timestamp:yyyy-MM-dd HH:mm:ss}\nLevel: {log.Level}\n\nMessage:\n{log.Message}", 
                        "Log Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            timerRefresh?.Stop();
            base.OnFormClosing(e);
        }
    }
    
    public class LogEntry
    {
        public DateTime Timestamp { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
    }
}
