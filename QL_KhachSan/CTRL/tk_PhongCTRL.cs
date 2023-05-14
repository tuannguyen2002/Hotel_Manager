using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KhachSan
{
    internal class tk_PhongCTRL
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
            sql = "SELECT p.MaPhong, p.TenPhong, lp.TenLoaiPhong, lp.GiaTheoGio, lp.GiaTheoNgay, hd.ThoiGianNhan, hd.ThoiGianTra, " +
                "DATEDIFF(day, hd.ThoiGianNhan, hd.ThoiGianTra) AS SoNgay, " +
                "(DATEDIFF(day, hd.ThoiGianNhan, hd.ThoiGianTra) * lp.GiaTheoNgay)  AS ThanhTien " +
                "FROM Phong p " +
                "INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong " +
                "INNER JOIN HoaDon hd ON p.MaPhong IN (SELECT MaPhong FROM ChiTietHoaDon WHERE MaHoaDon = hd.MaHoaDon)";
            cmd = new SqlCommand(sql, conn);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetDataDTP()
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            sql = "SELECT p.MaPhong, p.TenPhong, (DATEDIFF(day, hd.ThoiGianNhan, hd.ThoiGianTra) * lp.GiaTheoNgay)  AS ThanhTien FROM Phong p INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong INNER JOIN HoaDon hd ON p.MaPhong IN (SELECT MaPhong FROM ChiTietHoaDon WHERE MaHoaDon = hd.MaHoaDon)";
            cmd = new SqlCommand(sql, conn);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable search(string tukhoa)
        {
            string sql = "SearchTKP";
            cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tukhoa", tukhoa);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable searchTKP(string tukhoa)
        {
            string sql = "SearchTKDTP";
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
