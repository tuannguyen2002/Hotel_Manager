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
    public partial class FormCNDichVu : Form
    {
        DichVuCTRL dv = new DichVuCTRL();
        Connection conn = new Connection();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public FormCNDichVu()
        {
            InitializeComponent();
        }
        private void LoadDGV()
        {
            dt = new DataTable();
            dt = dv.GetData();
            dgvDichVu.DataSource = dt;
        }

        private void FormCNDichVu_Load(object sender, EventArgs e)
        {
            LoadDGV();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string madv = txtMadv.Text;
            string tendv = txtTendv.Text;
            string loaidv = txtLoaidv.Text;
            float giadv = float.Parse(txtGiadv.Text);
            string donvi = CBBdonvi.Text;
            
            dv.Insert(madv, tendv, loaidv, giadv, donvi);
            LoadDGV();
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chondong = -1;
            chondong = dgvDichVu.CurrentCell.RowIndex;
            txtMadv.Text = dgvDichVu.Rows[chondong].Cells[0].Value.ToString();
            txtTendv.Text = dgvDichVu.Rows[chondong].Cells[1].Value.ToString();
            txtLoaidv.Text = dgvDichVu.Rows[chondong].Cells[2].Value.ToString();
            txtGiadv.Text = dgvDichVu.Rows[chondong].Cells[3].Value.ToString();
            CBBdonvi.Text = dgvDichVu.Rows[chondong].Cells[4].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string madv = txtMadv.Text;
            string tendv = txtTendv.Text;
            string loaidv = txtLoaidv.Text;
            float giadv = float.Parse(txtGiadv.Text);
            string donvi = CBBdonvi.Text;
            dv.Update(madv, tendv, loaidv, giadv, donvi);
            LoadDGV();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string madv = txtMadv.Text;
            string tendv = txtTendv.Text;
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dịch vụ: " + tendv + " không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (result == DialogResult.Yes)
            {
                dv.Delete(madv);
            }
            LoadDGV();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tukhoa = txtTimKiem.Text;
            dt = new DataTable();
            dt = dv.search(tukhoa);
            dgvDichVu.DataSource = dt;
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            string tukhoa = txtTimKiem.Text;
            dt = new DataTable();
            dt = dv.search(tukhoa);
            dgvDichVu.DataSource = dt;
        }
    }
}
