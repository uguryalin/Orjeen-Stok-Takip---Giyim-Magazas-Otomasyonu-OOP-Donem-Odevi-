using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Orjeen_Stok_Takip.Helpers;
using Orjeen_Stok_Takip.Models;
using Orjeen_Stok_Takip.Services;

namespace Orjeen_Stok_Takip.Views
{
    public partial class ProductView : UserControl
    {
        private List<Product> _allProducts = new List<Product>();
        private string? _selectedProductId = null;

        public ProductView()
        {
            InitializeComponent();
            UIStyleHelper.ApplyDarkStyle(this);
        }

        private void ProductView_Load(object sender, EventArgs e)
        {
            UIStyleHelper.SetRoundedRegion(panelInput, 15);
            LoadCategories();
            LoadProducts();
        }

        private async void LoadCategories()
        {
            if (!SupabaseManager.IsInitialized) return;

            try
            {
                var categories = await CategoryService.GetCategoriesAsync();
                cmbCategory.DataSource = null;
                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "Id";
                cmbCategory.DataSource = categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kategoriler yüklenirken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadProducts()
        {
            if (!SupabaseManager.IsInitialized) return;

            try
            {
                _allProducts = await ProductService.GetProductsAsync();
                FilterProducts();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürünler yüklenirken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterProducts()
        {
            string query = txtSearch.Text.Trim().ToLower();
            List<Product> filtered;

            if (string.IsNullOrEmpty(query))
            {
                filtered = _allProducts;
            }
            else
            {
                filtered = _allProducts.FindAll(x => 
                    x.Name.ToLower().Contains(query) || 
                    x.Barcode.ToLower().Contains(query) || 
                    (x.Brand != null && x.Brand.ToLower().Contains(query))
                );
            }

            dgvProducts.DataSource = null;
            dgvProducts.DataSource = filtered;

            if (dgvProducts.Columns.Count > 0)
            {
                dgvProducts.Columns["Id"].Visible = false;
                dgvProducts.Columns["CategoryId"].Visible = false;
                dgvProducts.Columns["CreatedAt"].Visible = false;

                dgvProducts.Columns["Barcode"].HeaderText = "Barkod";
                dgvProducts.Columns["Name"].HeaderText = "Ürün Adı";
                dgvProducts.Columns["Brand"].HeaderText = "Marka";
                dgvProducts.Columns["Color"].HeaderText = "Renk";
                dgvProducts.Columns["Size"].HeaderText = "Beden";
                dgvProducts.Columns["PurchasePrice"].HeaderText = "Alış Fiyatı";
                dgvProducts.Columns["SalePrice"].HeaderText = "Satış Fiyatı";
                dgvProducts.Columns["StockQuantity"].HeaderText = "Mevcut Stok";
                dgvProducts.Columns["MinStockLevel"].HeaderText = "Kritik Seviye";

                dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void ClearInputs()
        {
            _selectedProductId = null;
            txtName.Clear();
            txtBarcode.Clear();
            txtBrand.Clear();
            txtColor.Clear();
            txtSize.Clear();
            txtPurchasePrice.Text = "0.00";
            txtSalePrice.Text = "0.00";
            txtMinStock.Text = "5";
            
            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;

            btnSave.Text = "Yeni Ürün Ekle";
            btnDelete.Enabled = false;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterProducts();
        }

        private void DgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                var row = dgvProducts.SelectedRows[0];
                var product = (Product)row.DataBoundItem;

                _selectedProductId = product.Id;
                txtName.Text = product.Name;
                txtBarcode.Text = product.Barcode;
                txtBrand.Text = product.Brand ?? string.Empty;
                txtColor.Text = product.Color ?? string.Empty;
                txtSize.Text = product.Size ?? string.Empty;
                txtPurchasePrice.Text = product.PurchasePrice.ToString("F2", CultureInfo.InvariantCulture);
                txtSalePrice.Text = product.SalePrice.ToString("F2", CultureInfo.InvariantCulture);
                txtMinStock.Text = product.MinStockLevel.ToString();

                if (!string.IsNullOrEmpty(product.CategoryId))
                {
                    cmbCategory.SelectedValue = product.CategoryId;
                }

                btnSave.Text = "Ürünü Güncelle";
                btnDelete.Enabled = true;
            }
            else
            {
                ClearInputs();
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string barcode = txtBarcode.Text.Trim();
            string brand = txtBrand.Text.Trim();
            string color = txtColor.Text.Trim();
            string size = txtSize.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(barcode))
            {
                MessageBox.Show("Ürün adı ve barkod alanları zorunludur.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal.TryParse(txtPurchasePrice.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal purchasePrice);
            decimal.TryParse(txtSalePrice.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal salePrice);
            int.TryParse(txtMinStock.Text, out int minStock);

            string? categoryId = cmbCategory.SelectedValue?.ToString();

            try
            {
                if (_selectedProductId == null)
                {
                    var product = new Product
                    {
                        Name = name,
                        Barcode = barcode,
                        Brand = string.IsNullOrEmpty(brand) ? null : brand,
                        Color = string.IsNullOrEmpty(color) ? null : color,
                        Size = string.IsNullOrEmpty(size) ? null : size,
                        PurchasePrice = purchasePrice,
                        SalePrice = salePrice,
                        MinStockLevel = minStock,
                        CategoryId = categoryId,
                        StockQuantity = 0
                    };

                    await ProductService.InsertProductAsync(product);
                    MessageBox.Show("Ürün başarıyla eklendi. Stok miktarını güncellemek için 'Satış / Stok Girişi' menüsünü kullanın.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var product = new Product
                    {
                        Id = _selectedProductId,
                        Name = name,
                        Barcode = barcode,
                        Brand = string.IsNullOrEmpty(brand) ? null : brand,
                        Color = string.IsNullOrEmpty(color) ? null : color,
                        Size = string.IsNullOrEmpty(size) ? null : size,
                        PurchasePrice = purchasePrice,
                        SalePrice = salePrice,
                        MinStockLevel = minStock,
                        CategoryId = categoryId
                    };

                    await ProductService.UpdateProductAsync(product);
                    MessageBox.Show("Ürün bilgileri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürün kaydedilirken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedProductId == null) return;

            var confirm = MessageBox.Show("Bu ürünü silmek istediğinize emin misiniz? Tüm stok hareket geçmişi de silinecektir.", "Ürün Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    await ProductService.DeleteProductAsync(_selectedProductId);
                    MessageBox.Show("Ürün başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ürün silinirken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
