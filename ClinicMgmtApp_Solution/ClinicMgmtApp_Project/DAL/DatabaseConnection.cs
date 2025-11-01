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
            try
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
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Failed to connect to the database: " + ex.Message);
            }
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
