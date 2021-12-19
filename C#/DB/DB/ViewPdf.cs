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
        List<string> lstImage, lstSplit;
        string pathPdf, pathJpg = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources");
        string output;
        public ViewPdf()
        {
            InitializeComponent();
        }

        private void ViewPdf_Load(object sender, EventArgs e)
        {
            pathPdf = @"C:\Users\ADMIN\Downloads\CHUONGV.pdf";
            runCmd(@"python C:\Projects\Python\Applications\utils\pdf2jpg.py " + pathPdf + " " + pathJpg);
            //long length = new System.IO.FileInfo(pathPdf).Length;
            MessageBox.Show(output);


            lstImage = new List<string>();
            int count = 0;
            DirectoryInfo dir = new DirectoryInfo(pathJpg); //change and get your folder
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
                item.Text = j.ToString();
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

            //pictureBox1.Image = Image.FromFile(lstImage[item.ImageIndex]);

        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
            e.DrawBackground();
            //e.Graphics.DrawRectangle(Pens.Gray, e.Bounds);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lstImage = new List<string>();
            int count = 0;
            DirectoryInfo dir = new DirectoryInfo(pathJpg); //change and get your folder
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

        private void listView1_Click(object sender, EventArgs e)
        {
            ListViewItem item = listView1.SelectedItems[0];
            pictureBox1.Image = Image.FromFile(lstImage[item.ImageIndex]);
        }

        private void listView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.BackColor == Color.BurlyWood)
                    {
                        lstSplit.Add(item.ImageIndex + "");
                        MessageBox.Show(item.ImageIndex + "");
                    }
                }
            }
        }

        public void runCmd(string cmd)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/k " + cmd;
            process.StartInfo = startInfo;
            process.Start();
        }

    }
}
