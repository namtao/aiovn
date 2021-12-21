using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB.DuAn;
using System.IO;
using System.Diagnostics;


namespace DB
{
    public partial class TKBP : Form
    {
        public TKBP()
        {
            InitializeComponent();
        }

        private void TKBP_Load(object sender, EventArgs e)
        {

        }

        public void ThongKeSKHDT(string path)
        {

            var arrPathPdf = Directory.GetFiles(path, "*.*",
                SearchOption.AllDirectories).Where(s => s.EndsWith(".pdf")).ToList();

            int count = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = arrPathPdf.Count;

            int colStart = 1;
            int colEnd = 8;
            int rowStart = 3;
            int rowEnd = 100000;

            object[,] arr = new object[rowEnd, colEnd];
            arr[0, 0] = "STT";
            arr[0, 1] = "Loại doanh nghiệp";
            arr[0, 2] = "Mã doanh nghiệp";
            arr[0, 3] = "Số file pdf";
            arr[0, 4] = "Số trang pdf";
            arr[0, 5] = "Số file pdf (không đưa)";
            arr[0, 6] = "Số trang pdf (không đưa)";
            arr[0, 7] = "Dung lượng file (MB)";

            int dong = 0;

            // lấy tất cả đường dẫn thư mục loại doanh nghiệp
            var doanhnghiep = Directory.GetDirectories(path);

            for (int i = 0; i < doanhnghiep.Length; i++)
            {
                // lấy tất cả đường dẫn thư mục mã doanh nghiệp
                var madoanhnghiep = Directory.GetDirectories(doanhnghiep[i]);

                //Tên loại doanh nghiệp
                arr[dong + 1, 1] = new DirectoryInfo(doanhnghiep[i]).Name.Trim();

                for (int j = 0; j < madoanhnghiep.Length; j++)
                {
                    //vào từng doanh nghiệp// số thứ tự
                    arr[dong + 1, 0] = dong + 1;

                    // Mã doanh nghiệp
                    arr[dong + 1, 2] = new DirectoryInfo(madoanhnghiep[j]).Name.Trim();

                    var files = Directory.GetFiles(madoanhnghiep[j], "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".pdf")).ToList();

                    var filesKhongDua = Directory.GetFiles(madoanhnghiep[j], "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".pdf")).ToList();

                    count += files.Count;
                    progressBar1.Value = count;


                    long size = 0;
                    for (int m = 0; m < files.Count; m++)
                    {
                        size += (new System.IO.FileInfo(files[m]).Length);
                    }

                    // số file
                    arr[dong + 1, 3] = files.Count - filesKhongDua.Count;

                    // số trang
                    arr[dong + 1, 4] = Utils.countPdf(files.ToArray()) - Utils.countPdf(filesKhongDua.ToArray());

                    // số file không đưa lên pm
                    arr[dong + 1, 5] = filesKhongDua.Count;

                    // số trang pdf không đưa lên pm
                    arr[dong + 1, 6] = Utils.countPdf(filesKhongDua.ToArray());

                    // tổng dung lượng
                    arr[dong + 1, 7] = String.Format("{0:#,##0.##}", Math.Round((double)size / (double)(1024 * 1024), 2));

                    dong++;
                }

            }

            Utils.ExportExcel(arr, "Sheet", rowStart, colStart, rowEnd, colEnd);
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThongKeSKHDT(linkLabel1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    linkLabel1.Text = fbd.SelectedPath;
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", linkLabel1.Text);
        }
    }
}
