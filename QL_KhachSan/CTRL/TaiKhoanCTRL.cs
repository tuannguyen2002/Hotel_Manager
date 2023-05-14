using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KhachSan.CTRL
{
    internal class TaiKhoanCTRL
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
            String sql = "select * from TaiKhoan";
            cmd = new SqlCommand(sql, conn);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public bool CheckTaiKhoan(string tk, string mk)
        {
            bool result = false;
            conn = new SqlConnection();
            conn = a.Getconnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {
                sql = "select Password from TaiKhoan where Username = @tk";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tk", tk);
                string matkhau = "";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        matkhau = reader.GetString(reader.GetOrdinal("Password"));
                    }
                }
                if (matkhau == mk)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi ở đây
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return result;
        }
    }
}
