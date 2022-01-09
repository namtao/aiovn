using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Company
{
    public class ItemComparer : System.Collections.IComparer
    {
        //column used for comparison
        public int Column { get; set; }

        //Order of sorting
        public SortOrder Order { get; set; }

        public ItemComparer(int colIndex)
        {
            Column = colIndex;
            Order = SortOrder.None;

        }
        public int Compare(object a, object b)
        {
            int result;

            ListViewItem itemA = a as ListViewItem;
            ListViewItem itemB = b as ListViewItem;
            if (itemA == null && itemB == null)
                result = 0;
            else if (itemA == null)
                result = -1;
            else if (itemB == null)
                result = 1;

            if (itemA == itemB)
                result = 0;

            // datetime comparison
            DateTime x1, y1;
            // Parse the two objects passed as a parameter as a DateTime.
            if (!DateTime.TryParse(itemA.SubItems[Column].Text, out x1))
                x1 = DateTime.MinValue;
            if (!DateTime.TryParse(itemB.SubItems[Column].Text, out y1))
                y1 = DateTime.MinValue;
            result = DateTime.Compare(x1, y1);

            if (x1 != DateTime.MinValue && y1 != DateTime.MinValue)
                goto done;

            //numeric comparison
            decimal x2, y2;
            if (!Decimal.TryParse(itemA.SubItems[Column].Text, out x2))
                x2 = Decimal.MinValue;
            if (!Decimal.TryParse(itemB.SubItems[Column].Text, out y2))
                y2 = Decimal.MinValue;
            result = Decimal.Compare(x2, y2);

            if (x2 != Decimal.MinValue && y2 != Decimal.MinValue)
                goto done;

            //alphabetic comparison
            result = String.Compare(itemA.SubItems[Column].Text, itemB.SubItems[Column].Text);



        done:
            // if sort order is descending.
            if (Order == SortOrder.Descending)
                // Invert the value returned by Compare.
                result *= -1;
            return result;

        }
    }
}
