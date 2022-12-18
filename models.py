import datetime
from typing import List, Optional
from pydantic import BaseModel


class A(BaseModel):

    id: Optional[int]
    name: Optional[nvarchar]


class CDConfig(BaseModel):

    id: List[]
    serial_key: Optional[nvarchar]
    org: Optional[nvarchar]


class DCDMTINHTRANG(BaseModel):

    tinh_trang_i_d: List[]
    ma: Optional[nvarchar]
    ten: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    su_dung: Optional[bit]
    tinh_trang_cha_i_d: Optional[int]


class Diff(BaseModel):

    id: Optional[nvarchar]
    so: Optional[nvarchar]
    quyen_so: Optional[nvarchar]
    noi_dang_ky: Optional[nvarchar]
    ngay_dang_ky: Optional[nvarchar]
    table_name: Optional[nvarchar]
    column_name: Optional[nvarchar]
    ktbm1: Optional[nvarchar]
    ktbm2: Optional[nvarchar]
    kt: Optional[nvarchar]
    ghi_chu: Optional[nvarchar]
    ngay_cap_nhat_k_t_b_m1: Optional[nvarchar]
    ngay_cap_nhat_k_t_b_m2: Optional[nvarchar]
    ngay_cap_nhat_k_t: Optional[nvarchar]


class DMCHUCVU(BaseModel):

    chuc_vu_i_d: List[]
    ma_chuc_vu: Optional[nvarchar]
    ten_chuc_vu: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    active: Optional[str]


class DMCOQUAN(BaseModel):

    co_quan_i_d: List[]
    ma_co_quan: Optional[nvarchar]
    ten_co_quan: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    active: Optional[str]


class DMDANTOC(BaseModel):

    ma_dan_toc: Optional[nvarchar]
    ten_dan_toc: Optional[nvarchar]
    ten_khac: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    su_dung: Optional[bit]


class DMDOMAT(BaseModel):

    do_mat_i_d: List[]
    ma_do_mat: Optional[nvarchar]
    ten_do_mat: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    active: Optional[str]


class DMDUONG(BaseModel):

    ma_duong: nvarchar
    ten_duong: Optional[nvarchar]
    ten_viet_tat: Optional[nvarchar]
    ma_quan_huyen: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    su_dung: Optional[bit]


class DMGIOITINH(BaseModel):

    ma_gioi_tinh: nvarchar
    ten_gioi_tinh: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    su_dung: Optional[bit]


class DMHOP(BaseModel):

    hop_i_d: List[]
    ma_hop: Optional[nvarchar]
    tieu_de: Optional[nvarchar]
    so_ho_so: Optional[int]
    suc_chua: Optional[int]
    da_chua: Optional[int]
    con_lai: Optional[int]
    tinh_trang_i_d: Optional[int]
    ke_i_d: Optional[int]
    thoi_gian_luu: Optional[nvarchar]
    nam_l_t: Optional[int]
    ngay_luu: Optional[datetime.date]
    mo_ta: Optional[nvarchar]
    active: Optional[str]


class DMHOSO(BaseModel):

    ho_so_i_d: List[]
    so_ho_so: Optional[nvarchar]
    so_muc_luc: Optional[nvarchar]
    ky_hieu: Optional[nvarchar]
    tieu_de: Optional[nvarchar]
    chu_thich: Optional[nvarchar]
    trich_yeu: Optional[nvarchar]
    thoi_gian_b_d: Optional[nvarchar]
    thoi_gian_k_t: Optional[nvarchar]
    nam_l_t: Optional[int]
    ngon_ngu_i_d: Optional[int]
    but_tich: Optional[nvarchar]
    so_to: Optional[int]
    thoi_han_i_d: Optional[int]
    che_do_s_d: Optional[nvarchar]
    tinh_trang: Optional[nvarchar]
    ghi_chu: Optional[nvarchar]
    hop_i_d: Optional[int]
    linh_vuc_i_d: Optional[int]
    loai_ho_so_i_d: Optional[int]
    phong_ban_i_d: Optional[int]


class DMKE(BaseModel):

    ke_i_d: List[]
    ma_ke: Optional[nvarchar]
    ten_ke: Optional[nvarchar]
    loai_ke_i_d: Optional[int]
    suc_chua: Optional[int]
    so_hop_da_luu: Optional[int]
    tinh_trang_i_d: Optional[int]
    kho_i_d: Optional[int]
    mo_ta: Optional[nvarchar]
    active: Optional[str]


class DMKHO(BaseModel):

    kho_i_d: List[]
    ma_kho: Optional[nvarchar]
    ten_kho: Optional[nvarchar]
    loai_kho_i_d: Optional[int]
    kich_thuoc: Optional[nvarchar]
    dia_chi: Optional[nvarchar]
    nguoi_quan_ly: Optional[nvarchar]
    dien_thoai: Optional[nvarchar]
    email: Optional[nvarchar]
    ghi_chu: Optional[nvarchar]
    active: Optional[str]


class DMLINHVUC(BaseModel):

    linh_vuc_i_d: List[]
    ma_linh_vuc: Optional[nvarchar]
    ten_linh_vuc: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    active: Optional[str]


class DMLOAICUTRU(BaseModel):

    ma_loai_cu_tru: int
    ten_loai_cu_tru: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    su_dung: Optional[bit]


