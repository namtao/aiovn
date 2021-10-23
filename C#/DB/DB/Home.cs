﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace DB
{
    public partial class Home : Form
    {
        public static string connectString = ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
        public static Home form1;
        System.Data.DataTable dt;

        public Home()
        {
            InitializeComponent();
            form1 = this;
            timer.Interval = 60000;
            timer.Start();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            //hide title in form
            //ControlBox = false;
        }

        public void Kiemtratrungexcel()
        {
            var arrPathExcel = Directory.GetFiles(@"\\192.168.31.206\Data_Output", "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".xlsx")).ToList();
            using (StreamWriter streamWriter = File.AppendText(@"C:\Users\ADMIN\Downloads\test.txt"))
            {
                foreach (string str in arrPathExcel)
                {
                    object[,] valueArray = Utils.readExcel(str);
                    if (valueArray.GetLength(0) > 3)
                        streamWriter.WriteLine(str);
                }
            }
        }

        public void getFiles()
        {
            var arrPathJpg = Directory.GetFiles(@"\\192.168.31.206\Data_output (không cập nhật được do không có tăng mới)", "*.*",
                SearchOption.AllDirectories).Where(s => s.EndsWith(".pdf") || s.EndsWith(".xlsx")).ToList();

            using (StreamWriter streamWriter = File.AppendText(@"C:\Users\ADMIN\Downloads\test.txt"))
            {
                foreach (string str in arrPathJpg)
                {
                    streamWriter.WriteLine(str);
                }
            }
        }

        public void openFile(string path)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook wb = excel.Workbooks.Open(path);
        }

        public void FillDgv(string sqlQuery)
        {
            SqlConnection conn = new SqlConnection(connectString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            datagrid.DataSource = ds.Tables[0];
        }

        private void btnExe_Click(object sender, EventArgs e)
        {
            /*try
            {
                if (rdnBM.Checked || rdnKTBM1.Checked || rdnKTBM2.Checked || rdnKetThuc.Checked)
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn cập nhật về trạng thái biên mục không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (rdnOther.Checked) strCommandSql = rtbSQL.Text;
                        datagrid.Visible = true;
                        lbCount.Visible = true;
                        FillDgv(strCommandSql);
                        lbCount.Text = (datagrid.Rows.Count - 1).ToString() + " Rows";
                    }
                    else MessageBox.Show("Đã hủy bỏ thao tác cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //strCommandSql = rtbSQL.Text;
                    if (rdnOther.Checked) strCommandSql = rtbSQL.Text;
                    datagrid.Visible = true;
                    lbCount.Visible = true;
                    FillDgv(strCommandSql);
                    lbCount.Text = (datagrid.Rows.Count - 1).ToString() + " Rows";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon.Visible = false;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt = (System.Data.DataTable)datagrid.DataSource;
            if (datagrid.Rows.Count != 0 && datagrid.Rows != null)
            {
                Utils.Export(dt, datagrid, "KIỂM TRA", "KIỂM TRA DỮ LIỆU");
            }
            else MessageBox.Show("Không có dữ liệu để lưu vào excel, vui lòng kiểm tra lại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void thôngTinPhiênBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            MessageBox.Show(String.Format("Phiên bản hiện tại là: {0}", version), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void clonePDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clone form3 = new Clone();
            form3.Show();
            this.Hide();
        }

        //10 phút sẽ cập nhật các trạng thái mới 1 lần
        private void timer_Tick(object sender, EventArgs e)
        {
            
        }

        private void Home_SizeChanged(object sender, EventArgs e)
        {
            bool MousePointerNotOnTaskBar = Screen.GetWorkingArea(this).Contains(Cursor.Position);

            if (this.WindowState == FormWindowState.Minimized && MousePointerNotOnTaskBar)
            {
                this.ShowInTaskbar = false;
                notifyIcon.Visible = true;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            if (this.WindowState == FormWindowState.Normal)
                this.ShowInTaskbar = true;
            notifyIcon.Visible = false;
            this.Show();
        }

        private void lbKS_MouseHover(object sender, EventArgs e)
        {

        }

        private void btnGetSources_Click(object sender, EventArgs e)
        {
            GetSources getSources = new GetSources();
            getSources.getSources();
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
                                    "'" + diff.ngayCapNhatKTBM1 + "', '"+diff.ngayCapNhatKTBM2+"', '"+diff.ngayCapNhatKT+"')", conn);
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

        private void rtbSQL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                datagrid.Visible = true;
                lbCount.Visible = true;
                FillDgv(rtbSQL.Text);
                lbCount.Text = (datagrid.Rows.Count - 1).ToString() + " Rows";
            }
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CountField countField = new CountField();
            this.Hide();
            countField.Show();
        }
    }
}