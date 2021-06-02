using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Data.SqlClient;

namespace LEARN
{
    public partial class formHome : Form
    {

        public formHome()
        {
            InitializeComponent();
        }

        private void formHome_Load(object sender, EventArgs e)
        {
            //notify();
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.Close();
        }

        private void txtExa_KeyDown(object sender, KeyEventArgs e)
        {
            eventbutton(e);
        }

        private void txtEng_KeyDown(object sender, KeyEventArgs e)
        {
            eventbutton(e);
        }

        private void txtVie_KeyDown(object sender, KeyEventArgs e)
        {
            eventbutton(e);
        }

        private void txtSpelling_KeyDown(object sender, KeyEventArgs e)
        {
            eventbutton(e);
        }
    
        private void notify()
        {            
            Data data = new Data();
            SqlConnection conn = data.GetConnect();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ENGLISHTOVIETNAMESE WHERE ID = " +
                "(SELECT TOP 1 ID FROM ENGLISHTOVIETNAMESE ORDER BY NEWID())", conn);
            sqlCommand.ExecuteNonQuery();
            SqlDataReader dr = sqlCommand.ExecuteReader();
            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    //Icon trên khay hệ thống
                    notifyIcon1.Icon = SystemIcons.WinLogo;

                    //Biểu tượng xuất hiện trên thông báo
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;

                    notifyIcon1.BalloonTipText = dr[1].ToString().ToUpper() + "   " + dr[2].ToString() + ":   " 
                        + dr[3].ToString().ToUpper() + "\n" + dr[4].ToString().ToUpper();
                    notifyIcon1.BalloonTipTitle = "Thông báo!";
                    // set icon
                    notifyIcon1.Icon = Properties.Resources.favicon;

                    notifyIcon1.ShowBalloonTip(2000);
                }
            }
            conn.Close();
        }

        private void formHome_SizeChanged(object sender, EventArgs e)
        {
            bool MousePointerNotOnTaskBar = Screen.GetWorkingArea(this).Contains(Cursor.Position);

            if(this.WindowState == FormWindowState.Minimized && MousePointerNotOnTaskBar)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                notify();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            if(this.WindowState == FormWindowState.Normal)
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
            this.Show();
        }

        public void eventbutton(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtEng.Text != "" && txtExa.Text != "" && txtSpelling.Text != "" && txtVie.Text != "")
                {
                    try
                    {
                        Data data = new Data();
                        SqlConnection conn = data.GetConnect();
                        conn.Open();
                        String sql = "INSERT INTO ENGLISHTOVIETNAMESE values(N'" + txtEng.Text.ToUpper() + "',N'" + txtSpelling.Text + "', " +
                            "N'" + txtVie.Text.ToUpper() + "',N'" + txtVie.Text.ToUpper() + "')";
                        SqlCommand sqlCommand = new SqlCommand(sql, conn);
                        sqlCommand.ExecuteNonQuery();
                        txtEng.Text = "";
                        txtSpelling.Text = "";
                        txtVie.Text = "";
                        txtExa.Text = "";
                        conn.Open();
                        lbFinish.Visible = true;
                    }
                    catch (Exception exx)
                    {
                        lbError.Visible = true;
                    }
                }
            }


            if (e.KeyCode == Keys.Escape)
            {
                this.WindowState=FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                notify();
            }
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_BalloonTipShown(object sender, EventArgs e)
        {
            //MessageBox.Show("OK");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            notify();
        }
    }


}