class DMLOAIDOITAC(BaseModel):

    loai_doi_tac_i_d: List[]
    ma: Optional[str]
    ten: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    active: Optional[str]


class DMLOAIHOSO(BaseModel):

    loai_ho_so_i_d: List[]
    ma_loai: Optional[nvarchar]
    ten_loai: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    active: Optional[str]


class DMLOAIKE(BaseModel):

    loai_ke_i_d: List[]
    ma_loai: Optional[nvarchar]
    ten_loai: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    active: Optional[str]


class DMLOAIKHO(BaseModel):

    loai_kho_i_d: List[]
    ma_loai: Optional[nvarchar]
    ten_loai: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    active: Optional[str]


class DMLOAITRANGTHAI(BaseModel):

    ma_loai_trang_thai: nvarchar
    ten_loai_trang_thai: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    su_dung: Optional[bit]


class DMLOAIVANBAN(BaseModel):

    loai_van_ban_i_d: List[]
    ma_loai: Optional[nvarchar]
    ten_loai: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    active: Optional[str]


class DMLOAIXACNHAN(BaseModel):

    ma_loai_xac_nhan: int
    ten_loai_xac_nhan: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    su_dung: Optional[bit]


class DMNGONNGU(BaseModel):

    ngon_ngu_i_d: List[]
    ma_ngon_ngu: Optional[nvarchar]
    ten_ngon_ngu: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    active: Optional[str]


class DMNGUOIKY(BaseModel):

    nguoi_ky_i_d: List[]
    ma_nguoi_ky: Optional[nvarchar]
    ten_nguoi_ky: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    active: Optional[str]


class DMNHOMMAU(BaseModel):

    ma_nhom_mau: nvarchar
    ten_nhom_mau: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    su_dung: Optional[bit]


class DMNOINHAN(BaseModel):

    noi_nhan_i_d: List[]
    ma_noi_nhan: Optional[nvarchar]
    ten_noi_nhan: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    active: Optional[str]


class DMPHONGBAN(BaseModel):

    phong_ban_i_d: List[]
    ma_phong_ban: Optional[nvarchar]
    ten_phong_ban: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    active: Optional[str]


class DMPHUONGXA(BaseModel):

    ma_phuong_xa: nvarchar
    ten_phuong_xa: Optional[nvarchar]
    ma_quan_huyen: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    su_dung: Optional[bit]


class DMQUANHE(BaseModel):

    ma_quan_he: nvarchar
    ten_quan_he: Optional[nchar]
    mo_ta: Optional[nvarchar]
    su_dung: Optional[bit]


class DMQUANHUYEN(BaseModel):

    ma_quan_huyen: nvarchar
    ten_quan_huyen: Optional[nvarchar]
    ma_tinh_thanh: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    su_dung: Optional[bit]


class DMTHOIHAN(BaseModel):

    thoi_han_i_d: List[]
    ma_thoi_han: Optional[nvarchar]
    ten_thoi_han: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    active: Optional[str]


class DMTINHTHANH(BaseModel):

    ma_tinh_thanh: nvarchar
    ten_tinh_thanh: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    su_dung: Optional[bit]


class DMTINHTRANGHONNHAN(BaseModel):

    ma_tinh_trang_hon_nhan: nvarchar
    ten_tinh_trang_hon_nhan: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    su_dung: Optional[str]


class DMTONGIAO(BaseModel):

    ma_ton_giao: nvarchar
    ten_ton_giao: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    su_dung: Optional[str]


class DMTINHTRANG(BaseModel):

    tinh_trang_i_d: List[]
    ma: Optional[nvarchar]
    ten: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    active: Optional[str]


class FILEATTACHFILE(BaseModel):

    attach_file_i_d: List[]
    object_i_d: Optional[int]
    original_name: Optional[nvarchar]
    upload_name: Optional[nvarchar]
    path_name: Optional[str]
    file_size: Optional[int]
    table_name: Optional[str]
    type_file: Optional[str]


class HTHNMUCDICH(BaseModel):

    ma_muc_dich: int
    ten_muc_dich: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    su_dung: Optional[bit]


class HTHOSOQUET(BaseModel):

    id: List[]
    ngay_quet: Optional[datetime.datetime]
    nguoi_quet_i_d: Optional[int]
    noi_dang_ky_i_d: Optional[nvarchar]
    quyen_so: Optional[nvarchar]
    so_trang: Optional[int]
    ghi_chu: Optional[nvarchar]
    loai_ho_so_i_d: Optional[int]
    may_quet_i_d: Optional[int]
    nguoi_kiem_tra_i_d: Optional[int]
    ngay_kiem_tra: Optional[datetime.datetime]
    tinh_trang_i_d: Optional[int]
    ghi_chu_loi: Optional[nvarchar]
    loai_giay_i_d: Optional[int]
    isdel: Optional[int]


