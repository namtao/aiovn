using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Configuration;

namespace ADDJ
{
    public partial class HoTich : Form
    {
        public static string sqlConnect = ConfigurationManager.ConnectionStrings["hotich"].ConnectionString;
        string imagePath = ConfigurationManager.AppSettings.Get("imagePath");
        public static HoTich form1;
        public static string dtTo, dtFrom;
        string hoten = null;
        string ngaySinh = null;
        string strCommandSql = null;
        string table = null;
        SqlConnection conn;
        Thread threadKS, threadKT, threadKH, threadCMC;
        DataTable dt;
        List<XuLy> listXuLyKS, listXuLyKT, listXuLyKH, listXuLyCMC, listKS, listKT, listKH, listCMC;
        Thread threadXuLyKS, threadXuLyKT, threadXuLyKH, threadXuLyCMC;
        Thread threadUpdateKS7, threadUpdateKT7, threadUpdateKH7, threadUpdateCMC7;
        int ksDuoi16 = 0, ksTren16 = 0, ktDuoi16 = 0, ktTren16 = 0, khDuoi16 = 0, khTren16 = 0, cmcDuoi16 = 0, cmcTren16 = 0;

        public void AG()
        {
            //thread An Giang
            //Thread threadAG, threadAG1, threadAG2;
            /*threadAG = new Thread(() =>
            {
                using (SqlConnection con = new SqlConnection(sqlConnect))
                {
                    string sql = "use UBND_Tp_Long_Xuyen_tinh_An_Giang_1975_2011; " +
                    "SELECT TENDONVIPHATHANH, NGAYLAP, HOSOSO, KYHIEU, TRICHYEU, TOSO, TIEUDE, " +
                    "THOIHANBAOQUAN, THOIGIANBATDAU,  vb.THOIGIANKETTHUC, hs.THOIGIANKETTHUC," +
                    "vb.GHICHU1, vb.GHICHU2, hs.GHICHU1, hs.GHICHU2, SOTO, TENLOAIVANBAN, TENPHONG " +
                    "FROM VANBAN vb " +
                    "left join DONVIPHATHANH dvph on vb.MADONVIPHATHANH = dvph.MADONVIPHATHANH " +
                    "left join HOSO hs on vb.MAHOSO = hs.MAHOSO " +
                    "left join LOAIVANBAN lvb on vb.MALOAIVANBAN = lvb.MALOAIVANBAN " +
                    "left join PHONG p on hs.MAPHONG = p.MAPHONG";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            for (int i = 0; i < sql.Split(new string[] { "FROM" }, StringSplitOptions.None)[0].
                                Split(new string[] { "SELECT" }, StringSplitOptions.None)[1].Trim().Split(',').Length; i++)
                            {
                                if (dr[i].ToString().Trim().Length > 0 && dr[i] != null && !dr[i].ToString().Trim().Equals(""))
                                    ag++;
                            }
                        }
                        MessageBox.Show(ag + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                    }
                }

            });
            threadAG.Start();


            threadAG1 = new Thread(() =>
            {
                using (SqlConnection con = new SqlConnection(sqlConnect))
                {
                    string sql = "use ADDJ_AnGiang; " +
                    "select top(178456) METADATA from meta order by METADATA asc";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr[0].ToString().Trim().Length > 0 && dr[0] != null && !dr[0].ToString().Trim().Equals(""))
                            {
                                string tieuDe = "", trichYeu = "", kyHieu = "";

                                JsonDocument doc = JsonDocument.Parse(dr[0].ToString());
                                JsonElement root = doc.RootElement;
                                for (int i = 0; i < root.GetArrayLength(); i++)
                                {
                                    //đếm số trường
                                    var indexName = root[i].GetProperty("indexName").ToString().Trim();
                                    var indexValue = root[i].GetProperty("indexValue").ToString().Trim();
                                    var indexValue2 = root[i].GetProperty("indexValue2").ToString().Trim();
                                    var indexValueQC = root[i].GetProperty("indexValueQC").ToString().Trim();

                                    if ((indexValue != null && indexValue != "")
                                        || (indexValue2 != null && indexValue2 != "")
                                        || (indexValueQC != null && indexValueQC != ""))
                                    {
                                        ag++;

                                        //lọc bản ghi
                                        if (indexName.ToString().Trim().Equals("TENHOSO"))
                                        {
                                            if (indexValue != null && indexValue != "") tieuDe = indexValue.ToString().Trim();
                                            else if (indexValue2 != null && indexValue2 != "") tieuDe = indexValue2.ToString().Trim();
                                            else tieuDe = indexValueQC.ToString().Trim();
                                        }

                                        if (indexName.ToString().Trim().Equals("SOKYHIEU"))
                                        {
                                            if (indexValue != null && indexValue != "") kyHieu = indexValue.ToString().Trim();
                                            else if (indexValue2 != null && indexValue2 != "") kyHieu = indexValue2.ToString().Trim();
                                            else kyHieu = indexValueQC.ToString().Trim();
                                        }

                                        if (indexName.ToString().Trim().Equals("TRICHYEU"))
                                        {
                                            if (indexValue != null && indexValue != "") trichYeu = indexValue.ToString().Trim();
                                            else if (indexValue2 != null && indexValue2 != "") kyHieu = indexValue2.ToString().Trim();
                                            else tieuDe = indexValueQC.ToString().Trim();
                                        }

                                        if (!tieuDe.Equals("") && !kyHieu.Equals("") && !trichYeu.Equals(""))
                                        {
                                            tieuDe = Utils.format(tieuDe);
                                            kyHieu = Utils.format(kyHieu);
                                            trichYeu = Utils.format(trichYeu);

                                            SqlConnection sqlConnection = new SqlConnection(sqlConnect);
                                            sqlConnection.Open();
                                            string sqlQuery = "use  UBND_tinh_An_Giang; " +
                                            "insert into ThongKe " +
                                            "select TENDONVIPHATHANH, NGAYLAP, HOSOSO, KYHIEU, TRICHYEU, " +
                                            "TOSO, TIEUDE, THOIHANBAOQUAN, THOIGIANBATDAU, vb.NGAYKY, " +
                                            "hs.THOIGIANKETTHUC as 'ThoiGianKetThucHS', vb.GHICHU1 as 'GhiChuVB1', vb.GHICHU2 as 'GhiChuVB2', " +
                                            "hs.GHICHU1 as 'GhiChuHS1', hs.GHICHU2 as 'GhiChuHS2', SOTO, TENLOAIVANBAN, TENPHONG, HOPSO " +
                                            "from VANBAN vb left join DONVIPHATHANH dvph on vb.MADONVIPHATHANH = dvph.MADONVIPHATHANH " +
                                            "left join HOSO hs on vb.MAHOSO = hs.MAHOSO left join LOAIVANBAN lvb on vb.MALOAIVANBAN = lvb.MALOAIVANBAN " +
                                            "left join PHONG p on hs.MAPHONG = p.MAPHONG " +
                                            "where TIEUDE like N'%" + tieuDe.Substring(5, tieuDe.Length - 5) + "%' and KYHIEU like '%" + kyHieu + "%'";
                                            SqlCommand cmd2 = new SqlCommand(sqlQuery, sqlConnection);
                                            cmd2.ExecuteNonQuery();
                                            sqlConnection.Close();
                                            tieuDe = "";
                                            trichYeu = "";
                                            kyHieu = "";
                                        }
                                    }

                                }
                            }
                        }
                        //MessageBox.Show("Có " +ag + " trường thông tin"+ "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                    }
                }

            });
            threadAG1.Start();

            threadAG2 = new Thread(() =>
            {
                using (SqlConnection con = new SqlConnection(sqlConnect))
                {
                    string sql = "use ADDJ_AnGiang; " +
                    "select top(180000) METADATA from meta order by METADATA desc";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr[0].ToString().Trim().Length > 0 && dr[0] != null && !dr[0].ToString().Trim().Equals(""))
                            {
                                string tieuDe = "", trichYeu = "", kyHieu = "";

                                JsonDocument doc = JsonDocument.Parse(dr[0].ToString());
                                JsonElement root = doc.RootElement;
                                for (int i = 0; i < root.GetArrayLength(); i++)
                                {
                                    //đếm số trường
                                    var indexName = root[i].GetProperty("indexName").ToString().Trim();
                                    var indexValue = root[i].GetProperty("indexValue").ToString().Trim();
                                    var indexValue2 = root[i].GetProperty("indexValue2").ToString().Trim();
                                    var indexValueQC = root[i].GetProperty("indexValueQC").ToString().Trim();

                                    if ((indexValue != null && indexValue != "")
                                        || (indexValue2 != null && indexValue2 != "")
                                        || (indexValueQC != null && indexValueQC != ""))
                                    {
                                        ag++;

                                        //lọc bản ghi
                                        if (indexName.ToString().Trim().Equals("TENHOSO"))
                                        {
                                            if (indexValue != null && indexValue != "") tieuDe = indexValue.ToString().Trim();
                                            else if (indexValue2 != null && indexValue2 != "") tieuDe = indexValue2.ToString().Trim();
                                            else tieuDe = indexValueQC.ToString().Trim();
                                        }

                                        if (indexName.ToString().Trim().Equals("SOKYHIEU"))
                                        {
                                            if (indexValue != null && indexValue != "") kyHieu = indexValue.ToString().Trim();
                                            else if (indexValue2 != null && indexValue2 != "") kyHieu = indexValue2.ToString().Trim();
                                            else kyHieu = indexValueQC.ToString().Trim();
                                        }

                                        if (indexName.ToString().Trim().Equals("TRICHYEU"))
                                        {
                                            if (indexValue != null && indexValue != "") trichYeu = indexValue.ToString().Trim();
                                            else if (indexValue2 != null && indexValue2 != "") kyHieu = indexValue2.ToString().Trim();
                                            else tieuDe = indexValueQC.ToString().Trim();
                                        }

                                        if (!tieuDe.Equals("") && !kyHieu.Equals("") && !trichYeu.Equals(""))
                                        {
                                            tieuDe = Utils.format(tieuDe);
                                            kyHieu = Utils.format(kyHieu);
                                            trichYeu = Utils.format(trichYeu);

                                            SqlConnection sqlConnection = new SqlConnection(sqlConnect);
                                            sqlConnection.Open();
                                            string sqlQuery = "use UBND_tinh_An_Giang; " +
                                            "insert into ThongKe " +
                                            "select TENDONVIPHATHANH, NGAYLAP, HOSOSO, KYHIEU, TRICHYEU, " +
                                            "TOSO, TIEUDE, THOIHANBAOQUAN, THOIGIANBATDAU, vb.NGAYKY, " +
                                            "hs.THOIGIANKETTHUC as 'ThoiGianKetThucHS', vb.GHICHU1 as 'GhiChuVB1', vb.GHICHU2 as 'GhiChuVB2', " +
                                            "hs.GHICHU1 as 'GhiChuHS1', hs.GHICHU2 as 'GhiChuHS2', SOTO, TENLOAIVANBAN, TENPHONG, HOPSO " +
                                            "from VANBAN vb left join DONVIPHATHANH dvph on vb.MADONVIPHATHANH = dvph.MADONVIPHATHANH " +
                                            "left join HOSO hs on vb.MAHOSO = hs.MAHOSO left join LOAIVANBAN lvb on vb.MALOAIVANBAN = lvb.MALOAIVANBAN " +
                                            "left join PHONG p on hs.MAPHONG = p.MAPHONG " +
                                            "where TIEUDE like N'%" + tieuDe.Substring(5, tieuDe.Length - 5) + "%' and KYHIEU like '%" + kyHieu + "%'";
                                            SqlCommand cmd2 = new SqlCommand(sqlQuery, sqlConnection);
                                            cmd2.ExecuteNonQuery();
                                            sqlConnection.Close();
                                            tieuDe = "";
                                            trichYeu = "";
                                            kyHieu = "";
                                        }
                                    }

                                }
                            }
                        }
                        MessageBox.Show("Có " + ag + " trường thông tin" + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                    }
                }

            });
            threadAG2.Start();*/
        }

        public HoTich()
        {
            InitializeComponent();
            form1 = this;

            timer.Interval = 60000;
            timer.Start();
        }

        public void ThongKe()
        {
            List<string> loaiHoSo = new List<string> { "HT_KHAISINH", "HT_KHAITU", "HT_KETHON", "HT_NHANCHAMECON" };

            // thread thống kê khai sinh
            threadKS = new Thread(() =>
            {
                using (SqlConnection con = new SqlConnection(sqlConnect))
                {
                    string sql = "SELECT so, quyenSo, trangSo, ngayDangKy, TenLoaiDangKy, " +
                        "TenNoiDangKy, nksHoTen, TenGioiTinh, nksNgaySinh, dt.TenDanToc, qt.TenQuocTich, " +
                        "meHoTen, meNgaySinh, dtm.TenDanToc, qtm.TenQuocTich, lctm.TenLoaiCuTru, chaHoTen, " +
                        "chaNgaySinh, dtc.TenDanToc, qtc.TenQuocTich, lctc.TenLoaiCuTru, GhiChu, nksNoiSinh, " +
                        "meNoiCuTru, chaNoiCuTru, nycHoTen, nycQuanHe, nguoiKy, chucVuNguoiKy, NguoiThucHien, " +
                        "lks.TenLoaiKhaiSinh, nsdvhc.ten, nksQueQuan, lgtnk.TenLoaiGiayTo, nycSoGiayToTuyThan, " +
                        "nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan, nksNgaySinhBangChu FROM HT_KHAISINH " +
                        "ks left join  HT_KS_LOAIDANGKY ldk on ks.loaiDangKy = ldk.MaLoaiDangKy " +
                        "left join  DM_GIOITINH gt on  ks.nksGioiTinh = gt.MaGioiTinh " +
                        "left join  DM_DANTOC dt on ks.nksDanToc = dt.MaDanToc " +
                        "left join  DM_DANTOC dtm on ks.meDanToc = dtm.MaDanToc " +
                        "left join  DM_DANTOC dtc on ks.chaDanToc = dtc.MaDanToc " +
                        "left join  DM_QUOCTICH qt on ks.nksQuocTich = qt.MaQuocTich " +
                        "left join  DM_QUOCTICH qtm on ks.meQuocTich = qtm.MaQuocTich " +
                        "left join  DM_QUOCTICH qtc on ks.chaQuocTich = qtc.MaQuocTich " +
                        "left join  HT_NOIDANGKY ndk on ks.noiDangKy = ndk.MaNoiDangKy " +
                        "left join  DM_LOAICUTRU lctm on ks.meLoaiCuTru = lctm.MaLoaiCuTru " +
                        "left join  DM_LOAICUTRU lctc on ks.chaLoaiCuTru = lctc.MaLoaiCuTru " +
                        "left join  HT_KS_LOAIKHAISINH lks on ks.nksLoaiKhaiSinh = lks.MaLoaiKhaiSinh " +
                        "left join  HT_LOAIGIAYTO lgtnk on ks.nycLoaiGiayToTuyThan = lgtnk.MaLoaiGiayTo " +
                        "left join  HT_Tinh_NoiSinh nsdvhc on ks.nksNoiSinhDVHC = nsdvhc.Ma " +
                        "WHERE quyenSo NOT LIKE '%2016' AND quyenSo NOT LIKE '%2017' AND quyenSo NOT LIKE '%2018' AND quyenSo NOT LIKE '%2019'";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        //duyệt từng bản ghi
                        while (dr.Read())
                        {
                            for (int i = 0; i < sql.Split(new string[] { "FROM" }, StringSplitOptions.None)[0].
                                Split(new string[] { "SELECT" }, StringSplitOptions.None)[1].Trim().Split(',').Length; i++)
                            {
                                //duyệt từng cột
                                if (dr[i].ToString().Trim().Length >= 16)
                                    ksTren16++;
                                else if (dr[i].ToString().Trim().Length > 0 && dr[i] != null && !dr[i].ToString().Trim().Equals(""))
                                    ksDuoi16++;

                            }
                        }
                        MessageBox.Show("Sẵn sàng thống kê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                    }
                }

            });

            //thread thống kê khai tử
            threadKT = new Thread(() =>
            {
                using (SqlConnection con = new SqlConnection(sqlConnect))
                {
                    string sql = "SELECT So, quyenSo, trangSo, ngayDangKy, TenLoaiDangKy, TenNoiDangKy, nktHoTen,  TenGioiTinh, " +
                        "nktNgaySinh, dt.TenDanToc, qt.TenQuocTich, TenLoaiCuTru, lgt.TenLoaiGiayTo,  nktSoGiayToTuyThan, " +
                        "nktNgayChet, GhiChu, nktGioPhutChet, nktNoiChet, nktNguyenNhanChet,  nktNoiCuTru, nycHoTen, nycQuanHe, " +
                        "nguoiKy, chucVuNguoiKy, nguoiThucHien,  nktNgayCapGiayToTuyThan, nktNoiCapGiayToTuyThan, gbt.TenLoai, " +
                        "gbtSo, gbtNgay,  gbtCoQuanCap, lgtnk.TenLoaiGiayTo, nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, " +
                        "nycNoiCapGiayToTuyThan FROM HT_KHAITU kt  left join HT_KT_LOAIDANGKY ldk on kt.loaiDangKy = ldk.MaLoaiDangKy " +
                        "left join HT_NOIDANGKY ndk on kt.noiDangKy = ndk.MaNoiDangKy " +
                        "left join DM_GIOITINH gt on kt.nktGioiTinh = gt.MaGioiTinh " +
                        "left join DM_DANTOC dt on kt.nktDanToc = dt.MaDanToc " +
                        "left join DM_QUOCTICH qt on kt.nktQuocTich = qt.MaQuocTich " +
                        "left join DM_LOAICUTRU lct on kt.nktLoaiCuTru = lct.MaLoaiCuTru " +
                        "left join HT_LOAIGIAYTO lgt on kt.nktLoaiGiayToTuyThan = lgt.MaLoaiGiayTo " +
                        "left join HT_KT_LOAI_GIAY_BAO_TU gbt on kt.gbtLoai = gbt.MaLoai " +
                        "left join HT_LOAIGIAYTO lgtnk on kt.nktLoaiGiayToTuyThan = lgtnk.MaLoaiGiayTo " +
                        "WHERE quyenSo NOT LIKE '%2016' AND quyenSo NOT LIKE '%2017' AND quyenSo NOT LIKE '%2018' AND quyenSo NOT LIKE '%2019'";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            for (int i = 0; i < sql.Split(new string[] { "FROM" }, StringSplitOptions.None)[0].
                                Split(new string[] { "SELECT" }, StringSplitOptions.None)[1].Trim().Split(',').Length; i++)
                            {

                                if (dr[i].ToString().Trim().Length >= 16)
                                    ktTren16++;
                                else if (dr[i].ToString().Trim().Length > 0 && dr[i] != null && !dr[i].ToString().Trim().Equals(""))
                                    ktDuoi16++;

                            }
                        }

                        con.Close();
                    }
                }
            });

