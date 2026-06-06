using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Orjeen_Stok_Takip.Helpers
{
    public static class UIStyleHelper
    {
        // Colors
        public static readonly Color BgColor = Color.FromArgb(15, 23, 42); // #0F172A
        public static readonly Color PanelColor = Color.FromArgb(30, 41, 59); // #1E293B
        public static readonly Color BorderColor = Color.FromArgb(51, 65, 85); // #334155
        public static readonly Color PrimaryColor = Color.FromArgb(59, 130, 246); // #3B82F6
        public static readonly Color PrimaryHover = Color.FromArgb(37, 99, 235); // #2563EB
        public static readonly Color AccentColor = Color.FromArgb(20, 184, 166); // #14B8A6 (Teal)
        public static readonly Color SuccessColor = Color.FromArgb(16, 185, 129); // #10B981
        public static readonly Color DangerColor = Color.FromArgb(239, 68, 68); // #EF4444
        public static readonly Color TextColor = Color.FromArgb(248, 250, 252); // #F8FAFC
        public static readonly Color TextMuted = Color.FromArgb(148, 163, 184); // #94A3B8

        // Fonts
        public static readonly Font HeaderFont = new Font("Segoe UI", 12F, FontStyle.Bold);
        public static readonly Font TitleFont = new Font("Segoe UI", 18F, FontStyle.Bold);
        public static readonly Font RegularFont = new Font("Segoe UI", 10F, FontStyle.Regular);
        public static readonly Font RegularBoldFont = new Font("Segoe UI", 10F, FontStyle.Bold);
        public static readonly Font SmallFont = new Font("Segoe UI", 8.5F, FontStyle.Regular);

        public static void StyleForm(Form form, bool borderless = true)
        {
            form.BackColor = BgColor;
            form.ForeColor = TextColor;
            form.Font = RegularFont;

            if (borderless)
            {
                form.FormBorderStyle = FormBorderStyle.None;
            }
            ApplyDarkStyle(form);
        }

        public static void ApplyDarkStyle(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is Panel panel)
                {
                    if (panel.Name == "titleBar")
                    {
                        panel.BackColor = BgColor;
                    }
                    else if (panel.BackColor == SystemColors.Control || panel.BackColor == Color.Transparent || panel.BackColor == Color.FromArgb(240, 240, 240))
                    {
                        panel.BackColor = PanelColor;
                    }
                    panel.ForeColor = TextColor;
                    ApplyDarkStyle(panel);
                }
                else if (ctrl is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 1;
                    
                    if (btn.Name.Contains("Primary") || btn.Tag?.ToString() == "Primary")
                    {
                        btn.BackColor = PrimaryColor;
                        btn.FlatAppearance.BorderColor = PrimaryColor;
                        btn.ForeColor = Color.White;
                    }
                    else if (btn.Name.Contains("Danger") || btn.Tag?.ToString() == "Danger")
                    {
                        btn.BackColor = DangerColor;
                        btn.FlatAppearance.BorderColor = DangerColor;
                        btn.ForeColor = Color.White;
                    }
                    else if (btn.Name.Contains("Success") || btn.Tag?.ToString() == "Success")
                    {
                        btn.BackColor = SuccessColor;
                        btn.FlatAppearance.BorderColor = SuccessColor;
                        btn.ForeColor = Color.White;
                    }
                    else
                    {
                        btn.BackColor = BorderColor;
                        btn.FlatAppearance.BorderColor = BorderColor;
                        btn.ForeColor = TextColor;
                    }
                    btn.Font = RegularBoldFont;
                    btn.Cursor = Cursors.Hand;
                }
                else if (ctrl is Label lbl)
                {
                    if (lbl.Tag?.ToString() == "Title")
                    {
                        lbl.Font = TitleFont;
                        lbl.ForeColor = TextColor;
                    }
                    else if (lbl.Tag?.ToString() == "Header")
                    {
                        lbl.Font = HeaderFont;
                        lbl.ForeColor = TextColor;
                    }
                    else if (lbl.Tag?.ToString() == "Muted")
                    {
                        lbl.Font = SmallFont;
                        lbl.ForeColor = TextMuted;
                    }
                    else
                    {
                        lbl.Font = RegularFont;
                        lbl.ForeColor = TextColor;
                    }
                }
                else if (ctrl is TextBox txt)
                {
                    txt.BackColor = PanelColor;
                    txt.ForeColor = TextColor;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                    txt.Font = RegularFont;
                }
                else if (ctrl is ComboBox cmb)
                {
                    cmb.BackColor = PanelColor;
                    cmb.ForeColor = TextColor;
                    cmb.FlatStyle = FlatStyle.Flat;
                    cmb.Font = RegularFont;
                }
                else if (ctrl is DataGridView dgv)
                {
                    dgv.BackgroundColor = PanelColor;
                    dgv.ForeColor = TextColor;
                    dgv.GridColor = BorderColor;
                    dgv.BorderStyle = BorderStyle.None;
                    dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                    dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                    
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = BgColor;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = TextColor;
                    dgv.ColumnHeadersDefaultCellStyle.Font = RegularBoldFont;
                    dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = BgColor;
                    
                    dgv.DefaultCellStyle.BackColor = PanelColor;
                    dgv.DefaultCellStyle.ForeColor = TextColor;
                    dgv.DefaultCellStyle.Font = RegularFont;
                    dgv.DefaultCellStyle.SelectionBackColor = PrimaryColor;
                    dgv.DefaultCellStyle.SelectionForeColor = Color.White;

                    dgv.RowHeadersVisible = false;
                    dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgv.AllowUserToResizeRows = false;
                    dgv.RowTemplate.Height = 35;
                }
                else
                {
                    ApplyDarkStyle(ctrl);
                }
            }
        }

        public static void SetRoundedRegion(Control control, int radius)
        {
            if (control.Width == 0 || control.Height == 0) return;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            control.Region = new Region(path);
        }

        public static void DrawBorder(Control control, Graphics g)
        {
            using (Pen pen = new Pen(BorderColor, 1))
            {
                g.DrawRectangle(pen, 0, 0, control.Width - 1, control.Height - 1);
            }
        }
    }
}
