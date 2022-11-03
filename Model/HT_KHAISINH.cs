using System.Collections.Generic;

namespace xD
{
    class HT_KHAISINH
    {
        private string ID, so, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, nksHoTen, nksGioiTinh, nksNgaySinh, nksDanToc, nksQuocTich, meHoTen, meNgaySinh, meDanToc, meQuocTich, meLoaiCuTru, chaHoTen, chaNgaySinh, chaDanToc, chaQuocTich, chaLoaiCuTru, TinhTrangID, TenFile, TenFileSauUpLoad, URLTapTinDinhKem, NamMoSo, DuLieuCu, NgayCapNhat, LoaiGiay, URLAnhCu, GhiChu, nksNoiSinh, meNoiCuTru, chaNoiCuTru, nycHoTen, nycQuanHe, nguoiKy, chucVuNguoiKy, NguoiThucHien, nksLoaiKhaiSinh, nksNoiSinhDVHC, nksQueQuan, nycLoaiGiayToTuyThan, nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan, nksNgaySinhBangChu;

        public string ID1 { get => ID; set => ID = value; }
        public string So1 { get => so; set => so = value; }
        public string QuyenSo { get => quyenSo; set => quyenSo = value; }
        public string TrangSo { get => trangSo; set => trangSo = value; }
        public string NgayDangKy { get => ngayDangKy; set => ngayDangKy = value; }
        public string LoaiDangKy { get => loaiDangKy; set => loaiDangKy = value; }
        public string NoiDangKy { get => noiDangKy; set => noiDangKy = value; }
        public string NksHoTen { get => nksHoTen; set => nksHoTen = value; }
        public string NksGioiTinh { get => nksGioiTinh; set => nksGioiTinh = value; }
        public string NksNgaySinh { get => nksNgaySinh; set => nksNgaySinh = value; }
        public string NksDanToc { get => nksDanToc; set => nksDanToc = value; }
        public string NksQuocTich { get => nksQuocTich; set => nksQuocTich = value; }
        public string MeHoTen { get => meHoTen; set => meHoTen = value; }
        public string MeNgaySinh { get => meNgaySinh; set => meNgaySinh = value; }
        public string MeDanToc { get => meDanToc; set => meDanToc = value; }
        public string MeQuocTich { get => meQuocTich; set => meQuocTich = value; }
        public string MeLoaiCuTru { get => meLoaiCuTru; set => meLoaiCuTru = value; }
        public string ChaHoTen { get => chaHoTen; set => chaHoTen = value; }
        public string ChaNgaySinh { get => chaNgaySinh; set => chaNgaySinh = value; }
        public string ChaDanToc { get => chaDanToc; set => chaDanToc = value; }
        public string ChaQuocTich { get => chaQuocTich; set => chaQuocTich = value; }
        public string ChaLoaiCuTru { get => chaLoaiCuTru; set => chaLoaiCuTru = value; }
        public string TinhTrangID1 { get => TinhTrangID; set => TinhTrangID = value; }
        public string TenFile1 { get => TenFile; set => TenFile = value; }
        public string TenFileSauUpLoad1 { get => TenFileSauUpLoad; set => TenFileSauUpLoad = value; }
        public string URLTapTinDinhKem1 { get => URLTapTinDinhKem; set => URLTapTinDinhKem = value; }
        public string NamMoSo1 { get => NamMoSo; set => NamMoSo = value; }
        public string DuLieuCu1 { get => DuLieuCu; set => DuLieuCu = value; }
        public string NgayCapNhat1 { get => NgayCapNhat; set => NgayCapNhat = value; }
        public string LoaiGiay1 { get => LoaiGiay; set => LoaiGiay = value; }
        public string URLAnhCu1 { get => URLAnhCu; set => URLAnhCu = value; }
        public string GhiChu1 { get => GhiChu; set => GhiChu = value; }
        public string NksNoiSinh { get => nksNoiSinh; set => nksNoiSinh = value; }
        public string MeNoiCuTru { get => meNoiCuTru; set => meNoiCuTru = value; }
        public string ChaNoiCuTru { get => chaNoiCuTru; set => chaNoiCuTru = value; }
        public string NycHoTen { get => nycHoTen; set => nycHoTen = value; }
        public string NycQuanHe { get => nycQuanHe; set => nycQuanHe = value; }
        public string NguoiKy { get => nguoiKy; set => nguoiKy = value; }
        public string ChucVuNguoiKy { get => chucVuNguoiKy; set => chucVuNguoiKy = value; }
        public string NguoiThucHien1 { get => NguoiThucHien; set => NguoiThucHien = value; }
        public string NksLoaiKhaiSinh { get => nksLoaiKhaiSinh; set => nksLoaiKhaiSinh = value; }
        public string NksNoiSinhDVHC { get => nksNoiSinhDVHC; set => nksNoiSinhDVHC = value; }
        public string NksQueQuan { get => nksQueQuan; set => nksQueQuan = value; }
        public string NycLoaiGiayToTuyThan { get => nycLoaiGiayToTuyThan; set => nycLoaiGiayToTuyThan = value; }
        public string NycSoGiayToTuyThan { get => nycSoGiayToTuyThan; set => nycSoGiayToTuyThan = value; }
        public string NycNgayCapGiayToTuyThan { get => nycNgayCapGiayToTuyThan; set => nycNgayCapGiayToTuyThan = value; }
        public string NycNoiCapGiayToTuyThan { get => nycNoiCapGiayToTuyThan; set => nycNoiCapGiayToTuyThan = value; }
        public string NksNgaySinhBangChu { get => nksNgaySinhBangChu; set => nksNgaySinhBangChu = value; }

