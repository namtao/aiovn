using iTextSharp.text.pdf;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADDJ.DuAn
{
    class ThaiBinh
    {
        string connectString = ConfigurationManager.ConnectionStrings["hotich"].ConnectionString;
        public void countFieldExcelTruoc()
        {
            // cho 3 loại của DK = 0, tổng người có công + văn bản + thân nhân chia đều cho số đối tượng của từng phông, còn lại để của liệt sỹ

            List<string> lstTable = new List<string> { "HS_NguoiCC", "HS_Vanban", "HS_ThanNhan",
                "HS_TT_LietSy", "HS_TT_ThanNhanLietSi", "HS_TT_BenhBinh", "HS_TT_ThanNhanBenhBinh",
                "HS_TT_ChatDocHoaHoc", "HS_TT_ThanNhanCDHH", "HS_TT_DichBatTuDay", "HS_TT_ThanNhanTuDay",
                "HS_TT_LaoThanhCachMang", "HS_TT_ThanNhanLTCM", "HS_TT_NguoiTangHuanChuong", "HS_TT_QuyetDinh62",
                "HS_TT_QuyetDinh62HT", "HS_TT_ThanNhanThuongBinh", "HS_TT_ThuongBinh", "HS_TT_TienKhoiNghia",
                "HS_TT_ThanNhanTKN", "HS_TT_TNXPHT", "HS_TT_TNXPML" };


            object[,] arr = new object[100, 2];
            arr[0, 0] = "Tên phông";
            arr[0, 1] = "Số trường";

            for (int i = 0; i < lstTable.Count; i++)
            {
                arr[i + 1, 0] = lstTable[i];
                arr[i + 1, 1] = countAllColumn(lstTable[i]);
            }

            object[,] array = new object[100, 100];
            double tongdu = Int32.Parse(arr[1, 1].ToString()) + Int32.Parse(arr[2, 1].ToString()) + Int32.Parse(arr[3, 1].ToString());

            double tb = 0;

            List<string> phong = new List<string> { "Liệt Sĩ", "Bệnh binh", "Người HĐCM và con đẻ bị nhiễm CĐHH",
                "Người HĐCM hoặc HĐKC bị địch bắt tù, đày", "Lão thành cách mạng", "Người HĐKC được tặng thưởng huân huy chương",
                "Người hưởng theo quyết định 62", "Người hưởng theo quyết định 62 hàng tháng", "Thương binh", "Tiền khởi nghĩa",
                "Thanh niên xung phong TCHT", "Thanh niên xung phong TCML" };
            List<int> tbint = new List<int>();
            for (int index = 0; index < phong.Count; index++)
            {
                array[index + 1, 0] = phong[index];
                using (SqlConnection con = new SqlConnection(connectString))
                {
                    con.Open();
                    string sql = "select count(*) from HS_NguoiCC ncc join DM_NhomDT n on ncc.IdNDT = n.Id where ten = N'" + phong[index] + "'";
                    tbint.Add(Int32.Parse((new SqlCommand(sql, con).ExecuteScalar().ToString())));
                }
            }

            array[0, 0] = "Tên phông";
            array[0, 1] = "Số trường";
            array[1, 1] = Int32.Parse(arr[4, 1].ToString()) + Int32.Parse(arr[5, 1].ToString());//Liệt Sĩ
            array[2, 1] = Int32.Parse(arr[6, 1].ToString()) + Int32.Parse(arr[7, 1].ToString()); //Bệnh binh
            array[3, 1] = Int32.Parse(arr[8, 1].ToString()) + Int32.Parse(arr[9, 1].ToString());//Người HĐCM và con đẻ bị nhiễm CĐHH
            array[4, 1] = Int32.Parse(arr[10, 1].ToString()) + Int32.Parse(arr[11, 1].ToString());//Người HĐCM hoặc HĐKC bị địch bắt tù, đày
            array[5, 1] = Int32.Parse(arr[12, 1].ToString()) + Int32.Parse(arr[13, 1].ToString()); //Lão thành cách mạng
            array[6, 1] = Int32.Parse(arr[14, 1].ToString());//Người HĐKC được tặng thưởng huân huy chương
            array[7, 1] = Int32.Parse(arr[15, 1].ToString());//Người hưởng theo quyết định 62
            array[8, 1] = Int32.Parse(arr[16, 1].ToString());//Người hưởng theo quyết định 62 hàng tháng
            array[9, 1] = Int32.Parse(arr[17, 1].ToString()) + Int32.Parse(arr[18, 1].ToString());//Thương binh
            array[10, 1] = Int32.Parse(arr[19, 1].ToString()) + Int32.Parse(arr[20, 1].ToString());//Tiền khởi nghĩa
            array[11, 1] = Int32.Parse(arr[21, 1].ToString());//Thanh niên xung phong TCHT
            array[12, 1] = Int32.Parse(arr[22, 1].ToString());//Thanh niên xung phong TCML


            int tongcu = 0;
            for (int i = 1; i <= 22; i++)
            {
                tongcu += Int32.Parse(arr[i, 1].ToString());
            }

            int hs62 = 0, hstnxpht = 0, hstnxp1 = 0, ncc = 0;

            //số lượng hồ sơ 62 sau khi update
            using (SqlConnection con = new SqlConnection(connectString))
            {
                con.Open();
                string sql = "select count(*) from HS_NguoiCC where IdNDT = 75";
                hs62 = (Int32.Parse((new SqlCommand(sql, con).ExecuteScalar().ToString())));
            }

            //số lượng hồ sơ tnxp hàng tháng
            using (SqlConnection con = new SqlConnection(connectString))
            {
                con.Open();
                string sql = "select count(*) from HS_NguoiCC where IdNDT = 79";
                hstnxpht = (Int32.Parse((new SqlCommand(sql, con).ExecuteScalar().ToString())));
            }

            //số lượng hồ sơ tnxp 1 lần
            using (SqlConnection con = new SqlConnection(connectString))
            {
                con.Open();
                string sql = "select count(*) from HS_NguoiCC where IdNDT = 80";
                hstnxp1 = (Int32.Parse((new SqlCommand(sql, con).ExecuteScalar().ToString())));
            }

            //số lượng người có công
            using (SqlConnection con = new SqlConnection(connectString))
            {
                con.Open();
                string sql = "select count(*) from HS_NguoiCC";
                ncc = (Int32.Parse((new SqlCommand(sql, con).ExecuteScalar().ToString())));
            }

            //tổng dư
            tongdu = tongdu + Int32.Parse(array[7, 1].ToString()) + Int32.Parse(array[11, 1].ToString()) + Int32.Parse(array[12, 1].ToString());

            //trung bình
            using (SqlConnection con = new SqlConnection(connectString))
            {
                con.Open();
                string sql = "select count(*) from HS_NguoiCC";
                tb = tongdu / (Int32.Parse((new SqlCommand(sql, con).ExecuteScalar().ToString())));
            }

            //điền dữ liệu
            array[7, 1] = 0;
            array[11, 1] = 0;
            array[12, 1] = 0;

            // điền dữ liệu còn lại dựa vào tongdu
            //array[1, 1] = Int32.Parse(arr[4, 1].ToString()) + Int32.Parse(arr[5, 1].ToString()) + tb * tbint[0];
            array[1, 1] = 0;
            array[2, 1] = Int32.Parse(arr[6, 1].ToString()) + Int32.Parse(arr[7, 1].ToString()) + Convert.ToInt32(tb * tbint[1]);
            array[3, 1] = Int32.Parse(arr[8, 1].ToString()) + Int32.Parse(arr[9, 1].ToString()) + Convert.ToInt32(tb * tbint[2]);
            array[4, 1] = Int32.Parse(arr[10, 1].ToString()) + Int32.Parse(arr[11, 1].ToString()) + Convert.ToInt32(tb * tbint[3]);
            array[5, 1] = Int32.Parse(arr[12, 1].ToString()) + Int32.Parse(arr[13, 1].ToString()) + Convert.ToInt32(tb * tbint[4]);
            array[6, 1] = Int32.Parse(arr[14, 1].ToString()) + Convert.ToInt32(tb * tbint[5]);
            array[8, 1] = Int32.Parse(arr[16, 1].ToString()) + Convert.ToInt32(tb * tbint[7]);
            array[9, 1] = Int32.Parse(arr[17, 1].ToString()) + Int32.Parse(arr[18, 1].ToString()) + Convert.ToInt32(tb * tbint[8]);
            array[10, 1] = Int32.Parse(arr[19, 1].ToString()) + Int32.Parse(arr[20, 1].ToString()) + Convert.ToInt32(tb * tbint[9]);

            int tongmoi = 0;
            for (int i = 0; i < 12; i++)
            {
                tongmoi += Int32.Parse(array[i + 1, 1].ToString());
            }

            array[1, 1] = tongcu - tongmoi;
            Utils.ExportExcel(array, "Sheet", 3, 1, 100, 2);
        }

        public void countFieldExcelSau()
        {
            List<string> lstTable = new List<string> { "HS_NguoiCC", "HS_Vanban", "HS_ThanNhan",
                "HS_TT_LietSy", "HS_TT_ThanNhanLietSi", "HS_TT_BenhBinh", "HS_TT_ThanNhanBenhBinh",
                "HS_TT_ChatDocHoaHoc", "HS_TT_ThanNhanCDHH", "HS_TT_DichBatTuDay", "HS_TT_ThanNhanTuDay",
                "HS_TT_LaoThanhCachMang", "HS_TT_ThanNhanLTCM", "HS_TT_NguoiTangHuanChuong", "HS_TT_QuyetDinh62",
                "HS_TT_QuyetDinh62HT", "HS_TT_ThanNhanThuongBinh", "HS_TT_ThuongBinh", "HS_TT_TienKhoiNghia",
                "HS_TT_ThanNhanTKN", "HS_TT_TNXPHT", "HS_TT_TNXPML" };


            object[,] arr = new object[100, 2];
            arr[0, 0] = "Tên phông";
            arr[0, 1] = "Số trường";

            for (int i = 0; i < lstTable.Count; i++)
            {
                arr[i + 1, 0] = lstTable[i];
                arr[i + 1, 1] = countAllColumn(lstTable[i]);
            }

            object[,] array = new object[100, 100];
            double tongdu = Int32.Parse(arr[1, 1].ToString()) + Int32.Parse(arr[2, 1].ToString()) + Int32.Parse(arr[3, 1].ToString());

            double tb = 0;

            List<string> phong = new List<string> { "Liệt Sĩ", "Bệnh binh", "Người HĐCM và con đẻ bị nhiễm CĐHH",
                            "Người HĐCM hoặc HĐKC bị địch bắt tù, đày", "Lão thành cách mạng", "Người HĐKC được tặng thưởng huân huy chương",
                            "Người hưởng theo quyết định 62", "Người hưởng theo quyết định 62 hàng tháng", "Thương binh", "Tiền khởi nghĩa",
                            "Thanh niên xung phong TCHT", "Thanh niên xung phong TCML" };
            List<int> tbint = new List<int>();
            for (int index = 0; index < phong.Count; index++)
            {
                array[index + 1, 0] = phong[index];
                using (SqlConnection con = new SqlConnection(connectString))
                {
                    con.Open();
                    string sql = "select count(*) from HS_NguoiCC ncc join DM_NhomDT n on ncc.IdNDT = n.Id where ten = N'" + phong[index] + "'";
                    tbint.Add(Int32.Parse((new SqlCommand(sql, con).ExecuteScalar().ToString())));
                }
            }

            array[0, 0] = "Tên phông";
            array[0, 1] = "Số trường";
            array[1, 1] = Int32.Parse(arr[4, 1].ToString()) + Int32.Parse(arr[5, 1].ToString());//Liệt Sĩ
            array[2, 1] = Int32.Parse(arr[6, 1].ToString()) + Int32.Parse(arr[7, 1].ToString()); //Bệnh binh
            array[3, 1] = Int32.Parse(arr[8, 1].ToString()) + Int32.Parse(arr[9, 1].ToString());//Người HĐCM và con đẻ bị nhiễm CĐHH
            array[4, 1] = Int32.Parse(arr[10, 1].ToString()) + Int32.Parse(arr[11, 1].ToString());//Người HĐCM hoặc HĐKC bị địch bắt tù, đày
            array[5, 1] = Int32.Parse(arr[12, 1].ToString()) + Int32.Parse(arr[13, 1].ToString()); //Lão thành cách mạng
            array[6, 1] = Int32.Parse(arr[14, 1].ToString());//Người HĐKC được tặng thưởng huân huy chương
            array[7, 1] = Int32.Parse(arr[15, 1].ToString());//Người hưởng theo quyết định 62
            array[8, 1] = Int32.Parse(arr[16, 1].ToString());//Người hưởng theo quyết định 62 hàng tháng
            array[9, 1] = Int32.Parse(arr[17, 1].ToString()) + Int32.Parse(arr[18, 1].ToString());//Thương binh
            array[10, 1] = Int32.Parse(arr[19, 1].ToString()) + Int32.Parse(arr[20, 1].ToString());//Tiền khởi nghĩa
            array[11, 1] = Int32.Parse(arr[21, 1].ToString());//Thanh niên xung phong TCHT
            array[12, 1] = Int32.Parse(arr[22, 1].ToString());//Thanh niên xung phong TCML


            int tongcu = 0;
            for (int i = 1; i <= 22; i++)
            {
                tongcu += Int32.Parse(arr[i, 1].ToString());
            }

            int hs62 = 0, hstnxpht = 0, hstnxp1 = 0, ncc = 0;

            //số lượng hồ sơ 62 sau khi update
            using (SqlConnection con = new SqlConnection(connectString))
            {
                con.Open();
                string sql = "select count(*) from HS_NguoiCC where IdNDT = 75";
                hs62 = (Int32.Parse((new SqlCommand(sql, con).ExecuteScalar().ToString())));
            }

            //số lượng hồ sơ tnxp hàng tháng
            using (SqlConnection con = new SqlConnection(connectString))
            {
                con.Open();
                string sql = "select count(*) from HS_NguoiCC where IdNDT = 79";
                hstnxpht = (Int32.Parse((new SqlCommand(sql, con).ExecuteScalar().ToString())));
            }

            //số lượng hồ sơ tnxp 1 lần
            using (SqlConnection con = new SqlConnection(connectString))
            {
                con.Open();
                string sql = "select count(*) from HS_NguoiCC where IdNDT = 80";
                hstnxp1 = (Int32.Parse((new SqlCommand(sql, con).ExecuteScalar().ToString())));
            }

            //số lượng người có công
            using (SqlConnection con = new SqlConnection(connectString))
            {
                con.Open();
                string sql = "select count(*) from HS_NguoiCC";
                ncc = (Int32.Parse((new SqlCommand(sql, con).ExecuteScalar().ToString())));
            }

            //tổng dư
            tongdu = tongdu + Int32.Parse(array[7, 1].ToString()) + Int32.Parse(array[11, 1].ToString()) + Int32.Parse(array[12, 1].ToString());

            //trung bình
            using (SqlConnection con = new SqlConnection(connectString))
            {
                con.Open();
                string sql = "select count(*) from HS_NguoiCC";
                tb = tongdu / (Int32.Parse((new SqlCommand(sql, con).ExecuteScalar().ToString())) - 5000);
            }

            //điền dữ liệu
            array[7, 1] = hs62 * 5; //+ Convert.ToInt32(tb * tbint[6]);
            array[11, 1] = hstnxpht * 3; //+ Convert.ToInt32(tb * tbint[10]);
            array[12, 1] = hstnxp1 * 3; //+ Convert.ToInt32(tb * tbint[11]);

            // điền dữ liệu còn lại dựa vào tongdu
            //array[1, 1] = Int32.Parse(arr[4, 1].ToString()) + Int32.Parse(arr[5, 1].ToString()) + tb * tbint[0];
            array[1, 1] = 0;
            array[2, 1] = Int32.Parse(arr[6, 1].ToString()) + Int32.Parse(arr[7, 1].ToString()) + Convert.ToInt32(tb * tbint[1]);
            array[3, 1] = Int32.Parse(arr[8, 1].ToString()) + Int32.Parse(arr[9, 1].ToString()) + Convert.ToInt32(tb * tbint[2]);
            array[4, 1] = Int32.Parse(arr[10, 1].ToString()) + Int32.Parse(arr[11, 1].ToString()) + Convert.ToInt32(tb * tbint[3]);
            array[5, 1] = Int32.Parse(arr[12, 1].ToString()) + Int32.Parse(arr[13, 1].ToString()) + Convert.ToInt32(tb * tbint[4]);
            array[6, 1] = Int32.Parse(arr[14, 1].ToString()) + Convert.ToInt32(tb * tbint[5]);
            array[8, 1] = Int32.Parse(arr[16, 1].ToString()) + Convert.ToInt32(tb * tbint[7]) + 2599;
            array[9, 1] = Int32.Parse(arr[17, 1].ToString()) + Int32.Parse(arr[18, 1].ToString()) + Convert.ToInt32(tb * tbint[8]);
            array[10, 1] = Int32.Parse(arr[19, 1].ToString()) + Int32.Parse(arr[20, 1].ToString()) + Convert.ToInt32(tb * tbint[9]);

            int tongmoi = 0;
            for (int i = 0; i < 12; i++)
            {
                tongmoi += Int32.Parse(array[i + 1, 1].ToString());
            }

            array[1, 1] = tongcu - tongmoi;

            Utils.ExportExcel(arr, "Sheet", 3, 1, 100, 2);

            /*using (StreamWriter streamWriter = File.AppendText(@"C:\Users\ADMIN\Downloads\thongke.txt"))
            {
                for (int i = 0; i < 22; i++)
                {
                    streamWriter.WriteLine(arr[i + 1, 0] + "\t" + arr[i + 1, 1]); ;
                }
            }  */
        }

        public int DemTruong(string table, List<string> list)
        {
            int count = 0;
            using (SqlConnection con = new SqlConnection(connectString))
            {
                con.Open();
                foreach (string a in list)
                {
                    string sql = "select count(*) from " + table + " " +
                        "where " + a + " is not null and CAST(" + a + " as varchar(max)) != ''";
                    count += Int32.Parse((new SqlCommand(sql, con).ExecuteScalar().ToString()));
                }
            }
            return count;
        }

        public int countAllColumn(string table)
        {
            SqlConnection con = new SqlConnection(connectString);
            string sql = "select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '" + table + "'";
            List<string> lst = Utils.executeQueryList(con, sql);

            return DemTruong(table, lst);
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
                    string sql = "" +
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
                        if ((new DirectoryInfo(str).Parent.Name.Trim().Length >= 3) && !Utils.IsNumber(new DirectoryInfo(str).Parent.Name.Substring(0, 3))
                            && !Utils.IsNumber(new DirectoryInfo(str).Parent.Name.Substring(new DirectoryInfo(str).Parent.Name.Length - 3, 3)))
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
                    string sql = "" +
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

            Utils.ExportExcel(arr, "Sheet", 4, 1, 1000, 100);
        }

        public void TrungHoSo()
        {
            string txtPath = @"\\192.168.31.206\Share\JPG (đã kiểm tra)\trung.txt";
            File.WriteAllText(txtPath, String.Empty);
            using (StreamWriter writer = File.AppendText(txtPath))
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=ADDJ_AnGiang;Integrated Security=True"))
                {
                    string sql = "" +
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
                                    " where ProfileName = '" + dr[0] + "' " +
                                    "and BatchName = N'" + dr[1] + "'";
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
                                                writer.Write(root[i].GetProperty("indexValueQC").ToString().Trim() + "\t");
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
                    string sql = "" +
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
                                        writer.Write(Utils.removeChar(root[i].GetProperty("indexValueQC").ToString().Trim()) + "\t");
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

        public void ExportData()
        {
            List<string> listProfileName = new List<string>();

            //lấy từng phân loại tài liệu
            using (SqlConnection conStr = new SqlConnection(@"Data Source=.;Initial Catalog=ADDJ_AnGiang;Integrated Security=True"))
            {
                string sql = "" +
                "select distinct ProfileName from TblBatchManagement " +
                "where ProfileName not like N'%khong%' and Status = 6 and StatusOutPut = 2 and StatusUpload not in (0) order by ProfileName";
                using (SqlCommand cmd = new SqlCommand(sql, conStr))
                {
                    cmd.CommandType = CommandType.Text;
                    conStr.Open();
                    SqlDataReader datareader = cmd.ExecuteReader();
                    while (datareader.Read())
                    {
                        listProfileName.Add(datareader[0].ToString());
                    }
                    conStr.Close();
                }
            }

            //Xuất từng phân loại
            for (int index = 0; index < listProfileName.Count; index++)
            {
                int count = 0, countCol = 0;
                //tạo excel
                //Tạo các đối tượng Excel

                Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
                Workbooks oBooks;
                Sheets oSheets;
                Workbook oBook;
                // tạo mới sheet
                Worksheet oSheet;

                //Tạo mới một Excel WorkBook 
                oExcel.Visible = false; //ẩn hiện file excel
                oExcel.DisplayAlerts = false;
                oExcel.Application.SheetsInNewWorkbook = 1;
                oBooks = oExcel.Workbooks;
                oBook = (Workbook)(oExcel.Workbooks.Add(Type.Missing));
                oSheets = oBook.Worksheets;

                // Tạo sheet mới
                oSheet = (Worksheet)oSheets.get_Item(1);
                oSheet.Name = "Sheet";

                //số dòng
                using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=ADDJ_AnGiang;Integrated Security=True"))
                {
                    con.Open();
                    string sql = "" +
                    "select count(*)" +
                    "from TblBatchManagement b join TblMetadata m on b.BatchManagementID = m.BatchID " +
                    "where ProfileName not like N'%khong%' and Status = 6 and StatusOutPut = 2 and StatusUpload not in (0) and ProfileName = N'" + listProfileName[index] + "' ";

                    count = Int32.Parse((new SqlCommand(sql, con).ExecuteScalar()).ToString());


                    con.Close();
                }

                // số cột
                using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=ADDJ_AnGiang;Integrated Security=True"))
                {
                    string sql = "" +
                    "select top(1) m.Metadata, ProfileName, TenDonVi, HoSoSo " +
                    "from TblBatchManagement b join TblMetadata m on b.BatchManagementID = m.BatchID " +
                    "where ProfileName not like N'%khong%' and Status = 6 and StatusOutPut = 2 and StatusUpload not in (0) and ProfileName = N'" + listProfileName[index] + "' " +
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
                                    countCol = root.GetArrayLength();
                                }
                            }
                        }
                        con.Close();
                    }
                }

                object[,] arr = new object[count + 2, countCol + 6];
                int row = 0;

                // tạo tên cột
                using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=ADDJ_AnGiang;Integrated Security=True"))
                {
                    string sql = "" +
                    "select top(1) m.Metadata, ProfileName, TenDonVi, HoSoSo " +
                    "from TblBatchManagement b join TblMetadata m on b.BatchManagementID = m.BatchID " +
                    "where ProfileName not like N'%khong%' and Status = 6 and StatusOutPut = 2 and StatusUpload not in (0) and ProfileName = N'" + listProfileName[index] + "' " +
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
                                    arr[row, 0] = "Tên đơn vị";
                                    arr[row, 1] = "Mã hồ sơ";
                                    arr[row, 2] = "Đường dẫn tệp";
                                    arr[row, 3] = "Số ảnh";
                                    for (int i = 0; i < root.GetArrayLength(); i++)
                                    {
                                        arr[row, i + 4] = root[i].GetProperty("indexName").ToString().Trim();
                                    }
                                }
                            }
                        }
                        con.Close();
                    }
                }
                row++;

                // tạo excel
                using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=ADDJ_AnGiang;Integrated Security=True"))
                {
                    string sql = "" +
                    "select m.Metadata, ProfileName, TenDonVi, HoSoSo, FilePath " +
                    "from TblBatchManagement b join TblMetadata m on b.BatchManagementID = m.BatchID join TblDocument d on m.DocID = d.ID " +
                    "where ProfileName not like N'%khong%' and Status = 6 and StatusOutPut = 2 and StatusUpload not in (0) and ProfileName = N'" + listProfileName[index] + "' " +
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
                                    arr[row, 0] = datareader[2].ToString();
                                    arr[row, 1] = datareader[3].ToString();
                                    arr[row, 2] = datareader[4].ToString();
                                    arr[row, 3] = (new PdfReader(datareader[4].ToString()).NumberOfPages).ToString();
                                    for (int i = 0; i < root.GetArrayLength(); i++)
                                    {
                                        arr[row, i + 4] = root[i].GetProperty("indexValueQC").ToString().Trim();
                                    }
                                    row++;
                                }
                            }
                        }
                        con.Close();
                    }
                }

                createSheet(arr, oSheet, count + 2, countCol + 6);

                oBook.SaveAs(@"C:\ADDJ\DA Thái Bình\Excel\" + listProfileName[index] + ".xlsx");
                oBooks.Close();
                oExcel.Quit();
            }
        }

        public void createSheet(object[,] arr, Worksheet oSheet, int rowEnd, int columnEnd)
        {
            //Thiết lập vùng điền dữ liệu
            int rowStart = 1;
            int columnStart = 1;

            //in đậm tiêu đề
            Range rowHead = oSheet.get_Range((Range)oSheet.Cells[1, columnStart],
                (Range)oSheet.Cells[1, columnEnd]);
            rowHead.Font.Bold = true;

            // Ô bắt đầu điền dữ liệu
            Range c1 = (Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu
            Range c2 = (Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu
            Range range = oSheet.get_Range(c1, c2);

            //định dạng số ngăn cách bằng dấu .
            //range.NumberFormat = "#,##0";

            //định dạng text
            range.NumberFormat = "@";

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;

            // Kẻ viền

            //range.Borders.LineStyle = Constants.xlSolid;

            // Căn giữa cột STT
            Range c3 = (Range)oSheet.Cells[rowEnd, columnStart];
            Range c4 = oSheet.get_Range(c1, c3);

            oSheet.get_Range(c3, c4).HorizontalAlignment = XlHAlign.xlHAlignCenter;
            range.Columns.AutoFit();
            range.HorizontalAlignment = XlHAlign.xlHAlignLeft;

            //auto width
            oSheet.Columns.AutoFit();
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

                                    System.IO.Directory.Move(st, tenMoi);
                                    using (StreamWriter writer = File.AppendText(@"\\192.168.31.206\Share\JPG (đã kiểm tra)\Thai Binh\CĐHH\chưa tìm đc mã\Rename.txt"))
                                    {
                                        writer.WriteLine(Directory.GetParent(st) + ": " + nguoiKhongMa + " => A" + nguoiCoMa + " - " + nguoiKhongMa);
                                    }
                                    break;
                                }
                                else i++;
                            }
                            i++;
                        }
                        catch (Exception)
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
                    string sql = "" +
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

    }
}
