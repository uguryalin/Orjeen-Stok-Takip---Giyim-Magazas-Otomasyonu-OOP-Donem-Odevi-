using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Orjeen_Stok_Takip.Helpers;
using Orjeen_Stok_Takip.Models;
using Orjeen_Stok_Takip.Services;

namespace Orjeen_Stok_Takip.Views
{
    public partial class SalesView : UserControl
    {
        private Product? _activeProduct;

        public SalesView()
        {
            InitializeComponent();
            UIStyleHelper.ApplyDarkStyle(this);
        }

        private void SalesView_Load(object sender, EventArgs e)
        {
            UIStyleHelper.SetRoundedRegion(panelTransaction, 15);
            UIStyleHelper.SetRoundedRegion(lblProductInfo, 8);
            
            cmbMovementType.SelectedIndex = 0; // Default to Out (Sale)
            LoadMovementsHistory();
        }

        private async void LoadMovementsHistory()
        {
            if (!SupabaseManager.IsInitialized) return;

            try
            {
                var movements = await StockService.GetStockMovementsAsync();
                var products = await ProductService.GetProductsAsync();
                var prodDict = new Dictionary<string, string>();
                foreach (var p in products)
                {
                    prodDict[p.Id] = $"{p.Name} ({p.Barcode})";
                }

                var displayList = new List<object>();
                foreach (var m in movements)
                {
                    prodDict.TryGetValue(m.ProductId, out string? prodName);
                    displayList.Add(new
                    {
                        m.Id,
                        Urun = prodName ?? "Bilinmeyen Ürün",
                        Tip = m.MovementType == "IN" ? "Giriş (Alış)" : "Çıkış (Satış)",
                        Miktar = m.Quantity,
                        BirimFiyat = m.UnitPrice.ToString("C", CultureInfo.GetCultureInfo("tr-TR")),
                        Toplam = (m.Quantity * m.UnitPrice).ToString("C", CultureInfo.GetCultureInfo("tr-TR")),
                        Aciklama = m.Description ?? string.Empty,
                        Tarih = m.CreatedAt.ToLocalTime().ToString("g")
                    });
                }

                dgvHistory.DataSource = null;
                dgvHistory.DataSource = displayList;

                if (dgvHistory.Columns.Count > 0)
                {
                    dgvHistory.Columns["Id"].Visible = false;

                    dgvHistory.Columns["Urun"].HeaderText = "Ürün";
                    dgvHistory.Columns["Tip"].HeaderText = "İşlem Tipi";
                    dgvHistory.Columns["Miktar"].HeaderText = "Miktar";
                    dgvHistory.Columns["BirimFiyat"].HeaderText = "Birim Fiyat";
                    dgvHistory.Columns["Toplam"].HeaderText = "Toplam Tutar";
                    dgvHistory.Columns["Aciklama"].HeaderText = "Açıklama";
                    dgvHistory.Columns["Tarih"].HeaderText = "Tarih";

                    dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading movements: {ex.Message}");
            }
        }

        private async void SearchBarcode()
        {
            string barcode = txtBarcode.Text.Trim();
            if (string.IsNullOrEmpty(barcode)) return;

            try
            {
                var product = await ProductService.GetProductByBarcodeAsync(barcode);
                if (product != null)
                {
                    _activeProduct = product;
                    lblProductInfo.Text = $"Ürün: {product.Name}\n" +
                                         $"Marka/Beden: {product.Brand ?? "-"} / {product.Size ?? "-"}\n" +
                                         $"Mevcut Stok: {product.StockQuantity}\n" +
                                         $"Satış Fiyatı: {product.SalePrice:C}\n" +
                                         $"Alış Fiyatı: {product.PurchasePrice:C}";
                    
                    UpdateDefaultPrice();
                    txtQty.Focus();
                }
                else
                {
                    _activeProduct = null;
                    lblProductInfo.Text = "Ürün bulunamadı.";
                    txtPrice.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürün aranırken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDefaultPrice()
        {
            if (_activeProduct == null) return;

            if (cmbMovementType.SelectedIndex == 0)
            {
                txtPrice.Text = _activeProduct.SalePrice.ToString("F2", CultureInfo.InvariantCulture);
            }
            else
            {
                txtPrice.Text = _activeProduct.PurchasePrice.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        private void BtnSearchBarcode_Click(object sender, EventArgs e)
        {
            SearchBarcode();
        }

        private void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchBarcode();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void CmbMovementType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDefaultPrice();
        }

        private async void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (_activeProduct == null)
            {
                MessageBox.Show("Lütfen önce geçerli bir ürün seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtQty.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Miktar sıfırdan büyük bir tamsayı olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal.TryParse(txtPrice.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price);

            string type = cmbMovementType.SelectedIndex == 0 ? "OUT" : "IN";
            string desc = txtDesc.Text.Trim();

            if (type == "OUT" && _activeProduct.StockQuantity < qty)
            {
                var confirm = MessageBox.Show($"Yetersiz stok! Mevcut stok ({_activeProduct.StockQuantity}) satış miktarından ({qty}) azdır. Yine de devam etmek istiyor musunuz?", "Stok Uyarısı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.No)
                {
                    return;
                }
            }

            try
            {
                btnSubmit.Enabled = false;
                await StockService.AddMovementAsync(_activeProduct.Id, type, qty, price, desc);
                
                MessageBox.Show("İşlem başarıyla tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtBarcode.Clear();
                txtQty.Text = "1";
                txtDesc.Clear();
                _activeProduct = null;
                lblProductInfo.Text = "Lütfen bir ürün barkodu okutun.";
                txtPrice.Text = "0.00";
                
                LoadMovementsHistory();
                txtBarcode.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İşlem tamamlanırken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSubmit.Enabled = true;
            }
        }
    }
}
