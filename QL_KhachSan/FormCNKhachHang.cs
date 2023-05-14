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
    public partial class FormCNKhachHang : Form
    {
        private Form currentChildForm;
        KhachHangCTRL kh = new KhachHangCTRL();
        Connection conn = new Connection();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public FormCNKhachHang()
        {
            InitializeComponent();
        }
        private void LoadDGV()
        {
            dt = new DataTable();
            dt = kh.GetData();
            dgvKH.DataSource = dt;
        }
        private void FormCNKhachHang_Load(object sender, EventArgs e)
        {
            LoadDGV();
        }
        private void ButtonThem_Click(object sender, EventArgs e)
        {
            string makh = txtMakh.Text;
            string tenkh = txtTenkh.Text;
            bool gt;
            if (rBtnNam.Checked) gt = true;
            else gt = false;
            string sdt = txtSDT.Text;
            string cccd = txtCCCD.Text;
            string stk = txtSTK.Text;
            kh.Insert(makh, tenkh, gt, sdt, cccd, stk);
            LoadDGV();
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chondong = -1;
            chondong = dgvKH.CurrentCell.RowIndex;
            txtMakh.Text = dgvKH.Rows[chondong].Cells[0].Value.ToString();
            txtTenkh.Text = dgvKH.Rows[chondong].Cells[1].Value.ToString();

            if (dgvKH.Rows[chondong].Cells[2].Value.ToString() == "True")
            {
                rBtnNam.Checked = true;
            }

            else
            {
                rBtnNu.Checked = true;
            }

            txtSDT.Text = dgvKH.Rows[chondong].Cells[3].Value.ToString();
            txtCCCD.Text = dgvKH.Rows[chondong].Cells[4].Value.ToString();
            txtSTK.Text = dgvKH.Rows[chondong].Cells[5].Value.ToString();
        }

        private void ButtonSua_Click(object sender, EventArgs e)
        {
            string makh = txtMakh.Text;
            string tenkh = txtTenkh.Text;
            bool gt;
            if (rBtnNam.Checked) gt = true;
            else gt = false;
            string sdt = txtSDT.Text;
            string cccd = txtCCCD.Text;
            string stk = txtSTK.Text;
            kh.Update(makh, tenkh, gt, sdt, cccd, stk);
            LoadDGV();
        }

        private void ButtonXoa_Click(object sender, EventArgs e)
        {
            string makh = txtMakh.Text;
            string tenkh = txtTenkh.Text;
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng: " + tenkh + " không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (result == DialogResult.Yes)
            {
                kh.Delete(makh);
            }
            LoadDGV();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tukhoa = txtTimKiem.Text;
            dt = new DataTable();
            dt = kh.search(tukhoa);
            dgvKH.DataSource = dt;
        }

        private void iconPictureBoxSearch_Click(object sender, EventArgs e)
        {
            string tukhoa = txtTimKiem.Text;
            dt = new DataTable();
            dt = kh.search(tukhoa);
            dgvKH.DataSource = dt;
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {         
            //FormChoThuePhong();
        }
    }
}
