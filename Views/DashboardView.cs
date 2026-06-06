using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Orjeen_Stok_Takip.Helpers;
using Orjeen_Stok_Takip.Models;
using Orjeen_Stok_Takip.Services;

namespace Orjeen_Stok_Takip.Views
{
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();
            UIStyleHelper.ApplyDarkStyle(this);
        }

        private void DashboardView_Load(object sender, EventArgs e)
        {
            UIStyleHelper.SetRoundedRegion(cardProducts, 15);
            UIStyleHelper.SetRoundedRegion(cardCategories, 15);
            UIStyleHelper.SetRoundedRegion(cardLowStock, 15);
            UIStyleHelper.SetRoundedRegion(cardMovements, 15);

            RefreshStats();
        }

        private async void RefreshStats()
        {
            if (!SupabaseManager.IsInitialized) return;

            try
            {
                btnRefresh.Enabled = false;
                btnRefresh.Text = "Yükleniyor...";

                var products = await ProductService.GetProductsAsync();
                var categories = await CategoryService.GetCategoriesAsync();
                var movements = await StockService.GetStockMovementsAsync();
                var lowStock = products.FindAll(x => x.StockQuantity <= x.MinStockLevel);

                lblProdCount.Text = products.Count.ToString();
                lblCatCount.Text = categories.Count.ToString();
                lblLowStockCount.Text = lowStock.Count.ToString();
                lblMovCount.Text = movements.Count.ToString();

                dgvLowStock.DataSource = null;
                dgvLowStock.DataSource = lowStock;

                if (dgvLowStock.Columns.Count > 0)
                {
                    dgvLowStock.Columns["Id"].Visible = false;
                    dgvLowStock.Columns["CategoryId"].Visible = false;
                    dgvLowStock.Columns["CreatedAt"].Visible = false;

                    dgvLowStock.Columns["Barcode"].HeaderText = "Barkod";
                    dgvLowStock.Columns["Name"].HeaderText = "Ürün Adı";
                    dgvLowStock.Columns["Brand"].HeaderText = "Marka";
                    dgvLowStock.Columns["Color"].HeaderText = "Renk";
                    dgvLowStock.Columns["Size"].HeaderText = "Beden";
                    dgvLowStock.Columns["PurchasePrice"].HeaderText = "Alış Fiyatı";
                    dgvLowStock.Columns["SalePrice"].HeaderText = "Satış Fiyatı";
                    dgvLowStock.Columns["StockQuantity"].HeaderText = "Mevcut Stok";
                    dgvLowStock.Columns["MinStockLevel"].HeaderText = "Kritik Seviye";

                    dgvLowStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
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

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshStats();
        }
    }
}
