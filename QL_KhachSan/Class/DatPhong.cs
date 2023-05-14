using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KhachSan.Class
{
    internal class DatPhong
    {
        private string MaHoaDon;
        private string MaPhong;
        private string MaKH;
        private DateTime TimeNhan;
        private DateTime TimeTra;

        public string MaHoaDon1 { get => MaHoaDon; set => MaHoaDon = value; }
        public string MaPhong1 { get => MaPhong; set => MaPhong = value; }
        public string MaKH1 { get => MaKH; set => MaKH = value; }
        public DateTime TimeNhan1 { get => TimeNhan; set => TimeNhan = value; }
        public DateTime TimeTra1 { get => TimeTra; set => TimeTra = value; }
    }
}
