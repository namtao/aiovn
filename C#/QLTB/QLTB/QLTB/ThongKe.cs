using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Class_DuLieu;
using Class_XuLy;

namespace QLTB
{
   
    public partial class ThongKe : Form
    {
        Data dt = new Data();
        XuLy xl = new XuLy();
        SqlConnection conn;
        
        public ThongKe()
        {
            InitializeComponent();
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            
        }

        private void ThongKe_FormClosed(object sender, FormClosedEventArgs e)
        {
            TrangChu tc = new TrangChu();
            tc.Show();
            
        }

        private void databd_ValueChanged(object sender, EventArgs e)
        {
            conn = dt.GetConnect();
            conn.Open();
            String sql = "";
            txtSoLuong.Text = "";
        }
    }
}
