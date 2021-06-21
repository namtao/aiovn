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

        public void ExportDataEntry()
        {
            File.WriteAllText(@"\\192.168.31.206\Share\JPG (đã kiểm tra)\dataentry.txt", String.Empty);
            using (StreamWriter streamWriter = File.AppendText(@"\\192.168.31.206\Share\JPG (đã kiểm tra)\dataentry.txt"))
            {

                SqlConnection sql1 = new SqlConnection(@"Data Source=.;Initial Catalog=ADDJ_AnGiang;Integrated Security=True");
                sql1.Open();
                sql1.Close();
                using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=ADDJ_AnGiang;Integrated Security=True"))
                {
                    string sql = "use ADDJ_AnGiang; " +
                    "select ProfileName, e.BatchID , BatchName, HoSoSo, RoleNameVie, FullName, m.Metadata " +
                    "from TblDataEntryHistory e join TblUser u on e.UserID = u.Id join TblBatchManagement b " +
                    "on e.BatchID = b.BatchManagementID join TblRole r on r.ID = e.RoleID join TblMetadata m " +
                    "on b.BatchManagementID = m.BatchID " +
                    "where convert(varchar, DateEnd, 103) = '" + dateTimePicker1.Value.ToString("dd/MM/yyyy") + "' and Status = 6 and StatusOutPut = 2";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            JsonDocument doc = JsonDocument.Parse(dr[6].ToString());
                            JsonElement root = doc.RootElement;

                            streamWriter.Write(dr[0].ToString());
                            //streamWriter.Write("\t" + dr[1].ToString());
                            streamWriter.Write("\t" + dr[2].ToString());
                            //streamWriter.Write("\t" + dr[3].ToString());
                            streamWriter.Write("\t" + dr[4].ToString());
                            streamWriter.Write("\t" + dr[5].ToString());

                            for (int i = 0; i < root.GetArrayLength(); i++)
                            {
                                streamWriter.WriteLine();
                                streamWriter.Write("\t" + root[i].GetProperty("indexName").ToString().Trim());
                                if (dr[4].ToString().Equals("Nhập liệu")) streamWriter.Write("\t" + root[i].GetProperty("indexValue").ToString().Trim());
                                if (dr[4].ToString().Equals("Nhập liệu lần 2")) streamWriter.Write("\t" + root[i].GetProperty("indexValue2").ToString().Trim());
                                //streamWriter.Write("\t" + root[i].GetProperty("indexValueQC").ToString().Trim());
                            }
                            streamWriter.WriteLine();
                        }
                        con.Close();
                    }
                }
            }
        }

        public void Diff()
        {
            using (StreamWriter streamWriter = File.AppendText(@"\\192.168.31.206\Share\JPG (đã kiểm tra)\empty.txt"))
            {

                SqlConnection sql1 = new SqlConnection(@"Data Source=.;Initial Catalog=ADDJ_AnGiang;Integrated Security=True");
                string[] loai = { "HSLS", "HSHHC" };
                object[,] arr = null;
                foreach (string s in loai)
                {
                    sql1.Open();
                    int rows = Int32.Parse((new SqlCommand("SELECT COUNT(*) FROM TblMetadata " +
                    "where BatchID in (select BatchManagementID from TblBatchManagement where ProfileName like '%" + s + "%')", sql1).ExecuteScalar()).ToString());
                    arr = new object[rows * rows, 10];
                    int countField = 0;
                    int row = 0;
                    int count = 0;
                    //int bm0 = Int32.Parse((new SqlCommand("select COUNT(*) from TblBatchManagement where BatchManagementID not in (select BatchID from TblDataEntryHistory) and ProfileName like '%"+s+"%'", sql1).ExecuteScalar()).ToString());
                    //int bm1 = Int32.Parse((new SqlCommand("SELECT COUNT(*) FROM (SELECT COUNT(*) AS SoLuong FROM TblDataEntryHistory group by BatchID having count(*) = 1) a", sql1).ExecuteScalar()).ToString());
                    //int bm2 = Int32.Parse((new SqlCommand("SELECT COUNT(*) FROM (SELECT COUNT(*) AS SoLuong FROM TblDataEntryHistory group by BatchID having count(*) = 2) a", sql1).ExecuteScalar()).ToString());
                    //int kt = Int32.Parse((new SqlCommand("SELECT COUNT(*) FROM (SELECT COUNT(*) AS SoLuong FROM TblDataEntryHistory group by BatchID having count(*) > 2) a", sql1).ExecuteScalar()).ToString());
                    sql1.Close();
                    using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=ADDJ_AnGiang;Integrated Security=True"))
                    {
                        string sql = "use ADDJ_AnGiang; " +
                        "SELECT Metadata, BatchID FROM TblMetadata " +
                        "where BatchID in (select BatchManagementID from TblBatchManagement where ProfileName like '%" + s + "%')";
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

                                        if ((indexValue == null || indexValue == "") && (indexValue2 == null || indexValue2 == "")
                                            && (indexValueQC == null || indexValueQC == ""))
                                        {
                                            streamWriter.WriteLine(dr[1]);
                                        }

                                        if (indexValueQC != null && indexValueQC != "") countField++;

                                        if ((indexValue != null && indexValue != "")
                                            && (indexValue2 != null && indexValue2 != "") &&
                                            !indexValue.ToString().Trim().ToUpper().Equals(indexValue2.ToString().Trim().ToUpper()))
                                        {
                                            SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=ADDJ_AnGiang;Integrated Security=True");
                                            string str = "use ADDJ_AnGiang; SELECT FullName FROM TblDataEntryHistory d join TblUser u on d.UserID = u.Id where BatchID = " + dr[1].ToString() +
                                                " order by DateEnd";
                                            using (SqlCommand cmd2 = new SqlCommand(str, conn))
                                            {
                                                conn.Open();
                                                cmd2.CommandType = CommandType.Text;
                                                SqlDataReader dataReader = cmd2.ExecuteReader();
                                                while (dataReader.Read())
                                                {
                                                    SqlConnection conStr = new SqlConnection(@"Data Source=.;Initial Catalog=ADDJ_AnGiang;Integrated Security=True");
                                                    string sqlString = "select ProfileName, BatchName from TblBatchManagement where BatchManagementID = " + dr[1].ToString();
                                                    using (SqlCommand sqlCommand = new SqlCommand(sqlString, conStr))
                                                    {
                                                        conStr.Open();
                                                        sqlCommand.CommandType = CommandType.Text;
                                                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                                                        while (sqlDataReader.Read())
                                                        {
                                                            arr[row, 0] = sqlDataReader[0].ToString() + ": " + sqlDataReader[1].ToString();
                                                        }
                                                        conStr.Close();
                                                    }

                                                    arr[row, 1] = dr[1].ToString();
                                                    arr[row, 2] = indexName;
                                                    if (count == 0) arr[row, 3] = dataReader[0].ToString() + ": " + indexValue;
                                                    if (count == 1) arr[row, 4] = dataReader[0].ToString() + ": " + indexValue2;
                                                    count++;
                                                }
                                                conn.Close();
                                                count = 0;
                                                row++;
                                            }
                                        }

                                    }


                                }
                            }
                            con.Close();
                        }
                    }
                    MessageBox.Show(s + ": " + countField.ToString() + " trường", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MessageBox.Show("Chưa biên mục: "+bm0+"\nHoàn thành biên mục 1: " + bm1 + " \nHoàn thành biên mục 2: " + bm2+ "\nHoàn thành kiểm tra: " + kt, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    /*DialogResult res = MessageBox.Show("Bạn có muốn xuất dữ liệu biên mục "+s+" không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (res == DialogResult.Yes)
                    {
                        Utils.ExportThongKe(arr, "So sánh", "So sánh giữa các lần biên mục");
                    }
                    if (res == DialogResult.No)
                    {

                    }*/
                }
            }
        }

        //Thống kê trường + copy k mã
        public void ThongKe(string path)
        {
            string txtPath = @"\\192.168.31.206\Share\JPG (đã kiểm tra)\nocode.txt";
            File.WriteAllText(txtPath, String.Empty);
            object[,] arr = new object[10 * 10, 10];
            int row = 0;
            int index = 0;
            //thống kê ảnh
            foreach (string pathDir in Directory.GetDirectories(path))
            {
                using (StreamWriter writer = File.AppendText(txtPath))
                {
                    string[] arrPathJpg = Directory.GetFiles(pathDir, "*.jpg", SearchOption.AllDirectories);
                    List<string> listNoCode = new List<string>();
                    List<string> listHoSo = new List<string>();
                    foreach (string str in arrPathJpg)
                    {
                        //listHoSo.Add(Directory.GetParent(str) + "");
                        if ((new DirectoryInfo(str).Parent.Name.Trim().Length >= 3) && !IsNumber(new DirectoryInfo(str).Parent.Name.Substring(0, 3))
                            && !IsNumber(new DirectoryInfo(str).Parent.Name.Substring(new DirectoryInfo(str).Parent.Name.Length - 3, 3)))
                        {
                            listNoCode.Add(Directory.GetParent(str) + "");

                            string dst = Path.Combine(@"\\192.168.31.206\Share\JPG không mã", @"CĐHH\Bổ sung", new DirectoryInfo(pathDir).Name.Trim(), new DirectoryInfo(str).Parent.Name.ToString());

                            if (!Directory.Exists(dst))
                                Directory.CreateDirectory(dst);
                            if (!File.Exists(Path.Combine(dst, new DirectoryInfo(str).Name)))
                                File.Copy(str, Path.Combine(dst, new DirectoryInfo(str).Name));
                            else
                            {
                                index++;
                                File.Copy(str, Path.Combine(dst, index + new DirectoryInfo(str).Name));
                            }
                        }
                    }

                    foreach (string strList in listNoCode.Distinct().ToList())
                    {
                        writer.WriteLine(strList);
                    }

                    /*arr[row, 0] = new DirectoryInfo(pathDir).Name.Trim();
                    arr[row, 1] = arrPathJpg.Length.ToString();
                    arr[row, 2] = listNoCode.Distinct().ToList().Count.ToString();
                    arr[row, 3] = listHoSo.Distinct().ToList().Count.ToString();
                    row++;*/
                }
            }

            /*int tongJpg = 0, tongKhongMa = 0, tongHoSo = 0;

            for(int i = 0; i < row; i++)
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
            string[] loai = { "HSLS", "HSHHC", "HSTBA", "HSBB", "HSCDHH" };
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
                    "where BatchID in (select BatchManagementID from TblBatchManagement where ProfileName like '%" + s + "%')";
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

                                    if (indexValueQC != null && indexValueQC != "") countField++;
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

            Utils.ExportThongKe(arr, "Sheet", "Title");*/
        }
        
        //Copy 89 23
        public void CopyCĐHH89(string path)
        {
            foreach (string pathDir in Directory.GetDirectories(path))
            {
                string[] arrPathJpg = Directory.GetFiles(pathDir, "*.jpg", SearchOption.AllDirectories);
                //List<string> listNoCode = new List<string>();
                List<string> listHoSo = new List<string>();
                foreach (string str in arrPathJpg)
                {
                    //kiểm tra có phải số không
                    if(str.Split('\\')[9].Contains("54") || str.Split('\\')[9].Contains("26") ||
                        Utils.IsNumber(str.Split('\\')[9].Substring(0, 1)))
                    {
                        //kiểm tra có phải 8 hoặc 9 không
                        if(str.Split('\\')[9].Contains("54") || str.Split('\\')[9].Contains("26") ||
                            Int32.Parse(str.Split('\\')[9].Substring(0, 1)) == 8 || Int32.Parse(str.Split('\\')[9].Substring(0, 1)) == 9)
                        {
                            //kiểm tra có ảnh <=3 không
                            if(Directory.GetFiles(Directory.GetParent(str).ToString(), "*.jpg", SearchOption.AllDirectories).Length <= 3)
                            {
                                string root = "";
                                for (int i = 7; i< str.Split('\\').Length; i++)
                                {
                                    root = Path.Combine(root, str.Split('\\')[i]);
                                }

                                root = Path.Combine(@"\\192.168.31.206\Share\CĐHH 8 9", root);

                                if (!Directory.Exists(Directory.GetParent(root).ToString()))
                                    Directory.CreateDirectory(Directory.GetParent(root).ToString());

                                File.Copy(str, root);
                            }
                        }
                    }
                }
            }
        }

        //Copy CĐHH cần import
        public void CopyCĐHHImport(string path)
        {
            foreach (string pathDir in Directory.GetDirectories(path))
            {
                string[] arrPathJpg = Directory.GetFiles(pathDir, "*.jpg", SearchOption.AllDirectories);
                List<string> listCode = new List<string>();
                foreach (string str in arrPathJpg)
                {
                    if (!str.Split('\\')[9].Contains("54") && !str.Split('\\')[9].Contains("26")
                        && IsNumber(str.Split('\\')[9].Substring(0, 1))
                        && Int32.Parse(str.Split('\\')[9].Substring(0, 1)) != 8 && Int32.Parse(str.Split('\\')[9].Substring(0, 1)) != 9
                        && ((new DirectoryInfo(str).Parent.Name.Trim().Length >= 3) && (IsNumber(new DirectoryInfo(str).Parent.Name.Substring(0, 3))
                            || IsNumber(new DirectoryInfo(str).Parent.Name.Substring(new DirectoryInfo(str).Parent.Name.Length - 3, 3)))))
                    {
                        string root = "";
                        for (int i = 7; i < str.Split('\\').Length; i++)
                        {
                            root = Path.Combine(root, str.Split('\\')[i]);
                        }

                        root = Path.Combine(@"\\192.168.31.206\Share\JPG CĐHH Import", root);

                        if (!Directory.Exists(Directory.GetParent(root).ToString()))
                            Directory.CreateDirectory(Directory.GetParent(root).ToString());

                        File.Copy(str, root);
                    }
                }
            }
        }

        //Thống kê số lượng hồ sơ 89
        public void ThongKeCĐHH89(string path)
        {
            foreach (string pathDir in Directory.GetDirectories(path))
            {
                using (StreamWriter writer = File.AppendText(@"\\192.168.31.206\Share\JPG (đã kiểm tra)\CDHH.txt"))
                {
                    string[] arrPathJpg = Directory.GetFiles(pathDir, "*.jpg", SearchOption.AllDirectories);
                    List<string> listHoSo89 = new List<string>();
                    foreach (string str in arrPathJpg)
                    {
                        //kiểm tra có phải số không
                        if ((new DirectoryInfo(str).Parent.Name.Trim().Length >= 3) && !IsNumber(new DirectoryInfo(str).Parent.Name.Substring(0, 3))
                            && !IsNumber(new DirectoryInfo(str).Parent.Name.Substring(new DirectoryInfo(str).Parent.Name.Length - 3, 3)))
                        {
                            if (str.Split('\\')[9].Contains("54") || str.Split('\\')[9].Contains("26") ||
                            Utils.IsNumber(str.Split('\\')[9].Substring(0, 1)))
                            {
                                //kiểm tra có phải 8 hoặc 9 không
                                if (str.Split('\\')[9].Contains("54") || str.Split('\\')[9].Contains("26") ||
                                    Int32.Parse(str.Split('\\')[9].Substring(0, 1)) == 8 || Int32.Parse(str.Split('\\')[9].Substring(0, 1)) == 9)
                                {
                                    listHoSo89.Add(Directory.GetParent(str) + "");
                                }
                            }
                        }
                    }

                    foreach (string strList in listHoSo89.Distinct().ToList())
                    {
                        writer.WriteLine(strList);
                    }
                }
            }
        }

        //Thống kê số lượng hồ sơ 1
        public void ThongKeCĐHH1(string path)
        {
            int count1 = 0;
            using (StreamWriter writer = File.AppendText(@"\\192.168.31.206\Share\JPG (đã kiểm tra)\CDHH.txt"))
            {

                foreach (string pathDir in Directory.GetDirectories(path))
                {
                    string[] arrPathJpg = Directory.GetFiles(pathDir, "*.jpg", SearchOption.AllDirectories);
                    List<string> listHoSo1 = new List<string>();
                    foreach (string str in arrPathJpg)
                    {
                        string x = new DirectoryInfo(Directory.GetParent(str).ToString()).Parent.Name.Substring(0, 2);
                        if (IsNumber(new DirectoryInfo(Directory.GetParent(str).ToString()).Parent.Name.Substring(0, 1))
                            && Int32.Parse(new DirectoryInfo(Directory.GetParent(str).ToString()).Parent.Name.Substring(0, 1)) == 1
                            && !IsNumber(new DirectoryInfo(Directory.GetParent(str).ToString()).Parent.Name.Substring(0, 2)))
                        {
                            listHoSo1.Add(Directory.GetParent(str) + "");
                        }
                    }

                    foreach (string strList in listHoSo1.Distinct().ToList())
                    {
                        count1++;
                        writer.WriteLine(strList);
                    }
                }
            }
            MessageBox.Show(count1 + "");
        }

        //thống kê đường dẫn thư mục
        public void ThongKePathJpg(string path)
        {
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
                        listNoCode.Add(Directory.GetParent(str) + "");
                    }

                    foreach (string strList in listNoCode.Distinct().ToList())
                    {
                        writer.WriteLine(strList);
                    }
                }
            }
        }


        public void getFields()
        {
            //thống kê trường
            SqlConnection sql1 = new SqlConnection(@"Data Source=.;Initial Catalog=ADDJ_AnGiang;Integrated Security=True");
            string[] loai = { "HSLS", "HSHHC" };
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
                    "where BatchID in (select BatchManagementID from TblBatchManagement where ProfileName like '%" + s + "%')";
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

                                    if (indexValueQC != null && indexValueQC != "") countField++;
                                }
                            }
                        }
                        con.Close();
                    }
                    MessageBox.Show(s + ": " + countField.ToString() + " trường", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = @"\\192.168.31.206\Share\JPG (đã kiểm tra)\Thai Binh\CĐHH";

            ThongKePathJpg(@"\\192.168.31.206\Share\JPG (đã kiểm tra)\Thai Binh\CĐHH\CHAT DOC HOA HOC BS");
            //ThongKeCĐHH1(path);
            //CopyCĐHH89(path);
            //CopyCĐHHImport(path);
            //ThongKeCĐHH89(path);
            //MessageBox.Show("Xong!!!");
            Close();
        }

        public void getParentPath(string path)
        {
            string txtPath = @"\\192.168.31.206\Share\JPG (đã kiểm tra)\nocode.txt";
            using (StreamWriter writer = File.AppendText(txtPath))
            {
                string[] arrPathJpg = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);
                List<string> listNoCode = new List<string>();
                List<string> listHoSo = new List<string>();
                foreach (string str in arrPathJpg)
                {
                    MessageBox.Show(str);

                    listHoSo.Add(Directory.GetParent(str) + "");
                    if ((new DirectoryInfo(str).Parent.Name.Trim().Length >= 3) && !IsNumber(new DirectoryInfo(str).Parent.Name.Substring(0, 3))
                        && !IsNumber(new DirectoryInfo(str).Parent.Name.Substring(new DirectoryInfo(str).Parent.Name.Length - 3, 3)))
                        listNoCode.Add(Directory.GetParent(str) + "");
                }

                foreach (string strList in listNoCode.Distinct().ToList())
                {
                    writer.WriteLine(strList);
                }


                MessageBox.Show(path + " có " + arrPathJpg.Length + " ảnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(path + " có " + listNoCode.Distinct().ToList().Count + " trường hợp không mã", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(path + " có " + listHoSo.Distinct().ToList().Count + " hồ sơ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private void btnExe_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ExportDataEntry();
            MessageBox.Show(@"\\192.168.31.206\Share\JPG (đã kiểm tra)\dataentry.txt");
        }
    }
}
