using Company;
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
using static ADDJ.Model.DB;

namespace ADDJ
{
    public partial class GiaoNhanThietBi : Form
    {
        public int idThietBi;
        public static string connectString = ConfigurationManager.ConnectionStrings["ADDJ"].ConnectionString;
        public GiaoNhanThietBi()
        {
            InitializeComponent();
        }

        private void btnExe_Click(object sender, EventArgs e)
        {
            insert(connectString, "insert into LichSuThietBi " +
                "values(idThietBi, CONVERT(nvarchar(10), GETDATE(), 103), N'" + txtNoiGui.Text + "', N'" + txtNguoiGui.Text + "', " +
                "N'" + txtTTNguoiGui.Text + "', N'" + txtNoiNhan.Text + "', N'" + txtNguoiNhan.Text + "', " +
                "N'" + txtTTNguoiNhan.Text + "', N'" + txtNoiDung.Text + "', N'" + txtNQL.Text + "', N'" + txtBPQL.Text + "', N'" + txtNgQL.Text + "'" +
                "N'" + txtGhiChu.Text + "')");

            update(connectString, "update ThietBi set DonVi = N'"+txtDonVi+"', NoiQuanLy = N'"+txtNQL+"', BoPhanQuanLy = N'"+txtBPQL+"', " +
                "NguoiQuanLy = N'"+txtNgQL+"', TinhTrang = '"+txtTinhTrang+"', TrangThai = '"+txtTrangThai+"' " +
                "where id = '"+idThietBi+"' ");
        }

        private void GiaoNhanThietBi_FormClosing(object sender, FormClosingEventArgs e)
        {
            QuanLyThietBi.form1.Show();
        }
    }
}