class HTKETHON(BaseModel):

    id: List[]
    so: Optional[nvarchar]
    quyen_so: Optional[nvarchar]
    trang_so: Optional[nvarchar]
    ngay_dang_ky: Optional[nvarchar]
    loai_dang_ky: Optional[int]
    noi_dang_ky: Optional[nvarchar]
    chong_ho_ten: Optional[nvarchar]
    chong_ngay_sinh: Optional[nvarchar]
    chong_dan_toc: Optional[nvarchar]
    chong_quoc_tich: Optional[nvarchar]
    chong_loai_cu_tru: Optional[int]
    chong_loai_giay_to_tuy_than: Optional[int]
    chong_so_giay_to_tuy_than: Optional[nvarchar]
    vo_ho_ten: Optional[nvarchar]
    vo_ngay_sinh: Optional[nvarchar]
    vo_dan_toc: Optional[nvarchar]
    vo_quoc_tich: Optional[nvarchar]
    vo_loai_cu_tru: Optional[int]
    vo_loai_giay_to_tuy_than: Optional[int]
    vo_so_giay_to_tuy_than: Optional[nvarchar]
    tinh_trang_i_d: Optional[int]
    ten_file: Optional[nvarchar]
    ten_file_sau_up_load: Optional[nvarchar]
    u_r_l_tap_tin_dinh_kem: Optional[nvarchar]
    nam_mo_so: Optional[nvarchar]
    loai_giay: Optional[nvarchar]
    du_lieu_cu: Optional[bit]
    ngay_cap_nhat: Optional[datetime.datetime]
    u_r_l_anh_cu: Optional[nvarchar]
    ghichu: Optional[nvarchar]
    chong_noi_cu_tru: Optional[nvarchar]
    vo_noi_cu_tru: Optional[nvarchar]
    nguoi_ky: Optional[nvarchar]
    chuc_vu_nguoi_ky: Optional[nvarchar]
    nguoi_thuc_hien: Optional[nvarchar]
    chong_ngay_cap_giay_to_tuy_than: Optional[nvarchar]
    chong_noi_cap_giay_to_tuy_than: Optional[nvarchar]
    vo_ngay_cap_giay_to_tuy_than: Optional[nvarchar]
    vo_noi_cap_giay_to_tuy_than: Optional[nvarchar]


class HTKETHON2(BaseModel):

    id: List[]
    so: Optional[nvarchar]
    quyen_so: Optional[nvarchar]
    trang_so: Optional[nvarchar]
    ngay_dang_ky: Optional[nvarchar]
    loai_dang_ky: Optional[int]
    noi_dang_ky: Optional[nvarchar]
    chong_ho_ten: Optional[nvarchar]
    chong_ngay_sinh: Optional[nvarchar]
    chong_dan_toc: Optional[nvarchar]
    chong_quoc_tich: Optional[nvarchar]
    chong_loai_cu_tru: Optional[int]
    chong_loai_giay_to_tuy_than: Optional[int]
    chong_so_giay_to_tuy_than: Optional[nvarchar]
    vo_ho_ten: Optional[nvarchar]
    vo_ngay_sinh: Optional[nvarchar]
    vo_dan_toc: Optional[nvarchar]
    vo_quoc_tich: Optional[nvarchar]
    vo_loai_cu_tru: Optional[int]
    vo_loai_giay_to_tuy_than: Optional[int]
    vo_so_giay_to_tuy_than: Optional[nvarchar]
    tinh_trang_i_d: Optional[int]
    ten_file: Optional[nvarchar]
    ten_file_sau_up_load: Optional[nvarchar]
    u_r_l_tap_tin_dinh_kem: Optional[nvarchar]
    ket_hon_i_d: Optional[int]


class HTKHLOAIDANGKY(BaseModel):

    ma_loai_dang_ky: int
    ten_loai_dang_ky: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    su_dung: Optional[bit]


class HTKHAISINH(BaseModel):

    id: List[]
    so: Optional[nvarchar]
    quyen_so: Optional[nvarchar]
    trang_so: Optional[nvarchar]
    ngay_dang_ky: Optional[nvarchar]
    loai_dang_ky: Optional[int]
    noi_dang_ky: Optional[nvarchar]
    nks_ho_ten: Optional[nvarchar]
    nks_gioi_tinh: Optional[nvarchar]
    nks_ngay_sinh: Optional[nvarchar]
    nks_dan_toc: Optional[nvarchar]
    nks_quoc_tich: Optional[nvarchar]
    me_ho_ten: Optional[nvarchar]
    me_ngay_sinh: Optional[nvarchar]
    me_dan_toc: Optional[nvarchar]
    me_quoc_tich: Optional[nvarchar]
    me_loai_cu_tru: Optional[int]
    cha_ho_ten: Optional[nvarchar]
    cha_ngay_sinh: Optional[nvarchar]
    cha_dan_toc: Optional[nvarchar]
    cha_quoc_tich: Optional[nvarchar]
    cha_loai_cu_tru: Optional[int]
    tinh_trang_i_d: Optional[int]
    ten_file: Optional[nvarchar]
    ten_file_sau_up_load: Optional[nvarchar]
    u_r_l_tap_tin_dinh_kem: Optional[nvarchar]
    nam_mo_so: Optional[nvarchar]
    loai_giay: Optional[nvarchar]
    du_lieu_cu: Optional[bit]
    ngay_cap_nhat: Optional[datetime.datetime]
    u_r_l_anh_cu: Optional[nvarchar]
    ghichu: Optional[nvarchar]
    nks_noi_sinh: Optional[nvarchar]
    me_noi_cu_tru: Optional[nvarchar]
    cha_noi_cu_tru: Optional[nvarchar]
    nyc_ho_ten: Optional[nvarchar]
    nyc_quan_he: Optional[nvarchar]
    nguoi_ky: Optional[nvarchar]
    chuc_vu_nguoi_ky: Optional[nvarchar]
    nguoi_thuc_hien: Optional[nvarchar]
    nks_ngay_sinh_bang_chu: Optional[nvarchar]
    nks_loai_khai_sinh: Optional[int]
    nks_noi_sinh_d_v_h_c: Optional[nvarchar]
    nks_que_quan: Optional[nvarchar]
    nyc_loai_giay_to_tuy_than: Optional[int]
    nyc_so_giay_to_tuy_than: Optional[nvarchar]
    nyc_ngay_cap_giay_to_tuy_than: Optional[nvarchar]
    nyc_noi_cap_giay_to_tuy_than: Optional[nvarchar]
    me_loai_giay_to_tuy_than: Optional[int]
    me_so_giay_to_tuy_than: Optional[nvarchar]
    cha_loai_giay_to_tuy_than: Optional[int]
    cha_so_giay_to_tuy_than: Optional[nvarchar]


