using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Class_XuLy;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
namespace QLTB
{
    public partial class ThucDon : Form
    {
        xulythucdon xuly1 = new xulythucdon();
        string ma_banh;
        public ThucDon()
        {
            InitializeComponent();
        }
        
        private void ThucDon_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = xuly1.Showxuly();
            dataGridView1.DataSource = dt;
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                double a, b;
                a = Convert.ToDouble(txtgia.Text);
                b = Convert.ToDouble(txtsoluong.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Giá và Số Lượng là kiểu số,vui lòng nhập lại !!!");
            }
            if (txtma.TextLength == 0)
            {
                MessageBox.Show("Mã bánh không được bỏ trống"); return;
            }
            else if (txttenbanh.TextLength == 0)
            {
                MessageBox.Show("Tên bánh không được bỏ trống"); return;
            }
            else if (txtgia.TextLength == 0)
            {
                MessageBox.Show("Đơn giá không được bỏ trống"); return;
            }
            else if (txtsoluong.TextLength == 0)
            {
                MessageBox.Show("Số lượng không được bỏ trống"); return;
            }
            else if (txtnguocgoc.TextLength == 0)
            {
                MessageBox.Show("Nguồn gốc không được bỏ trống"); return;
            }
            try
            {
                if (xuly1.kiemtratontai(txtma.Text))
                {
                    MessageBox.Show("Mã bánh đã tồn tại , vui lòng nhập mã mới!!!");
                }
                else
                {
                    xuly1.insert(txtma.Text, txttenbanh.Text, txtgia.Text, txtsoluong.Text, dateTimePicker1.Value.ToString("yyyy/MM/dd"), txtnguocgoc.Text);
                    ThucDon_Load(sender, e);
                    MessageBox.Show(" Thêm thành công");
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
            txttenbanh.Clear();
            txtgia.Clear();
            txtsoluong.Clear();
            txtnguocgoc.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                double a, b;
                a = Convert.ToDouble(txtgia.Text);
                b = Convert.ToDouble(txtsoluong.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Dữ liệu là kiểu số,vui lòng nhập lại !!!");
            }
            if (txtma.TextLength == 0)
            {
                MessageBox.Show("Mã bánh không được bỏ trống"); return;
            }
            else if (txttenbanh.TextLength == 0)
            {
                MessageBox.Show("Tên bánh không được bỏ trống"); return;
            }
            else if (txtgia.TextLength == 0)
            {
                MessageBox.Show("Đơn giá không được bỏ trống"); return;
            }
            else if (txtsoluong.TextLength == 0)
            {
                MessageBox.Show("Số lượng không được bỏ trống"); return;
            }
            else if (txtnguocgoc.TextLength == 0)
            {
                MessageBox.Show("Nguồn gốc không được bỏ trống"); return;
            }
            try
            {
                xuly1.update(txtma.Text, txttenbanh.Text, txtgia.Text, txtsoluong.Text, dateTimePicker1.Value.ToString("yyyy/MM/dd"), txtnguocgoc.Text);
                ThucDon_Load(sender, e);
                MessageBox.Show(" Cập nhật thành công");
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
            txttenbanh.Clear();
            txtgia.Clear();
            txtsoluong.Clear();
            txtnguocgoc.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtma.TextLength == 0)
                MessageBox.Show(" Bạn cần chọn một mã bánh để xóa");
            else
            {
                if(xuly1.kiemtratontai(txtma.Text))
                {
                
                    xuly1.delete(txtma.Text);
                    MessageBox.Show("Đã xóa thành công");
                    ThucDon_Load(sender, e);
                }
                else 
                {
                    MessageBox.Show("Mã bánh không tồn tại");
                }
            }
            txtma.Clear();
            txttenbanh.Clear();
            txtgia.Clear();
            txtsoluong.Clear();
            txtnguocgoc.Clear();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txttimkiem.TextLength == 0)
                MessageBox.Show("Bạn chưa nhập từ khoá tìm kiếm");
            else
            {
                DataTable dt = new DataTable();
                dt = xuly1.look(txttimkiem.Text);
                dataGridView1.DataSource = dt;
            }
        }
        int dong;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            if (dong >= 0)
            {
                ma_banh = dataGridView1.Rows[dong].Cells[0].Value.ToString();
                txtma.Text = dataGridView1.Rows[dong].Cells[0].Value.ToString();
                txttenbanh.Text = dataGridView1.Rows[dong].Cells[1].Value.ToString();
                txtgia.Text = dataGridView1.Rows[dong].Cells[2].Value.ToString();
                txtsoluong.Text = dataGridView1.Rows[dong].Cells[3].Value.ToString();
                DateTime ngaysx = DateTime.Parse(dataGridView1.Rows[dong].Cells[4].Value.ToString());
                txtnguocgoc.Text = dataGridView1.Rows[dong].Cells[5].Value.ToString();
            }
        }

        private void ThucDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            TrangChu.tc.Show();
        }

    }
}
