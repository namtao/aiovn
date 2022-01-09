using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DuAn
{
    public class BinhPhuoc
    {
        public void ThongKeSKHDT()
        {
            var path = @"C:\Users\ADMIN\Downloads\Data so hoa (k xoa)";

            var arrPathJpg = Directory.GetFiles(path, "*.*",
                SearchOption.AllDirectories).Where(s => s.EndsWith(".pdf")).ToList();


            int colStart = 1;
            int colEnd = 6;
            int rowStart = 3;
            int rowEnd = 100000;

            object[,] arr = new object[rowEnd, colEnd];
            arr[0, 0] = "STT";
            arr[0, 1] = "Loại doanh nghiệp";
            arr[0, 2] = "Mã doanh nghiệp";
            arr[0, 3] = "Số file pdf";
            arr[0, 4] = "Số trang pdf";
            arr[0, 5] = "Dung lượng file (MB)";

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

                    // số file
                    arr[dong + 1, 3] = files.Count;

                    long size = 0;
                    for (int m = 0; m < files.Count; m++)
                    {
                        size += (new System.IO.FileInfo(files[m]).Length);
                    }

                    // số trang
                    arr[dong + 1, 4] = Utils.countPdf(files.ToArray());

                    // tổng dung lượng
                    arr[dong + 1, 5] = String.Format("{0:#,##0.##}", Math.Round((double)size / (double)(1024 * 1024), 2));

                    dong++;
                }

            }

            Utils.ExportExcel(arr, "Sheet", rowStart, colStart, rowEnd, colEnd);
        }
    }
}