class HTKHAISINH2(BaseModel):

    id: List[]
    so: Optional[nvarchar]
    quyen_so: Optional[nvarchar]
    trang_so: Optional[nvarchar]
    ngay_dang_ky: Optional[nvarchar]
    loai_dang_ky: Optional[int]
    noi_dang_ky: Optional[nvarchar]
    nks_ho_ten: Optional[nvarchar]
    nks_gioi_tinh: Optional[nvarchar]
    nks_ngay_sinh: Optional[nvarchar]
    nks_dan_toc: Optional[nvarchar]
    nks_quoc_tich: Optional[nvarchar]
    me_ho_ten: Optional[nvarchar]
    me_ngay_sinh: Optional[nvarchar]
    me_dan_toc: Optional[nvarchar]
    me_quoc_tich: Optional[nvarchar]
    me_loai_cu_tru: Optional[int]
    cha_ho_ten: Optional[nvarchar]
    cha_ngay_sinh: Optional[nvarchar]
    cha_dan_toc: Optional[nvarchar]
    cha_quoc_tich: Optional[nvarchar]
    cha_loai_cu_tru: Optional[int]
    tinh_trang_i_d: Optional[int]
    ten_file: Optional[nvarchar]
    ten_file_sau_up_load: Optional[nvarchar]
    u_r_l_tap_tin_dinh_kem: Optional[nvarchar]
    khai_sinh_i_d: Optional[int]


class HTKHAITU(BaseModel):

    id: List[]
    so: Optional[nvarchar]
    quyen_so: Optional[nvarchar]
    trang_so: Optional[nvarchar]
    ngay_dang_ky: Optional[nvarchar]
    loai_dang_ky: Optional[int]
    noi_dang_ky: Optional[nvarchar]
    nkt_ho_ten: Optional[nvarchar]
    nkt_gioi_tinh: Optional[nvarchar]
    nkt_ngay_sinh: Optional[nvarchar]
    nkt_dan_toc: Optional[nvarchar]
    nkt_quoc_tich: Optional[nvarchar]
    nkt_loai_cu_tru: Optional[int]
    nkt_loai_giay_to_tuy_than: Optional[int]
    nkt_so_giay_to_tuy_than: Optional[nvarchar]
    nkt_ngay_chet: Optional[nvarchar]
    tinh_trang_i_d: Optional[int]
    ten_file: Optional[nvarchar]
    ten_file_sau_upload: Optional[nvarchar]
    u_r_l_tap_tin_dinh_kem: Optional[nvarchar]
    nam_mo_so: Optional[nvarchar]
    loai_giay: Optional[nvarchar]
    du_lieu_cu: Optional[bit]
    ngay_cap_nhat: Optional[datetime.datetime]
    u_r_l_anh_cu: Optional[nvarchar]
    ghichu: Optional[nvarchar]
    nkt_gio_phut_chet: Optional[nvarchar]
    nkt_noi_chet: Optional[nvarchar]
    nkt_nguyen_nhan_chet: Optional[nvarchar]
    nkt_noi_cu_tru: Optional[nvarchar]
    nyc_ho_ten: Optional[nvarchar]
    nyc_quan_he: Optional[nvarchar]
    nguoi_ky: Optional[nvarchar]
    chuc_vu_nguoi_ky: Optional[nvarchar]
    nguoi_thuc_hien: Optional[nvarchar]
    nkt_gio_phut_chet1: Optional[nvarchar]
    nkt_ngay_cap_giay_to_tuy_than: Optional[nvarchar]
    nkt_noi_cap_giay_to_tuy_than: Optional[nvarchar]
    gbt_loai: Optional[int]
    gbt_so: Optional[nvarchar]
    gbt_ngay: Optional[nvarchar]
    gbt_co_quan_cap: Optional[nvarchar]
    nyc_loai_giay_to_tuy_than: Optional[int]
    nyc_so_giay_to_tuy_than: Optional[nvarchar]
    nyc_ngay_cap_giay_to_tuy_than: Optional[nvarchar]
    nyc_noi_cap_giay_to_tuy_than: Optional[nvarchar]


