using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using QL_KhachSan.Class;

namespace QL_KhachSan
{
    internal class PhongCTRL
    {
        
        Connection a = new Connection();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        string sql;
        public List<Phong> ListPhong()
        {
            List<Phong> ds = new List<Phong>();
            string sql = "select * from Phong";
            cmd = new SqlCommand(sql, conn);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Phong p = new Phong();
                p.Maphong = dt.Rows[i][0].ToString();
                p.Tenphong = dt.Rows[i][1].ToString();
                p.Maloaiphong = dt.Rows[i][2].ToString();
                p.Trangthai = dt.Rows[i][3].ToString();
                ds.Add(p);
            }

            return ds;
        }
        
        public DataTable GetData()
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            String sql = "select * from Phong";
            cmd = new SqlCommand(sql, conn);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public bool CheckMaPhong(string maPhong)
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            string sqlCheckMaPhong = "select * from Phong where MaPhong = @Maphong";
            SqlCommand cmdCheckMaPhong = new SqlCommand(sqlCheckMaPhong, conn);
            cmdCheckMaPhong.Parameters.AddWithValue("@Maphong", maPhong);
            da = new SqlDataAdapter(cmdCheckMaPhong);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public void Insert(string maphong, string tenphong, string maloaiphong, string trangthai)
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            if (CheckMaPhong(maphong) == true)
            {
                MessageBox.Show("Mã Phòng Đã Tồn Tại");
            }
            else
            {
                try
                {
                    string sqlPhong = "insert into Phong(MaPhong,TenPhong,MaLoaiPhong,TrangThai) values(@maphong,@tenphong,@maloaiphong,@trangthai)";
                    SqlCommand cmdPhong = new SqlCommand(sqlPhong, conn);
                    cmdPhong.Parameters.AddWithValue("@maphong", maphong);
                    cmdPhong.Parameters.AddWithValue("@tenphong", tenphong);
                    cmdPhong.Parameters.AddWithValue("@maloaiphong", maloaiphong);
                    cmdPhong.Parameters.AddWithValue("@trangthai", trangthai);
                    if (cmdPhong.ExecuteNonQuery() > 0)
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
        public void Update(string maphong, string tenphong, string maloaiphong, string trangthai)
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            if (CheckMaPhong(maphong) == true)
            {
                try
                {
                    string sql = "update Phong set TenPhong =@tenphong, MaLoaiPhong= @maloaiphong,TrangThai=@TrangThai where MaPhong = @maphong";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maphong", maphong);
                    cmd.Parameters.AddWithValue("@tenphong", tenphong);
                    cmd.Parameters.AddWithValue("@maloaiphong", maloaiphong);
                    cmd.Parameters.AddWithValue("@trangthai", trangthai);
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
                MessageBox.Show("Mã Phòng Không Tồn Tại");
            }
        }
        public void Delete(string maphong)
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }


            if (CheckMaPhong(maphong) == true)
            {
                try
                {
                    string sql = "delete Phong where MaPhong = @maphong";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maphong", maphong);

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
                MessageBox.Show("Mã Phòng Không Tồn Tại");
            }
        }
        public DataTable search(string tukhoa)
        {
            string sql = "SearchPhong";
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
