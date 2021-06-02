using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_DuLieu
{
    public class Data
    {
        public SqlConnection GetConnect()
        {
            return new SqlConnection(@"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=QLTB;Integrated Security=True");
        }

        public DataTable GetTable(String sql)
        {
            SqlConnection con = GetConnect();
            con.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, con);
            SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();
            return (dt);
        }

        public void ExcuteNonQuery(String sql)
        {
            SqlConnection con = GetConnect();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
        }
    }
}
