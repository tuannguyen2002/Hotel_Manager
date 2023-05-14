using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KhachSan.Class
{
    internal class Phong
    {
        private string maphong;
        private string maloaiphong;
        private string tenphong;
        private string trangthai;
        private string tenloaiphong;
        private int sogiuong;
        private float giatheogio;
        private float giatheongay;
        private float tiencoc;
        public string Maphong { get => maphong; set => maphong = value; }
        public string Maloaiphong { get => maloaiphong; set => maloaiphong = value; }
        public string Tenphong { get => tenphong; set => tenphong = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
        public string Tenloaiphong { get => tenloaiphong; set => tenloaiphong = value; }
        public int Sogiuong { get => sogiuong; set => sogiuong = value; }
        public float Giatheogio { get => giatheogio; set => giatheogio = value; }
        public float Giatheongay { get => giatheongay; set => giatheongay = value; }
        public float Tiencoc { get => tiencoc; set => tiencoc = value; }
    }
}
