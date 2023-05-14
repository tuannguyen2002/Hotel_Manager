using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KhachSan
{
    internal class KhachHangCTRL
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
            String sql = "select * from KhachHang";
            cmd = new SqlCommand(sql, conn);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetData1()
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            String sql = "select MaKhachHang,TenKhachHang,CCCD from KhachHang";
            cmd = new SqlCommand(sql, conn);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool CheckMaKhachHang(string makh)
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            string sql = "select * from KhachHang where MaKhachHang = @makh";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@makh", makh);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public void Insert(string makh, string tenkh, bool gt, string sdt, string cccd, string stk)
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            if (CheckMaKhachHang(makh) == true)
            {
                MessageBox.Show("Mã Khách Hàng Đã Tồn Tại");
            }
            else
            {
                try
                {
                    string sql = "insert into KhachHang(MaKhachHang,TenKhachHang,GioiTinh,SDT,CCCD,STK) values(@makh,@tenkh,@gt,@sdt,@cccd,@stk)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@makh", makh);
                    cmd.Parameters.AddWithValue("@tenkh", tenkh);
                    cmd.Parameters.AddWithValue("@gt", gt);
                    cmd.Parameters.AddWithValue("@sdt", sdt);
                    cmd.Parameters.AddWithValue("@cccd", cccd);
                    cmd.Parameters.AddWithValue("@stk", stk);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Thêm Mới Thành Công");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Tạo Mới Thất Bại!...." + e.ToString());
                    throw;
                }
            }

        }
        public void Update(string makh, string tenkh, bool gt, string sdt, string cccd, string stk)
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            if (CheckMaKhachHang(makh) == true)
            {
                try
                {
                    string sql = "update KhachHang set TenKhachHang =@tenkh,GioiTinh=@gt,SDT=@sdt,CCCD=@cccd,STK = @stk where MaKhachHang = @makh";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@makh", makh);
                    cmd.Parameters.AddWithValue("@tenkh", tenkh);
                    cmd.Parameters.AddWithValue("@gt", gt);
                    cmd.Parameters.AddWithValue("@sdt", sdt);
                    cmd.Parameters.AddWithValue("@cccd", cccd);
                    cmd.Parameters.AddWithValue("@stk", stk);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Thay đổi Thành Công");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thay đổi Không được chấp nhận..." + ex.ToString());
                    throw;
                }

            }
            else
            {
                MessageBox.Show("Mã Khách Hàng Không Tồn Tại");
            }
        }
        public void Delete(string makh)
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }


            if (CheckMaKhachHang(makh) == true)
            {
                try
                {
                    string sql = "delete KhachHang where MaKhachHang = @makh";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@makh", makh);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Xóa Thành Công");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa thất bại..." + ex.ToString());
                    throw;
                }

            }
            else
            {
                MessageBox.Show("Mã Khách Hàng Không Tồn Tại");
            }
        }
        public DataTable search(string tukhoa)
        {
            string sql = "SearchKhachHang";
            cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tukhoa", tukhoa);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable search1(string tukhoa)
        {
            string sql = "SearchKhachHang2";
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
