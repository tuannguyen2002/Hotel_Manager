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
    public partial class U1 : UserControl
    {
        public U1()
        {
            InitializeComponent();
        }
        public void ThongTinUserControl(string mp,string tp, string lp, int sg, float ttg,float ttn,float tc)
        {
            lb0.Text = mp;
            lb1.Text = tp;
            lb2.Text = lp;
            lb3.Text = sg.ToString();
            lb4.Text = ttg.ToString();
            lb5.Text = ttn.ToString();
            lb6.Text = tc.ToString();

        }
        // public event EventHandler<UserControlEventArgs> UserControlClicked;
        public event EventHandler<UserControlEventArgs> UserControlClicked;

        private void OnUserControlClicked(UserControlEventArgs e)
        {
            // Kiểm tra xem sự kiện có ai đang theo dõi nó không
            UserControlClicked?.Invoke(this, e);
        }

        // Tạo lớp UserControlEventArgs để truyền các thông tin cần lấy từ UserControl
        public class UserControlEventArgs : EventArgs
        { 
            public string mp { get; set; }
            public string tp { get; set; }
            public string lp { get; set; }
            public int sg { get; set; }
            public float ttg { get; set; }
            public float ttn { get; set; }
            public float tc { get; set; }

        }
        private void U1_Click(object sender, EventArgs e)
        {
            UserControlEventArgs args = new UserControlEventArgs();
            args.mp = lb0.Text;
            args.tp = lb1.Text;
            args.lp = lb2.Text;
            args.sg = int.Parse(lb3.Text);
            args.ttg = float.Parse(lb4.Text);
            args.ttn = float.Parse(lb5.Text);
            args.tc = float.Parse(lb6.Text);
            OnUserControlClicked(args);
        }
    }
    
}
