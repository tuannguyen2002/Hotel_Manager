using QL_KhachSan.Class;
using QL_KhachSan.CTRL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KhachSan
{
    public partial class Login : Form
    {
        private bool Check;
        TaiKhoanCTRL taikhoan = new TaiKhoanCTRL();
        Connection conn = new Connection();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public Login()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
            iconButton1.Visible = true;
            iconButton2.Visible = false;
            labelCheck.Visible = false;
            labelCheckNull.Visible = false;
            this.Size = new System.Drawing.Size(996, 680);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = false;
            iconButton1.Visible = false;
            iconButton2.Visible = true;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
            iconButton1.Visible = true;
            iconButton2.Visible = false;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string pass = txtPass.Text;

            if (taikhoan.CheckTaiKhoan(user, pass) == false)
            {
                labelCheck.Visible = true;
                labelCheckNull.Visible = false;

                // MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác");
            }
            else if (user == "" && pass == "")
            {
                labelCheckNull.Visible = true;
                labelCheck.Visible = false;
            }
            else
            {
                FormMenu form2 = new FormMenu();
                this.Hide();
                form2.ShowDialog();
                this.Show();
                //form2.Show();

            }
        }
    }
}
