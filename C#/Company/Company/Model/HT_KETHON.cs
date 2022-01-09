using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class HT_KETHON
    {
        private string ID, So, quyenSo, trangSo, ngayDangKy, loaiDangKy, noiDangKy, chongHoTen, chongNgaySinh, chongDanToc, chongQuocTich, chongLoaiCuTru, chongLoaiGiayToTuyThan, chongSoGiayToTuyThan, voHoTen, voNgaySinh, voDanToc, voQuocTich, voLoaiCuTru, voLoaiGiayToTuyThan, voSoGiayToTuyThan, TinhTrangID, TenFile, TenFileSauUpLoad, URLTapTinDinhKem, NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, urlAnhCu, GhiChu, chongNoiCuTru, voNoiCuTru, nguoiKy, chucVuNguoiKy, nguoiThucHien, chongNgayCapGiayToTuyThan, chongNoiCapGiayToTuyThan, voNgayCapGiayToTuyThan, voNoiCapGiayToTuyThan;

        public string ID1 { get => ID; set => ID = value; }
        public string So1 { get => So; set => So = value; }
        public string QuyenSo { get => quyenSo; set => quyenSo = value; }
        public string TrangSo { get => trangSo; set => trangSo = value; }
        public string NgayDangKy { get => ngayDangKy; set => ngayDangKy = value; }
        public string LoaiDangKy { get => loaiDangKy; set => loaiDangKy = value; }
        public string NoiDangKy { get => noiDangKy; set => noiDangKy = value; }
        public string ChongHoTen { get => chongHoTen; set => chongHoTen = value; }
        public string ChongNgaySinh { get => chongNgaySinh; set => chongNgaySinh = value; }
        public string ChongDanToc { get => chongDanToc; set => chongDanToc = value; }
        public string ChongQuocTich { get => chongQuocTich; set => chongQuocTich = value; }
        public string ChongLoaiCuTru { get => chongLoaiCuTru; set => chongLoaiCuTru = value; }
        public string ChongLoaiGiayToTuyThan { get => chongLoaiGiayToTuyThan; set => chongLoaiGiayToTuyThan = value; }
        public string ChongSoGiayToTuyThan { get => chongSoGiayToTuyThan; set => chongSoGiayToTuyThan = value; }
        public string VoHoTen { get => voHoTen; set => voHoTen = value; }
        public string VoNgaySinh { get => voNgaySinh; set => voNgaySinh = value; }
        public string VoDanToc { get => voDanToc; set => voDanToc = value; }
        public string VoQuocTich { get => voQuocTich; set => voQuocTich = value; }
        public string VoLoaiCuTru { get => voLoaiCuTru; set => voLoaiCuTru = value; }
        public string VoLoaiGiayToTuyThan { get => voLoaiGiayToTuyThan; set => voLoaiGiayToTuyThan = value; }
        public string VoSoGiayToTuyThan { get => voSoGiayToTuyThan; set => voSoGiayToTuyThan = value; }
        public string TinhTrangID1 { get => TinhTrangID; set => TinhTrangID = value; }
        public string TenFile1 { get => TenFile; set => TenFile = value; }
        public string TenFileSauUpLoad1 { get => TenFileSauUpLoad; set => TenFileSauUpLoad = value; }
        public string URLTapTinDinhKem1 { get => URLTapTinDinhKem; set => URLTapTinDinhKem = value; }
        public string NamMoSo1 { get => NamMoSo; set => NamMoSo = value; }
        public string LoaiGiay1 { get => LoaiGiay; set => LoaiGiay = value; }
        public string DuLieuCu1 { get => DuLieuCu; set => DuLieuCu = value; }
        public string NgayCapNhat1 { get => NgayCapNhat; set => NgayCapNhat = value; }
        public string UrlAnhCu { get => urlAnhCu; set => urlAnhCu = value; }
        public string GhiChu1 { get => GhiChu; set => GhiChu = value; }
        public string ChongNoiCuTru { get => chongNoiCuTru; set => chongNoiCuTru = value; }
        public string VoNoiCuTru { get => voNoiCuTru; set => voNoiCuTru = value; }
        public string NguoiKy { get => nguoiKy; set => nguoiKy = value; }
        public string ChucVuNguoiKy { get => chucVuNguoiKy; set => chucVuNguoiKy = value; }
        public string NguoiThucHien { get => nguoiThucHien; set => nguoiThucHien = value; }
        public string ChongNgayCapGiayToTuyThan { get => chongNgayCapGiayToTuyThan; set => chongNgayCapGiayToTuyThan = value; }
        public string ChongNoiCapGiayToTuyThan { get => chongNoiCapGiayToTuyThan; set => chongNoiCapGiayToTuyThan = value; }
        public string VoNgayCapGiayToTuyThan { get => voNgayCapGiayToTuyThan; set => voNgayCapGiayToTuyThan = value; }
        public string VoNoiCapGiayToTuyThan { get => voNoiCapGiayToTuyThan; set => voNoiCapGiayToTuyThan = value; }

        public HT_KETHON(string iD, string so, string quyenSo, string trangSo, string ngayDangKy, string loaiDangKy, string noiDangKy, string chongHoTen, string chongNgaySinh, string chongDanToc, string chongQuocTich, string chongLoaiCuTru, string chongLoaiGiayToTuyThan, string chongSoGiayToTuyThan, string voHoTen, string voNgaySinh, string voDanToc, string voQuocTich, string voLoaiCuTru, string voLoaiGiayToTuyThan, string voSoGiayToTuyThan, string tinhTrangID, string tenFile, string tenFileSauUpLoad, string uRLTapTinDinhKem, string namMoSo, string loaiGiay, string duLieuCu, string ngayCapNhat, string urlAnhCu, string ghiChu, string chongNoiCuTru, string voNoiCuTru, string nguoiKy, string chucVuNguoiKy, string nguoiThucHien, string chongNgayCapGiayToTuyThan, string chongNoiCapGiayToTuyThan, string voNgayCapGiayToTuyThan, string voNoiCapGiayToTuyThan)
        {
            ID = iD;
            So = so;
            this.quyenSo = quyenSo;
            this.trangSo = trangSo;
            this.ngayDangKy = ngayDangKy;
            this.loaiDangKy = loaiDangKy;
            this.noiDangKy = noiDangKy;
            this.chongHoTen = chongHoTen;
            this.chongNgaySinh = chongNgaySinh;
            this.chongDanToc = chongDanToc;
            this.chongQuocTich = chongQuocTich;
            this.chongLoaiCuTru = chongLoaiCuTru;
            this.chongLoaiGiayToTuyThan = chongLoaiGiayToTuyThan;
            this.chongSoGiayToTuyThan = chongSoGiayToTuyThan;
            this.voHoTen = voHoTen;
            this.voNgaySinh = voNgaySinh;
            this.voDanToc = voDanToc;
            this.voQuocTich = voQuocTich;
            this.voLoaiCuTru = voLoaiCuTru;
            this.voLoaiGiayToTuyThan = voLoaiGiayToTuyThan;
            this.voSoGiayToTuyThan = voSoGiayToTuyThan;
            TinhTrangID = tinhTrangID;
            TenFile = tenFile;
            TenFileSauUpLoad = tenFileSauUpLoad;
            URLTapTinDinhKem = uRLTapTinDinhKem;
            NamMoSo = namMoSo;
            LoaiGiay = loaiGiay;
            DuLieuCu = duLieuCu;
            NgayCapNhat = ngayCapNhat;
            this.urlAnhCu = urlAnhCu;
            GhiChu = ghiChu;
            this.chongNoiCuTru = chongNoiCuTru;
            this.voNoiCuTru = voNoiCuTru;
            this.nguoiKy = nguoiKy;
            this.chucVuNguoiKy = chucVuNguoiKy;
            this.nguoiThucHien = nguoiThucHien;
            this.chongNgayCapGiayToTuyThan = chongNgayCapGiayToTuyThan;
            this.chongNoiCapGiayToTuyThan = chongNoiCapGiayToTuyThan;
            this.voNgayCapGiayToTuyThan = voNgayCapGiayToTuyThan;
            this.voNoiCapGiayToTuyThan = voNoiCapGiayToTuyThan;
        }

        public HT_KETHON()
        {
        }



        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            var kh = (HT_KETHON)obj;

            return ID == kh.ID &&
                   So == kh.So &&
                   quyenSo == kh.quyenSo &&
                   trangSo == kh.trangSo &&
                   ngayDangKy == kh.ngayDangKy &&
                   loaiDangKy == kh.loaiDangKy &&
                   noiDangKy == kh.noiDangKy &&
                   chongHoTen == kh.chongHoTen &&
                   chongNgaySinh == kh.chongNgaySinh &&
                   chongDanToc == kh.chongDanToc &&
                   chongQuocTich == kh.chongQuocTich &&
                   chongLoaiCuTru == kh.chongLoaiCuTru &&
                   chongLoaiGiayToTuyThan == kh.chongLoaiGiayToTuyThan &&
                   chongSoGiayToTuyThan == kh.chongSoGiayToTuyThan &&
                   voHoTen == kh.voHoTen &&
                   voNgaySinh == kh.voNgaySinh &&
                   voDanToc == kh.voDanToc &&
                   voQuocTich == kh.voQuocTich &&
                   voLoaiCuTru == kh.voLoaiCuTru &&
                   voLoaiGiayToTuyThan == kh.voLoaiGiayToTuyThan &&
                   voSoGiayToTuyThan == kh.voSoGiayToTuyThan &&
                   TinhTrangID == kh.TinhTrangID &&
                   TenFile == kh.TenFile &&
                   TenFileSauUpLoad == kh.TenFileSauUpLoad &&
                   URLTapTinDinhKem == kh.URLTapTinDinhKem &&
                   NamMoSo == kh.NamMoSo &&
                   LoaiGiay == kh.LoaiGiay &&
                   DuLieuCu == kh.DuLieuCu &&
                   NgayCapNhat == kh.NgayCapNhat &&
                   urlAnhCu == kh.urlAnhCu &&
                   GhiChu == kh.GhiChu &&
                   chongNoiCuTru == kh.chongNoiCuTru &&
                   voNoiCuTru == kh.voNoiCuTru &&
                   nguoiKy == kh.nguoiKy &&
                   chucVuNguoiKy == kh.chucVuNguoiKy &&
                   nguoiThucHien == kh.nguoiThucHien &&
                   chongNgayCapGiayToTuyThan == kh.chongNgayCapGiayToTuyThan &&
                   chongNoiCapGiayToTuyThan == kh.chongNoiCapGiayToTuyThan &&
                   voNgayCapGiayToTuyThan == kh.voNgayCapGiayToTuyThan &&
                   voNoiCapGiayToTuyThan == kh.voNoiCapGiayToTuyThan;
        }

        public override int GetHashCode()
        {
            int hashCode = -382672839;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(So);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(quyenSo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(trangSo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ngayDangKy);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(loaiDangKy);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(noiDangKy);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(chongHoTen);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(chongNgaySinh);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(chongDanToc);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(chongQuocTich);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(chongLoaiCuTru);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(chongLoaiGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(chongSoGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(voHoTen);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(voNgaySinh);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(voDanToc);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(voQuocTich);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(voLoaiCuTru);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(voLoaiGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(voSoGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TinhTrangID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TenFile);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TenFileSauUpLoad);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(URLTapTinDinhKem);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NamMoSo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LoaiGiay);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DuLieuCu);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NgayCapNhat);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(urlAnhCu);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GhiChu);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(chongNoiCuTru);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(voNoiCuTru);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nguoiKy);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(chucVuNguoiKy);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nguoiThucHien);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(chongNgayCapGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(chongNoiCapGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(voNgayCapGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(voNoiCapGiayToTuyThan);
            return hashCode;
        }
    }
}
