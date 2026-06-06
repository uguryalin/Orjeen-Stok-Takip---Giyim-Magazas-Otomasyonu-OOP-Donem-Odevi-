using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Orjeen_Stok_Takip.Helpers;
using Orjeen_Stok_Takip.Models;
using Orjeen_Stok_Takip.Services;

namespace Orjeen_Stok_Takip.Views
{
    public partial class RevenueView : UserControl
    {
        private List<StockMovement> _allMovements = new List<StockMovement>();
        private Dictionary<string, string> _productNames = new Dictionary<string, string>();

        public RevenueView()
        {
            InitializeComponent();
            UIStyleHelper.ApplyDarkStyle(this);
        }

        private void RevenueView_Load(object sender, EventArgs e)
        {
            UIStyleHelper.SetRoundedRegion(filterPanel, 12);
            UIStyleHelper.SetRoundedRegion(cardRevenue, 12);
            UIStyleHelper.SetRoundedRegion(cardCost, 12);
            UIStyleHelper.SetRoundedRegion(cardProfit, 12);

            // Re-apply rounded regions dynamically when size changes (handles maximization/resizing)
            filterPanel.SizeChanged += (s, ev) => UIStyleHelper.SetRoundedRegion(filterPanel, 12);
            cardRevenue.SizeChanged += (s, ev) => UIStyleHelper.SetRoundedRegion(cardRevenue, 12);
            cardCost.SizeChanged += (s, ev) => UIStyleHelper.SetRoundedRegion(cardCost, 12);
            cardProfit.SizeChanged += (s, ev) => UIStyleHelper.SetRoundedRegion(cardProfit, 12);

            dtpSingleDate.Value = DateTime.Today;
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            dtpEndDate.Value = DateTime.Today;

            RefreshDataAndLoadToday();
        }

        private async void RefreshDataAndLoadToday()
        {
            if (!SupabaseManager.IsInitialized) return;

            try
            {
                btnRefresh.Enabled = false;
                btnRefresh.Text = "Yükleniyor...";

                // Load all movements and products once to cache
                _allMovements = await StockService.GetStockMovementsAsync();
                
                var products = await ProductService.GetProductsAsync();
                _productNames.Clear();
                foreach (var p in products)
                {
                    _productNames[p.Id] = $"{p.Name} ({p.Barcode})";
                }

                // Default to Today's stats
                FilterToday();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnRefresh.Enabled = true;
                btnRefresh.Text = "Yenile";
            }
        }

        private void FilterToday()
        {
            lblTableTitle.Text = "BUGÜNKÜ ANLIK İŞLEMLER";
            var today = DateTime.Today;
            var filtered = _allMovements.FindAll(m => m.CreatedAt.ToLocalTime().Date == today);
            CalculateAndDisplay(filtered);
        }

        private void FilterSingleDay(DateTime selectedDate)
        {
            lblTableTitle.Text = $"{selectedDate.ToString("dd.MM.yyyy")} TARİHLİ İŞLEMLER";
            var filtered = _allMovements.FindAll(m => m.CreatedAt.ToLocalTime().Date == selectedDate.Date);
            CalculateAndDisplay(filtered);
        }

        private void FilterDateRange(DateTime start, DateTime end)
        {
            lblTableTitle.Text = $"{start.ToString("dd.MM.yyyy")} - {end.ToString("dd.MM.yyyy")} ARASINDAKİ İŞLEMLER";
            var filtered = _allMovements.FindAll(m => {
                var localDate = m.CreatedAt.ToLocalTime().Date;
                return localDate >= start.Date && localDate <= end.Date;
            });
            CalculateAndDisplay(filtered);
        }

        private void CalculateAndDisplay(List<StockMovement> movements)
        {
            decimal totalRevenue = 0; // Sales/OUT
            decimal totalCost = 0;    // Purchases/IN

            var displayList = new List<object>();

            foreach (var m in movements)
            {
                _productNames.TryGetValue(m.ProductId, out string? prodName);
                decimal amount = m.Quantity * m.UnitPrice;

                if (m.MovementType == "OUT")
                {
                    totalRevenue += amount;
                }
                else if (m.MovementType == "IN")
                {
                    totalCost += amount;
                }

                displayList.Add(new
                {
                    m.Id,
                    Urun = prodName ?? "Bilinmeyen Ürün",
                    Tip = m.MovementType == "IN" ? "Giriş (Alış)" : "Çıkış (Satış)",
                    Miktar = m.Quantity,
                    BirimFiyat = m.UnitPrice.ToString("C", CultureInfo.GetCultureInfo("tr-TR")),
                    ToplamTutar = amount.ToString("C", CultureInfo.GetCultureInfo("tr-TR")),
                    Aciklama = m.Description ?? string.Empty,
                    Tarih = m.CreatedAt.ToLocalTime().ToString("g")
                });
            }

            // Update KPI cards
            lblTotalRevenue.Text = totalRevenue.ToString("C", CultureInfo.GetCultureInfo("tr-TR"));
            lblTotalCost.Text = totalCost.ToString("C", CultureInfo.GetCultureInfo("tr-TR"));

            decimal netProfit = totalRevenue - totalCost;
            lblNetProfit.Text = netProfit.ToString("C", CultureInfo.GetCultureInfo("tr-TR"));

            // Change net profit color depending on positive/negative status
            if (netProfit > 0)
            {
                lblNetProfit.ForeColor = UIStyleHelper.SuccessColor; // Green for positive profit
            }
            else if (netProfit < 0)
            {
                lblNetProfit.ForeColor = UIStyleHelper.DangerColor; // Red for loss
            }
            else
            {
                lblNetProfit.ForeColor = UIStyleHelper.PrimaryColor; // Blue for neutral/zero
            }

            // Populate Grid
            dgvMovements.DataSource = null;
            dgvMovements.DataSource = displayList;

            if (dgvMovements.Columns.Count > 0)
            {
                dgvMovements.Columns["Id"].Visible = false;

                dgvMovements.Columns["Urun"].HeaderText = "Ürün";
                dgvMovements.Columns["Tip"].HeaderText = "İşlem Tipi";
                dgvMovements.Columns["Miktar"].HeaderText = "Miktar";
                dgvMovements.Columns["BirimFiyat"].HeaderText = "Birim Fiyat";
                dgvMovements.Columns["ToplamTutar"].HeaderText = "Toplam Tutar";
                dgvMovements.Columns["Aciklama"].HeaderText = "Açıklama";
                dgvMovements.Columns["Tarih"].HeaderText = "İşlem Tarihi";

                dgvMovements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataAndLoadToday();
        }

        private void BtnFilterToday_Click(object sender, EventArgs e)
        {
            FilterToday();
        }

        private void BtnFilterDay_Click(object sender, EventArgs e)
        {
            FilterSingleDay(dtpSingleDate.Value);
        }

        private void BtnFilterRange_Click(object sender, EventArgs e)
        {
            DateTime start = dtpStartDate.Value;
            DateTime end = dtpEndDate.Value;

            if (start > end)
            {
                MessageBox.Show("Başlangıç tarihi bitiş tarihinden sonra olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FilterDateRange(start, end);
        }
    }
}
