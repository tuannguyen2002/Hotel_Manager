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
    internal class LoaiPhongCTRL
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
            String sql = "select * from LoaiPhong";
            cmd = new SqlCommand(sql, conn);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public bool CheckMaLoaiPhong(string maloaiphong)
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            string sqlCheckMaLoaiPhong = "select * from Phong where MaLoaiPhong = @maloaiphong";
            SqlCommand cmdCheckMaLoaiPhong = new SqlCommand(sqlCheckMaLoaiPhong, conn);
            cmdCheckMaLoaiPhong.Parameters.AddWithValue("@maloaiphong", maloaiphong);
            da = new SqlDataAdapter(cmdCheckMaLoaiPhong);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public string Get_tenphong(string maloaiphong)
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            string tenloaiphong = "select TenLoaiPhong from Phong where MaLoaiPhong = @maloaiphong";
            //SqlCommand cmd = new SqlCommand(tenloaiphong, conn);
            //cmd.Parameters.AddWithValue("@maphong", maloaiphong);
            //da = new SqlDataAdapter(cmd);
            //dt = new DataTable();
            //da.Fill(dt);
            return tenloaiphong;
        }
        public void Insert(string maloaiphong, string tenloaiphong, int sogiuong, double giatheogio, double giatheongay, double tiencoc)
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            if (CheckMaLoaiPhong(maloaiphong) == true)
            {
                MessageBox.Show("Mã Loại Phòng Đã Tồn Tại");
            }
            else
            {
                //try
                //{
                    string sqlLP = "insert into LoaiPhong(MaLoaiPhong,TenLoaiPhong,SoGiuong,GiaTheoGio,GiaTheoNgay,TienCoc) values(@maloaiphong, @tenloaiphong, @sogiuong, @giatheogio, @giatheongay, @tiencoc)";
                    SqlCommand cmdLP = new SqlCommand(sqlLP, conn);
                    cmdLP.Parameters.AddWithValue("@maloaiphong", maloaiphong);
                    cmdLP.Parameters.AddWithValue("@tenloaiphong", tenloaiphong);
                    cmdLP.Parameters.AddWithValue("@sogiuong", sogiuong);
                    cmdLP.Parameters.AddWithValue("@giatheogio", giatheogio);
                    cmdLP.Parameters.AddWithValue("@giatheongay", giatheongay);
                    cmdLP.Parameters.AddWithValue("@tiencoc", tiencoc);
                    if (cmdLP.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Thêm Mới Thành Công");
                    }
                //}
                //catch (Exception e)
                //{
                //    MessageBox.Show("Tạo Mới Thất Bại!...." + e.ToString());
                //    throw;
                //}
            }

        }
        public void Update(string maloaiphong, string tenloaiphong, int sogiuong, double giatheogio, double giatheongay, double tiencoc)
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            if (CheckMaLoaiPhong(maloaiphong) == true)
            {
                try
                {
                    string sql = "update LoaiPhong set TenLoaiPhong =@tenloaiphong, SoGiuong= @sogiuong,GiaTheoGio=@giatheogio,GiaTheoNgay=@giatheongay,TienCoc=@tiencoc  where MaLoaiPhong = @maloaiphong";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maphong", maloaiphong);
                    cmd.Parameters.AddWithValue("@tenloaiphong", tenloaiphong);
                    cmd.Parameters.AddWithValue("@sogiuong", sogiuong);
                    cmd.Parameters.AddWithValue("@giatheogio", giatheogio);
                    cmd.Parameters.AddWithValue("@giatheongay", giatheongay);
                    cmd.Parameters.AddWithValue("@tiencoc", tiencoc);
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
                MessageBox.Show("Mã Loại Phòng Không Tồn Tại");
            }
        }
        public void Delete(string maloaiphong)
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }


            if (CheckMaLoaiPhong(maloaiphong) == true)
            {
                try
                {
                    string sql = "delete LoaiPhong where MaLoaiPhong = @maloaiphong";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maloaiphong", maloaiphong);

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
            string sql = "SearchLoaiPhong";
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
