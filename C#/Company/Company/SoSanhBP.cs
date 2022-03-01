using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Company
{
    public partial class SoSanhBP : Form
    {
        public static string sqlConnect = ConfigurationManager.ConnectionStrings["DBBinhPhuoc"].ConnectionString;
        public SoSanhBP()
        {
            InitializeComponent();
        }

        public void SoSanh()
        {
            string pathDir = Path.Combine(System.IO.Directory.GetParent(System.Reflection.Assembly.GetEntryAssembly().Location).ToString(), "sosanh.txt");
            if (!File.Exists(pathDir))
            {
                File.Create(pathDir);
            }
            File.WriteAllText(pathDir, String.Empty);

            List<string> listTitle = new List<string>();
            List<string> listID = new List<string>();
            List<string> listDiff, listUser, listNgay;
            List<string> lst = new List<string>();

            //cấu hình excel
            int colStart = 1;
            int colEnd = 7;
            int rowStart = 3;
            int rowEnd = 100000;

            object[,] arr = new object[rowEnd, colEnd];
            arr[0, 0] = "STT";
            arr[0, 1] = "ID";
            arr[0, 2] = "Tên cột lỗi";
            arr[0, 3] = "Lần 1";
            arr[0, 4] = "Lần 2";
            arr[0, 5] = "Người cập nhật";
            arr[0, 6] = "Ngày cập nhật";

            int dong = 1;

            //cập nhật danh sách biên mục 1
            using (SqlConnection con = new SqlConnection(sqlConnect))
            {
                string str = "SET IDENTITY_INSERT ThongTinBienMuc2 ON; " +
                    "INSERT INTO ThongTinBienMuc2(ID, SoVaKyHieu, NgayBanHanh, " +
                    "TrichYeuND, TacGiaVB, ToSo, GhiChu, STT, HopSo, HoSoSo, TieuDeHS, " +
                    "SoLuongTo, ThoiHanBaoQuan, Nam, Phong, MaDinhDanh, TenLoaiVB, " +
                    "MucLucSo, SuDung, TrangThai, ThoiGianBDKT, NgayTao, NgayCapNhat, IdNguoiDung) " +
                    "select ID, SoVaKyHieu, NgayBanHanh, TrichYeuND, TacGiaVB, ToSo, GhiChu, " +
                    "STT, HopSo, HoSoSo, TieuDeHS, SoLuongTo, ThoiHanBaoQuan, Nam, Phong, " +
                    "MaDinhDanh, TenLoaiVB, MucLucSo, SuDung, TrangThai, ThoiGianBDKT, NgayTao, NgayCapNhat, IdNguoiDung " +
                    "from ThongTinBienMuc where id not in (select id from ThongTinBienMuc2) and TrangThai = 1; " +
                    "SET IDENTITY_INSERT ThongTinBienMuc2 OFF; ";

                using (SqlCommand cmd = new SqlCommand(str, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            //cập nhật danh sách biên mục 2
            using (SqlConnection con = new SqlConnection(sqlConnect))
            {
                string str = "SET IDENTITY_INSERT ThongTinBienMuc2 ON; " +
                    "INSERT INTO ThongTinBienMuc2(ID, SoVaKyHieu, NgayBanHanh, " +
                    "TrichYeuND, TacGiaVB, ToSo, GhiChu, STT, HopSo, HoSoSo, " +
                    "TieuDeHS, SoLuongTo, ThoiHanBaoQuan, Nam, Phong, MaDinhDanh, " +
                    "TenLoaiVB, MucLucSo, SuDung, TrangThai, ThoiGianBDKT, NgayTao, " +
                    "NgayCapNhat, IdNguoiDung) select ID, SoVaKyHieu, NgayBanHanh, " +
                    "TrichYeuND, TacGiaVB, ToSo, GhiChu, STT, HopSo, HoSoSo, TieuDeHS, " +
                    "SoLuongTo, ThoiHanBaoQuan, Nam, Phong, MaDinhDanh, TenLoaiVB, " +
                    "MucLucSo, SuDung, TrangThai, ThoiGianBDKT, NgayTao, NgayCapNhat, " +
                    "IdNguoiDung from ThongTinBienMuc " +
                    "where id in (select id from ThongTinBienMuc2) and TrangThai = 2 " +
                    "and id not in (select id from ThongTinBienMuc2 group by id having count(*) > 1); " +
                    "SET IDENTITY_INSERT ThongTinBienMuc2 OFF;";

                using (SqlCommand cmd = new SqlCommand(str, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            //lấy thông tin cột
            using (SqlConnection con = new SqlConnection(sqlConnect))
            {
                string str = " select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'ThongTinBienMuc'";

                using (SqlCommand cmd = new SqlCommand(str, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    //duyệt từng bản ghi
                    while (dr.Read())
                    {
                        listTitle.Add(dr[0].ToString());
                    }
                    con.Close();
                }
            }

            // lấy thông tin bản ghi đủ 2 trạng thái
            using (SqlConnection con = new SqlConnection(sqlConnect))
            {
                string str = "select id from ThongTinBienMuc2 " +
                    "where id in (select id from ThongTinBienMuc2  group by id having count(*) > 1) " +
                    "and CONVERT(varchar(10),NgayCapNhat,103) between '"+dateTimePicker1.Value.ToString("dd/MM/yyyy")+"'" +" " +
                    "and '"+ dateTimePicker2.Value.ToString("dd/MM/yyyy")+ "'";

                using (SqlCommand cmd = new SqlCommand(str, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    //duyệt từng bản ghi
                    while (dr.Read())
                    {
                        listID.Add(dr[0].ToString());
                    }
                    con.Close();
                }
            }

            //so sánh
            foreach (string id in listID)
            {
                foreach (string title in listTitle)
                {
                    using (SqlConnection con = new SqlConnection(sqlConnect))
                    {
                        listDiff = new List<string>();
                        listUser = new List<string>();
                        listNgay = new List<string>();


                        string str = "select bm." + title + ", TenDayDu, bm.NgayCapNhat " +
                            "FROM ThongTinBienMuc2 bm left join NguoiDung nd on bm.IdNguoiDung = nd.ID " +
                            "where bm.id = " + id + "order by bm.NgayCapNhat asc";

                        using (SqlCommand cmd = new SqlCommand(str, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            con.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                            //duyệt từng bản ghi
                            while (dr.Read())
                            {
                                listDiff.Add(dr[0].ToString());
                                listUser.Add(dr[1].ToString());
                                listNgay.Add(dr[2].ToString());
                            }
                            con.Close();
                        }
                    }

                    if (!listDiff[0].Equals(listDiff[1])
                        && !title.Equals("ID")
                        && !title.Equals("TrangThai")
                        && !title.Equals("NgayTao")
                        && !title.Equals("NgayCapNhat")
                        && !title.Equals("IdNguoiDung"))
                    {
                        /*MessageBox.Show(id +" "+ title + " lần 1: " + listDiff[0]+ " lần 2:" + listDiff[1]);*/
                        lst.Add(id);
                        /*using (StreamWriter streamWriter = File.AppendText(pathDir))
                        {
                            streamWriter.WriteLine(id + "\t" + title + "\t" + 
                                listDiff[0].Replace("\n", "").Replace("\r", "").Replace("\t", "") + 
                                "\t" + listDiff[1].Replace("\n", "").Replace("\r", "").Replace("\t", ""));
                        }*/

                        arr[dong, 0] = dong;
                        arr[dong, 1] = id;
                        arr[dong, 2] = title;
                        arr[dong, 3] = listDiff[0].Replace("\n", "").Replace("\r", "").Replace("\t", "");
                        arr[dong, 4] = listDiff[1].Replace("\n", "").Replace("\r", "").Replace("\t", "");
                        arr[dong, 5] = listUser[0] + "\t" + listUser[1];
                        arr[dong, 6] = listNgay[1];
                        dong++;
                    }
                }


            }


            Utils.ExportExcel(arr, "Sheet", rowStart, colStart, rowEnd, colEnd);

            // Thông báo lỗi
            MessageBox.Show("Có " + lst.Count + " số lỗi, " + lst.Distinct().ToList().Count + " số bản ghi lỗi.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SoSanhBP_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SoSanh();
        }
    }
}
