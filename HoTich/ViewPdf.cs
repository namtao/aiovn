using GdPicture14;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xD
{
    public partial class ViewPdf : Form
    {
        private readonly GdPicturePDF _currentPdf = new GdPicturePDF();
        public ViewPdf()
        {
            InitializeComponent();

            GdPictureStatus gdPictureStatus = this._currentPdf.LoadFromFile(@"C:\Users\Nam\Downloads\Python for Data Analysis Data Wrangling with Pandas, NumPy, and IPython (Wes McKinney) (z-lib.org).pdf", false);
            bool flag4 = gdPictureStatus == 0;
            if (flag4)
            {
                this.gdViewer1.DisplayFromGdPicturePDF(this._currentPdf);
                this.thumbnailEx1.LoadFromGdViewer(this.gdViewer1);
            }

            Utils.run_cmd();
        }
    }
}
