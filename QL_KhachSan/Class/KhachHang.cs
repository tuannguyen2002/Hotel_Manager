using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KhachSan.Class
{
    internal class KhachHang
    {
        private string makh;
        private string cccd;
        private string tenkh;
        private bool gt;
        private string sdt;
        private string stk;

        public string Makh { get => makh; set => makh = value; }
        public string Cccd { get => cccd; set => cccd = value; }
        public string Tenkh { get => tenkh; set => tenkh = value; }
        public bool Gt { get => gt; set => gt = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Stk { get => stk; set => stk = value; }
    }
}
