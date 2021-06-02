using Class_DuLieu;
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



namespace Class_XuLy
{
    public class QLBH
    {
        Data da = new Data();
        public DataTable Showxuly()
        {
            string sql = "select *from KhachHang";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public DataTable getTable_Chungloai()
        {
            SqlConnection con = da.GetConnect();
            SqlDataAdapter daChungloai = new SqlDataAdapter("select *from Chungloaibanh", con);
            DataTable dtChungloai = new DataTable();
            daChungloai.Fill(dtChungloai);
            return (dtChungloai);
        }
        public bool kiemtratontai(string maso)
        {
            bool tatkt = false;
            SqlConnection con = da.GetConnect();
            SqlCommand cmd = new SqlCommand("Select * from  KhachHang", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (maso == dr.GetString(0))
                {
                    tatkt = true;
                    break;
                }
            }
            da.GetConnect().Close();
            return tatkt;
        }
        public void insertKhachHang(string makh, string tenkh, string diachi, string sdt, string ngaymua, string chungloai, string soluong, string dongia, string thanhtien)//them
        {

            string sql = "insert into KhachHang values(N'" + makh + "',N'" + tenkh + "',N'" + diachi + "',N'" + sdt + "',N'" + ngaymua + "',N'" + chungloai + "','" + soluong + "','" + dongia + "','" + thanhtien + "')";
            da.ExcuteNonQuery(sql);
        }
        public void updateKhachHang(string ma_kh, string makh, string tenkh, string diachi, string sdt, string ngaymua, string chungloai, string soluong, string dongia, string thanhtien)
        {
            string sql = "update KhachHang set TenKH= N'" + tenkh + "',DiaChi=N'" + diachi + "' ,SDT=N'" + sdt + "' ,NgayMuaHang =N'" + ngaymua + "' ,ChungLoaiBanh=N'" + chungloai + "' ,SoLuong='" + soluong + "',DonGia ='" + dongia + "',ThanhTien ='" + thanhtien + "'where  MaKH='" + makh + "'";
            da.ExcuteNonQuery(sql);
        }
        public void deleteKhachHang(string makh)
        {
            string sql = "delete KhachHang where MaKH ='" + makh + "'";
            da.ExcuteNonQuery(sql);

        }
        public DataTable look(string dk)
        {
            string sql = "select *from KhachHang where  MaKH like N'" + dk + "' OR TenKH like  N'%" + dk + "%'";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            da.ExcuteNonQuery(sql);
            return dt;
        }
    }
}
