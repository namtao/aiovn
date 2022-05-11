using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDJ.Model
{
    class DB
    {
        public static void insert(string sqlConnect, string sqlCommand)
        {
            using (SqlConnection con = new SqlConnection(sqlConnect))
            {
                using (SqlCommand cmd = new SqlCommand(sqlCommand, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public static void update(string sqlConnect, string sqlCommand)
        {
            using (SqlConnection con = new SqlConnection(sqlConnect))
            {
                using (SqlCommand cmd = new SqlCommand(sqlCommand, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