class HTKHAITU2(BaseModel):

    id: List[]
    so: Optional[nvarchar]
    quyen_so: Optional[nvarchar]
    trang_so: Optional[nvarchar]
    ngay_dang_ky: Optional[nvarchar]
    loai_dang_ky: Optional[int]
    noi_dang_ky: Optional[nvarchar]
    nkt_ho_ten: Optional[nvarchar]
    nkt_gioi_tinh: Optional[nvarchar]
    nkt_ngay_sinh: Optional[nvarchar]
    nkt_dan_toc: Optional[nvarchar]
    nkt_quoc_tich: Optional[nvarchar]
    nkt_loai_cu_tru: Optional[int]
    nkt_loai_giay_to_tuy_than: Optional[int]
    nkt_so_giay_to_tuy_than: Optional[nvarchar]
    nkt_ngay_chet: Optional[nvarchar]
    tinh_trang_i_d: Optional[int]
    ten_file: Optional[nvarchar]
    ten_file_sau_upload: Optional[nvarchar]
    u_r_l_tap_tin_dinh_kem: Optional[nvarchar]
    khai_tu_i_d: Optional[int]


class HTKSLOAIDANGKY(BaseModel):

    ma_loai_dang_ky: int
    ten_loai_dang_ky: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    su_dung: Optional[bit]


class HTKSLOAIKHAISINH(BaseModel):

    ma_loai_khai_sinh: int
    ten_loai_khai_sinh: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    su_dung: Optional[bit]


class HTKTLOAIGIAYBAOTU(BaseModel):

    ma_loai: int
    ten_loai: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    su_dung: Optional[bit]


class HTKTLOAIDANGKY(BaseModel):

    ma_loai_dang_ky: int
    ten_loai_dang_ky: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    su_dung: Optional[bit]


class HTLOAIGIAY(BaseModel):

    id: int
    ma: Optional[nvarchar]
    ten: Optional[nvarchar]


class HTLOAIGIAYTO(BaseModel):

    ma_loai_giay_to: int
    ten_loai_giay_to: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    su_dung: Optional[bit]


class HTMAPROLES(BaseModel):

    id: List[]
    role_i_d: Optional[int]
    tinh_trang_i_d: Optional[int]


class HTMAYQUET(BaseModel):

    id: int
    ma: Optional[nvarchar]
    ten: Optional[nvarchar]


class HTNCMLOAIDANGKY(BaseModel):

    ma_loai_dang_ky: int
    ten_loai_dang_ky: Optional[nvarchar]
    mo_ta: Optional[nvarchar]
    su_dung: Optional[bit]


class HTNHANCHAMECON(BaseModel):

    id: List[]
    so: Optional[nvarchar]
    quyen_so: Optional[nvarchar]
    trang_so: Optional[nvarchar]
    quyet_dinh_so: Optional[nvarchar]
    ngay_dang_ky: Optional[nvarchar]
    loai_dang_ky: Optional[int]
    loai_xac_nhan: Optional[int]
    noi_dang_ky: Optional[nvarchar]
    cm_ho_ten: Optional[nvarchar]
    cm_ngay_sinh: Optional[nvarchar]
    cm_dan_toc: Optional[nvarchar]
    cm_quoc_tich: Optional[nvarchar]
    cm_loai_cu_tru: Optional[int]
    cm_loai_giay_to_tuy_than: Optional[int]
    cm_so_giay_to_tuy_than: Optional[nvarchar]
    nc_ho_ten: Optional[nvarchar]
    nc_ngay_sinh: Optional[nvarchar]
    nc_dan_toc: Optional[nvarchar]
    nc_quoc_tich: Optional[nvarchar]
    nc_loai_cu_tru: Optional[int]
    nc_loai_giay_to_tuy_than: Optional[int]
    nc_so_giay_to_tuy_than: Optional[nvarchar]
    tinh_trang_i_d: Optional[int]
    ten_file: Optional[nvarchar]
    ten_file_sau_upload: Optional[nvarchar]
    u_r_l_tap_tin_dinh_kem: Optional[nvarchar]
    nam_mo_so: Optional[nvarchar]
    loai_giay: Optional[nvarchar]
    du_lieu_cu: Optional[bit]
    ngay_cap_nhat: Optional[datetime.datetime]
    ghichu: Optional[nvarchar]
    cm_noi_cu_tru: Optional[nvarchar]
    nc_noi_cu_tru: Optional[nvarchar]
    nyc_ho_ten: Optional[nvarchar]
    nyc_q_h_nguoi_duoc_nhan: Optional[nvarchar]
    nguoi_ky: Optional[nvarchar]
    chuc_vu_nguoi_ky: Optional[nvarchar]
    nguoi_thuc_hien: Optional[nvarchar]
    cm_que_quan: Optional[nvarchar]
    cm_ngay_cap_giay_to_tuy_than: Optional[nvarchar]
    cm_noi_cap_giay_to_tuy_than: Optional[nvarchar]
    nc_que_quan: Optional[nvarchar]
    nc_ngay_cap_giay_to_tuy_than: Optional[nvarchar]
    nc_noi_cap_giay_to_tuy_than: Optional[nvarchar]
    nyc_loai_giay_to_tuy_than: Optional[int]
    nyc_so_giay_to_tuy_than: Optional[nvarchar]
    nyc_ngay_cap_giay_to_tuy_than: Optional[nvarchar]
    nyc_noi_cap_giay_to_tuy_than: Optional[nvarchar]


