using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ClinicMgmtApp_Project.BLL;

namespace ClinicMgmtApp_Project.DAL
{
    internal class UserDB
    {
        private static SqlConnection sqlConnection = null;
        private static SqlCommand sqlCommand = null;

        public static List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            
            try
            {
                sqlConnection = DatabaseConnection.GetConnection();

                sqlCommand = new SqlCommand("SELECT * FROM User", sqlConnection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    User user = new User
                    {
                        Username = sqlDataReader["Username"].ToString(),
                        Password = sqlDataReader["Password"].ToString(),
                        Role = sqlDataReader["Role"].ToString()
                    };

                    users.Add(user);
                }
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }

            return users;
        }
    }
}
