using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using Microsoft.Office.Interop.Excel;

namespace Company
{
    public class Utils
    {
        public static bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        
        public static int countPdf(string[] arrPathPdf)
        {
            int numberOfPages = 0;
            foreach (string str in arrPathPdf)
            {
                PdfReader pdfReader = new PdfReader(str);
                numberOfPages += pdfReader.NumberOfPages;
            }
            return numberOfPages;
        }

        public static void ExportExcel(object[,] arr, string sheetName, int rowStart, int columnStart, int rowEnd, int columnEnd)
        {
            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Workbooks oBooks;
            Sheets oSheets;
            Workbook oBook;
            Worksheet oSheet;

            //Tạo mới một Excel WorkBook 
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBook = oExcel.Workbooks.Add(Type.Missing);
            oSheets = oBook.Worksheets;
            oSheet = oSheets.get_Item(1);
            oSheet.Name = sheetName;

            //in đậm title
            Range rowHead = oSheet.get_Range((Range)oSheet.Cells[3, columnStart], (Range)oSheet.Cells[3, columnEnd]);
            rowHead.Font.Bold = true;
            rowHead.Font.Name = "Tahoma";
            rowHead.Font.Size = "12";
            rowHead.HorizontalAlignment = XlHAlign.xlHAlignCenter;

            //in đậm cột A
            Range rowA = oSheet.get_Range((Range)oSheet.Cells[3, 1], (Range)oSheet.Cells[100, 1]);

            //rowA.Font.Bold = true;

            // Kẻ viền
            rowHead.Borders.LineStyle = Constants.xlSolid;

            // Thiết lập màu nền
            //rowHead.Interior.ColorIndex = 15;

            rowHead.HorizontalAlignment = XlHAlign.xlHAlignCenter;

            // Tạo header
            Range head = oSheet.get_Range((Range)oSheet.Cells[1, columnStart], (Range)oSheet.Cells[1, columnEnd]);
            head.MergeCells = true;
            head.Value2 = "Thống kê ngày " + DateTime.Now.ToString("dd/MM/yyyy");
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "12";
            head.HorizontalAlignment = XlHAlign.xlHAlignCenter;

            //title
            /*Range t0 = oSheet.Cells[3, 1];
            t0.Value2 = "Tên Phông";

            Range t1 = oSheet.Cells[3, 2];
            t1.Value2 = "Số lượng JPG";

            Range t2 = oSheet.Cells[3, 3];
            t2.Value2 = "Số trường hợp không mã";

            Range t3 = oSheet.Cells[3, 4];
            t3.Value2 = "Số hồ sơ";*/


            // Ô bắt đầu điền dữ liệu
            Range c1 = (Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu
            Range c2 = (Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu
            Range range = oSheet.get_Range(c1, c2);

            //định dạng số ngăn cách bằng dấu .
            //range.NumberFormat = "#,##0";

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;

            // Kẻ viền

            //range.Borders.LineStyle = Constants.xlSolid;

            // Căn giữa cột STT
            Range c3 = (Range)oSheet.Cells[rowEnd, columnStart];
            Range c4 = oSheet.get_Range(c1, c3);

            //oSheet.get_Range(c3, c4).HorizontalAlignment = XlHAlign.xlHAlignCenter;
            range.Columns.AutoFit();
            range.HorizontalAlignment = XlHAlign.xlHAlignLeft;

            //auto width
            oSheet.Columns.AutoFit();
        }

        public static void Export(System.Data.DataTable dt, DataGridView dataGrid, string sheetName, string title)
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


            // Tạo mảng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,

            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.

            object[,] arr = new object[dt.Rows.Count + 1, dt.Columns.Count];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int r = 0; r < dt.Rows.Count; r++)

            {
                DataRow dr = dt.Rows[r];

                for (int c = 0; c < dt.Columns.Count; c++)

                {
                    arr[0, c] = dataGrid.Columns[c].HeaderText.ToString();
                    arr[r + 1, c] = dr[c];
                }
            }

            //Thiết lập vùng điền dữ liệu

            int rowStart = 3;

            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count;

            int columnEnd = dt.Columns.Count;


            //in đậm tiêu đề
            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range((Microsoft.Office.Interop.Excel.Range)oSheet.Cells[3, columnStart],
                (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[3, columnEnd]);

            rowHead.Font.Bold = true;

            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

            //rowHead.Interior.ColorIndex = 15;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo phần đầu nếu muốn

            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range((Microsoft.Office.Interop.Excel.Range)oSheet.Cells[1, columnStart], (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[1, columnEnd]);

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Tahoma";

            head.Font.Size = "12";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //định dạng text
            range.NumberFormat = "@";

            //auto witdh

            //Điền dữ liệu vào vùng đã thiết lập

            range.Value2 = arr;

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột STT

            Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            oSheet.get_Range(c3, c4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            range.Columns.AutoFit();
        }

        public static void ExportThongKe(System.Data.DataTable dt, DataGridView dataGrid, string sheetName, string title)
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


            // Tạo mảng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,

            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.

            object[,] arr = new object[dt.Rows.Count + 1, dt.Columns.Count];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int r = 0; r < dt.Rows.Count; r++)

            {
                DataRow dr = dt.Rows[r];

                for (int c = 0; c < dt.Columns.Count; c++)

                {
                    arr[0, c] = dataGrid.Columns[c].HeaderText.ToString();
                    arr[r + 1, c] = dr[c];
                }
            }

            //Thiết lập vùng điền dữ liệu

            int rowStart = 3;

            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count;

            int columnEnd = dt.Columns.Count;


            //in đậm tiêu đề
            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range((Microsoft.Office.Interop.Excel.Range)oSheet.Cells[3, columnStart],
                (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[3, columnEnd]);

            rowHead.Font.Bold = true;

            //in đậm cột A
            Microsoft.Office.Interop.Excel.Range rowA = oSheet.get_Range((Microsoft.Office.Interop.Excel.Range)oSheet.Cells[3, 1],
                (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[100, 1]);

            rowA.Font.Bold = true;

            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

            //rowHead.Interior.ColorIndex = 15;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo phần đầu nếu muốn

            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range((Microsoft.Office.Interop.Excel.Range)oSheet.Cells[1, columnStart], (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[1, columnEnd]);

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Tahoma";

            head.Font.Size = "12";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //định dạng số ngăn cách bằng dấu .
            range.NumberFormat = "#,##0";

            //auto witdh

            //Điền dữ liệu vào vùng đã thiết lập

            range.Value2 = arr;

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột STT

            Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            oSheet.get_Range(c3, c4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            range.Columns.AutoFit();
        }

        public static SqlDataReader executeQueryTable(SqlConnection con, string sql)
        {
            SqlDataReader dr = null;
            using (con)
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    dr = cmd.ExecuteReader();
                }
            }
            return dr;
        }

        public static int executeQueryCount(SqlConnection con, string sql)
        {
            return Int32.Parse((new SqlCommand(sql, con).ExecuteScalar()).ToString());
        }

        public static List<string> executeQueryList(SqlConnection con, string sql)
        {
            List<string> lst = new List<string>();

            using (con)
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lst.Add(dr[0].ToString());
                    }
                    con.Close();
                }
            }

            return lst;
        }

        public static string format(string str)
        {
            int max = 0;
            string[] s = str.Split('\'');
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Length > max) str = s[i];
            }

            return str;
        }

        public static object[,] readExcel(string link)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(link);
            Microsoft.Office.Interop.Excel.Worksheet xlWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkbook.Sheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;
            object[,] valueArray = (object[,])xlRange.get_Value(Microsoft.Office.Interop.Excel.XlRangeValueDataType.xlRangeValueDefault);
            xlWorkbook.Close(0);
            xlApp.Quit();
            return valueArray;
        }

        public static string QuotationMarks(string str)
        {
            int count = str.Split('\'').Length;
            string result = str.Split('\'')[0];
            for (int i = 0; i < count - 1; i++)
            {
                result = result + "''" + str.Split('\'')[i + 1];
            }
            return result;
        }

        public static string removeChar(string tst)
        {
            var rgx4 = new Regex(@"[\r\n'/\\]");
            tst = rgx4.Replace(tst, string.Empty);
            return tst;
        }

        public static void FillDgv(SqlConnection conn, string sqlQuery, DataGridView dataGrid)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            dataGrid.DataSource = ds.Tables[0];
        }

        public static string convertToUnSign(string s)
        {
            //có dấu thành không dấu
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
    }
}
