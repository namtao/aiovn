using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilsLib
{
    public class StringFormat
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
    }
}
