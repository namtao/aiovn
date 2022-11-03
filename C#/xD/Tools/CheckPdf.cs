using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xD
{
    public partial class CheckPdf : Form
    {
        public static string sqlConnect = ConfigurationManager.ConnectionStrings["hotich"].ConnectionString;

        public CheckPdf()
        {
            InitializeComponent();
        }

        private void CheckPdf_Load(object sender, EventArgs e)
        {
            List<String> a = Directory.GetFiles(@"D:\HoTich\HOTICH_HG\source - haugiang\Files\KS", "*.pdf",
                                         SearchOption.AllDirectories).ToList();
            List<String> filePaths = new List<string>();

            foreach (string file in a)
                filePaths.Add(Path.GetFileName(file));

            List<String> files = new List<string>();

            using (SqlConnection con = new SqlConnection(sqlConnect))
            {
                string sql = "select TenFileSauUpLoad from HT_KHAISINH";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        /*var f = dr[0].ToString();

                        if (filePaths.FirstOrDefault(stringToCheck => stringToCheck.Contains(dr[0].ToString())) == null)
                        {
                            Console.WriteLine(filePaths);
                        }*/

                        files.Add(dr[0].ToString());
                    }

                    con.Close();
                }
            }

            var list3 = filePaths.Except(files).ToList();
        }
    }
}
