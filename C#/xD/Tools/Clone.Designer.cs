
namespace xD
{
    partial class Clone
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clone));
            this.txtPathText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPathClone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPathPDF = new System.Windows.Forms.TextBox();
            this.btnClone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPathText
            // 
            this.txtPathText.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPathText.Location = new System.Drawing.Point(288, 32);
            this.txtPathText.Multiline = true;
            this.txtPathText.Name = "txtPathText";
            this.txtPathText.Size = new System.Drawing.Size(374, 28);
            this.txtPathText.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 19);
            this.label2.TabIndex = 1000000014;
            this.label2.Text = "Đường dẫn thư mục chứa file text";
            // 
            // txtPathClone
            // 
            this.txtPathClone.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPathClone.Location = new System.Drawing.Point(288, 82);
            this.txtPathClone.Multiline = true;
            this.txtPathClone.Name = "txtPathClone";
            this.txtPathClone.Size = new System.Drawing.Size(374, 28);
            this.txtPathClone.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 19);
            this.label1.TabIndex = 1000000014;
            this.label1.Text = "Đường dẫn chứa file cần nhân bản";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(257, 19);
            this.label3.TabIndex = 1000000016;
            this.label3.Text = "Đường dẫn chứa file PDF đã nhân bản";
            // 
            // txtPathPDF
            // 
            this.txtPathPDF.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPathPDF.Location = new System.Drawing.Point(288, 135);
            this.txtPathPDF.Multiline = true;
            this.txtPathPDF.Name = "txtPathPDF";
            this.txtPathPDF.Size = new System.Drawing.Size(374, 28);
            this.txtPathPDF.TabIndex = 3;
            // 
            // btnClone
            // 
            this.btnClone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClone.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClone.Location = new System.Drawing.Point(271, 195);
            this.btnClone.Name = "btnClone";
            this.btnClone.Size = new System.Drawing.Size(89, 28);
            this.btnClone.TabIndex = 1000000017;
            this.btnClone.Text = "Nhân bản";
            this.btnClone.UseVisualStyleBackColor = false;
            this.btnClone.Click += new System.EventHandler(this.btnClone_Click);
            // 
            // Clone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(685, 235);
            this.Controls.Add(this.btnClone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPathPDF);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPathClone);
            this.Controls.Add(this.txtPathText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Clone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhân bản";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtPathText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPathClone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPathPDF;
        private System.Windows.Forms.Button btnClone;
    }
}