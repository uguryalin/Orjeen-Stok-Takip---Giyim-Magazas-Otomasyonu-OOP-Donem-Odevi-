using System;
using System.Drawing;
using System.Windows.Forms;
using Orjeen_Stok_Takip.Helpers;
using Orjeen_Stok_Takip.Services;

namespace Orjeen_Stok_Takip.Views
{
    public partial class MainForm : Form
    {
        private UserControl? _currentView;
        private Button? _activeButton;

        public MainForm()
        {
            InitializeComponent();
            UIStyleHelper.StyleForm(this, true);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Set User Profile UI
            if (AuthService.CurrentProfile != null)
            {
                lblUserName.Text = AuthService.CurrentProfile.FullName ?? "Kullanıcı";
                lblUserRole.Text = $"{AuthService.CurrentProfile.Role} | {AuthService.CurrentProfile.Email}";
            }
            else
            {
                lblUserName.Text = "Yeni Personel";
                lblUserRole.Text = "Staff";
            }

            // Load Default View
            ShowView(new DashboardView(), btnDashboard);
        }

        private void ShowView(UserControl view, Button menuButton)
        {
            // Clean up previous view
            if (_currentView != null)
            {
                contentPanel.Controls.Remove(_currentView);
                _currentView.Dispose();
            }

            // Set new view
            _currentView = view;
            _currentView.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(_currentView);

            // Highlight Active Button
            if (_activeButton != null)
            {
                _activeButton.BackColor = Color.Transparent;
            }

            _activeButton = menuButton;
            _activeButton.BackColor = UIStyleHelper.PrimaryColor;
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn == btnDashboard)
                {
                    ShowView(new DashboardView(), btnDashboard);
                }
                else if (btn == btnProducts)
                {
                    ShowView(new ProductView(), btnProducts);
                }
                else if (btn == btnCategories)
                {
                    ShowView(new CategoryView(), btnCategories);
                }
                else if (btn == btnSales)
                {
                    ShowView(new SalesView(), btnSales);
                }
                else if (btn == btnRevenue)
                {
                    ShowView(new RevenueView(), btnRevenue);
                }
                else if (btn == btnAssistant)
                {
                    ShowView(new AssistantView(), btnAssistant);
                }
                else if (btn == btnSettings)
                {
                    var settingsView = new SettingsView();
                    // Optional: reload things if needed when settings are saved
                    ShowView(settingsView, btnSettings);
                }
            }
        }

        private async void BtnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                await AuthService.SignOutAsync();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                btnMaximize.Text = "▢";
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                btnMaximize.Text = "❐";
            }
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Dragging code for titleBar
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }
    }
}
