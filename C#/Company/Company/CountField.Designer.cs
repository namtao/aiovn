
namespace Company
{
    partial class CountField
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CountField));
            this.cbxTable = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.list1 = new System.Windows.Forms.ListBox();
            this.list2 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb = new System.Windows.Forms.Label();
            this.rtbSQL = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKyTu = new System.Windows.Forms.TextBox();
            this.lbTren = new System.Windows.Forms.Label();
            this.lbDuoi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbxTable
            // 
            this.cbxTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTable.FormattingEnabled = true;
            this.cbxTable.Location = new System.Drawing.Point(99, 14);
            this.cbxTable.Name = "cbxTable";
            this.cbxTable.Size = new System.Drawing.Size(194, 28);
            this.cbxTable.TabIndex = 1;
            this.cbxTable.DropDown += new System.EventHandler(this.cbxTable_DropDown);
            this.cbxTable.SelectedValueChanged += new System.EventHandler(this.cbxTable_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bảng";
            // 
            // list1
            // 
            this.list1.FormattingEnabled = true;
            this.list1.ItemHeight = 20;
            this.list1.Location = new System.Drawing.Point(10, 303);
            this.list1.Name = "list1";
            this.list1.Size = new System.Drawing.Size(314, 424);
            this.list1.TabIndex = 2;
            this.list1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.list1_MouseDoubleClick);
            // 
            // list2
            // 
            this.list2.FormattingEnabled = true;
            this.list2.ItemHeight = 20;
            this.list2.Location = new System.Drawing.Point(352, 303);
            this.list2.Name = "list2";
            this.list2.Size = new System.Drawing.Size(314, 424);
            this.list2.TabIndex = 2;
            this.list2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.list2_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Đếm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(474, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Không đếm";
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb.ForeColor = System.Drawing.Color.Red;
            this.lb.Location = new System.Drawing.Point(386, 22);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(44, 20);
            this.lb.TabIndex = 1;
            this.lb.Text = ".......";
            this.lb.Click += new System.EventHandler(this.lb_Click);
            // 
            // rtbSQL
            // 
            this.rtbSQL.BackColor = System.Drawing.Color.White;
            this.rtbSQL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbSQL.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbSQL.ForeColor = System.Drawing.Color.DodgerBlue;
            this.rtbSQL.Location = new System.Drawing.Point(10, 94);
            this.rtbSQL.Margin = new System.Windows.Forms.Padding(5, 5, 10, 5);
            this.rtbSQL.Name = "rtbSQL";
            this.rtbSQL.Size = new System.Drawing.Size(656, 156);
            this.rtbSQL.TabIndex = 0;
            this.rtbSQL.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 1000000053;
            this.label4.Text = "Ký tự";
            // 
            // txtKyTu
            // 
            this.txtKyTu.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKyTu.Location = new System.Drawing.Point(99, 58);
            this.txtKyTu.Multiline = true;
            this.txtKyTu.Name = "txtKyTu";
            this.txtKyTu.Size = new System.Drawing.Size(67, 28);
            this.txtKyTu.TabIndex = 1000000052;
            // 
            // lbTren
            // 
            this.lbTren.AutoSize = true;
            this.lbTren.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTren.ForeColor = System.Drawing.Color.Red;
            this.lbTren.Location = new System.Drawing.Point(249, 66);
            this.lbTren.Name = "lbTren";
            this.lbTren.Size = new System.Drawing.Size(44, 20);
            this.lbTren.TabIndex = 1000000054;
            this.lbTren.Text = ".......";
            this.lbTren.Click += new System.EventHandler(this.lbTren_Click);
            // 
            // lbDuoi
            // 
            this.lbDuoi.AutoSize = true;
            this.lbDuoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDuoi.ForeColor = System.Drawing.Color.Red;
            this.lbDuoi.Location = new System.Drawing.Point(474, 66);
            this.lbDuoi.Name = "lbDuoi";
            this.lbDuoi.Size = new System.Drawing.Size(44, 20);
            this.lbDuoi.TabIndex = 1000000055;
            this.lbDuoi.Text = ".......";
            this.lbDuoi.Click += new System.EventHandler(this.lbDuoi_Click);
            // 
            // CountField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(678, 742);
            this.Controls.Add(this.lbDuoi);
            this.Controls.Add(this.lbTren);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtKyTu);
            this.Controls.Add(this.rtbSQL);
            this.Controls.Add(this.list2);
            this.Controls.Add(this.list1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxTable);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CountField";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đếm trường";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CountField_FormClosing);
            this.Load += new System.EventHandler(this.CountField_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox list1;
        private System.Windows.Forms.ListBox list2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.RichTextBox rtbSQL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKyTu;
        private System.Windows.Forms.Label lbTren;
        private System.Windows.Forms.Label lbDuoi;
    }
}

