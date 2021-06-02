using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Handle
{
    public class DB
    {
        String conn;

        public DB(String conn)
        {
            this.conn = conn;
        }

        public DataTable GetTable(String sql)
        {
            SqlConnection con = GetConnect();
            con.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, con);
            SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();
            return (dt);
        }

        public void Load(String sql, DataGridView dgv)
        {
            SqlConnection con = GetConnect();
            con.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, con);
            SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dgv.DataSource = dt;
            con.Close();
        }

        public void Load(String sql, ComboBox cbx,String value, String display)
        {
            SqlConnection con = GetConnect();
            SqlDataAdapter daChungloai = new SqlDataAdapter(sql, con);
            DataTable dtChungloai = new DataTable();
            daChungloai.Fill(dtChungloai);
            cbx.DataSource = dtChungloai;
            cbx.ValueMember = value;
            cbx.DisplayMember = display;
        }

        public SqlConnection GetConnect()
        {
            return new SqlConnection(conn);
        }

        public void Insert(String  sql)
        {
            SqlConnection con = GetConnect();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
        }

        public void Update(String sql)
        {
            SqlConnection con = GetConnect();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
        }

        public void Delete(String sql)
        {
            SqlConnection con = GetConnect();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
        }

        public void TimKiem(String sql, DataGridView dgv)
        {
            DataTable dt = new DataTable();
            dt = GetTable(sql);
            SqlConnection con = GetConnect();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            dgv.DataSource = dt;
            con.Close();
            cmd.Dispose();
        }
    }
}
