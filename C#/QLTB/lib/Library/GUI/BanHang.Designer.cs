namespace GUI
{
    partial class BanHang
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnBanHang = new System.Windows.Forms.Panel();
            this.btnThanhtien = new System.Windows.Forms.Button();
            this.datengaymua = new System.Windows.Forms.DateTimePicker();
            this.cbchungloaibanh = new System.Windows.Forms.ComboBox();
            this.btntimkiemkh = new System.Windows.Forms.Button();
            this.btnxoakh = new System.Windows.Forms.Button();
            this.btnthemkh = new System.Windows.Forms.Button();
            this.txttimkiemkh = new System.Windows.Forms.TextBox();
            this.txttenkh = new System.Windows.Forms.TextBox();
            this.btnsuakh = new System.Windows.Forms.Button();
            this.dgvBH = new System.Windows.Forms.DataGridView();
            this.MaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayMuaHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChungLoaiBanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtthanhtoan = new System.Windows.Forms.TextBox();
            this.txtgia = new System.Windows.Forms.TextBox();
            this.txtsoluongban = new System.Windows.Forms.TextBox();
            this.txtmanv = new System.Windows.Forms.TextBox();
            this.txtsdtkh = new System.Windows.Forms.TextBox();
            this.txtdiachikh = new System.Windows.Forms.TextBox();
            this.txtmakh = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.pnBanHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBH)).BeginInit();
            this.SuspendLayout();
            // 
            // pnBanHang
            // 
            this.pnBanHang.Controls.Add(this.btnThanhtien);
            this.pnBanHang.Controls.Add(this.datengaymua);
            this.pnBanHang.Controls.Add(this.cbchungloaibanh);
            this.pnBanHang.Controls.Add(this.btntimkiemkh);
            this.pnBanHang.Controls.Add(this.btnxoakh);
            this.pnBanHang.Controls.Add(this.btnthemkh);
            this.pnBanHang.Controls.Add(this.txttimkiemkh);
            this.pnBanHang.Controls.Add(this.txttenkh);
            this.pnBanHang.Controls.Add(this.btnsuakh);
            this.pnBanHang.Controls.Add(this.dgvBH);
            this.pnBanHang.Controls.Add(this.label14);
            this.pnBanHang.Controls.Add(this.label15);
            this.pnBanHang.Controls.Add(this.label16);
            this.pnBanHang.Controls.Add(this.label17);
            this.pnBanHang.Controls.Add(this.label30);
            this.pnBanHang.Controls.Add(this.label18);
            this.pnBanHang.Controls.Add(this.label19);
            this.pnBanHang.Controls.Add(this.label20);
            this.pnBanHang.Controls.Add(this.label21);
            this.pnBanHang.Controls.Add(this.txtthanhtoan);
            this.pnBanHang.Controls.Add(this.txtgia);
            this.pnBanHang.Controls.Add(this.txtsoluongban);
            this.pnBanHang.Controls.Add(this.txtmanv);
            this.pnBanHang.Controls.Add(this.txtsdtkh);
            this.pnBanHang.Controls.Add(this.txtdiachikh);
            this.pnBanHang.Controls.Add(this.txtmakh);
            this.pnBanHang.Controls.Add(this.label22);
            this.pnBanHang.Location = new System.Drawing.Point(2, 2);
            this.pnBanHang.Margin = new System.Windows.Forms.Padding(2);
            this.pnBanHang.Name = "pnBanHang";
            this.pnBanHang.Size = new System.Drawing.Size(607, 452);
            this.pnBanHang.TabIndex = 40;
            // 
            // btnThanhtien
            // 
            this.btnThanhtien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThanhtien.ForeColor = System.Drawing.Color.Crimson;
            this.btnThanhtien.Location = new System.Drawing.Point(348, 168);
            this.btnThanhtien.Margin = new System.Windows.Forms.Padding(2);
            this.btnThanhtien.Name = "btnThanhtien";
            this.btnThanhtien.Size = new System.Drawing.Size(85, 25);
            this.btnThanhtien.TabIndex = 34;
            this.btnThanhtien.Text = "Thành Tiền";
            this.btnThanhtien.UseVisualStyleBackColor = true;
            this.btnThanhtien.Click += new System.EventHandler(this.btnThanhtien_Click);
            // 
            // datengaymua
            // 
            this.datengaymua.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datengaymua.Location = new System.Drawing.Point(453, 39);
            this.datengaymua.Name = "datengaymua";
            this.datengaymua.Size = new System.Drawing.Size(142, 20);
            this.datengaymua.TabIndex = 33;
            // 
            // cbchungloaibanh
            // 
            this.cbchungloaibanh.FormattingEnabled = true;
            this.cbchungloaibanh.Location = new System.Drawing.Point(453, 71);
            this.cbchungloaibanh.Name = "cbchungloaibanh";
            this.cbchungloaibanh.Size = new System.Drawing.Size(142, 21);
            this.cbchungloaibanh.TabIndex = 32;
            this.cbchungloaibanh.SelectedIndexChanged += new System.EventHandler(this.cbchungloaibanh_SelectedIndexChanged);
            // 
            // btntimkiemkh
            // 
            this.btntimkiemkh.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntimkiemkh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btntimkiemkh.Location = new System.Drawing.Point(21, 216);
            this.btntimkiemkh.Name = "btntimkiemkh";
            this.btntimkiemkh.Size = new System.Drawing.Size(85, 31);
            this.btntimkiemkh.TabIndex = 31;
            this.btntimkiemkh.Text = "Tìm Kiếm";
            this.btntimkiemkh.UseVisualStyleBackColor = true;
            this.btntimkiemkh.Click += new System.EventHandler(this.btntimkiemkh_Click);
            // 
            // btnxoakh
            // 
            this.btnxoakh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnxoakh.ForeColor = System.Drawing.Color.Green;
            this.btnxoakh.Location = new System.Drawing.Point(495, 216);
            this.btnxoakh.Name = "btnxoakh";
            this.btnxoakh.Size = new System.Drawing.Size(73, 32);
            this.btnxoakh.TabIndex = 30;
            this.btnxoakh.Text = "Xóa";
            this.btnxoakh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnxoakh.UseVisualStyleBackColor = true;
            this.btnxoakh.Click += new System.EventHandler(this.btnxoakh_Click);
            // 
            // btnthemkh
            // 
            this.btnthemkh.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnthemkh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnthemkh.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnthemkh.Location = new System.Drawing.Point(320, 216);
            this.btnthemkh.Name = "btnthemkh";
            this.btnthemkh.Size = new System.Drawing.Size(80, 31);
            this.btnthemkh.TabIndex = 29;
            this.btnthemkh.Text = "Thêm";
            this.btnthemkh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnthemkh.UseVisualStyleBackColor = true;
            this.btnthemkh.Click += new System.EventHandler(this.btnthemkh_Click);
            // 
            // txttimkiemkh
            // 
            this.txttimkiemkh.Location = new System.Drawing.Point(123, 216);
            this.txttimkiemkh.Multiline = true;
            this.txttimkiemkh.Name = "txttimkiemkh";
            this.txttimkiemkh.Size = new System.Drawing.Size(119, 33);
            this.txttimkiemkh.TabIndex = 27;
            // 
            // txttenkh
            // 
            this.txttenkh.Location = new System.Drawing.Point(101, 87);
            this.txttenkh.Multiline = true;
            this.txttenkh.Name = "txttenkh";
            this.txttenkh.Size = new System.Drawing.Size(142, 25);
            this.txttenkh.TabIndex = 16;
            // 
            // btnsuakh
            // 
            this.btnsuakh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnsuakh.ForeColor = System.Drawing.Color.Green;
            this.btnsuakh.Location = new System.Drawing.Point(407, 215);
            this.btnsuakh.Name = "btnsuakh";
            this.btnsuakh.Size = new System.Drawing.Size(79, 32);
            this.btnsuakh.TabIndex = 28;
            this.btnsuakh.Text = "Sửa";
            this.btnsuakh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnsuakh.UseVisualStyleBackColor = true;
            this.btnsuakh.Click += new System.EventHandler(this.btnsuakh_Click);
            // 
            // dgvBH
            // 
            this.dgvBH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKH,
            this.TenKH,
            this.DiaChi,
            this.dataGridViewTextBoxColumn1,
            this.NgayMuaHang,
            this.ChungLoaiBanh,
            this.SoLuong,
            this.DonGia,
            this.ThanhTien});
            this.dgvBH.Location = new System.Drawing.Point(0, 253);
            this.dgvBH.Name = "dgvBH";
            this.dgvBH.Size = new System.Drawing.Size(593, 194);
            this.dgvBH.TabIndex = 26;
            this.dgvBH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBH_CellClick);
            // 
            // MaKH
            // 
            this.MaKH.DataPropertyName = "MaKH";
            this.MaKH.HeaderText = "Mã KH";
            this.MaKH.Name = "MaKH";
            this.MaKH.Width = 70;
            // 
            // TenKH
            // 
            this.TenKH.DataPropertyName = "TenKH";
            this.TenKH.HeaderText = "Tên KH";
            this.TenKH.Name = "TenKH";
            this.TenKH.Width = 140;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 90;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "SDT";
            this.dataGridViewTextBoxColumn1.HeaderText = "SĐT";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // NgayMuaHang
            // 
            this.NgayMuaHang.DataPropertyName = "NgayMuaHang";
            this.NgayMuaHang.HeaderText = "Ngày Mua";
            this.NgayMuaHang.Name = "NgayMuaHang";
            this.NgayMuaHang.Width = 90;
            // 
            // ChungLoaiBanh
            // 
            this.ChungLoaiBanh.DataPropertyName = "ChungLoaiBanh";
            this.ChungLoaiBanh.HeaderText = "Tên Bánh";
            this.ChungLoaiBanh.Name = "ChungLoaiBanh";
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số Lượng Mua";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Width = 70;
            // 
            // DonGia
            // 
            this.DonGia.DataPropertyName = "DonGia";
            this.DonGia.HeaderText = "Đơn Giá";
            this.DonGia.Name = "DonGia";
            this.DonGia.Width = 70;
            // 
            // ThanhTien
            // 
            this.ThanhTien.DataPropertyName = "ThanhTien";
            this.ThanhTien.HeaderText = "Thành Tiền";
            this.ThanhTien.Name = "ThanhTien";
            this.ThanhTien.Width = 70;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(361, 138);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "Đơn Giá";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(361, 106);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 13);
            this.label15.TabIndex = 25;
            this.label15.Text = "Số Lượng";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(361, 76);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 13);
            this.label16.TabIndex = 23;
            this.label16.Text = "Loại Bánh";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(358, 51);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 13);
            this.label17.TabIndex = 22;
            this.label17.Text = "Ngày Mua";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(19, 190);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(72, 13);
            this.label30.TabIndex = 21;
            this.label30.Text = "Mã nhân viên";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(19, 162);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(38, 13);
            this.label18.TabIndex = 21;
            this.label18.Text = "Phone";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(19, 129);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 13);
            this.label19.TabIndex = 20;
            this.label19.Text = "Địa Chỉ";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label20.Location = new System.Drawing.Point(21, 97);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(44, 13);
            this.label20.TabIndex = 19;
            this.label20.Text = "Tên KH";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(19, 63);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(40, 13);
            this.label21.TabIndex = 18;
            this.label21.Text = "Mã KH";
            // 
            // txtthanhtoan
            // 
            this.txtthanhtoan.Location = new System.Drawing.Point(453, 168);
            this.txtthanhtoan.Multiline = true;
            this.txtthanhtoan.Name = "txtthanhtoan";
            this.txtthanhtoan.Size = new System.Drawing.Size(142, 26);
            this.txtthanhtoan.TabIndex = 15;
            // 
            // txtgia
            // 
            this.txtgia.Enabled = false;
            this.txtgia.Location = new System.Drawing.Point(453, 136);
            this.txtgia.Multiline = true;
            this.txtgia.Name = "txtgia";
            this.txtgia.Size = new System.Drawing.Size(142, 24);
            this.txtgia.TabIndex = 14;
            // 
            // txtsoluongban
            // 
            this.txtsoluongban.Location = new System.Drawing.Point(453, 101);
            this.txtsoluongban.Multiline = true;
            this.txtsoluongban.Name = "txtsoluongban";
            this.txtsoluongban.Size = new System.Drawing.Size(142, 27);
            this.txtsoluongban.TabIndex = 13;
            // 
            // txtmanv
            // 
            this.txtmanv.Location = new System.Drawing.Point(101, 182);
            this.txtmanv.Multiline = true;
            this.txtmanv.Name = "txtmanv";
            this.txtmanv.Size = new System.Drawing.Size(142, 24);
            this.txtmanv.TabIndex = 12;
            // 
            // txtsdtkh
            // 
            this.txtsdtkh.Location = new System.Drawing.Point(101, 155);
            this.txtsdtkh.Multiline = true;
            this.txtsdtkh.Name = "txtsdtkh";
            this.txtsdtkh.Size = new System.Drawing.Size(142, 24);
            this.txtsdtkh.TabIndex = 12;
            // 
            // txtdiachikh
            // 
            this.txtdiachikh.Location = new System.Drawing.Point(101, 116);
            this.txtdiachikh.Multiline = true;
            this.txtdiachikh.Name = "txtdiachikh";
            this.txtdiachikh.Size = new System.Drawing.Size(142, 28);
            this.txtdiachikh.TabIndex = 11;
            // 
            // txtmakh
            // 
            this.txtmakh.Location = new System.Drawing.Point(101, 56);
            this.txtmakh.Multiline = true;
            this.txtmakh.Name = "txtmakh";
            this.txtmakh.Size = new System.Drawing.Size(142, 24);
            this.txtmakh.TabIndex = 17;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(240, 10);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(182, 22);
            this.label22.TabIndex = 10;
            this.label22.Text = "Quản Lí Khách Hàng";
            // 
            // BanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnBanHang);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BanHang";
            this.Size = new System.Drawing.Size(613, 466);
            this.pnBanHang.ResumeLayout(false);
            this.pnBanHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnBanHang;
        private System.Windows.Forms.Button btnThanhtien;
        private System.Windows.Forms.DateTimePicker datengaymua;
        private System.Windows.Forms.ComboBox cbchungloaibanh;
        private System.Windows.Forms.Button btntimkiemkh;
        private System.Windows.Forms.Button btnxoakh;
        private System.Windows.Forms.Button btnthemkh;
        private System.Windows.Forms.TextBox txttimkiemkh;
        private System.Windows.Forms.TextBox txttenkh;
        private System.Windows.Forms.Button btnsuakh;
        private System.Windows.Forms.DataGridView dgvBH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayMuaHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChungLoaiBanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtthanhtoan;
        private System.Windows.Forms.TextBox txtgia;
        private System.Windows.Forms.TextBox txtsoluongban;
        private System.Windows.Forms.TextBox txtmanv;
        private System.Windows.Forms.TextBox txtsdtkh;
        private System.Windows.Forms.TextBox txtdiachikh;
        private System.Windows.Forms.TextBox txtmakh;
        private System.Windows.Forms.Label label22;
    }
}
