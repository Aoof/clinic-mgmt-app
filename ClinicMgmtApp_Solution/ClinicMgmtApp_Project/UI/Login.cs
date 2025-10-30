using ClinicMgmtApp_Project.BLL;
using ClinicMgmtApp_Project.DAL;
using System;
using System.Windows.Forms;

namespace ClinicMgmtApp_Project.UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            try
            {
                UserStore.Login(username, password);
                Form dashboard = null;
                switch (UserStore.GetUser().Role)
                {
                    case "Adminstrator":
                        dashboard = new AdminDashboard();
                        break;
                    case "Doctor":
                        dashboard = new DoctorDashboard();
                        break;
                    case "Receptionist":
                        dashboard = new ReceptionistDashboard();
                        break;
                    default:
                        MessageBox.Show("Login successful! Welcome, User.");
                        break;
                }
                this.Hide();
                dashboard.ShowDialog();
                Close();
            }
            catch (Exception ex)
            {
                if (ex is UserNotFoundException || ex is InvalidCredentialsException)
                {
                    MessageBox.Show(ex.Message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MessageBox.Show("Unexpected error happened! Contact adminstration for more info.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnLogin.PerformClick(); }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnLogin.PerformClick(); }
        }
    }
}
