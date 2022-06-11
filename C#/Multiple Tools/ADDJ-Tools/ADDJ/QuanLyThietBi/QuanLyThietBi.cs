using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADDJ;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace ADDJ
{

    /*select NoiQuanLy, LoaiThietBi, tt.TinhTrang, tt2.TrangThai, COUNT(*) as 'Số Lượng' 
    from ThietBi tb join TinhTrang tt on tb.TinhTrang = tt.ID join TrangThai tt2 on tb.TrangThai = tt2.ID
    where DonVi = 'ADDJ'
    group by NoiQuanLy, LoaiThietBi, tt.TinhTrang, tt2.TrangThai
    order by NoiQuanLy, LoaiThietBi
    
     select tb.id as 'ID', MaThietBi as 'Mã thiết bị', DonVi as 'Đơn vị', NoiQuanLy as 'Nơi quản lý', 
    BoPhanQuanLy as 'Bộ phận quản lý', NguoiQuanLy as 'Người quản lý', LoaiThietBi 'Loại thiết bị', TenThietBi as 'Tên thiết bị',
    ThongSoKyThuat as 'Thông số kỹ thuật', NuocSanXuat as 'Nước sản xuất',
    tt1.TinhTrang as 'Tình trạng', tt2.TrangThai as 'Trạng thái'
    from ThietBi tb join TinhTrang tt1 
    on tb.TinhTrang = tt1.id join TrangThai tt2 on tb.TrangThai = tt2.ID
    where DonVi = 'ADDJ'
    order by NoiQuanLy, BoPhanQuanLy, NguoiQuanLy, MaThietBi*/

    public partial class QuanLyThietBi : Form
    {
        public static QuanLyThietBi form1;
        public static string connectString = ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
        public QuanLyThietBi()
        {
            InitializeComponent();
            form1 = this;
        }

        private void Report_Load(object sender, EventArgs e)
        {
            FillDgv("select tb.id as 'ID', MaThietBi as 'Mã thiết bị', DonVi as 'Đơn vị', NoiQuanLy as 'Nơi quản lý', " +
                "BoPhanQuanLy as 'Bộ phận quản lý', NguoiQuanLy as 'Người quản lý', LoaiThietBi 'Loại thiết bị', TenThietBi as 'Tên thiết bị', " +
                "tt1.TinhTrang as 'Tình trạng', tt2.TrangThai as 'Trạng thái'" +
                "from ThietBi tb join TinhTrang tt1 " +
                "on tb.TinhTrang = tt1.id join TrangThai tt2 on tb.TrangThai = tt2.ID order by DonVi, MaThietBi");
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

        private void datagrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xem lịch sử thiết bị?", "Lịch sử thiết bị", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                DialogResult result2 = MessageBox.Show("Bạn có muốn thực hiện giao nhận thiết bị?", "Giao nhận thiết bị", MessageBoxButtons.YesNo);
                if (result2 == DialogResult.Yes)
                {
                    // giao nhận thiết bị
                    GiaoNhanThietBi gntb = new GiaoNhanThietBi();
                    gntb.idThietBi = Int32.Parse(datagrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                    gntb.Show();
                    this.Hide();
                }
            }
            else if (result == DialogResult.Yes)
            {
                if (e.RowIndex != -1)
                {
                    string id = datagrid.Rows[e.RowIndex].Cells[0].Value.ToString();

                    HoSoThietBiReport crystal = new HoSoThietBiReport();

                    TextObject tentb = (TextObject)crystal.ReportDefinition.Sections["PageHeaderSection1"].ReportObjects["text31"];
                    TextObject matb = (TextObject)crystal.ReportDefinition.Sections["PageHeaderSection1"].ReportObjects["text32"];
                    TextObject namsx = (TextObject)crystal.ReportDefinition.Sections["PageHeaderSection1"].ReportObjects["text33"];
                    TextObject nuocsx = (TextObject)crystal.ReportDefinition.Sections["PageHeaderSection1"].ReportObjects["text34"];
                    TextObject nhacc = (TextObject)crystal.ReportDefinition.Sections["PageHeaderSection1"].ReportObjects["text35"];
                    TextObject thongso = (TextObject)crystal.ReportDefinition.Sections["PageHeaderSection1"].ReportObjects["text36"];
                    TextObject tinhtranghientai = (TextObject)crystal.ReportDefinition.Sections["PageHeaderSection1"].ReportObjects["text37"];

                    SqlConnection con = new SqlConnection(connectString);
                    using (SqlCommand command = new SqlCommand("select NhaCungCap, ThongSoKyThuat, tt1.TinhTrang, tt2.TrangThai, NuocSanXuat from ThietBi tb join TinhTrang tt1 " +
                        "on tb.TinhTrang = tt1.id join TrangThai tt2 on tb.TrangThai = tt2.ID where tb.id = " + id, con))
                    {
                        command.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader d = command.ExecuteReader();

                        while (d.Read())
                        {
                            namsx.Text = "";
                            nhacc.Text = d[0].ToString();
                            thongso.Text = d[1].ToString();
                            tinhtranghientai.Text = d[2].ToString() + ", " + d[3].ToString();
                            nuocsx.Text = d[4].ToString();
                        }
                        con.Close();
                    }

                    tentb.Text = datagrid.Rows[e.RowIndex].Cells[7].Value.ToString();
                    matb.Text = datagrid.Rows[e.RowIndex].Cells[1].Value.ToString();


                    //Lịch sử thiết bị
                    string strSql = "select * from LichSuThietBi where idThietBi = " + id + " order by NgayThang";
                    SqlDataAdapter adapter = new SqlDataAdapter(strSql, connectString);
                    DataSet dataReport = new DataSet();
                    adapter.Fill(dataReport, "LichSuThietBi");

                    ReportViewer reportViewer = new ReportViewer();
                    crystal.SetDataSource(dataReport);
                    reportViewer.crystalReportViewer.ReportSource = crystal;
                    reportViewer.Show();

                    this.Hide();
                }
            }
        }

        private void QuanLyThietBi_FormClosing(object sender, FormClosingEventArgs e)
        {
            Home.form1.Show();
            this.Hide();
        }
    }
}
