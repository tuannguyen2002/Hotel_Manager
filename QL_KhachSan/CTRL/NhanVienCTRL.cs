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
    internal class NhanVienCTRL
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
            String sql = "select * from NhanVien";
            cmd = new SqlCommand(sql, conn);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetDataDTNV()
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            String sql = "select MaNhanVien, TenNhanVien, ChucVu, Luong from NhanVien";
            cmd = new SqlCommand(sql, conn);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool CheckMaNhanVien(string manv)
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            string sqlCheckManv = "select * from NhanVien where MaNhanVien = @manv";
            SqlCommand cmdCheckManv = new SqlCommand(sqlCheckManv, conn);
            cmdCheckManv.Parameters.AddWithValue("@manv", manv);
            da = new SqlDataAdapter(cmdCheckManv);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public void Insert(string manv, string tennv, bool gt, string sdt, string cccd, string chucvu, float luong)
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            if (CheckMaNhanVien(manv) == true)
            {
                MessageBox.Show("Mã Nhân Viên Đã Tồn Tại");
            }
            else
            {
                try
                {
                    string sql = "insert into NhanVien(MaNhanVien,TenNhanVien,GioiTinh,SDT,CCCD,ChucVu,Luong) values(@manv,@tennv,@gt,@sdt,@cccd,@chucvu,@luong)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@manv", manv);
                    cmd.Parameters.AddWithValue("@tennv", tennv);
                    cmd.Parameters.AddWithValue("@gt", gt);
                    cmd.Parameters.AddWithValue("@sdt", sdt);
                    cmd.Parameters.AddWithValue("@cccd", cccd);
                    cmd.Parameters.AddWithValue("@chucvu", chucvu);
                    cmd.Parameters.AddWithValue("@luong", luong);
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
        public void Update(string manv, string tennv, bool gt, string sdt, string cccd, string chucvu, float luong)
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            if (CheckMaNhanVien(manv) == true)
            {
                try
                {
                    string sql = "update NhanVien set TenNhanVien =@tennv,GioiTinh=@gt,SDT=@sdt,CCCD=@cccd,ChucVu = @chucvu,Luong=@luong where MaNhanVien = @manv";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@manv", manv);
                    cmd.Parameters.AddWithValue("@tennv", tennv);
                    cmd.Parameters.AddWithValue("@gt", gt);
                    cmd.Parameters.AddWithValue("@sdt", sdt);
                    cmd.Parameters.AddWithValue("@cccd", cccd);
                    cmd.Parameters.AddWithValue("@chucvu", chucvu);
                    cmd.Parameters.AddWithValue("@luong", luong);
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
                MessageBox.Show("Mã Nhân Viên Không Tồn Tại");
            }
        }
        public void Delete(string manv)
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }


            if (CheckMaNhanVien(manv) == true)
            {
                try
                {
                    string sql = "delete NhanVien where MaNhanVien = @manv";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@manv", manv);

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
                MessageBox.Show("Mã Nhân Viên Không Tồn Tại");
            }
        }
        public DataTable search(string tukhoa)
        {
            string sql = "SearchNhanVien";
            cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tukhoa", tukhoa);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable searchDTNV(string tukhoa)
        {
            string sql = "SearchTKDTNV";
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
