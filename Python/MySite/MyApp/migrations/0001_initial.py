# Generated by Django 4.0.3 on 2022-04-01 04:41

from django.db import migrations, models


class Migration(migrations.Migration):

    initial = True

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='AuthGroup',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('name', models.CharField(db_collation='SQL_Latin1_General_CP1_CI_AS', max_length=150, unique=True)),
            ],
            options={
                'db_table': 'auth_group',
                'managed': False,
            },
        ),
        migrations.CreateModel(
            name='AuthGroupPermissions',
            fields=[
                ('id', models.BigAutoField(primary_key=True, serialize=False)),
            ],
            options={
                'db_table': 'auth_group_permissions',
                'managed': False,
            },
        ),
        migrations.CreateModel(
            name='AuthPermission',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('name', models.CharField(db_collation='SQL_Latin1_General_CP1_CI_AS', max_length=255)),
                ('codename', models.CharField(db_collation='SQL_Latin1_General_CP1_CI_AS', max_length=100)),
            ],
            options={
                'db_table': 'auth_permission',
                'managed': False,
            },
        ),
        migrations.CreateModel(
            name='AuthUser',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('password', models.CharField(db_collation='SQL_Latin1_General_CP1_CI_AS', max_length=128)),
                ('last_login', models.DateTimeField(blank=True, null=True)),
                ('is_superuser', models.BooleanField()),
                ('username', models.CharField(db_collation='SQL_Latin1_General_CP1_CI_AS', max_length=150, unique=True)),
                ('first_name', models.CharField(db_collation='SQL_Latin1_General_CP1_CI_AS', max_length=150)),
                ('last_name', models.CharField(db_collation='SQL_Latin1_General_CP1_CI_AS', max_length=150)),
                ('email', models.CharField(db_collation='SQL_Latin1_General_CP1_CI_AS', max_length=254)),
                ('is_staff', models.BooleanField()),
                ('is_active', models.BooleanField()),
                ('date_joined', models.DateTimeField()),
            ],
            options={
                'db_table': 'auth_user',
                'managed': False,
            },
        ),
        migrations.CreateModel(
            name='AuthUserGroups',
            fields=[
                ('id', models.BigAutoField(primary_key=True, serialize=False)),
            ],
            options={
                'db_table': 'auth_user_groups',
                'managed': False,
            },
        ),
        migrations.CreateModel(
            name='AuthUserUserPermissions',
            fields=[
                ('id', models.BigAutoField(primary_key=True, serialize=False)),
            ],
            options={
                'db_table': 'auth_user_user_permissions',
                'managed': False,
            },
        ),
        migrations.CreateModel(
            name='Danhsachpdf',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('pathpdf', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='PathPDF', max_length=2000, null=True)),
            ],
            options={
                'db_table': 'DanhSachPDF',
                'managed': False,
            },
        ),
        migrations.CreateModel(
            name='DjangoAdminLog',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('action_time', models.DateTimeField()),
                ('object_id', models.TextField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', null=True)),
                ('object_repr', models.CharField(db_collation='SQL_Latin1_General_CP1_CI_AS', max_length=200)),
                ('action_flag', models.SmallIntegerField()),
                ('change_message', models.TextField(db_collation='SQL_Latin1_General_CP1_CI_AS')),
            ],
            options={
                'db_table': 'django_admin_log',
                'managed': False,
            },
        ),
        migrations.CreateModel(
            name='DjangoContentType',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('app_label', models.CharField(db_collation='SQL_Latin1_General_CP1_CI_AS', max_length=100)),
                ('model', models.CharField(db_collation='SQL_Latin1_General_CP1_CI_AS', max_length=100)),
            ],
            options={
                'db_table': 'django_content_type',
                'managed': False,
            },
        ),
        migrations.CreateModel(
            name='DjangoMigrations',
            fields=[
                ('id', models.BigAutoField(primary_key=True, serialize=False)),
                ('app', models.CharField(db_collation='SQL_Latin1_General_CP1_CI_AS', max_length=255)),
                ('name', models.CharField(db_collation='SQL_Latin1_General_CP1_CI_AS', max_length=255)),
                ('applied', models.DateTimeField()),
            ],
            options={
                'db_table': 'django_migrations',
                'managed': False,
            },
        ),
        migrations.CreateModel(
            name='DjangoSession',
            fields=[
                ('session_key', models.CharField(db_collation='SQL_Latin1_General_CP1_CI_AS', max_length=40, primary_key=True, serialize=False)),
                ('session_data', models.TextField(db_collation='SQL_Latin1_General_CP1_CI_AS')),
                ('expire_date', models.DateTimeField()),
            ],
            options={
                'db_table': 'django_session',
                'managed': False,
            },
        ),
        migrations.CreateModel(
            name='Duongdanxuly',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('filepath', models.TextField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='FilePath', null=True)),
            ],
            options={
                'db_table': 'DuongDanXuLy',
                'managed': False,
            },
        ),
        migrations.CreateModel(
            name='Nguoidung',
            fields=[
                ('id', models.AutoField(db_column='ID', primary_key=True, serialize=False)),
                ('tendangnhap', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='TenDangNhap', max_length=50, null=True)),
                ('matkhau', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='MatKhau', max_length=50, null=True)),
                ('trangthai', models.IntegerField(blank=True, db_column='TrangThai', null=True)),
                ('ngaytao', models.DateTimeField(blank=True, db_column='NgayTao', null=True)),
                ('ngaycapnhat', models.DateTimeField(blank=True, db_column='NgayCapNhat', null=True)),
                ('tendaydu', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='TenDayDu', max_length=50, null=True)),
                ('quyen', models.IntegerField(blank=True, db_column='Quyen', null=True)),
            ],
            options={
                'db_table': 'NguoiDung',
                'managed': False,
            },
        ),
        migrations.CreateModel(
            name='Thongtinbienmuc',
            fields=[
                ('id', models.AutoField(db_column='ID', primary_key=True, serialize=False, unique=True)),
                ('sovakyhieu', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='SoVaKyHieu', max_length=300, null=True)),
                ('ngaybanhanh', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='NgayBanHanh', max_length=100, null=True)),
                ('trichyeund', models.TextField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='TrichYeuND', null=True)),
                ('tacgiavb', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='TacGiaVB', max_length=300, null=True)),
                ('toso', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='ToSo', max_length=50, null=True)),
                ('ghichu', models.TextField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='GhiChu', null=True)),
                ('stt', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='STT', max_length=50, null=True)),
                ('hopso', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='HopSo', max_length=50, null=True)),
                ('hososo', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='HoSoSo', max_length=50, null=True)),
                ('tieudehs', models.TextField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='TieuDeHS', null=True)),
                ('soluongto', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='SoLuongTo', max_length=50, null=True)),
                ('thoihanbaoquan', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='ThoiHanBaoQuan', max_length=50, null=True)),
                ('nam', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='Nam', max_length=50, null=True)),
                ('phong', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='Phong', max_length=500, null=True)),
                ('madinhdanh', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='MaDinhDanh', max_length=50, null=True)),
                ('tenloaivb', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='TenLoaiVB', max_length=4000, null=True)),
                ('muclucso', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='MucLucSo', max_length=500, null=True)),
                ('sudung', models.BooleanField(blank=True, db_column='SuDung', null=True)),
                ('trangthai', models.IntegerField(blank=True, db_column='TrangThai', null=True)),
                ('thoigianbdkt', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='ThoiGianBDKT', max_length=500, null=True)),
                ('ngaytao', models.DateTimeField(blank=True, db_column='NgayTao', null=True)),
                ('ngaycapnhat', models.DateTimeField(blank=True, db_column='NgayCapNhat', null=True)),
                ('idnguoidung', models.IntegerField(blank=True, db_column='IdNguoiDung', null=True)),
            ],
            options={
                'db_table': 'ThongTinBienMuc',
                'managed': False,
            },
        ),
        migrations.CreateModel(
            name='Thongtinbienmuc2',
            fields=[
                ('id', models.AutoField(db_column='ID', primary_key=True, serialize=False)),
                ('sovakyhieu', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='SoVaKyHieu', max_length=300, null=True)),
                ('ngaybanhanh', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='NgayBanHanh', max_length=100, null=True)),
                ('trichyeund', models.TextField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='TrichYeuND', null=True)),
                ('tacgiavb', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='TacGiaVB', max_length=300, null=True)),
                ('toso', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='ToSo', max_length=50, null=True)),
                ('ghichu', models.TextField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='GhiChu', null=True)),
                ('stt', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='STT', max_length=50, null=True)),
                ('hopso', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='HopSo', max_length=50, null=True)),
                ('hososo', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='HoSoSo', max_length=50, null=True)),
                ('tieudehs', models.TextField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='TieuDeHS', null=True)),
                ('soluongto', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='SoLuongTo', max_length=50, null=True)),
                ('thoihanbaoquan', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='ThoiHanBaoQuan', max_length=50, null=True)),
                ('nam', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='Nam', max_length=50, null=True)),
                ('phong', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='Phong', max_length=500, null=True)),
                ('madinhdanh', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='MaDinhDanh', max_length=50, null=True)),
                ('tenloaivb', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='TenLoaiVB', max_length=4000, null=True)),
                ('muclucso', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='MucLucSo', max_length=500, null=True)),
                ('sudung', models.BooleanField(blank=True, db_column='SuDung', null=True)),
                ('trangthai', models.IntegerField(blank=True, db_column='TrangThai', null=True)),
                ('thoigianbdkt', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='ThoiGianBDKT', max_length=500, null=True)),
                ('ngaytao', models.DateTimeField(blank=True, db_column='NgayTao', null=True)),
                ('ngaycapnhat', models.DateTimeField(blank=True, db_column='NgayCapNhat', null=True)),
                ('idnguoidung', models.IntegerField(blank=True, db_column='IdNguoiDung', null=True)),
            ],
            options={
                'db_table': 'ThongTinBienMuc2',
                'managed': False,
            },
        ),
        migrations.CreateModel(
            name='Thongtinbienmucna',
            fields=[
                ('id', models.AutoField(db_column='ID', primary_key=True, serialize=False)),
                ('madinhdanh', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='MaDinhDanh', max_length=500, null=True)),
                ('malinhvuc', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='MaLinhVuc', max_length=500, null=True)),
                ('sohieuketqua', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='SoHieuKetQua', max_length=500, null=True)),
                ('trichyeund', models.TextField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='TrichYeuND', null=True)),
                ('ngaycohieuluc', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='NgayCoHieuLuc', max_length=500, null=True)),
                ('ngayhethieuluc', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='NgayHetHieuLuc', max_length=500, null=True)),
                ('coquanbanhanh', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='CoQuanBanHanh', max_length=500, null=True)),
                ('ngaybanhanhkq', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='NgayBanHanhKQ', max_length=500, null=True)),
                ('tencanhantc', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='TenCaNhanTC', max_length=500, null=True)),
                ('tenfile', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='TenFile', max_length=500, null=True)),
                ('ghichu', models.TextField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='GhiChu', null=True)),
                ('theloai', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='TheLoai', max_length=500, null=True)),
                ('trangthai', models.IntegerField(blank=True, db_column='TrangThai', null=True)),
                ('ngaytao', models.DateTimeField(blank=True, db_column='NgayTao', null=True)),
                ('ngaycapnhat', models.DateTimeField(blank=True, db_column='NgayCapNhat', null=True)),
            ],
            options={
                'db_table': 'ThongTinBienMucNA',
                'managed': False,
            },
        ),
        migrations.CreateModel(
            name='Vanban',
            fields=[
                ('id', models.AutoField(db_column='ID', primary_key=True, serialize=False)),
                ('idthongtin', models.IntegerField(blank=True, db_column='IDThongTin', null=True)),
                ('tenvanban', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='TenVanBan', max_length=500, null=True)),
                ('path', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='Path', max_length=4000, null=True)),
                ('ngaytao', models.DateTimeField(blank=True, db_column='NgayTao', null=True)),
            ],
            options={
                'db_table': 'VanBan',
                'managed': False,
            },
        ),
        migrations.CreateModel(
            name='Vanbanna',
            fields=[
                ('id', models.AutoField(db_column='ID', primary_key=True, serialize=False)),
                ('idthongtin', models.IntegerField(blank=True, db_column='IDThongTin', null=True)),
                ('tenvanban', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='TenVanBan', max_length=50, null=True)),
                ('path', models.CharField(blank=True, db_collation='SQL_Latin1_General_CP1_CI_AS', db_column='Path', max_length=50, null=True)),
                ('ngaytao', models.DateTimeField(blank=True, db_column='NgayTao', null=True)),
            ],
            options={
                'db_table': 'VanBanNA',
                'managed': False,
            },
        ),
    ]