using System;
using System.Drawing;
using System.Windows.Forms;
using Orjeen_Stok_Takip.Helpers;
using Orjeen_Stok_Takip.Services;

namespace Orjeen_Stok_Takip.Views
{
    public partial class LoginForm : Form
    {
        private bool _isSignUpMode = false;

        public LoginForm()
        {
            InitializeComponent();
            UIStyleHelper.StyleForm(this, true);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            UpdateMode();
        }

        private void UpdateMode()
        {
            if (_isSignUpMode)
            {
                lblSubtitle.Text = "Yeni personel hesabı oluşturun";
                lblFullNameTag.Visible = true;
                txtFullName.Visible = true;
                btnSubmit.Text = "Kayıt Ol";
                lblSwitchMode.Text = "Zaten hesabınız var mı? Giriş Yapın";
                
                // Adjust positions
                lblEmailTag.Location = new Point(50, 210);
                txtEmail.Location = new Point(50, 235);
                lblPasswordTag.Location = new Point(50, 280);
                txtPassword.Location = new Point(50, 305);
                btnSubmit.Location = new Point(50, 360);
                lblSwitchMode.Location = new Point(50, 420);
                lblError.Location = new Point(50, 455);
            }
            else
            {
                lblSubtitle.Text = "Devam etmek için giriş yapın";
                lblFullNameTag.Visible = false;
                txtFullName.Visible = false;
                btnSubmit.Text = "Giriş Yap";
                lblSwitchMode.Text = "Hesabınız yok mu? Kayıt Olun";
                
                // Move email & password up
                lblEmailTag.Location = new Point(50, 140);
                txtEmail.Location = new Point(50, 165);
                lblPasswordTag.Location = new Point(50, 210);
                txtPassword.Location = new Point(50, 235);
                btnSubmit.Location = new Point(50, 290);
                lblSwitchMode.Location = new Point(50, 350);
                lblError.Location = new Point(50, 385);
            }
            lblError.Text = string.Empty;
        }

        private void LblSwitchMode_Click(object sender, EventArgs e)
        {
            _isSignUpMode = !_isSignUpMode;
            UpdateMode();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void BtnSubmit_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string fullName = txtFullName.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ShowError("E-posta ve şifre boş bırakılamaz.");
                return;
            }

            if (_isSignUpMode && string.IsNullOrEmpty(fullName))
            {
                ShowError("Ad soyad alanı boş bırakılamaz.");
                return;
            }

            btnSubmit.Enabled = false;
            btnSubmit.Text = _isSignUpMode ? "Kaydediliyor..." : "Giriş Yapılıyor...";
            lblError.Text = string.Empty;

            try
            {
                if (_isSignUpMode)
                {
                    bool success = await AuthService.SignUpAsync(email, password, fullName);
                    if (success)
                    {
                        MessageBox.Show("Kayıt başarılı! Lütfen e-postanızı doğrulayın (veya doğrudan giriş yapmayı deneyin).", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _isSignUpMode = false;
                        UpdateMode();
                    }
                    else
                    {
                        ShowError("Kayıt başarısız.");
                    }
                }
                else
                {
                    bool success = await AuthService.SignInAsync(email, password);
                    if (success)
                    {
                        MainForm mainForm = new MainForm();
                        mainForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        ShowError("Hatalı e-posta veya şifre.");
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (message.Contains("Bilinen böyle bir ana bilgisayar yok") || message.Contains("No such host is known"))
                {
                    ShowError("Bağlantı Hatası: Supabase projeniz duraklatılmış (paused) olabilir veya internet bağlantınız kesilmiş. Lütfen Supabase panelinden projenizi aktifleştirip tekrar deneyin.");
                }
                else
                {
                    try
                    {
                        if (message.Trim().StartsWith("{") && message.Trim().EndsWith("}"))
                        {
                            var errObj = Newtonsoft.Json.Linq.JObject.Parse(message);
                            string cleanMsg = errObj["message"]?.ToString() 
                                           ?? errObj["msg"]?.ToString() 
                                           ?? errObj["error_description"]?.ToString() 
                                           ?? message;

                            if (cleanMsg.Contains("Password should be at least 6 characters") || cleanMsg.Contains("should be at least 6 characters"))
                            {
                                cleanMsg = "Şifreniz en az 6 karakter uzunluğunda olmalıdır.";
                            }
                            else if (cleanMsg.Contains("Signup requires a valid email"))
                            {
                                cleanMsg = "Lütfen geçerli bir e-posta adresi girin.";
                            }

                            ShowError($"İşlem Başarısız: {cleanMsg}");
                        }
                        else
                        {
                            ShowError($"İşlem sırasında hata: {message}");
                        }
                    }
                    catch
                    {
                        ShowError($"İşlem sırasında hata: {message}");
                    }
                }
            }
            finally
            {
                btnSubmit.Enabled = true;
                btnSubmit.Text = _isSignUpMode ? "Kayıt Ol" : "Giriş Yap";
            }
        }

        private void ShowError(string msg)
        {
            lblError.Text = msg;
            lblError.ForeColor = UIStyleHelper.DangerColor;
        }

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
