using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_KhachSan.Class;

namespace QL_KhachSan
{
    internal class tk_dvCTRL
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
            sql = "SELECT dv.MaDichVu, dv.TenDichVu, dv.DonVi, SUM(ct.SoLuong) AS TongSoLuong, SUM(ct.TienDichVu) AS TongTien \r\nFROM DichVu dv INNER JOIN ChiTietSuDungDichVu ct ON dv.MaDichVu = ct.MaDichVu\r\nGROUP BY dv.MaDichVu, dv.TenDichVu, dv.DonVi;";
            cmd = new SqlCommand(sql, conn);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetDataDTDV()
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            sql = "SELECT dv.MaDichVu, dv.TenDichVu, SUM(ct.TienDichVu) AS TongTien FROM DichVu dv INNER JOIN ChiTietSuDungDichVu ct ON dv.MaDichVu = ct.MaDichVu GROUP BY dv.MaDichVu, dv.TenDichVu;";
            cmd = new SqlCommand(sql, conn);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable searchTKDV(string tukhoa)
        {
            string sql = "SearchTKDTDV";
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
