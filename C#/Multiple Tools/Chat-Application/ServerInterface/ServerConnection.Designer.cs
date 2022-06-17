namespace ServerInterface
{
    partial class ServerConnection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerConnection));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.IPmaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.portTextBox = new System.Windows.Forms.MaskedTextBox();
            this.CreateServerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 26);
            this.label1.TabIndex = 15;
            this.label1.Text = "Địa chỉ IP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 26);
            this.label3.TabIndex = 17;
            this.label3.Text = "Cổng:";
            // 
            // IPmaskedTextBox
            // 
            this.IPmaskedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPmaskedTextBox.Location = new System.Drawing.Point(177, 36);
            this.IPmaskedTextBox.Name = "IPmaskedTextBox";
            this.IPmaskedTextBox.Size = new System.Drawing.Size(170, 26);
            this.IPmaskedTextBox.TabIndex = 18;
            // 
            // portTextBox
            // 
            this.portTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portTextBox.Location = new System.Drawing.Point(177, 112);
            this.portTextBox.Mask = "00000";
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(170, 26);
            this.portTextBox.TabIndex = 20;
            this.portTextBox.ValidatingType = typeof(int);
            // 
            // CreateServerButton
            // 
            this.CreateServerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CreateServerButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.CreateServerButton.Location = new System.Drawing.Point(41, 176);
            this.CreateServerButton.Name = "CreateServerButton";
            this.CreateServerButton.Size = new System.Drawing.Size(306, 40);
            this.CreateServerButton.TabIndex = 27;
            this.CreateServerButton.Text = "Tạo mới phòng";
            this.CreateServerButton.UseVisualStyleBackColor = true;
            this.CreateServerButton.Click += new System.EventHandler(this.CreateServerButton_Click);
            // 
            // ServerConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(398, 249);
            this.Controls.Add(this.CreateServerButton);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.IPmaskedTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ServerConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo mới phòng chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerConnection_FormClosing);
            this.Load += new System.EventHandler(this.ServerConnection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.MaskedTextBox IPmaskedTextBox;
        private System.Windows.Forms.MaskedTextBox portTextBox;
        public System.Windows.Forms.Button CreateServerButton;
    }
}