using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;

namespace Company
{
    public partial class ReportViewer : Form
    {
        public static string connectString = ConfigurationManager.ConnectionStrings["ADDJ"].ConnectionString;

        public ReportViewer()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            /*string strSql = "select * from ThietBi where id = 324";
            SqlDataAdapter adapter = new SqlDataAdapter(strSql, connectString);
            DataSet dataReport = new DataSet();
            adapter.Fill(dataReport, "ThietBi");

            CrystalReport crystal = new CrystalReport();
            crystal.SetDataSource(dataReport);
            crystalReportViewer.ReportSource = crystal;*/
        }

        private void ReportViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            QuanLyThietBi.form1.Show();
        }
    }
}
