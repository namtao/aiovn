using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CountFolder
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        public void Errors()
        {
            int count = 0;
            string pathDir = @"\\192.168.31.206\Share\JPG (đã kiểm tra)\errors.txt";
            File.WriteAllText(pathDir, String.Empty);
            using (StreamWriter streamWriter = File.AppendText(pathDir))
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=ADDJ_AnGiang;Integrated Security=True"))
                {
                    string sql = "use ADDJ_AnGiang; " +
                    "select m.Metadata,ProfileName, TenDonVi, HoSoSo from TblBatchManagement b join TblMetadata m on b.BatchManagementID = m.BatchID where Status != 7";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr[0].ToString().Trim().Length > 0 && dr[0] != null && !dr[0].ToString().Trim().Equals(""))
                            {
                                JsonDocument doc = JsonDocument.Parse(dr[0].ToString());
                                JsonElement root = doc.RootElement;
                                for (int i = 0; i < root.GetArrayLength(); i++)
                                {
                                    string indexName = root[i].GetProperty("indexName").ToString().Trim();
                                    string indexValue = root[i].GetProperty("indexValue").ToString().Trim();
                                    string indexValue2 = root[i].GetProperty("indexValue2").ToString().Trim();
                                    string indexValueQC = root[i].GetProperty("indexValueQC").ToString().Trim();
                                    string err = "";

                                    if (indexName.Equals("Ghi chú"))
                                    {
                                        if (indexValueQC != "" && indexValueQC != null)
                                        {
                                            err = indexValueQC;
                                            streamWriter.WriteLine(dr[1] + "\t" + dr[2] + "\t" + dr[3] + "\t" + err);
                                            count++;
                                        }

                                    }
                                }


                            }
                        }
                        con.Close();
                    }
                }
            }

            MessageBox.Show("Có " + count + " trường hợp lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ThongKe(string path)
        {
            object[,] arr = new object[10 * 10, 10];
            int row = 0;
            //thống kê ảnh
            string txtPath = @"\\192.168.31.206\Share\JPG (đã kiểm tra)\nocode.txt";
            File.WriteAllText(txtPath, String.Empty);
            foreach (string pathDir in Directory.GetDirectories(path))
            {

                using (StreamWriter writer = File.AppendText(txtPath))
                {
                    string[] arrPathJpg = Directory.GetFiles(pathDir, "*.jpg", SearchOption.AllDirectories);
                    List<string> listNoCode = new List<string>();
                    List<string> listHoSo = new List<string>();
                    foreach (string str in arrPathJpg)
                    {
                        listHoSo.Add(Directory.GetParent(str) + "");
                        if ((new DirectoryInfo(str).Parent.Name.Trim().Length >= 3) && !IsNumber(new DirectoryInfo(str).Parent.Name.Substring(0, 3))
                            && !IsNumber(new DirectoryInfo(str).Parent.Name.Substring(new DirectoryInfo(str).Parent.Name.Length - 3, 3)))
                            listNoCode.Add(Directory.GetParent(str) + "");
                    }

                    foreach (string strList in listNoCode.Distinct().ToList())
                    {
                        writer.WriteLine(strList);
                    }

                    arr[row, 0] = new DirectoryInfo(pathDir).Name.Trim();
                    arr[row, 1] = arrPathJpg.Length.ToString();
                    arr[row, 2] = listNoCode.Distinct().ToList().Count.ToString();
                    arr[row, 3] = listHoSo.Distinct().ToList().Count.ToString();
                    row++;
                }
            }

            int tongJpg = 0, tongKhongMa = 0, tongHoSo = 0;

            for (int i = 0; i < row; i++)
            {
                tongJpg += Int32.Parse(arr[i, 1].ToString());
                tongKhongMa += Int32.Parse(arr[i, 2].ToString());
                tongHoSo += Int32.Parse(arr[i, 3].ToString());
            }

            arr[row, 1] = tongJpg.ToString();
            arr[row, 2] = tongKhongMa.ToString();
            arr[row, 3] = tongHoSo.ToString();
            row = row + 3;

            //thống kê trường
            SqlConnection sql1 = new SqlConnection(@"Data Source=.;Initial Catalog=ADDJ_AnGiang;Integrated Security=True");
            string[] loai = { "HSLS", "HSHHC", "HSTBA", "HSBB", "HSCDHH", "HS62", "HSLTCM", "HSTKN", "HSTNXP1" };
            foreach (string s in loai)
            {
                sql1.Open();
                int rows = Int32.Parse((new SqlCommand("SELECT COUNT(*) FROM TblMetadata " +
                "where BatchID in (select BatchManagementID from TblBatchManagement where ProfileName like '%" + s + "%')", sql1).ExecuteScalar()).ToString());
                int countField = 0;
                sql1.Close();
                using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=ADDJ_AnGiang;Integrated Security=True"))
                {
                    string sql = "use ADDJ_AnGiang; " +
                    "SELECT Metadata, BatchID FROM TblMetadata " +
                    "where BatchID in (select BatchManagementID from TblBatchManagement where ProfileName like '%" + s + "%' and Status != 7)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr[0].ToString().Trim().Length > 0 && dr[0] != null && !dr[0].ToString().Trim().Equals(""))
                            {
                                JsonDocument doc = JsonDocument.Parse(dr[0].ToString());
                                JsonElement root = doc.RootElement;
                                for (int i = 0; i < root.GetArrayLength(); i++)
                                {
                                    string indexName = root[i].GetProperty("indexName").ToString().Trim();
                                    string indexValueQC = root[i].GetProperty("indexValueQC").ToString().Trim();

                                    if (!indexName.Equals("Ghi chú") && indexValueQC != null && indexValueQC != "") countField++;
                                }
                            }
                        }
                        con.Close();
                    }

                    arr[row, 0] = "Số trường: " + s;
                    arr[row, 1] = countField.ToString();
                    row++;
                }
            }

            Utils.ExportThongKe(arr, "Sheet", "Title");
        }

        public void TrungHoSo()
        {
            string txtPath = @"\\192.168.31.206\Share\JPG (đã kiểm tra)\trung.txt";
            File.WriteAllText(txtPath, String.Empty);
            using (StreamWriter writer = File.AppendText(txtPath))
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=ADDJ_AnGiang;Integrated Security=True"))
                {
                    string sql = "use ADDJ_AnGiang; " +
                    "select ProfileName, BatchName, count(*) as SoLuong from TblBatchManagement where Status not in (7, 2, 8, 9) and StatusOutPut not in (0, 1) and StatusUpload not in (0) group by ProfileName, BatchName having count(*) > 1 order by ProfileName, BatchName ";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            using (SqlConnection connect = new SqlConnection(@"Data Source=.;Initial Catalog=ADDJ_AnGiang;Integrated Security=True"))
                            {
                                string query = "select m.Metadata from TblBatchManagement b join TblMetadata m on b.BatchManagementID = m.BatchID" +
                                    " where ProfileName = '" + dr[0]+"' " +
                                    "and BatchName = N'"+dr[1]+"'";
                                using (SqlCommand command = new SqlCommand(query, connect))
                                {
                                    command.CommandType = CommandType.Text;
                                    connect.Open();
                                    SqlDataReader datareader = command.ExecuteReader();
                                    while (datareader.Read())
                                    {
                                        if (datareader[0].ToString().Trim().Length > 0 && datareader[0] != null && !datareader[0].ToString().Trim().Equals(""))
                                        {
                                            JsonDocument doc = JsonDocument.Parse(datareader[0].ToString());
                                            JsonElement root = doc.RootElement;
                                            writer.Write(dr[0] + "\t" + dr[1] + "\t");
                                            for (int i = 0; i < root.GetArrayLength(); i++)
                                            {
                                                writer.Write(root[i].GetProperty("indexValueQC").ToString().Trim() +"\t");
                                            }
                                            writer.WriteLine();
                                        }
                                    }
                                    writer.WriteLine();
                                }
                                connect.Close();
                            }
                        }
                        con.Close();
                    }
                }
            }
        }

        public void HuanHuyChuong()
        {
            string txtPath = @"\\192.168.31.206\Share\JPG (đã kiểm tra)\hhc.txt";
            File.WriteAllText(txtPath, String.Empty);
            using (StreamWriter writer = File.AppendText(txtPath))
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=ADDJ_AnGiang;Integrated Security=True"))
                {
                    string sql = "use ADDJ_AnGiang; " +
                    "select  m.Metadata, ProfileName, TenDonVi, HoSoSo, m.BatchID, DocID " +
                    "from TblBatchManagement b join TblMetadata m on b.BatchManagementID = m.BatchID " +
                    "where ProfileName like N'%HSHHC_dinh-chinh-thong-tin%' and Status not in (7, 2, 8, 9) and StatusOutPut not in (0, 1) and StatusUpload not in (0)  " +
                    "order by BatchManagementID";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader datareader = cmd.ExecuteReader();
                        while (datareader.Read())
                        {
                            using (SqlConnection connect = new SqlConnection(@"Data Source=.;Initial Catalog=ADDJ_AnGiang;Integrated Security=True"))
                            {
                                if (datareader[0].ToString().Trim().Length > 0 && datareader[0] != null && !datareader[0].ToString().Trim().Equals(""))
                                {
                                    JsonDocument doc = JsonDocument.Parse(datareader[0].ToString());
                                    JsonElement root = doc.RootElement;
                                    writer.Write(datareader[4] + "\t" + datareader[5] + "\t" + datareader[1] + "\t" + datareader[2] + "\t" + datareader[3] + "\t");
                                    for (int i = 0; i < root.GetArrayLength(); i++)
                                    {
                                        writer.Write(removeChar(root[i].GetProperty("indexValueQC").ToString().Trim()) + "\t");
                                    }
                                    writer.WriteLine();
                                }
                            }
                        }
                        con.Close();
                    }
                }
            }
        }

        public void countProfile(string path)
        {
            //thống kê ảnh
            string txtPath = @"\\192.168.31.206\Share\JPG (đã kiểm tra)\count.txt";
            File.WriteAllText(txtPath, String.Empty);
            using (StreamWriter writer = File.AppendText(txtPath))
            {
                string[] arrPathJpg = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);
                List<string> listHoSo = new List<string>();
                foreach (string str in arrPathJpg)
                {
                    listHoSo.Add(Directory.GetParent(str) + "");
                }

                foreach (string strList in listHoSo.Distinct().ToList())
                {
                    writer.WriteLine(strList);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Errors(); 
            Close();
        }

        public static bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        public string removeChar(string tst)
        {
            var rgx4 = new Regex(@"[\r\n'/\\]");
            tst = rgx4.Replace(tst, string.Empty);
            return tst;
        }

    }
}
