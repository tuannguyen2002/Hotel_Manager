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
    public partial class FormTK_DoanhThu : Form
    {
        tk_dvCTRL dv = new tk_dvCTRL();
        tk_PhongCTRL phong = new tk_PhongCTRL();
        NhanVienCTRL nv = new NhanVienCTRL();
        hoadonCTRL hd = new hoadonCTRL();
        Connection a = new Connection();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public FormTK_DoanhThu()
        {
            InitializeComponent();
        }

        private void FormTK_DoanhThu_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt = dv.GetDataDTDV();
            dgvDTDV.DataSource = dt;

            dt = phong.GetDataDTP();
            dgvDTP.DataSource = dt;

            dt = nv.GetDataDTNV();
            dgvDTNV.DataSource = dt;

            dt = hd.GetDataDTTong();
            dgvDTHD.DataSource = dt;
        }

        private void dgvDTDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            FormTK_DoanhThu_Load(sender, e);
        }

        private void cbthang_SelectedIndexChanged(object sender, EventArgs e)
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

            //Lọc dịch vụ
            String sql = "TKDTDV '" + tgbatdau + "', '" + tgketthuc + "'";
            cmd = new SqlCommand(sql, conn);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dgvDTDV.DataSource = dt;

            //lọc phòng
            sql = "TKDTP '" + tgbatdau + "', '" + tgketthuc + "'";
            cmd = new SqlCommand(sql, conn);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dgvDTP.DataSource = dt;
        }

        private void cbnam_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbthang.SelectedIndex = 12;
        }

        private void txtSearchDT_TextChanged(object sender, EventArgs e)
        {
            string tukhoa = txtSearchDT.Text;
            dt = new DataTable();
            dt = phong.searchTKP(tukhoa);
            dgvDTP.DataSource = dt;

            dt = new DataTable();
            dt = nv.searchDTNV(tukhoa);
            dgvDTNV.DataSource = dt;

            dt = new DataTable();
            dt = dv.searchTKDV(tukhoa);
            dgvDTDV.DataSource = dt;
        }
    }
}
