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
    public partial class FormCNLoaiPhong : Form
    {
        LoaiPhongCTRL lp = new LoaiPhongCTRL();
        Connection conn = new Connection();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public FormCNLoaiPhong()
        {
            InitializeComponent();
        }
        private void LoadDGV()
        {
            dt = new DataTable();
            dt = lp.GetData();
            dgvLoaiPhong.DataSource = dt;
        }

        private void FormCNLoaiPhong_Load(object sender, EventArgs e)
        {
            LoadDGV();
        }

        private void dgvLoaiPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chondong = -1;
            chondong = dgvLoaiPhong.CurrentCell.RowIndex;
            txtMaloaiphong.Text = dgvLoaiPhong.Rows[chondong].Cells[0].Value.ToString();
            txtTenloaiphong.Text = dgvLoaiPhong.Rows[chondong].Cells[1].Value.ToString();
            if(Convert.ToInt32(dgvLoaiPhong.Rows[chondong].Cells[2].Value) == 1)
                rBtn1.Checked = true;
            else if(Convert.ToInt32(dgvLoaiPhong.Rows[chondong].Cells[2].Value) == 2)
                rBtn2.Checked = true;
            else rBtn3.Checked = true;
            txtGiatheogio.Text = dgvLoaiPhong.Rows[chondong].Cells[3].Value.ToString();
            txtGiatheongay.Text = dgvLoaiPhong.Rows[chondong].Cells[4].Value.ToString();
            txtTienCoc.Text = dgvLoaiPhong.Rows[chondong].Cells[5].Value.ToString();
        }
        private int Sogiuong()
        {
            if (rBtn1.Checked)
                return 1;
            else if(rBtn2.Checked) return 2;
            else return 3;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maloaiphong = txtMaloaiphong.Text;
            string tenloaiphong = txtTenloaiphong.Text;
            int sogiuong = Sogiuong();
            float giatheongay = float.Parse(txtGiatheongay.Text);
            float giatheogio = float.Parse(txtGiatheogio.Text);
            float tiencoc = float.Parse(txtTienCoc.Text);
            lp.Insert(maloaiphong, tenloaiphong, sogiuong, giatheogio, giatheongay, tiencoc);
            LoadDGV();
        }



        private void btnSua_Click(object sender, EventArgs e)
        {
            string maloaiphong = txtMaloaiphong.Text;
            string tenloaiphong = txtTenloaiphong.Text;
            int sogiuong = Sogiuong();
            float giatheongay = float.Parse(txtGiatheongay.Text);
            float giatheogio = float.Parse(txtGiatheogio.Text);
            float tiencoc = float.Parse(txtTienCoc.Text);
            lp.Update(maloaiphong, tenloaiphong, sogiuong, giatheogio, giatheongay, tiencoc);
            LoadDGV();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maloaiphong = txtMaloaiphong.Text;
            string tenloaiphong = txtTenloaiphong.Text;
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa loại phòng: " + tenloaiphong + " không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (result == DialogResult.Yes)
            {
                lp.Delete(maloaiphong);
            }
            LoadDGV();
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            string tukhoa = txtTimKiem.Text;
            dt = new DataTable();
            dt = lp.search(tukhoa);
            dgvLoaiPhong.DataSource = dt;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tukhoa = txtTimKiem.Text;
            dt = new DataTable();
            dt = lp.search(tukhoa);
            dgvLoaiPhong.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
