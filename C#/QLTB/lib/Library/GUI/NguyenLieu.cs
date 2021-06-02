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
    public partial class NguyenLieu : UserControl
    {
        Data data = new Data();
        XuLy xl = new XuLy();
        DB db = new DB(@"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=QLTB;Integrated Security=True");
        SqlConnection conn;
        public NguyenLieu()
        {
            InitializeComponent();
            loadNL();
        }
        public void loadNL()
        {
            try
            {
                conn = new SqlConnection(@"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=QLTB;Integrated Security=True");
                String text = "select * from NguyenLieu;select DISTINCT Ncc from NguyenLieu";
                SqlDataAdapter da = new SqlDataAdapter(text, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                dt = ds.Tables[0];
                dgvNhapHang.DataSource = dt;
                dt2 = ds.Tables[1];
                cbxnhacungcap.DataSource = dt2;
                cbxnhacungcap.DisplayMember = "Ncc";
                cbxnhacungcap.ValueMember = "Ncc";
            }
            catch (SqlException)
            {
                MessageBox.Show("Không thể kết nốt dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnthemnguyenlieu_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    if (txttennguyenlieu.Text.Length == 0)
                    {
                        MessageBox.Show("Không Được Để Tên Trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (txtdongianguyenlieu.Text.Length == 0)
                    {
                        MessageBox.Show("Không Được Để Đơn Giá Trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (txtsoluongnguyenlieu.Text.Length == 0)
                    {
                        MessageBox.Show("Không Được Để Số Lượng Trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    conn.Open();
                    String sql = "Insert into NguyenLieu Values(@Ten,@Ncc,@DonGia,@SoLuong,@NgayNhap)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Ten", txttennguyenlieu.Text);
                    cmd.Parameters.AddWithValue("@Ncc", cbxnhacungcap.Text);
                    cmd.Parameters.AddWithValue("@DonGia", Convert.ToSingle(txtdongianguyenlieu.Text));
                    cmd.Parameters.AddWithValue("@SoLuong", Convert.ToSingle(txtsoluongnguyenlieu.Text));
                    cmd.Parameters.AddWithValue("@NgayNhap", datenhapnguyenlieu.Value.ToString("yyyy-MM-dd"));
                    cmd.ExecuteNonQuery();
                    loadNL();
                    txtmanguyenlieu.Clear();
                    txttennguyenlieu.Clear();
                    txtdongianguyenlieu.Clear();
                    txtsoluongnguyenlieu.Clear();
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

        private void btnsuanguyenlieu_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtmanguyenlieu.Text.Length == 0)
                {
                    MessageBox.Show("Không Được Để Mã Trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txttennguyenlieu.Text.Length == 0)
                {
                    MessageBox.Show("Không Được Để Tên Trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtdongianguyenlieu.Text.Length == 0)
                {
                    MessageBox.Show("Không Được Để Đơn Giá Trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtsoluongnguyenlieu.Text.Length == 0)
                {
                    MessageBox.Show("Không Được Để Số Lượng Trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                conn.Open();
                String sql = "Update NguyenLieu Set Ten =N'" + txttennguyenlieu.Text + "',Ncc='" + cbxnhacungcap.Text + "',Gia='" + Convert.ToInt32(txtdongianguyenlieu.Text) + "',SoLuong='" + Convert.ToInt32(txtsoluongnguyenlieu.Text) + "',NgayNhap='" + datenhapnguyenlieu.Value.ToString("yyyy-MM-dd") + "' Where MaNhap='" + txtmanguyenlieu.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                loadNL();
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

        private void btnxoanguyenlieu_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    if (txtmanguyenlieu.Text.Length == 0)
                    {
                        MessageBox.Show("Không Được Để Mã Trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    conn.Open();
                    String sql = "Delete From NguyenLieu Where MaNhap='" + txtmanguyenlieu.Text + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    loadNL();
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

        private void btnThanhTiennguyenlieu_Click(object sender, EventArgs e)
        {
            try
            {
                txtThanhTien.Text = (Convert.ToInt32(txtsoluongnguyenlieu.Text) * Convert.ToInt32(txtdongianguyenlieu.Text)).ToString();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Đơn Giá Hoặc Số Lượng Phải Là Số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int vitri;
        private void dgvNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
            if (vitri >= 0)
            {
                txtmanguyenlieu.Text = dgvNhapHang.Rows[vitri].Cells[0].Value.ToString();
                txttennguyenlieu.Text = dgvNhapHang.Rows[vitri].Cells[1].Value.ToString();
                cbxnhacungcap.Text = dgvNhapHang.Rows[vitri].Cells[2].Value.ToString();
                txtdongianguyenlieu.Text = dgvNhapHang.Rows[vitri].Cells[3].Value.ToString();
                txtsoluongnguyenlieu.Text = dgvNhapHang.Rows[vitri].Cells[4].Value.ToString();
                datenhapnguyenlieu.Text = dgvNhapHang.Rows[vitri].Cells[5].Value.ToString();

            }
        }
    }
}