        public HT_KHAISINH(string iD, string so, string quyenSo, string trangSo, string ngayDangKy, string loaiDangKy, string noiDangKy, string nksHoTen, string nksGioiTinh, string nksNgaySinh, string nksDanToc, string nksQuocTich, string meHoTen, string meNgaySinh, string meDanToc, string meQuocTich, string meLoaiCuTru, string chaHoTen, string chaNgaySinh, string chaDanToc, string chaQuocTich, string chaLoaiCuTru, string tinhTrangID, string tenFile, string tenFileSauUpLoad, string uRLTapTinDinhKem, string namMoSo, string duLieuCu, string ngayCapNhat, string loaiGiay, string uRLAnhCu, string ghiChu, string nksNoiSinh, string meNoiCuTru, string chaNoiCuTru, string nycHoTen, string nycQuanHe, string nguoiKy, string chucVuNguoiKy, string nguoiThucHien, string nksLoaiKhaiSinh, string nksNoiSinhDVHC, string nksQueQuan, string nycLoaiGiayToTuyThan, string nycSoGiayToTuyThan, string nycNgayCapGiayToTuyThan, string nycNoiCapGiayToTuyThan, string nksNgaySinhBangChu)
        {
            ID = iD;
            this.so = so;
            this.quyenSo = quyenSo;
            this.trangSo = trangSo;
            this.ngayDangKy = ngayDangKy;
            this.loaiDangKy = loaiDangKy;
            this.noiDangKy = noiDangKy;
            this.nksHoTen = nksHoTen;
            this.nksGioiTinh = nksGioiTinh;
            this.nksNgaySinh = nksNgaySinh;
            this.nksDanToc = nksDanToc;
            this.nksQuocTich = nksQuocTich;
            this.meHoTen = meHoTen;
            this.meNgaySinh = meNgaySinh;
            this.meDanToc = meDanToc;
            this.meQuocTich = meQuocTich;
            this.meLoaiCuTru = meLoaiCuTru;
            this.chaHoTen = chaHoTen;
            this.chaNgaySinh = chaNgaySinh;
            this.chaDanToc = chaDanToc;
            this.chaQuocTich = chaQuocTich;
            this.chaLoaiCuTru = chaLoaiCuTru;
            TinhTrangID = tinhTrangID;
            TenFile = tenFile;
            TenFileSauUpLoad = tenFileSauUpLoad;
            URLTapTinDinhKem = uRLTapTinDinhKem;
            NamMoSo = namMoSo;
            DuLieuCu = duLieuCu;
            NgayCapNhat = ngayCapNhat;
            LoaiGiay = loaiGiay;
            URLAnhCu = uRLAnhCu;
            GhiChu = ghiChu;
            this.nksNoiSinh = nksNoiSinh;
            this.meNoiCuTru = meNoiCuTru;
            this.chaNoiCuTru = chaNoiCuTru;
            this.nycHoTen = nycHoTen;
            this.nycQuanHe = nycQuanHe;
            this.nguoiKy = nguoiKy;
            this.chucVuNguoiKy = chucVuNguoiKy;
            NguoiThucHien = nguoiThucHien;
            this.nksLoaiKhaiSinh = nksLoaiKhaiSinh;
            this.nksNoiSinhDVHC = nksNoiSinhDVHC;
            this.nksQueQuan = nksQueQuan;
            this.nycLoaiGiayToTuyThan = nycLoaiGiayToTuyThan;
            this.nycSoGiayToTuyThan = nycSoGiayToTuyThan;
            this.nycNgayCapGiayToTuyThan = nycNgayCapGiayToTuyThan;
            this.nycNoiCapGiayToTuyThan = nycNoiCapGiayToTuyThan;
            this.nksNgaySinhBangChu = nksNgaySinhBangChu;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            var ks = (HT_KHAISINH)obj;

            return ID.Equals(ks.ID) &&
                so.Equals(ks.so) &&
                quyenSo.Equals(ks.quyenSo) &&
                trangSo.Equals(ks.trangSo) &&
                ngayDangKy.Equals(ks.ngayDangKy) &&
                loaiDangKy.Equals(ks.loaiDangKy) &&
                noiDangKy.Equals(ks.noiDangKy) &&
                nksHoTen.Equals(ks.nksHoTen) &&
                nksGioiTinh.Equals(ks.nksGioiTinh) &&
                nksNgaySinh.Equals(ks.nksNgaySinh) &&
                nksDanToc.Equals(ks.nksDanToc) &&
                nksQuocTich.Equals(ks.nksQuocTich) &&
                meHoTen.Equals(ks.meHoTen) &&
                meNgaySinh.Equals(ks.meNgaySinh) &&
                meDanToc.Equals(ks.meDanToc) &&
                meQuocTich.Equals(ks.meQuocTich) &&
                meLoaiCuTru.Equals(ks.meLoaiCuTru) &&
                chaHoTen.Equals(ks.chaHoTen) &&
                chaNgaySinh.Equals(ks.chaNgaySinh) &&
                chaDanToc.Equals(ks.chaDanToc) &&
                chaQuocTich.Equals(ks.chaQuocTich) &&
                chaLoaiCuTru.Equals(ks.chaLoaiCuTru) &&
                TenFile.Equals(ks.TenFile) &&
                TenFileSauUpLoad.Equals(ks.TenFileSauUpLoad) &&
                URLTapTinDinhKem.Equals(ks.URLTapTinDinhKem) &&
                NamMoSo.Equals(ks.NamMoSo) &&
                DuLieuCu.Equals(ks.DuLieuCu) &&
                NgayCapNhat.Equals(ks.NgayCapNhat) &&
                LoaiGiay.Equals(ks.LoaiGiay) &&
                URLAnhCu.Equals(ks.URLAnhCu) &&
                GhiChu.Equals(ks.GhiChu) &&
                nksNoiSinh.Equals(ks.nksNoiSinh) &&
                meNoiCuTru.Equals(ks.meNoiCuTru) &&
                chaNoiCuTru.Equals(ks.chaNoiCuTru) &&
                nycHoTen.Equals(ks.nycHoTen) &&
                nycQuanHe.Equals(ks.nycQuanHe) &&
                nguoiKy.Equals(ks.nguoiKy) &&
                chucVuNguoiKy.Equals(ks.chucVuNguoiKy) &&
                NguoiThucHien.Equals(ks.NguoiThucHien) &&
                nksLoaiKhaiSinh.Equals(ks.nksLoaiKhaiSinh) &&
                nksNoiSinhDVHC.Equals(ks.nksNoiSinhDVHC) &&
                nksQueQuan.Equals(ks.nksQueQuan) &&
                nycLoaiGiayToTuyThan.Equals(ks.nycLoaiGiayToTuyThan) &&
                nycSoGiayToTuyThan.Equals(ks.nycSoGiayToTuyThan) &&
                nycNgayCapGiayToTuyThan.Equals(ks.nycNgayCapGiayToTuyThan) &&
                nycNoiCapGiayToTuyThan.Equals(ks.nycNoiCapGiayToTuyThan) &&
                nksNgaySinhBangChu.Equals(ks.nksNgaySinhBangChu);
        }

        public HT_KHAISINH()
        {
        }

        public override int GetHashCode()
        {
            int hashCode = -2045957784;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(so);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(quyenSo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(trangSo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ngayDangKy);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(loaiDangKy);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(noiDangKy);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nksHoTen);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nksGioiTinh);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nksNgaySinh);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nksDanToc);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nksQuocTich);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(meHoTen);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(meNgaySinh);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(meDanToc);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(meQuocTich);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(meLoaiCuTru);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(chaHoTen);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(chaNgaySinh);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(chaDanToc);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(chaQuocTich);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(chaLoaiCuTru);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TinhTrangID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TenFile);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TenFileSauUpLoad);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(URLTapTinDinhKem);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NamMoSo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DuLieuCu);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NgayCapNhat);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LoaiGiay);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(URLAnhCu);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GhiChu);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nksNoiSinh);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(meNoiCuTru);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(chaNoiCuTru);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nycHoTen);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nycQuanHe);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nguoiKy);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(chucVuNguoiKy);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NguoiThucHien);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nksLoaiKhaiSinh);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nksNoiSinhDVHC);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nksQueQuan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nycLoaiGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nycSoGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nycNgayCapGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nycNoiCapGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nksNgaySinhBangChu);
            return hashCode;
        }


    }
}
