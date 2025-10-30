using System;
using System.Data.Entity;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ClinicMgmtApp_Project.DAL
{
    internal class DatabaseConnection
    {
        private static readonly string sqlConnectionString = ConfigurationManager.ConnectionStrings["ClinicMgmtDBCS"].ConnectionString;

        private static SqlConnection sqlConnection = null;

        public static SqlConnection GetConnection()
        {
            if (sqlConnection == null)
            {
                sqlConnection = new SqlConnection(sqlConnectionString);
            }

            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }

            return sqlConnection;
        }

        public static void CloseConnection()
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
        }
    }
}
