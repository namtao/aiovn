using Class_DuLieu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handle;

namespace Class_XuLy
{
    public class XuLy
    {
        Data data = new Data();
        DB db = new DB(@"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=QLTB;Integrated Security=True");

        public DataTable doanhthu()
        {
            String sql = "Select * from REVENUE";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }
        public string role(string id)
        {
            string str = "";
            SqlConnection con = data.GetConnect();
            con.Open();
            SqlCommand cmd = new SqlCommand("select Quyen from DangNhap where TenDangNhap='" + id + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    str = dr["Quyen"].ToString();
                }
            }
            return str;
        }


        public DataTable Show()
        {
            String sql = "Select * from NhanVien";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }

        public void Them(String manv, String hoten,String sdt,String ngaybatdau,String ngayketthuc,String hesoluong, String luong)
        {
            String sql = "insert into NhanVien values(N'"+manv+ "',N'" + hoten + "',N'" + sdt + "',N'" + ngaybatdau + "',N'" + ngayketthuc + "','" + hesoluong + "','" + luong + "')";
            //data.ExcuteNonQuery(sql);
            db.Insert(sql);
        }

        public void Sua(String manv, String hoten, String sdt, String ngaybatdau, String ngayketthuc, String hesoluong, String luong)
        {
            String sql = "update NhanVien set HoTen=N'" + hoten + "',Sdt=N'" + sdt + "',NgayBatDau=N'" + ngaybatdau + "',NgayKetThuc=N'" + ngayketthuc + "',HeSoLuong='" + hesoluong + "',Luong='" + luong + "' where MaNV='"+manv+"'";
            //data.ExcuteNonQuery(sql);
            db.Update(sql);
        }

        public void Xoa(String manv)
        {
            String sql = "delete NhanVien where MaNV='"+manv+"'";
            //data.ExcuteNonQuery(sql);
            db.Delete(sql);
        }

        public DataTable TimKiem(String tk)
        {
            string sql = "SELECT * FROM NhanVien WHERE HoTen LIKE N'%" + tk + "%' OR Sdt LIKE '%" + tk + "%' OR MaNV LIKE '%" + tk + "%'";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            data.ExcuteNonQuery(sql);
            return dt;
        }

        public bool KiemTraDangNhap(string id, string ps)
        {
            SqlConnection con = data.GetConnect();
            SqlCommand cmd = new SqlCommand("select * from DangNhap where TenDangNhap='" + id + "' and MatKhau='" + ps + "'  ", con);
            con.Open();
            SqlDataReader dtr = cmd.ExecuteReader();
            if (dtr.Read() == true)
            {
                return true;
            }
            return false;
        }

        public void Doimk(String ten, string mkm)
        {
            String sql = "update DangNhap set MatKhau='"+mkm+"' where TenDangNhap='"+ten+"' ";
            data.ExcuteNonQuery(sql);
        }

        public void Reset()
        {
            String sql = "delete from DangNhap";
            String sql1 = "delete from KhachHang";
            String sql2 = "delete from NguyenLieu";
            String sql3 = "delete from ChungLoaiBanh";
            String sql4 = "delete from NhanVien";
            data.ExcuteNonQuery(sql);
            data.ExcuteNonQuery(sql1);
            data.ExcuteNonQuery(sql2);
            data.ExcuteNonQuery(sql3);
            data.ExcuteNonQuery(sql4);
        }

        public Boolean KiemTraHopLe(String ma,String ten,String sdt)
        {
            if (ma == "" || ten == "" || sdt == "" || sdt.Length != 10) return false;
            if (IsNumber(sdt) == false) return false;
            return true;
        }

