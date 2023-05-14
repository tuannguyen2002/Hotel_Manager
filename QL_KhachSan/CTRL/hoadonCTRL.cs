using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KhachSan
{
    internal class hoadonCTRL
    {
        Connection a = new Connection();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        string sql;

        public DataTable GetDataDTTong()
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            sql = "SELECT COUNT(MaHoaDon) AS SoLuongHoaDon, SUM(ThanhTien) AS ThanhTien FROM HoaDon";
            cmd = new SqlCommand(sql, conn);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
