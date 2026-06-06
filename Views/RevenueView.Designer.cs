namespace Orjeen_Stok_Takip.Views
{
    partial class RevenueView
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.btnFilterToday = new System.Windows.Forms.Button();
            this.btnFilterRange = new System.Windows.Forms.Button();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblAnd = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblRangeFilter = new System.Windows.Forms.Label();
            this.btnFilterDay = new System.Windows.Forms.Button();
            this.dtpSingleDate = new System.Windows.Forms.DateTimePicker();
            this.lblDayFilter = new System.Windows.Forms.Label();
            this.cardRevenue = new System.Windows.Forms.Panel();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.lblRevenueTitle = new System.Windows.Forms.Label();
            this.cardCost = new System.Windows.Forms.Panel();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.lblCostTitle = new System.Windows.Forms.Label();
            this.cardProfit = new System.Windows.Forms.Panel();
            this.lblNetProfit = new System.Windows.Forms.Label();
            this.lblProfitTitle = new System.Windows.Forms.Label();
            this.lblTableTitle = new System.Windows.Forms.Label();
            this.dgvMovements = new System.Windows.Forms.DataGridView();
            this.filterPanel.SuspendLayout();
            this.cardRevenue.SuspendLayout();
            this.cardCost.SuspendLayout();
            this.cardProfit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovements)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(206, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CİRO VE GELİR TAKİBİ";
            this.lblTitle.Tag = "Title";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(820, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 35);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Tag = "Primary";
            this.btnRefresh.Text = "Yenile";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // filterPanel
            // 
            this.filterPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.filterPanel.Controls.Add(this.btnFilterToday);
            this.filterPanel.Controls.Add(this.btnFilterRange);
            this.filterPanel.Controls.Add(this.dtpEndDate);
            this.filterPanel.Controls.Add(this.lblAnd);
            this.filterPanel.Controls.Add(this.dtpStartDate);
            this.filterPanel.Controls.Add(this.lblRangeFilter);
            this.filterPanel.Controls.Add(this.btnFilterDay);
            this.filterPanel.Controls.Add(this.dtpSingleDate);
            this.filterPanel.Controls.Add(this.lblDayFilter);
            this.filterPanel.Location = new System.Drawing.Point(30, 80);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(890, 85);
            this.filterPanel.TabIndex = 2;
            // 
            // btnFilterToday
            // 
            this.btnFilterToday.Location = new System.Drawing.Point(770, 25);
            this.btnFilterToday.Name = "btnFilterToday";
            this.btnFilterToday.Size = new System.Drawing.Size(100, 35);
            this.btnFilterToday.TabIndex = 8;
            this.btnFilterToday.Text = "Bugün (Anlık)";
            this.btnFilterToday.UseVisualStyleBackColor = true;
            this.btnFilterToday.Click += new System.EventHandler(this.BtnFilterToday_Click);
            // 
            // btnFilterRange
            // 
            this.btnFilterRange.Location = new System.Drawing.Point(675, 25);
            this.btnFilterRange.Name = "btnFilterRange";
            this.btnFilterRange.Size = new System.Drawing.Size(80, 35);
            this.btnFilterRange.TabIndex = 7;
            this.btnFilterRange.Tag = "Primary";
            this.btnFilterRange.Text = "Uygula";
            this.btnFilterRange.UseVisualStyleBackColor = true;
            this.btnFilterRange.Click += new System.EventHandler(this.BtnFilterRange_Click);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(545, 28);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(120, 27);
            this.dtpEndDate.TabIndex = 6;
            // 
            // lblAnd
            // 
            this.lblAnd.AutoSize = true;
            this.lblAnd.Location = new System.Drawing.Point(515, 31);
            this.lblAnd.Name = "lblAnd";
            this.lblAnd.Size = new System.Drawing.Size(25, 20);
            this.lblAnd.TabIndex = 5;
            this.lblAnd.Text = "ile";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(385, 28);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(120, 27);
            this.dtpStartDate.TabIndex = 4;
            // 
            // lblRangeFilter
            // 
            this.lblRangeFilter.AutoSize = true;
            this.lblRangeFilter.Location = new System.Drawing.Point(385, 5);
            this.lblRangeFilter.Name = "lblRangeFilter";
            this.lblRangeFilter.Size = new System.Drawing.Size(139, 20);
            this.lblRangeFilter.TabIndex = 3;
            this.lblRangeFilter.Text = "Tarih Aralığı Seçin:";
            this.lblRangeFilter.Tag = "Muted";
            // 
            // btnFilterDay
            // 
            this.btnFilterDay.Location = new System.Drawing.Point(170, 25);
            this.btnFilterDay.Name = "btnFilterDay";
            this.btnFilterDay.Size = new System.Drawing.Size(80, 35);
            this.btnFilterDay.TabIndex = 2;
            this.btnFilterDay.Tag = "Primary";
            this.btnFilterDay.Text = "Uygula";
            this.btnFilterDay.UseVisualStyleBackColor = true;
            this.btnFilterDay.Click += new System.EventHandler(this.BtnFilterDay_Click);
            // 
            // dtpSingleDate
            // 
            this.dtpSingleDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSingleDate.Location = new System.Drawing.Point(15, 28);
            this.dtpSingleDate.Name = "dtpSingleDate";
            this.dtpSingleDate.Size = new System.Drawing.Size(140, 27);
            this.dtpSingleDate.TabIndex = 1;
            // 
            // lblDayFilter
            // 
            this.lblDayFilter.AutoSize = true;
            this.lblDayFilter.Location = new System.Drawing.Point(15, 5);
            this.lblDayFilter.Name = "lblDayFilter";
            this.lblDayFilter.Size = new System.Drawing.Size(129, 20);
            this.lblDayFilter.TabIndex = 0;
            this.lblDayFilter.Text = "Belirli Bir Gün Seç:";
            this.lblDayFilter.Tag = "Muted";
            // 
            // cardRevenue
            // 
            this.cardRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cardRevenue.Controls.Add(this.lblTotalRevenue);
            this.cardRevenue.Controls.Add(this.lblRevenueTitle);
            this.cardRevenue.Location = new System.Drawing.Point(30, 185);
            this.cardRevenue.Name = "cardRevenue";
            this.cardRevenue.Size = new System.Drawing.Size(280, 110);
            this.cardRevenue.TabIndex = 3;
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblTotalRevenue.Location = new System.Drawing.Point(20, 45);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(109, 41);
            this.lblTotalRevenue.TabIndex = 1;
            this.lblTotalRevenue.Text = "0,00 TL";
            // 
            // lblRevenueTitle
            // 
            this.lblRevenueTitle.AutoSize = true;
            this.lblRevenueTitle.Location = new System.Drawing.Point(20, 15);
            this.lblRevenueTitle.Name = "lblRevenueTitle";
            this.lblRevenueTitle.Size = new System.Drawing.Size(155, 20);
            this.lblRevenueTitle.TabIndex = 0;
            this.lblRevenueTitle.Text = "Toplam Satış (Ciro)";
            this.lblRevenueTitle.Tag = "Muted";
            // 
            // cardCost
            // 
            this.cardCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cardCost.Controls.Add(this.lblTotalCost);
            this.cardCost.Controls.Add(this.lblCostTitle);
            this.cardCost.Location = new System.Drawing.Point(330, 185);
            this.cardCost.Name = "cardCost";
            this.cardCost.Size = new System.Drawing.Size(280, 110);
            this.cardCost.TabIndex = 4;
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblTotalCost.Location = new System.Drawing.Point(20, 45);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(109, 41);
            this.lblTotalCost.TabIndex = 1;
            this.lblTotalCost.Text = "0,00 TL";
            // 
            // lblCostTitle
            // 
            this.lblCostTitle.AutoSize = true;
            this.lblCostTitle.Location = new System.Drawing.Point(20, 15);
            this.lblCostTitle.Name = "lblCostTitle";
            this.lblCostTitle.Size = new System.Drawing.Size(149, 20);
            this.lblCostTitle.TabIndex = 0;
            this.lblCostTitle.Text = "Toplam Alış (Gider)";
            this.lblCostTitle.Tag = "Muted";
            // 
            // cardProfit
            // 
            this.cardProfit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardProfit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cardProfit.Controls.Add(this.lblNetProfit);
            this.cardProfit.Controls.Add(this.lblProfitTitle);
            this.cardProfit.Location = new System.Drawing.Point(630, 185);
            this.cardProfit.Name = "cardProfit";
            this.cardProfit.Size = new System.Drawing.Size(290, 110);
            this.cardProfit.TabIndex = 5;
            // 
            // lblNetProfit
            // 
            this.lblNetProfit.AutoSize = true;
            this.lblNetProfit.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblNetProfit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblNetProfit.Location = new System.Drawing.Point(20, 45);
            this.lblNetProfit.Name = "lblNetProfit";
            this.lblNetProfit.Size = new System.Drawing.Size(109, 41);
            this.lblNetProfit.TabIndex = 1;
            this.lblNetProfit.Text = "0,00 TL";
            // 
            // lblProfitTitle
            // 
            this.lblProfitTitle.AutoSize = true;
            this.lblProfitTitle.Location = new System.Drawing.Point(20, 15);
            this.lblProfitTitle.Name = "lblProfitTitle";
            this.lblProfitTitle.Size = new System.Drawing.Size(161, 20);
            this.lblProfitTitle.TabIndex = 0;
            this.lblProfitTitle.Text = "Net Kâr / Genel Durum";
            this.lblProfitTitle.Tag = "Muted";
            // 
            // lblTableTitle
            // 
            this.lblTableTitle.AutoSize = true;
            this.lblTableTitle.Location = new System.Drawing.Point(30, 315);
            this.lblTableTitle.Name = "lblTableTitle";
            this.lblTableTitle.Size = new System.Drawing.Size(258, 20);
            this.lblTableTitle.TabIndex = 6;
            this.lblTableTitle.Text = "FİLTRELENEN DÖNEMDEKİ İŞLEMLER";
            this.lblTableTitle.Tag = "Header";
            // 
            // dgvMovements
            // 
            this.dgvMovements.AllowUserToAddRows = false;
            this.dgvMovements.AllowUserToDeleteRows = false;
            this.dgvMovements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMovements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovements.Location = new System.Drawing.Point(30, 350);
            this.dgvMovements.Name = "dgvMovements";
            this.dgvMovements.ReadOnly = true;
            this.dgvMovements.RowHeadersWidth = 51;
            this.dgvMovements.Size = new System.Drawing.Size(890, 370);
            this.dgvMovements.TabIndex = 7;
            // 
            // RevenueView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvMovements);
            this.Controls.Add(this.lblTableTitle);
            this.Controls.Add(this.cardProfit);
            this.Controls.Add(this.cardCost);
            this.Controls.Add(this.cardRevenue);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblTitle);
            this.Name = "RevenueView";
            this.Size = new System.Drawing.Size(950, 755);
            this.Load += new System.EventHandler(this.RevenueView_Load);
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.cardRevenue.ResumeLayout(false);
            this.cardRevenue.PerformLayout();
            this.cardCost.ResumeLayout(false);
            this.cardCost.PerformLayout();
            this.cardProfit.ResumeLayout(false);
            this.cardProfit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovements)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Label lblDayFilter;
        private System.Windows.Forms.DateTimePicker dtpSingleDate;
        private System.Windows.Forms.Button btnFilterDay;
        private System.Windows.Forms.Label lblRangeFilter;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblAnd;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnFilterRange;
        private System.Windows.Forms.Button btnFilterToday;
        private System.Windows.Forms.Panel cardRevenue;
        private System.Windows.Forms.Label lblRevenueTitle;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Panel cardCost;
        private System.Windows.Forms.Label lblCostTitle;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.Panel cardProfit;
        private System.Windows.Forms.Label lblProfitTitle;
        private System.Windows.Forms.Label lblNetProfit;
        private System.Windows.Forms.Label lblTableTitle;
        private System.Windows.Forms.DataGridView dgvMovements;
    }
}
