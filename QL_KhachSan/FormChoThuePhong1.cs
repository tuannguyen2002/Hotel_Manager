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
using static QL_KhachSan.U1;

namespace QL_KhachSan
{
    public partial class FormChoThuePhong1 : Form
    {
        public DataRow selectedRow;
        public FormChoThuePhong1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;
            this.Size = new Size(1600, 900);
        }
        PhongCTRL p = new PhongCTRL();
        LoaiPhongCTRL lp = new LoaiPhongCTRL();
        Connection conn = new Connection();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        KhachHangCTRL kh = new KhachHangCTRL();
        private void LoadDGV_KH()
        {
            dt = new DataTable();
            dt = kh.GetData1();
            dgvKH.DataSource = dt;
        }
        private bool Checkmaphong(string ma)
        {
            bool kt = false;
            foreach (DataGridViewRow row in dgvPhong.Rows)
            {
                // Kiểm tra giá trị của ô đầu tiên ở hàng hiện tại
                string cellValue = row.Cells["MaPhong"].Value?.ToString();
                if (cellValue == ma)
                {
                    kt = true;
                    // Nếu tìm thấy giá trị 'ma', trả về true và kết thúc hàm

                }
            }
            // Không tìm thấy giá trị 'ma', trả về false
            return kt;
        }
        private void LoadDGVphong(string mp, string tp, string lp, float ttg, float ttn, float tc)
        {
            int rowIndex = dgvPhong.Rows.Add();
            dgvPhong.Rows[rowIndex].Cells[0].Value = mp;
            dgvPhong.Rows[rowIndex].Cells[1].Value = tp;
            dgvPhong.Rows[rowIndex].Cells[2].Value = lp;
            dgvPhong.Rows[rowIndex].Cells[3].Value = ttg;
            dgvPhong.Rows[rowIndex].Cells[4].Value = ttn;
            dgvPhong.Rows[rowIndex].Cells[5].Value = tc;
        }
        private void HandleUserControlClicked(object sender, UserControlEventArgs e)
        {
            string maphong = e.mp;
            string tenphong = e.tp;
            string loaiphong = e.lp;
            float tientheogio = e.ttg;
            float tientheongay = e.ttn;
            float tiencoc = e.tc;
            //if (Checkmaphong(maphong)==true)
            //    MessageBox.Show("Đã có phòng trong danh sách đặt phòng");
            if (dgvPhong.RowCount == 0)
                LoadDGVphong(e.mp, e.tp, e.lp, e.ttg, e.ttn, e.tc);
            else
            {
                if (Checkmaphong(e.mp))
                    MessageBox.Show("Đã có phòng trong danh sách đặt phòng");
                else
                    LoadDGVphong(e.mp, e.tp, e.lp, e.ttg, e.ttn, e.tc);
            }
            // Xử lý các thông tin vừa lấy
        }
        private void addUserControl()
        {
            List<string> loaiphong = new List<string>();
            if (cbSuite.Checked)
                loaiphong.Add(cbSuite.Text);
            else
                loaiphong.Remove(cbSuite.Text);
            if (cbSuperior.Checked)
                loaiphong.Add(cbSuperior.Text);
            else
                loaiphong.Remove(cbSuperior.Text);
            if (cbStandard.Checked)
                loaiphong.Add(cbStandard.Text);
            else
                loaiphong.Remove(cbStandard.Text);
            if (cbDeluxe.Checked)
                loaiphong.Add(cbDeluxe.Text);
            else
                loaiphong.Remove(cbDeluxe.Text);

            List<Phong> listChecked = new List<Phong>();
            List<Phong> list = new Data().ListPhong();
            foreach (Phong ph in list)
            {
                foreach (string t in loaiphong)
                {
                    if (ph.Tenloaiphong == t)
                        listChecked.Add(ph);
                }
            }
            foreach (Phong ph in listChecked)
            {
                U1 a = new U1();
                a.ThongTinUserControl(ph.Maphong, ph.Tenphong, ph.Tenloaiphong, ph.Sogiuong, ph.Giatheogio, ph.Giatheongay, ph.Tiencoc);
                fLPanelphong.Controls.Add(a);
            }
            foreach (U1 control in fLPanelphong.Controls)
            {
                control.UserControlClicked += new EventHandler<UserControlEventArgs>(HandleUserControlClicked);
            }
        }
        private void btnFormKH_Click(object sender, EventArgs e)
        {
            FormCNKhachHang f = new FormCNKhachHang();
            f.ShowDialog();
        }

        private void FormChoThuePhong1_Load(object sender, EventArgs e)
        {
            LoadDGV_KH();
            List<Phong> list = new Data().ListPhong();
            foreach (Phong ph in list)
            {
                U1 a = new U1();
                a.ThongTinUserControl(ph.Maphong, ph.Tenphong, ph.Tenloaiphong, ph.Sogiuong, ph.Giatheogio, ph.Giatheongay, ph.Tiencoc);
                fLPanelphong.Controls.Add(a);
            }
            foreach (U1 control in fLPanelphong.Controls)
            {
                control.UserControlClicked += new EventHandler<UserControlEventArgs>(HandleUserControlClicked);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tukhoa = txtTimKiem.Text;
            dt = new DataTable();
            dt = kh.search1(tukhoa);
            dgvKH.DataSource = dt;
        }

        private void iconPictureBoxSearch_Click(object sender, EventArgs e)
        {
            string tukhoa = txtTimKiem.Text;
            dt = new DataTable();
            dt = kh.search1(tukhoa);
            dgvKH.DataSource = dt;
        }

        private void btnBochon_Click(object sender, EventArgs e)
        {
            if (dgvPhong.SelectedRows.Count > 0)
            {
                // Lấy đối tượng DataGridViewRow của dòng được chọn
                DataGridViewRow selectedRow = dgvPhong.SelectedRows[0];

                // Loại bỏ dòng được chọn khỏi bảng dữ liệu
                dgvPhong.Rows.Remove(selectedRow);
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            fLPanelphong.Controls.Clear();
            addUserControl();
        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            FormHoaDon f = new FormHoaDon(selectedRow);
            f.ShowDialog();
        }

        private void dgvKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvKH_DoubleClick(object sender, EventArgs e)
        {
            if (dgvKH.SelectedRows.Count > 0)
            {
                selectedRow = ((DataRowView)dgvKH.SelectedRows[0].DataBoundItem).Row;
                // Mở Form đích ở đây (nếu cần)
            }
        }
    }
}
