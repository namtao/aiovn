using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB
{
    public partial class ViewPdf : Form
    {
        List<string> lstImage = new List<string>();
        public ViewPdf()
        {
            InitializeComponent();
        }

        private void ViewPdf_Load(object sender, EventArgs e)
        {
            runCmd("ipconfig & ipconfig");

            int count = 0;
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\ADMIN\Downloads"); //change and get your folder
            foreach (FileInfo file in dir.GetFiles())
            {
                try
                {
                    this.imageList1.Images.Add(count++.ToString(), Image.FromFile(file.FullName));
                    lstImage.Add(file.FullName);
                }
                catch
                {
                    Console.WriteLine("This is not an image file");
                }
            }
            this.listView1.View = View.LargeIcon;
            this.imageList1.ImageSize = new Size(256, 256);
            this.listView1.LargeImageList = this.imageList1;
            //or
            //this.listView1.View = View.SmallIcon;
            //this.listView1.SmallImageList = this.imageList1;

            for (int j = 0; j < this.imageList1.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                //item.Text = j.ToString();
                this.listView1.Items.Add(item);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;
            ListViewItem item = listView1.SelectedItems[0];
            if (item.BackColor != Color.BurlyWood) item.BackColor = Color.BurlyWood;
            else item.BackColor = Color.White;


            /*if (listView1.SelectedItems.Count == 0)
                return;
            ListViewItem item = listView1.SelectedItems[0];
            Image img1 = imageList1.Images[item.ImageIndex];
            Image img2 = item.Tag as Image;*/

            pictureBox1.Image = Image.FromFile(lstImage[item.ImageIndex]);

        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
            e.DrawBackground();
            //e.Graphics.DrawRectangle(Pens.Gray, e.Bounds);
        }

        public void runCmd(string cmd)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/k " + cmd;
            process.StartInfo = startInfo;
            process.Start();
        }

    }
}