        public bool IsNumber(string str)
        {
            foreach (Char c in str)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        public void SoLuongKhachHang()
        {
            String sql = "select cout(*) from KhachHang";
            data.ExcuteNonQuery(sql);
        }


        //xử lý thực đơn
        Data da = new Data();
        public DataTable Showxuly()
        {
            string sql = "select * from ChungLoaiBanh";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public bool kiemtratontai(string maso)
        {
            bool tatkt = false;
            SqlConnection con = da.GetConnect();
            SqlCommand cmd = new SqlCommand("Select * from  ChungLoaiBanh", con);
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
        public void insert(string mabanh, string tenbanh, string gia, string soluong, string ngaysx, string nguongoc)
        {
            string sql = "insert into ChungLoaiBanh values(N'" + mabanh + "',N'" + tenbanh + "',N'" + gia + "',N'" + soluong + "',N'" + ngaysx + "',N'" + nguongoc + "')";
            da.ExcuteNonQuery(sql);
        }
        public void update(string mabanh, string tenbanh, string gia, string soluong, string ngaysx, string nguongoc)
        {
            string sql = "update ChungLoaiBanh set TenBanh= N'" + tenbanh + "',Gia=N'" + gia + "' ,SoLuongCo=N'" + soluong + "' ,NgaySX =N'" + ngaysx + "' ,NguonGoc=N'" + nguongoc + "'where  MaBanh='" + mabanh + "'";
            da.ExcuteNonQuery(sql);
        }
        public void delete(string mabanh)
        {
            string sql = "delete ChungLoaiBanh where MaBanh ='" + mabanh + "'";
            da.ExcuteNonQuery(sql);
        }
        public DataTable look(string dk)
        {
            string sql = "select *from ChungLoaiBanh where  MaBanh like N'" + dk + "' OR TenBanh like  N'%" + dk + "%' OR NguonGoc like N'" + dk + "' OR NguonGoc like N'" + dk + "'";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            da.ExcuteNonQuery(sql);
            return dt;
        }

        public DataTable ShowxulyBH()
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
        public bool kiemtratontaiBH(string maso)
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
        public void insertKhachHang(string makh, string tenkh, string diachi, string sdt, string ngaymua, string chungloai, string soluong, string dongia, string thanhtien,string manv)//them
        {

            string sql = "insert into KhachHang values(N'" + makh + "',N'" + tenkh + "',N'" + diachi + "',N'" + sdt + "',N'" + ngaymua + "',N'" + chungloai + "','" + soluong + "','" + dongia + "','" + thanhtien + "','"+manv+"')";
            da.ExcuteNonQuery(sql);
        }
        public void insertNhanVien(string manv, string tennv, string sdt, string ngaybd, string ngaykt, string heso, string luong)//them
        {

            string sql = "insert into NhanVien values(N'" + manv + "',N'" + tennv + "',,N'" + sdt + "',N'" + ngaybd + "',N'" + ngaykt + "','" + heso + "','" + luong + "')";
            da.ExcuteNonQuery(sql);
        }
        public void updateKhachHang(string makh, string tenkh, string diachi, string sdt, string ngaymua, string chungloai, string soluong, string dongia, string thanhtien, string manv)
        {
            string sql = "update KhachHang set TenKH= N'" + tenkh + "',DiaChi=N'" + diachi + "' ,SDT=N'" + sdt + "' ,NgayMuaHang =N'" + ngaymua + "' ,ChungLoaiBanh=N'" + chungloai + "' ,SoLuong='" + soluong + "',DonGia ='" + dongia + "',ThanhTien ='" + thanhtien + "',MaNV='"+manv+"' where  MaKH='" + makh + "'";
            da.ExcuteNonQuery(sql);
        }
        public void deleteKhachHang(string makh)
        {
            string sql = "delete KhachHang where MaKH ='" + makh + "'";
            da.ExcuteNonQuery(sql);

        }
        public DataTable lookBH(string dk)
        {
            string sql = "select *from KhachHang where  MaKH like N'" + dk + "' OR TenKH like  N'%" + dk + "%'";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            da.ExcuteNonQuery(sql);
            return dt;
        }

       
    }
}
