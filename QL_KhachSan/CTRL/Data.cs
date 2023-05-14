using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_KhachSan.Class;

namespace QL_KhachSan
{
    internal class Data
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=qlks;Integrated Security=True");

        public void openConnect()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }

        public void closeConnect()
        {
            conn.Close();
        }

        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter da;

        public List<Phong> ListPhong()
        {
            List<Phong> ds = new List<Phong>();
            string sql = "select p.MaPhong, p.TenPhong,p.MaLoaiPhong,p.TrangThai,lp.TenLoaiPhong,lp.SoGiuong,lp.GiaTheoGio,lp.GiaTheoNgay,lp.TienCoc\r\n\tFrom Phong p\r\n\tInner Join LoaiPhong lp on p.MaLoaiPhong=lp.MaLoaiPhong where lp.SoGiuong>0";
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
                p.Tenloaiphong = dt.Rows[i][4].ToString();
                p.Sogiuong = int.Parse(dt.Rows[i][5].ToString());
                p.Giatheogio = float.Parse(dt.Rows[i][6].ToString());
                p.Giatheongay = float.Parse(dt.Rows[i][7].ToString());
                p.Tiencoc= float.Parse(dt.Rows[i][8].ToString());
                ds.Add(p);
            }

            return ds;
        }



    }
}
