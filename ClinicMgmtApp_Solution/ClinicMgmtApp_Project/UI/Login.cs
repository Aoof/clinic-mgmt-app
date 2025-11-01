using ClinicMgmtApp_Project.BLL;
using ClinicMgmtApp_Project.DAL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicMgmtApp_Project.UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private Image ResizeImage(Image img, int width, int height)
        {
            Bitmap resized = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resized))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, width, height);
            }
            return resized;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Text = Properties.Settings.Default.Username;
            txtPassword.Text = Properties.Settings.Default.Password;

            if (!string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                checkRememberPassword.Checked = true;
            }
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
                    case RolesEnum.Administrator:
                        dashboard = new AdminDashboard();
                        break;
                    case RolesEnum.Doctor:
                        dashboard = new DoctorDashboard();
                        break;
                    case RolesEnum.Receptionist:
                        dashboard = new ReceptionistDashboard();
                        break;
                    default:
                        MessageBox.Show("Login successful! Welcome, User.");
                        break;
                }

                if (checkRememberPassword.Checked)
                {
                    Properties.Settings.Default.Username = username;
                    Properties.Settings.Default.Password = password;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.Username = "";
                    Properties.Settings.Default.Password = "";
                    Properties.Settings.Default.Save();
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
