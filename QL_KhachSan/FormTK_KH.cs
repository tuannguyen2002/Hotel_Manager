using QL_KhachSan.Class;
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
    public partial class FormTK_KH : Form
    {
        tk_khCTRL kh = new tk_khCTRL();
        Connection a = new Connection();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public FormTK_KH()
        {
            InitializeComponent();
        }

        private void FormTK_KH_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt = kh.GetData();
            dgvTKKH.DataSource = dt;
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FormTK_KH_Load(sender, e);
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string tukhoa = txtsearch.Text;
            dt = new DataTable();
            dt = kh.search(tukhoa);
            dgvTKKH.DataSource = dt;
        }

        private void cbTKKH_SelectedIndexChanged(object sender, EventArgs e)
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
            if (cbnam.SelectedIndex == 4)
            {
                tgbatdau = "2022-01-01";
                tgketthuc = "2026-01-01";
            }
            else
            {
                if (cbnam.SelectedIndex == 0)
                    nam = "2022-";
                if (cbnam.SelectedIndex == 1)
                    nam = "2023-";
                if (cbnam.SelectedIndex == 2)
                    nam = "2024-";
                if (cbnam.SelectedIndex == 3)
                    nam = "2025-";
                tgbatdau = nam + array[cbthang.SelectedIndex, 0];
                tgketthuc = nam + array[cbthang.SelectedIndex, 1];
            }
            conn = new SqlConnection();
            conn = a.Getconnection();
            String sql = "TKKH '" + tgbatdau + "', '" + tgketthuc + "'";
            cmd = new SqlCommand(sql, conn);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dgvTKKH.DataSource = dt;
        }

        private void cbnam_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbthang.SelectedIndex = 12;
        }
    }
}
