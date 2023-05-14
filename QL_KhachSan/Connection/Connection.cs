using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QL_KhachSan
{
    internal class Connection
    {
        string connectionString = @"Data Source=.;Initial Catalog=qlks;Integrated Security=True";
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public SqlConnection Getconnection()
        {
            try
            {
                conn = new SqlConnection(connectionString);
            }
            catch (Exception e)
            {
                MessageBox.Show("connection faild: " + e.ToString());
            }
            return conn;
        }

        public void OpenData()
        {
            if (Getconnection().State == ConnectionState.Closed)
            {
                Getconnection().Open();
            }
        }
        public void CloseData()
        {
            if (Getconnection().State == ConnectionState.Open)
            {
                Getconnection().Close();
            }
        }
    }
}
