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

namespace QLTB
{
    public partial class DangNhap : Form
    {
        XuLy xl = new XuLy();
        Doimatkhau dk = new Doimatkhau();
        public static DangNhap dn;
        public DangNhap()
        {
            InitializeComponent();
            dn = this;
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            //chọn ô textbox
            txtTenDangNhap.Select();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxHien_CheckedChanged(object sender, EventArgs e)
        {
            if (chbHien.Checked) txtMatKhau.UseSystemPasswordChar = true;
            else txtMatKhau.UseSystemPasswordChar = false;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (xl.KiemTraDangNhap(txtTenDangNhap.Text, txtMatKhau.Text) == true)
                {
                    TrangChu trangChu = new TrangChu();
                    trangChu.dn = this;
                    trangChu.Show();
                    this.Hide();
                }
                else MessageBox.Show("Đăng nhập thất bại!!!");
            } catch(Exception ex) { MessageBox.Show("Đăng nhập thất bại!!!"); }
        }

        private void btnDangNhap_MouseHover(object sender, EventArgs e)
        {
            lbDangNhap.Text = "Đăng nhập";
        }

        private void btnDangNhap_MouseLeave(object sender, EventArgs e)
        {
            lbDangNhap.Text = "";
        }

        private void btnDangKi_MouseHover(object sender, EventArgs e)
        {
            lbDangKi.Text = "Đổi mật khẩu";
        }

        private void btnDangKi_MouseLeave(object sender, EventArgs e)
        {
            lbDangKi.Text = "";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn đổi mật khẩu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    dk.Show();
                    this.Hide();                  
                }
            } catch(Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập!!!");
            }
        }
    }
}
