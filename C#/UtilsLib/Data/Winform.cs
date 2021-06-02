using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilsLib
{
    public class Winform
    {
        public static void FillDgv(SqlConnection conn, string sqlQuery, DataGridView dataGrid)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            dataGrid.DataSource = ds.Tables[0];
        }
    }
}
