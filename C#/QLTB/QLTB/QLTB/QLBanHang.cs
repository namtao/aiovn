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
using Class_XuLy;
using System.Text.RegularExpressions;
namespace QLTB
{
    public partial class QLBanHang : Form
    {
        public QLBanHang()
        {
            InitializeComponent();
        }
        QLBH xuly1 = new QLBH();
        public Int32 tongBan=0;
        string ma_kh;
        private void QLBanHang_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = xuly1.Showxuly();
            dataGridView1.DataSource = dt;
            cbchungloaibanh.DataSource = xuly1.getTable_Chungloai();
            cbchungloaibanh.DisplayMember = "TenBanh";
            cbchungloaibanh.ValueMember = "Gia";
            
        }
        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }
        private void cbchungloaibanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtgia.Text = cbchungloaibanh.SelectedValue.ToString();
        }
        private void btnThanhtien_Click(object sender, EventArgs e)
        {
            try
            {
                double a, b;
                a = Convert.ToDouble(txtgia.Text);
                b = Convert.ToDouble(txtsoluong.Text);
                txtthanhtien.Text = (a * b).ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Nhập sai dữ liệu . Kiểm tra lại dữ liệu số lượng !!!");
            }      
        }
       
        private void btnTimKiem_Click(object sender, EventArgs e)
        {

           if (txttimkiem.TextLength == 0)
               MessageBox.Show("Bạn chưa nhập từ khoá tìm kiếm");
           try
           {
                   DataTable dt = new DataTable();
                   dt = xuly1.look(txttimkiem.Text);
                   dataGridView1.DataSource = dt;  
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            string stsdt = txtsdt.Text;
            if (txtma.TextLength == 0)
            {MessageBox.Show("Mã KH không được bỏ trống"); return;
            }
            else if (txtten.TextLength == 0)
            {MessageBox.Show("Họ tên không được bỏ trống");return;
            }
            else if (txtdiachi.TextLength == 0)
            { MessageBox.Show("Địa chỉ không được bỏ trống");return;
            }
            else if (txtsdt.TextLength == 0)
            { MessageBox.Show("Số điện thoại không được bỏ trống");return;
            }
            else if (IsNumber(stsdt) == false)
            { MessageBox.Show("Nhập sai dữ liệu của số điện thoại");return;
            }
            else if (cbchungloaibanh.SelectedIndex == -1)
            { MessageBox.Show("Số lượng không được bỏ trống");return;
            }
            else if (txtgia.TextLength == 0)
            { MessageBox.Show("Đơn giá không được bỏ trống"); return;
            }
            else if (txtthanhtien.TextLength == 0)
            { MessageBox.Show("Thành tiền không được bỏ trống"); return;
            }
            try
            {
                if (xuly1.kiemtratontai(txtma.Text))
                {
                    MessageBox.Show("Mã Khách Hàng đã tồn tại");
                }
                else
                {
                    xuly1.insertKhachHang(txtma.Text, txtten.Text, txtdiachi.Text, txtsdt.Text.Trim(), dateTimePicker1.Value.ToString("yyyy/MM/dd"), cbchungloaibanh.Text, txtsoluong.Text, txtgia.Text, txtthanhtien.Text);
                    QLBanHang_Load(sender, e);
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
            txtma.Clear();
            txtten.Clear();
            txtdiachi.Clear();
            txtsdt.Clear();
            txtsoluong.Clear();
            txtthanhtien.Clear();
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            string stsdt = txtsdt.Text;

            if (txtma.TextLength == 0)
            { MessageBox.Show("Mã KH không được bỏ trống"); return;
            }
            else if (txtten.TextLength == 0)
            { MessageBox.Show("Họ tên không được bỏ trống");return;
            }
            else if (txtdiachi.TextLength == 0)
            {MessageBox.Show("Địa chỉ không được bỏ trống");return;
            }
            else if (txtsdt.TextLength == 0)
            { MessageBox.Show("Số điện thoại không được bỏ trống");return;
            }
            else if (IsNumber(stsdt) == false)
            {MessageBox.Show("Nhập sai kiểu dữ liệu của số điện thoại");return;
            }
            else if (txtsoluong.TextLength == 0)
            {MessageBox.Show("Số lượng không được bỏ trống"); return;
            }
            else if (txtthanhtien.TextLength == 0)
            {MessageBox.Show("Thành tiền không được bỏ trống"); return;
            }
            try
            {
                if (xuly1.kiemtratontai(txtma.Text))
                {
                    xuly1.updateKhachHang(ma_kh, txtma.Text, txtten.Text, txtdiachi.Text, txtsdt.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd"), cbchungloaibanh.Text, txtsoluong.Text, txtgia.Text, txtthanhtien.Text);
                    QLBanHang_Load(sender, e);
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
            txtma.Clear();
            txtten.Clear();
            txtdiachi.Clear();
            txtsdt.Clear();
            txtsoluong.Clear();
            txtthanhtien.Clear();
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (txtma.TextLength == 0)
                MessageBox.Show(" Bạn cần chọn một mã Khách hàng để xóa");
            else
            {
                if (xuly1.kiemtratontai(txtma.Text))
                {
                    xuly1.deleteKhachHang(txtma.Text);
                    MessageBox.Show(" Xóa thành công");
                    QLBanHang_Load(sender, e);

                }
                else
                {
                    MessageBox.Show("Mã Khách Hàng không tồn tại");
                }
            }
            txtma.Clear();
            txtten.Clear();
            txtdiachi.Clear();
            txtsdt.Clear();
            txtsoluong.Clear();
            txtthanhtien.Clear();
        }
        int dong; 
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            if (dong >= 0)
            {
                ma_kh = dataGridView1.Rows[dong].Cells[0].Value.ToString();
                txtma.Text = dataGridView1.Rows[dong].Cells[0].Value.ToString();
                txtten.Text = dataGridView1.Rows[dong].Cells[1].Value.ToString();
                txtdiachi.Text = dataGridView1.Rows[dong].Cells[2].Value.ToString();
                txtsdt.Text = dataGridView1.Rows[dong].Cells[3].Value.ToString();
                DateTime ngaymua = DateTime.Parse(dataGridView1.Rows[dong].Cells[4].Value.ToString());
                cbchungloaibanh.Text = dataGridView1.Rows[dong].Cells[5].Value.ToString();
                txtsoluong.Text = dataGridView1.Rows[dong].Cells[6].Value.ToString();
                txtgia.Text = dataGridView1.Rows[dong].Cells[7].Value.ToString();
                txtthanhtien.Text = dataGridView1.Rows[dong].Cells[8].Value.ToString();
            }
        }

        private void QLBanHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            TrangChu.tc.Show();
        }
    }
}
