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

namespace QLTB
{
    public partial class NguyenLieu : Form
    {
        String connString = @"Data Source=NAM\SQL;Initial Catalog=QLTB;Integrated Security=True";
        SqlConnection conn;
        public NguyenLieu()
        {
            InitializeComponent();
        }

        private void NguyenLieu_Load(object sender, EventArgs e)
        {

            try
            {
                
                conn = new SqlConnection(connString);
                String text = "select * from NguyenLieu;select DISTINCT Ncc from NguyenLieu";
                SqlDataAdapter da = new SqlDataAdapter(text, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                dgvNhapHang.DataSource = dt;
                dt = ds.Tables[1];
                cbbNcc.DataSource = dt;
                cbbNcc.DisplayMember = "Ncc";
                cbbNcc.ValueMember = "Ncc";
            }
            catch (SqlException)
            {
                MessageBox.Show("Không thể kết nốt dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void NguyenLieu_FormClosed(object sender, FormClosedEventArgs e)
        {
            TrangChu tc = new TrangChu();
            tc.Show();
        }

        private void bttDong_Click(object sender, EventArgs e)
        {
            this.Close();
          
        }
        Int32 vitri;

        private void dgvNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
            if (vitri >= 0)
            {
                txtMa.Text = dgvNhapHang.Rows[vitri].Cells[0].Value.ToString();
                txtTen.Text = dgvNhapHang.Rows[vitri].Cells[1].Value.ToString();
                cbbNcc.Text = dgvNhapHang.Rows[vitri].Cells[2].Value.ToString();
                txtDongia.Text = dgvNhapHang.Rows[vitri].Cells[3].Value.ToString();
                txtSoLuong.Text = dgvNhapHang.Rows[vitri].Cells[4].Value.ToString();
                dateTimePicker1.Text = dgvNhapHang.Rows[vitri].Cells[5].Value.ToString();
              
            }
        }

        private void bttThem_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    if (txtTen.Text.Length == 0)
                    {
                        MessageBox.Show("Không Được Để Tên Trống","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                    if (txtDongia.Text.Length == 0)
                    {
                        MessageBox.Show("Không Được Để Đơn Giá Trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (txtSoLuong.Text.Length == 0)
                    {
                        MessageBox.Show("Không Được Để Số Lượng Trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                  
                    conn.Open();
                    String sql = "Insert into NguyenLieu Values(@Ten,@Ncc,@DonGia,@SoLuong,@NgayNhap)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Ten", txtTen.Text);
                    cmd.Parameters.AddWithValue("@Ncc", cbbNcc.Text);
                    cmd.Parameters.AddWithValue("@DonGia", Convert.ToSingle(txtDongia.Text));
                    cmd.Parameters.AddWithValue("@SoLuong", Convert.ToSingle(txtSoLuong.Text));
                    cmd.Parameters.AddWithValue("@NgayNhap", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    cmd.ExecuteNonQuery();
                    NguyenLieu_Load(sender, e);
                    txtMa.Clear();
                    txtTen.Clear();
                    txtDongia.Clear();
                    txtSoLuong.Clear();
                    txtTen.Focus();
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Đơn Giá Hoặc Số Lượng Phải Là Số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (SqlException)
                {
                    MessageBox.Show("Thêm Thất Bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              

                conn.Close();

            }
            else
            {
                conn.Close();
            }
        }

        private void bttSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMa.Text.Length == 0)
                {
                    MessageBox.Show("Không Được Để Mã Trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtTen.Text.Length == 0)
                {
                    MessageBox.Show("Không Được Để Tên Trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtDongia.Text.Length == 0)
                {
                    MessageBox.Show("Không Được Để Đơn Giá Trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtSoLuong.Text.Length == 0)
                {
                    MessageBox.Show("Không Được Để Số Lượng Trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                  
                conn.Open();
                String sql = "Update NguyenLieu Set Ten =N'" + txtTen.Text + "',Ncc='" + cbbNcc.Text + "',Gia='" + Convert.ToInt32(txtDongia.Text) + "',SoLuong='" + Convert.ToInt32(txtSoLuong.Text) + "',NgayNhap='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' Where MaNhap='" + txtMa.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                NguyenLieu_Load(sender, e);
                conn.Close();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Mã Đơn Giá Hoặc Số Lượng Phải Là Số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException)
            {
                MessageBox.Show("Sửa Thất Bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bttXoa_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    if (txtMa.Text.Length == 0)
                    {
                        MessageBox.Show("Không Được Để Mã Trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    conn.Open();
                    String sql = "Delete From NguyenLieu Where MaNhap='" + txtMa.Text + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    NguyenLieu_Load(sender, e);
                    conn.Close();
                    txtMa.Clear();
                    txtTen.Clear();
                    txtDongia.Clear();
                    txtSoLuong.Clear();
                    txtTen.Focus();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Mã Phải Là Số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
             
            }
            else
            {
                conn.Close();
            }
        }

        private void bttTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(connString);
                String text = "select * from NguyenLieu Where Ten Like N'%" + txtTen.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(text, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                dgvNhapHang.DataSource = dt;
            }
            catch (SqlException)
            {
                MessageBox.Show("Kết nối thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

        private void bttLoad_Click(object sender, EventArgs e)
        {
            try
            {

                conn = new SqlConnection(connString);
                String text = "select * from NguyenLieu;select DISTINCT Ncc from NguyenLieu";
                SqlDataAdapter da = new SqlDataAdapter(text, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                dgvNhapHang.DataSource = dt;
                dt = ds.Tables[1];
                cbbNcc.DataSource = dt;
                cbbNcc.DisplayMember = "Ncc";
                cbbNcc.ValueMember = "Ncc";
            }
            catch (SqlException)
            {
                MessageBox.Show("Kết nối thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bttThanhTien_Click(object sender, EventArgs e)
        {
            try
            {
                txtThanhTien.Text=(Convert.ToInt32(txtSoLuong.Text)*Convert.ToInt32(txtDongia.Text)).ToString();
            }
            catch(FormatException ex)
            {
                MessageBox.Show("Đơn Giá Hoặc Số Lượng Phải Là Số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
