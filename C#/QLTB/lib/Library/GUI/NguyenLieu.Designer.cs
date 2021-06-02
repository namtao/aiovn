namespace GUI
{
    partial class NguyenLieu
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
            this.pnNhapHang = new System.Windows.Forms.Panel();
            this.dgvNhapHang = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.btnxoanguyenlieu = new System.Windows.Forms.Button();
            this.btnsuanguyenlieu = new System.Windows.Forms.Button();
            this.btnthemnguyenlieu = new System.Windows.Forms.Button();
            this.btnThanhTiennguyenlieu = new System.Windows.Forms.Button();
            this.datenhapnguyenlieu = new System.Windows.Forms.DateTimePicker();
            this.label23 = new System.Windows.Forms.Label();
            this.txtsoluongnguyenlieu = new System.Windows.Forms.TextBox();
            this.cbxnhacungcap = new System.Windows.Forms.ComboBox();
            this.txtdongianguyenlieu = new System.Windows.Forms.TextBox();
            this.txtmanguyenlieu = new System.Windows.Forms.TextBox();
            this.txttennguyenlieu = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.pnNhapHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhapHang)).BeginInit();
            this.SuspendLayout();
            // 
            // pnNhapHang
            // 
            this.pnNhapHang.Controls.Add(this.dgvNhapHang);
            this.pnNhapHang.Controls.Add(this.txtThanhTien);
            this.pnNhapHang.Controls.Add(this.btnxoanguyenlieu);
            this.pnNhapHang.Controls.Add(this.btnsuanguyenlieu);
            this.pnNhapHang.Controls.Add(this.btnthemnguyenlieu);
            this.pnNhapHang.Controls.Add(this.btnThanhTiennguyenlieu);
            this.pnNhapHang.Controls.Add(this.datenhapnguyenlieu);
            this.pnNhapHang.Controls.Add(this.label23);
            this.pnNhapHang.Controls.Add(this.txtsoluongnguyenlieu);
            this.pnNhapHang.Controls.Add(this.cbxnhacungcap);
            this.pnNhapHang.Controls.Add(this.txtdongianguyenlieu);
            this.pnNhapHang.Controls.Add(this.txtmanguyenlieu);
            this.pnNhapHang.Controls.Add(this.txttennguyenlieu);
            this.pnNhapHang.Controls.Add(this.label24);
            this.pnNhapHang.Controls.Add(this.label25);
            this.pnNhapHang.Controls.Add(this.label26);
            this.pnNhapHang.Controls.Add(this.label27);
            this.pnNhapHang.Controls.Add(this.label28);
            this.pnNhapHang.Controls.Add(this.label29);
            this.pnNhapHang.Location = new System.Drawing.Point(3, 3);
            this.pnNhapHang.Name = "pnNhapHang";
            this.pnNhapHang.Size = new System.Drawing.Size(914, 608);
            this.pnNhapHang.TabIndex = 41;
            // 
            // dgvNhapHang
            // 
            this.dgvNhapHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhapHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn2});
            this.dgvNhapHang.Location = new System.Drawing.Point(4, 380);
            this.dgvNhapHang.Margin = new System.Windows.Forms.Padding(4);
            this.dgvNhapHang.Name = "dgvNhapHang";
            this.dgvNhapHang.Size = new System.Drawing.Size(906, 210);
            this.dgvNhapHang.TabIndex = 36;
            this.dgvNhapHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhapHang_CellClick);
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "MaNhap";
            this.dataGridViewTextBoxColumn7.HeaderText = "Mã";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Ten";
            this.dataGridViewTextBoxColumn6.HeaderText = "Tên Hàng";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Ncc";
            this.dataGridViewTextBoxColumn5.HeaderText = "Nhà Cung Cấp";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Gia";
            this.dataGridViewTextBoxColumn4.HeaderText = "Đơn Giá";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SoLuong";
            this.dataGridViewTextBoxColumn3.HeaderText = "Số Lượng";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NgayNhap";
            this.dataGridViewTextBoxColumn2.HeaderText = "Ngày Nhập";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Location = new System.Drawing.Point(694, 320);
            this.txtThanhTien.Margin = new System.Windows.Forms.Padding(4);
            this.txtThanhTien.Multiline = true;
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.Size = new System.Drawing.Size(204, 49);
            this.txtThanhTien.TabIndex = 35;
            // 
            // btnxoanguyenlieu
            // 
            this.btnxoanguyenlieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnxoanguyenlieu.Location = new System.Drawing.Point(681, 188);
            this.btnxoanguyenlieu.Margin = new System.Windows.Forms.Padding(4);
            this.btnxoanguyenlieu.Name = "btnxoanguyenlieu";
            this.btnxoanguyenlieu.Size = new System.Drawing.Size(110, 49);
            this.btnxoanguyenlieu.TabIndex = 32;
            this.btnxoanguyenlieu.Text = "Xóa";
            this.btnxoanguyenlieu.UseVisualStyleBackColor = true;
            this.btnxoanguyenlieu.Click += new System.EventHandler(this.btnxoanguyenlieu_Click);
            // 
            // btnsuanguyenlieu
            // 
            this.btnsuanguyenlieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsuanguyenlieu.Location = new System.Drawing.Point(757, 119);
            this.btnsuanguyenlieu.Margin = new System.Windows.Forms.Padding(4);
            this.btnsuanguyenlieu.Name = "btnsuanguyenlieu";
            this.btnsuanguyenlieu.Size = new System.Drawing.Size(119, 49);
            this.btnsuanguyenlieu.TabIndex = 31;
            this.btnsuanguyenlieu.Text = "Sửa";
            this.btnsuanguyenlieu.UseVisualStyleBackColor = true;
            this.btnsuanguyenlieu.Click += new System.EventHandler(this.btnsuanguyenlieu_Click);
            // 
            // btnthemnguyenlieu
            // 
            this.btnthemnguyenlieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnthemnguyenlieu.Location = new System.Drawing.Point(609, 122);
            this.btnthemnguyenlieu.Margin = new System.Windows.Forms.Padding(4);
            this.btnthemnguyenlieu.Name = "btnthemnguyenlieu";
            this.btnthemnguyenlieu.Size = new System.Drawing.Size(112, 49);
            this.btnthemnguyenlieu.TabIndex = 30;
            this.btnthemnguyenlieu.Text = "Thêm";
            this.btnthemnguyenlieu.UseVisualStyleBackColor = true;
            this.btnthemnguyenlieu.Click += new System.EventHandler(this.btnthemnguyenlieu_Click);
            // 
            // btnThanhTiennguyenlieu
            // 
            this.btnThanhTiennguyenlieu.Location = new System.Drawing.Point(545, 320);
            this.btnThanhTiennguyenlieu.Margin = new System.Windows.Forms.Padding(4);
            this.btnThanhTiennguyenlieu.Name = "btnThanhTiennguyenlieu";
            this.btnThanhTiennguyenlieu.Size = new System.Drawing.Size(141, 52);
            this.btnThanhTiennguyenlieu.TabIndex = 29;
            this.btnThanhTiennguyenlieu.Text = "Thành Tiền";
            this.btnThanhTiennguyenlieu.UseVisualStyleBackColor = true;
            this.btnThanhTiennguyenlieu.Click += new System.EventHandler(this.btnThanhTiennguyenlieu_Click);
            // 
            // datenhapnguyenlieu
            // 
            this.datenhapnguyenlieu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datenhapnguyenlieu.Location = new System.Drawing.Point(301, 346);
            this.datenhapnguyenlieu.Margin = new System.Windows.Forms.Padding(4);
            this.datenhapnguyenlieu.Name = "datenhapnguyenlieu";
            this.datenhapnguyenlieu.Size = new System.Drawing.Size(204, 26);
            this.datenhapnguyenlieu.TabIndex = 28;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(37, 347);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(133, 29);
            this.label23.TabIndex = 27;
            this.label23.Text = "Ngày Nhập";
            // 
            // txtsoluongnguyenlieu
            // 
            this.txtsoluongnguyenlieu.Location = new System.Drawing.Point(301, 297);
            this.txtsoluongnguyenlieu.Margin = new System.Windows.Forms.Padding(4);
            this.txtsoluongnguyenlieu.Name = "txtsoluongnguyenlieu";
            this.txtsoluongnguyenlieu.Size = new System.Drawing.Size(204, 26);
            this.txtsoluongnguyenlieu.TabIndex = 26;
            // 
            // cbxnhacungcap
            // 
            this.cbxnhacungcap.FormattingEnabled = true;
            this.cbxnhacungcap.Location = new System.Drawing.Point(301, 209);
            this.cbxnhacungcap.Margin = new System.Windows.Forms.Padding(4);
            this.cbxnhacungcap.Name = "cbxnhacungcap";
            this.cbxnhacungcap.Size = new System.Drawing.Size(204, 28);
            this.cbxnhacungcap.TabIndex = 25;
            // 
            // txtdongianguyenlieu
            // 
            this.txtdongianguyenlieu.Location = new System.Drawing.Point(301, 259);
            this.txtdongianguyenlieu.Margin = new System.Windows.Forms.Padding(4);
            this.txtdongianguyenlieu.Name = "txtdongianguyenlieu";
            this.txtdongianguyenlieu.Size = new System.Drawing.Size(204, 26);
            this.txtdongianguyenlieu.TabIndex = 24;
            // 
            // txtmanguyenlieu
            // 
            this.txtmanguyenlieu.Location = new System.Drawing.Point(301, 121);
            this.txtmanguyenlieu.Margin = new System.Windows.Forms.Padding(4);
            this.txtmanguyenlieu.Name = "txtmanguyenlieu";
            this.txtmanguyenlieu.Size = new System.Drawing.Size(204, 26);
            this.txtmanguyenlieu.TabIndex = 23;
            // 
            // txttennguyenlieu
            // 
            this.txttennguyenlieu.Location = new System.Drawing.Point(301, 167);
            this.txttennguyenlieu.Margin = new System.Windows.Forms.Padding(4);
            this.txttennguyenlieu.Name = "txttennguyenlieu";
            this.txttennguyenlieu.Size = new System.Drawing.Size(204, 26);
            this.txttennguyenlieu.TabIndex = 22;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(37, 303);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(116, 29);
            this.label24.TabIndex = 21;
            this.label24.Text = "Số Lượng";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(37, 258);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(100, 29);
            this.label25.TabIndex = 20;
            this.label25.Text = "Đơn Giá";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(37, 122);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(175, 29);
            this.label26.TabIndex = 17;
            this.label26.Text = "Mã nguyên liệu";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(37, 215);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(170, 29);
            this.label27.TabIndex = 19;
            this.label27.Text = "Nhà Cung Cấp";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(37, 167);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(185, 29);
            this.label28.TabIndex = 18;
            this.label28.Text = "Tên nguyên liệu";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(251, 26);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(386, 53);
            this.label29.TabIndex = 16;
            this.label29.Text = "Nhập Nguyên Liệu";
            // 
            // NguyenLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnNhapHang);
            this.Name = "NguyenLieu";
            this.Size = new System.Drawing.Size(924, 696);
            this.pnNhapHang.ResumeLayout(false);
            this.pnNhapHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhapHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnNhapHang;
        private System.Windows.Forms.DataGridView dgvNhapHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.Button btnxoanguyenlieu;
        private System.Windows.Forms.Button btnsuanguyenlieu;
        private System.Windows.Forms.Button btnthemnguyenlieu;
        private System.Windows.Forms.Button btnThanhTiennguyenlieu;
        private System.Windows.Forms.DateTimePicker datenhapnguyenlieu;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtsoluongnguyenlieu;
        private System.Windows.Forms.ComboBox cbxnhacungcap;
        private System.Windows.Forms.TextBox txtdongianguyenlieu;
        private System.Windows.Forms.TextBox txtmanguyenlieu;
        private System.Windows.Forms.TextBox txttennguyenlieu;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
    }
}
