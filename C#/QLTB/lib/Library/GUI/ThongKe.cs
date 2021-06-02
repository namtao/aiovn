using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Class_DuLieu;
using Class_XuLy;
using System.Data.SqlClient;
using Handle;

namespace GUI
{
    public partial class ThongKe : UserControl
    {
        Data data = new Data();
        XuLy xl = new XuLy();
        DB db = new DB(@"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=QLTB;Integrated Security=True");


        SqlConnection conn;
        public ThongKe()
        {
            InitializeComponent();
            loadTK();
        }

        public void loadTK()
        {
            conn = data.GetConnect();
            SqlCommand cmd = new SqlCommand("select count(*) from NhanVien", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                slnv.Text = dr[0].ToString();
            }
            conn.Close();
            SqlCommand cmd1 = new SqlCommand("select SUM(Gia*Soluong) from NguyenLieu", conn);
            conn.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                lbchi.Text = dr1[0].ToString();
            }
            conn.Close();
            SqlCommand cmd2 = new SqlCommand("select SUM([ThanhTien]) from KhachHang", conn);
            conn.Open();
            SqlDataReader dr2 = cmd2.ExecuteReader();
            if (dr2.Read())
            {
                lbthu.Text = dr2[0].ToString();
            }
            conn.Close();
            SqlCommand cmd3 = new SqlCommand("SELECT top(1)chungloaibanh,mycount FROM (SELECT chungloaibanh,sum(soluong) mycount FROM khachhang GROUP BY (chungloaibanh)) tb1 order by  mycount desc", conn);
            conn.Open();
            SqlDataReader dr3 = cmd3.ExecuteReader();
            if (dr3.Read())
            {
                maxbanh.Text = dr3[0].ToString();
            }
            conn.Close();
            SqlCommand cmd4 = new SqlCommand("SELECT top(1)chungloaibanh,mycount FROM (SELECT chungloaibanh,sum(soluong) mycount FROM khachhang GROUP BY (chungloaibanh)) tb1 order by  mycount", conn);
            conn.Open();
            SqlDataReader dr4 = cmd4.ExecuteReader();
            if (dr4.Read())
            {
                minbanh.Text = dr4[0].ToString();
            }
            conn.Close();
            SqlCommand cmd5 = new SqlCommand("SELECT top(1) mycount,manv,hoten FROM (SELECT KhachHang.manv ,HoTen,sum(soluong) mycount FROM khachhang,NhanVien where KhachHang.MaNV = NhanVien.MaNV GROUP BY (KhachHang.manv),HoTen)  tb1 order by  mycount desc", conn);
            conn.Open();
            SqlDataReader dr5 = cmd5.ExecuteReader();
            if (dr5.Read())
            {
                maxnv.Text = dr5[2].ToString();
                manvmax.Text = dr5[1].ToString();
            }
            conn.Close();
            SqlCommand cmd6 = new SqlCommand("SELECT top(1) mycount,manv,hoten FROM (SELECT KhachHang.manv ,HoTen,sum(soluong) mycount FROM khachhang,NhanVien where KhachHang.MaNV = NhanVien.MaNV GROUP BY (KhachHang.manv),HoTen)  tb1 order by  mycount", conn);
            conn.Open();
            SqlDataReader dr6 = cmd6.ExecuteReader();
            if (dr6.Read())
            {
                minmv.Text = dr6[2].ToString();
                manvmin.Text = dr6[1].ToString();
            }
        }


        private void tabPage2_load(object sender, EventArgs e)
        {
            
        }


        private void label1_MouseHover(object sender, EventArgs e)
        {
            panel1.Hide();
            DataTable dt = new DataTable();
            dt = xl.doanhthu();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                
                    this.chart1.Series["doanhthu"].Points.AddXY(dt.Rows[i][0].ToString(), dt.Rows[i][1]);
                    
                //this.chart1.Series["doanhthu"].Points.AddXY("T1", 1000000);
                //this.chart1.Series["doanhthu"].Points.AddXY("T2", 1100000);
                //this.chart1.Series["doanhthu"].Points.AddXY("T3", 1100000);
            }
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.chart1.Series["doanhthu"].Points.Clear();
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            panel1.Show();
            DataTable dt = new DataTable();
            dt = xl.doanhthu();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {

                this.chart2.Series["doanhthu2"].Points.AddXY(dt.Rows[i][0].ToString(), dt.Rows[i][1]);

               
            }
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            this.chart2.Series["doanhthu2"].Points.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
        
        

    }
}
