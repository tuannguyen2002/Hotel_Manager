using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace QL_KhachSan
{
    public partial class FormTKPhong : Form
    {
        tk_PhongCTRL phong = new tk_PhongCTRL();
        Connection a = new Connection();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public FormTKPhong()
        {
            InitializeComponent();
        }

        private void FormTKPhong_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt = phong.GetData();
            dgvTKP.DataSource = dt;
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            FormTKPhong_Load(sender, e);
        }

        private void cbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbThang.SelectedIndex = 12;
        }

        private void cbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            String[,] array = new String[,]
            {
                {"01-01", "02-01"},
                {"02-01", "03-01"},
                {"03-01", "04-01"},
                {"04-01", "05-01"},
                {"05-01", "06-01"},
                {"06-01", "07-01"},
                {"07-01", "08-01"},
                {"08-01", "09-01"},
                {"09-01", "10-01"},
                {"10-01", "11-01"},
                {"11-01", "12-01"},
                {"12-01", "12-31"},
                {"01-01", "12-31"},
            };
            String nam = "";
            String tgbatdau = "";
            String tgketthuc = "";
            if (cbNam.SelectedIndex == 4)
            {
                tgbatdau = "2022-01-01";
                tgketthuc = "2026-01-01";
            }
            else
            {
                if (cbNam.SelectedIndex == 0)
                    nam = "2022-";
                if (cbNam.SelectedIndex == 1)
                    nam = "2023-";
                if (cbNam.SelectedIndex == 2)
                    nam = "2024-";
                if (cbNam.SelectedIndex == 3)
                    nam = "2025-";
                tgbatdau = nam + array[cbThang.SelectedIndex, 0];
                tgketthuc = nam + array[cbThang.SelectedIndex, 1];
            }
            conn = new SqlConnection();
            conn = a.Getconnection();
            String sql = "TKP '" + tgbatdau + "', '" + tgketthuc + "'";
            cmd = new SqlCommand(sql, conn);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dgvTKP.DataSource = dt;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string tukhoa = txtSearch.Text;
            dt = new DataTable();
            dt = phong.search(tukhoa);
            dgvTKP.DataSource = dt;
        }
    }
}
