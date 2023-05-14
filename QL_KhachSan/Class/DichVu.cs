using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KhachSan.Class
{
    internal class DichVu
    {
        private string madv;
        private string tendv;
        private string loaidv;
        private double giadv;
        private string donvi;

        public string Madv { get => madv; set => madv = value; }
        public string Tendv { get => tendv; set => tendv = value; }
        public string Loaidv { get => loaidv; set => loaidv = value; }
        public double Giadv { get => giadv; set => giadv = value; }
        public string Donvi { get => donvi; set => donvi = value; }
    }
}
