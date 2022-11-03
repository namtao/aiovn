using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace xD
{
    public partial class ConnectDB : Form
    {
        public static ConnectDB connect;

        public ConnectDB()
        {
            InitializeComponent();
            connect = this;
        }

        public SqlConnection getConnect()
        {
            return new SqlConnection(@"Data Source=" + txtServer.Text.Trim() + ";Initial Catalog = HoTich;"
                    + "User ID=" + txtUserName.Text.Trim() + " ;Password=" + txtPassword.Text.Trim()
                    );
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = getConnect();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    HoTich.sqlConnect = @"Data Source=" + txtServer.Text.Trim() + ";Initial Catalog=HoTich;" +
                    "User ID=" + txtUserName.Text.Trim() + " ;Password=" + txtPassword.Text.Trim();
                    Home form = new Home();
                    form.Show();
                    getConnect().Close();
                    this.Hide();
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlConnection.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txtServer.Text = @"WIN-U3V1ATJPGQM\MSSQLSERVER01";
            txtUserName.Text = "sa";
            txtPassword.Text = "P@ssword";
        }
    }
}
