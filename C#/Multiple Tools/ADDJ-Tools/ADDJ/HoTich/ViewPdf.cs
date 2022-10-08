using GdPicture14;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADDJ
{
    public partial class ViewPdf : Form
    {
        private readonly GdPicturePDF _currentPdf = new GdPicturePDF();

        public ViewPdf()
        {
            InitializeComponent();
            //this.gdViewer.DisplayFromFile(@"C:\Users\Nam\Downloads\contratos.png");
            GdPictureStatus gdPictureStatus = this._currentPdf.LoadFromFile("C:/Users/Nam/Downloads/ams.profile-11-file_scan.pdf", false);
            bool flag4 = gdPictureStatus == 0;
            if (flag4)
            {
                this.gdViewer.DisplayFromGdPicturePDF(this._currentPdf);
                this.thumbnailEx1.LoadFromGdViewer(this.gdViewer);
            }

        }
    }
}
