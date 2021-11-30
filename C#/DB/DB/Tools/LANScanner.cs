using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB
{
    public partial class LANScanner : Form
    {
        public LANScanner()
        {
            InitializeComponent();
        }

        public string GetMacAddress(string ipAddress)
        {
            try
            {
                string macAddress = string.Empty;
                System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
                pProcess.StartInfo.FileName = "arp";
                pProcess.StartInfo.Arguments = "-a " + ipAddress;
                pProcess.StartInfo.UseShellExecute = false;
                pProcess.StartInfo.RedirectStandardOutput = true;
                pProcess.StartInfo.CreateNoWindow = true;
                pProcess.Start();
                string strOutput = pProcess.StandardOutput.ReadToEnd();
                string[] substrings = strOutput.Split('-');
                if (substrings.Length >= 8)
                {
                    macAddress = substrings[3].Substring(Math.Max(0, substrings[3].Length - 2))
                        + "-" + substrings[4] + "-" + substrings[5] + "-" + substrings[6]
                        + "-" + substrings[7] + "-"
                        + substrings[8].Substring(0, 2);
                    return macAddress;
                }
                else
                {
                    return "not found";
                }
            } catch(Exception ex)
            {
                return "not found";
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            string subnet = txtSubnet.Text;
            progressBar.Maximum = 254;
            progressBar.Value = 0;
            lvResult.Items.Clear();

            Task.Factory.StartNew(new Action(() =>
            {
                for (int i = 2; i < 255; i++)
                {
                    string ip = $"{subnet}.{i}";
                    Ping ping = new Ping();
                    PingReply reply = ping.Send(ip, 100);
                    if (reply.Status == IPStatus.Success)
                    {
                        progressBar.BeginInvoke(new Action(() =>
                        {
                            try
                            {
                                IPHostEntry host = Dns.GetHostEntry(IPAddress.Parse(ip));
                                var hostname = host.HostName;

                                lvResult.Items.Add(new ListViewItem(new String[] { ip, hostname, GetMacAddress(ip), "Up" }));
                            }
                            catch
                            {
                                //MessageBox.Show($"Couldn't retrieve hostname from {ip}", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                lvResult.Items.Add(new ListViewItem(new String[] { ip, "Not found", GetMacAddress(ip), "Up" }));
                            }
                            progressBar.Value += 1;
                            lblStatus.ForeColor = Color.Blue;
                            lblStatus.Text = $"Scanning: {ip}";
                            if (progressBar.Value == 253)
                                lblStatus.Text = "Finished";
                        }));
                    }
                    else
                    {
                        progressBar.BeginInvoke(new Action(() =>
                        {
                            progressBar.Value += 1;
                            lblStatus.ForeColor = Color.DarkGray;
                            lblStatus.Text = $"Scanning: {ip}";
                            //lvResult.Items.Add(new ListViewItem(new String[] { ip, "", "Down" }));
                            if (progressBar.Value == 253)
                            {
                                lblStatus.Text = "Finished";
                                progressBar.Value = 0;
                            }
                        }));
                    }
                }
            }));
        }
    }
}
