using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    class Q10
    {

        private void ThongKe()
        {
            object[,] arr = new object[1000, 100];
            string ndk = "", nam = "", sotruonghop = "", soquyen = "";
            int count = 0;
            using (SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = HoTich; Integrated Security = True"))
            {
                string sql = "select RIGHT(quyenso, 4), noiDangKy from HT_NHANCHAMECON " +
                    "where RIGHT(quyenSo, 4) between 2007 and 2015 group by RIGHT(quyenso, 4), noiDangKy order by noiDangKy, RIGHT(quyenso, 4)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        using (SqlConnection con2 = new SqlConnection(@"Data Source =.; Initial Catalog = HoTich; Integrated Security = True"))
                        {
                            string sql2 = "select count(*) as 'Số lượng' " +
                                "from (select distinct quyenSo from HT_NHANCHAMECON " +
                                "where noiDangKy = " + dr[1] + " and quyenSo like '%/" + dr[0] + "%') a";

                            using (SqlCommand cmd2 = new SqlCommand(sql2, con2))
                            {
                                cmd2.CommandType = CommandType.Text;
                                con2.Open();
                                SqlDataReader dr2 = cmd2.ExecuteReader();
                                while (dr2.Read())
                                {
                                    arr[count, 4] = dr2[0];
                                }
                                con2.Close();
                            }
                        }

                        using (SqlConnection con3 = new SqlConnection(@"Data Source =.; Initial Catalog = HoTich; Integrated Security = True"))
                        {
                            string sql3 = "select  TenNoiDangKy, RIGHT(quyenSo, 4) as 'Năm',  count(*) as 'Số lượng' " +
                                "from HT_NHANCHAMECON ks join HT_NOIDANGKY ndk on ks.noiDangKy = ndk.MaNoiDangKy " +
                                "where noiDangKy = " + dr[1] + " and quyenSo like '%/" + dr[0] + "%' " +
                                "group by noiDangKy, TenNoiDangKy, RIGHT(quyenSo, 4) order by TenNoiDangKy, RIGHT(quyenSo, 4)";

                            using (SqlCommand cmd3 = new SqlCommand(sql3, con3))
                            {
                                cmd3.CommandType = CommandType.Text;
                                con3.Open();
                                SqlDataReader dr3 = cmd3.ExecuteReader();
                                while (dr3.Read())
                                {
                                    arr[count, 1] = dr3[0];
                                    arr[count, 2] = dr3[1];
                                    arr[count, 3] = dr3[2];
                                }
                                con3.Close();
                            }

                        }

                        count++;
                    }
                    con.Close();
                }
            }

            //Utils.ExportQ10(arr, "Q10");
        }

    }
}
