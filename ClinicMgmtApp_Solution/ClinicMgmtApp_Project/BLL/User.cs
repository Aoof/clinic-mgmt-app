namespace ClinicMgmtApp_Project.BLL
{
    internal class User
    {
        private int id;
        private string username;
        private string role;

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

        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        public User()
        {
            Id = 0;
            Username = string.Empty;
            Role = string.Empty;
        }

        public User(int id, string username, string role)
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
    }
}
