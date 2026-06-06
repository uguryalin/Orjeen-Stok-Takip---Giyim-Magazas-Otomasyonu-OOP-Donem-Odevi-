using System;
using System.IO;
using Newtonsoft.Json;
using Orjeen_Stok_Takip.Models;

namespace Orjeen_Stok_Takip.Helpers
{
    public static class ConfigHelper
    {
        private static readonly string ConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
        private static ConfigModel? _currentConfig;

        public static ConfigModel LoadConfig()
        {
            if (_currentConfig != null)
                return _currentConfig;

            try
            {
                if (File.Exists(ConfigPath))
                {
                    string json = File.ReadAllText(ConfigPath);
                    _currentConfig = JsonConvert.DeserializeObject<ConfigModel>(json) ?? new ConfigModel();
                }
                else
                {
                    _currentConfig = new ConfigModel();
                    SaveConfig(_currentConfig);
                }
            }
            catch
            {
                _currentConfig = new ConfigModel();
            }

            if (string.IsNullOrWhiteSpace(_currentConfig.SupabaseUrl) || _currentConfig.SupabaseUrl.Contains("gjxkcgqcfzdedmmfxglz"))
            {
                _currentConfig.SupabaseUrl = "https://gjxkcgcqfzdedmmfxglz.supabase.co";
                _currentConfig.SupabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImdqeGtjZ2NxZnpkZWRtbWZ4Z2x6Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3ODAwNjI2OTgsImV4cCI6MjA5NTYzODY5OH0.gLOTrjITy7ZnCucU0jixYBDIiiXjXZ1vQOQK2Bml6l8";
                _currentConfig.GeminiApiKey = "AQ.Ab8RN6IuTb-j6mLCQ0Qi6GHHKRrco-SZb6uSKugcsGhDtBRRHg";
                SaveConfig(_currentConfig);
            }

            return _currentConfig;
        }

        public static void SaveConfig(ConfigModel config)
        {
            try
            {
                string json = JsonConvert.SerializeObject(config, Formatting.Indented);
                File.WriteAllText(ConfigPath, json);
                _currentConfig = config;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving config: {ex.Message}");
            }
        }
    }
}
