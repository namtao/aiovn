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
    public partial class BanHang : UserControl
    {
        Data data = new Data();
        XuLy xl = new XuLy();
        DB db = new DB(@"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=QLTB;Integrated Security=True");
        SqlConnection conn;
        public BanHang()
        {
            InitializeComponent();
            loadBH();
        }

        public void loadBH()
        {
            txtgia.Text = "";
            string sqlTable = "select *from KhachHang";
            db.Load(sqlTable, dgvBH);

            String sql = "select * from Chungloaibanh";
            db.Load(sql, cbchungloaibanh, "Gia", "TenBanh");
            
            cbchungloaibanh.ValueMember="Gia";
            cbchungloaibanh.DisplayMember = "TenBanh";
        }

        private void btnthemkh_Click(object sender, EventArgs e)
        {
            string stsdt = txtsdtkh.Text;
            if (txtmakh.TextLength == 0)
            {
                MessageBox.Show("Mã KH không được bỏ trống"); return;
            }
            else if (txtmanv.TextLength == 0)
            {
                MessageBox.Show("Mã NV không được bỏ trống"); return;
            }
            else if (txttenkh.TextLength == 0)
            {
                MessageBox.Show("Họ tên không được bỏ trống"); return;
            }
            else if (txtdiachikh.TextLength == 0)
            {
                MessageBox.Show("Địa chỉ không được bỏ trống"); return;
            }
            else if (txtsdtkh.TextLength == 0)
            {
                MessageBox.Show("Số điện thoại không được bỏ trống"); return;
            }
            else if (xl.IsNumber(stsdt) == false)
            {
                MessageBox.Show("Nhập sai dữ liệu của số điện thoại"); return;
            }
            else if (cbchungloaibanh.SelectedIndex == -1)
            {
                MessageBox.Show("Số lượng không được bỏ trống"); return;
            }
            else if (txtgia.TextLength == 0)
            {
                MessageBox.Show("Đơn giá không được bỏ trống"); return;
            }
            else if (txtthanhtoan.TextLength == 0)
            {
                MessageBox.Show("Thành tiền không được bỏ trống"); return;
            }
            try
            {
                if (xl.kiemtratontaiBH(txtmakh.Text))
                {
                    MessageBox.Show("Mã Khách Hàng đã tồn tại");
                }
                else
                {
                    xl.insertKhachHang(txtmakh.Text, txttenkh.Text, txtdiachikh.Text, txtsdtkh.Text, datengaymua.Value.ToString("yyyy-MM-dd"), cbchungloaibanh.Text, txtsoluongban.Text, txtgia.Text, txtthanhtoan.Text, txtmanv.Text);
                    loadBH();
                    MessageBox.Show(" Thêm khách hàng thành công");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Sai câu lệnh sql" + ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtmakh.Clear();
            txttenkh.Clear();
            txtdiachikh.Clear();
            txtsdtkh.Clear();
            txtsoluongban.Clear();
            txtthanhtoan.Clear();
        }

        int dongBH;
        private void dgvBH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dongBH = e.RowIndex;
            if (dongBH >= 0)
            {
                txtmakh.Text = dgvBH.Rows[dongBH].Cells[0].Value.ToString();
                txttenkh.Text = dgvBH.Rows[dongBH].Cells[1].Value.ToString();
                txtdiachikh.Text = dgvBH.Rows[dongBH].Cells[2].Value.ToString();
                txtsdtkh.Text = dgvBH.Rows[dongBH].Cells[3].Value.ToString();
                DateTime ngaymua = DateTime.Parse(dgvBH.Rows[dongBH].Cells[4].Value.ToString());
                cbchungloaibanh.Text = dgvBH.Rows[dongBH].Cells[5].Value.ToString();
                txtsoluongban.Text = dgvBH.Rows[dongBH].Cells[6].Value.ToString();
                txtgia.Text = dgvBH.Rows[dongBH].Cells[7].Value.ToString();
                txtthanhtoan.Text = dgvBH.Rows[dongBH].Cells[8].Value.ToString();
                txtmanv.Text = dgvBH.Rows[dongBH].Cells[9].Value.ToString();
            }
        }

        private void btnsuakh_Click(object sender, EventArgs e)
        {
            string stsdt = txtsdtkh.Text;

            if (txtmakh.TextLength == 0)
            {
                MessageBox.Show("Mã KH không được bỏ trống"); return;
            }
            else if (txttenkh.TextLength == 0)
            {
                MessageBox.Show("Họ tên không được bỏ trống"); return;
            }
            else if (txtdiachikh.TextLength == 0)
            {
                MessageBox.Show("Địa chỉ không được bỏ trống"); return;
            }
            else if (txtsdtkh.TextLength == 0)
            {
                MessageBox.Show("Số điện thoại không được bỏ trống"); return;
            }
            else if (xl.IsNumber(stsdt) == false)
            {
                MessageBox.Show("Nhập sai kiểu dữ liệu của số điện thoại"); return;
            }
            else if (txtsoluongban.TextLength == 0)
            {
                MessageBox.Show("Số lượng không được bỏ trống"); return;
            }
            else if (txtthanhtoan.TextLength == 0)
            {
                MessageBox.Show("Thành tiền không được bỏ trống"); return;
            }
            try
            {
                if (xl.kiemtratontaiBH(txtmakh.Text))
                {
                    xl.updateKhachHang(txtmakh.Text, txttenkh.Text, txtdiachikh.Text, txtsdtkh.Text, datengaymua.Value.ToString("yyyy-MM-dd"), cbchungloaibanh.Text, txtsoluongban.Text, txtgia.Text, txtthanhtoan.Text, txtmanv.Text);
                    loadBH();
                    MessageBox.Show(" Cập nhật thành công");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã khách hàng");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Sai câu lệnh sql" + ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtmakh.Clear();
            txttenkh.Clear();
            txtdiachikh.Clear();
            txtsdtkh.Clear();
            txtsoluongban.Clear();
            txtthanhtoan.Clear();
        }

        private void btnxoakh_Click(object sender, EventArgs e)
        {
            if (txtmakh.TextLength == 0)
                MessageBox.Show(" Bạn cần chọn một mã Khách hàng để xóa");
            else
            {
                if (xl.kiemtratontaiBH(txtmakh.Text))
                {
                    xl.deleteKhachHang(txtmakh.Text);
                    MessageBox.Show(" Xóa thành công");
                    loadBH();

                }
                else
                {
                    MessageBox.Show("Mã Khách Hàng không tồn tại");
                }
            }
            txtmakh.Clear();
            txttenkh.Clear();
            txtdiachikh.Clear();
            txtsdtkh.Clear();
            txtsoluongban.Clear();
            txtthanhtoan.Clear();
        }

        private void btnThanhtien_Click(object sender, EventArgs e)
        {
            try
            {
                double a, b;
                a = Convert.ToDouble(txtgia.Text);
                b = Convert.ToDouble(txtsoluongban.Text);
                txtthanhtoan.Text = (a * b).ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Nhập sai dữ liệu . Kiểm tra lại dữ liệu số lượng !!!");
            }
        }

        private void btntimkiemkh_Click(object sender, EventArgs e)
        {
            if (txttimkiemkh.TextLength == 0)
                MessageBox.Show("Bạn chưa nhập từ khoá tìm kiếm");
            try
            {
                DataTable dt = new DataTable();
                dt = xl.lookBH(txttimkiemkh.Text);
                dgvBH.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbchungloaibanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtgia.Text = cbchungloaibanh.SelectedValue.ToString();
        }
    }
}