class HTNHANCHAMECON2(BaseModel):

    id: List[]
    so: Optional[nvarchar]
    quyen_so: Optional[nvarchar]
    trang_so: Optional[nvarchar]
    quyet_dinh_so: Optional[nvarchar]
    ngay_dang_ky: Optional[nvarchar]
    loai_dang_ky: Optional[int]
    loai_xac_nhan: Optional[int]
    noi_dang_ky: Optional[nvarchar]
    cm_ho_ten: Optional[nvarchar]
    cm_ngay_sinh: Optional[nvarchar]
    cm_dan_toc: Optional[nvarchar]
    cm_quoc_tich: Optional[nvarchar]
    cm_loai_cu_tru: Optional[int]
    cm_loai_giay_to_tuy_than: Optional[int]
    cm_so_giay_to_tuy_than: Optional[nvarchar]
    nc_ho_ten: Optional[nvarchar]
    nc_ngay_sinh: Optional[nvarchar]
    nc_dan_toc: Optional[nvarchar]
    nc_quoc_tich: Optional[nvarchar]
    nc_loai_cu_tru: Optional[int]
    nc_loai_giay_to_tuy_than: Optional[int]
    nc_so_giay_to_tuy_than: Optional[nvarchar]
    tinh_trang_i_d: Optional[int]
    ten_file: Optional[nvarchar]
    ten_file_sau_upload: Optional[nvarchar]
    u_r_l_tap_tin_dinh_kem: Optional[nvarchar]
    n_c_m_i_d: Optional[int]


class HTOCR(BaseModel):

    id: List[]
    noi_dang_ky_i_d: Optional[nvarchar]
    nam_mo_so: Optional[int]
    quyen_so: Optional[nvarchar]
    loai_ho_so_i_d: Optional[int]
    tinh_trang_o_c_r_i_d: Optional[int]


class HTTinhNoiSinh(BaseModel):

    ma: Optional[float]
    ten: Optional[nvarchar]


class HTTINHTRANGQUET(BaseModel):

    id: int
    ma: Optional[nvarchar]
    ten: Optional[nvarchar]


class HTTINHTRANGOCR(BaseModel):

    id: int
    ma_tinh_trang: Optional[nvarchar]
    ten_tinh_trang: Optional[nvarchar]


class HTXACNHANHONNHAN(BaseModel):

    id: List[]
    so: Optional[nvarchar]
    quyen_so: Optional[nvarchar]
    trang_so: Optional[nvarchar]
    ngay_dang_ky: Optional[nvarchar]
    noi_cap: Optional[nvarchar]
    nguoi_ky: Optional[nvarchar]
    chuc_vu_nguoi_ky: Optional[nvarchar]
    nguoi_thuc_hien: Optional[nvarchar]
    ghi_chu: Optional[nvarchar]
    nxn_ho_ten: Optional[nvarchar]
    nxn_gioi_tinh: Optional[nvarchar]
    nxn_ngay_sinh: Optional[nvarchar]
    nxn_dan_toc: Optional[nvarchar]
    nxn_quoc_tich: Optional[nvarchar]
    nxn_quoc_tich_khac: Optional[nvarchar]
    nxn_loai_cu_tru: Optional[int]
    nxn_noi_cu_tru: Optional[nvarchar]
    nxn_loai_giay_to_tuy_than: Optional[int]
    nxn_giay_to_khac: Optional[nvarchar]
    nxn_so_giay_to_tuy_than: Optional[nvarchar]
    nxn_ngay_cap_giay_to_tuy_than: Optional[nvarchar]
    nxn_noi_cap_giay_to_tuy_than: Optional[nvarchar]
    nxn_thoi_gian_cu_tru_tai: Optional[nvarchar]
    nxn_thoi_gian_cu_tru_tu: Optional[nvarchar]
    nxn_thoi_gian_cu_tru_den: Optional[nvarchar]
    nxn_tinh_trang_hon_nhan: Optional[nvarchar]
    nxn_loai_muc_dich_su_dung: Optional[int]
    nxn_muc_dich_su_dung: Optional[nvarchar]
    nyc_ho_ten: Optional[nvarchar]
    nyc_quan_he: Optional[nvarchar]
    nyc_loai_giay_to_tuy_than: Optional[int]
    nyc_giay_to_khac: Optional[nvarchar]
    nyc_so_giay_to_tuy_than: Optional[nvarchar]
    nyc_ngay_cap_giay_to_khac: Optional[nvarchar]
    nyc_noi_cap_giay_to_khac: Optional[nvarchar]
    tinh_trang_i_d: Optional[int]
    ten_file: Optional[nvarchar]
    ten_file_sau_upload: Optional[nvarchar]
    u_r_l_tap_tin_dinh_kem: Optional[nvarchar]
    nam_mo_so: Optional[nvarchar]
    loai_giay: Optional[nvarchar]
    ngay_cap_nhat: Optional[datetime.datetime]


class HTXULY(BaseModel):

    q_t_x_l_i_d: List[]
    object_i_d: Optional[int]
    ngay_xu_ly: Optional[datetime.datetime]
    nguoi_xu_ly_i_d: Optional[int]
    ghi_chu: Optional[nvarchar]
    noi_dung_xu_ly: Optional[nvarchar]
    is_leaf: Optional[str]
    parrent_i_d: Optional[int]
    tinh_trang_i_d: Optional[int]
    table_name: Optional[nvarchar]
    t_n: Optional[str]


class PARAM(BaseModel):

    code: nvarchar
    name: Optional[nvarchar]
    value: Optional[nvarchar]


class PMLSYSPREFIX(BaseModel):

    id: float
    prefix: str
    table_name: Optional[str]
    description: Optional[str]


