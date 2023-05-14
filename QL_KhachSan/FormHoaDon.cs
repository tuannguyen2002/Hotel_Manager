using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KhachSan
{
    public partial class FormHoaDon : Form
    {
        private DataRow selectedRow;
        public FormHoaDon(DataRow row)
        {
            InitializeComponent();
            selectedRow = row;
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                // Lấy giá trị của từng cột từ dòng được chọn và gán cho các TextBox trong Form đích
                txtMaKH.Text = selectedRow["Column1"].ToString();
                txtCCCD.Text = selectedRow["Column3"].ToString();
                txtTenKH.Text = selectedRow["Column2"].ToString();
            }

        }
    }
}
