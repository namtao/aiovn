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
using System.Threading;

namespace QLTB
{
    public partial class Doimatkhau : Form
    {
        XuLy xl = new XuLy();
        public Doimatkhau()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTen.Text == "") MessageBox.Show("Không được để trống!!!");
                else if (txtMatKhau.Text == "") MessageBox.Show("Không được để trống!!!");
                else if (txtXacNhan.Text == "") MessageBox.Show("Không được để trống!!!");
                else if (tbmkm.Text.Equals(txtXacNhan.Text) == false) MessageBox.Show("Xác nhận mật khẩu sai!!!");
                else if (txtTen.Text.Length < 8 || txtTen.Text.Length > 20) MessageBox.Show("Tên đăng nhập nằm trong khoảng 8-20 ký tự!!!");
                else if (xl.KiemTraDangNhap(txtTen.Text, txtMatKhau.Text) == false) MessageBox.Show("Tài khoản hoặc mật khẩu cũ không đúng");
                else
                {
                    xl.Doimk(txtTen.Text, tbmkm.Text);
                    MessageBox.Show("Đổi mật khẩu thành công!!! hệ thống sẽ quay lại màn hình đăng nhập sau 5s khi click OK");
                    Thread.Sleep(5000);
                    DangNhap dn = new DangNhap();
                    dn.Show();
                    this.Close();
                }
            } catch(Exception ex)
            {
                MessageBox.Show("Không đổi mật khẩu được, xin kiểm tra lại!!!");
            }
            
        }

        private void DangKy_Load(object sender, EventArgs e)
        {
            txtTen.Select();
        }

        private void DangKy_FormClosing(object sender, FormClosingEventArgs e)
        {
            DangNhap.dn.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
