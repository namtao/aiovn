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
using ADDJ.DuAn;
using System.Threading;

namespace ADDJ
{
    public partial class CountField : Form
    {
        string connectString = ConfigurationManager.ConnectionStrings["hotich"].ConnectionString;
        ThaiBinh tb = new ThaiBinh();

        public CountField()
        {
            InitializeComponent();
        }

        private void CountField_Load(object sender, EventArgs e)
        {
            //cbxTable_DropDown(sender, e);
            //cbxTable.SelectedIndex = 0;
        }

        private void cbxTable_DropDown(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectString);
            conn.Open();
            string strCmd = "select distinct TABLE_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME in ('HT_KHAISINH', 'HT_KHAITU', 'HT_KETHON', 'HT_NHANCHAMECON')";
            SqlCommand cmd = new SqlCommand(strCmd, conn);
            SqlDataAdapter da = new SqlDataAdapter(strCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            conn.Close();
            cbxTable.DisplayMember = "TABLE_NAME";
            cbxTable.ValueMember = "TABLE_NAME";
            cbxTable.DataSource = ds.Tables[0];
            list1.Visible = true;
            list2.Visible = true;
        }

        List<string> lst1 = new List<string>();
        List<string> lst2 = new List<string>();

        private void cbxTable_SelectedValueChanged(object sender, EventArgs e)
        {
            list1.Items.Clear();
            list2.Items.Clear();
            lst1.Clear();
            lst2.Clear();

            using (SqlConnection con = new SqlConnection(connectString))
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
            xuly();
        }

        private void CountField_FormClosing(object sender, FormClosingEventArgs e)
        {
            Home.form1.Show();
        }

        private void lbTren_Click(object sender, EventArgs e)
        {
            xuly();
        }

        private void lbDuoi_Click(object sender, EventArgs e)
        {
            xuly();
        }

        public void xuly()
        {
            string loai = "";
            new Thread(()=>
            {
                List<string> lstView = null;
                int tren = 0, duoi = 0;
                if (rdnAll.Checked)
                {
                    lstView = new List<string> { "view_ht_khaisinh_chitiet", "view_ht_khaitu_chitiet", "view_ht_kethon_chitiet", "view_ht_nhanchamecon_chitiet" };
                    loai = "Tất cả";
                }
                else if (rdnKS.Checked)
                {
                    lstView = new List<string> { "view_ht_khaisinh_chitiet" };
                    loai = "KS";
                }
                else if (rdnKT.Checked)
                {
                    lstView = new List<string> { "view_ht_khaitu_chitiet" };
                    loai = "KT";
                }
                else if (rdnKH.Checked)
                {
                    lstView = new List<string> { "view_ht_kethon_chitiet" };
                    loai = "KH";
                }
                else
                {
                    lstView = new List<string> { "view_ht_nhanchamecon_chitiet" };
                    loai = "CMC";
                }

                /*String.Format("{0:n}", 1234);  // Output: 1,234.00
                String.Format("{0:n0}", 9876); // No digits after the decimal point. Output: 9,876*/

                foreach (string view in lstView)
                {
                    // tính tổng số trường
                    using (SqlConnection con = new SqlConnection(connectString))
                    {
                        string sql = @"select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = @view";
                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@view", view);
                            con.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                            //duyệt từng bản ghi
                            while (dr.Read())
                            {
                                string sql2 = @"SELECT count(*) FROM " + view + " where " + dr[0].ToString().Trim() +
                                    " is not null and CAST(" + dr[0].ToString().Trim() + " as varchar(max)) != ''and len(" + dr[0].ToString().Trim() + ") < " + Int32.Parse(txtKyTu.Text) + "";
                                using (SqlConnection con2 = new SqlConnection(connectString))
                                {
                                    using (SqlCommand cmd2 = new SqlCommand(sql2, con2))
                                    {
                                        cmd2.CommandType = CommandType.Text;
                                        con2.Open();
                                        duoi += Convert.ToInt32(cmd2.ExecuteScalar());
                                    }
                                    con2.Close();
                                }
                            }

                            con.Close();
                        }
                    }

                    using (SqlConnection con = new SqlConnection(connectString))
                    {
                        string sql = @"select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = @view";
                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@view", view);
                            con.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                            //duyệt từng bản ghi
                            while (dr.Read())
                            {
                                var x = dr[0];
                                string sql2 = @"SELECT count(*) FROM " + view + " where " + dr[0].ToString().Trim() +
                                    " is not null and CAST(" + dr[0].ToString().Trim() + " as varchar(max)) != '' and len(" + dr[0].ToString().Trim() + ") >= " + Int32.Parse(txtKyTu.Text) + "";
                                using (SqlConnection con2 = new SqlConnection(connectString))
                                {
                                    using (SqlCommand cmd2 = new SqlCommand(sql2, con2))
                                    {
                                        cmd2.CommandType = CommandType.Text;
                                        con2.Open();
                                        tren += Convert.ToInt32(cmd2.ExecuteScalar());
                                    }
                                    con2.Close();
                                }
                            }

                            con.Close();
                        }
                    }
                }

                // Những gì liên quan đến giao diện thì cho vào Invoke
                Invoke(new System.Action(() =>
                {
                    lb.Text = loai + " - Tổng: " + String.Format("{0:n0}", (tren + duoi)) + " trường";
                    lbTren.Text = "Trên: " + String.Format("{0:n0}", (tren));
                    lbDuoi.Text = "Dưới: " + String.Format("{0:n0}", (duoi));
                }));
            }).Start();
            
        }

        private void rdnKS_CheckedChanged(object sender, EventArgs e)
        {
            xuly();
        }

        private void rdnKT_CheckedChanged(object sender, EventArgs e)
        {
            xuly();
        }

        private void rdnKH_CheckedChanged(object sender, EventArgs e)
        {
            xuly();
        }

        private void rdnCMC_CheckedChanged(object sender, EventArgs e)
        {
            xuly();
        }

        private void rdnAll_CheckedChanged(object sender, EventArgs e)
        {
            xuly();
        }
    }
}
