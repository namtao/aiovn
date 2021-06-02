using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateSentencase
{
    class Utils
    {
        public static void WriteLog(string str)
        {
            using (StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + "Log.txt"))
            {
                sw.WriteLine(DateTime.Now + "\t"+ str);
            }
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
