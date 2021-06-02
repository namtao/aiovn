using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DB
{
    public partial class PDF : Form
    {
        public PDF()
        {
            InitializeComponent();
        }

        private void PDF_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("msedge.exe", @"C:\Users\Admin\Downloads\chuong.pdf");
        }
    }
}
