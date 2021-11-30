using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.DuAn
{
    internal class BinhPhuoc
    {
        public void ThongKeSKHDT()
        {
            var arrPathJpg = Directory.GetFiles(@"C:\Users\ADMIN\Downloads\Data so hoa (k xoa)", "*.*",
                SearchOption.AllDirectories).Where(s => s.EndsWith(".pdf")).ToList();

            object[,] arr = new object[100, 3];
            arr[0, 0] = "Mã doanh nghiệp";
            arr[0, 1] = "Số hồ sơ";
            arr[0, 2] = "Dung lượng file";

            Utils.ExportExcel(arr, "Sheet", 3, 1, 100, 3);
        }
    }
}
