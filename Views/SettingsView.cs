using System;
using System.Windows.Forms;
using Orjeen_Stok_Takip.Helpers;
using Orjeen_Stok_Takip.Models;

namespace Orjeen_Stok_Takip.Views
{
    public partial class SettingsView : UserControl
    {
        public event Action? OnSettingsSaved;

        public SettingsView()
        {
            InitializeComponent();
            UIStyleHelper.ApplyDarkStyle(this);
        }

        private void SettingsView_Load(object sender, EventArgs e)
        {
            var config = ConfigHelper.LoadConfig();
            txtUrl.Text = config.SupabaseUrl;
            txtKey.Text = config.SupabaseKey;
            txtGemini.Text = config.GeminiApiKey;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var config = new ConfigModel
            {
                SupabaseUrl = txtUrl.Text.Trim(),
                SupabaseKey = txtKey.Text.Trim(),
                GeminiApiKey = txtGemini.Text.Trim()
            };

            ConfigHelper.SaveConfig(config);

            lblStatus.Text = "Ayarlar başarıyla kaydedildi.";
            lblStatus.ForeColor = UIStyleHelper.SuccessColor;

            OnSettingsSaved?.Invoke();
        }
    }
}
