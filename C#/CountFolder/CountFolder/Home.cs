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
using iTextSharp.text.pdf;

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

        public void KhongMa()
        {
            string txtPath = @"\\192.168.31.206\Share\JPG (đã kiểm tra)\hhc.txt";
            File.WriteAllText(txtPath, String.Empty);
            using (StreamWriter writer = File.AppendText(txtPath))
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=ADDJ_AnGiang;Integrated Security=True"))
                {
                    string sql = "use ADDJ_AnGiang; " +
                    "select  m.Metadata, ProfileName, TenDonVi, HoSoSo, m.BatchID, DocID " +
                    "from TblBatchManagement b join TblMetadata m on b.BatchManagementID = m.BatchID" +
                    " where (ISNUMERIC(left(HoSoSo, 4)) = 0 and left(HoSoSo, 1) not like 'A') " +
                    "and ProfileName not like '%hhc%' and ProfileName like '%hs%' " +
                    "and Status not in (7, 9) and StatusOutPut not in (0, 1) " +
                    "and StatusUpload not in (0) and ProfileName not like '%khong%' " +
                    "and ProfileName not like '%TBA%' order by TenDonVi, ProfileName, HoSoSo";
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

        public static string convertToUnSign(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        public void editCDHH()
        {
            File.WriteAllText(@"\\192.168.31.206\Share\JPG (đã kiểm tra)\Thai Binh\CĐHH\chưa tìm đc mã\Rename.txt", String.Empty);
            File.WriteAllText(@"\\192.168.31.206\Share\JPG (đã kiểm tra)\Thai Binh\CĐHH\chưa tìm đc mã\Error.txt", String.Empty);
            string path = @"\\192.168.31.206\Share\JPG (đã kiểm tra)\Thai Binh\CĐHH\chưa tìm đc mã";
            //liệt kê hết các huyện
            List<string> listHuyen = Directory.GetDirectories(path).ToList();

            //liệt kê hết các xã trong 1 huyện
            foreach (string strHuyen in listHuyen)
            {
                List<string> listXa = Directory.GetDirectories(strHuyen).ToList();
                foreach (string strXa in listXa)
                {
                    List<string> listNguoiTrongXa = new List<string>();
                    string[] arrJpg = Directory.GetFiles(strXa, "*.jpg", SearchOption.AllDirectories);
                    foreach (string strJpg in arrJpg)
                    {
                        listNguoiTrongXa.Add(Directory.GetParent(strJpg) + "");
                    }
                    listNguoiTrongXa = listNguoiTrongXa.Distinct().ToList();

                    int i = 1;
                    foreach (string st in listNguoiTrongXa)
                    {
                        //lấy tên huyện + xã trong folderName
                        string huyenFolderName = new DirectoryInfo(strHuyen + "").Name;
                        string xaFolderName = new DirectoryInfo(strXa + "").Name;


                        //lấy danh sách mã trong db
                        List<string> listMaHoSo = new List<string>();
                        using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=ThaiBinh;Integrated Security=True"))
                        {
                            string sql = "select mahoso from ghep " +
                                "where (select dbo.non_unicode_convert (huyen)) = (select dbo.non_unicode_convert (N' Huyện ' + N'" + huyenFolderName + "')) " +
                                "and (select dbo.non_unicode_convert (xa)) = (select dbo.non_unicode_convert (N'" + xaFolderName + "'))";
                            using (SqlCommand cmd = new SqlCommand(sql, con))
                            {
                                cmd.CommandType = CommandType.Text;
                                con.Open();
                                SqlDataReader dr = cmd.ExecuteReader();
                                while (dr.Read())
                                {
                                    listMaHoSo.Add(dr[0] + "");
                                }
                                con.Close();
                            }

                            listMaHoSo = listMaHoSo.Distinct().ToList();
                        }

                        //tìm mã thích hợp và thực hiện đổi mã
                        try
                        {
                            while (true)
                            {
                                string nguoiCoMa = i.ToString().PadLeft(3, '0');
                                if (!listMaHoSo.Contains("A" + nguoiCoMa))
                                {
                                    string nguoiKhongMa = new DirectoryInfo(st + "").Name;

                                    //thực hiện đổi tên thư mục
                                    string tenMoi = Path.Combine(Directory.GetParent(st) + "", "A" + nguoiCoMa + " - " + nguoiKhongMa);

                                    System.IO.Directory.Move(st , tenMoi);
                                    using (StreamWriter writer = File.AppendText(@"\\192.168.31.206\Share\JPG (đã kiểm tra)\Thai Binh\CĐHH\chưa tìm đc mã\Rename.txt"))
                                    {
                                        writer.WriteLine(Directory.GetParent(st) + ": "+ nguoiKhongMa + " => A" + nguoiCoMa + " - " + nguoiKhongMa);
                                    }
                                    break;
                                }
                                else i++;
                            }
                            i++;
                        } 
                        catch (Exception ex)
                        {
                            using (StreamWriter writer = File.AppendText(@"\\192.168.31.206\Share\JPG (đã kiểm tra)\Thai Binh\CĐHH\chưa tìm đc mã\Error.txt"))
                            {
                                writer.WriteLine(st);
                            }
                        }
                    }
                }
            }            
        }

        public void chuyendoi()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=ThaiBinh;Integrated Security=True"))
            {
                string sql = "select mahoso, xa, huyen from ghep order by mahoso";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        string[] arrPathJpg = Directory.GetFiles(@"\\192.168.31.206\Share\Đông Kinh\TNXP_HT", dr[0] + ".pdf",
                            SearchOption.AllDirectories);
                        string maso = dr[0].ToString().Substring(dr[0].ToString().Length - 4, 4);
                        string path = Path.Combine(@"\\192.168.31.206\Share\JPG (đã kiểm tra)\Thai Binh\14. Đông Kinh - TNXP_TCHT", dr[2].ToString(), dr[1].ToString(), maso);
                        if (!System.IO.Directory.Exists(path))
                            Directory.CreateDirectory(Path.Combine(path));

                        System.IO.File.Copy(arrPathJpg[0], Path.Combine(path, dr[0].ToString() + ".pdf"));
                    }
                    con.Close();
                }
            }

            /*string[] arrPathJpg = Directory.GetFiles(@"D:\Share\Đông Kinh\TNXP_TCML", "*.pdf",
                            SearchOption.AllDirectories);
            int numberOfPages = 0;
            foreach(string str in arrPathJpg)
            {
                PdfReader pdfReader = new PdfReader(str);
                numberOfPages += pdfReader.NumberOfPages;
            }

            MessageBox.Show(numberOfPages + "");*/
        }

        public void hhcTangMoi()
        {
            string[] arrPathJpg = Directory.GetFiles(@"\\192.168.31.206\Share\JPG (đã kiểm tra)\Thai Binh\02. huan huy chuong\tang moi co ma tren phan mem", "*.jpg", 
                SearchOption.AllDirectories);
            List<string> listHoSo = new List<string>();
            foreach (string str in arrPathJpg)
            {
                listHoSo.Add(Directory.GetParent(str) + "");
            }

            listHoSo = listHoSo.Distinct().ToList();

            string huyen, xa;
            foreach (string pathDir in Directory.GetDirectories(@"\\192.168.31.206\Share\JPG (đã kiểm tra)\Thai Binh\02. huan huy chuong\tang moi co ma tren phan mem"))
            {
                //tìm tên huyện
                huyen = new DirectoryInfo(pathDir).Name;
                foreach (string pathDir2 in Directory.GetDirectories(Path.Combine(@"\\192.168.31.206\Share\JPG (đã kiểm tra)\Thai Binh\02. huan huy chuong\tang moi co ma tren phan mem", huyen)))
                {
                    //tìm tên xã
                    xa = new DirectoryInfo(pathDir2).Name;

                }
            }
        }

        public void hhc()
        {
            string pathDir = @"\\192.168.31.206\Share\JPG (đã kiểm tra)\hhc.txt";
            File.WriteAllText(pathDir, String.Empty);
            using (StreamWriter streamWriter = File.AppendText(pathDir))
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=ADDJ_AnGiang;Integrated Security=True"))
                {
                    string sql = "use ADDJ_AnGiang; " +
                    "select BatchName, m.Metadata, ProfileName from TblBatchManagement b join TblMetadata m " +
                    "on b.BatchManagementID = m.BatchID where ProfileName like '%hhc%' " +
                    "and Status not in (7, 9) and StatusOutPut not in (0, 1) and StatusUpload not in (0) and ProfileName not like '%khong%'";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            JsonDocument doc = JsonDocument.Parse(dr[1].ToString());
                            JsonElement root = doc.RootElement;
                            streamWriter.Write(dr[0] + "\t" + dr[2] + "\t");
                            for (int i = 0; i < root.GetArrayLength(); i++)
                            {
                                string indexName = root[i].GetProperty("indexName").ToString().Trim();
                                string indexValue = root[i].GetProperty("indexValue").ToString().Trim();
                                string indexValue2 = root[i].GetProperty("indexValue2").ToString().Trim();
                                string indexValueQC = root[i].GetProperty("indexValueQC").ToString().Trim();

                                streamWriter.Write(indexValueQC + "\t");
                            }
                            streamWriter.WriteLine();
                        }
                        con.Close();
                    }
                }
            }
        }

        public void countPages()
        {
            string[] arrPathJpg = Directory.GetFiles(@"\\192.168.31.206\Share\JPG (đã kiểm tra)\Thai Binh\12. Đông Kinh - 62_TCML", "*.pdf",
                            SearchOption.AllDirectories);
            int numberOfPages = 0;
            foreach (string str in arrPathJpg)
            {
                PdfReader pdfReader = new PdfReader(str);
                numberOfPages += pdfReader.NumberOfPages;
            }

            MessageBox.Show(numberOfPages + "");
        }

        public void kiemtra()
        {
            string txtPath = @"\\192.168.31.206\Share\JPG (đã kiểm tra)\kiemtra.txt";
            File.WriteAllText(txtPath, String.Empty);
            string path = @"\\192.168.31.206\Share\JPG (đã kiểm tra)\Thai Binh\13. Đông Kinh - TNXP_TCML";

            /*foreach (string pathDir in Directory.GetDirectories(path))
            {
                foreach (string pathDir2 in Directory.GetDirectories(pathDir))
                {
                    foreach (string pathDir3 in Directory.GetDirectories(pathDir2))
                    {
                        using (StreamWriter writer = File.AppendText(txtPath))
                        {
                            string[] arrPathPdf = Directory.GetFiles(pathDir3, "*.pdf", SearchOption.AllDirectories);
                            if(arrPathPdf.Length > 1) writer.WriteLine(pathDir3);
                        }
                    }
                }
            }*/
            foreach (string pathDir in Directory.GetDirectories(path))
            {
                foreach (string pathDir2 in Directory.GetDirectories(pathDir))
                {
                    using (StreamWriter writer = File.AppendText(txtPath))
                    {
                        string[] arrPathPdf = Directory.GetFiles(pathDir2, "*.pdf", SearchOption.AllDirectories);
                        writer.WriteLine(pathDir2 + "\t" + arrPathPdf.Length);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kiemtra();
            MessageBox.Show("Xong!!!");
            Close();
        }

        private void Q10()
        {
            object[,] arr = new object[1000, 100];
            string ndk = "", nam = "", sotruonghop = "", soquyen = "";
            int count = 0;
            using (SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = HoTich; Integrated Security = True"))
            {
                string sql = "select RIGHT(quyenso, 4), noiDangKy from HT_NHANCHAMECON " +
                    "where RIGHT(quyenSo, 4) between 2007 and 2015 group by RIGHT(quyenso, 4), noiDangKy order by noiDangKy, RIGHT(quyenso, 4)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        using (SqlConnection con2 = new SqlConnection(@"Data Source =.; Initial Catalog = HoTich; Integrated Security = True"))
                        {
                            string sql2 = "select count(*) as 'Số lượng' " +
                                "from (select distinct quyenSo from HT_NHANCHAMECON " +
                                "where noiDangKy = " + dr[1] + " and quyenSo like '%/" + dr[0] + "%') a";

                            using (SqlCommand cmd2 = new SqlCommand(sql2, con2))
                            {
                                cmd2.CommandType = CommandType.Text;
                                con2.Open();
                                SqlDataReader dr2 = cmd2.ExecuteReader();
                                while (dr2.Read())
                                {
                                    arr[count, 4] = dr2[0];
                                }
                                con2.Close();
                            }
                        }

                        using (SqlConnection con3 = new SqlConnection(@"Data Source =.; Initial Catalog = HoTich; Integrated Security = True"))
                        {
                            string sql3 = "select  TenNoiDangKy, RIGHT(quyenSo, 4) as 'Năm',  count(*) as 'Số lượng' " +
                                "from HT_NHANCHAMECON ks join HT_NOIDANGKY ndk on ks.noiDangKy = ndk.MaNoiDangKy " +
                                "where noiDangKy = " + dr[1] + " and quyenSo like '%/" + dr[0] + "%' " +
                                "group by noiDangKy, TenNoiDangKy, RIGHT(quyenSo, 4) order by TenNoiDangKy, RIGHT(quyenSo, 4)";

                            using (SqlCommand cmd3 = new SqlCommand(sql3, con3))
                            {
                                cmd3.CommandType = CommandType.Text;
                                con3.Open();
                                SqlDataReader dr3 = cmd3.ExecuteReader();
                                while (dr3.Read())
                                {
                                    arr[count, 1] = dr3[0];
                                    arr[count, 2] = dr3[1];
                                    arr[count, 3] = dr3[2];
                                }
                                con3.Close();
                            }

                        }

                        count++;
                    }
                    con.Close();
                }
            }    

            Utils.ExportQ10(arr, "Q10");
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
