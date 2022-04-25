# This is an auto-generated Django model module.
# You'll have to do the following manually to clean this up:
#   * Rearrange models' order
#   * Make sure each model has one field with primary_key=True
#   * Make sure each ForeignKey and OneToOneField has `on_delete` set to the desired behavior
#   * Remove `managed = False` lines if you wish to allow Django to create, modify, and delete the table
# Feel free to rename the models, but don't rename db_table values or field names.
from django.db import models


class Danhsachpdf(models.Model):
    pathpdf = models.CharField(db_column='PathPDF', max_length=2000, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'DanhSachPDF'


class Duongdanxuly(models.Model):
    filepath = models.TextField(db_column='FilePath', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'DuongDanXuLy'


class Nguoidung(models.Model):
    id = models.AutoField(db_column='ID', primary_key = True)  # Field name made lowercase.
    tendangnhap = models.CharField(db_column='TenDangNhap', max_length=50, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    matkhau = models.CharField(db_column='MatKhau', max_length=50, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    trangthai = models.IntegerField(db_column='TrangThai', blank=True, null=True)  # Field name made lowercase.
    ngaytao = models.DateTimeField(db_column='NgayTao', blank=True, null=True)  # Field name made lowercase.
    ngaycapnhat = models.DateTimeField(db_column='NgayCapNhat', blank=True, null=True)  # Field name made lowercase.
    tendaydu = models.CharField(db_column='TenDayDu', max_length=50, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    quyen = models.IntegerField(db_column='Quyen', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'NguoiDung'


class Thongtinbienmuc(models.Model):
    id = models.AutoField(db_column='ID', unique=True, primary_key = True)  # Field name made lowercase.
    sovakyhieu = models.CharField(db_column='SoVaKyHieu', max_length=300, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    ngaybanhanh = models.CharField(db_column='NgayBanHanh', max_length=100, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    trichyeund = models.TextField(db_column='TrichYeuND', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    tacgiavb = models.CharField(db_column='TacGiaVB', max_length=300, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    toso = models.CharField(db_column='ToSo', max_length=50, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    ghichu = models.TextField(db_column='GhiChu', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    stt = models.CharField(db_column='STT', max_length=50, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    hopso = models.CharField(db_column='HopSo', max_length=50, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    hososo = models.CharField(db_column='HoSoSo', max_length=50, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    tieudehs = models.TextField(db_column='TieuDeHS', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    soluongto = models.CharField(db_column='SoLuongTo', max_length=50, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    thoihanbaoquan = models.CharField(db_column='ThoiHanBaoQuan', max_length=50, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    nam = models.CharField(db_column='Nam', max_length=50, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    phong = models.CharField(db_column='Phong', max_length=500, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    madinhdanh = models.CharField(db_column='MaDinhDanh', max_length=50, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    tenloaivb = models.CharField(db_column='TenLoaiVB', max_length=4000, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    muclucso = models.CharField(db_column='MucLucSo', max_length=500, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    sudung = models.BooleanField(db_column='SuDung', blank=True, null=True)  # Field name made lowercase.
    trangthai = models.IntegerField(db_column='TrangThai', blank=True, null=True)  # Field name made lowercase.
    thoigianbdkt = models.CharField(db_column='ThoiGianBDKT', max_length=500, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    ngaytao = models.DateTimeField(db_column='NgayTao', blank=True, null=True)  # Field name made lowercase.
    ngaycapnhat = models.DateTimeField(db_column='NgayCapNhat', blank=True, null=True)  # Field name made lowercase.
    idnguoidung = models.IntegerField(db_column='IdNguoiDung', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'ThongTinBienMuc'


class Thongtinbienmuc2(models.Model):
    id = models.AutoField(db_column='ID', primary_key = True)  # Field name made lowercase.
    sovakyhieu = models.CharField(db_column='SoVaKyHieu', max_length=300, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    ngaybanhanh = models.CharField(db_column='NgayBanHanh', max_length=100, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    trichyeund = models.TextField(db_column='TrichYeuND', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    tacgiavb = models.CharField(db_column='TacGiaVB', max_length=300, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    toso = models.CharField(db_column='ToSo', max_length=50, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    ghichu = models.TextField(db_column='GhiChu', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    stt = models.CharField(db_column='STT', max_length=50, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    hopso = models.CharField(db_column='HopSo', max_length=50, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    hososo = models.CharField(db_column='HoSoSo', max_length=50, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    tieudehs = models.TextField(db_column='TieuDeHS', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    soluongto = models.CharField(db_column='SoLuongTo', max_length=50, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    thoihanbaoquan = models.CharField(db_column='ThoiHanBaoQuan', max_length=50, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    nam = models.CharField(db_column='Nam', max_length=50, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    phong = models.CharField(db_column='Phong', max_length=500, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    madinhdanh = models.CharField(db_column='MaDinhDanh', max_length=50, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    tenloaivb = models.CharField(db_column='TenLoaiVB', max_length=4000, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    muclucso = models.CharField(db_column='MucLucSo', max_length=500, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    sudung = models.BooleanField(db_column='SuDung', blank=True, null=True)  # Field name made lowercase.
    trangthai = models.IntegerField(db_column='TrangThai', blank=True, null=True)  # Field name made lowercase.
    thoigianbdkt = models.CharField(db_column='ThoiGianBDKT', max_length=500, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    ngaytao = models.DateTimeField(db_column='NgayTao', blank=True, null=True)  # Field name made lowercase.
    ngaycapnhat = models.DateTimeField(db_column='NgayCapNhat', blank=True, null=True)  # Field name made lowercase.
    idnguoidung = models.IntegerField(db_column='IdNguoiDung', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'ThongTinBienMuc2'


class Thongtinbienmucna(models.Model):
    id = models.AutoField(db_column='ID', primary_key = True)  # Field name made lowercase.
    madinhdanh = models.CharField(db_column='MaDinhDanh', max_length=500, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    malinhvuc = models.CharField(db_column='MaLinhVuc', max_length=500, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    sohieuketqua = models.CharField(db_column='SoHieuKetQua', max_length=500, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    trichyeund = models.TextField(db_column='TrichYeuND', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    ngaycohieuluc = models.CharField(db_column='NgayCoHieuLuc', max_length=500, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    ngayhethieuluc = models.CharField(db_column='NgayHetHieuLuc', max_length=500, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    coquanbanhanh = models.CharField(db_column='CoQuanBanHanh', max_length=500, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    ngaybanhanhkq = models.CharField(db_column='NgayBanHanhKQ', max_length=500, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    tencanhantc = models.CharField(db_column='TenCaNhanTC', max_length=500, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    tenfile = models.CharField(db_column='TenFile', max_length=500, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    ghichu = models.TextField(db_column='GhiChu', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    theloai = models.CharField(db_column='TheLoai', max_length=500, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    trangthai = models.IntegerField(db_column='TrangThai', blank=True, null=True)  # Field name made lowercase.
    ngaytao = models.DateTimeField(db_column='NgayTao', blank=True, null=True)  # Field name made lowercase.
    ngaycapnhat = models.DateTimeField(db_column='NgayCapNhat', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'ThongTinBienMucNA'


class Vanban(models.Model):
    id = models.AutoField(db_column='ID', primary_key = True)  # Field name made lowercase.
    idthongtin = models.IntegerField(db_column='IDThongTin', blank=True, null=True)  # Field name made lowercase.
    tenvanban = models.CharField(db_column='TenVanBan', max_length=500, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    path = models.CharField(db_column='Path', max_length=4000, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    ngaytao = models.DateTimeField(db_column='NgayTao', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'VanBan'


class Vanbanna(models.Model):
    id = models.AutoField(db_column='ID', primary_key = True)  # Field name made lowercase.
    idthongtin = models.IntegerField(db_column='IDThongTin', blank=True, null=True)  # Field name made lowercase.
    tenvanban = models.CharField(db_column='TenVanBan', max_length=50, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    path = models.CharField(db_column='Path', max_length=50, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    ngaytao = models.DateTimeField(db_column='NgayTao', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'VanBanNA'


class AuthGroup(models.Model):
    name = models.CharField(unique=True, max_length=150, db_collation='SQL_Latin1_General_CP1_CI_AS')

    class Meta:
        managed = False
        db_table = 'auth_group'


class AuthGroupPermissions(models.Model):
    id = models.BigAutoField(primary_key=True)
    group = models.ForeignKey(AuthGroup, models.DO_NOTHING)
    permission = models.ForeignKey('AuthPermission', models.DO_NOTHING)

    class Meta:
        managed = False
        db_table = 'auth_group_permissions'
        unique_together = (('group', 'permission'),)


class AuthPermission(models.Model):
    name = models.CharField(max_length=255, db_collation='SQL_Latin1_General_CP1_CI_AS')
    content_type = models.ForeignKey('DjangoContentType', models.DO_NOTHING)
    codename = models.CharField(max_length=100, db_collation='SQL_Latin1_General_CP1_CI_AS')

    class Meta:
        managed = False
        db_table = 'auth_permission'
        unique_together = (('content_type', 'codename'),)


class AuthUser(models.Model):
    password = models.CharField(max_length=128, db_collation='SQL_Latin1_General_CP1_CI_AS')
    last_login = models.DateTimeField(blank=True, null=True)
    is_superuser = models.BooleanField()
    username = models.CharField(unique=True, max_length=150, db_collation='SQL_Latin1_General_CP1_CI_AS')
    first_name = models.CharField(max_length=150, db_collation='SQL_Latin1_General_CP1_CI_AS')
    last_name = models.CharField(max_length=150, db_collation='SQL_Latin1_General_CP1_CI_AS')
    email = models.CharField(max_length=254, db_collation='SQL_Latin1_General_CP1_CI_AS')
    is_staff = models.BooleanField()
    is_active = models.BooleanField()
    date_joined = models.DateTimeField()

    class Meta:
        managed = False
        db_table = 'auth_user'


class AuthUserGroups(models.Model):
    id = models.BigAutoField(primary_key=True)
    user = models.ForeignKey(AuthUser, models.DO_NOTHING)
    group = models.ForeignKey(AuthGroup, models.DO_NOTHING)

    class Meta:
        managed = False
        db_table = 'auth_user_groups'
        unique_together = (('user', 'group'),)


class AuthUserUserPermissions(models.Model):
    id = models.BigAutoField(primary_key=True)
    user = models.ForeignKey(AuthUser, models.DO_NOTHING)
    permission = models.ForeignKey(AuthPermission, models.DO_NOTHING)

    class Meta:
        managed = False
        db_table = 'auth_user_user_permissions'
        unique_together = (('user', 'permission'),)


class DjangoAdminLog(models.Model):
    action_time = models.DateTimeField()
    object_id = models.TextField(db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)
    object_repr = models.CharField(max_length=200, db_collation='SQL_Latin1_General_CP1_CI_AS')
    action_flag = models.SmallIntegerField()
    change_message = models.TextField(db_collation='SQL_Latin1_General_CP1_CI_AS')
    content_type = models.ForeignKey('DjangoContentType', models.DO_NOTHING, blank=True, null=True)
    user = models.ForeignKey(AuthUser, models.DO_NOTHING)

    class Meta:
        managed = False
        db_table = 'django_admin_log'


class DjangoContentType(models.Model):
    app_label = models.CharField(max_length=100, db_collation='SQL_Latin1_General_CP1_CI_AS')
    model = models.CharField(max_length=100, db_collation='SQL_Latin1_General_CP1_CI_AS')

    class Meta:
        managed = False
        db_table = 'django_content_type'
        unique_together = (('app_label', 'model'),)


class DjangoMigrations(models.Model):
    id = models.BigAutoField(primary_key=True)
    app = models.CharField(max_length=255, db_collation='SQL_Latin1_General_CP1_CI_AS')
    name = models.CharField(max_length=255, db_collation='SQL_Latin1_General_CP1_CI_AS')
    applied = models.DateTimeField()

    class Meta:
        managed = False
        db_table = 'django_migrations'


class DjangoSession(models.Model):
    session_key = models.CharField(primary_key=True, max_length=40, db_collation='SQL_Latin1_General_CP1_CI_AS')
    session_data = models.TextField(db_collation='SQL_Latin1_General_CP1_CI_AS')
    expire_date = models.DateTimeField()

    class Meta:
        managed = False
        db_table = 'django_session'