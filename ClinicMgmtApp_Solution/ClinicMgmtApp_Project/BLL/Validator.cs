using System;
using System.Text.RegularExpressions;

namespace ClinicMgmtApp_Project.BLL
{
    internal class Validator
    {
        public static string ValidateUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ValidationException("Username cannot be empty.");
            }
            if (username.Length < 4 || username.Length > 20)
            {
                throw new ValidationException("Username must be between 4 and 20 characters long.");
            }
            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$"))
            {
                throw new ValidationException("Username can only contain alphanumeric characters and underscores.");
            }
            return username;
        }

        public static string ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ValidationException("Password cannot be empty.");
            }

            if (password.Length < 8)
            {
                throw new ValidationException("Password must be at least 8 characters long.");
            }

            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                throw new ValidationException("Password must contain at least one uppercase letter.");
            }

            if (!Regex.IsMatch(password, @"[a-z]"))
            {
                throw new ValidationException("Password must contain at least one lowercase letter.");
            }

            if (!Regex.IsMatch(password, @"[0-9]"))
            {
                throw new ValidationException("Password must contain at least one digit.");
            }

            return password;
        }
    }
}
