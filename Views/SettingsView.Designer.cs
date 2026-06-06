namespace Orjeen_Stok_Takip.Views
{
    partial class SettingsView
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
            this.lblUrl = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.lblGemini = new System.Windows.Forms.Label();
            this.txtGemini = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(187, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "API VE VERİTABANI AYARLARI";
            this.lblTitle.Tag = "Header";
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(30, 70);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(101, 20);
            this.lblUrl.TabIndex = 1;
            this.lblUrl.Text = "Supabase URL";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(30, 95);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(420, 27);
            this.txtUrl.TabIndex = 2;
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(30, 140);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(140, 20);
            this.lblKey.TabIndex = 3;
            this.lblKey.Text = "Supabase Anon Key";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(30, 165);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(420, 27);
            this.txtKey.TabIndex = 4;
            this.txtKey.UseSystemPasswordChar = true;
            // 
            // lblGemini
            // 
            this.lblGemini.AutoSize = true;
            this.lblGemini.Location = new System.Drawing.Point(30, 210);
            this.lblGemini.Name = "lblGemini";
            this.lblGemini.Size = new System.Drawing.Size(136, 20);
            this.lblGemini.TabIndex = 5;
            this.lblGemini.Text = "Gemini AI API Key";
            // 
            // txtGemini
            // 
            this.txtGemini.Location = new System.Drawing.Point(30, 235);
            this.txtGemini.Name = "txtGemini";
            this.txtGemini.Size = new System.Drawing.Size(420, 27);
            this.txtGemini.TabIndex = 6;
            this.txtGemini.UseSystemPasswordChar = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(30, 290);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(420, 40);
            this.btnSave.TabIndex = 7;
            this.btnSave.Tag = "Primary";
            this.btnSave.Text = "Ayarları Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(30, 340);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(420, 25);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtGemini);
            this.Controls.Add(this.lblGemini);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.lblTitle);
            this.Name = "SettingsView";
            this.Size = new System.Drawing.Size(480, 380);
            this.Load += new System.EventHandler(this.SettingsView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label lblGemini;
        private System.Windows.Forms.TextBox txtGemini;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblStatus;
    }
}
