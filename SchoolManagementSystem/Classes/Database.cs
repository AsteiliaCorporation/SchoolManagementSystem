using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace SchoolManagementSystem.Classes
{
    internal class Database
    {
        #region Global Variables

        private SqlConnection conn;

        #endregion

        public void Connect()
        {
            //string databaseDevice = @"DESKTOP-SSMVUMG\ASTEILIA_DB";
            string databaseDevice = GetServerExternalIp().ToString() + @"\SQLEXPRESS,1433";
            string databaseName = "ASTEILIA";
            string databaseUsername = "sa";
            string databasePassword = "Su16ta_ali";
            string connectionString = ""
                + "Data Source=" + databaseDevice + ";"
                + "Initial Catalog=" + databaseName + ";"
                + "User ID=" + databaseUsername + ";"
                + "Password=" + databasePassword;

            conn = new SqlConnection(connectionString);

            conn.Open();
        }

        public void Disconnect()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Dispose();
            }
        }

        public SqlConnection GetConnection()
        {
            return conn;
        }

        private IPAddress GetServerExternalIp()
        {
            return IPAddress.Parse(new WebClient().DownloadString("http://icanhazip.com").Replace("\\r\\n", "").Replace("\\n", "").Trim());
        }
    }
}
