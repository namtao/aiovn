using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xD
{
    public partial class QuaTrinhXuLy : Form
    {
        string nhiemVu = null;
        string col = null;

        public QuaTrinhXuLy()
        {
            InitializeComponent();
        }

        private void QuaTrinhXuLy_FormClosing(object sender, FormClosingEventArgs e)
        {
            HoTich.form1.Show();
        }

        private void QuaTrinhXuLy_Load(object sender, EventArgs e)
        {
            cbxLoai.SelectedIndex = 0;
            //cbxNhiemVu.SelectedIndex = 1;
            updateSum();
        }

        private void cbxQuyenSo_DropDown(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(HoTich.sqlConnect);
            conn.Open();
            string strCmd = "select distinct quyenSo from " + cbxLoai.Text + " where NOIDANGKY LIKE '%" + cbxNDK.SelectedValue + "%' ";
            SqlCommand cmd = new SqlCommand(strCmd, conn);
            SqlDataAdapter da = new SqlDataAdapter(strCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            conn.Close();
            cbxQuyenSo.DisplayMember = "quyenSo";
            cbxQuyenSo.ValueMember = "quyenSo";
            cbxQuyenSo.DataSource = ds.Tables[0];
        }

        private void cbxNDK_DropDown(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(HoTich.sqlConnect);
            conn.Open();
            string strCmd = "SELECT * FROM HT_NOIDANGKY";
            SqlCommand cmd = new SqlCommand(strCmd, conn);
            SqlDataAdapter da = new SqlDataAdapter(strCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            conn.Close();
            cbxNDK.DisplayMember = "TenNoiDangKy";
            cbxNDK.ValueMember = "MaNoiDangKy";
            cbxNDK.DataSource = ds.Tables[0];
        }

        private void cbxQuyenSo_TextChanged(object sender, EventArgs e)
        {
            updateSum();
        }

        private void cbxNDK_TextChanged(object sender, EventArgs e)
        {
            updateSum();
        }

        private void cbxLoai_TextChanged(object sender, EventArgs e)
        {
            updateSum();
        }

        private void updateSum()
        {
            SqlConnection conn = new SqlConnection(HoTich.sqlConnect);
            conn.Open();
            lbSum.Text = new SqlCommand("select count(*) from " + cbxLoai.Text + " where NOIDANGKY LIKE '%" + cbxNDK.SelectedValue + "%' " +
                "and quyenSo like '%" + cbxQuyenSo.Text + "%' ", conn)
                .ExecuteScalar().ToString() + "";
            conn.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)datagrid.DataSource;
            if (datagrid.Rows.Count != 0 && datagrid.Rows != null)
            {
                Utils.Export(dt, datagrid, "KIỂM TRA", "KIỂM TRA DỮ LIỆU");
            }
            else MessageBox.Show("Không có dữ liệu để lưu vào excel, vui lòng kiểm tra lại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void thôngTinPhiênBảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            MessageBox.Show(String.Format("Phiên bản hiện tại là: {0}", version), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void soSánhChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbxNhiemVu.SelectedIndex == 0)
            {
                nhiemVu = " ";
                col = "ngayCapNhatKT";
            }
            else if (cbxNhiemVu.SelectedIndex == 1)
            {
                nhiemVu = " and (ghiChu = '5 -> 6' or ghiChu = '5 -> 7')";
                col = "ngayCapNhatKTBM1";
            }
            else
            {
                nhiemVu = " and (ghiChu = '6 -> 7' or ghiChu = '5 -> 7')";
                col = "ngayCapNhatKTBM2";
            }
            SqlConnection conn = new SqlConnection(HoTich.sqlConnect);
            conn.Open();
            string sqlQuery = "SELECT so as N'Số', quyenSo as N'Quyển số', " +
                "TenNoiDangKy as N'Nơi đăng ký', ngayDangKy as N'Ngày đăng ký', " +
                "tableName as N'Loại', columnName as N'Trường', ktbm1 as N'Kiểm tra 1', " +
                "ktbm2 as N'Kiểm tra 2', kt as N'Kết thúc'" +
                " FROM Diff k join HT_NOIDANGKY ndk on k.noiDangKy = ndk.MaNoiDangKy " +
                "where quyenSo like '%" + cbxQuyenSo.Text + "%' " +
                "and noiDangKy LIKE '%" + cbxNDK.SelectedValue + "%' and tableName = '" + cbxLoai.Text + "'" + nhiemVu +
                "and convert(date, " + col + ", 103) between convert(date, '" + dtFrom.Value.ToString("dd/MM/yyyy") + "', 103) " +
                "and convert(date, '" + dtTo.Value.ToString("dd/MM/yyyy") + "', 103)";
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            lbSumData.Text = new SqlCommand("select count(*) from (select id from Diff where quyenSo like '%" + cbxQuyenSo.Text + "%' " +
                "and noiDangKy LIKE '%" + cbxNDK.SelectedValue + "%' and tableName = '" + cbxLoai.Text + "'" + nhiemVu +
                "and convert(date, " + col + ", 103) between convert(date, '" + dtFrom.Value.ToString("dd/MM/yyyy") + "', 103) " +
                "and convert(date, '" + dtTo.Value.ToString("dd/MM/yyyy") + "', 103) group by id) k", conn)
                .ExecuteScalar().ToString() + "";
            conn.Close();
            datagrid.DataSource = ds.Tables[0];
            datagrid.Visible = true;
        }

        private void tổngHợpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbxNhiemVu.SelectedIndex == 0)
            {
                nhiemVu = " ";
                col = "ngayCapNhatKT";
            }
            else if (cbxNhiemVu.SelectedIndex == 1)
            {
                nhiemVu = " and(ghiChu = '5 -> 6' or ghiChu = '5 -> 7')";
                col = "ngayCapNhatKTBM1";
            }
            else
            {
                nhiemVu = " and(ghiChu = '6 -> 7' or ghiChu = '5 -> 7')";
                col = "ngayCapNhatKTBM2";
            }

            SqlConnection conn = new SqlConnection(HoTich.sqlConnect);
            conn.Open();
            string sqlQuery = "select k.quyenSo as N'Quyển số', ndk.TenNoiDangKy as N'Nơi đăng ký', count(*) as N'Số bản ghi khác' " +
                "from (select so, quyenSo, noiDangKy, count(*) as SoTruongKhac " +
                "from Diff where convert(date, " + col + ", 103) " +
                "between convert(date, '" + dtFrom.Value.ToString("dd/MM/yyyy") + "', 103) and " +
                "convert(date, '" + dtTo.Value.ToString("dd/MM/yyyy") + "', 103) " +
                "" + nhiemVu + " " +
                "group by quyenSo, noiDangKy, so) k join HT_NOIDANGKY ndk on k.noiDangKy = ndk.MaNoiDangKy " +
                "group by TenNoiDangKy, k.quyenSo";
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            datagrid.DataSource = ds.Tables[0];
            datagrid.Visible = true;
        }
    }
}
