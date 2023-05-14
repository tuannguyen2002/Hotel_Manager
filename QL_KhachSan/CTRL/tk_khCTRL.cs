using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KhachSan
{
    internal class tk_khCTRL
    {
        Connection a = new Connection();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        string sql;

        public DataTable GetData()
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            sql = "SELECT kh.MaKhachHang, kh.TenKhachHang, hd.MaHoaDon, hd.NgayLapHoaDon, hd.ThoiGianDat, hd.ThoiGianNhan, hd.ThoiGianTra, hd.ThanhTien, COUNT(ct.MaPhong) AS SoLuongPhong\r\n    FROM KhachHang kh\r\n    INNER JOIN HoaDon hd ON kh.MaKhachHang = hd.MaKhachHang\r\n    INNER JOIN ChiTietHoaDon ct ON hd.MaHoaDon = ct.MaHoaDon\r\n    GROUP BY kh.MaKhachHang, kh.TenKhachHang, hd.MaHoaDon, hd.NgayLapHoaDon, hd.ThoiGianDat, hd.ThoiGianNhan, hd.ThoiGianTra, hd.ThanhTien;";
            cmd = new SqlCommand(sql, conn);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable search(string tukhoa)
        {
            string sql = "SearchTKKH";
            cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tukhoa", tukhoa);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
