using Newtonsoft.Json;
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
using ADDJ.DuAn;

namespace ADDJ
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
            timer.Interval = 1000;
            timer.Start();
        }



        private void Home_Load(object sender, EventArgs e)
        {
            // MessageBox.Show(Environment.CurrentDirectory);
        }

        public int DemTruong(string table, List<string> list)
        {
            int count = 0;
            using (SqlConnection con = new SqlConnection(connectString))
            {
                con.Open();
                foreach (string a in list)
                {
                    if (!a.Equals("Id") && !a.Equals("HoSoDangQLTaiSo") && !a.Equals("BanGocBanSao") && !a.Equals("FileName") && !a.Equals("FilePath"))
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
        }

        public void ThongKeTB(object sender, EventArgs e)
        {
            // xuất số hồ sơ
            FillDgv("select Ten, count(*) as SoLuong from HS_NguoiCC n join DM_NhomDT d on n.IdNDT = d.Id where TrangThai <> 1 AND TrangThai <> 2 group by Ten order by Ten");
            dt = (System.Data.DataTable)datagrid.DataSource;
            if (datagrid.Rows.Count != 0 && datagrid.Rows != null)
            {
                Utils.Export(dt, datagrid, "Hồ sơ", "Thống kê số hồ sơ");
            }
            else MessageBox.Show("Không có dữ liệu để lưu vào excel, vui lòng kiểm tra lại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            // xuất số trang            
            FillDgv("SELECT Ten, sum(SoTrang) as SoTrang FROM V_ThongKeSoTrangTheoHoSo group by Ten order by Ten");
            dt = (System.Data.DataTable)datagrid.DataSource;
            if (datagrid.Rows.Count != 0 && datagrid.Rows != null)
            {
                Utils.Export(dt, datagrid, "Trang tài liệu", "Thống kê số trang");
            }
            else MessageBox.Show("Không có dữ liệu để lưu vào excel, vui lòng kiểm tra lại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            // xuất số trường
            thốngKêToolStripMenuItem_Click(sender, e);
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

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon.Visible = false;
            System.Windows.Forms.Application.Exit();
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

        private void clonePDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clone form3 = new Clone();
            form3.Show();
            this.Hide();
        }

        //10 phút sẽ cập nhật các trạng thái mới 1 lần
        private void timer_Tick(object sender, EventArgs e)
        {
            /*Console.WriteLine("Finish");
            using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=HoTich;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("if (select count(*)  from HT_KHAISINH where SUBSTRING (URLTapTinDinhKem, 1, 1) = '/') > 0 " +
                    "update HT_KHAISINH set URLTapTinDinhKem = SUBSTRING(trim(URLTapTinDinhKem), 2, LEN(trim(URLTapTinDinhKem)));" +
                    "if (select count(*)  from HT_KHAITU where SUBSTRING(URLTapTinDinhKem, 1, 1) = '/') > 0 " +
                    "update HT_KHAITU set URLTapTinDinhKem = SUBSTRING(trim(URLTapTinDinhKem), 2, LEN(trim(URLTapTinDinhKem)));" +
                    "if (select count(*)  from HT_KETHON where SUBSTRING(URLTapTinDinhKem, 1, 1) = '/') > 0 " +
                    "update HT_KETHON set URLTapTinDinhKem = SUBSTRING(trim(URLTapTinDinhKem), 2, LEN(trim(URLTapTinDinhKem)));" +
                    "if (select count(*)  from HT_NHANCHAMECON where SUBSTRING(URLTapTinDinhKem, 1, 1) = '/') > 0 " +
                    "update HT_NHANCHAMECON set URLTapTinDinhKem = SUBSTRING(trim(URLTapTinDinhKem), 2, LEN(trim(URLTapTinDinhKem))); ", con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }*/
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

        private void thongKeThuMucStripMenuItem1_Click(object sender, EventArgs e)
        {
            Tree tree = new Tree();
            tree.Show();
            this.Hide();
        }

        private void thongKeThietBiStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLyThietBi quanLyThietBi= new QuanLyThietBi();
            quanLyThietBi.Show();
        }

        private void hoTichStripMenuItem_Click(object sender, EventArgs e)
        {
            HoTich ht = new HoTich();
            ht.Show();
            this.Hide();
        }
    }
}
