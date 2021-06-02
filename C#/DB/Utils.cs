using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DB
{
    class Utils
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


        public static void ExportThongKe(DataTable dt, DataGridView dataGrid, string sheetName, string title)
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

        public static void Export(DataTable dt, DataGridView dataGrid, string sheetName, string title)
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
    }
}