class QTXLCMC(BaseModel):

    id: List[]
    so: Optional[nvarchar]
    quyen_so: Optional[nvarchar]
    trang_so: Optional[nvarchar]
    quyet_dinh_so: Optional[nvarchar]
    ngay_dang_ky: Optional[nvarchar]
    loai_dang_ky: Optional[int]
    loai_xac_nhan: Optional[int]
    noi_dang_ky: Optional[nvarchar]
    cm_ho_ten: Optional[nvarchar]
    cm_ngay_sinh: Optional[nvarchar]
    cm_dan_toc: Optional[nvarchar]
    cm_quoc_tich: Optional[nvarchar]
    cm_loai_cu_tru: Optional[int]
    cm_loai_giay_to_tuy_than: Optional[int]
    cm_so_giay_to_tuy_than: Optional[nvarchar]
    nc_ho_ten: Optional[nvarchar]
    nc_ngay_sinh: Optional[nvarchar]
    nc_dan_toc: Optional[nvarchar]
    nc_quoc_tich: Optional[nvarchar]
    nc_loai_cu_tru: Optional[int]
    nc_loai_giay_to_tuy_than: Optional[int]
    nc_so_giay_to_tuy_than: Optional[nvarchar]
    tinh_trang_i_d: Optional[int]
    ten_file: Optional[nvarchar]
    ten_file_sau_upload: Optional[nvarchar]
    u_r_l_tap_tin_dinh_kem: Optional[nvarchar]
    nam_mo_so: Optional[nvarchar]
    loai_giay: Optional[nvarchar]
    du_lieu_cu: Optional[bit]
    ngay_cap_nhat: Optional[datetime.datetime]
    ghi_chu: Optional[nvarchar]
    cm_noi_cu_tru: Optional[nvarchar]
    nc_noi_cu_tru: Optional[nvarchar]
    nyc_ho_ten: Optional[nvarchar]
    nyc_q_h_nguoi_duoc_nhan: Optional[nvarchar]
    nguoi_ky: Optional[nvarchar]
    chuc_vu_nguoi_ky: Optional[nvarchar]
    nguoi_thuc_hien: Optional[nvarchar]
    cm_que_quan: Optional[nvarchar]
    cm_ngay_cap_giay_to_tuy_than: Optional[nvarchar]
    cm_noi_cap_giay_to_tuy_than: Optional[nvarchar]
    nc_que_quan: Optional[nvarchar]
    nc_ngay_cap_giay_to_tuy_than: Optional[nvarchar]
    nc_noi_cap_giay_to_tuy_than: Optional[nvarchar]
    nyc_loai_giay_to_tuy_than: Optional[int]
    nyc_so_giay_to_tuy_than: Optional[nvarchar]
    nyc_ngay_cap_giay_to_tuy_than: Optional[nvarchar]
    nyc_noi_cap_giay_to_tuy_than: Optional[nvarchar]


class QTXLKH(BaseModel):

    id: List[]
    so: Optional[nvarchar]
    quyen_so: Optional[nvarchar]
    trang_so: Optional[nvarchar]
    ngay_dang_ky: Optional[nvarchar]
    loai_dang_ky: Optional[int]
    noi_dang_ky: Optional[nvarchar]
    chong_ho_ten: Optional[nvarchar]
    chong_ngay_sinh: Optional[nvarchar]
    chong_dan_toc: Optional[nvarchar]
    chong_quoc_tich: Optional[nvarchar]
    chong_loai_cu_tru: Optional[int]
    chong_loai_giay_to_tuy_than: Optional[int]
    chong_so_giay_to_tuy_than: Optional[nvarchar]
    vo_ho_ten: Optional[nvarchar]
    vo_ngay_sinh: Optional[nvarchar]
    vo_dan_toc: Optional[nvarchar]
    vo_quoc_tich: Optional[nvarchar]
    vo_loai_cu_tru: Optional[int]
    vo_loai_giay_to_tuy_than: Optional[int]
    vo_so_giay_to_tuy_than: Optional[nvarchar]
    tinh_trang_i_d: Optional[int]
    ten_file: Optional[nvarchar]
    ten_file_sau_up_load: Optional[nvarchar]
    u_r_l_tap_tin_dinh_kem: Optional[nvarchar]
    nam_mo_so: Optional[nvarchar]
    loai_giay: Optional[nvarchar]
    du_lieu_cu: Optional[bit]
    ngay_cap_nhat: Optional[datetime.datetime]
    url_anh_cu: Optional[nvarchar]
    ghi_chu: Optional[nvarchar]
    chong_noi_cu_tru: Optional[nvarchar]
    vo_noi_cu_tru: Optional[nvarchar]
    nguoi_ky: Optional[nvarchar]
    chuc_vu_nguoi_ky: Optional[nvarchar]
    nguoi_thuc_hien: Optional[nvarchar]
    chong_ngay_cap_giay_to_tuy_than: Optional[nvarchar]
    chong_noi_cap_giay_to_tuy_than: Optional[nvarchar]
    vo_ngay_cap_giay_to_tuy_than: Optional[nvarchar]
    vo_noi_cap_giay_to_tuy_than: Optional[nvarchar]


