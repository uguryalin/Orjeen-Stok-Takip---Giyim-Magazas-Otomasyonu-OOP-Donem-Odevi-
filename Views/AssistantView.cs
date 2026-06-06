using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Orjeen_Stok_Takip.Helpers;
using Orjeen_Stok_Takip.Services;

namespace Orjeen_Stok_Takip.Views
{
    public partial class AssistantView : UserControl
    {
        // Win32 API to scroll RichTextBox to the absolute bottom
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private const int WM_VSCROLL = 0x115;
        private const int SB_BOTTOM = 7;

        public AssistantView()
        {
            InitializeComponent();
            UIStyleHelper.ApplyDarkStyle(this);

            rtbChat.BackColor = UIStyleHelper.PanelColor;
            rtbChat.ForeColor = UIStyleHelper.TextColor;
            rtbChat.Font = UIStyleHelper.RegularFont;
        }

        private void AssistantView_Load(object sender, EventArgs e)
        {
            UIStyleHelper.SetRoundedRegion(panelChatBg, 12);
            UIStyleHelper.SetRoundedRegion(panelInputContainer, 12);

            // Dynamically recalculate rounded regions when container sizes change (e.g. window maximized)
            panelChatBg.SizeChanged += (s, ev) => UIStyleHelper.SetRoundedRegion(panelChatBg, 12);
            panelInputContainer.SizeChanged += (s, ev) => UIStyleHelper.SetRoundedRegion(panelInputContainer, 12);

            AppendMessage("🤖 Orjeen Yapay Zeka", "Merhaba! Ben Orjeen Stok Danışmanınız. Mağazanızdaki stok durumu, kritik seviyedeki ürünler veya satış performansları hakkında sorularınızı yanıtlayabilir, size sipariş önerileri hazırlayabilirim. Nasıl yardımcı olabilirim?", false);
        }

        private void AppendMessage(string sender, string message, bool isUser)
        {
            rtbChat.SelectionStart = rtbChat.TextLength;
            rtbChat.SelectionLength = 0;

            rtbChat.SelectionColor = isUser ? UIStyleHelper.PrimaryColor : UIStyleHelper.AccentColor;
            rtbChat.SelectionFont = UIStyleHelper.RegularBoldFont;
            rtbChat.AppendText(sender + ":\n");

            rtbChat.SelectionColor = UIStyleHelper.TextColor;
            rtbChat.SelectionFont = UIStyleHelper.RegularFont;
            rtbChat.AppendText(message + "\n\n");

            // Force scroll to the absolute bottom
            SendMessage(rtbChat.Handle, WM_VSCROLL, SB_BOTTOM, 0);
        }

        private async Task<string> BuildStockContextAsync()
        {
            if (!SupabaseManager.IsInitialized)
                return "Supabase veritabanı bağlantısı yok.";

            try
            {
                var products = await ProductService.GetProductsAsync();
                var categories = await CategoryService.GetCategoriesAsync();

                var sb = new StringBuilder();
                sb.AppendLine($"--- MAĞAZA ÖZET VERİLERİ ---");
                sb.AppendLine($"Toplam Ürün Çeşidi: {products.Count}");
                sb.AppendLine($"Toplam Kategori Sayısı: {categories.Count}");
                
                sb.AppendLine("\nKategoriler:");
                foreach (var cat in categories)
                {
                    sb.AppendLine($"- {cat.Name}");
                }

                sb.AppendLine("\nÜrün Listesi ve Stok Seviyeleri:");
                foreach (var prod in products)
                {
                    string status = prod.StockQuantity <= prod.MinStockLevel ? "🚨 (Kritik Seviye!)" : "✓";
                    sb.AppendLine($"- {prod.Name} [Barkod: {prod.Barcode}, Marka: {prod.Brand ?? "-"}, Beden: {prod.Size ?? "-"}, Renk: {prod.Color ?? "-"}]: Stok: {prod.StockQuantity} adet (Min: {prod.MinStockLevel}) - Satış Fiyatı: {prod.SalePrice} TL - Alış Fiyatı: {prod.PurchasePrice} TL {status}");
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                return $"Stok verileri alınamadı: {ex.Message}";
            }
        }

        private async void SendMessage()
        {
            string query = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(query)) return;

            txtInput.Clear();
            AppendMessage("👤 Siz", query, true);

            btnSend.Enabled = false;
            txtInput.Enabled = false;
            
            try
            {
                string stockContext = await BuildStockContextAsync();
                string reply = await GeminiService.ChatWithAssistantAsync(query, stockContext);

                AppendMessage("🤖 Orjeen Yapay Zeka", reply, false);
            }
            catch (Exception ex)
            {
                AppendMessage("🤖 Sistem", $"Hata oluştu: {ex.Message}", false);
            }
            finally
            {
                btnSend.Enabled = true;
                txtInput.Enabled = true;
                txtInput.Focus();
            }
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void TxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendMessage();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
