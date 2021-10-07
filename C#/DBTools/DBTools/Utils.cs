using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTools
{
    public class Utils
    {
        public static void ExportThongKe(object[,] arr, string sheetName, string title)
        {

            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetName;

            //Thiết lập vùng điền dữ liệu
            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = 1000;
            int columnEnd = 100;

            //in đậm tiêu đề
            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range((Microsoft.Office.Interop.Excel.Range)oSheet.Cells[3, columnStart],
                (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[3, columnEnd]);
            rowHead.Font.Bold = true;

            //in đậm cột A
            Microsoft.Office.Interop.Excel.Range rowA = oSheet.get_Range((Microsoft.Office.Interop.Excel.Range)oSheet.Cells[3, 1],
                (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[100, 1]);

            //rowA.Font.Bold = true;

            // Kẻ viền
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền
            //rowHead.Interior.ColorIndex = 15;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo phần đầu nếu muốn
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range((Microsoft.Office.Interop.Excel.Range)oSheet.Cells[1, columnStart], (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[1, columnEnd]);
            head.MergeCells = true;
            head.Value2 ="Thống kê Thái Bình ngày "+ DateTime.Now.ToString("dd/MM/yyyy");
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "12";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //title 1
            Microsoft.Office.Interop.Excel.Range t0 = oSheet.Cells[3, 1];
            t0.Value2 = "Tên Phông";
            t0.Font.Name = "Tahoma";
            t0.Font.Size = "12";
            t0.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range t1 = oSheet.Cells[3, 2];
            t1.Value2 = "Số lượng JPG";
            t1.Font.Name = "Tahoma";
            t1.Font.Size = "12";
            t1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range t2 = oSheet.Cells[3, 3];
            t2.Value2 = "Số trường hợp không mã";
            t2.Font.Name = "Tahoma";
            t2.Font.Size = "12";
            t2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range t3 = oSheet.Cells[3, 4];
            t3.Value2 = "Số hồ sơ";
            t3.Font.Name = "Tahoma";
            t3.Font.Size = "12";
            t3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //định dạng số ngăn cách bằng dấu .
            //range.NumberFormat = "#,##0";

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;

            // Kẻ viền

            //range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột STT
            Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];
            Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            //oSheet.get_Range(c3, c4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            range.Columns.AutoFit();
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //auto width
            oSheet.Columns.AutoFit();
        }

        public static void ExportQ10(object[,] arr, string sheetName)
        {

            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetName;

            //Thiết lập vùng điền dữ liệu
            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = 1000;
            int columnEnd = 5;

            //in đậm tiêu đề
            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range((Microsoft.Office.Interop.Excel.Range)oSheet.Cells[3, columnStart],
                (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[3, columnEnd]);
            rowHead.Font.Bold = true;

            //in đậm cột A
            Microsoft.Office.Interop.Excel.Range rowA = oSheet.get_Range((Microsoft.Office.Interop.Excel.Range)oSheet.Cells[3, 1],
                (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[100, 1]);

            //rowA.Font.Bold = true;

            // Kẻ viền
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền
            //rowHead.Interior.ColorIndex = 15;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo phần đầu nếu muốn
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range((Microsoft.Office.Interop.Excel.Range)oSheet.Cells[1, columnStart], (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[1, columnEnd]);
            head.MergeCells = true;
            head.Value2 = "Thống kê Q10";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "12";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //title 1
            Microsoft.Office.Interop.Excel.Range t0 = oSheet.Cells[3, 1];
            t0.Value2 = "Loại";
            t0.Font.Name = "Tahoma";
            t0.Font.Size = "12";
            t0.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range t1 = oSheet.Cells[3, 2];
            t1.Value2 = "Nơi đăng ký";
            t1.Font.Name = "Tahoma";
            t1.Font.Size = "12";
            t1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range t2 = oSheet.Cells[3, 3];
            t2.Value2 = "Năm";
            t2.Font.Name = "Tahoma";
            t2.Font.Size = "12";
            t2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range t3 = oSheet.Cells[3, 4];
            t3.Value2 = "Số trường hợp";
            t3.Font.Name = "Tahoma";
            t3.Font.Size = "12";
            t3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range t4 = oSheet.Cells[3, 5];
            t4.Value2 = "Số quyển";
            t4.Font.Name = "Tahoma";
            t4.Font.Size = "12";
            t4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //định dạng số ngăn cách bằng dấu .
            //range.NumberFormat = "#,##0";

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;

            // Kẻ viền

            //range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột STT
            Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];
            Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            //oSheet.get_Range(c3, c4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            range.Columns.AutoFit();
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //auto width
            oSheet.Columns.AutoFit();
        }

        public static bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
    }
}
