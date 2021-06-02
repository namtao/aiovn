using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.ServiceProcess;
using System.Threading;

namespace UpdateSentencase
{
    public partial class HomService : ServiceBase
    {
        private System.Timers.Timer scheduleServices;
        Thread threadKS, threadKT, threadKH, threadCMC;
        public HomService()
        {
            InitializeComponent();
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Log.txt"))
            {
                File.CreateText(AppDomain.CurrentDomain.BaseDirectory + "Log.txt");
            }
            scheduleServices = new System.Timers.Timer();
            scheduleServices.Interval = 120 * 1000;
            scheduleServices.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            scheduleServices.Start();
        }

        protected override void OnStart(string[] args)
        {
            Utils.WriteLog("Start services...");
            scheduleServices.Stop();
            scheduleServices.Start();
            doWorking();
        }

        protected override void OnStop()
        {
            Utils.WriteLog("Stop services...");
        }

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            Utils.WriteLog("OnTimer...");
            if (threadKS.ThreadState == System.Threading.ThreadState.Stopped)
            {
                doWorking();
            }
            else Utils.WriteLog("Continue...");
        }

        public void doWorking()
        {
            Utils.WriteLog("Thread running...");
            threadKS = new Thread(() =>
                {
                    try
                    {
                        using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog = HoTich;Integrated Security=True"))
                        {
                            con.Open();
                            string sql = "use HoTich; " +
                            "SELECT id, nksNoiSinh FROM HT_KHAISINH " +
                            "where TinhTrangID = 5 " +
                            "and id not in (select id from UpdateSentencase where TableName = 'HT_KHAISINH')";
                            using (SqlCommand cmd = new SqlCommand(sql, con))
                            {
                                cmd.CommandType = CommandType.Text;
                                SqlDataReader dr = cmd.ExecuteReader();
                                while (dr.Read())
                                {
                                    string sqlQuery = "use HoTich; " +
                                    "update HT_KHAISINH " +
                                    "set nksNoiSinh = (select dbo.ProperCase(N'" + Utils.QuotationMarks(dr["nksNoiSinh"].ToString()) + "')) " +
                                    "where id= " + dr["id"] + ";" +
                                    "SET IDENTITY_INSERT UpdateSentencase ON;" +
                                    "insert into UpdateSentencase(id, tableName) values (" + dr[0] + ", 'HT_KHAISINH');" +
                                    "SET IDENTITY_INSERT UpdateSentencase off;";
                                    SqlConnection sqlConnection = new SqlConnection(@"Data Source=.;Initial Catalog=HoTich;Integrated Security=True");
                                    sqlConnection.Open();
                                    SqlCommand cmd2 = new SqlCommand(sqlQuery, sqlConnection);
                                    cmd2.ExecuteNonQuery();
                                    sqlConnection.Close();
                                }
                            }
                            con.Close();
                        };
                    }
                    catch (Exception ex)
                    {
                        Utils.WriteLog(ex.Message);
                    }
                });
            threadKS.Start();

            threadKT = new Thread(() =>
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog = HoTich;Integrated Security=True"))
                    {
                        con.Open();
                        string sql = "use HoTich; " +
                        "SELECT id, nktNoiChet from HT_KHAITU " +
                        "where TinhTrangID = 5 " +
                        "and id not in (select id from UpdateSentencase where TableName = 'HT_KHAITU')";
                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            SqlDataReader dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                string sqlQuery = "use HoTich; " +
                                "update HT_KHAITU " +
                                "set nktNoiChet = (select dbo.ProperCase(N'" + Utils.QuotationMarks(dr["nktNoiChet"].ToString()) + "')) " +
                                "where id= " + dr["id"] + ";" +
                                "SET IDENTITY_INSERT UpdateSentencase ON;" +
                                "insert into UpdateSentencase(id, tableName) values (" + dr[0] + ", 'HT_KHAITU');" +
                                "SET IDENTITY_INSERT UpdateSentencase off;";
                                SqlConnection sqlConnection = new SqlConnection(@"Data Source=.;Initial Catalog=HoTich;Integrated Security=True");
                                sqlConnection.Open();
                                SqlCommand cmd2 = new SqlCommand(sqlQuery, sqlConnection);
                                cmd2.ExecuteNonQuery();
                                sqlConnection.Close();
                            }
                        }
                        con.Close();
                    };
                }
                catch (Exception ex)
                {
                    Utils.WriteLog(ex.Message);
                }
            });
            threadKT.Start();

            threadKH = new Thread(() =>
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog = HoTich;Integrated Security=True"))
                    {
                        con.Open();
                        string sql = "use HoTich; " +
                        "SELECT id, chongNoiCuTru from HT_KETHON " +
                        "where TinhTrangID = 5 " +
                        "and id not in (select id from UpdateSentencase where TableName = 'HT_KETHON')";
                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            SqlDataReader dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                string sqlQuery = "use HoTich; " +
                                "update HT_KETHON " +
                                "set chongNoiCuTru = (select dbo.ProperCase(N'" + Utils.QuotationMarks(dr["chongNoiCuTru"].ToString()) + "')) " +
                                "where id= " + dr["id"] + ";" +
                                "SET IDENTITY_INSERT UpdateSentencase ON;" +
                                "insert into UpdateSentencase(id, tableName) values (" + dr[0] + ", 'HT_KETHON');" +
                                "SET IDENTITY_INSERT UpdateSentencase off;";
                                SqlConnection sqlConnection = new SqlConnection(@"Data Source=.;Initial Catalog=HoTich;Integrated Security=True");
                                sqlConnection.Open();
                                SqlCommand cmd2 = new SqlCommand(sqlQuery, sqlConnection);
                                cmd2.ExecuteNonQuery();
                                sqlConnection.Close();
                            }
                        }
                        con.Close();
                    };
                }
                catch (Exception ex)
                {
                    Utils.WriteLog(ex.Message);
                }
            });
            threadKH.Start();   

            threadCMC = new Thread(() =>
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog = HoTich;Integrated Security=True"))
                    {
                        con.Open();
                        string sql = "use HoTich; " +
                        "SELECT id, ncNoiCuTru from HT_NHANCHAMECON " +
                        "where TinhTrangID = 5 " +
                        "and id not in (select id from UpdateSentencase where TableName = 'HT_NHANCHAMECON')";
                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            SqlDataReader dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                string sqlQuery = "use HoTich; " +
                                "update HT_NHANCHAMECON " +
                                "set ncNoiCuTru = (select dbo.ProperCase(N'" + Utils.QuotationMarks(dr["ncNoiCuTru"].ToString()) + "')) " +
                                "where id= " + dr["id"] + ";" +
                                "SET IDENTITY_INSERT UpdateSentencase ON;" +
                                "insert into UpdateSentencase(id, tableName) values (" + dr[0] + ", 'HT_NHANCHAMECON');" +
                                "SET IDENTITY_INSERT UpdateSentencase off;";
                                SqlConnection sqlConnection = new SqlConnection(@"Data Source=.;Initial Catalog=HoTich;Integrated Security=True");
                                sqlConnection.Open();
                                SqlCommand cmd2 = new SqlCommand(sqlQuery, sqlConnection);
                                cmd2.ExecuteNonQuery();
                                sqlConnection.Close();
                            }
                        }
                        con.Close();
                    };
                }
                catch (Exception ex)
                {
                    Utils.WriteLog(ex.Message);
                }
            });
            threadCMC.Start();
        }
    }
}
