using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KhachSan.Class
{
    internal class LoaiPhong
    {
        private string maloaiphong;
        private string tenloaiphong;
        private int sogiuong;
        private double giatheogio;
        private double giatheongay;
        private double tiencoc;

        public string Maloaiphong { get => maloaiphong; set => maloaiphong = value; }
        public string Tenloaiphong { get => tenloaiphong; set => tenloaiphong = value; }
        public int Sogiuong { get => sogiuong; set => sogiuong = value; }
        public double Giatheogio { get => giatheogio; set => giatheogio = value; }
        public double Giatheongay { get => giatheongay; set => giatheongay = value; }
        public double Tiencoc { get => tiencoc; set => tiencoc = value; }
    }
}
