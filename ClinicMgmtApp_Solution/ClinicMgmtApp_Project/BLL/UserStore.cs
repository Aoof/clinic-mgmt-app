using System;
using ClinicMgmtApp_Project.DAL;

namespace ClinicMgmtApp_Project.BLL
{
    internal class UserStore
    {
        private static User CurrentUser = null;

        public static User GetUser()
        {
            if (CurrentUser == null)
            {
                throw new UnauthorizedException("Failed to retrieve current user: User is not authenticated");
            }
            return CurrentUser;
        }

        public static void Login(string username, string password)
        {
            CurrentUser = UserDB.AuthenticateUser(username, password);
            if (CurrentUser == null)
            {
                throw new Exception("Login failed: Unexpected error during authentication.");
            }
        }

        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}
