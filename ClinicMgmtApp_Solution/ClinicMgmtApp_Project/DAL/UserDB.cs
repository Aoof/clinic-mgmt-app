using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;
using ClinicMgmtApp_Project.BLL;

namespace ClinicMgmtApp_Project.DAL
{
    internal class UserDB
    {
        private static SqlConnection sqlConnection = null;
        private static SqlCommand sqlCommand = null;
        private static bool VerifyPassword(string plainPassword, string storedHash)
        {
            byte[] hashBytes = Convert.FromBase64String(storedHash);
            // ^ Change back to a byte array to work better with it
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            // ^ Retrieve the salt from the byte array
            var pbkdf2 = new Rfc2898DeriveBytes(plainPassword, salt, 10000);
            // ^ Hash the input password with the same salt and iterations
            byte[] hash = pbkdf2.GetBytes(20);
            // ^ Retrieve the new hash and it should be exactly the same as the old one so we can compare them
            for (int i = 0; i < 20; i++) // 20 cause hash length is 20
            {
                if (hashBytes[i + 16] != hash[i]) // Since we start at 0 we should offset it by 16 (to skip over the salt) 
                {
                    return false;
                }
            }
            return true;
        }

        private static string GenerateSaltedHash(string plainPassword)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            // ^ This generates a 16 byte salt using the built-in cryptographic random number generator
            var pbkdf2 = new Rfc2898DeriveBytes(plainPassword, salt, 10000);
            // ^ Running the hash with that 16 byte salt for 10,000 iterations
            byte[] hash = pbkdf2.GetBytes(20);
            // ^ This gets the resulting 20 byte hash (The default is length of 20 so we hardcode it)
            byte[] hashBytes = new byte[36];
            // ^ Setting up so that we can make it store the salt + hash together in the same string (we'll retrieve that later on to decrypt it)
            Array.Copy(salt, 0, hashBytes, 0, 16);
            // ^ Copying the first 16 bytes (the salt) to the byte array
            Array.Copy(hash, 0, hashBytes, 16, 20);
            // ^ Copying the next 20 bytes (the hash) to the byte array
            return Convert.ToBase64String(hashBytes); // < Turning the byte array into a Base64 string to store in the database
        }
        public static List<User> GetAllUsers()
        {
            if (UserStore.GetUser().Role != "Admin")
            {
                throw new UnauthorizedException("Access denied: Only Admin users can retrieve all users.");
            }

            List<User> users = new List<User>();
            
            try
            {
                sqlConnection = DatabaseConnection.GetConnection();

                sqlCommand = new SqlCommand("SELECT * FROM [dbo].[User]", sqlConnection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    User user = new User
                    {
                        Id = Convert.ToInt32(sqlDataReader["Id"]),
                        Username = sqlDataReader["Username"].ToString(),
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

        public static User AuthenticateUser(string username, string plainPassword)
        {
            // Chose to use pbkdf2 for password hashing + salting for better security (More info is in VerifyPassword and GenerateSaltedHash methods)
            User authenticatedUser = null;
            try
            {
                sqlConnection = DatabaseConnection.GetConnection();
                sqlCommand = new SqlCommand("SELECT * FROM [dbo].[User] WHERE Username = @Username", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Username", username);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    string storedHash = sqlDataReader["PasswordHash"].ToString();
                    if (VerifyPassword(plainPassword, storedHash))
                    {
                        authenticatedUser = new User(
                            Convert.ToInt32(sqlDataReader["Id"]), 
                            sqlDataReader["Username"].ToString(), 
                            sqlDataReader["Role"].ToString()
                        );
                    } else
                    {
                        throw new InvalidCredentialsException("Authentication failed: Incorrect password.");
                    }
                }
                else
                {
                    throw new UserNotFoundException("Authentication failed: User not found or incorrect password.");
                }
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
            return authenticatedUser;
        }

        public static void CreateUser(User entity, string plainPassword)
        {
            // Temporarily comment out to allow initial user creation
            if (UserStore.GetUser().Role != "Adminstrator")
            {
                throw new UnauthorizedAccessException("Access denied: Only Adminstrator users can create new users.");
            }
            try
            {
                sqlConnection = DatabaseConnection.GetConnection();
                sqlCommand = new SqlCommand("INSERT INTO [dbo].[User] (Username, PasswordHash, Role) VALUES (@Username, @PasswordHash, @Role)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Username", entity.Username);
                sqlCommand.Parameters.AddWithValue("@PasswordHash", GenerateSaltedHash(Validator.ValidatePassword(plainPassword)));
                sqlCommand.Parameters.AddWithValue("@Role", entity.Role);
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static void DeleteUser(string username)
        {
            if (UserStore.GetUser().Role != "Adminstrator")
            {
                throw new UnauthorizedException("Access denied: Only Admin users can delete users.");
            }
            try
            {
                sqlConnection = DatabaseConnection.GetConnection();
                sqlCommand = new SqlCommand("DELETE FROM [dbo].[User] WHERE Username = @Username", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Username", username);
                int rowsAffected = sqlCommand.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new UserNotFoundException("Deletion failed: User not found.");
                }
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static void UpdateUser(User entity, string newPassword = null)
        {
            if (UserStore.GetUser().Role != "Adminstrator")
            {
                throw new UnauthorizedException("Access denied: Only Admin users can update users.");
            }

            try
            {
                sqlConnection = DatabaseConnection.GetConnection();
                sqlCommand = new SqlCommand();
                if (newPassword != null)
                {
                    sqlCommand = new SqlCommand("UPDATE [dbo].[User] SET Username = @Username, PasswordHash = @PasswordHash, Role = @Role WHERE Id = @Id", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@PasswordHash", GenerateSaltedHash(Validator.ValidatePassword(newPassword)));
                }
                else
                {
                    sqlCommand = new SqlCommand("UPDATE User SET Username = @Username, Role = @Role WHERE Id = @Id", sqlConnection);
                }
                sqlCommand.Parameters.AddWithValue("@Username", entity.Username);
                sqlCommand.Parameters.AddWithValue("@Role", entity.Role);
                sqlCommand.Parameters.AddWithValue("@Id", entity.Id);

                int rowsAffected = sqlCommand.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new UserNotFoundException("Update failed: User not found.");
                }
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }
    }
}
