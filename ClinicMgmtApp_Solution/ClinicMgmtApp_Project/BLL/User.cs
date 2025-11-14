using ClinicMgmtApp_Project.DAL;
using System;
using System.Collections.Generic;

namespace ClinicMgmtApp_Project.BLL
{
    internal class User
    {
        private int id;
        private string username;
        private RolesEnum role;

        public int Id 
        {
            get { return id; }
            set { id = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = Validator.ValidateUsername(value); }
        }

        public RolesEnum Role
        {
            get { return role; }
            set { role = value; }
        }

        public User()
        {
            Id = 0;
            Username = string.Empty;
            Role = RolesEnum.Receptionist;
        }

        public User(int id, string username, RolesEnum role)
        {
            Id = id;
            Username = username;
            Role = role;
        }

        public User(User other)
        {
            Id = other.Id;
            Username = other.Username;
            Role = other.Role;
        }

        public static string GenerateRandomPassword(int length = 12)
        {
            const string validChars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz23456789!@#$%^&*()-_=+";
            Random random = new Random();
            char[] passwordChars = new char[length];
            for (int i = 0; i < length; i++)
            {
                passwordChars[i] = validChars[random.Next(validChars.Length)];
            }

            string password = new string(passwordChars);

            try
            {
                Validator.ValidatePassword(password);
            }
            catch (ValidationException)
            {
                return GenerateRandomPassword(length);
            }

            return new string(passwordChars);
        }

        public static string RoleToString(RolesEnum role)
        {
            return role.ToString();
        }

        public static RolesEnum StringToRole(string roleString)
        {
            if (Enum.TryParse(roleString, out RolesEnum role))
            {
                return role;
            }
            else
            {
                throw new ValidationException("Invalid role string: " + roleString);
            }
        }

        public static List<User> GetAllUsers()
        {
            if (!UserStore.GetUser().CanPerformAction(minimumRole: RolesEnum.Receptionist))
            {
                throw new UnauthorizedException("Access denied: You must be at least a receptionist to retrieve all users.");
            }
            return UserDB.GetAllUsers();
        }

        public static void CreateUser(User newUser, string plainPassword)
        {
            if (!UserStore.GetUser().CanPerformAction(minimumRole: RolesEnum.Administrator))
            {
                throw new UnauthorizedException("Access denied: Only Admin users can register new users.");
            }
            UserDB.CreateUser(newUser, Validator.ValidatePassword(plainPassword));
        }

        public static void UpdateUser(User updatedUser, string plainPassword = null)
        {
            if (!UserStore.GetUser().CanPerformAction(minimumRole: RolesEnum.Administrator))
            {
                throw new UnauthorizedException("Access denied: Only Admin users can update other users.");
            }

            if (plainPassword == null)
            {
                UserDB.UpdateUser(updatedUser, null);
                return;
            }
            UserDB.UpdateUser(updatedUser, Validator.ValidatePassword(plainPassword));
        }

        public static void DeleteUser(int id)
        {
            if (!UserStore.GetUser().CanPerformAction(minimumRole: RolesEnum.Administrator))
            {
                throw new UnauthorizedException("Access denied: Only Admin users can delete other users.");
            }
            UserDB.DeleteUser(id);
        }

        public bool CanPerformAction(RolesEnum minimumRole)
        {
            return Role <= minimumRole;
        } 
    }
}
