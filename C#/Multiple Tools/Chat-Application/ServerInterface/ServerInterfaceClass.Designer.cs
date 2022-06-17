namespace ServerInterface
{
    partial class ServerInterfaceClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerInterfaceClass));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.CurrentUsersListbox = new System.Windows.Forms.ListBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.HistoryListbox = new System.Windows.Forms.ListBox();
            this.tabChat = new System.Windows.Forms.TabPage();
            this.ChatListBox = new System.Windows.Forms.ListBox();
            this.StartServerButton = new System.Windows.Forms.Button();
            this.GreenLightPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.GreenLamp = new System.Windows.Forms.PictureBox();
            this.RedLightPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.RedLamp = new System.Windows.Forms.PictureBox();
            this.StopServerButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ServerPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabChat.SuspendLayout();
            this.GreenLightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GreenLamp)).BeginInit();
            this.RedLightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RedLamp)).BeginInit();
            this.ServerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tabControl2);
            this.panel1.Location = new System.Drawing.Point(107, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(363, 326);
            this.panel1.TabIndex = 1;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabChat);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(359, 322);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Transparent;
            this.tabPage4.Controls.Add(this.CurrentUsersListbox);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(351, 296);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Người dùng trực tuyến";
            // 
            // CurrentUsersListbox
            // 
            this.CurrentUsersListbox.BackColor = System.Drawing.Color.White;
            this.CurrentUsersListbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentUsersListbox.FormattingEnabled = true;
            this.CurrentUsersListbox.Location = new System.Drawing.Point(3, 3);
            this.CurrentUsersListbox.Name = "CurrentUsersListbox";
            this.CurrentUsersListbox.Size = new System.Drawing.Size(345, 290);
            this.CurrentUsersListbox.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.Transparent;
            this.tabPage5.Controls.Add(this.HistoryListbox);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(351, 296);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Lịch sử";
            // 
            // HistoryListbox
            // 
            this.HistoryListbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HistoryListbox.FormattingEnabled = true;
            this.HistoryListbox.Location = new System.Drawing.Point(3, 3);
            this.HistoryListbox.Name = "HistoryListbox";
            this.HistoryListbox.Size = new System.Drawing.Size(345, 290);
            this.HistoryListbox.TabIndex = 0;
            // 
            // tabChat
            // 
            this.tabChat.Controls.Add(this.ChatListBox);
            this.tabChat.Location = new System.Drawing.Point(4, 22);
            this.tabChat.Name = "tabChat";
            this.tabChat.Padding = new System.Windows.Forms.Padding(3);
            this.tabChat.Size = new System.Drawing.Size(351, 296);
            this.tabChat.TabIndex = 2;
            this.tabChat.Text = "Nội dung";
            this.tabChat.UseVisualStyleBackColor = true;
            // 
            // ChatListBox
            // 
            this.ChatListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChatListBox.FormattingEnabled = true;
            this.ChatListBox.Location = new System.Drawing.Point(3, 3);
            this.ChatListBox.Name = "ChatListBox";
            this.ChatListBox.Size = new System.Drawing.Size(345, 290);
            this.ChatListBox.TabIndex = 0;
            // 
            // StartServerButton
            // 
            this.StartServerButton.Font = new System.Drawing.Font("Palatino Linotype", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartServerButton.ForeColor = System.Drawing.Color.LimeGreen;
            this.StartServerButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.StartServerButton.Location = new System.Drawing.Point(3, 99);
            this.StartServerButton.Name = "StartServerButton";
            this.StartServerButton.Size = new System.Drawing.Size(98, 36);
            this.StartServerButton.TabIndex = 2;
            this.StartServerButton.Text = "Bắt đầu";
            this.StartServerButton.UseVisualStyleBackColor = true;
            this.StartServerButton.Click += new System.EventHandler(this.StartServerButton_Click);
            // 
            // GreenLightPanel
            // 
            this.GreenLightPanel.Controls.Add(this.label2);
            this.GreenLightPanel.Controls.Add(this.GreenLamp);
            this.GreenLightPanel.Location = new System.Drawing.Point(132, 10);
            this.GreenLightPanel.Name = "GreenLightPanel";
            this.GreenLightPanel.Size = new System.Drawing.Size(143, 82);
            this.GreenLightPanel.TabIndex = 18;
            this.GreenLightPanel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(23, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Trực tuyến";
            // 
            // GreenLamp
            // 
            this.GreenLamp.Image = global::ServerInterface.Properties.Resources.green;
            this.GreenLamp.Location = new System.Drawing.Point(50, 3);
            this.GreenLamp.Name = "GreenLamp";
            this.GreenLamp.Size = new System.Drawing.Size(35, 35);
            this.GreenLamp.TabIndex = 14;
            this.GreenLamp.TabStop = false;
            // 
            // RedLightPanel
            // 
            this.RedLightPanel.Controls.Add(this.label1);
            this.RedLightPanel.Controls.Add(this.RedLamp);
            this.RedLightPanel.Location = new System.Drawing.Point(281, 10);
            this.RedLightPanel.Name = "RedLightPanel";
            this.RedLightPanel.Size = new System.Drawing.Size(147, 82);
            this.RedLightPanel.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Tomato;
            this.label1.Location = new System.Drawing.Point(19, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Ngoại tuyến";
            // 
            // RedLamp
            // 
            this.RedLamp.Image = global::ServerInterface.Properties.Resources.red;
            this.RedLamp.Location = new System.Drawing.Point(57, 3);
            this.RedLamp.Name = "RedLamp";
            this.RedLamp.Size = new System.Drawing.Size(35, 34);
            this.RedLamp.TabIndex = 13;
            this.RedLamp.TabStop = false;
            // 
            // StopServerButton
            // 
            this.StopServerButton.Enabled = false;
            this.StopServerButton.Font = new System.Drawing.Font("Palatino Linotype", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopServerButton.ForeColor = System.Drawing.Color.Tomato;
            this.StopServerButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.StopServerButton.Location = new System.Drawing.Point(3, 156);
            this.StopServerButton.Name = "StopServerButton";
            this.StopServerButton.Size = new System.Drawing.Size(98, 37);
            this.StopServerButton.TabIndex = 19;
            this.StopServerButton.Text = "Kết thúc";
            this.StopServerButton.UseVisualStyleBackColor = true;
            this.StopServerButton.Click += new System.EventHandler(this.StopServerButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Indigo;
            this.label3.Location = new System.Drawing.Point(10, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 32);
            this.label3.TabIndex = 21;
            this.label3.Text = "Máy chủ";
            // 
            // ServerPanel
            // 
            this.ServerPanel.BackColor = System.Drawing.Color.MintCream;
            this.ServerPanel.Controls.Add(this.panel1);
            this.ServerPanel.Controls.Add(this.GreenLightPanel);
            this.ServerPanel.Controls.Add(this.label3);
            this.ServerPanel.Controls.Add(this.StopServerButton);
            this.ServerPanel.Controls.Add(this.RedLightPanel);
            this.ServerPanel.Controls.Add(this.pictureBox1);
            this.ServerPanel.Controls.Add(this.StartServerButton);
            this.ServerPanel.Location = new System.Drawing.Point(2, 2);
            this.ServerPanel.Name = "ServerPanel";
            this.ServerPanel.Size = new System.Drawing.Size(510, 591);
            this.ServerPanel.TabIndex = 26;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(118, 468);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(272, 123);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // ServerInterfaceClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(512, 597);
            this.Controls.Add(this.ServerPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ServerInterfaceClass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Máy chủ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerInterfaceClass_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ServerInterfaceClass_FormClosed);
            this.Load += new System.EventHandler(this.ServerInterfaceClass_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabChat.ResumeLayout(false);
            this.GreenLightPanel.ResumeLayout(false);
            this.GreenLightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GreenLamp)).EndInit();
            this.RedLightPanel.ResumeLayout(false);
            this.RedLightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RedLamp)).EndInit();
            this.ServerPanel.ResumeLayout(false);
            this.ServerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
       internal System.Windows.Forms.Button StartServerButton;
        private System.Windows.Forms.Panel GreenLightPanel;
        private System.Windows.Forms.PictureBox GreenLamp;
        private System.Windows.Forms.Panel RedLightPanel;
        private System.Windows.Forms.PictureBox RedLamp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
       internal System.Windows.Forms.Button StopServerButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel ServerPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TabControl tabControl2;
        public System.Windows.Forms.TabPage tabPage4;
        internal System.Windows.Forms.ListBox CurrentUsersListbox;
        public System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ListBox HistoryListbox;
        private System.Windows.Forms.TabPage tabChat;
        private System.Windows.Forms.ListBox ChatListBox;
    }
}

