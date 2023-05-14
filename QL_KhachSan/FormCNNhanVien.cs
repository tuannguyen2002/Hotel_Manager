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
    public partial class FormCNNhanVien : Form
    {
        NhanVienCTRL nv = new NhanVienCTRL();
        Connection conn = new Connection();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public FormCNNhanVien()
        {
            InitializeComponent();
        }
        private void LoadDGV()
        {
            dt = new DataTable();
            dt = nv.GetData();
            dgvNhanVien.DataSource = dt;
        }
        private void FormCNNhanVien_Load(object sender, EventArgs e)
        {
            LoadDGV();
        }

        private void ButtonThem_Click(object sender, EventArgs e)
        {
            string manv = txtManv.Text;
            string tennv = txtTennv.Text;
            bool gt;
            if (rBtnNam.Checked) gt = true;
            else gt = false;
            string sdt = txtSDT.Text;
            string cccd = txtCCCD.Text;
            string chucvu = txtChucVu.Text;
            float luong = float.Parse(txtLuong.Text);
            nv.Insert(manv,tennv,gt,sdt,cccd,chucvu,luong);
            LoadDGV();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chondong = -1;
            chondong = dgvNhanVien.CurrentCell.RowIndex;
            txtManv.Text = dgvNhanVien.Rows[chondong].Cells[0].Value.ToString();
            txtTennv.Text = dgvNhanVien.Rows[chondong].Cells[1].Value.ToString();
            
            if (dgvNhanVien.Rows[chondong].Cells[2].Value.ToString() == "True")
            {
                rBtnNam.Checked = true;
            }

            else
            {
                rBtnNu.Checked = true;  
            }
            
            txtSDT.Text = dgvNhanVien.Rows[chondong].Cells[3].Value.ToString();
            txtCCCD.Text = dgvNhanVien.Rows[chondong].Cells[4].Value.ToString();
            txtChucVu.Text = dgvNhanVien.Rows[chondong].Cells[5].Value.ToString();
            txtLuong.Text = dgvNhanVien.Rows[chondong].Cells[6].Value.ToString();
        }

        private void ButtonSua_Click(object sender, EventArgs e)
        {
            string manv = txtManv.Text;
            string tennv = txtTennv.Text;
            bool gt;
            if (rBtnNam.Checked) gt = true;
            else gt = false;
            string sdt = txtSDT.Text;
            string cccd = txtCCCD.Text;
            string chucvu = txtChucVu.Text;
            float luong = float.Parse(txtLuong.Text);
            nv.Update(manv, tennv, gt, sdt, cccd, chucvu, luong);
            LoadDGV();
        }

        private void ButtonXoa_Click(object sender, EventArgs e)
        {
            string manv = txtManv.Text;
            string tennv = txtTennv.Text;
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên: " + tennv + " không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (result == DialogResult.Yes)
            {
                nv.Delete(manv);
            }
            LoadDGV();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string tukhoa = txtTimKiem.Text;
            dt = new DataTable();
            dt = nv.search(tukhoa);
            dgvNhanVien.DataSource = dt;
        }

        private void iconPictureBoxSearch_Click(object sender, EventArgs e)
        {
            string tukhoa = txtTimKiem.Text;
            dt = new DataTable();
            dt = nv.search(tukhoa);
            dgvNhanVien.DataSource = dt;
        }
    }
}
