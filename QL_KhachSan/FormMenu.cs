using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KhachSan
{
    public partial class FormMenu : Form
    {
        private Form currentChildForm;
        private IconButton currentBtn;
        bool sidebarExpand;

        public FormMenu()
        {
            InitializeComponent();
            customizeDesing();
            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

        }
        private void lockIconbtn(bool t)
        {
            iconBtnDanhmuc.Enabled = iconBtnQLphong.Enabled = iconBtnThongke.Enabled = t;
        }

        private void customizeDesing()
        {
            panelDanhmuc.Visible = false;
            panelQLphong.Visible = false;
            panelThongke.Visible = false;

        }
        private struct RBGcolors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                //Current Child Form Icon
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void hideSubMenu()
        {
            if (panelDanhmuc.Visible == true)
                panelDanhmuc.Visible = false;
            if (panelQLphong.Visible == true)
                panelQLphong.Visible = false;
            if (panelThongke.Visible == true)
                panelThongke.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
        }
        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            SidebarTimer.Start();
        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                customizeDesing();
                Sidebar.Width -= 10;
                if (Sidebar.Width == Sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    SidebarTimer.Stop();
                    customizeDesing();
                    lockIconbtn(false);
                }
            }
            else
            {
                Sidebar.Width += 10;
                if (Sidebar.Width == Sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    SidebarTimer.Stop();
                    lockIconbtn(true);
                }

            }
        }

        private void iconCurrentChildForm_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            Reset();
            hideSubMenu();
        }
        private void Reset()
        {
            DisableButton();
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lblTitleChildForm.Text = "Home";
        }
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitlebar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #region DanhMuc
        private void iconBtnDanhmuc_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RBGcolors.color1);
            showSubMenu(panelDanhmuc);
        }

        private void iconBtnCNphong_Click(object sender, EventArgs e)
        {
            //code
            OpenChildForm(new FormCNPhong());
        }

        private void iconBtnCNdinhvu_Click(object sender, EventArgs e)
        {
            //code
            OpenChildForm(new FormCNDichVu());
        }

        private void iconBtnCNnhanvien_Click(object sender, EventArgs e)
        {
            //code
            OpenChildForm(new FormCNNhanVien());
        }

        private void iconBtnCNloaiphong_Click(object sender, EventArgs e)
        {
            //code
            OpenChildForm(new FormCNLoaiPhong());
        }
        private void iconButtonCNKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCNKhachHang());
        }
        #endregion
        #region Quan Ly Phong
        private void iconBtnQLphong_Click(object sender, EventArgs e)
        {
            showSubMenu(panelQLphong);
            ActivateButton(sender, RBGcolors.color2);
        }

        private void iconBtnChothuephong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormChoThuePhong1());
        }

        private void iconBtnSudungdichvu_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region Thong Ke
        private void iconBtnThongke_Click(object sender, EventArgs e)
        {
            showSubMenu(panelThongke);
            ActivateButton(sender, RBGcolors.color3);
        }

        private void iconBtnTKKH_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormTK_KH());
        }

        private void iconBtnTKphong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormTKPhong());
        }

        private void iconBtnTKdv_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormTK_DV());
        }

        private void iconBtTKdoanhthu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormTK_DoanhThu());
        }
        #endregion

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {

        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            OpenChildForm(new FormChoThuePhong1());
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Login form1 = new Login();
            this.Hide();
            form1.ShowDialog();
            this.Show();
        }
    }
}
