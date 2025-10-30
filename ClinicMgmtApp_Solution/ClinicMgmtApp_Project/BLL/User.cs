namespace ClinicMgmtApp_Project.BLL
{
    internal class User
    {
        private string username;
        private string password;
        private string role;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        public User()
        {
            Username = string.Empty;
            Password = string.Empty;
            Role = string.Empty;
        }

        public User(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        public User(User other)
        {
            Username = other.Username;
            Password = other.Password;
            Role = other.Role;
        }
    }
}