            //thread thống kê kết hôn
            threadKH = new Thread(() =>
            {
                using (SqlConnection con = new SqlConnection(sqlConnect))
                {
                    string sql = "SELECT So, quyenSo, trangSo, ngayDangKy, TenLoaiDangKy, TenNoiDangKy, chongHoTen,  " +
                        "chongNgaySinh, dtc.TenDanToc, qtc.TenQuocTich, lctc.TenLoaiCuTru, lgtc.TenLoaiGiayTo, " +
                        " chongSoGiayToTuyThan, voHoTen, voNgaySinh, dtv.TenDanToc, qtv.TenQuocTich, lctv.TenLoaiCuTru,  " +
                        "lgtv.TenLoaiGiayTo, voSoGiayToTuyThan, GhiChu, chongNoiCuTru, voNoiCuTru, nguoiKy,  chucVuNguoiKy, " +
                        "nguoiThucHien, chongNgayCapGiayToTuyThan, chongNoiCapGiayToTuyThan,  voNgayCapGiayToTuyThan, voNoiCapGiayToTuyThan " +
                        "FROM HT_KETHON kh left join HT_KH_LOAIDANGKY ldk on kh.loaiDangKy = ldk.MaLoaiDangKy " +
                        "left join HT_NOIDANGKY ndk on kh.noiDangKy = ndk.MaNoiDangKy " +
                        "left join DM_DANTOC dtc on kh.chongDanToc = dtc.MaDanToc " +
                        "left join DM_QUOCTICH qtc on kh.chongQuocTich = qtc.MaQuocTich " +
                        "left join DM_LOAICUTRU lctc on kh.chongLoaiCuTru = lctc.MaLoaiCuTru " +
                        "left join HT_LOAIGIAYTO lgtc on kh.chongLoaiGiayToTuyThan = lgtc.MaLoaiGiayTo " +
                        "left join DM_DANTOC dtv on kh.voDanToc = dtv.MaDanToc " +
                        "left join DM_QUOCTICH qtv on kh.voQuocTich = qtv.MaQuocTich " +
                        "left join DM_LOAICUTRU lctv on kh.voLoaiCuTru = lctv.MaLoaiCuTru " +
                        "left join HT_LOAIGIAYTO lgtv on kh.voLoaiGiayToTuyThan = lgtv.MaLoaiGiayTo " +
                        "WHERE quyenSo NOT LIKE '%2016' AND quyenSo NOT LIKE '%2017' AND quyenSo NOT LIKE '%2018' AND quyenSo NOT LIKE '%2019'";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            for (int i = 0; i < sql.Split(new string[] { "FROM" }, StringSplitOptions.None)[0].
                                Split(new string[] { "SELECT" }, StringSplitOptions.None)[1].Trim().Split(',').Length; i++)
                            {

                                if (dr[i].ToString().Trim().Length >= 16)
                                    khTren16++;
                                else if (dr[i].ToString().Trim().Length > 0 && dr[i] != null && !dr[i].ToString().Trim().Equals(""))
                                    khDuoi16++;

                            }
                        }

                        con.Close();
                    }
                }
            });

            //thread thống kê cha mẹ con
            threadCMC = new Thread(() =>
            {
                using (SqlConnection con = new SqlConnection(sqlConnect))
                {
                    string sql = "SELECT So, quyenSo, trangSo, quyetDinhSo, ngayDangKy, TenLoaiDangKy, " +
                        "TenLoaiXacNhan,  TenNoiDangKy, cmHoTen, cmNgaySinh, dtcm.TenDanToc, qtcm.TenQuocTich, " +
                        "lctcm.TenLoaiCuTru, lgtcm.TenLoaiGiayTo,  cmSoGiayToTuyThan, ncHoTen, ncNgaySinh, " +
                        "dtnc.TenDanToc, qtnc.TenQuocTich, lctnc.TenLoaiCuTru, lgtnc.TenLoaiGiayTo,  " +
                        "ncSoGiayToTuyThan, GhiChu, cmNoiCuTru, ncNoiCuTru, nycHoTen, nycQHNguoiDuocNhan,  " +
                        "nguoiKy, chucVuNguoiKy, nguoiThucHien, cmQueQuan, cmNgayCapGiayToTuyThan,  " +
                        "cmNoiCapGiayToTuyThan, ncQueQuan, ncNgayCapGiayToTuyThan, ncNoiCapGiayToTuyThan,  " +
                        "lgtnk.TenLoaiGiayTo, nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan " +
                        "FROM HT_NHANCHAMECON cmc left join HT_NCM_LOAIDANGKY ldk on cmc.loaiDangKy = ldk.MaLoaiDangKy " +
                        "left join DM_LOAIXACNHAN lxn on cmc.loaiXacNhan = lxn.MaLoaiXacNhan " +
                        "left join HT_NOIDANGKY ndk on cmc.noiDangKy = ndk.MaNoiDangKy " +
                        "left join DM_DANTOC dtcm on cmc.cmDanToc = dtcm.MaDanToc " +
                        "left join DM_QUOCTICH qtcm on cmc.cmQuocTich = qtcm.MaQuocTich " +
                        "left join DM_LOAICUTRU lctcm on cmc.cmLoaiCuTru = lctcm.MaLoaiCuTru " +
                        "left join HT_LOAIGIAYTO lgtcm on cmc.cmLoaiGiayToTuyThan = lgtcm.MaLoaiGiayTo " +
                        "left join DM_DANTOC dtnc on cmc.ncDanToc = dtnc.MaDanToc " +
                        "left join DM_QUOCTICH qtnc on cmc.ncQuocTich = qtnc.MaQuocTich " +
                        "left join DM_LOAICUTRU lctnc on cmc.ncLoaiCuTru = lctnc.MaLoaiCuTru " +
                        "left join HT_LOAIGIAYTO lgtnc on cmc.ncLoaiGiayToTuyThan = lgtnc.MaLoaiGiayTo " +
                        "left join HT_LOAIGIAYTO lgtnk on cmc.nycLoaiGiayToTuyThan = lgtnk.MaLoaiGiayTo " +
                        "WHERE quyenSo NOT LIKE '%2016' AND quyenSo NOT LIKE '%2017' AND quyenSo NOT LIKE '%2018' AND quyenSo NOT LIKE '%2019'";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            for (int i = 0; i < sql.Split(new string[] { "FROM" }, StringSplitOptions.None)[0].
                                Split(new string[] { "SELECT" }, StringSplitOptions.None)[1].Trim().Split(',').Length; i++)
                            {

                                if (dr[i].ToString().Trim().Length >= 16)
                                    cmcTren16++;
                                else if (dr[i].ToString().Trim().Length > 0 && dr[i] != null && !dr[i].ToString().Trim().Equals(""))
                                    cmcDuoi16++;

                            }
                        }
                        con.Close();
                    }
                }
            });
        }

        //thực hiện thêm bản ghi có trạng thái mới vào db
        private void insertXuLyKS(string id)
        {
            using (SqlConnection con = new SqlConnection(sqlConnect))
            {
                string sql = "SET IDENTITY_INSERT QTXLKS ON;" +
                    "insert into QTXLKS(ID, so, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, " +
                    "nksHoTen, nksGioiTinh, nksNgaySinh, nksDanToc, nksQuocTich, meHoTen, " +
                    "meNgaySinh, meDanToc, meQuocTich, meLoaiCuTru, chaHoTen, chaNgaySinh, " +
                    "chaDanToc, chaQuocTich, chaLoaiCuTru, TinhTrangID, TenFile, TenFileSauUpLoad, " +
                    "URLTapTinDinhKem, NamMoSo, DuLieuCu, NgayCapNhat, LoaiGiay, URLAnhCu, GhiChu, " +
                    "nksNoiSinh, meNoiCuTru, chaNoiCuTru, nycHoTen, nycQuanHe, nguoiKy, chucVuNguoiKy, " +
                    "NguoiThucHien, nksLoaiKhaiSinh, nksNoiSinhDVHC, nksQueQuan, nycLoaiGiayToTuyThan, " +
                    "nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan, nksNgaySinhBangChu)" +
                    " SELECT ID, so, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, " +
                    "nksHoTen, nksGioiTinh, nksNgaySinh, nksDanToc, nksQuocTich, meHoTen, " +
                    "meNgaySinh, meDanToc, meQuocTich, meLoaiCuTru, chaHoTen, chaNgaySinh, " +
                    "chaDanToc, chaQuocTich, chaLoaiCuTru, TinhTrangID, TenFile, TenFileSauUpLoad, " +
                    "URLTapTinDinhKem, NamMoSo, DuLieuCu, NgayCapNhat, LoaiGiay, URLAnhCu, GhiChu, " +
                    "nksNoiSinh, meNoiCuTru, chaNoiCuTru, nycHoTen, nycQuanHe, nguoiKy, chucVuNguoiKy, " +
                    "NguoiThucHien, nksLoaiKhaiSinh, nksNoiSinhDVHC, nksQueQuan, nycLoaiGiayToTuyThan, " +
                    "nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan, nksNgaySinhBangChu" +
                    " FROM HT_KHAISINH" +
                    " where id = @id;" +
                    " SET IDENTITY_INSERT QTXLKS OFF; ";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        private void insertXuLyKT(string id)
        {
            using (SqlConnection con = new SqlConnection(sqlConnect))
            {
                string sql = "SET IDENTITY_INSERT QTXLKT ON;" +
                    "insert into QTXLKT(ID, So, quyenSo, trangSo, ngayDangKy, loaiDangKy, " +
                    "noiDangKy, nktHoTen, nktGioiTinh, nktNgaySinh, nktDanToc, nktQuocTich, " +
                    "nktLoaiCuTru, nktLoaiGiayToTuyThan, nktSoGiayToTuyThan, nktNgayChet, " +
                    "TinhTrangID, TenFile, TenFileSauUpload, URLTapTinDinhKem, NamMoSo, " +
                    "LoaiGiay, DuLieuCu, NgayCapNhat, urlAnhCu, GhiChu, nktGioPhutChet, " +
                    "nktNoiChet, nktNguyenNhanChet, nktNoiCuTru, nycHoTen, nycQuanHe, " +
                    "nguoiKy, chucVuNguoiKy, nguoiThucHien, nktNgayCapGiayToTuyThan, " +
                    "nktNoiCapGiayToTuyThan, gbtLoai, gbtSo, gbtNgay, gbtCoQuanCap, " +
                    "nycLoaiGiayToTuyThan, nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan)" +
                    " SELECT ID, So, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, " +
                    "nktHoTen, nktGioiTinh, nktNgaySinh, nktDanToc, nktQuocTich, nktLoaiCuTru, " +
                    "nktLoaiGiayToTuyThan, nktSoGiayToTuyThan, nktNgayChet, TinhTrangID, TenFile, " +
                    "TenFileSauUpload, URLTapTinDinhKem, NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, " +
                    "urlAnhCu, GhiChu, nktGioPhutChet, nktNoiChet, nktNguyenNhanChet, nktNoiCuTru, " +
                    "nycHoTen, nycQuanHe, nguoiKy, chucVuNguoiKy, nguoiThucHien, nktNgayCapGiayToTuyThan, " +
                    "nktNoiCapGiayToTuyThan, gbtLoai, gbtSo, gbtNgay, gbtCoQuanCap, nycLoaiGiayToTuyThan, " +
                    "nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan" +
                    " FROM HT_KHAITU" +
                    " where id = " + id + ";" +
                    " SET IDENTITY_INSERT QTXLKT OFF; ";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        private void insertXuLyKH(string id)
        {
            using (SqlConnection con = new SqlConnection(sqlConnect))
            {
                string sql = "SET IDENTITY_INSERT QTXLKH ON;" +
                    "insert into QTXLKH(ID, So, quyenSo, trangSo, ngayDangKy, loaiDangKy, " +
                    "noiDangKy, chongHoTen, chongNgaySinh, chongDanToc, chongQuocTich, " +
                    "chongLoaiCuTru, chongLoaiGiayToTuyThan, chongSoGiayToTuyThan, voHoTen, " +
                    "voNgaySinh, voDanToc, voQuocTich, voLoaiCuTru, voLoaiGiayToTuyThan, " +
                    "voSoGiayToTuyThan, TinhTrangID, TenFile, TenFileSauUpLoad, URLTapTinDinhKem, " +
                    "NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, urlAnhCu, GhiChu, chongNoiCuTru, " +
                    "voNoiCuTru, nguoiKy, chucVuNguoiKy, nguoiThucHien, chongNgayCapGiayToTuyThan, " +
                    "chongNoiCapGiayToTuyThan, voNgayCapGiayToTuyThan, voNoiCapGiayToTuyThan)" +
                    " SELECT ID, So, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, chongHoTen, " +
                    "chongNgaySinh, chongDanToc, chongQuocTich, chongLoaiCuTru, chongLoaiGiayToTuyThan, " +
                    "chongSoGiayToTuyThan, voHoTen, voNgaySinh, voDanToc, voQuocTich, voLoaiCuTru, " +
                    "voLoaiGiayToTuyThan, voSoGiayToTuyThan, TinhTrangID, TenFile, TenFileSauUpLoad, " +
                    "URLTapTinDinhKem, NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, urlAnhCu, GhiChu, " +
                    "chongNoiCuTru, voNoiCuTru, nguoiKy, chucVuNguoiKy, nguoiThucHien, chongNgayCapGiayToTuyThan, " +
                    "chongNoiCapGiayToTuyThan, voNgayCapGiayToTuyThan, voNoiCapGiayToTuyThan" +
                    " FROM HT_KETHON" +
                    " where id = " + id + ";" +
                    " SET IDENTITY_INSERT QTXLKH OFF; ";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        private void insertXuLyCMC(string id)
        {
            using (SqlConnection con = new SqlConnection(sqlConnect))
            {
                string sql = "SET IDENTITY_INSERT QTXLCMC ON;" +
                    "insert into QTXLCMC(ID, So, quyenSo, trangSo, quyetDinhSo, ngayDangKy, " +
                    "loaiDangKy, loaiXacNhan, noiDangKy, cmHoTen, cmNgaySinh, cmDanToc, " +
                    "cmQuocTich, cmLoaiCuTru, cmLoaiGiayToTuyThan, cmSoGiayToTuyThan, ncHoTen, " +
                    "ncNgaySinh, ncDanToc, ncQuocTich, ncLoaiCuTru, ncLoaiGiayToTuyThan, " +
                    "ncSoGiayToTuyThan, TinhTrangID, TenFile, TenFileSauUpload, URLTapTinDinhKem, " +
                    "NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, GhiChu, cmNoiCuTru, ncNoiCuTru, " +
                    "nycHoTen, nycQHNguoiDuocNhan, nguoiKy, chucVuNguoiKy, nguoiThucHien, " +
                    "cmQueQuan, cmNgayCapGiayToTuyThan, cmNoiCapGiayToTuyThan, ncQueQuan, " +
                    "ncNgayCapGiayToTuyThan, ncNoiCapGiayToTuyThan, nycLoaiGiayToTuyThan, " +
                    "nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan)" +
                    " SELECT ID, So, quyenSo, trangSo, quyetDinhSo, ngayDangKy, loaiDangKy, " +
                    "loaiXacNhan, noiDangKy, cmHoTen, cmNgaySinh, cmDanToc, cmQuocTich, cmLoaiCuTru, " +
                    "cmLoaiGiayToTuyThan, cmSoGiayToTuyThan, ncHoTen, ncNgaySinh, ncDanToc, ncQuocTich, " +
                    "ncLoaiCuTru, ncLoaiGiayToTuyThan, ncSoGiayToTuyThan, TinhTrangID, TenFile, " +
                    "TenFileSauUpload, URLTapTinDinhKem, NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, " +
                    "GhiChu, cmNoiCuTru, ncNoiCuTru, nycHoTen, nycQHNguoiDuocNhan, nguoiKy, chucVuNguoiKy, " +
                    "nguoiThucHien, cmQueQuan, cmNgayCapGiayToTuyThan, cmNoiCapGiayToTuyThan, ncQueQuan, " +
                    "ncNgayCapGiayToTuyThan, ncNoiCapGiayToTuyThan, nycLoaiGiayToTuyThan, nycSoGiayToTuyThan, " +
                    "nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan" +
                    " FROM HT_NHANCHAMECON" +
                    " where id = " + id + ";" +
                    " SET IDENTITY_INSERT QTXLCMC OFF; ";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        private void UpdateID7()
        {
            //thread update trạng thái 7
            threadUpdateKS7 = new Thread(() =>
            {
                SqlConnection con = new SqlConnection(HoTich.sqlConnect);
                string strCmd = "SELECT id FROM QTXLKS where TinhTrangID = 7";
                List<string> listID7 = new List<string>();
                HT_KHAISINH root = new HT_KHAISINH(), qtxl = new HT_KHAISINH();

                using (SqlCommand command = new SqlCommand(strCmd, con))
                {
                    command.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader d = command.ExecuteReader();

                    //duyệt từng bản ghi gán vào 2 2 đối tượng r so sánh
                    while (d.Read())
                    {
                        listID7.Add(d[0].ToString());
                    }
                    con.Close();
                }

                foreach (string str in listID7)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT ID, so, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, " +
                    "nksHoTen, nksGioiTinh, nksNgaySinh, nksDanToc, nksQuocTich, meHoTen, " +
                    "meNgaySinh, meDanToc, meQuocTich, meLoaiCuTru, chaHoTen, chaNgaySinh, " +
                    "chaDanToc, chaQuocTich, chaLoaiCuTru, TinhTrangID, TenFile, TenFileSauUpLoad, " +
                    "URLTapTinDinhKem, NamMoSo, DuLieuCu, NgayCapNhat, LoaiGiay, URLAnhCu, GhiChu, " +
                    "nksNoiSinh, meNoiCuTru, chaNoiCuTru, nycHoTen, nycQuanHe, nguoiKy, chucVuNguoiKy, " +
                    "NguoiThucHien, nksLoaiKhaiSinh, nksNoiSinhDVHC, nksQueQuan, nycLoaiGiayToTuyThan, " +
                    "nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan, nksNgaySinhBangChu FROM QTXLKS WHERE ID = " + str, con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader dr = cmd.ExecuteReader();
                        //duyệt từng bản ghi
                        while (dr.Read())
                        {
                            Type type = (new HT_KHAISINH()).GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            int i = 0;
                            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                            {
                                qtxl.GetType().GetProperty(property.Name).SetValue(qtxl, dr[i].ToString().Trim(), null);
                                i++;
                            }
                        }
                        con.Close();
                    }

                    using (SqlCommand cmd = new SqlCommand("SELECT ID, so, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, " +
                    "nksHoTen, nksGioiTinh, nksNgaySinh, nksDanToc, nksQuocTich, meHoTen, " +
                    "meNgaySinh, meDanToc, meQuocTich, meLoaiCuTru, chaHoTen, chaNgaySinh, " +
                    "chaDanToc, chaQuocTich, chaLoaiCuTru, TinhTrangID, TenFile, TenFileSauUpLoad, " +
                    "URLTapTinDinhKem, NamMoSo, DuLieuCu, NgayCapNhat, LoaiGiay, URLAnhCu, GhiChu, " +
                    "nksNoiSinh, meNoiCuTru, chaNoiCuTru, nycHoTen, nycQuanHe, nguoiKy, chucVuNguoiKy, " +
                    "NguoiThucHien, nksLoaiKhaiSinh, nksNoiSinhDVHC, nksQueQuan, nycLoaiGiayToTuyThan, " +
                    "nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan, nksNgaySinhBangChu FROM HT_KHAISINH WHERE ID = " + str, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        //duyệt từng bản ghi
                        while (dr.Read())
                        {
                            Type type = (new HT_KHAISINH()).GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            int i = 0;
                            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                            {
                                root.GetType().GetProperty(property.Name).SetValue(root, dr[i].ToString().Trim(), null);
                                i++;
                            }
                        }
                        con.Close();
                    }

                    //so sánh 2 đối tượng
                    Type t = (new HT_KHAISINH()).GetType();
                    foreach (System.Reflection.PropertyInfo property in t.GetProperties())
                    {
                        //nếu khác nhau thì cập nhật lại qtxl
                        if (root.GetType().GetProperty(property.Name).GetValue(root, null) != null
                            && (qtxl.GetType().GetProperty(property.Name).GetValue(qtxl, null) != null))
                        {
                            if (!root.GetType().GetProperty(property.Name).GetValue(root, null).Equals(qtxl.GetType().GetProperty(property.Name).GetValue(qtxl, null)))
                            {
                                string strCo = "delete QTXLKS where TinhTrangID  = 7  and ID = " + str;
                                using (SqlCommand cmd = new SqlCommand(strCo, con))
                                {
                                    cmd.CommandType = CommandType.Text;
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                            }
                        }
                    }
                }
            });

            //thread update trạng thái 7
            threadUpdateKT7 = new Thread(() =>
            {
                SqlConnection con = new SqlConnection(HoTich.sqlConnect);
                string strCmd = "SELECT id FROM QTXLKT where TinhTrangID = 7";
                List<string> listID7 = new List<string>();
                HT_KHAITU root = new HT_KHAITU(), qtxl = new HT_KHAITU();

                using (SqlCommand command = new SqlCommand(strCmd, con))
                {
                    command.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader d = command.ExecuteReader();

                    //duyệt từng bản ghi gán vào 2 2 đối tượng r so sánh
                    while (d.Read())
                    {
                        listID7.Add(d[0].ToString());
                    }
                    con.Close();
                }

                foreach (string str in listID7)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT ID, So, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, " +
                    "nktHoTen, nktGioiTinh, nktNgaySinh, nktDanToc, nktQuocTich, nktLoaiCuTru, " +
                    "nktLoaiGiayToTuyThan, nktSoGiayToTuyThan, nktNgayChet, TinhTrangID, TenFile, " +
                    "TenFileSauUpload, URLTapTinDinhKem, NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, " +
                    "urlAnhCu, GhiChu, nktGioPhutChet, nktNoiChet, nktNguyenNhanChet, nktNoiCuTru, " +
                    "nycHoTen, nycQuanHe, nguoiKy, chucVuNguoiKy, nguoiThucHien, nktNgayCapGiayToTuyThan, " +
                    "nktNoiCapGiayToTuyThan, gbtLoai, gbtSo, gbtNgay, gbtCoQuanCap, nycLoaiGiayToTuyThan, " +
                    "nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan FROM QTXLKT WHERE ID = " + str, con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader dr = cmd.ExecuteReader();
                        //duyệt từng bản ghi
                        while (dr.Read())
                        {
                            Type type = (new HT_KHAITU()).GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            int i = 0;
                            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                            {
                                qtxl.GetType().GetProperty(property.Name).SetValue(qtxl, dr[i].ToString().Trim(), null);
                                i++;
                            }
                        }
                        con.Close();
                    }

                    using (SqlCommand cmd = new SqlCommand("SELECT ID, So, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, " +
                    "nktHoTen, nktGioiTinh, nktNgaySinh, nktDanToc, nktQuocTich, nktLoaiCuTru, " +
                    "nktLoaiGiayToTuyThan, nktSoGiayToTuyThan, nktNgayChet, TinhTrangID, TenFile, " +
                    "TenFileSauUpload, URLTapTinDinhKem, NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, " +
                    "urlAnhCu, GhiChu, nktGioPhutChet, nktNoiChet, nktNguyenNhanChet, nktNoiCuTru, " +
                    "nycHoTen, nycQuanHe, nguoiKy, chucVuNguoiKy, nguoiThucHien, nktNgayCapGiayToTuyThan, " +
                    "nktNoiCapGiayToTuyThan, gbtLoai, gbtSo, gbtNgay, gbtCoQuanCap, nycLoaiGiayToTuyThan, " +
                    "nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan FROM HT_KHAITU WHERE ID = " + str, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        //duyệt từng bản ghi
                        while (dr.Read())
                        {
                            Type type = (new HT_KHAITU()).GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            int i = 0;
                            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                            {
                                root.GetType().GetProperty(property.Name).SetValue(root, dr[i].ToString().Trim(), null);
                                i++;
                            }
                        }
                        con.Close();
                    }

                    //so sánh 2 đối tượng
                    Type t = (new HT_KHAITU()).GetType();
                    foreach (System.Reflection.PropertyInfo property in t.GetProperties())
                    {
                        //nếu khác nhau thì cập nhật lại qtxl
                        if (root.GetType().GetProperty(property.Name).GetValue(root, null) != null
                            && (qtxl.GetType().GetProperty(property.Name).GetValue(qtxl, null) != null))
                        {
                            if (!root.GetType().GetProperty(property.Name).GetValue(root, null).Equals(qtxl.GetType().GetProperty(property.Name).GetValue(qtxl, null)))
                            {
                                string strCo = " delete QTXLKT where TinhTrangID  = 7  and ID = " + str;
                                using (SqlCommand cmd = new SqlCommand(strCo, con))
                                {
                                    cmd.CommandType = CommandType.Text;
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                            }
                        }
                    }
                }
            });

            //thread update trạng thái 7
            threadUpdateKH7 = new Thread(() =>
            {
                SqlConnection con = new SqlConnection(HoTich.sqlConnect);
                string strCmd = "SELECT id FROM QTXLKH where TinhTrangID = 7";
                List<string> listID7 = new List<string>();
                HT_KETHON root = new HT_KETHON(), qtxl = new HT_KETHON();

                using (SqlCommand command = new SqlCommand(strCmd, con))
                {
                    command.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader d = command.ExecuteReader();

                    //duyệt từng bản ghi gán vào 2 2 đối tượng r so sánh
                    while (d.Read())
                    {
                        listID7.Add(d[0].ToString());
                    }
                    con.Close();
                }

                foreach (string str in listID7)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT ID, So, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, chongHoTen, " +
                    "chongNgaySinh, chongDanToc, chongQuocTich, chongLoaiCuTru, chongLoaiGiayToTuyThan, " +
                    "chongSoGiayToTuyThan, voHoTen, voNgaySinh, voDanToc, voQuocTich, voLoaiCuTru, " +
                    "voLoaiGiayToTuyThan, voSoGiayToTuyThan, TinhTrangID, TenFile, TenFileSauUpLoad, " +
                    "URLTapTinDinhKem, NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, urlAnhCu, GhiChu, " +
                    "chongNoiCuTru, voNoiCuTru, nguoiKy, chucVuNguoiKy, nguoiThucHien, chongNgayCapGiayToTuyThan, " +
                    "chongNoiCapGiayToTuyThan, voNgayCapGiayToTuyThan, voNoiCapGiayToTuyThan FROM QTXLKH WHERE ID = " + str, con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader dr = cmd.ExecuteReader();
                        //duyệt từng bản ghi
                        while (dr.Read())
                        {
                            Type type = (new HT_KETHON()).GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            int i = 0;
                            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                            {
                                qtxl.GetType().GetProperty(property.Name).SetValue(qtxl, dr[i].ToString().Trim(), null);
                                i++;
                            }
                        }
                        con.Close();
                    }

                    using (SqlCommand cmd = new SqlCommand("SELECT ID, So, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, chongHoTen, " +
                    "chongNgaySinh, chongDanToc, chongQuocTich, chongLoaiCuTru, chongLoaiGiayToTuyThan, " +
                    "chongSoGiayToTuyThan, voHoTen, voNgaySinh, voDanToc, voQuocTich, voLoaiCuTru, " +
                    "voLoaiGiayToTuyThan, voSoGiayToTuyThan, TinhTrangID, TenFile, TenFileSauUpLoad, " +
                    "URLTapTinDinhKem, NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, urlAnhCu, GhiChu, " +
                    "chongNoiCuTru, voNoiCuTru, nguoiKy, chucVuNguoiKy, nguoiThucHien, chongNgayCapGiayToTuyThan, " +
                    "chongNoiCapGiayToTuyThan, voNgayCapGiayToTuyThan, voNoiCapGiayToTuyThan FROM HT_KETHON WHERE ID = " + str, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        //duyệt từng bản ghi
                        while (dr.Read())
                        {
                            Type type = (new HT_KETHON()).GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            int i = 0;
                            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                            {
                                root.GetType().GetProperty(property.Name).SetValue(root, dr[i].ToString().Trim(), null);
                                i++;
                            }
                        }
                        con.Close();
                    }

                    //so sánh 2 đối tượng
                    Type t = (new HT_KETHON()).GetType();
                    foreach (System.Reflection.PropertyInfo property in t.GetProperties())
                    {
                        //nếu khác nhau thì cập nhật lại qtxl
                        if (root.GetType().GetProperty(property.Name).GetValue(root, null) != null
                                && (qtxl.GetType().GetProperty(property.Name).GetValue(qtxl, null) != null))
                        {
                            if (!root.GetType().GetProperty(property.Name).GetValue(root, null).Equals(qtxl.GetType().GetProperty(property.Name).GetValue(qtxl, null)))
                            {
                                string strCo = "delete QTXLKH where TinhTrangID  = 7  and ID = " + str;
                                using (SqlCommand cmd = new SqlCommand(strCo, con))
                                {
                                    cmd.CommandType = CommandType.Text;
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                            }
                        }
                    }
                }
            });

            //thread update trạng thái 7
            threadUpdateCMC7 = new Thread(() =>
            {
                SqlConnection con = new SqlConnection(HoTich.sqlConnect);
                string strCmd = "SELECT id FROM QTXLCMC where TinhTrangID = 7";
                List<string> listID7 = new List<string>();
                HT_NHANCHAMECON root = new HT_NHANCHAMECON(), qtxl = new HT_NHANCHAMECON();

                using (SqlCommand command = new SqlCommand(strCmd, con))
                {
                    command.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader d = command.ExecuteReader();

                    //duyệt từng bản ghi gán vào 2 2 đối tượng r so sánh
                    while (d.Read())
                    {
                        listID7.Add(d[0].ToString());
                    }
                    con.Close();
                }

                foreach (string str in listID7)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT ID, So, quyenSo, trangSo, quyetDinhSo, ngayDangKy, loaiDangKy, " +
                    "loaiXacNhan, noiDangKy, cmHoTen, cmNgaySinh, cmDanToc, cmQuocTich, cmLoaiCuTru, " +
                    "cmLoaiGiayToTuyThan, cmSoGiayToTuyThan, ncHoTen, ncNgaySinh, ncDanToc, ncQuocTich, " +
                    "ncLoaiCuTru, ncLoaiGiayToTuyThan, ncSoGiayToTuyThan, TinhTrangID, TenFile, " +
                    "TenFileSauUpload, URLTapTinDinhKem, NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, " +
                    "GhiChu, cmNoiCuTru, ncNoiCuTru, nycHoTen, nycQHNguoiDuocNhan, nguoiKy, chucVuNguoiKy, " +
                    "nguoiThucHien, cmQueQuan, cmNgayCapGiayToTuyThan, cmNoiCapGiayToTuyThan, ncQueQuan, " +
                    "ncNgayCapGiayToTuyThan, ncNoiCapGiayToTuyThan, nycLoaiGiayToTuyThan, nycSoGiayToTuyThan, " +
                    "nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan FROM QTXLCMC WHERE ID = " + str, con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader dr = cmd.ExecuteReader();
                        //duyệt từng bản ghi
                        while (dr.Read())
                        {
                            Type type = (new HT_NHANCHAMECON()).GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            int i = 0;
                            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                            {
                                qtxl.GetType().GetProperty(property.Name).SetValue(qtxl, dr[i].ToString().Trim(), null);
                                i++;
                            }
                        }
                        con.Close();
                    }

                    using (SqlCommand cmd = new SqlCommand("SELECT ID, So, quyenSo, trangSo, quyetDinhSo, ngayDangKy, loaiDangKy, " +
                    "loaiXacNhan, noiDangKy, cmHoTen, cmNgaySinh, cmDanToc, cmQuocTich, cmLoaiCuTru, " +
                    "cmLoaiGiayToTuyThan, cmSoGiayToTuyThan, ncHoTen, ncNgaySinh, ncDanToc, ncQuocTich, " +
                    "ncLoaiCuTru, ncLoaiGiayToTuyThan, ncSoGiayToTuyThan, TinhTrangID, TenFile, " +
                    "TenFileSauUpload, URLTapTinDinhKem, NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, " +
                    "GhiChu, cmNoiCuTru, ncNoiCuTru, nycHoTen, nycQHNguoiDuocNhan, nguoiKy, chucVuNguoiKy, " +
                    "nguoiThucHien, cmQueQuan, cmNgayCapGiayToTuyThan, cmNoiCapGiayToTuyThan, ncQueQuan, " +
                    "ncNgayCapGiayToTuyThan, ncNoiCapGiayToTuyThan, nycLoaiGiayToTuyThan, nycSoGiayToTuyThan, " +
                    "nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan FROM HT_NHANCHAMECON WHERE ID = " + str, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        //duyệt từng bản ghi
                        while (dr.Read())
                        {
                            Type type = (new HT_NHANCHAMECON()).GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            int i = 0;
                            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                            {
                                root.GetType().GetProperty(property.Name).SetValue(root, dr[i].ToString().Trim(), null);
                                i++;
                            }
                        }
                        con.Close();
                    }

                    //so sánh 2 đối tượng
                    Type t = (new HT_NHANCHAMECON()).GetType();
                    foreach (System.Reflection.PropertyInfo property in t.GetProperties())
                    {
                        //nếu khác nhau thì cập nhật lại qtxl
                        if (root.GetType().GetProperty(property.Name).GetValue(root, null) != null
                            && (qtxl.GetType().GetProperty(property.Name).GetValue(qtxl, null) != null))
                        {
                            if (!root.GetType().GetProperty(property.Name).GetValue(root, null).Equals(qtxl.GetType().GetProperty(property.Name).GetValue(qtxl, null)))
                            {
                                string strCo = "delete QTXLCMC where TinhTrangID  = 7  and ID = " + str;
                                using (SqlCommand cmd = new SqlCommand(strCo, con))
                                {
                                    cmd.CommandType = CommandType.Text;
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                            }
                        }
                    }
                }
            });
        }

        private void QuaTrinhXuLy()
        {
            threadXuLyKS = new Thread(() =>
            {
                using (SqlConnection sqlConnection = new SqlConnection(sqlConnect))
                {
                    sqlConnection.Open();

                    listXuLyKS = new List<XuLy>();

                    listKS = new List<XuLy>();

                    //thêm phần tử vào list xử lý (bảng QTXLKS lưu tất cả các trạng thái)
                    SqlCommand command = new SqlCommand("SELECT ID, TinhTrangID FROM QTXLKS", sqlConnection)
                    {
                        CommandType = CommandType.Text
                    };
                    SqlDataReader dr1 = command.ExecuteReader();
                    while (dr1.Read())
                    {
                        listXuLyKS.Add(new XuLy(dr1[0].ToString().Trim(), dr1[1].ToString().Trim()));
                    }
                    dr1.Close();
                    dr1.Dispose();

                    //thêm phẩn tử vào list KS (bảng KS lưu bản ghi)
                    SqlCommand command2 = new SqlCommand("SELECT ID, TinhTrangID FROM HT_KHAISINH", sqlConnection)
                    {
                        CommandType = CommandType.Text
                    };
                    SqlDataReader dr2 = command2.ExecuteReader();
                    while (dr2.Read())
                    {
                        listKS.Add(new XuLy(dr2[0].ToString().Trim(), dr2[1].ToString().Trim()));
                    }
                    dr2.Close();
                    dr2.Dispose();

                    foreach (XuLy xuLy in listKS)
                    {
                        if (!listXuLyKS.Contains(xuLy)) insertXuLyKS(xuLy.Id);
                    }

                    sqlConnection.Close();
                }
            });
            threadXuLyKS.Start();

            threadXuLyKT = new Thread(() =>
            {
                using (SqlConnection sqlConnection = new SqlConnection(sqlConnect))
                {
                    sqlConnection.Open();

                    listXuLyKT = new List<XuLy>();

                    listKT = new List<XuLy>();

                    SqlCommand command = new SqlCommand("SELECT ID, TinhTrangID FROM QTXLKT", sqlConnection)
                    {
                        CommandType = CommandType.Text
                    };
                    SqlDataReader dr1 = command.ExecuteReader();
                    while (dr1.Read())
                    {
                        listXuLyKT.Add(new XuLy(dr1[0].ToString().Trim(), dr1[1].ToString().Trim()));
                    }
                    dr1.Close();
                    dr1.Dispose();

                    SqlCommand command2 = new SqlCommand("SELECT ID, TinhTrangID FROM HT_KHAITU", sqlConnection)
                    {
                        CommandType = CommandType.Text
                    };
                    SqlDataReader dr2 = command2.ExecuteReader();
                    while (dr2.Read())
                    {
                        listKT.Add(new XuLy(dr2[0].ToString().Trim(), dr2[1].ToString().Trim()));
                    }
                    dr2.Close();
                    dr2.Dispose();

                    foreach (XuLy xuLy in listKT)
                    {
                        if (!listXuLyKT.Contains(xuLy)) insertXuLyKT(xuLy.Id);
                    }

                    sqlConnection.Close();
                }

            });
            threadXuLyKT.Start();

            threadXuLyKH = new Thread(() =>
            {
                using (SqlConnection sqlConnection = new SqlConnection(sqlConnect))
                {
                    sqlConnection.Open();

                    listXuLyKH = new List<XuLy>();

                    listKH = new List<XuLy>();

                    SqlCommand command = new SqlCommand("SELECT ID, TinhTrangID FROM QTXLKH", sqlConnection)
                    {
                        CommandType = CommandType.Text
                    };
                    SqlDataReader dr1 = command.ExecuteReader();
                    while (dr1.Read())
                    {
                        listXuLyKH.Add(new XuLy(dr1[0].ToString().Trim(), dr1[1].ToString().Trim()));
                    }
                    dr1.Close();
                    dr1.Dispose();

                    SqlCommand command2 = new SqlCommand("SELECT ID, TinhTrangID FROM HT_KETHON", sqlConnection)
                    {
                        CommandType = CommandType.Text
                    };
                    SqlDataReader dr2 = command2.ExecuteReader();
                    while (dr2.Read())
                    {
                        listKH.Add(new XuLy(dr2[0].ToString().Trim(), dr2[1].ToString().Trim()));
                    }
                    dr2.Close();
                    dr2.Dispose();

                    foreach (XuLy xuLy in listKH)
                    {
                        if (!listXuLyKH.Contains(xuLy)) insertXuLyKH(xuLy.Id);
                    }

                    sqlConnection.Close();
                }

            });
            threadXuLyKH.Start();

            threadXuLyCMC = new Thread(() =>
            {
                using (SqlConnection sqlConnection = new SqlConnection(sqlConnect))
                {
                    sqlConnection.Open();

                    listXuLyCMC = new List<XuLy>();

                    listCMC = new List<XuLy>();

                    SqlCommand command = new SqlCommand("SELECT ID, TinhTrangID FROM QTXLCMC", sqlConnection)
                    {
                        CommandType = CommandType.Text
                    };
                    SqlDataReader dr1 = command.ExecuteReader();
                    while (dr1.Read())
                    {
                        listXuLyCMC.Add(new XuLy(dr1[0].ToString().Trim(), dr1[1].ToString().Trim()));
                    }
                    dr1.Close();
                    dr1.Dispose();

                    SqlCommand command2 = new SqlCommand("SELECT ID, TinhTrangID FROM HT_NHANCHAMECON", sqlConnection)
                    {
                        CommandType = CommandType.Text
                    };
                    SqlDataReader dr2 = command2.ExecuteReader();
                    while (dr2.Read())
                    {
                        listCMC.Add(new XuLy(dr2[0].ToString().Trim(), dr2[1].ToString().Trim()));
                    }
                    dr2.Close();
                    dr2.Dispose();

                    foreach (XuLy xuLy in listCMC)
                    {
                        if (!listXuLyCMC.Contains(xuLy)) insertXuLyCMC(xuLy.Id);
                    }

                    sqlConnection.Close();
                }

            });
            threadXuLyCMC.Start();
        }

        public void updateNgayThang(string cot, string bang)
        {

            using (SqlConnection con = new SqlConnection(sqlConnect))
            {
                string sql = "SELECT " + cot + ", id FROM " + bang;
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    //duyệt từng bản ghi
                    while (dr.Read())
                    {
                        try
                        {
                            string s = dr[0].ToString();
                            // create date time 2019-11-12 22:45:12.004
                            DateTime date = DateTime.Parse(dr[0].ToString());
                            // converting to string format
                            string date_str = date.ToString("dd/MM/yyyy HH:mm:ss");

                            SqlConnection conn = new SqlConnection(sqlConnect);
                            conn.Open();
                            //UPDATE HT_KHAISINH SET ngayDangKy = (select REPLACE((select ngayDangKy from HT_KHAISINH where id = 864395),'.','/')) + ' 00:00:00.000' WHERE ID = 864395
                            SqlCommand cmd2 = new SqlCommand("UPDATE " + bang + " SET " + cot + " = (select REPLACE((select " + cot + " from " + bang + " where id = " + dr[1].ToString() + "),'.','/')) + ' 00:00:00.000' WHERE ID = " + dr[1].ToString(), conn);
                            cmd2.ExecuteNonQuery();
                            conn.Close();
                        }
                        catch (Exception) { }
                    }
                    con.Close();
                }
            }
        }
        private void HoTich_Load(object sender, EventArgs e)
        {
            //hide title in form
            //ControlBox = false;


            cbxLoai.SelectedIndex = 0;
            new Thread(() =>
            {
                Invoke(new Action(() =>
                {
                    SqlConnection sqlConnection = null;
                    try
                    {
                        using (sqlConnection = new SqlConnection(sqlConnect))
                        {
                            sqlConnection.Open();
                            if (sqlConnection.State == ConnectionState.Open)
                            {
                                QuaTrinhXuLy();
                                ThongKe();
                                UpdateID7();
                                xuLy();

                                sqlConnection.Close();
                            }
                            else
                            {
                                ConnectDB connectDB = new ConnectDB();
                                connectDB.Show();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        ConnectDB connectDB = new ConnectDB();
                        connectDB.Show();
                    }
                }));
            }
            ).Start();
        }

        public void FillDgv(string sqlQuery)
        {
            SqlConnection conn = new SqlConnection(sqlConnect);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            datagrid.DataSource = ds.Tables[0];
        }

        private void btnExe_Click(object sender, EventArgs e)
        {
            datagrid.Visible = true;
            try
            {
                if (rdnBM.Checked || rdnKTBM1.Checked || rdnKTBM2.Checked || rdnKetThuc.Checked)
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn cập nhật về trạng thái biên mục không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (rdnOther.Checked) strCommandSql = rtbSQL.Text;
                        datagrid.Visible = true;
                        lbCount.Visible = true;
                        FillDgv(strCommandSql);
                        lbCount.Text = (datagrid.Rows.Count - 1).ToString() + " Rows";
                    }
                    else MessageBox.Show("Đã hủy bỏ thao tác cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //strCommandSql = rtbSQL.Text;
                    if (rdnOther.Checked) strCommandSql = rtbSQL.Text;
                    datagrid.Visible = true;
                    lbCount.Visible = true;
                    FillDgv(strCommandSql);
                    lbCount.Text = (datagrid.Rows.Count - 1).ToString() + " Rows";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HoTich_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon.Visible = false;
            DialogResult dialogResult = MessageBox.Show("Đóng chương trình sẽ dừng tất cả các hoạt động thống kê, bạn có muốn đóng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                //ConnectDB.connect.Show();
                if (threadKS.ThreadState == ThreadState.Running) threadKS.Abort();
                if (threadKT.ThreadState == ThreadState.Running) threadKT.Abort();
                if (threadKH.ThreadState == ThreadState.Running) threadKH.Abort();
                if (threadCMC.ThreadState == ThreadState.Running) threadCMC.Abort();
                if (threadXuLyCMC.ThreadState == ThreadState.Running) threadXuLyCMC.Abort();
                if (threadXuLyKS.ThreadState == ThreadState.Running) threadXuLyKS.Abort();
                if (threadXuLyKT.ThreadState == ThreadState.Running) threadXuLyKT.Abort();
                if (threadXuLyKH.ThreadState == ThreadState.Running) threadXuLyKH.Abort();
                //Application.Exit();
                this.Hide();
                Home home = new Home();
                home.ShowDialog();
            }
            else if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void rdnLoiTrangSo_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLenh();
        }

        private void rdnTrung_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLenh();
        }

        private void rdnId7_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLenh();
        }

        private void rdnFormat_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLenh();
        }

        private void rdnOther_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLenh();
        }

        private void rdnChuanHoa_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdnKS_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLoai();
        }

        private void rdnKT_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLoai();
        }

        private void rdnKH_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLoai();
        }

        private void rdnCMC_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLoai();
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0 && ((Utils.IsNumber(txtYear.Text) && txtYear.Text.Length == 4) || (Utils.IsNumber(txtYear.Text) && txtYear.Text.Length == 0)))
            {
                xuLy();
            }
            else if (tabControl.SelectedIndex == 1)
            {
                if ((txtYear.Text != "" && Utils.IsNumber(txtYear.Text) && txtYear.Text.Length == 4))
                {
                    groupBox1.Enabled = true;
                    groupBox2.Enabled = true;
                    btnExe.Visible = true;
                    rdnKS.Checked = true;
                    rdnLoiTrangSo.Checked = true;
                    rtbSQL.Text = strCommandSql.ToLower();
                    rtbSQL.Visible = true;
                    //lbCount.Visible = true;
                }
                else
                {
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = false;
                    //rtbSQL.Enabled = false;
                    rtbSQL.ReadOnly = true;
                    btnExe.Visible = false;
                    rdnKS.Checked = false;
                    rdnLoiTrangSo.Checked = false;
                    rtbSQL.Text = "";
                    lbCount.Enabled = false;
                }
            }
        }

        private void txtNdk_TextChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0) xuLy();
            else if (tabControl.SelectedIndex == 1)
            {
                if (txtNdk.Text != "")
                {
                    rtbSQL.Visible = true;
                    groupBox1.Enabled = true;
                    groupBox2.Enabled = true;
                    btnExe.Visible = true;
                    rdnKS.Checked = true;
                    rdnLoiTrangSo.Checked = true;
                    rtbSQL.Text = strCommandSql.ToLower(); ;
                    //lbCount.Visible = true;
                }
                else
                {
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = false;
                    rtbSQL.Visible = false;
                    //btnClone.Visible = false;
                    btnExe.Visible = false;
                    rdnKS.Checked = false;
                    rdnLoiTrangSo.Checked = false;
                    rtbSQL.Text = "";
                    datagrid.Visible = false;
                    lbCount.Visible = false;
                }
                xuLyLenh();
            }
        }

        private void txtNdk_DropDown(object sender, EventArgs e)
        {
            conn = new SqlConnection(sqlConnect);
            conn.Open();
            string strCmd = "SELECT * FROM HT_NOIDANGKY WHERE TenNoiDangKy LIKE N'%Quận 10%' ORDER BY TenNoiDangKy";
            SqlCommand cmd = new SqlCommand(strCmd, conn);
            SqlDataAdapter da = new SqlDataAdapter(strCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            conn.Close();
            txtNdk.DisplayMember = "TenNoiDangKy";
            txtNdk.ValueMember = "MaNoiDangKy";
            txtNdk.DataSource = ds.Tables[0];
            //txtNdk.Text = "";
            //txtNdk.SelectedIndex = -1;
        }

        private void xuLyLoai()
        {
            try
            {
                if (rdnKS.Checked)
                {
                    hoten = "NKSHOTEN";
                    table = "HT_KHAISINH";
                    ngaySinh = "OR LEN(NKSNGAYSINH) NOT IN('', 4, 10)  " +
                                    "OR (LEN(MENGAYSINH) NOT IN('', 4, 10) AND CHARINDEX('T', LOWER(MENGAYSINH), 0) = 0)  " +
                                    "OR (LEN(CHANGAYSINH) NOT IN('', 4, 10) AND CHARINDEX('T', LOWER(CHANGAYSINH), 0) = 0) ";
                }
                else if (rdnKT.Checked)
                {
                    hoten = "NKTHOTEN";
                    table = "HT_KHAITU";
                    ngaySinh = "or (len(nktNgaySinh) not in ('',4,10) and CHARINDEX('t',lower(nktNgaySinh),0)=0) " +
                            "or(len(nktNgayChet) not in ('', 4, 10) and CHARINDEX('t', lower(nktNgayChet), 0) = 0)";
                }
                else if (rdnKH.Checked)
                {
                    hoten = "CHONGHOTEN , VOHOTEN";
                    table = "HT_KETHON";
                    ngaySinh = "or (len(chongNgaySinh) not in ('',4,10) and CHARINDEX('t',lower(chongNgaySinh),0)=0) " +
                            "or(len(voNgaySinh) not in ('', 4, 10) and CHARINDEX('t', lower(voNgaySinh), 0) = 0)";
                }
                else
                {
                    hoten = "CMHOTEN";
                    table = "HT_NHANCHAMECON";
                    ngaySinh = "or (len(cmNgaySinh) not in ('',4,10) and CHARINDEX('t',lower(cmNgaySinh),0)=0)" +
                            " or(len(ncNgaySinh) not in ('', 4, 10) and CHARINDEX('t', lower(ncNgaySinh), 0) = 0)";
                }

                rdnLoiTrangSo.Checked = false;
                rdnTrung.Checked = false;
                rdnId7.Checked = false;
                rdnFormat.Checked = false;
                rdnOther.Checked = false;
                rdnLoiTrangSo.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt = (DataTable)datagrid.DataSource;
            if (datagrid.Rows.Count != 0 && datagrid.Rows != null)
            {
                Utils.Export(dt, datagrid, "KIỂM TRA", "KIỂM TRA DỮ LIỆU");
            }
            else MessageBox.Show("Không có dữ liệu để lưu vào excel, vui lòng kiểm tra lại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        //tắt luồng thống kê dữ liệu
        private void tắtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            threadKS.Abort();
            threadKT.Abort();
            threadKH.Abort();
            threadCMC.Abort();
            MessageBox.Show("Thống kê đã dừng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //tắt luồng cập nhật trạng thái kêt thúc
        private void tắtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            threadUpdateKS7.Abort();
            threadUpdateKT7.Abort();
            threadUpdateKH7.Abort();
            threadUpdateCMC7.Abort();
            MessageBox.Show("Cập nhật trạng thái kết thúc đã dừng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //tắt luồng quá trình xử lý
        private void tắtToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            threadXuLyKS.Abort();
            threadXuLyKT.Abort();
            threadXuLyKH.Abort();
            threadXuLyCMC.Abort();
            MessageBox.Show("Quá trình xử lý đã dừng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //khởi động lại luồng thống kê dữ liệu
        private void khởiĐộngLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKe();
            threadKS.Start();
            threadKT.Start();
            threadKH.Start();
            threadCMC.Start();
            MessageBox.Show("Khởi động lại chức năng thống kê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //khởi động lại luồng cập nhật trạng thái kêt thúc
        private void khởiĐộngLạiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UpdateID7();
            threadUpdateKS7.Start();
            threadUpdateKT7.Start();
            threadUpdateKH7.Start();
            threadUpdateCMC7.Start();
            MessageBox.Show("Khởi động lại chức năng cập nhật trạng thái kết thúc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //khởi động lại luồng quá trình xử lý
        private void khởiĐộngLạiToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(HoTich.sqlConnect);
            connection.Open();
            QuaTrinhXuLy();
            connection.Close();
            MessageBox.Show("Khởi động lại chức năng quá trình xử lý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void thôngTinPhiênBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            MessageBox.Show(String.Format("Phiên bản hiện tại là: {0}", version), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void addListDiff<T>(List<Diff> listDiff, T tt7, T tt6, T tt5, string columnName)
        {
            Diff diff = new Diff();
            if (tt7.GetType().GetProperty("ID1").GetValue(tt7, null) != null)
            {
                diff.id = tt7.GetType().GetProperty("ID1").GetValue(tt7, null) + "";
                diff.so = tt7.GetType().GetProperty("So1").GetValue(tt7, null) + "";
                diff.quyenSo = tt7.GetType().GetProperty("QuyenSo").GetValue(tt7, null) + "";
                diff.noiDangKy = tt7.GetType().GetProperty("NoiDangKy").GetValue(tt7, null) + "";
                diff.ngayDangKy = tt7.GetType().GetProperty("NgayDangKy").GetValue(tt7, null) + "";
            }
            else if (tt6.GetType().GetProperty("ID1").GetValue(tt6, null) != null)
            {
                diff.id = tt6.GetType().GetProperty("ID1").GetValue(tt6, null) + "";
                diff.so = tt6.GetType().GetProperty("So1").GetValue(tt6, null) + "";
                diff.quyenSo = tt6.GetType().GetProperty("QuyenSo").GetValue(tt6, null) + "";
                diff.noiDangKy = tt6.GetType().GetProperty("NoiDangKy").GetValue(tt6, null) + "";
                diff.ngayDangKy = tt6.GetType().GetProperty("NgayDangKy").GetValue(tt6, null) + "";
            }
            else
            {
                diff.id = tt5.GetType().GetProperty("ID1").GetValue(tt5, null) + "";
                diff.so = tt5.GetType().GetProperty("So1").GetValue(tt5, null) + "";
                diff.quyenSo = tt5.GetType().GetProperty("QuyenSo").GetValue(tt5, null) + "";
                diff.noiDangKy = tt5.GetType().GetProperty("NoiDangKy").GetValue(tt5, null) + "";
                diff.ngayDangKy = tt5.GetType().GetProperty("NgayDangKy").GetValue(tt5, null) + "";
            }

            diff.tableName = tt7.GetType().Name + "";

            diff.columnName = columnName;
            diff.ktbm1 = tt5.GetType().GetProperty(columnName).GetValue(tt5, null) + "";
            diff.ktbm2 = tt6.GetType().GetProperty(columnName).GetValue(tt6, null) + "";
            diff.kt = tt7.GetType().GetProperty(columnName).GetValue(tt7, null) + "";

            if (tt5.GetType().GetProperty("NgayCapNhat1").GetValue(tt5, null) != null)
                diff.ngayCapNhatKTBM1 = tt5.GetType().GetProperty("NgayCapNhat1").GetValue(tt5, null).ToString();

            if (tt6.GetType().GetProperty("NgayCapNhat1").GetValue(tt6, null) != null)
                diff.ngayCapNhatKTBM2 = tt6.GetType().GetProperty("NgayCapNhat1").GetValue(tt6, null).ToString();

            if (tt7.GetType().GetProperty("NgayCapNhat1").GetValue(tt7, null) != null)
                diff.ngayCapNhatKT = tt7.GetType().GetProperty("NgayCapNhat1").GetValue(tt7, null).ToString();
            listDiff.Add(diff);
        }

        public void xuLy()
        {
            if (tabControl.SelectedIndex == 0)
            {
                dataGrid1.Visible = true;
                dataGrid2.Visible = true;
                dataGrid2.DataSource = null;
                dataGrid2.Refresh();

                SqlConnection conn = new SqlConnection(HoTich.sqlConnect);

                string sqlQuery = "select RIGHT(quyenSo, 4) as N'Năm', noiDangKy as N'Mã nơi đăng ký',  " +
                    "REPLACE(TenNoiDangKy, N', Thành phố Hồ Chí Minh', '') as N'Tên nơi đăng ký', " +
                    "count(*) as N'Số lượng' from " + cbxLoai.Text + " ks join HT_NOIDANGKY ndk on ks.noiDangKy = ndk.MaNoiDangKy " +
                    "where TinhTrangID like '%" + cbxTrangThai.SelectedValue + "%' and quyenSo like '%" +
                    txtYear.Text + "%' and noiDangKy like '%" + txtNdk.SelectedValue + "%' " +
                    "group by RIGHT(quyenSo, 4), TenNoiDangKy, noiDangKy " +
                    "order by RIGHT(quyenSo, 4), TenNoiDangKy";

                Utils.FillDgv(conn, sqlQuery, dataGrid1);
            }

        }

        private void cbxTrangThai_TextChanged(object sender, EventArgs e)
        {
            try
            {
                xuLy();
            }
            catch (Exception)
            {
                MessageBox.Show("Chọn loại tài liệu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbxLoai_TextChanged(object sender, EventArgs e)
        {
            xuLy();
        }

        private void cbxTrangThai_DropDown(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(HoTich.sqlConnect);
            conn.Open();
            string strCmd = "select TinhTrangID, Ten from DC_DMTINHTRANG where TinhTrangID in (1,5,6,7) order by Ten";
            SqlCommand cmd = new SqlCommand(strCmd, conn);
            SqlDataAdapter da = new SqlDataAdapter(strCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            conn.Close();
            cbxTrangThai.DisplayMember = "Ten";
            cbxTrangThai.ValueMember = "TinhTrangID";
            cbxTrangThai.DataSource = ds.Tables[0];
        }

        private void dataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGrid2.DataSource = null;
            dataGrid2.Refresh();
            SqlConnection conn = new SqlConnection(HoTich.sqlConnect);

            string sqlQuery = "select quyenSo as N'Quyển số', count(*) as N'Số lượng' from " + cbxLoai.Text +
                " ks join HT_NOIDANGKY ndk on ks.noiDangKy = ndk.MaNoiDangKy " +
                "where TinhTrangID like '%" + cbxTrangThai.SelectedValue + "%' and quyenSo like '%" +
                dataGrid1.Rows[e.RowIndex].Cells[0].Value.ToString() + "%' " +
                "and noiDangKy = '" + dataGrid1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'" +
                "group by quyenSo order by quyenSo";

            Utils.FillDgv(conn, sqlQuery, dataGrid2);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 1)
            {
                if (txtYear.Text != "" && (Utils.IsNumber(txtYear.Text) && txtYear.Text.Length == 4))
                {
                    groupBox1.Enabled = true;
                    groupBox2.Enabled = true;
                    btnExe.Visible = true;
                    rdnKS.Checked = true;
                    rdnLoiTrangSo.Checked = true;
                    rtbSQL.Visible = true;
                }
                else
                {
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = false;
                    btnExe.Visible = false;
                    rdnKS.Checked = false;
                    rdnLoiTrangSo.Checked = false;
                    rtbSQL.Text = "";
                    rtbSQL.Visible = false;
                    lbCount.Visible = false;
                }
            }
        }

        private void btnTKTBG_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (cbxLoai.Text.Equals("HT_KHAISINH"))
            {
                //Khai sinh
                sql = "SELECT top(1) so, quyenSo, trangSo, LEFT(ngayDangKy, 10), TenLoaiDangKy, " +
                    "TenNoiDangKy, nksHoTen, TenGioiTinh, LEFT(nksNgaySinh, 10), dt.TenDanToc, qt.TenQuocTich, " +
                    "meHoTen, LEFT(meNgaySinh, 10), dtm.TenDanToc, qtm.TenQuocTich, lctm.TenLoaiCuTru, chaHoTen, " +
                    "LEFT(chaNgaySinh, 10), dtc.TenDanToc, qtc.TenQuocTich, lctc.TenLoaiCuTru, GhiChu, nksNoiSinh, " +
                    "meNoiCuTru, chaNoiCuTru, nycHoTen, nycQuanHe, nguoiKy, chucVuNguoiKy, NguoiThucHien, " +
                    "lks.TenLoaiKhaiSinh, nsdvhc.ten, nksQueQuan, lgtnk.TenLoaiGiayTo, nycSoGiayToTuyThan, " +
                    "LEFT(nycNgayCapGiayToTuyThan, 10), nycNoiCapGiayToTuyThan, nksNgaySinhBangChu FROM HT_KHAISINH " +
                    "ks left join  HT_KS_LOAIDANGKY ldk on ks.loaiDangKy = ldk.MaLoaiDangKy " +
                    "left join  DM_GIOITINH gt on  ks.nksGioiTinh = gt.MaGioiTinh " +
                    "left join  DM_DANTOC dt on ks.nksDanToc = dt.MaDanToc " +
                    "left join  DM_DANTOC dtm on ks.meDanToc = dtm.MaDanToc " +
                    "left join  DM_DANTOC dtc on ks.chaDanToc = dtc.MaDanToc " +
                    "left join  DM_QUOCTICH qt on ks.nksQuocTich = qt.MaQuocTich " +
                    "left join  DM_QUOCTICH qtm on ks.meQuocTich = qtm.MaQuocTich " +
                    "left join  DM_QUOCTICH qtc on ks.chaQuocTich = qtc.MaQuocTich " +
                    "left join  HT_NOIDANGKY ndk on ks.noiDangKy = ndk.MaNoiDangKy " +
                    "left join  DM_LOAICUTRU lctm on ks.meLoaiCuTru = lctm.MaLoaiCuTru " +
                    "left join  DM_LOAICUTRU lctc on ks.chaLoaiCuTru = lctc.MaLoaiCuTru " +
                    "left join  HT_KS_LOAIKHAISINH lks on ks.nksLoaiKhaiSinh = lks.MaLoaiKhaiSinh " +
                    "left join  HT_LOAIGIAYTO lgtnk on ks.nycLoaiGiayToTuyThan = lgtnk.MaLoaiGiayTo " +
                    "left join  HT_Tinh_NoiSinh nsdvhc on ks.nksNoiSinhDVHC = nsdvhc.Ma ";
                //"WHERE meNgaySinh NOT LIKE N'%TUỔI%' AND chaNgaySinh NOT LIKE N'%TUỔI%' AND TinhTrangID like '%" + cbxTrangThai.SelectedValue + "%' and quyenSo like '%" + txtYear.Text + "%' and noiDangKy like '%" + txtNdk.SelectedValue + "%' " +
                //" and quyenSo NOT LIKE '%2016' AND quyenSo NOT LIKE '%2017' AND quyenSo NOT LIKE '%2018' AND quyenSo NOT LIKE '%2019' ORDER BY quyenSo, so, TenNoiDangKy";
            }
            else if (cbxLoai.Text.Equals("HT_KHAITU"))
            {
                //khai tử
                sql = "SELECT  top(1)  So, quyenSo, trangSo, LEFT(ngayDangKy, 10), TenLoaiDangKy, TenNoiDangKy, nktHoTen,  TenGioiTinh, " +
                        "LEFT(nktNgaySinh, 10), dt.TenDanToc, qt.TenQuocTich, TenLoaiCuTru, lgt.TenLoaiGiayTo,  nktSoGiayToTuyThan, " +
                        "LEFT(nktNgayChet, 10), GhiChu, nktGioPhutChet, nktNoiChet, nktNguyenNhanChet,  nktNoiCuTru, nycHoTen, nycQuanHe, " +
                        "nguoiKy, chucVuNguoiKy, nguoiThucHien,  LEFT(nktNgayCapGiayToTuyThan, 10), nktNoiCapGiayToTuyThan, gbt.TenLoai, " +
                        "gbtSo, LEFT(gbtNgay, 10),  gbtCoQuanCap, lgtnk.TenLoaiGiayTo, nycSoGiayToTuyThan, LEFT(nycNgayCapGiayToTuyThan, 10), " +
                        "nycNoiCapGiayToTuyThan FROM HT_KHAITU kt  left join HT_KT_LOAIDANGKY ldk on kt.loaiDangKy = ldk.MaLoaiDangKy " +
                        "left join HT_NOIDANGKY ndk on kt.noiDangKy = ndk.MaNoiDangKy " +
                        "left join DM_GIOITINH gt on kt.nktGioiTinh = gt.MaGioiTinh " +
                        "left join DM_DANTOC dt on kt.nktDanToc = dt.MaDanToc " +
                        "left join DM_QUOCTICH qt on kt.nktQuocTich = qt.MaQuocTich " +
                        "left join DM_LOAICUTRU lct on kt.nktLoaiCuTru = lct.MaLoaiCuTru " +
                        "left join HT_LOAIGIAYTO lgt on kt.nktLoaiGiayToTuyThan = lgt.MaLoaiGiayTo " +
                        "left join HT_KT_LOAI_GIAY_BAO_TU gbt on kt.gbtLoai = gbt.MaLoai " +
                        "left join HT_LOAIGIAYTO lgtnk on kt.nktLoaiGiayToTuyThan = lgtnk.MaLoaiGiayTo " +
                        "WHERE nktNgaySinh NOT LIKE N'%TUỔI%' AND TinhTrangID like '%" + cbxTrangThai.SelectedValue + "%' and quyenSo like '%" + txtYear.Text + "%' and noiDangKy like '%" + txtNdk.SelectedValue + "%'" +
                        " and quyenSo NOT LIKE '%2016' AND quyenSo NOT LIKE '%2017' AND quyenSo NOT LIKE '%2018' AND quyenSo NOT LIKE '%2019' ORDER BY quyenSo, so, TenNoiDangKy";
            }
            else if (cbxLoai.Text.Equals("HT_KETHON"))
            {
                //kết hôn
                sql = "SELECT  top(1)  So, quyenSo, trangSo, LEFT(ngayDangKy, 10), TenLoaiDangKy, TenNoiDangKy, chongHoTen,  " +
                        "LEFT(chongNgaySinh, 10), dtc.TenDanToc, qtc.TenQuocTich, lctc.TenLoaiCuTru, lgtc.TenLoaiGiayTo, " +
                        " chongSoGiayToTuyThan, voHoTen, LEFT(voNgaySinh, 10), dtv.TenDanToc, qtv.TenQuocTich, lctv.TenLoaiCuTru,  " +
                        "lgtv.TenLoaiGiayTo, voSoGiayToTuyThan, GhiChu, chongNoiCuTru, voNoiCuTru, nguoiKy,  chucVuNguoiKy, " +
                        "nguoiThucHien, LEFT(chongNgayCapGiayToTuyThan, 10), chongNoiCapGiayToTuyThan,  LEFT(voNgayCapGiayToTuyThan, 10), voNoiCapGiayToTuyThan " +
                        "FROM HT_KETHON kh left join HT_KH_LOAIDANGKY ldk on kh.loaiDangKy = ldk.MaLoaiDangKy " +
                        "left join HT_NOIDANGKY ndk on kh.noiDangKy = ndk.MaNoiDangKy " +
                        "left join DM_DANTOC dtc on kh.chongDanToc = dtc.MaDanToc " +
                        "left join DM_QUOCTICH qtc on kh.chongQuocTich = qtc.MaQuocTich " +
                        "left join DM_LOAICUTRU lctc on kh.chongLoaiCuTru = lctc.MaLoaiCuTru " +
                        "left join HT_LOAIGIAYTO lgtc on kh.chongLoaiGiayToTuyThan = lgtc.MaLoaiGiayTo " +
                        "left join DM_DANTOC dtv on kh.voDanToc = dtv.MaDanToc " +
                        "left join DM_QUOCTICH qtv on kh.voQuocTich = qtv.MaQuocTich " +
                        "left join DM_LOAICUTRU lctv on kh.voLoaiCuTru = lctv.MaLoaiCuTru " +
                        "left join HT_LOAIGIAYTO lgtv on kh.voLoaiGiayToTuyThan = lgtv.MaLoaiGiayTo " +
                        "WHERE voNgaySinh NOT LIKE N'%TUỔI%' AND chongNgaySinh NOT LIKE N'%TUỔI%' AND TinhTrangID like '%" + cbxTrangThai.SelectedValue + "%' and quyenSo like '%" + txtYear.Text + "%' and noiDangKy like '%" + txtNdk.SelectedValue + "%'" +
                        " and quyenSo NOT LIKE '%2016' AND quyenSo NOT LIKE '%2017' AND quyenSo NOT LIKE '%2018' AND quyenSo NOT LIKE '%2019' ORDER BY quyenSo, so, TenNoiDangKy";
            }
            else
            {
                //cha mẹ con
                sql = "SELECT top(1) So, quyenSo, trangSo, quyetDinhSo, LEFT(ngayDangKy, 10), TenLoaiDangKy, " +
                        "TenLoaiXacNhan,  TenNoiDangKy, cmHoTen, LEFT(cmNgaySinh, 10), dtcm.TenDanToc, qtcm.TenQuocTich, " +
                        "lctcm.TenLoaiCuTru, lgtcm.TenLoaiGiayTo,  cmSoGiayToTuyThan, ncHoTen, LEFT(ncNgaySinh, 10), " +
                        "dtnc.TenDanToc, qtnc.TenQuocTich, lctnc.TenLoaiCuTru, lgtnc.TenLoaiGiayTo,  " +
                        "ncSoGiayToTuyThan, GhiChu, cmNoiCuTru, ncNoiCuTru, nycHoTen, nycQHNguoiDuocNhan,  " +
                        "nguoiKy, chucVuNguoiKy, nguoiThucHien, cmQueQuan, LEFT(cmNgayCapGiayToTuyThan, 10),  " +
                        "cmNoiCapGiayToTuyThan, ncQueQuan, LEFT(ncNgayCapGiayToTuyThan, 10), ncNoiCapGiayToTuyThan,  " +
                        "lgtnk.TenLoaiGiayTo, nycSoGiayToTuyThan, LEFT(nycNgayCapGiayToTuyThan, 10), nycNoiCapGiayToTuyThan " +
                        "FROM HT_NHANCHAMECON cmc left join HT_NCM_LOAIDANGKY ldk on cmc.loaiDangKy = ldk.MaLoaiDangKy " +
                        "left join DM_LOAIXACNHAN lxn on cmc.loaiXacNhan = lxn.MaLoaiXacNhan " +
                        "left join HT_NOIDANGKY ndk on cmc.noiDangKy = ndk.MaNoiDangKy " +
                        "left join DM_DANTOC dtcm on cmc.cmDanToc = dtcm.MaDanToc " +
                        "left join DM_QUOCTICH qtcm on cmc.cmQuocTich = qtcm.MaQuocTich " +
                        "left join DM_LOAICUTRU lctcm on cmc.cmLoaiCuTru = lctcm.MaLoaiCuTru " +
                        "left join HT_LOAIGIAYTO lgtcm on cmc.cmLoaiGiayToTuyThan = lgtcm.MaLoaiGiayTo " +
                        "left join DM_DANTOC dtnc on cmc.ncDanToc = dtnc.MaDanToc " +
                        "left join DM_QUOCTICH qtnc on cmc.ncQuocTich = qtnc.MaQuocTich " +
                        "left join DM_LOAICUTRU lctnc on cmc.ncLoaiCuTru = lctnc.MaLoaiCuTru " +
                        "left join HT_LOAIGIAYTO lgtnc on cmc.ncLoaiGiayToTuyThan = lgtnc.MaLoaiGiayTo " +
                        "left join HT_LOAIGIAYTO lgtnk on cmc.nycLoaiGiayToTuyThan = lgtnk.MaLoaiGiayTo " +
                        "WHERE cmNgaySinh NOT LIKE N'%TUỔI%' AND ncNgaySinh NOT LIKE N'%TUỔI%' AND TinhTrangID like '%" + cbxTrangThai.SelectedValue + "%' and quyenSo like '%" + txtYear.Text + "%' and noiDangKy like '%" + txtNdk.SelectedValue + "%'" +
                        " and quyenSo NOT LIKE '%2016' AND quyenSo NOT LIKE '%2017' AND quyenSo NOT LIKE '%2018' AND quyenSo NOT LIKE '%2019' ORDER BY quyenSo, so, TenNoiDangKy";
            }


            SqlConnection con1 = new SqlConnection(sqlConnect);
            Utils.FillDgv(con1, sql, dataGrid1);
            con1.Close();

            DataTable dt1 = (DataTable)dataGrid1.DataSource;

            // xuất excel file chi tiết các trường
            if (dataGrid1.Rows.Count != 0 && dataGrid1.Rows != null && dataGrid1.Rows.Count <= 11)
            {
                Utils.Export(dt1, dataGrid1, "KIỂM TRA", "KIỂM TRA DỮ LIỆU");
            }
            else MessageBox.Show("Không có dữ liệu để lưu vào excel, vui lòng kiểm tra lại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            // xuất excel thống kê số lượng ký tự trên dưới 16
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn(" ", typeof(string)));
            dt.Columns.Add(new DataColumn("Trên 16 ký tự", typeof(int)));
            dt.Columns.Add(new DataColumn("Dưới 16 ký tự", typeof(int)));

            int tren16 = 0, duoi16 = 0, index = 1;
            for (int j = 0; j < dt1.Columns.Count; j++)
            {
                if (dataGrid1.SelectedCells[j].Value.ToString().Trim().Length > 15)
                    tren16++;
                else
                    duoi16++;
            }
            dt.Rows.Add(index++, tren16, duoi16);

            datagrid.DataSource = dt;

            //XUẤT EXCEL
            if (datagrid.Rows.Count != 0 && datagrid.Rows != null)
            {
                Utils.ExportThongKe(dt, datagrid, "THỐNG KÊ", "THỐNG KÊ SỐ LƯỢNG TRƯỜNG TRÊN VÀ DƯỚI 16 KÝ TỰ");
                tren16 = 0; duoi16 = 0; index = 0;
            }
            else MessageBox.Show("Không có dữ liệu để lưu vào excel, vui lòng kiểm tra lại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void dataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGrid2.DataSource = null;
            dataGrid2.Refresh();
            SqlConnection conn = new SqlConnection(HoTich.sqlConnect);

            string sqlQuery = "select quyenSo as N'Quyển số', count(*) as N'Số lượng' from " + cbxLoai.Text + " ks join HT_NOIDANGKY ndk on ks.noiDangKy = ndk.MaNoiDangKy " +
                "where TinhTrangID like '%" + cbxTrangThai.SelectedValue + "%' and quyenSo like '%" + dataGrid1.Rows[e.RowIndex].Cells[0].Value.ToString() + "%' " +
                "and noiDangKy = '" + dataGrid1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'" +
                "group by quyenSo order by quyenSo";

            Utils.FillDgv(conn, sqlQuery, dataGrid2);
        }

        private void thốngKêToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            QuaTrinhXuLy qtxl = new QuaTrinhXuLy();

            if (!threadUpdateKS7.IsAlive &&
                !threadUpdateKT7.IsAlive &&
                !threadUpdateKH7.IsAlive &&
                !threadUpdateCMC7.IsAlive)
            {
                qtxl.Show();
                this.Hide();
            }
            else MessageBox.Show("Đang cập nhật dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cậpNhậtDanhSáchSoSánhToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HT_KHAISINH kstt7 = new HT_KHAISINH(), kstt6 = new HT_KHAISINH(), kstt5 = new HT_KHAISINH();
            HT_KHAITU kttt7 = new HT_KHAITU(), kttt6 = new HT_KHAITU(), kttt5 = new HT_KHAITU();
            HT_KETHON khtt7 = new HT_KETHON(), khtt6 = new HT_KETHON(), khtt5 = new HT_KETHON();
            HT_NHANCHAMECON cmctt7 = new HT_NHANCHAMECON(), cmctt6 = new HT_NHANCHAMECON(), cmctt5 = new HT_NHANCHAMECON();

            //thread xử lý KS
            Thread threadDiffKS = new Thread(() =>
            {
                xuLyDiff<HT_KHAISINH>(kstt7, kstt6, kstt5, "QTXLKS");
            });

            //thread xử lý KT
            Thread threadDiffKT = new Thread(() =>
            {
                xuLyDiff<HT_KHAITU>(kttt7, kttt6, kttt5, "QTXLKT");
            });

            //thread xử lý KH
            Thread threadDiffKH = new Thread(() =>
            {
                xuLyDiff<HT_KETHON>(khtt7, khtt6, khtt5, "QTXLKH");
            });

            //thread xử lý CMC
            Thread threadDiffCMC = new Thread(() =>
            {
                xuLyDiff<HT_NHANCHAMECON>(cmctt7, cmctt6, cmctt5, "QTXLCMC");
            });

            threadDiffKS.Start();
            threadDiffKT.Start();
            threadDiffKH.Start();
            threadDiffCMC.Start();
        }

        private void nhânSựToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            ThongKeNhanSu tk = new ThongKeNhanSu();
            tk.ShowDialog();
        }

        private void cậpNhậtDữLiệuMenuItem_Click(object sender, EventArgs e)
        {
            if (!threadUpdateKS7.IsAlive &&
                !threadUpdateKT7.IsAlive &&
                !threadUpdateKH7.IsAlive &&
                !threadUpdateCMC7.IsAlive)
            {
                UpdateID7();
                threadUpdateKS7.Start();
                threadUpdateKT7.Start();
                threadUpdateKH7.Start();
                threadUpdateCMC7.Start();
            }
            else MessageBox.Show("Đang cập nhật dữ liệu ở trạng thái kết thúc, vui lòng chờ ít phút!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void clonePDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clone form3 = new Clone();
            form3.Show();
            this.Hide();
        }

        private void rdnKTBM2_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLenh();
        }

        //10 phút sẽ cập nhật các trạng thái mới 1 lần
        private void timer_Tick(object sender, EventArgs e)
        {
            if (!threadXuLyKS.IsAlive &&
                        !threadXuLyKT.IsAlive &&
                        !threadXuLyKH.IsAlive &&
                        !threadXuLyCMC.IsAlive)
            {
                using (SqlConnection sqlConnection = new SqlConnection(HoTich.sqlConnect))
                {
                    sqlConnection.Open();
                    if (sqlConnection.State == ConnectionState.Open)
                    {
                        QuaTrinhXuLy();

                        sqlConnection.Close();
                    }
                }
            }
        }

        private void HoTich_SizeChanged(object sender, EventArgs e)
        {
            bool MousePointerNotOnTaskBar = Screen.GetWorkingArea(this).Contains(Cursor.Position);

            if (this.WindowState == FormWindowState.Minimized && MousePointerNotOnTaskBar)
            {
                this.ShowInTaskbar = false;
                notifyIcon.Visible = true;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            if (this.WindowState == FormWindowState.Normal)
                this.ShowInTaskbar = true;
            notifyIcon.Visible = false;
            this.Show();
        }

        private void txtYear_KeyDown(object sender, KeyEventArgs e)
        {
            //SendKeys.Send("{A}");
            //SendKeys.SendWait("{A}");

            if (e.Control && e.KeyCode == Keys.S)
            {
                dt = (DataTable)datagrid.DataSource;
                if (datagrid.Rows.Count != 0 && datagrid.Rows != null)
                {
                    Utils.Export(dt, datagrid, "SHEET 1", "CAPTION");
                }
                else MessageBox.Show("Không có dữ liệu để lưu vào excel, vui lòng kiểm tra lại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtNdk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                dt = (DataTable)datagrid.DataSource;
                if (datagrid.Rows.Count != 0 && datagrid.Rows != null)
                {
                    Utils.Export(dt, datagrid, "SHEET 1", "CAPTION");
                }
                else MessageBox.Show("Không có dữ liệu để lưu vào excel, vui lòng kiểm tra lại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tổngHợpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //datagrid.Visible = true;
            if (threadCMC.ThreadState == ThreadState.Running ||
                threadKS.ThreadState == ThreadState.Running ||
                threadKT.ThreadState == ThreadState.Running ||
                threadKH.ThreadState == ThreadState.Running)
            {
                MessageBox.Show("Đang chạy, xin vui lòng chờ trong giây lát!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else

            if (threadCMC.ThreadState == ThreadState.Stopped &&
                threadKS.ThreadState == ThreadState.Stopped &&
                threadKT.ThreadState == ThreadState.Stopped &&
                threadKH.ThreadState == ThreadState.Stopped)
            {

                ThongKe();

                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn(" ", typeof(string)));
                dt.Columns.Add(new DataColumn("Khai sinh", typeof(int)));
                dt.Columns.Add(new DataColumn("Khai tử", typeof(int)));
                dt.Columns.Add(new DataColumn("Kết hôn", typeof(int)));
                dt.Columns.Add(new DataColumn("Cha mẹ con", typeof(int)));
                dt.Columns.Add(new DataColumn("Tổng", typeof(int)));

                //Thêm dữ liệu
                dt.Rows.Add("Dưới 16 ký tự", ksDuoi16, ktDuoi16, khDuoi16, cmcDuoi16, ksDuoi16 + ktDuoi16 + khDuoi16 + cmcDuoi16);
                dt.Rows.Add("Trên 16 ký tự", ksTren16, ktTren16, khTren16, cmcTren16, ksTren16 + ktTren16 + khTren16 + cmcTren16);
                dt.Rows.Add("Tổng số trường", ksTren16 + ksDuoi16, ktDuoi16 + ktTren16, khTren16 + khDuoi16, cmcDuoi16 + cmcTren16,
                    ksDuoi16 + ktDuoi16 + khDuoi16 + cmcDuoi16 + ksTren16 + ktTren16 + khTren16 + cmcTren16);

                conn = new SqlConnection(sqlConnect);
                conn.Open();

                //thêm số bản ghi trước 2016
                dt.Rows.Add("Số bản ghi trước 2016", new SqlCommand("SELECT COUNT(*) FROM HT_KHAISINH where quyenSo NOT LIKE '%2016' AND quyenSo NOT LIKE '%2017' AND quyenSo NOT LIKE '%2018' AND quyenSo NOT LIKE '%2019'", conn).ExecuteScalar(),
                    new SqlCommand("SELECT COUNT(*) FROM HT_KHAITU where quyenSo NOT LIKE '%2016' AND quyenSo NOT LIKE '%2017' AND quyenSo NOT LIKE '%2018' AND quyenSo NOT LIKE '%2019'", conn).ExecuteScalar(),
                    new SqlCommand("SELECT COUNT(*) FROM HT_KETHON where quyenSo NOT LIKE '%2016' AND quyenSo NOT LIKE '%2017' AND quyenSo NOT LIKE '%2018' AND quyenSo NOT LIKE '%2019'", conn).ExecuteScalar(),
                    new SqlCommand("SELECT COUNT(*) FROM HT_NHANCHAMECON where quyenSo NOT LIKE '%2016' AND quyenSo NOT LIKE '%2017' AND quyenSo NOT LIKE '%2018' AND quyenSo NOT LIKE '%2019'", conn).ExecuteScalar(),
                    (Convert.ToInt32(new SqlCommand("SELECT COUNT(*) FROM HT_KHAISINH where quyenSo NOT LIKE '%2016' AND quyenSo NOT LIKE '%2017' AND quyenSo NOT LIKE '%2018' AND quyenSo NOT LIKE '%2019'", conn).ExecuteScalar()) +
                        Convert.ToInt32(new SqlCommand("SELECT COUNT(*) FROM HT_KHAITU where quyenSo NOT LIKE '%2016' AND quyenSo NOT LIKE '%2017' AND quyenSo NOT LIKE '%2018' AND quyenSo NOT LIKE '%2019'", conn).ExecuteScalar()) +
                        Convert.ToInt32(new SqlCommand("SELECT COUNT(*) FROM HT_KETHON where quyenSo NOT LIKE '%2016' AND quyenSo NOT LIKE '%2017' AND quyenSo NOT LIKE '%2018' AND quyenSo NOT LIKE '%2019'", conn).ExecuteScalar()) +
                        Convert.ToInt32(new SqlCommand("SELECT COUNT(*) FROM HT_NHANCHAMECON where quyenSo NOT LIKE '%2016' AND quyenSo NOT LIKE '%2017' AND quyenSo NOT LIKE '%2018' AND quyenSo NOT LIKE '%2019'", conn).ExecuteScalar())));

                //thêm số bản ghi sau 2016
                dt.Rows.Add("Số bản ghi sau 2016", new SqlCommand("SELECT COUNT(*) FROM HT_KHAISINH where quyenSo LIKE '%2016' or quyenSo LIKE '%2017' or quyenSo LIKE '%2018' or quyenSo LIKE '%2019'", conn).ExecuteScalar(),
                    new SqlCommand("SELECT COUNT(*) FROM HT_KHAITU where quyenSo LIKE '%2016' or quyenSo LIKE '%2017' or quyenSo LIKE '%2018' or quyenSo LIKE '%2019'", conn).ExecuteScalar(),
                    new SqlCommand("SELECT COUNT(*) FROM HT_KETHON where quyenSo LIKE '%2016' or quyenSo LIKE '%2017' or quyenSo LIKE '%2018' or quyenSo LIKE '%2019'", conn).ExecuteScalar(),
                    new SqlCommand("SELECT COUNT(*) FROM HT_NHANCHAMECON where quyenSo LIKE '%2016' or quyenSo LIKE '%2017' or quyenSo LIKE '%2018' or quyenSo LIKE '%2019'", conn).ExecuteScalar(),
                    (Convert.ToInt32(new SqlCommand("SELECT COUNT(*) FROM HT_KHAISINH where quyenSo LIKE '%2016' or quyenSo LIKE '%2017' or quyenSo LIKE '%2018' or quyenSo LIKE '%2019'", conn).ExecuteScalar()) +
                        Convert.ToInt32(new SqlCommand("SELECT COUNT(*) FROM HT_KHAITU where quyenSo LIKE '%2016' or quyenSo LIKE '%2017' or quyenSo LIKE '%2018' or quyenSo LIKE '%2019'", conn).ExecuteScalar()) +
                        Convert.ToInt32(new SqlCommand("SELECT COUNT(*) FROM HT_KETHON where quyenSo LIKE '%2016' or quyenSo LIKE '%2017' or quyenSo LIKE '%2018' or quyenSo LIKE '%2019'", conn).ExecuteScalar()) +
                        Convert.ToInt32(new SqlCommand("SELECT COUNT(*) FROM HT_NHANCHAMECON where quyenSo LIKE '%2016' or quyenSo LIKE '%2017' or quyenSo LIKE '%2018' or quyenSo LIKE '%2019'", conn).ExecuteScalar())));

                conn.Close();
                datagrid.DataSource = dt;

                //XUẤT EXCEL
                if (datagrid.Rows.Count != 0 && datagrid.Rows != null)
                {
                    Utils.ExportThongKe(dt, datagrid, "THỐNG KÊ", "THỐNG KÊ DỮ LIỆU HỘ TỊCH");
                    ksDuoi16 = 0; ksTren16 = 0; ktDuoi16 = 0; ktTren16 = 0; khDuoi16 = 0; khTren16 = 0; cmcDuoi16 = 0; cmcTren16 = 0;
                }
                else MessageBox.Show("Không có dữ liệu để lưu vào excel, vui lòng kiểm tra lại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                ThongKe();
                threadKS.Start();
                threadKT.Start();
                threadKH.Start();
                threadCMC.Start();
                MessageBox.Show("Đang chạy, xin vui lòng chờ trong giây lát!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void rdnQuyenSo_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLenh();
        }

        private void rdnTKQuyenSo_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLenh();
        }

        private void rdnDelete_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLenh();
        }

        private void sốBảnGhiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mess = "";
            conn = new SqlConnection(sqlConnect);
            conn.Open();
            mess = mess + "Khai sinh: " + new SqlCommand("SELECT COUNT(*) FROM HT_KHAISINH", conn).ExecuteScalar().ToString() + "\n";
            mess = mess + "Khai Tử: " + new SqlCommand("SELECT COUNT(*) FROM HT_KHAITU", conn).ExecuteScalar().ToString() + "\n";
            mess = mess + "Kết hôn: " + new SqlCommand("SELECT COUNT(*) FROM HT_KETHON", conn).ExecuteScalar().ToString() + "\n";
            mess = mess + "Nhận cha mẹ con: " + new SqlCommand("SELECT COUNT(*) FROM HT_NHANCHAMECON", conn).ExecuteScalar().ToString() + "\n";
            mess = mess + "Tổng: " + (Convert.ToInt32(new SqlCommand("SELECT COUNT(*) FROM HT_KHAISINH", conn).ExecuteScalar()) +
                Convert.ToInt32(new SqlCommand("SELECT COUNT(*) FROM HT_KHAITU", conn).ExecuteScalar()) +
                Convert.ToInt32(new SqlCommand("SELECT COUNT(*) FROM HT_KETHON", conn).ExecuteScalar()) +
                Convert.ToInt32(new SqlCommand("SELECT COUNT(*) FROM HT_NHANCHAMECON", conn).ExecuteScalar())).ToString() + "\n";
            conn.Close();
            MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void xuLyLenh()
        {
            if (tabControl.SelectedIndex == 1)
            {
                if (rdnLoiTrangSo.Checked)
                {
                    strCommandSql = "SELECT SO, QUYENSO, TENNOIDANGKY, " + hoten + ", TRANGSO, TINHTRANGID, TENFILESAUUPLOAD " + "\n" + "FROM " + table +
                        " KT JOIN HT_NOIDANGKY NDK ON KT.NOIDANGKY = NDK.MANOIDANGKY " + "\n" + "WHERE ISNUMERIC(TRANGSO) != 1 " +
                        "AND TRANGSO IS NOT NULL AND TRANGSO !='' AND QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'";

                }
                else if (rdnTrung.Checked)
                {
                    strCommandSql = "SELECT SO , QUYENSO, TENNOIDANGKY, COUNT(*) AS 'SL TRUNG' " + "\n" + "FROM " + table + " KT JOIN HT_NOIDANGKY NDK ON KT.NOIDANGKY = NDK.MANOIDANGKY \n" +
                        "WHERE(QUYENSO LIKE '%" + txtYear.Text.Trim() + "%') AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%' GROUP BY TENNOIDANGKY,QUYENSO,SO HAVING COUNT(*) >= 2 ORDER BY TENNOIDANGKY, QUYENSO";
                }
                else if (rdnId7.Checked)
                {
                    strCommandSql = "SELECT SO, QUYENSO , TENNOIDANGKY, TRANGSO, " +
                                hoten + ", TINHTRANGID, TENFILESAUUPLOAD\n" +
                                " FROM " + table + " KT JOIN HT_NOIDANGKY NDK ON KT.NOIDANGKY = NDK.MANOIDANGKY \n" +
                                "WHERE QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'" +
                                " AND(TINHTRANGID != 7 OR TINHTRANGID IS NULL) " +
                                "ORDER BY NOIDANGKY, QUYENSO, SO";
                }
                else if (rdnFormat.Checked)
                {
                    strCommandSql = "SELECT SO, QUYENSO, TENNOIDANGKY, " + hoten +
                                " , TENFILESAUUPLOAD\n FROM " + table + " KS JOIN HT_NOIDANGKY NDK ON KS.NOIDANGKY = NDK.MANOIDANGKY \n" +
                                "WHERE(SO = ''  OR  NGAYDANGKY = '' OR CHARINDEX('/', SO, 0) = 0 " +
                                "OR CHARINDEX('/', QUYENSO, 0) = 0  OR CHARINDEX('.', NGAYDANGKY, 0) = 0  " +
                                "OR LEN(NGAYDANGKY) <> 10  " + ngaySinh +
                                "OR RIGHT(SO, 4) <> RIGHT(NGAYDANGKY, 4)   OR (ISNUMERIC(TRANGSO) != 1 AND TRANGSO IS NOT NULL AND TRANGSO !=''))  " +
                                "AND TINHTRANGID IN(7)  AND (QUYENSO LIKE '%" + txtYear.Text.Trim() + "%') " +
                                "AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'" +
                                "ORDER BY NOIDANGKY, QUYENSO; ";
                }
                else if (rdnBM.Checked)
                {
                    strCommandSql = "update " + table + " " +
                        "set TinhTrangID = 1 \n" +
                        "where  (ISNUMERIC(TRANGSO) = 1 or TRANGSO IS NULL or TRANGSO ='') AND " +
                        "QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'; \n" +
                        "update xl set TinhTrangID = 1 \n" +
                        "from HT_KHAISINH ks join HT_XULY xl " +
                        "on ks.ID = xl.ObjectID" +
                        " where (ISNUMERIC(TRANGSO) = 1 or TRANGSO IS NULL or TRANGSO ='') AND " +
                        " QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'; \n" +
                        "select so, quyenSo, " + hoten + ", noiDangKy, TinhTrangID from " + table + " " +
                        "where QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%';  ";
                }
                else if (rdnKTBM1.Checked)
                {
                    strCommandSql = "update " + table + " " +
                        "set TinhTrangID = 5 \n" +
                        "where  (ISNUMERIC(TRANGSO) = 1 or TRANGSO IS NULL or TRANGSO ='') AND " +
                        "QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'; \n" +
                        "update xl set TinhTrangID = 5 \n" +
                        "from HT_KHAISINH ks join HT_XULY xl " +
                        "on ks.ID = xl.ObjectID" +
                        " where  (ISNUMERIC(TRANGSO) = 1 or TRANGSO IS NULL or TRANGSO ='') AND " +
                        "QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'; \n" +
                        "select so, quyenSo, " + hoten + ", noiDangKy, TinhTrangID from " + table + " " +
                        "where QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%';  ";
                }
                else if (rdnKTBM2.Checked)
                {
                    strCommandSql = "update " + table + " " +
                        "set TinhTrangID = 6 \n" +
                        "where  (ISNUMERIC(TRANGSO) = 1 or TRANGSO IS NULL or TRANGSO ='') AND " +
                        "QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'; \n" +
                        "update xl set TinhTrangID = 6 \n" +
                        "from HT_KHAISINH ks join HT_XULY xl " +
                        "on ks.ID = xl.ObjectID" +
                        " where  (ISNUMERIC(TRANGSO) = 1 or TRANGSO IS NULL or TRANGSO ='') AND " +
                        "QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'; \n" +
                        "select so, quyenSo, " + hoten + ", noiDangKy, TinhTrangID from " + table + " " +
                        "where QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%';  ";
                }
                else if (rdnKetThuc.Checked)
                {
                    strCommandSql = "update " + table + " " +
                        "set TinhTrangID = 7 \n" +
                        "where  (ISNUMERIC(TRANGSO) = 1 or TRANGSO IS NULL or TRANGSO ='') AND " +
                        "QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'; \n" +
                        "update xl set TinhTrangID = 7 \n" +
                        "from HT_KHAISINH ks join HT_XULY xl " +
                        "on ks.ID = xl.ObjectID" +
                        " where  (ISNUMERIC(TRANGSO) = 1 or TRANGSO IS NULL or TRANGSO ='') AND " +
                        "QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%'; \n" +
                        "select so, quyenSo, " + hoten + ", noiDangKy, TinhTrangID from " + table + " " +
                        "where QUYENSO LIKE '%" + txtYear.Text.Trim() + "%' AND NOIDANGKY LIKE '%" + txtNdk.SelectedValue + "%';  ";
                }
                else if (rdnTKQuyenSo.Checked)
                {
                    strCommandSql = "select TenNoiDangKy, quyenSo, count(*) as N'Sum'\n" +
                        "from " + table + " kt join HT_NOIDANGKY ndk on kt.noiDangKy = ndk.MaNoiDangKy \n" +
                        "where quyenSo like '%" + txtYear.Text.Trim() + "%' and noiDangKy LIKE '%" + txtNdk.SelectedValue + "%' \n" +
                        "group by TenNoiDangKy, quyenSo \n" +
                        "order by TenNoiDangKy, quyenSo";
                }
                else if (rdnQuyenSo.Checked)
                {
                    strCommandSql = "SELECT SO, QUYENSO, noiDangKy, " + hoten +
                        " , TENFILESAUUPLOAD\n FROM " + table + " " +
                        "\nwhere so is null or so ='' or quyenSo is null or quyenSo = '' or noiDangKy is null or noiDangKy = ''";
                }
                else if (rdnDelete.Checked)
                {
                    strCommandSql = "delete from " + table +
                        " \nwhere quyenSo like '%" + txtYear.Text.Trim() + "%' and noiDangKy LIKE '%" + txtNdk.SelectedValue + "%' \n";
                }
                else if (rdnOther.Checked)
                {
                    rtbSQL.ReadOnly = false;
                }
                if (!rdnOther.Checked) rtbSQL.ReadOnly = true;

                rtbSQL.Text = strCommandSql.ToLower();
            }
        }

        private void rdnBM_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLenh();
        }

        private void rdnKTBM1_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLenh();
        }

        private void rdnKetThuc_CheckedChanged(object sender, EventArgs e)
        {
            xuLyLenh();
        }

        private void lbKS_MouseHover(object sender, EventArgs e)
        {

        }

        private void btnGetSources_Click(object sender, EventArgs e)
        {
            GetSources getSources = new GetSources();
            getSources.getSources();
        }

        private void xuLyDiff<T>(T tt7, T tt6, T tt5, string tableName)
        {
            using (SqlConnection con = new SqlConnection(HoTich.sqlConnect))
            {
                List<string> listDayDu2TrangThai = new List<string>();

                string str = " SELECT DISTINCT ID " +
                    " FROM " + tableName +
                    " where ((id in (select id from "+ tableName +" where TinhTrangID = 7) " +
                    "and id in (select id from " + tableName + " where TinhTrangID = 6)) " +
                    "or (id in (select id from " + tableName + " where TinhTrangID = 7) " +
                    "and id in (select id from " + tableName + " where TinhTrangID = 5)) " +
                    "or (id in (select id from " + tableName + " where TinhTrangID = 5) " +
                    "and id in (select id from " + tableName + " where TinhTrangID = 6)))";

                using (SqlCommand cmd = new SqlCommand(str, con))
                {
                    cmd.CommandType = CommandType.Text;
                    //cmd.Parameters.AddWithValue("@tableName", tableName);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    //duyệt từng bản ghi
                    while (dr.Read())
                    {
                        listDayDu2TrangThai.Add(dr[0].ToString());
                    }
                    con.Close();
                }

                //duyệt từng bản ghi có đủ 3 trạng thái
                foreach (string s in listDayDu2TrangThai)
                {
                    //trạng thái 7
                    string kt = " SELECT * " +
                            " FROM " + tableName + " where id = " + s + " and TinhTrangID = 7";

                    //trạng thái 6
                    string ktbm2 = " SELECT * " +
                            " FROM " + tableName + " where id = " + s + " and TinhTrangID = 6";

                    //trạng thái 5
                    string ktbm1 = " SELECT * " +
                            " FROM " + tableName + " where id = " + s + " and TinhTrangID = 5";

                    setValueObject<T>(kt, con, tt7);
                    setValueObject<T>(ktbm2, con, tt6);
                    setValueObject<T>(ktbm1, con, tt5);

                    //thêm những bản ghi có từ 2 trạng thái trở lên
                    //có 5,6 mà không có 7
                    if (tt7.GetType().GetProperty("ID1").GetValue(tt7, null) == null &&
                        tt6.GetType().GetProperty("ID1").GetValue(tt6, null) != null &&
                        tt5.GetType().GetProperty("ID1").GetValue(tt5, null) != null)
                    {
                        //so sánh 3 trạng thái nếu khác nhau thì so sánh từng cột 1 để lưu vào db
                        if (!tt6.Equals(tt5))
                        {
                            List<Diff> listDiff = new List<Diff>();

                            Type type = tt6.GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                            {
                                if (!tt6.GetType().GetProperty(property.Name).GetValue(tt6, null).ToString().ToUpper().
                                    Equals(tt5.GetType().GetProperty(property.Name).GetValue(tt5, null).ToString().ToUpper()))
                                    if (!property.Name.Equals("TinhTrangID1") && !property.Name.Equals("NgayCapNhat1"))
                                        addListDiff<T>(listDiff, tt7, tt6, tt5, property.Name);
                            }

                            foreach (Diff diff in listDiff)
                            {
                                SqlConnection conn = new SqlConnection(HoTich.sqlConnect);
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("if(select count(*) from Diff " +
                                    "where id = '" + diff.id + "' and so = '" + diff.so + "' and quyenSo = '" + diff.quyenSo +
                                    "' and noiDangKy = '" + diff.noiDangKy + "' " +
                                    "and ngayDangKy = '" + diff.ngayDangKy + "' and tableName = '" +
                                    diff.tableName + "' and columnName = '" + diff.columnName + "' " +
                                    "and ktbm1 = N'" + Utils.QuotationMarks(diff.ktbm1) +
                                    "' and ktbm2 = N'" + Utils.QuotationMarks(diff.ktbm2) + "' and kt = N'" +
                                    Utils.QuotationMarks(diff.kt) + "' and ghiChu = '" + diff.ghiChu + "') = 0 " +
                                    "insert into Diff values('" + diff.id + "', '" + diff.so + "', '" + diff.quyenSo + "'," +
                                    "'" + diff.noiDangKy + "', '" + diff.ngayDangKy + "', '" + diff.tableName + "', '" + diff.columnName +
                                    "', N'" + Utils.QuotationMarks(diff.ktbm1) + "'," +
                                    "N'" + Utils.QuotationMarks(diff.ktbm2) + "',N'" + Utils.QuotationMarks(diff.kt) + "', '5 -> 6', " +
                                    "'" + diff.ngayCapNhatKTBM1 + "', '" + diff.ngayCapNhatKTBM2 + "', '" + diff.ngayCapNhatKT + "')", conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                        }
                    }
                    //có 5, 7 mà không có 6
                    else if (tt7.GetType().GetProperty("ID1").GetValue(tt7, null) != null &&
                        tt6.GetType().GetProperty("ID1").GetValue(tt6, null) == null &&
                        tt5.GetType().GetProperty("ID1").GetValue(tt5, null) != null)
                    {
                        //so sánh 3 trạng thái nếu khác nhau thì so sánh từng cột 1 để lưu vào db
                        if (!tt7.Equals(tt5))
                        {
                            List<Diff> listDiff = new List<Diff>();

                            Type type = tt7.GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                            {
                                if (!tt7.GetType().GetProperty(property.Name).GetValue(tt7, null).ToString().ToUpper().
                                    Equals(tt5.GetType().GetProperty(property.Name).GetValue(tt5, null).ToString().ToUpper()))
                                    if (!property.Name.Equals("TinhTrangID1") && !property.Name.Equals("NgayCapNhat1"))
                                        addListDiff<T>(listDiff, tt7, tt6, tt5, property.Name);
                            }

                            foreach (Diff diff in listDiff)
                            {
                                SqlConnection conn = new SqlConnection(HoTich.sqlConnect);
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("if(select count(*) from Diff " +
                                    "where id = '" + diff.id + "' and so = '" + diff.so + "' and quyenSo = '" + diff.quyenSo + "' and noiDangKy = '" + diff.noiDangKy + "' " +
                                    "and ngayDangKy = '" + diff.ngayDangKy + "' and tableName = '" + diff.tableName + "' and columnName = '" + diff.columnName + "' " +
                                    "and ktbm1 = N'" + Utils.QuotationMarks(diff.ktbm1) +
                                    "' and ktbm2 = N'" + Utils.QuotationMarks(diff.ktbm2) + "' and kt = N'" + Utils.QuotationMarks(diff.kt) + "' and ghiChu = '" + diff.ghiChu + "') = 0 " +
                                    "insert into Diff values('" + diff.id + "', '" + diff.so + "', '" + diff.quyenSo + "'," +
                                    "'" + diff.noiDangKy + "', '" + diff.ngayDangKy + "', '" + diff.tableName + "', '" + diff.columnName + "', N'" + Utils.QuotationMarks(diff.ktbm1) + "'," +
                                    "N'" + Utils.QuotationMarks(diff.ktbm2) + "',N'" + Utils.QuotationMarks(diff.kt) + "', '5 -> 7', " +
                                    "'" + diff.ngayCapNhatKTBM1 + "', '" + diff.ngayCapNhatKTBM2 + "', '" + diff.ngayCapNhatKT + "')", conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                        }
                    }
                    //có 6, 7 mà không có 5
                    else if ((tt7.GetType().GetProperty("ID1").GetValue(tt7, null) != null &&
                        tt6.GetType().GetProperty("ID1").GetValue(tt6, null) != null &&
                        tt5.GetType().GetProperty("ID1").GetValue(tt5, null) == null))
                    {
                        if (!tt7.Equals(tt6))
                        {
                            List<Diff> listDiff = new List<Diff>();

                            Type type = tt7.GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                            {
                                if (!tt7.GetType().GetProperty(property.Name).GetValue(tt7, null).ToString().ToUpper().
                                    Equals(tt6.GetType().GetProperty(property.Name).GetValue(tt6, null).ToString().ToUpper()))
                                    if (!property.Name.Equals("TinhTrangID1") && !property.Name.Equals("NgayCapNhat1"))
                                        addListDiff<T>(listDiff, tt7, tt6, tt5, property.Name);
                            }

                            foreach (Diff diff in listDiff)
                            {
                                SqlConnection conn = new SqlConnection(HoTich.sqlConnect);
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("if(select count(*) from Diff " +
                                    "where id = '" + diff.id + "' and so = '" + diff.so + "' and quyenSo = '" + diff.quyenSo + "' and noiDangKy = '" + diff.noiDangKy + "' " +
                                    "and ngayDangKy = '" + diff.ngayDangKy + "' and tableName = '" + diff.tableName + "' and columnName = '" + diff.columnName + "' " +
                                    "and ktbm1 = N'" + Utils.QuotationMarks(diff.ktbm1) +
                                    "' and ktbm2 = N'" + Utils.QuotationMarks(diff.ktbm2) + "' and kt = N'" + Utils.QuotationMarks(diff.kt) + "' and ghiChu = '" + diff.ghiChu + "') = 0 " +
                                    "insert into Diff values('" + diff.id + "', '" + diff.so + "', '" + diff.quyenSo + "'," +
                                    "'" + diff.noiDangKy + "', '" + diff.ngayDangKy + "', '" + diff.tableName + "', '" + diff.columnName + "', N'" + Utils.QuotationMarks(diff.ktbm1) + "'," +
                                    "N'" + Utils.QuotationMarks(diff.ktbm2) + "',N'" + Utils.QuotationMarks(diff.kt) + "', '6 -> 7', " +
                                    "'" + diff.ngayCapNhatKTBM1 + "', '" + diff.ngayCapNhatKTBM2 + "', '" + diff.ngayCapNhatKT + "')", conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                        }
                    }
                    //có cả 3 5, 6, 7
                    else if ((tt7.GetType().GetProperty("ID1").GetValue(tt7, null) != null &&
                        tt6.GetType().GetProperty("ID1").GetValue(tt6, null) != null &&
                        tt5.GetType().GetProperty("ID1").GetValue(tt5, null) != null))
                    {
                        //5!=6
                        if (!tt5.Equals(tt6))
                        {
                            List<Diff> listDiff = new List<Diff>();

                            Type type = tt7.GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                            {
                                if (!tt5.GetType().GetProperty(property.Name).GetValue(tt5, null).ToString().ToUpper().
                                    Equals(tt6.GetType().GetProperty(property.Name).GetValue(tt6, null).ToString().ToUpper()))
                                    if (!property.Name.Equals("TinhTrangID1") && !property.Name.Equals("NgayCapNhat1"))
                                        addListDiff<T>(listDiff, tt7, tt6, tt5, property.Name);
                            }

                            foreach (Diff diff in listDiff)
                            {
                                SqlConnection conn = new SqlConnection(HoTich.sqlConnect);
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("if(select count(*) from Diff " +
                                    "where id = '" + diff.id + "' and so = '" + diff.so + "' and quyenSo = '" + diff.quyenSo + "' and noiDangKy = '" + diff.noiDangKy + "' " +
                                    "and ngayDangKy = '" + diff.ngayDangKy + "' and tableName = '" + diff.tableName + "' and columnName = '" + diff.columnName + "' " +
                                    "and ktbm1 = N'" + Utils.QuotationMarks(diff.ktbm1) +
                                    "' and ktbm2 = N'" + Utils.QuotationMarks(diff.ktbm2) + "' and kt = N'" + Utils.QuotationMarks(diff.kt) + "' and ghiChu = '" + diff.ghiChu + "') = 0 " +
                                    "insert into Diff values('" + diff.id + "', '" + diff.so + "', '" + diff.quyenSo + "'," +
                                    "'" + diff.noiDangKy + "', '" + diff.ngayDangKy + "', '" + diff.tableName + "', '" + diff.columnName + "', N'" + Utils.QuotationMarks(diff.ktbm1) + "'," +
                                    "N'" + Utils.QuotationMarks(diff.ktbm2) + "',N'" + Utils.QuotationMarks(diff.kt) + "', '5 -> 6', " +
                                    "'" + diff.ngayCapNhatKTBM1 + "', '" + diff.ngayCapNhatKTBM2 + "', '" + diff.ngayCapNhatKT + "')", conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                        }

                        //5!=7
                        if (!tt7.Equals(tt5))
                        {
                            List<Diff> listDiff = new List<Diff>();

                            Type type = tt7.GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                            {
                                if (!tt7.GetType().GetProperty(property.Name).GetValue(tt7, null).ToString().ToUpper().
                                    Equals(tt5.GetType().GetProperty(property.Name).GetValue(tt5, null).ToString().ToUpper()))
                                    if (!property.Name.Equals("TinhTrangID1") && !property.Name.Equals("NgayCapNhat1"))
                                        addListDiff<T>(listDiff, tt7, tt6, tt5, property.Name);
                            }

                            foreach (Diff diff in listDiff)
                            {
                                SqlConnection conn = new SqlConnection(HoTich.sqlConnect);
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("if(select count(*) from Diff " +
                                    "where id = '" + diff.id + "' and so = '" + diff.so + "' and quyenSo = '" + diff.quyenSo + "' and noiDangKy = '" + diff.noiDangKy + "' " +
                                    "and ngayDangKy = '" + diff.ngayDangKy + "' and tableName = '" + diff.tableName + "' and columnName = '" + diff.columnName + "' " +
                                    "and ktbm1 = N'" + Utils.QuotationMarks(diff.ktbm1) +
                                    "' and ktbm2 = N'" + Utils.QuotationMarks(diff.ktbm2) + "' and kt = N'" + Utils.QuotationMarks(diff.kt) + "' and ghiChu = '" + diff.ghiChu + "') = 0 " +
                                    "insert into Diff values('" + diff.id + "', '" + diff.so + "', '" + diff.quyenSo + "'," +
                                    "'" + diff.noiDangKy + "', '" + diff.ngayDangKy + "', '" + diff.tableName + "', '" + diff.columnName + "', N'" + Utils.QuotationMarks(diff.ktbm1) + "'," +
                                    "N'" + Utils.QuotationMarks(diff.ktbm2) + "',N'" + Utils.QuotationMarks(diff.kt) + "', '5 -> 7', " +
                                    "'" + diff.ngayCapNhatKTBM1 + "', '" + diff.ngayCapNhatKTBM2 + "', '" + diff.ngayCapNhatKT + "')", conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                        }

                        //6!=7
                        if (!tt7.Equals(tt6))
                        {
                            List<Diff> listDiff = new List<Diff>();

                            Type type = tt7.GetType();

                            //lấy value theo tên thuộc tính (có get set)
                            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                            {
                                if (!tt7.GetType().GetProperty(property.Name).GetValue(tt7, null).ToString().ToUpper().
                                    Equals(tt6.GetType().GetProperty(property.Name).GetValue(tt6, null).ToString().ToUpper()))
                                    if (!property.Name.Equals("TinhTrangID1") && !property.Name.Equals("NgayCapNhat1"))
                                        addListDiff<T>(listDiff, tt7, tt6, tt5, property.Name);
                            }

                            foreach (Diff diff in listDiff)
                            {
                                SqlConnection conn = new SqlConnection(HoTich.sqlConnect);
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("if(select count(*) from Diff " +
                                    "where id = '" + diff.id + "' and so = '" + diff.so + "' and quyenSo = '" + diff.quyenSo + "' and noiDangKy = '" + diff.noiDangKy + "' " +
                                    "and ngayDangKy = '" + diff.ngayDangKy + "' and tableName = '" + diff.tableName + "' and columnName = '" + diff.columnName + "' " +
                                    "and ktbm1 = N'" + Utils.QuotationMarks(diff.ktbm1) +
                                    "' and ktbm2 = N'" + Utils.QuotationMarks(diff.ktbm2) + "' and kt = N'" + Utils.QuotationMarks(diff.kt) + "' and ghiChu = '" + diff.ghiChu + "') = 0 " +
                                    "insert into Diff values('" + diff.id + "', '" + diff.so + "', '" + diff.quyenSo + "'," +
                                    "'" + diff.noiDangKy + "', '" + diff.ngayDangKy + "', '" + diff.tableName + "', '" + diff.columnName + "', N'" + Utils.QuotationMarks(diff.ktbm1) + "'," +
                                    "N'" + Utils.QuotationMarks(diff.ktbm2) + "',N'" + Utils.QuotationMarks(diff.kt) + "', '6 -> 7', " +
                                    "'" + diff.ngayCapNhatKTBM1 + "', '" + diff.ngayCapNhatKTBM2 + "', '" + diff.ngayCapNhatKT + "')", conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                        }
                    }
                }
            }

            MessageBox.Show("Đã xử lý xong " + tt7.GetType().Name, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void setValueObject<T>(string str, SqlConnection con, T tt)
        {
            using (SqlCommand cmd = new SqlCommand(str, con))
            {
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                //duyệt từng bản ghi
                int i = 0;
                while (dr.Read())
                {
                    Type type = tt.GetType();

                    //lấy value theo tên thuộc tính (có get set)
                    foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                    {
                        tt.GetType().GetProperty(property.Name).SetValue(tt, dr[i].ToString().Trim(), null);
                        i++;
                    }
                }
                if (i == 0)
                {
                    Type type = tt.GetType();

                    //lấy value theo tên thuộc tính (có get set)
                    foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                    {
                        tt.GetType().GetProperty(property.Name).SetValue(tt, null, null);
                        i++;
                    }
                }
                con.Close();
            }
        }
    }
}
