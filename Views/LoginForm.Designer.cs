namespace Orjeen_Stok_Takip.Views
{
    partial class LoginForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.titleBar = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblSwitchMode = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.lblEmailTag = new System.Windows.Forms.Label();
            this.lblPasswordTag = new System.Windows.Forms.Label();
            this.lblFullNameTag = new System.Windows.Forms.Label();
            this.titleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.Controls.Add(this.btnClose);
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(400, 40);
            this.titleBar.TabIndex = 0;
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(360, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(50, 60);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(185, 25);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "ORJEEN STOK TAKİP";
            this.lblTitle.Tag = "Title";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Location = new System.Drawing.Point(50, 95);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(193, 17);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "Devam etmek için giriş yapın";
            this.lblSubtitle.Tag = "Muted";
            // 
            // lblFullNameTag
            // 
            this.lblFullNameTag.AutoSize = true;
            this.lblFullNameTag.Location = new System.Drawing.Point(50, 140);
            this.lblFullNameTag.Name = "lblFullNameTag";
            this.lblFullNameTag.Size = new System.Drawing.Size(81, 20);
            this.lblFullNameTag.TabIndex = 3;
            this.lblFullNameTag.Text = "Ad Soyad";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(50, 165);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(300, 27);
            this.txtFullName.TabIndex = 4;
            // 
            // lblEmailTag
            // 
            this.lblEmailTag.AutoSize = true;
            this.lblEmailTag.Location = new System.Drawing.Point(50, 210);
            this.lblEmailTag.Name = "lblEmailTag";
            this.lblEmailTag.Size = new System.Drawing.Size(60, 20);
            this.lblEmailTag.TabIndex = 5;
            this.lblEmailTag.Text = "E-posta";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(50, 235);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(300, 27);
            this.txtEmail.TabIndex = 6;
            // 
            // lblPasswordTag
            // 
            this.lblPasswordTag.AutoSize = true;
            this.lblPasswordTag.Location = new System.Drawing.Point(50, 280);
            this.lblPasswordTag.Name = "lblPasswordTag";
            this.lblPasswordTag.Size = new System.Drawing.Size(39, 20);
            this.lblPasswordTag.TabIndex = 7;
            this.lblPasswordTag.Text = "Şifre";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(50, 305);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(300, 27);
            this.txtPassword.TabIndex = 8;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(50, 360);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(300, 45);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Tag = "Primary";
            this.btnSubmit.Text = "Giriş Yap";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // lblSwitchMode
            // 
            this.lblSwitchMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSwitchMode.Location = new System.Drawing.Point(50, 420);
            this.lblSwitchMode.Name = "lblSwitchMode";
            this.lblSwitchMode.Size = new System.Drawing.Size(300, 25);
            this.lblSwitchMode.TabIndex = 10;
            this.lblSwitchMode.Text = "Hesabınız yok mu? Kayıt Olun";
            this.lblSwitchMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSwitchMode.Click += new System.EventHandler(this.LblSwitchMode_Click);
            // 
            // lblError
            // 
            this.lblError.ForeColor = System.Drawing.Color.Tomato;
            this.lblError.Location = new System.Drawing.Point(50, 455);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(300, 50);
            this.lblError.TabIndex = 11;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 550);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblSwitchMode);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPasswordTag);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmailTag);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblFullNameTag);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.titleBar);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orjeen Giriş";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.titleBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblSwitchMode;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblEmailTag;
        private System.Windows.Forms.Label lblPasswordTag;
        private System.Windows.Forms.Label lblFullNameTag;
    }
}
