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
    public partial class ThucDon : UserControl
    {
        Data data = new Data();
        XuLy xl = new XuLy();
        DB db = new DB(@"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=QLTB;Integrated Security=True");
        public ThucDon()
        {
            InitializeComponent();
            loadTD();
        }

        public void loadTD()
        {
            string sql = "select * from ChungLoaiBanh";
            db.Load(sql, dgvTD);
        }

        private void btnXoaTD_Click(object sender, EventArgs e)
        {
            if (txtma.TextLength == 0)
                MessageBox.Show(" Bạn cần chọn một mã bánh để xóa");
            else
            {
                if (xl.kiemtratontai(txtma.Text))
                {
                    string sql = "delete ChungLoaiBanh where MaBanh ='" + txtma.Text + "'";
                    db.Delete(sql);
                    MessageBox.Show("Đã xóa thành công");
                    loadTD();
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

        private void btnThemTD_Click(object sender, EventArgs e)
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
                if (xl.kiemtratontai(txtma.Text))
                {
                    MessageBox.Show("Mã bánh đã tồn tại , vui lòng nhập mã mới!!!");
                }
                else
                {
                    string sql = "insert into ChungLoaiBanh values(N'" + txtma.Text + "',N'" + txttenbanh.Text + "','" + txtgia.Text + "','" + txtsoluong.Text + "','" + dateTD.Value.ToString("yyyy/MM/dd") + "',N'" + txtnguocgoc.Text + "')";
                    db.Insert(sql);
                    loadTD();
                    MessageBox.Show("Thêm thành công");
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

        private void btnSuaTD_Click(object sender, EventArgs e)
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
                string sql = "update ChungLoaiBanh set TenBanh= N'" + txttenbanh.Text + "',Gia=N'" + txtgia.Text + "' ,SoLuongCo=N'" + txtsoluong.Text + "' ,NgaySX =N'" + dateTD.Value.ToString("yyyy/MM/dd") + "' ,NguonGoc=N'" + txtnguocgoc.Text + "'where  MaBanh='" + txtma.Text + "'";
                db.Update(sql);
                loadTD();
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txttim.TextLength == 0)
                MessageBox.Show("Bạn chưa nhập từ khoá tìm kiếm");
            else
            {
                string sql = "select * from ChungLoaiBanh where  MaBanh like N'" + txttim.Text + "' OR TenBanh like  N'%" + txttim.Text + "%' OR NguonGoc like N'" + txttim.Text + "' OR NguonGoc like N'" + txttim.Text + "'";
                db.Load(sql, dgvTD);
            }
        }

        int dong;
        private void dgvTD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            if (dong >= 0)
            {
                txtma.Text = dgvTD.Rows[dong].Cells[0].Value.ToString();
                txttenbanh.Text = dgvTD.Rows[dong].Cells[1].Value.ToString();
                txtgia.Text = dgvTD.Rows[dong].Cells[2].Value.ToString();
                txtsoluong.Text = dgvTD.Rows[dong].Cells[3].Value.ToString();
                DateTime ngaysx = DateTime.Parse(dgvTD.Rows[dong].Cells[4].Value.ToString());
                txtnguocgoc.Text = dgvTD.Rows[dong].Cells[5].Value.ToString();
            }
        }
    }
}
