using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using Class_DuLieu;
using Class_XuLy;
using Handle;

namespace QLTB
{
    public partial class TrangChu : Form
    {
        public static TrangChu tc;
        public DangNhap dn;
        Data data = new Data();
        XuLy xl = new XuLy();
        DB db = new DB(@"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=QLTB;Integrated Security=True");


        SqlConnection conn;

        public TrangChu()
        {
            InitializeComponent();
            conn = data.GetConnect();
            tc=this;
            thucDon1.Show();
        }

        private void btnThucDon_Click(object sender, EventArgs e)
        {
            banHang1.Hide();
            thucDon1.Show();
            nguyenLieu1.Hide();
            thongKe1.Hide();
            nhanVien1.Hide();
        }

        private void btnQLBH_Click(object sender, EventArgs e)
        {
            banHang1.Show();
            thucDon1.Hide();
            nguyenLieu1.Hide();
            thongKe1.Hide();
            nhanVien1.Hide();
        }


        private void thucDon1_Load(object sender, EventArgs e)
        {
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            banHang1.Hide();
            thucDon1.Hide();
            nguyenLieu1.Hide();
            thongKe1.Show();
            nhanVien1.Hide();
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            banHang1.Hide();
            thucDon1.Hide();
            nguyenLieu1.Hide();
            thongKe1.Hide();
            nhanVien1.Show();
        }

        private void btnQLNH_Click(object sender, EventArgs e)
        {
            banHang1.Hide();
            thucDon1.Hide();
            nguyenLieu1.Show();
            thongKe1.Hide();
            nhanVien1.Hide();
        }

        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            this.Close();
            DangNhap.dn.Show();
        }

        private void TrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DangNhap.dn.Show();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            string s1 =xl.role(((DangNhap)dn).txtTenDangNhap.Text);
            string s2 = "user";
            if (string.Compare(s1, s2, true) == 0)
            {
                btnQLNV.Hide();
            }
        }

        private void thongKe1_Load(object sender, EventArgs e)
        {

        }

        private void banHang1_Load(object sender, EventArgs e)
        {

        }
    }
}
