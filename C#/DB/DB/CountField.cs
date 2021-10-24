using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using System.Configuration;
using Microsoft.Office.Interop.Excel;
using DB.DuAn;

namespace DB
{
    public partial class CountField : Form
    {
        string connectString = ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
        public static string sqlConnect;
        ThaiBinh tb;

        public CountField()
        {
            InitializeComponent();
        }
                
        private void CountField_Load(object sender, EventArgs e)
        {
            tb = new ThaiBinh();
            tb.countFieldExcelSau();
            //tb.countFieldExcelTruoc();
            this.Close();
        }

        private void cbxTable_DropDown(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=SLDTTBImport;Integrated Security=True");
            conn.Open();
            string strCmd = "select distinct TABLE_NAME from INFORMATION_SCHEMA.COLUMNS";
            SqlCommand cmd = new SqlCommand(strCmd, conn);
            SqlDataAdapter da = new SqlDataAdapter(strCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            conn.Close();
            cbxTable.DisplayMember = "TABLE_NAME";
            cbxTable.ValueMember = "TABLE_NAME";
            cbxTable.DataSource = ds.Tables[0];
        }

        List<string> lst1 = new List<string>();
        List<string> lst2 = new List<string>();

        private void cbxTable_SelectedValueChanged(object sender, EventArgs e)
        {
            list1.Items.Clear();
            list2.Items.Clear();
            lst1.Clear();
            lst2.Clear();

            using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=SLDTTBImport;Integrated Security=True"))
            {
                /*string sql = "select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS " +
                    "where COLUMN_NAME not like '%id%' and COLUMN_NAME not like '%stt%' " +
                    "and COLUMN_NAME not like '%status%' and COLUMN_NAME not like '%trangthai%' " +
                    "and COLUMN_NAME not like 'is%' and TABLE_NAME = '" + cbxTable.Text + "'";*/
                string sql = "select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS " +
                    "where TABLE_NAME = '" + cbxTable.Text + "'";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lst1.Add(dr[0].ToString());
                    }
                    con.Close();
                }
            }

            foreach (string a in lst1)
            {
                list1.Items.Add(a);
            }
        }

        private void list1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lst2.Add(lst1[list1.SelectedIndex]);

            lst1.RemoveAt(list1.SelectedIndex);


            clearListBox();

        }

        private void list2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lst1.Add(lst2[list2.SelectedIndex]);

            lst2.RemoveAt(list2.SelectedIndex);

            clearListBox();

        }

        public void clearListBox()
        {
            list1.Items.Clear();
            list2.Items.Clear();

            foreach (string a in lst1)
            {
                list1.Items.Add(a);
            }

            foreach (string a in lst2)
            {
                list2.Items.Add(a);
            }
        }

        /*public int DemTruong(string table, List<string> list)
        {
            int count = 0;
            using (SqlConnection con = new SqlConnection(connectString))
            {
                con.Open();
                foreach (string a in list)
                {
                    if (!a.Equals("Id"))
                    {
                        string sql = "select count(*) from " + table + " " +
                            "where " + a + " is not null and CAST(" + a + " as varchar(max)) != '' and CAST(" + a + " as varchar(max)) != '__/__/____'";
                        count += Int32.Parse((new SqlCommand(sql, con).ExecuteScalar().ToString()));
                    }
                }
            }
            return count;
        }

        public int countAllColumn(string table)
        {
            SqlConnection con = new SqlConnection(connectString);
            string sql = "select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '" + table + "'";
            List<string> lst = Utils.executeQueryList(con, sql);

            return DemTruong(table, lst);
        }*/

        private void lb_Click(object sender, EventArgs e)
        {
            lb.Text = "Có " + tb.DemTruong(cbxTable.Text, lst1).ToString() + " trường";
        }

        private void CountField_FormClosing(object sender, FormClosingEventArgs e)
        {
            Home.form1.Show();
        }
    }
}
