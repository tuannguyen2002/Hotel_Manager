using QL_KhachSan.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KhachSan
{
    public partial class FormCNPhong : Form
    {
        PhongCTRL p = new PhongCTRL();
        LoaiPhongCTRL lp = new LoaiPhongCTRL();
        Connection conn = new Connection();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public FormCNPhong()
        {
            InitializeComponent();
        }
        private void LoadDGV()
        {
            dt = new DataTable();
            dt = p.GetData();
            dgvPhong.DataSource = dt;
        }
        private void LoadCBB()
        {
            dt = new DataTable();
            dt = lp.GetData();
            CBBLoaiPhong.DataSource = dt;
            CBBLoaiPhong.DisplayMember = CBBLoaiPhong.ValueMember = "MaLoaiPhong";
        }
        private void FormCNPhong_Load(object sender, EventArgs e)
        {
            LoadDGV();
            LoadCBB();
        }

        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chondong = -1;
            chondong = dgvPhong.CurrentCell.RowIndex;
            txtMaphong.Text = dgvPhong.Rows[chondong].Cells[0].Value.ToString();
            txtTenphong.Text = dgvPhong.Rows[chondong].Cells[2].Value.ToString();
            CBBLoaiPhong.SelectedValue = dgvPhong.Rows[chondong].Cells[1].Value.ToString();
            txtTrangThai.Text = dgvPhong.Rows[chondong].Cells[3].Value.ToString();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string maphong = txtMaphong.Text;
            string tenphong = txtTenphong.Text;
            string maloaiphong = CBBLoaiPhong.SelectedValue.ToString();
            string tinhtrang = txtTrangThai.Text;
            p.Insert(maphong, tenphong, maloaiphong, tinhtrang);
            LoadDGV();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            string maphong = txtMaphong.Text;
            string tenphong = txtTenphong.Text;
            string maloaiphong = CBBLoaiPhong.SelectedValue.ToString();
            string tinhtrang = txtTrangThai.Text;
            p.Update(maphong, tenphong, maloaiphong, tinhtrang);
            LoadDGV();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            string maphong = txtMaphong.Text;
            string tenphong = txtTenphong.Text;
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng: " + tenphong + " không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (result == DialogResult.Yes)
            {
                p.Delete(maphong);
            }
            LoadDGV();
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            string tukhoa = txtTimKiem.Text;
            dt = new DataTable();
            dt = p.search(tukhoa);
            dgvPhong.DataSource = dt;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tukhoa = txtTimKiem.Text;
            dt = new DataTable();
            dt = p.search(tukhoa);
            dgvPhong.DataSource = dt;
        }

        private void CBBLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
