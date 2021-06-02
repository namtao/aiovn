using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    class HT_NHANCHAMECON
    {
        private string ID, So, quyenSo, trangSo, quyetDinhSo, ngayDangKy, loaiDangKy, loaiXacNhan, noiDangKy, cmHoTen, cmNgaySinh, cmDanToc, cmQuocTich, cmLoaiCuTru, cmLoaiGiayToTuyThan, cmSoGiayToTuyThan, ncHoTen, ncNgaySinh, ncDanToc, ncQuocTich, ncLoaiCuTru, ncLoaiGiayToTuyThan, ncSoGiayToTuyThan, TinhTrangID, TenFile, TenFileSauUpload, URLTapTinDinhKem, NamMoSo, LoaiGiay, DuLieuCu, NgayCapNhat, GhiChu, cmNoiCuTru, ncNoiCuTru, nycHoTen, nycQHNguoiDuocNhan, nguoiKy, chucVuNguoiKy, nguoiThucHien, cmQueQuan, cmNgayCapGiayToTuyThan, cmNoiCapGiayToTuyThan, ncQueQuan, ncNgayCapGiayToTuyThan, ncNoiCapGiayToTuyThan, nycLoaiGiayToTuyThan, nycSoGiayToTuyThan, nycNgayCapGiayToTuyThan, nycNoiCapGiayToTuyThan;

        public HT_NHANCHAMECON(string iD, string so, string quyenSo, string trangSo, string quyetDinhSo, string ngayDangKy, string loaiDangKy, string loaiXacNhan, string noiDangKy, string cmHoTen, string cmNgaySinh, string cmDanToc, string cmQuocTich, string cmLoaiCuTru, string cmLoaiGiayToTuyThan, string cmSoGiayToTuyThan, string ncHoTen, string ncNgaySinh, string ncDanToc, string ncQuocTich, string ncLoaiCuTru, string ncLoaiGiayToTuyThan, string ncSoGiayToTuyThan, string tinhTrangID, string tenFile, string tenFileSauUpload, string uRLTapTinDinhKem, string namMoSo, string loaiGiay, string duLieuCu, string ngayCapNhat, string ghiChu, string cmNoiCuTru, string ncNoiCuTru, string nycHoTen, string nycQHNguoiDuocNhan, string nguoiKy, string chucVuNguoiKy, string nguoiThucHien, string cmQueQuan, string cmNgayCapGiayToTuyThan, string cmNoiCapGiayToTuyThan, string ncQueQuan, string ncNgayCapGiayToTuyThan, string ncNoiCapGiayToTuyThan, string nycLoaiGiayToTuyThan, string nycSoGiayToTuyThan, string nycNgayCapGiayToTuyThan, string nycNoiCapGiayToTuyThan)
        {
            ID = iD;
            So = so;
            this.quyenSo = quyenSo;
            this.trangSo = trangSo;
            this.quyetDinhSo = quyetDinhSo;
            this.ngayDangKy = ngayDangKy;
            this.loaiDangKy = loaiDangKy;
            this.loaiXacNhan = loaiXacNhan;
            this.noiDangKy = noiDangKy;
            this.cmHoTen = cmHoTen;
            this.cmNgaySinh = cmNgaySinh;
            this.cmDanToc = cmDanToc;
            this.cmQuocTich = cmQuocTich;
            this.cmLoaiCuTru = cmLoaiCuTru;
            this.cmLoaiGiayToTuyThan = cmLoaiGiayToTuyThan;
            this.cmSoGiayToTuyThan = cmSoGiayToTuyThan;
            this.ncHoTen = ncHoTen;
            this.ncNgaySinh = ncNgaySinh;
            this.ncDanToc = ncDanToc;
            this.ncQuocTich = ncQuocTich;
            this.ncLoaiCuTru = ncLoaiCuTru;
            this.ncLoaiGiayToTuyThan = ncLoaiGiayToTuyThan;
            this.ncSoGiayToTuyThan = ncSoGiayToTuyThan;
            TinhTrangID = tinhTrangID;
            TenFile = tenFile;
            TenFileSauUpload = tenFileSauUpload;
            URLTapTinDinhKem = uRLTapTinDinhKem;
            NamMoSo = namMoSo;
            LoaiGiay = loaiGiay;
            DuLieuCu = duLieuCu;
            NgayCapNhat = ngayCapNhat;
            GhiChu = ghiChu;
            this.cmNoiCuTru = cmNoiCuTru;
            this.ncNoiCuTru = ncNoiCuTru;
            this.nycHoTen = nycHoTen;
            this.nycQHNguoiDuocNhan = nycQHNguoiDuocNhan;
            this.nguoiKy = nguoiKy;
            this.chucVuNguoiKy = chucVuNguoiKy;
            this.nguoiThucHien = nguoiThucHien;
            this.cmQueQuan = cmQueQuan;
            this.cmNgayCapGiayToTuyThan = cmNgayCapGiayToTuyThan;
            this.cmNoiCapGiayToTuyThan = cmNoiCapGiayToTuyThan;
            this.ncQueQuan = ncQueQuan;
            this.ncNgayCapGiayToTuyThan = ncNgayCapGiayToTuyThan;
            this.ncNoiCapGiayToTuyThan = ncNoiCapGiayToTuyThan;
            this.nycLoaiGiayToTuyThan = nycLoaiGiayToTuyThan;
            this.nycSoGiayToTuyThan = nycSoGiayToTuyThan;
            this.nycNgayCapGiayToTuyThan = nycNgayCapGiayToTuyThan;
            this.nycNoiCapGiayToTuyThan = nycNoiCapGiayToTuyThan;
        }

        public HT_NHANCHAMECON()
        {
        }

        public string ID1 { get => ID; set => ID = value; }
        public string So1 { get => So; set => So = value; }
        public string QuyenSo { get => quyenSo; set => quyenSo = value; }
        public string TrangSo { get => trangSo; set => trangSo = value; }
        public string QuyetDinhSo { get => quyetDinhSo; set => quyetDinhSo = value; }
        public string NgayDangKy { get => ngayDangKy; set => ngayDangKy = value; }
        public string LoaiDangKy { get => loaiDangKy; set => loaiDangKy = value; }
        public string LoaiXacNhan { get => loaiXacNhan; set => loaiXacNhan = value; }
        public string NoiDangKy { get => noiDangKy; set => noiDangKy = value; }
        public string CmHoTen { get => cmHoTen; set => cmHoTen = value; }
        public string CmNgaySinh { get => cmNgaySinh; set => cmNgaySinh = value; }
        public string CmDanToc { get => cmDanToc; set => cmDanToc = value; }
        public string CmQuocTich { get => cmQuocTich; set => cmQuocTich = value; }
        public string CmLoaiCuTru { get => cmLoaiCuTru; set => cmLoaiCuTru = value; }
        public string CmLoaiGiayToTuyThan { get => cmLoaiGiayToTuyThan; set => cmLoaiGiayToTuyThan = value; }
        public string CmSoGiayToTuyThan { get => cmSoGiayToTuyThan; set => cmSoGiayToTuyThan = value; }
        public string NcHoTen { get => ncHoTen; set => ncHoTen = value; }
        public string NcNgaySinh { get => ncNgaySinh; set => ncNgaySinh = value; }
        public string NcDanToc { get => ncDanToc; set => ncDanToc = value; }
        public string NcQuocTich { get => ncQuocTich; set => ncQuocTich = value; }
        public string NcLoaiCuTru { get => ncLoaiCuTru; set => ncLoaiCuTru = value; }
        public string NcLoaiGiayToTuyThan { get => ncLoaiGiayToTuyThan; set => ncLoaiGiayToTuyThan = value; }
        public string NcSoGiayToTuyThan { get => ncSoGiayToTuyThan; set => ncSoGiayToTuyThan = value; }
        public string TinhTrangID1 { get => TinhTrangID; set => TinhTrangID = value; }
        public string TenFile1 { get => TenFile; set => TenFile = value; }
        public string TenFileSauUpload1 { get => TenFileSauUpload; set => TenFileSauUpload = value; }
        public string URLTapTinDinhKem1 { get => URLTapTinDinhKem; set => URLTapTinDinhKem = value; }
        public string NamMoSo1 { get => NamMoSo; set => NamMoSo = value; }
        public string LoaiGiay1 { get => LoaiGiay; set => LoaiGiay = value; }
        public string DuLieuCu1 { get => DuLieuCu; set => DuLieuCu = value; }
        public string NgayCapNhat1 { get => NgayCapNhat; set => NgayCapNhat = value; }
        public string GhiChu1 { get => GhiChu; set => GhiChu = value; }
        public string CmNoiCuTru { get => cmNoiCuTru; set => cmNoiCuTru = value; }
        public string NcNoiCuTru { get => ncNoiCuTru; set => ncNoiCuTru = value; }
        public string NycHoTen { get => nycHoTen; set => nycHoTen = value; }
        public string NycQHNguoiDuocNhan { get => nycQHNguoiDuocNhan; set => nycQHNguoiDuocNhan = value; }
        public string NguoiKy { get => nguoiKy; set => nguoiKy = value; }
        public string ChucVuNguoiKy { get => chucVuNguoiKy; set => chucVuNguoiKy = value; }
        public string NguoiThucHien { get => nguoiThucHien; set => nguoiThucHien = value; }
        public string CmQueQuan { get => cmQueQuan; set => cmQueQuan = value; }
        public string CmNgayCapGiayToTuyThan { get => cmNgayCapGiayToTuyThan; set => cmNgayCapGiayToTuyThan = value; }
        public string CmNoiCapGiayToTuyThan { get => cmNoiCapGiayToTuyThan; set => cmNoiCapGiayToTuyThan = value; }
        public string NcQueQuan { get => ncQueQuan; set => ncQueQuan = value; }
        public string NcNgayCapGiayToTuyThan { get => ncNgayCapGiayToTuyThan; set => ncNgayCapGiayToTuyThan = value; }
        public string NcNoiCapGiayToTuyThan { get => ncNoiCapGiayToTuyThan; set => ncNoiCapGiayToTuyThan = value; }
        public string NycLoaiGiayToTuyThan { get => nycLoaiGiayToTuyThan; set => nycLoaiGiayToTuyThan = value; }
        public string NycSoGiayToTuyThan { get => nycSoGiayToTuyThan; set => nycSoGiayToTuyThan = value; }
        public string NycNgayCapGiayToTuyThan { get => nycNgayCapGiayToTuyThan; set => nycNgayCapGiayToTuyThan = value; }
        public string NycNoiCapGiayToTuyThan { get => nycNoiCapGiayToTuyThan; set => nycNoiCapGiayToTuyThan = value; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            var cmc = (HT_NHANCHAMECON)obj;

            return ID.Equals(cmc.ID) &&
                    So.Equals(cmc.So) &&
                    quyenSo.Equals(cmc.quyenSo) &&
                    trangSo.Equals(cmc.trangSo) &&
                    quyetDinhSo.Equals(cmc.quyetDinhSo) &&
                    ngayDangKy.Equals(cmc.ngayDangKy) &&
                    loaiDangKy.Equals(cmc.loaiDangKy) &&
                    loaiXacNhan.Equals(cmc.loaiXacNhan) &&
                    noiDangKy.Equals(cmc.noiDangKy) &&
                    cmHoTen.Equals(cmc.cmHoTen) &&
                    cmNgaySinh.Equals(cmc.cmNgaySinh) &&
                    cmDanToc.Equals(cmc.cmDanToc) &&
                    cmQuocTich.Equals(cmc.cmQuocTich) &&
                    cmLoaiCuTru.Equals(cmc.cmLoaiCuTru) &&
                    cmLoaiGiayToTuyThan.Equals(cmc.cmLoaiGiayToTuyThan) &&
                    cmSoGiayToTuyThan.Equals(cmc.cmSoGiayToTuyThan) &&
                    ncHoTen.Equals(cmc.ncHoTen) &&
                    ncNgaySinh.Equals(cmc.ncNgaySinh) &&
                    ncDanToc.Equals(cmc.ncDanToc) &&
                    ncQuocTich.Equals(cmc.ncQuocTich) &&
                    ncLoaiCuTru.Equals(cmc.ncLoaiCuTru) &&
                    ncLoaiGiayToTuyThan.Equals(cmc.ncLoaiGiayToTuyThan) &&
                    ncSoGiayToTuyThan.Equals(cmc.ncSoGiayToTuyThan) &&
                    TenFile.Equals(cmc.TenFile) &&
                    TenFileSauUpload.Equals(cmc.TenFileSauUpload) &&
                    URLTapTinDinhKem.Equals(cmc.URLTapTinDinhKem) &&
                    NamMoSo.Equals(cmc.NamMoSo) &&
                    LoaiGiay.Equals(cmc.LoaiGiay) &&
                    DuLieuCu.Equals(cmc.DuLieuCu) &&
                    NgayCapNhat.Equals(cmc.NgayCapNhat) &&
                    GhiChu.Equals(cmc.GhiChu) &&
                    cmNoiCuTru.Equals(cmc.cmNoiCuTru) &&
                    ncNoiCuTru.Equals(cmc.ncNoiCuTru) &&
                    nycHoTen.Equals(cmc.nycHoTen) &&
                    nycQHNguoiDuocNhan.Equals(cmc.nycQHNguoiDuocNhan) &&
                    nguoiKy.Equals(cmc.nguoiKy) &&
                    chucVuNguoiKy.Equals(cmc.chucVuNguoiKy) &&
                    nguoiThucHien.Equals(cmc.nguoiThucHien) &&
                    cmQueQuan.Equals(cmc.cmQueQuan) &&
                    cmNgayCapGiayToTuyThan.Equals(cmc.cmNgayCapGiayToTuyThan) &&
                    cmNoiCapGiayToTuyThan.Equals(cmc.cmNoiCapGiayToTuyThan) &&
                    ncQueQuan.Equals(cmc.ncQueQuan) &&
                    ncNgayCapGiayToTuyThan.Equals(cmc.ncNgayCapGiayToTuyThan) &&
                    ncNoiCapGiayToTuyThan.Equals(cmc.ncNoiCapGiayToTuyThan) &&
                    nycLoaiGiayToTuyThan.Equals(cmc.nycLoaiGiayToTuyThan) &&
                    nycSoGiayToTuyThan.Equals(cmc.nycSoGiayToTuyThan) &&
                    nycNgayCapGiayToTuyThan.Equals(cmc.nycNgayCapGiayToTuyThan) &&
                    nycNoiCapGiayToTuyThan.Equals(cmc.nycNoiCapGiayToTuyThan);
        }

        public override int GetHashCode()
        {
            int hashCode = 1220955993;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(So);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(quyenSo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(trangSo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(quyetDinhSo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ngayDangKy);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(loaiDangKy);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(loaiXacNhan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(noiDangKy);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(cmHoTen);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(cmNgaySinh);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(cmDanToc);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(cmQuocTich);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(cmLoaiCuTru);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(cmLoaiGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(cmSoGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ncHoTen);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ncNgaySinh);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ncDanToc);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ncQuocTich);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ncLoaiCuTru);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ncLoaiGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ncSoGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TinhTrangID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TenFile);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TenFileSauUpload);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(URLTapTinDinhKem);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NamMoSo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LoaiGiay);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DuLieuCu);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NgayCapNhat);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GhiChu);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(cmNoiCuTru);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ncNoiCuTru);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nycHoTen);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nycQHNguoiDuocNhan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nguoiKy);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(chucVuNguoiKy);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nguoiThucHien);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(cmQueQuan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(cmNgayCapGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(cmNoiCapGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ncQueQuan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ncNgayCapGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ncNoiCapGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nycLoaiGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nycSoGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nycNgayCapGiayToTuyThan);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nycNoiCapGiayToTuyThan);
            return hashCode;
        }


    }
}
