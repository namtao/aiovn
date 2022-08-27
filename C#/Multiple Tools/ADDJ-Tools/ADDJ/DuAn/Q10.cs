﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADDJ
{
    class Q10
    {
        public static string connectString = ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;

        private void ThongKe()
        {
            object[,] arr = new object[1000, 100];
            //string ndk = "", nam = "", sotruonghop = "", soquyen = "";
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

            //Utils.ExportQ10(arr, "Q10");
        }


        private void addListDiff<T>(List<Diff> listDiff, T tt7, T tt6, T tt5, string columnName)
        {
            Diff diff = new Diff();
            if (tt7.GetType().GetProperty("ID1").GetValue(tt7, null) != null)
            {
                diff.id = tt7.GetType().GetProperty("ID1").GetValue(tt7, null) + "";
                diff.so = tt7.GetType().GetProperty("So1").GetValue(tt7, null) + "";
                diff.quyenSo = tt7.GetType().GetProperty("QuyenSo").GetValue(tt7, null) + "";
                diff.noiDangKy = tt7.GetType().GetProperty("NoiDangKy").GetValue(tt7, null) + "";
                diff.ngayDangKy = tt7.GetType().GetProperty("NgayDangKy").GetValue(tt7, null) + "";
            }
            else if (tt6.GetType().GetProperty("ID1").GetValue(tt6, null) != null)
            {
                diff.id = tt6.GetType().GetProperty("ID1").GetValue(tt6, null) + "";
                diff.so = tt6.GetType().GetProperty("So1").GetValue(tt6, null) + "";
                diff.quyenSo = tt6.GetType().GetProperty("QuyenSo").GetValue(tt6, null) + "";
                diff.noiDangKy = tt6.GetType().GetProperty("NoiDangKy").GetValue(tt6, null) + "";
                diff.ngayDangKy = tt6.GetType().GetProperty("NgayDangKy").GetValue(tt6, null) + "";
            }
            else
            {
                diff.id = tt5.GetType().GetProperty("ID1").GetValue(tt5, null) + "";
                diff.so = tt5.GetType().GetProperty("So1").GetValue(tt5, null) + "";
                diff.quyenSo = tt5.GetType().GetProperty("QuyenSo").GetValue(tt5, null) + "";
                diff.noiDangKy = tt5.GetType().GetProperty("NoiDangKy").GetValue(tt5, null) + "";
                diff.ngayDangKy = tt5.GetType().GetProperty("NgayDangKy").GetValue(tt5, null) + "";
            }

            diff.tableName = tt7.GetType().Name + "";

            diff.columnName = columnName;
            diff.ktbm1 = tt5.GetType().GetProperty(columnName).GetValue(tt5, null) + "";
            diff.ktbm2 = tt6.GetType().GetProperty(columnName).GetValue(tt6, null) + "";
            diff.kt = tt7.GetType().GetProperty(columnName).GetValue(tt7, null) + "";

            if (tt5.GetType().GetProperty("NgayCapNhat1").GetValue(tt5, null) != null)
                diff.ngayCapNhatKTBM1 = tt5.GetType().GetProperty("NgayCapNhat1").GetValue(tt5, null).ToString();

            if (tt6.GetType().GetProperty("NgayCapNhat1").GetValue(tt6, null) != null)
                diff.ngayCapNhatKTBM2 = tt6.GetType().GetProperty("NgayCapNhat1").GetValue(tt6, null).ToString();

            if (tt7.GetType().GetProperty("NgayCapNhat1").GetValue(tt7, null) != null)
                diff.ngayCapNhatKT = tt7.GetType().GetProperty("NgayCapNhat1").GetValue(tt7, null).ToString();
            listDiff.Add(diff);
        }


        private void xuLyDiff<T>(T tt7, T tt6, T tt5, string tableName)
        {
            using (SqlConnection con = new SqlConnection(connectString))
            {
                List<string> listDayDu2TrangThai = new List<string>();

                string str = " SELECT DISTINCT ID " +
                    " FROM " + tableName + "" +
                    " where ((id in (select id from " + tableName + " where TinhTrangID = 7) " +
                    "and id in (select id from " + tableName + " where TinhTrangID = 6)) " +
                    "or (id in (select id from " + tableName + " where TinhTrangID = 7) " +
                    "and id in (select id from " + tableName + " where TinhTrangID = 5)) " +
                    "or (id in (select id from " + tableName + " where TinhTrangID = 5) " +
                    "and id in (select id from " + tableName + " where TinhTrangID = 6)))";

                using (SqlCommand cmd = new SqlCommand(str, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    //duyệt từng bản ghi
                    while (dr.Read())
                    {
                        listDayDu2TrangThai.Add(dr[0].ToString());
                    }
                    con.Close();
                }

                //duyệt từng bản ghi có đủ 3 trạng thái
                foreach (string s in listDayDu2TrangThai)
                {
                    //trạng thái 7
                    string kt = " SELECT * " +
                            " FROM " + tableName + " where id = " + s + " and TinhTrangID = 7";

                    //trạng thái 6
                    string ktbm2 = " SELECT * " +
                            " FROM " + tableName + " where id = " + s + " and TinhTrangID = 6";

                    //trạng thái 5
                    string ktbm1 = " SELECT * " +
                            " FROM " + tableName + " where id = " + s + " and TinhTrangID = 5";

                    setValueObject<T>(kt, con, tt7);
                    setValueObject<T>(ktbm2, con, tt6);
                    setValueObject<T>(ktbm1, con, tt5);

                    //thêm những bản ghi có từ 2 trạng thái trở lên
                    //có 5,6 mà không có 7
                    if (tt7.GetType().GetProperty("ID1").GetValue(tt7, null) == null &&
                        tt6.GetType().GetProperty("ID1").GetValue(tt6, null) != null &&
                        tt5.GetType().GetProperty("ID1").GetValue(tt5, null) != null)
                    {
                        //so sánh 3 trạng thái nếu khác nhau thì so sánh từng cột 1 để lưu vào db
                        if (!tt6.Equals(tt5))
                        {
                            List<Diff> listDiff = new List<Diff>();

                            Type type = tt6.GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                            {
                                if (!tt6.GetType().GetProperty(property.Name).GetValue(tt6, null).ToString().ToUpper().
                                    Equals(tt5.GetType().GetProperty(property.Name).GetValue(tt5, null).ToString().ToUpper()))
                                    if (!property.Name.Equals("TinhTrangID1") && !property.Name.Equals("NgayCapNhat1"))
                                        addListDiff<T>(listDiff, tt7, tt6, tt5, property.Name);
                            }

                            foreach (Diff diff in listDiff)
                            {
                                SqlConnection conn = new SqlConnection(connectString);
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("if(select count(*) from Diff " +
                                    "where id = '" + diff.id + "' and so = '" + diff.so + "' and quyenSo = '" + diff.quyenSo +
                                    "' and noiDangKy = '" + diff.noiDangKy + "' " +
                                    "and ngayDangKy = '" + diff.ngayDangKy + "' and tableName = '" +
                                    diff.tableName + "' and columnName = '" + diff.columnName + "' " +
                                    "and ktbm1 = N'" + Utils.QuotationMarks(diff.ktbm1) +
                                    "' and ktbm2 = N'" + Utils.QuotationMarks(diff.ktbm2) + "' and kt = N'" +
                                    Utils.QuotationMarks(diff.kt) + "' and ghiChu = '" + diff.ghiChu + "') = 0 " +
                                    "insert into Diff values('" + diff.id + "', '" + diff.so + "', '" + diff.quyenSo + "'," +
                                    "'" + diff.noiDangKy + "', '" + diff.ngayDangKy + "', '" + diff.tableName + "', '" + diff.columnName +
                                    "', N'" + Utils.QuotationMarks(diff.ktbm1) + "'," +
                                    "N'" + Utils.QuotationMarks(diff.ktbm2) + "',N'" + Utils.QuotationMarks(diff.kt) + "', '5 -> 6', " +
                                    "'" + diff.ngayCapNhatKTBM1 + "', '" + diff.ngayCapNhatKTBM2 + "', '" + diff.ngayCapNhatKT + "')", conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                        }
                    }
                    //có 5, 7 mà không có 6
                    else if (tt7.GetType().GetProperty("ID1").GetValue(tt7, null) != null &&
                        tt6.GetType().GetProperty("ID1").GetValue(tt6, null) == null &&
                        tt5.GetType().GetProperty("ID1").GetValue(tt5, null) != null)
                    {
                        //so sánh 3 trạng thái nếu khác nhau thì so sánh từng cột 1 để lưu vào db
                        if (!tt7.Equals(tt5))
                        {
                            List<Diff> listDiff = new List<Diff>();

                            Type type = tt7.GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                            {
                                if (!tt7.GetType().GetProperty(property.Name).GetValue(tt7, null).ToString().ToUpper().
                                    Equals(tt5.GetType().GetProperty(property.Name).GetValue(tt5, null).ToString().ToUpper()))
                                    if (!property.Name.Equals("TinhTrangID1") && !property.Name.Equals("NgayCapNhat1"))
                                        addListDiff<T>(listDiff, tt7, tt6, tt5, property.Name);
                            }

                            foreach (Diff diff in listDiff)
                            {
                                SqlConnection conn = new SqlConnection(connectString);
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("if(select count(*) from Diff " +
                                    "where id = '" + diff.id + "' and so = '" + diff.so + "' and quyenSo = '" + diff.quyenSo + "' and noiDangKy = '" + diff.noiDangKy + "' " +
                                    "and ngayDangKy = '" + diff.ngayDangKy + "' and tableName = '" + diff.tableName + "' and columnName = '" + diff.columnName + "' " +
                                    "and ktbm1 = N'" + Utils.QuotationMarks(diff.ktbm1) +
                                    "' and ktbm2 = N'" + Utils.QuotationMarks(diff.ktbm2) + "' and kt = N'" + Utils.QuotationMarks(diff.kt) + "' and ghiChu = '" + diff.ghiChu + "') = 0 " +
                                    "insert into Diff values('" + diff.id + "', '" + diff.so + "', '" + diff.quyenSo + "'," +
                                    "'" + diff.noiDangKy + "', '" + diff.ngayDangKy + "', '" + diff.tableName + "', '" + diff.columnName + "', N'" + Utils.QuotationMarks(diff.ktbm1) + "'," +
                                    "N'" + Utils.QuotationMarks(diff.ktbm2) + "',N'" + Utils.QuotationMarks(diff.kt) + "', '5 -> 7', " +
                                    "'" + diff.ngayCapNhatKTBM1 + "', '" + diff.ngayCapNhatKTBM2 + "', '" + diff.ngayCapNhatKT + "')", conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                        }
                    }
                    //có 6, 7 mà không có 5
                    else if ((tt7.GetType().GetProperty("ID1").GetValue(tt7, null) != null &&
                        tt6.GetType().GetProperty("ID1").GetValue(tt6, null) != null &&
                        tt5.GetType().GetProperty("ID1").GetValue(tt5, null) == null))
                    {
                        if (!tt7.Equals(tt6))
                        {
                            List<Diff> listDiff = new List<Diff>();

                            Type type = tt7.GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                            {
                                if (!tt7.GetType().GetProperty(property.Name).GetValue(tt7, null).ToString().ToUpper().
                                    Equals(tt6.GetType().GetProperty(property.Name).GetValue(tt6, null).ToString().ToUpper()))
                                    if (!property.Name.Equals("TinhTrangID1") && !property.Name.Equals("NgayCapNhat1"))
                                        addListDiff<T>(listDiff, tt7, tt6, tt5, property.Name);
                            }

                            foreach (Diff diff in listDiff)
                            {
                                SqlConnection conn = new SqlConnection(connectString);
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("if(select count(*) from Diff " +
                                    "where id = '" + diff.id + "' and so = '" + diff.so + "' and quyenSo = '" + diff.quyenSo + "' and noiDangKy = '" + diff.noiDangKy + "' " +
                                    "and ngayDangKy = '" + diff.ngayDangKy + "' and tableName = '" + diff.tableName + "' and columnName = '" + diff.columnName + "' " +
                                    "and ktbm1 = N'" + Utils.QuotationMarks(diff.ktbm1) +
                                    "' and ktbm2 = N'" + Utils.QuotationMarks(diff.ktbm2) + "' and kt = N'" + Utils.QuotationMarks(diff.kt) + "' and ghiChu = '" + diff.ghiChu + "') = 0 " +
                                    "insert into Diff values('" + diff.id + "', '" + diff.so + "', '" + diff.quyenSo + "'," +
                                    "'" + diff.noiDangKy + "', '" + diff.ngayDangKy + "', '" + diff.tableName + "', '" + diff.columnName + "', N'" + Utils.QuotationMarks(diff.ktbm1) + "'," +
                                    "N'" + Utils.QuotationMarks(diff.ktbm2) + "',N'" + Utils.QuotationMarks(diff.kt) + "', '6 -> 7', " +
                                    "'" + diff.ngayCapNhatKTBM1 + "', '" + diff.ngayCapNhatKTBM2 + "', '" + diff.ngayCapNhatKT + "')", conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                        }
                    }
                    //có cả 3 5, 6, 7
                    else if ((tt7.GetType().GetProperty("ID1").GetValue(tt7, null) != null &&
                        tt6.GetType().GetProperty("ID1").GetValue(tt6, null) != null &&
                        tt5.GetType().GetProperty("ID1").GetValue(tt5, null) != null))
                    {
                        //5!=6
                        if (!tt5.Equals(tt6))
                        {
                            List<Diff> listDiff = new List<Diff>();

                            Type type = tt7.GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                            {
                                if (!tt5.GetType().GetProperty(property.Name).GetValue(tt5, null).ToString().ToUpper().
                                    Equals(tt6.GetType().GetProperty(property.Name).GetValue(tt6, null).ToString().ToUpper()))
                                    if (!property.Name.Equals("TinhTrangID1") && !property.Name.Equals("NgayCapNhat1"))
                                        addListDiff<T>(listDiff, tt7, tt6, tt5, property.Name);
                            }

                            foreach (Diff diff in listDiff)
                            {
                                SqlConnection conn = new SqlConnection(connectString);
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("if(select count(*) from Diff " +
                                    "where id = '" + diff.id + "' and so = '" + diff.so + "' and quyenSo = '" + diff.quyenSo + "' and noiDangKy = '" + diff.noiDangKy + "' " +
                                    "and ngayDangKy = '" + diff.ngayDangKy + "' and tableName = '" + diff.tableName + "' and columnName = '" + diff.columnName + "' " +
                                    "and ktbm1 = N'" + Utils.QuotationMarks(diff.ktbm1) +
                                    "' and ktbm2 = N'" + Utils.QuotationMarks(diff.ktbm2) + "' and kt = N'" + Utils.QuotationMarks(diff.kt) + "' and ghiChu = '" + diff.ghiChu + "') = 0 " +
                                    "insert into Diff values('" + diff.id + "', '" + diff.so + "', '" + diff.quyenSo + "'," +
                                    "'" + diff.noiDangKy + "', '" + diff.ngayDangKy + "', '" + diff.tableName + "', '" + diff.columnName + "', N'" + Utils.QuotationMarks(diff.ktbm1) + "'," +
                                    "N'" + Utils.QuotationMarks(diff.ktbm2) + "',N'" + Utils.QuotationMarks(diff.kt) + "', '5 -> 6', " +
                                    "'" + diff.ngayCapNhatKTBM1 + "', '" + diff.ngayCapNhatKTBM2 + "', '" + diff.ngayCapNhatKT + "')", conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                        }

                        //5!=7
                        if (!tt7.Equals(tt5))
                        {
                            List<Diff> listDiff = new List<Diff>();

                            Type type = tt7.GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                            {
                                if (!tt7.GetType().GetProperty(property.Name).GetValue(tt7, null).ToString().ToUpper().
                                    Equals(tt5.GetType().GetProperty(property.Name).GetValue(tt5, null).ToString().ToUpper()))
                                    if (!property.Name.Equals("TinhTrangID1") && !property.Name.Equals("NgayCapNhat1"))
                                        addListDiff<T>(listDiff, tt7, tt6, tt5, property.Name);
                            }

                            foreach (Diff diff in listDiff)
                            {
                                SqlConnection conn = new SqlConnection(connectString);
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("if(select count(*) from Diff " +
                                    "where id = '" + diff.id + "' and so = '" + diff.so + "' and quyenSo = '" + diff.quyenSo + "' and noiDangKy = '" + diff.noiDangKy + "' " +
                                    "and ngayDangKy = '" + diff.ngayDangKy + "' and tableName = '" + diff.tableName + "' and columnName = '" + diff.columnName + "' " +
                                    "and ktbm1 = N'" + Utils.QuotationMarks(diff.ktbm1) +
                                    "' and ktbm2 = N'" + Utils.QuotationMarks(diff.ktbm2) + "' and kt = N'" + Utils.QuotationMarks(diff.kt) + "' and ghiChu = '" + diff.ghiChu + "') = 0 " +
                                    "insert into Diff values('" + diff.id + "', '" + diff.so + "', '" + diff.quyenSo + "'," +
                                    "'" + diff.noiDangKy + "', '" + diff.ngayDangKy + "', '" + diff.tableName + "', '" + diff.columnName + "', N'" + Utils.QuotationMarks(diff.ktbm1) + "'," +
                                    "N'" + Utils.QuotationMarks(diff.ktbm2) + "',N'" + Utils.QuotationMarks(diff.kt) + "', '5 -> 7', " +
                                    "'" + diff.ngayCapNhatKTBM1 + "', '" + diff.ngayCapNhatKTBM2 + "', '" + diff.ngayCapNhatKT + "')", conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                        }

                        //6!=7
                        if (!tt7.Equals(tt6))
                        {
                            List<Diff> listDiff = new List<Diff>();

                            Type type = tt7.GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                            {
                                if (!tt7.GetType().GetProperty(property.Name).GetValue(tt7, null).ToString().ToUpper().
                                    Equals(tt6.GetType().GetProperty(property.Name).GetValue(tt6, null).ToString().ToUpper()))
                                    if (!property.Name.Equals("TinhTrangID1") && !property.Name.Equals("NgayCapNhat1"))
                                        addListDiff<T>(listDiff, tt7, tt6, tt5, property.Name);
                            }

                            foreach (Diff diff in listDiff)
                            {
                                SqlConnection conn = new SqlConnection(connectString);
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("if(select count(*) from Diff " +
                                    "where id = '" + diff.id + "' and so = '" + diff.so + "' and quyenSo = '" + diff.quyenSo + "' and noiDangKy = '" + diff.noiDangKy + "' " +
                                    "and ngayDangKy = '" + diff.ngayDangKy + "' and tableName = '" + diff.tableName + "' and columnName = '" + diff.columnName + "' " +
                                    "and ktbm1 = N'" + Utils.QuotationMarks(diff.ktbm1) +
                                    "' and ktbm2 = N'" + Utils.QuotationMarks(diff.ktbm2) + "' and kt = N'" + Utils.QuotationMarks(diff.kt) + "' and ghiChu = '" + diff.ghiChu + "') = 0 " +
                                    "insert into Diff values('" + diff.id + "', '" + diff.so + "', '" + diff.quyenSo + "'," +
                                    "'" + diff.noiDangKy + "', '" + diff.ngayDangKy + "', '" + diff.tableName + "', '" + diff.columnName + "', N'" + Utils.QuotationMarks(diff.ktbm1) + "'," +
                                    "N'" + Utils.QuotationMarks(diff.ktbm2) + "',N'" + Utils.QuotationMarks(diff.kt) + "', '6 -> 7', " +
                                    "'" + diff.ngayCapNhatKTBM1 + "', '" + diff.ngayCapNhatKTBM2 + "', '" + diff.ngayCapNhatKT + "')", conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                        }
                    }
                }
            }

            MessageBox.Show("Đã xử lý xong " + tt7.GetType().Name, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void setValueObject<T>(string str, SqlConnection con, T tt)
        {
            using (SqlCommand cmd = new SqlCommand(str, con))
            {
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                //duyệt từng bản ghi
                int i = 0;
                while (dr.Read())
                {
                    Type type = tt.GetType();

                    //lấy value theo tên thuộc tính (có get set)
                    foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                    {
                        tt.GetType().GetProperty(property.Name).SetValue(tt, dr[i].ToString().Trim(), null);
                        i++;
                    }
                }
                if (i == 0)
                {
                    Type type = tt.GetType();

                    //lấy value theo tên thuộc tính (có get set)
                    foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                    {
                        tt.GetType().GetProperty(property.Name).SetValue(tt, null, null);
                        i++;
                    }
                }
                con.Close();
            }
        }

    }
}