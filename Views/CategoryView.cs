using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Orjeen_Stok_Takip.Helpers;
using Orjeen_Stok_Takip.Models;
using Orjeen_Stok_Takip.Services;

namespace Orjeen_Stok_Takip.Views
{
    public partial class CategoryView : UserControl
    {
        private string? _selectedCategoryId = null;

        public CategoryView()
        {
            InitializeComponent();
            UIStyleHelper.ApplyDarkStyle(this);
        }

        private void CategoryView_Load(object sender, EventArgs e)
        {
            UIStyleHelper.SetRoundedRegion(panelInput, 15);
            LoadCategories();
        }

        private async void LoadCategories()
        {
            if (!SupabaseManager.IsInitialized) return;

            try
            {
                var list = await CategoryService.GetCategoriesAsync();
                dgvCategories.DataSource = null;
                dgvCategories.DataSource = list;

                if (dgvCategories.Columns.Count > 0)
                {
                    dgvCategories.Columns["Id"].Visible = false;
                    dgvCategories.Columns["CreatedAt"].Visible = false;

                    dgvCategories.Columns["Name"].HeaderText = "Kategori Adı";
                    dgvCategories.Columns["Description"].HeaderText = "Açıklama";

                    dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }

                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kategoriler yüklenirken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            _selectedCategoryId = null;
            txtName.Clear();
            txtDescription.Clear();
            btnSave.Text = "Yeni Kategori Ekle";
            btnDelete.Enabled = false;
        }

        private void DgvCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count > 0)
            {
                var row = dgvCategories.SelectedRows[0];
                var category = (Category)row.DataBoundItem;
                
                _selectedCategoryId = category.Id;
                txtName.Text = category.Name;
                txtDescription.Text = category.Description;
                
                btnSave.Text = "Kategoriyi Güncelle";
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
            string desc = txtDescription.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Kategori adı boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_selectedCategoryId == null)
                {
                    await CategoryService.InsertCategoryAsync(name, desc);
                    MessageBox.Show("Kategori başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await CategoryService.UpdateCategoryAsync(_selectedCategoryId, name, desc);
                    MessageBox.Show("Kategori başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kategori kaydedilirken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedCategoryId == null) return;

            var confirm = MessageBox.Show("Bu kategoriyi silmek istediğinize emin misiniz? Bu kategoriye ait ürünler etkilenmeyecektir.", "Kategori Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    await CategoryService.DeleteCategoryAsync(_selectedCategoryId);
                    MessageBox.Show("Kategori silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategories();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Kategori silinirken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
