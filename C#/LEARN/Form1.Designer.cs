namespace LEARN
{
    partial class formHome
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formHome));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.txtEng = new System.Windows.Forms.TextBox();
            this.txtExa = new System.Windows.Forms.TextBox();
            this.txtSpelling = new System.Windows.Forms.TextBox();
            this.txtVie = new System.Windows.Forms.TextBox();
            this.lbFinish = new System.Windows.Forms.Label();
            this.lbError = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "LEARN";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_BalloonTipClicked);
            this.notifyIcon1.BalloonTipShown += new System.EventHandler(this.notifyIcon1_BalloonTipShown);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(105, 26);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(104, 22);
            this.toolStripMenuItem1.Text = "Thoát";
            // 
            // txtEng
            // 
            this.txtEng.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEng.Location = new System.Drawing.Point(11, 39);
            this.txtEng.Multiline = true;
            this.txtEng.Name = "txtEng";
            this.txtEng.PlaceholderText = "ENGLISH";
            this.txtEng.Size = new System.Drawing.Size(141, 28);
            this.txtEng.TabIndex = 1;
            this.txtEng.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEng.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEng_KeyDown);
            // 
            // txtExa
            // 
            this.txtExa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtExa.Location = new System.Drawing.Point(11, 73);
            this.txtExa.Multiline = true;
            this.txtExa.Name = "txtExa";
            this.txtExa.PlaceholderText = "EXAMPLE";
            this.txtExa.Size = new System.Drawing.Size(435, 34);
            this.txtExa.TabIndex = 4;
            this.txtExa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtExa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtExa_KeyDown);
            // 
            // txtSpelling
            // 
            this.txtSpelling.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSpelling.Location = new System.Drawing.Point(158, 39);
            this.txtSpelling.Multiline = true;
            this.txtSpelling.Name = "txtSpelling";
            this.txtSpelling.PlaceholderText = "SPELLING";
            this.txtSpelling.Size = new System.Drawing.Size(141, 28);
            this.txtSpelling.TabIndex = 2;
            this.txtSpelling.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSpelling.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSpelling_KeyDown);
            // 
            // txtVie
            // 
            this.txtVie.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtVie.Location = new System.Drawing.Point(305, 39);
            this.txtVie.Multiline = true;
            this.txtVie.Name = "txtVie";
            this.txtVie.PlaceholderText = "VIETNAMESE";
            this.txtVie.Size = new System.Drawing.Size(141, 28);
            this.txtVie.TabIndex = 3;
            this.txtVie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVie.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVie_KeyDown);
            // 
            // lbFinish
            // 
            this.lbFinish.AutoSize = true;
            this.lbFinish.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbFinish.ForeColor = System.Drawing.Color.Lime;
            this.lbFinish.Location = new System.Drawing.Point(173, 9);
            this.lbFinish.Name = "lbFinish";
            this.lbFinish.Size = new System.Drawing.Size(122, 15);
            this.lbFinish.TabIndex = 5;
            this.lbFinish.Text = "COMPLETE INSERT!!!";
            this.lbFinish.Visible = false;
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbError.ForeColor = System.Drawing.Color.Red;
            this.lbError.Location = new System.Drawing.Point(182, 9);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(102, 15);
            this.lbError.TabIndex = 6;
            this.lbError.Text = "INSERT ERROR!!!";
            this.lbError.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 900000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // formHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 119);
            this.Controls.Add(this.lbError);
            this.Controls.Add(this.lbFinish);
            this.Controls.Add(this.txtExa);
            this.Controls.Add(this.txtVie);
            this.Controls.Add(this.txtSpelling);
            this.Controls.Add(this.txtEng);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "formHome";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.formHome_Load);
            this.SizeChanged += new System.EventHandler(this.formHome_SizeChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TextBox txtEng;
        private System.Windows.Forms.TextBox txtExa;
        private System.Windows.Forms.TextBox txtSpelling;
        private System.Windows.Forms.TextBox txtVie;
        private System.Windows.Forms.Label lbFinish;
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.Timer timer1;
    }
}