class QTXLKS(BaseModel):

    id: List[]
    so: Optional[nvarchar]
    quyen_so: Optional[nvarchar]
    trang_so: Optional[nvarchar]
    ngay_dang_ky: Optional[nvarchar]
    loai_dang_ky: Optional[int]
    noi_dang_ky: Optional[nvarchar]
    nks_ho_ten: Optional[nvarchar]
    nks_gioi_tinh: Optional[nvarchar]
    nks_ngay_sinh: Optional[nvarchar]
    nks_dan_toc: Optional[nvarchar]
    nks_quoc_tich: Optional[nvarchar]
    me_ho_ten: Optional[nvarchar]
    me_ngay_sinh: Optional[nvarchar]
    me_dan_toc: Optional[nvarchar]
    me_quoc_tich: Optional[nvarchar]
    me_loai_cu_tru: Optional[int]
    cha_ho_ten: Optional[nvarchar]
    cha_ngay_sinh: Optional[nvarchar]
    cha_dan_toc: Optional[nvarchar]
    cha_quoc_tich: Optional[nvarchar]
    cha_loai_cu_tru: Optional[int]
    tinh_trang_i_d: Optional[int]
    ten_file: Optional[nvarchar]
    ten_file_sau_up_load: Optional[nvarchar]
    u_r_l_tap_tin_dinh_kem: Optional[nvarchar]
    nam_mo_so: Optional[nvarchar]
    du_lieu_cu: Optional[bit]
    ngay_cap_nhat: Optional[datetime.datetime]
    loai_giay: Optional[nvarchar]
    u_r_l_anh_cu: Optional[nvarchar]
    ghi_chu: Optional[nvarchar]
    nks_noi_sinh: Optional[nvarchar]
    me_noi_cu_tru: Optional[nvarchar]
    cha_noi_cu_tru: Optional[nvarchar]
    nyc_ho_ten: Optional[nvarchar]
    nyc_quan_he: Optional[nvarchar]
    nguoi_ky: Optional[nvarchar]
    chuc_vu_nguoi_ky: Optional[nvarchar]
    nguoi_thuc_hien: Optional[nvarchar]
    nks_loai_khai_sinh: Optional[int]
    nks_noi_sinh_d_v_h_c: Optional[nvarchar]
    nks_que_quan: Optional[nvarchar]
    nyc_loai_giay_to_tuy_than: Optional[int]
    nyc_so_giay_to_tuy_than: Optional[nvarchar]
    nyc_ngay_cap_giay_to_tuy_than: Optional[nvarchar]
    nyc_noi_cap_giay_to_tuy_than: Optional[nvarchar]
    nks_ngay_sinh_bang_chu: Optional[nvarchar]


class QTXLKT(BaseModel):

    id: List[]
    so: Optional[nvarchar]
    quyen_so: Optional[nvarchar]
    trang_so: Optional[nvarchar]
    ngay_dang_ky: Optional[nvarchar]
    loai_dang_ky: Optional[int]
    noi_dang_ky: Optional[nvarchar]
    nkt_ho_ten: Optional[nvarchar]
    nkt_gioi_tinh: Optional[nvarchar]
    nkt_ngay_sinh: Optional[nvarchar]
    nkt_dan_toc: Optional[nvarchar]
    nkt_quoc_tich: Optional[nvarchar]
    nkt_loai_cu_tru: Optional[int]
    nkt_loai_giay_to_tuy_than: Optional[int]
    nkt_so_giay_to_tuy_than: Optional[nvarchar]
    nkt_ngay_chet: Optional[nvarchar]
    tinh_trang_i_d: Optional[int]
    ten_file: Optional[nvarchar]
    ten_file_sau_upload: Optional[nvarchar]
    u_r_l_tap_tin_dinh_kem: Optional[nvarchar]
    nam_mo_so: Optional[nvarchar]
    loai_giay: Optional[nvarchar]
    du_lieu_cu: Optional[bit]
    ngay_cap_nhat: Optional[datetime.datetime]
    url_anh_cu: Optional[nvarchar]
    ghi_chu: Optional[nvarchar]
    nkt_gio_phut_chet: Optional[nvarchar]
    nkt_noi_chet: Optional[nvarchar]
    nkt_nguyen_nhan_chet: Optional[nvarchar]
    nkt_noi_cu_tru: Optional[nvarchar]
    nyc_ho_ten: Optional[nvarchar]
    nyc_quan_he: Optional[nvarchar]
    nguoi_ky: Optional[nvarchar]
    chuc_vu_nguoi_ky: Optional[nvarchar]
    nguoi_thuc_hien: Optional[nvarchar]
    nkt_ngay_cap_giay_to_tuy_than: Optional[nvarchar]
    nkt_noi_cap_giay_to_tuy_than: Optional[nvarchar]
    gbt_loai: Optional[int]
    gbt_so: Optional[nvarchar]
    gbt_ngay: Optional[nvarchar]
    gbt_co_quan_cap: Optional[nvarchar]
    nyc_loai_giay_to_tuy_than: Optional[int]
    nyc_so_giay_to_tuy_than: Optional[nvarchar]
    nyc_ngay_cap_giay_to_tuy_than: Optional[nvarchar]
    nyc_noi_cap_giay_to_tuy_than: Optional[nvarchar]


class Time(BaseModel):

    p_k__date: datetime.datetime
    date__name: Optional[nvarchar]
    year: Optional[datetime.datetime]
    year__name: Optional[nvarchar]
    day__of__year: Optional[int]
    day__of__year__name: Optional[nvarchar]


class USERTIMEEXPI(BaseModel):

    id: List[]
    user_i_d: Optional[int]
    time_expi: Optional[int]
