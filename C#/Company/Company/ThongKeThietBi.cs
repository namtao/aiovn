using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Company
{
    public partial class ThongKeThietBi : Form
    {
        public ThongKeThietBi()
        {
            InitializeComponent();
        }

        private void ThongKeThietBi_FormClosing(object sender, FormClosingEventArgs e)
        {
            Home.form1.Show();
        }
    }
}
