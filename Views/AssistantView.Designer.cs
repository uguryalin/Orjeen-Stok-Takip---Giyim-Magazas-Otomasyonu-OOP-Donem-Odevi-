namespace Orjeen_Stok_Takip.Views
{
    partial class AssistantView
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
            this.panelChatBg = new System.Windows.Forms.Panel();
            this.rtbChat = new System.Windows.Forms.RichTextBox();
            this.panelInputContainer = new System.Windows.Forms.Panel();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblHint = new System.Windows.Forms.Label();
            this.panelChatBg.SuspendLayout();
            this.panelInputContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(227, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "YAPAY ZEKA STOK DANIŞMANI";
            this.lblTitle.Tag = "Title";
            // 
            // panelChatBg
            // 
            this.panelChatBg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChatBg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.panelChatBg.Controls.Add(this.rtbChat);
            this.panelChatBg.Location = new System.Drawing.Point(30, 80);
            this.panelChatBg.Name = "panelChatBg";
            this.panelChatBg.Padding = new System.Windows.Forms.Padding(15);
            this.panelChatBg.Size = new System.Drawing.Size(890, 490);
            this.panelChatBg.TabIndex = 1;
            // 
            // rtbChat
            // 
            this.rtbChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbChat.Location = new System.Drawing.Point(15, 15);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.ReadOnly = true;
            this.rtbChat.Size = new System.Drawing.Size(860, 460);
            this.rtbChat.TabIndex = 0;
            this.rtbChat.Text = "";
            // 
            // panelInputContainer
            // 
            this.panelInputContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInputContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.panelInputContainer.Controls.Add(this.btnSend);
            this.panelInputContainer.Controls.Add(this.txtInput);
            this.panelInputContainer.Location = new System.Drawing.Point(30, 595);
            this.panelInputContainer.Name = "panelInputContainer";
            this.panelInputContainer.Size = new System.Drawing.Size(890, 65);
            this.panelInputContainer.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(760, 15);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(110, 35);
            this.btnSend.TabIndex = 1;
            this.btnSend.Tag = "Primary";
            this.btnSend.Text = "Gönder";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(15, 19);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(730, 27);
            this.txtInput.TabIndex = 0;
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtInput_KeyDown);
            // 
            // lblHint
            // 
            this.lblHint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHint.AutoSize = true;
            this.lblHint.Location = new System.Drawing.Point(30, 680);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(438, 20);
            this.lblHint.TabIndex = 3;
            this.lblHint.Text = "Yapay zekaya stok durumunu, kritik ürünleri veya sipariş önerilerini sorun.";
            this.lblHint.Tag = "Muted";
            // 
            // AssistantView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.panelInputContainer);
            this.Controls.Add(this.panelChatBg);
            this.Controls.Add(this.lblTitle);
            this.Name = "AssistantView";
            this.Size = new System.Drawing.Size(950, 755);
            this.Load += new System.EventHandler(this.AssistantView_Load);
            this.panelChatBg.ResumeLayout(false);
            this.panelInputContainer.ResumeLayout(false);
            this.panelInputContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelChatBg;
        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.Panel panelInputContainer;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblHint;
    }
}
