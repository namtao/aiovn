using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handle
{
    public class check
    {
        public Boolean IsNumber(string str)
        {
            foreach (Char c in str)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        public Boolean IsPhone(string phone)
        {
            if(phone.Length==10 && IsNumber(phone))
            return true;
            return false;
        }
    }
}
