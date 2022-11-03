using xD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static xD.Model.DB;


namespace xD
{
    public partial class GiaoNhanThietBi : Form
    {
        public int idThietBi;
        public static string connectString = ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
        public GiaoNhanThietBi()
        {
            InitializeComponent();
        }

        private void btnExe_Click(object sender, EventArgs e)
        {
            insert(connectString, "insert into LichSuThietBi " +
                "values("+idThietBi+", CONVERT(nvarchar(10), GETDATE(), 103), N'" + txtNoiGui.Text + "', N'" + txtNguoiGui.Text + "', " +
                "N'" + txtTTNguoiGui.Text + "', N'" + txtNoiNhan.Text + "', N'" + txtNguoiNhan.Text + "', " +
                "N'" + txtTTNguoiNhan.Text + "', N'" + txtNoiDung.Text + "', N'" + txtNQL.Text + "', N'" + txtBPQL.Text + "', N'" + txtNgQL.Text + "', " +
                "N'" + txtGhiChu.Text + "')");

            update(connectString, "update ThietBi set DonVi = N'"+txtDonVi.Text+"', NoiQuanLy = N'"+txtNQL.Text+"', BoPhanQuanLy = N'"+txtBPQL.Text+"', " +
                "NguoiQuanLy = N'"+txtNgQL.Text+"', TinhTrang = '"+txtTinhTrang.Text+"', TrangThai = '"+txtTrangThai.Text+"' " +
                "where id = '"+idThietBi+"' ");
        }

        private void GiaoNhanThietBi_FormClosing(object sender, FormClosingEventArgs e)
        {
            QuanLyThietBi.form1.Show();
        }
    }
}
