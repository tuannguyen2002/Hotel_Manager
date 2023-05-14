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
    internal class DichVuCTRL
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
            String sql = "select * from DichVu";
            cmd = new SqlCommand(sql, conn);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool CheckMaDichVu(string madichvu)
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            string sqlCheckMaDichvu = "select * from DichVu where MaDichVu = @madichvu";
            SqlCommand cmdCheckMaDichvu = new SqlCommand(sqlCheckMaDichvu, conn);
            cmdCheckMaDichvu.Parameters.AddWithValue("@madichvu", madichvu);
            da = new SqlDataAdapter(cmdCheckMaDichvu);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public void Insert(string madichvu, string tendichvu, string loaidichvu, float giadichvu,string donvi)
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            if (CheckMaDichVu(madichvu) == true)
            {
                MessageBox.Show("Mã Dịch Vụ Đã Tồn Tại");
            }
            else
            {
                try
                {
                    string sqlDichVu = "insert into DichVu(MaDichVu,TenDichVu,LoaiDichVu,GiaDichVu,DonVi) values(@madichvu,@tendichvu,@loaidichvu,@giadichvu,@donvi)";
                    SqlCommand cmdDichVu = new SqlCommand(sqlDichVu, conn);
                    cmdDichVu.Parameters.AddWithValue("@madichvu", madichvu);
                    cmdDichVu.Parameters.AddWithValue("@tendichvu", tendichvu);
                    cmdDichVu.Parameters.AddWithValue("@loaidichvu", loaidichvu);
                    cmdDichVu.Parameters.AddWithValue("@giadichvu", giadichvu);
                    cmdDichVu.Parameters.AddWithValue("@donvi", donvi);
                    if (cmdDichVu.ExecuteNonQuery() > 0)
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
        public void Update(string madichvu, string tendichvu, string loaidichvu, float giadichvu, string donvi)
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            if (CheckMaDichVu(madichvu) == true)
            {
                try
                {
                    string sqlDichVu = "update DichVu set TenDichVu =@tendichvu, LoaiDichVu= @loaidichvu,GiaDichVu=@giadichvu,DonVi=@donvi where MaDichVu = @madichvu";
                    SqlCommand cmdDichVu = new SqlCommand(sqlDichVu, conn);
                    cmdDichVu.Parameters.AddWithValue("@madichvu", madichvu);
                    cmdDichVu.Parameters.AddWithValue("@tendichvu", tendichvu);
                    cmdDichVu.Parameters.AddWithValue("@loaidichvu", loaidichvu);
                    cmdDichVu.Parameters.AddWithValue("@giadichvu", giadichvu);
                    cmdDichVu.Parameters.AddWithValue("@donvi", donvi);
                    if (cmdDichVu.ExecuteNonQuery() > 0)
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
        public void Delete(string madichvu)
        {
            conn = new SqlConnection();
            conn = a.Getconnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }


            if (CheckMaDichVu(madichvu) == true)
            {
                try
                {
                    string sql = "delete DichVu where MaDichVu = @madichvu";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@madichvu", madichvu);

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
                MessageBox.Show("Mã Dịch Vụ Không Tồn Tại");
            }
        }
        public DataTable search(string tukhoa)
        {
            string sql = "SearchDichVu";
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
