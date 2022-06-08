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
using System.Configuration;
using Microsoft.Office.Interop.Excel;
using Company.DuAn;
using System.Threading;

namespace Company
{
    public partial class CountField : Form
    {
        string connectString = ConfigurationManager.ConnectionStrings["hotich"].ConnectionString;
        ThaiBinh tb = new ThaiBinh();

        public CountField()
        {
            InitializeComponent();
        }

        private void CountField_Load(object sender, EventArgs e)
        {

        }

        private void cbxTable_DropDown(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectString);
            conn.Open();
            string strCmd = "select distinct TABLE_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME in ('HT_KHAISINH', 'HT_KHAITU', 'HT_KETHON', 'HT_NHANCHAMECON')";
            SqlCommand cmd = new SqlCommand(strCmd, conn);
            SqlDataAdapter da = new SqlDataAdapter(strCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            conn.Close();
            cbxTable.DisplayMember = "TABLE_NAME";
            cbxTable.ValueMember = "TABLE_NAME";
            cbxTable.DataSource = ds.Tables[0];
        }

        List<string> lst1 = new List<string>();
        List<string> lst2 = new List<string>();

        private void cbxTable_SelectedValueChanged(object sender, EventArgs e)
        {
            list1.Items.Clear();
            list2.Items.Clear();
            lst1.Clear();
            lst2.Clear();

            using (SqlConnection con = new SqlConnection(connectString))
            {
                /*string sql = "select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS " +
                    "where COLUMN_NAME not like '%id%' and COLUMN_NAME not like '%stt%' " +
                    "and COLUMN_NAME not like '%status%' and COLUMN_NAME not like '%trangthai%' " +
                    "and COLUMN_NAME not like 'is%' and TABLE_NAME = '" + cbxTable.Text + "'";*/
                string sql = "select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS " +
                    "where TABLE_NAME = '" + cbxTable.Text + "'";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lst1.Add(dr[0].ToString());
                    }
                    con.Close();
                }
            }

