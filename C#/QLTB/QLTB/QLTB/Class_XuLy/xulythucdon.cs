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
    public class xulythucdon
    {
        Data da = new Data();
        string ma_banh;
        public DataTable Showxuly()
        {
            string sql = "select *from ChungLoaiBanh";
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
            string sql = "update ChungLoaiBanh set TenBanh= N'" + tenbanh + "',Gia=N'" + gia + "' ,SoLuongCo=N'" + soluong + "' ,NgaySX =N'" + ngaysx + "' ,NguonGoc=N'" + nguongoc + "'where  MaBanh='" + mabanh + "'" ;
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
    }
}
