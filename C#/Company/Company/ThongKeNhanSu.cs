using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Company
{
    public partial class ThongKeNhanSu : Form
    {
        public ThongKeNhanSu()
        {
            InitializeComponent();
        }

        private void ThongKeNhanSu_FormClosing(object sender, FormClosingEventArgs e)
        {
            HoTich.form1.Show();
        }

        private void btnExe_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                SqlConnection conn = new SqlConnection(HoTich.sqlConnect);
                conn.Open();
                string str = "exec [dbo].[HT_ThongKeNhanSu] '" + dtTo.Value.ToString("dd/MM/yyyy") + "', '" + dtFrom.Value.ToString("dd/MM/yyyy") + "', null, null";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(str, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();

                DataTable dt = ds.Tables[0];
                datagrid.DataSource = ds.Tables[0];
                Utils.Export(dt, datagrid, "Nhân sự", "Thống kê nhân sự");
            }).Start();
            this.Close();
        }
    }
}
