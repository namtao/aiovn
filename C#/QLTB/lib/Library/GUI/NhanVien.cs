using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Class_DuLieu;
using Class_XuLy;
using Handle;

namespace GUI
{
    public partial class NhanVien : UserControl
    {
        Data data = new Data();
        XuLy xl = new XuLy();
        DB db = new DB(@"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=QLTB;Integrated Security=True");
        SqlConnection conn;
        public NhanVien()
        {
            InitializeComponent();
            load();
        }

        public void load()
        {
            if (txtMaNhanVien.Text == "") txtMaNhanVien.Text = "Mã nhân viên";
            txtMaNhanVien.ForeColor = Color.Silver;
            if (txtHoTen.Text == "") txtHoTen.Text = "Họ tên nhân viên";
            txtHoTen.ForeColor = Color.Silver;
            if (txtSdt.Text == "") txtSdt.Text = "Số điện thoại";
            txtSdt.ForeColor = Color.Silver;
            
            String sql = "Select * from NhanVien";
            db.Load(sql, dgv);
        }
        private void dateBd_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime bd = Convert.ToDateTime(dateBd.Value.ToString("yyyy-MM-dd"));
                DateTime kt = Convert.ToDateTime(dateKt.Value.ToString("yyyy-MM-dd"));
                TimeSpan Time = kt - bd;
                int tongSoNgay = Time.Days;
                double tongLuong = tongSoNgay * Convert.ToDouble(cbxHeSo.Text) * 100000;
                lbLuong.Text = tongLuong.ToString();
            }
            catch (Exception) { }
        }
        private void txtMaNhanVien_Enter(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text == "Mã nhân viên") txtMaNhanVien.Text = "";
            txtMaNhanVien.ForeColor = Color.Black;
        }

        private void txtMaNhanVien_Leave(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text == "")
            {
                txtMaNhanVien.Text = "Mã nhân viên";
                txtMaNhanVien.ForeColor = Color.Silver;
            }
        }

        private void txtHoTen_Enter(object sender, EventArgs e)
        {
            if (txtHoTen.Text == "Họ tên nhân viên") txtHoTen.Text = "";
            txtHoTen.ForeColor = Color.Black;
        }

        private void txtHoTen_Leave(object sender, EventArgs e)
        {
            if (txtHoTen.Text == "")
            {
                txtHoTen.Text = "Họ tên nhân viên";
                txtHoTen.ForeColor = Color.Silver;
            }
        }

        private void txtSdt_Enter(object sender, EventArgs e)
        {
            if (txtSdt.Text == "Số điện thoại") txtSdt.Text = "";
            txtSdt.ForeColor = Color.Black;
        }

        private void txtSdt_Leave(object sender, EventArgs e)
        {
            if (txtSdt.Text == "")
            {
                txtSdt.Text = "Số điện thoại";
                txtSdt.ForeColor = Color.Silver;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (xl.KiemTraHopLe(txtMaNhanVien.Text, txtHoTen.Text, txtSdt.Text) == false) MessageBox.Show("Không được để trống, số điện thoại phải 10 số");
                else
                {
                    double luong = Convert.ToDouble(lbLuong.Text);
                    String sql = "insert into NhanVien values('" + txtMaNhanVien.Text + "',N'" + txtHoTen.Text + "',N'" + txtSdt.Text + "',N'" + dateBd.Value.ToString("yyyy/MM/dd") + "',N'" + dateKt.Value.ToString("yyyy/MM/dd") + "','" + cbxHeSo.Text + "','" + luong + "')";
                    db.Insert(sql);
                    load();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Không thêm được, xin kiểm tra lại");
            }
                
           
        }

       

        private void dateKt_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime bd = Convert.ToDateTime(dateBd.Value.ToString("yyyy-MM-dd"));
                DateTime kt = Convert.ToDateTime(dateKt.Value.ToString("yyyy-MM-dd"));
                TimeSpan Time = kt - bd;
                int tongSoNgay = Time.Days;
                double tongLuong = tongSoNgay * Convert.ToDouble(cbxHeSo.Text) * 100000;
                lbLuong.Text = tongLuong.ToString();
            }
            catch (Exception) { }
        }

        private void cbxHeSo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime bd = Convert.ToDateTime(dateBd.Value.ToString("yyyy-MM-dd"));
                DateTime kt = Convert.ToDateTime(dateKt.Value.ToString("yyyy-MM-dd"));
                TimeSpan Time = kt - bd;
                int tongSoNgay = Time.Days;
                int tongLuong = (int)(tongSoNgay * Convert.ToDouble(cbxHeSo.Text) * 100000);
                lbLuong.Text = tongLuong.ToString();
            }
            catch (Exception ex) { }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                double luong = Convert.ToDouble(lbLuong.Text);
                String sql = "update NhanVien set HoTen=N'" + txtHoTen.Text + "',Sdt=N'" + txtSdt.Text + "',NgayBatDau=N'" + dateBd.Value.ToString("yyyy/MM/dd") + "',NgayKetThuc=N'" + dateKt.Value.ToString("yyyy/MM/dd") + "',HeSoLuong='" + cbxHeSo.Text + "',Luong='" + lbLuong.Text + "' where MaNV='" + txtMaNhanVien.Text + "'";
                db.Update(sql);
                load();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không sửa được, xin kiểm tra lại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                String sql = "delete NhanVien where MaNV='" + txtMaNhanVien.Text + "'";
                db.Delete(sql);
                load();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không xóa được, xin kiểm tra lại");
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM NhanVien WHERE HoTen LIKE N'%" + txtTimKiem.Text + "%' OR Sdt LIKE '%" + txtTimKiem.Text + "%' OR MaNV LIKE '%" + txtTimKiem.Text + "%'";
            db.Load(sql, dgv);
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int d = e.RowIndex;
                txtMaNhanVien.Text = dgv.Rows[d].Cells[0].Value.ToString();
                txtHoTen.Text = dgv.Rows[d].Cells[1].Value.ToString();
                txtSdt.Text = dgv.Rows[d].Cells[2].Value.ToString();
                dateBd.Text = dgv.Rows[d].Cells[3].Value.ToString();
                dateKt.Text = dgv.Rows[d].Cells[4].Value.ToString();
                cbxHeSo.Text = dgv.Rows[d].Cells[5].Value.ToString();
                lbLuong.Text = dgv.Rows[d].Cells[6].Value.ToString();
            }
            catch (Exception) { }
        }
    }
}
