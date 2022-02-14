using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private int CountCharacters()
        {
            int count = 0;
            // Create a StreamReader and point it to the file to read
            using (StreamReader reader = new StreamReader(@"C:\Users\ADMIN\Downloads\DataData.txt"))
            {
                string content = reader.ReadToEnd();
                count = content.Length;
                // Make the program look busy for 5 seconds
                Thread.Sleep(5000);
            }

            return count;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Create a task to execute CountCharacters() function
            // CountCharacters() function returns int, so we created Task
            Task<int> task = new Task<int>(CountCharacters);
            task.Start();

            lblCount.Text = "Processing file. Please wait...";
            // Wait until the long running task completes
            int count = await task;
            lblCount.Text = count.ToString() + " characters in file";
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // Create a task to execute CountCharacters() function
            // CountCharacters() function returns int, so we created Task
            Task<int> task = new Task<int>(CountCharacters);
            task.Start();

            label1.Text = "Processing file. Please wait...";
            // Wait until the long running task completes
            int count = await task;
            label1.Text = count.ToString() + " characters in file";
        }
    }
}
