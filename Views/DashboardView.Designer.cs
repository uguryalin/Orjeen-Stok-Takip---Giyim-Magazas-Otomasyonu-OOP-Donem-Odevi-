namespace Orjeen_Stok_Takip.Views
{
    partial class DashboardView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.cardProducts = new System.Windows.Forms.Panel();
            this.lblProdCount = new System.Windows.Forms.Label();
            this.lblProdTitle = new System.Windows.Forms.Label();
            this.cardCategories = new System.Windows.Forms.Panel();
            this.lblCatCount = new System.Windows.Forms.Label();
            this.lblCatTitle = new System.Windows.Forms.Label();
            this.cardLowStock = new System.Windows.Forms.Panel();
            this.lblLowStockCount = new System.Windows.Forms.Label();
            this.lblLowStockTitle = new System.Windows.Forms.Label();
            this.cardMovements = new System.Windows.Forms.Panel();
            this.lblMovCount = new System.Windows.Forms.Label();
            this.lblMovTitle = new System.Windows.Forms.Label();
            this.lblLowStockHeader = new System.Windows.Forms.Label();
            this.dgvLowStock = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cardProducts.SuspendLayout();
            this.cardCategories.SuspendLayout();
            this.cardLowStock.SuspendLayout();
            this.cardMovements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(142, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "MAĞAZA DURUMU";
            this.lblTitle.Tag = "Title";
            // 
            // cardProducts
            // 
            this.cardProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cardProducts.Controls.Add(this.lblProdCount);
            this.cardProducts.Controls.Add(this.lblProdTitle);
            this.cardProducts.Location = new System.Drawing.Point(30, 80);
            this.cardProducts.Name = "cardProducts";
            this.cardProducts.Size = new System.Drawing.Size(200, 110);
            this.cardProducts.TabIndex = 1;
            // 
            // lblProdCount
            // 
            this.lblProdCount.AutoSize = true;
            this.lblProdCount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblProdCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblProdCount.Location = new System.Drawing.Point(20, 45);
            this.lblProdCount.Name = "lblProdCount";
            this.lblProdCount.Size = new System.Drawing.Size(40, 46);
            this.lblProdCount.TabIndex = 1;
            this.lblProdCount.Text = "0";
            // 
            // lblProdTitle
            // 
            this.lblProdTitle.AutoSize = true;
            this.lblProdTitle.Location = new System.Drawing.Point(20, 15);
            this.lblProdTitle.Name = "lblProdTitle";
            this.lblProdTitle.Size = new System.Drawing.Size(91, 20);
            this.lblProdTitle.TabIndex = 0;
            this.lblProdTitle.Text = "Toplam Ürün";
            this.lblProdTitle.Tag = "Muted";
            // 
            // cardCategories
            // 
            this.cardCategories.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cardCategories.Controls.Add(this.lblCatCount);
            this.cardCategories.Controls.Add(this.lblCatTitle);
            this.cardCategories.Location = new System.Drawing.Point(250, 80);
            this.cardCategories.Name = "cardCategories";
            this.cardCategories.Size = new System.Drawing.Size(200, 110);
            this.cardCategories.TabIndex = 2;
            // 
            // lblCatCount
            // 
            this.lblCatCount.AutoSize = true;
            this.lblCatCount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblCatCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(184)))), ((int)(((byte)(166)))));
            this.lblCatCount.Location = new System.Drawing.Point(20, 45);
            this.lblCatCount.Name = "lblCatCount";
            this.lblCatCount.Size = new System.Drawing.Size(40, 46);
            this.lblCatCount.TabIndex = 1;
            this.lblCatCount.Text = "0";
            // 
            // lblCatTitle
            // 
            this.lblCatTitle.AutoSize = true;
            this.lblCatTitle.Location = new System.Drawing.Point(20, 15);
            this.lblCatTitle.Name = "lblCatTitle";
            this.lblCatTitle.Size = new System.Drawing.Size(123, 20);
            this.lblCatTitle.TabIndex = 0;
            this.lblCatTitle.Text = "Toplam Kategori";
            this.lblCatTitle.Tag = "Muted";
            // 
            // cardLowStock
            // 
            this.cardLowStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cardLowStock.Controls.Add(this.lblLowStockCount);
            this.cardLowStock.Controls.Add(this.lblLowStockTitle);
            this.cardLowStock.Location = new System.Drawing.Point(470, 80);
            this.cardLowStock.Name = "cardLowStock";
            this.cardLowStock.Size = new System.Drawing.Size(200, 110);
            this.cardLowStock.TabIndex = 3;
            // 
            // lblLowStockCount
            // 
            this.lblLowStockCount.AutoSize = true;
            this.lblLowStockCount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblLowStockCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblLowStockCount.Location = new System.Drawing.Point(20, 45);
            this.lblLowStockCount.Name = "lblLowStockCount";
            this.lblLowStockCount.Size = new System.Drawing.Size(40, 46);
            this.lblLowStockCount.TabIndex = 1;
            this.lblLowStockCount.Text = "0";
            // 
            // lblLowStockTitle
            // 
            this.lblLowStockTitle.AutoSize = true;
            this.lblLowStockTitle.Location = new System.Drawing.Point(20, 15);
            this.lblLowStockTitle.Name = "lblLowStockTitle";
            this.lblLowStockTitle.Size = new System.Drawing.Size(81, 20);
            this.lblLowStockTitle.TabIndex = 0;
            this.lblLowStockTitle.Text = "Kritik Stok";
            this.lblLowStockTitle.Tag = "Muted";
            // 
            // cardMovements
            // 
            this.cardMovements.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cardMovements.Controls.Add(this.lblMovCount);
            this.cardMovements.Controls.Add(this.lblMovTitle);
            this.cardMovements.Location = new System.Drawing.Point(690, 80);
            this.cardMovements.Name = "cardMovements";
            this.cardMovements.Size = new System.Drawing.Size(230, 110);
            this.cardMovements.TabIndex = 4;
            // 
            // lblMovCount
            // 
            this.lblMovCount.AutoSize = true;
            this.lblMovCount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblMovCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblMovCount.Location = new System.Drawing.Point(20, 45);
            this.lblMovCount.Name = "lblMovCount";
            this.lblMovCount.Size = new System.Drawing.Size(40, 46);
            this.lblMovCount.TabIndex = 1;
            this.lblMovCount.Text = "0";
            // 
            // lblMovTitle
            // 
            this.lblMovTitle.AutoSize = true;
            this.lblMovTitle.Location = new System.Drawing.Point(20, 15);
            this.lblMovTitle.Name = "lblMovTitle";
            this.lblMovTitle.Size = new System.Drawing.Size(126, 20);
            this.lblMovTitle.TabIndex = 0;
            this.lblMovTitle.Text = "Toplam Hareket";
            this.lblMovTitle.Tag = "Muted";
            // 
            // lblLowStockHeader
            // 
            this.lblLowStockHeader.AutoSize = true;
            this.lblLowStockHeader.Location = new System.Drawing.Point(30, 220);
            this.lblLowStockHeader.Name = "lblLowStockHeader";
            this.lblLowStockHeader.Size = new System.Drawing.Size(262, 20);
            this.lblLowStockHeader.TabIndex = 5;
            this.lblLowStockHeader.Text = "KRİTİK STOK SEVİYESİNDEKİ ÜRÜNLER";
            this.lblLowStockHeader.Tag = "Header";
            // 
            // dgvLowStock
            // 
            this.dgvLowStock.AllowUserToAddRows = false;
            this.dgvLowStock.AllowUserToDeleteRows = false;
            this.dgvLowStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLowStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLowStock.Location = new System.Drawing.Point(30, 260);
            this.dgvLowStock.Name = "dgvLowStock";
            this.dgvLowStock.ReadOnly = true;
            this.dgvLowStock.RowHeadersWidth = 51;
            this.dgvLowStock.Size = new System.Drawing.Size(890, 460);
            this.dgvLowStock.TabIndex = 6;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(820, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 35);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Tag = "Primary";
            this.btnRefresh.Text = "Yenile";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // DashboardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvLowStock);
            this.Controls.Add(this.lblLowStockHeader);
            this.Controls.Add(this.cardMovements);
            this.Controls.Add(this.cardLowStock);
            this.Controls.Add(this.cardCategories);
            this.Controls.Add(this.cardProducts);
            this.Controls.Add(this.lblTitle);
            this.Name = "DashboardView";
            this.Size = new System.Drawing.Size(950, 755);
            this.Load += new System.EventHandler(this.DashboardView_Load);
            this.cardProducts.ResumeLayout(false);
            this.cardProducts.PerformLayout();
            this.cardCategories.ResumeLayout(false);
            this.cardCategories.PerformLayout();
            this.cardLowStock.ResumeLayout(false);
            this.cardLowStock.PerformLayout();
            this.cardMovements.ResumeLayout(false);
            this.cardMovements.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel cardProducts;
        private System.Windows.Forms.Label lblProdCount;
        private System.Windows.Forms.Label lblProdTitle;
        private System.Windows.Forms.Panel cardCategories;
        private System.Windows.Forms.Label lblCatCount;
        private System.Windows.Forms.Label lblCatTitle;
        private System.Windows.Forms.Panel cardLowStock;
        private System.Windows.Forms.Label lblLowStockCount;
        private System.Windows.Forms.Label lblLowStockTitle;
        private System.Windows.Forms.Panel cardMovements;
        private System.Windows.Forms.Label lblMovCount;
        private System.Windows.Forms.Label lblMovTitle;
        private System.Windows.Forms.Label lblLowStockHeader;
        private System.Windows.Forms.DataGridView dgvLowStock;
        private System.Windows.Forms.Button btnRefresh;
    }
}
