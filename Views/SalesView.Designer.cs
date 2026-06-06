namespace Orjeen_Stok_Takip.Views
{
    partial class SalesView
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
            this.panelTransaction = new System.Windows.Forms.Panel();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.btnSearchBarcode = new System.Windows.Forms.Button();
            this.lblProductInfo = new System.Windows.Forms.Label();
            this.lblMovementType = new System.Windows.Forms.Label();
            this.cmbMovementType = new System.Windows.Forms.ComboBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblHistoryTitle = new System.Windows.Forms.Label();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.panelTransaction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(227, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HIZLI SATIŞ VE STOK HAREKETLERİ";
            this.lblTitle.Tag = "Title";
            // 
            // panelTransaction
            // 
            this.panelTransaction.Controls.Add(this.btnSubmit);
            this.panelTransaction.Controls.Add(this.txtDesc);
            this.panelTransaction.Controls.Add(this.lblDesc);
            this.panelTransaction.Controls.Add(this.txtPrice);
            this.panelTransaction.Controls.Add(this.lblPrice);
            this.panelTransaction.Controls.Add(this.txtQty);
            this.panelTransaction.Controls.Add(this.lblQty);
            this.panelTransaction.Controls.Add(this.cmbMovementType);
            this.panelTransaction.Controls.Add(this.lblMovementType);
            this.panelTransaction.Controls.Add(this.lblProductInfo);
            this.panelTransaction.Controls.Add(this.btnSearchBarcode);
            this.panelTransaction.Controls.Add(this.txtBarcode);
            this.panelTransaction.Controls.Add(this.lblBarcode);
            this.panelTransaction.Location = new System.Drawing.Point(30, 80);
            this.panelTransaction.Name = "panelTransaction";
            this.panelTransaction.Size = new System.Drawing.Size(320, 640);
            this.panelTransaction.TabIndex = 1;
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(20, 20);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(95, 20);
            this.lblBarcode.TabIndex = 0;
            this.lblBarcode.Text = "Ürün Barkodu";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(20, 45);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(170, 27);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBarcode_KeyDown);
            // 
            // btnSearchBarcode
            // 
            this.btnSearchBarcode.Location = new System.Drawing.Point(200, 43);
            this.btnSearchBarcode.Name = "btnSearchBarcode";
            this.btnSearchBarcode.Size = new System.Drawing.Size(100, 30);
            this.btnSearchBarcode.TabIndex = 2;
            this.btnSearchBarcode.Tag = "Primary";
            this.btnSearchBarcode.Text = "Oku";
            this.btnSearchBarcode.UseVisualStyleBackColor = true;
            this.btnSearchBarcode.Click += new System.EventHandler(this.BtnSearchBarcode_Click);
            // 
            // lblProductInfo
            // 
            this.lblProductInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblProductInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProductInfo.Location = new System.Drawing.Point(20, 95);
            this.lblProductInfo.Name = "lblProductInfo";
            this.lblProductInfo.Padding = new System.Windows.Forms.Padding(10);
            this.lblProductInfo.Size = new System.Drawing.Size(280, 120);
            this.lblProductInfo.TabIndex = 3;
            this.lblProductInfo.Text = "Lütfen bir ürün barkodu okutun.";
            // 
            // lblMovementType
            // 
            this.lblMovementType.AutoSize = true;
            this.lblMovementType.Location = new System.Drawing.Point(20, 235);
            this.lblMovementType.Name = "lblMovementType";
            this.lblMovementType.Size = new System.Drawing.Size(81, 20);
            this.lblMovementType.TabIndex = 4;
            this.lblMovementType.Text = "İşlem Türü";
            // 
            // cmbMovementType
            // 
            this.cmbMovementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMovementType.FormattingEnabled = true;
            this.cmbMovementType.Items.AddRange(new object[] {
            "Satış (Stok Çıkışı)",
            "Alış (Stok Girişi)"});
            this.cmbMovementType.Location = new System.Drawing.Point(20, 260);
            this.cmbMovementType.Name = "cmbMovementType";
            this.cmbMovementType.Size = new System.Drawing.Size(280, 28);
            this.cmbMovementType.TabIndex = 5;
            this.cmbMovementType.SelectedIndexChanged += new System.EventHandler(this.CmbMovementType_SelectedIndexChanged);
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(20, 310);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(51, 20);
            this.lblQty.TabIndex = 6;
            this.lblQty.Text = "Miktar";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(20, 335);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(280, 27);
            this.txtQty.TabIndex = 7;
            this.txtQty.Text = "1";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(20, 385);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(79, 20);
            this.lblPrice.TabIndex = 8;
            this.lblPrice.Text = "Birim Fiyat";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(20, 410);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(280, 27);
            this.txtPrice.TabIndex = 9;
            this.txtPrice.Text = "0.00";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(20, 460);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(70, 20);
            this.lblDesc.TabIndex = 10;
            this.lblDesc.Text = "Açıklama";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(20, 485);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(280, 27);
            this.txtDesc.TabIndex = 11;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(20, 540);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(280, 45);
            this.btnSubmit.TabIndex = 12;
            this.btnSubmit.Tag = "Primary";
            this.btnSubmit.Text = "İşlemi Tamamla";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // lblHistoryTitle
            // 
            this.lblHistoryTitle.AutoSize = true;
            this.lblHistoryTitle.Location = new System.Drawing.Point(370, 55);
            this.lblHistoryTitle.Name = "lblHistoryTitle";
            this.lblHistoryTitle.Size = new System.Drawing.Size(183, 20);
            this.lblHistoryTitle.TabIndex = 2;
            this.lblHistoryTitle.Text = "STOK HAREKET GEÇMİŞİ";
            this.lblHistoryTitle.Tag = "Header";
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Location = new System.Drawing.Point(370, 80);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersWidth = 51;
            this.dgvHistory.Size = new System.Drawing.Size(550, 640);
            this.dgvHistory.TabIndex = 3;
            // 
            // SalesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.lblHistoryTitle);
            this.Controls.Add(this.panelTransaction);
            this.Controls.Add(this.lblTitle);
            this.Name = "SalesView";
            this.Size = new System.Drawing.Size(950, 755);
            this.Load += new System.EventHandler(this.SalesView_Load);
            this.panelTransaction.ResumeLayout(false);
            this.panelTransaction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelTransaction;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button btnSearchBarcode;
        private System.Windows.Forms.Label lblProductInfo;
        private System.Windows.Forms.Label lblMovementType;
        private System.Windows.Forms.ComboBox cmbMovementType;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblHistoryTitle;
        private System.Windows.Forms.DataGridView dgvHistory;
    }
}