            foreach (string a in lst1)
            {
                list1.Items.Add(a);
            }
        }

        private void list1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lst2.Add(lst1[list1.SelectedIndex]);

            lst1.RemoveAt(list1.SelectedIndex);


            clearListBox();

        }

        private void list2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lst1.Add(lst2[list2.SelectedIndex]);

            lst2.RemoveAt(list2.SelectedIndex);

            clearListBox();

        }

        public void clearListBox()
        {
            list1.Items.Clear();
            list2.Items.Clear();

            foreach (string a in lst1)
            {
                list1.Items.Add(a);
            }

            foreach (string a in lst2)
            {
                list2.Items.Add(a);
            }
        }

        /*public int DemTruong(string table, List<string> list)
        {
            int count = 0;
            using (SqlConnection con = new SqlConnection(connectString))
            {
                con.Open();
                foreach (string a in list)
                {
                    if (!a.Equals("Id"))
                    {
                        string sql = "select count(*) from " + table + " " +
                            "where " + a + " is not null and CAST(" + a + " as varchar(max)) != '' and CAST(" + a + " as varchar(max)) != '__/__/____'";
                        count += Int32.Parse((new SqlCommand(sql, con).ExecuteScalar().ToString()));
                    }
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
        }*/

        private void lb_Click(object sender, EventArgs e)
        {
            xuly();
        }

        private void CountField_FormClosing(object sender, FormClosingEventArgs e)
        {
            Home.form1.Show();
        }

        private void lbTren_Click(object sender, EventArgs e)
        {
            xuly();
        }

        private void lbDuoi_Click(object sender, EventArgs e)
        {
            xuly();
        }

        public void xuly()
        {
            DateTime startdate = DateTime.Now;

            /*String.Format("{0:n}", 1234);  // Output: 1,234.00
            String.Format("{0:n0}", 9876); // No digits after the decimal point. Output: 9,876*/
            //lb.Text = "Tổng: " + String.Format("{0:n0}", Utils.DemTruong(connectString, cbxTable.Text, lst1)) + " trường";

            int ksTren16 = 0, ksDuoi16 = 0;
            using (SqlConnection con = new SqlConnection(connectString))
            {
                string sql = "SELECT so, quyenSo, trangSo, ngayDangKy, TenLoaiDangKy, " +
                    "TenNoiDangKy, nksHoTen, TenGioiTinh, nksNgaySinh, dt.TenDanToc, qt.TenQuocTich, " +
                    "meHoTen, meNgaySinh, dtm.TenDanToc, qtm.TenQuocTich, lctm.TenLoaiCuTru, chaHoTen, " +
                    "chaNgaySinh, dtc.TenDanToc, qtc.TenQuocTich, lctc.TenLoaiCuTru, GhiChu, nksNoiSinh, " +
                    "meNoiCuTru, chaNoiCuTru, nycHoTen, nycQuanHe, nguoiKy, chucVuNguoiKy, NguoiThucHien, " +
                    "lks.TenLoaiKhaiSinh, nsdvhc.ten, nksQueQuan, lgtnk.TenLoaiGiayTo, nycSoGiayToTuyThan, " +
                    "nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan, nksNgaySinhBangChu FROM HT_KHAISINH " +
                    "ks left join  HT_KS_LOAIDANGKY ldk on ks.loaiDangKy = ldk.MaLoaiDangKy " +
                    "left join  DM_GIOITINH gt on  ks.nksGioiTinh = gt.MaGioiTinh " +
                    "left join  DM_DANTOC dt on ks.nksDanToc = dt.MaDanToc " +
                    "left join  DM_DANTOC dtm on ks.meDanToc = dtm.MaDanToc " +
                    "left join  DM_DANTOC dtc on ks.chaDanToc = dtc.MaDanToc " +
                    "left join  DM_QUOCTICH qt on ks.nksQuocTich = qt.MaQuocTich " +
                    "left join  DM_QUOCTICH qtm on ks.meQuocTich = qtm.MaQuocTich " +
                    "left join  DM_QUOCTICH qtc on ks.chaQuocTich = qtc.MaQuocTich " +
                    "left join  HT_NOIDANGKY ndk on ks.noiDangKy = ndk.MaNoiDangKy " +
                    "left join  DM_LOAICUTRU lctm on ks.meLoaiCuTru = lctm.MaLoaiCuTru " +
                    "left join  DM_LOAICUTRU lctc on ks.chaLoaiCuTru = lctc.MaLoaiCuTru " +
                    "left join  HT_KS_LOAIKHAISINH lks on ks.nksLoaiKhaiSinh = lks.MaLoaiKhaiSinh " +
                    "left join  HT_LOAIGIAYTO lgtnk on ks.nycLoaiGiayToTuyThan = lgtnk.MaLoaiGiayTo " +
                    "left join  HT_Tinh_NoiSinh nsdvhc on ks.nksNoiSinhDVHC = nsdvhc.Ma " +
                    "WHERE quyenSo NOT LIKE '%2016' AND quyenSo NOT LIKE '%2017' AND quyenSo NOT LIKE '%2018' AND quyenSo NOT LIKE '%2019'";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    //duyệt từng bản ghi
                    while (dr.Read())
                    {
                        for (int i = 0; i < sql.Split(new string[] { "FROM" }, StringSplitOptions.None)[0].
                            Split(new string[] { "SELECT" }, StringSplitOptions.None)[1].Trim().Split(',').Length; i++)
                        {
                            //duyệt từng cột
                            if (dr[i].ToString().Trim().Length >= 16)
                                ksTren16++;
                            else if (dr[i].ToString().Trim().Length > 0 && dr[i] != null && !dr[i].ToString().Trim().Equals(""))
                                ksDuoi16++;

                            /*using (SqlConnection con2 = new SqlConnection(connectString))
                            {
                                string sql2 = "select ";
                                using (SqlCommand cmd2 = new SqlCommand(sql2, con2))
                                {
                                    
                                }
                            }*/


                        }

                        /*Parallel.For(0, sql.Split(new string[] { "FROM" }, StringSplitOptions.None)[0].
                            Split(new string[] { "SELECT" }, StringSplitOptions.None)[1].Trim().Split(',').Length, i =>
                        {
                            //duyệt từng cột
                            if (dr[i].ToString().Trim().Length >= 16)
                                ksTren16++;
                            else if (dr[i].ToString().Trim().Length > 0 && dr[i] != null && !dr[i].ToString().Trim().Equals(""))
                                ksDuoi16++;
                        });*/
                    }
                    con.Close();
                }
            }

            lb.Text = "Tổng: " + String.Format("{0:n0}", (ksDuoi16 + ksTren16)) + " trường";
            lbTren.Text = "Tổng: " + String.Format("{0:n0}", (ksTren16)) + " trường";
            lbDuoi.Text = "Tổng: " + String.Format("{0:n0}", (ksDuoi16)) + " trường";

            DateTime finishDate = DateTime.Now;
            TimeSpan time = finishDate - startdate;
            Console.WriteLine("Total:=" + time.Ticks);
        }
    }
}
