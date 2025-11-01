using ClinicMgmtApp_Project.BLL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicMgmtApp_Project.UI
{
    public partial class AdminDashboard : Form
    {
        private static bool isEditMode = false;
        private static bool isPasswordChanged = false;

        private readonly Color SIDEBAR_BG = Color.FromArgb(44, 62, 80);
        private readonly Color SIDEBAR_ACTIVE = Color.FromArgb(52, 73, 94);
        private readonly Color HEADER_BG = Color.FromArgb(41, 128, 185);
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

        public AdminDashboard()
        {
            InitializeComponent();

            // Adjust button image sizes
            btnDoctorScheduling.Image = ResizeImage(btnDoctorScheduling.Image, 30, 30);
            btnDoctorScheduling.ImageAlign = ContentAlignment.MiddleLeft;
            btnDoctorScheduling.TextAlign = ContentAlignment.MiddleLeft;
            btnDoctorScheduling.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnPatientRegistration.Image = ResizeImage(btnPatientRegistration.Image, 30, 30);
            btnPatientRegistration.ImageAlign = ContentAlignment.MiddleLeft;
            btnPatientRegistration.TextAlign = ContentAlignment.MiddleLeft;
            btnPatientRegistration.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnUserManagement.Image = ResizeImage(btnUserManagement.Image, 30, 30);
            btnUserManagement.ImageAlign = ContentAlignment.MiddleLeft;
            btnUserManagement.TextAlign = ContentAlignment.MiddleLeft;
            btnUserManagement.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnReports.Image = ResizeImage(btnReports.Image, 30, 30);
            btnReports.ImageAlign = ContentAlignment.MiddleLeft;
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.TextImageRelation = TextImageRelation.ImageBeforeText;

            ShowPanel(pnlUserManagement);
            SetActiveButton(btnUserManagement);
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            ResetForm();
        }

        // Navigation Methods
        private void btnReports_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlReports);
            SetActiveButton(btnReports);
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlUserManagement);
            SetActiveButton(btnUserManagement);
        }

        private void btnDoctorScheduling_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlDoctorScheduling);
            SetActiveButton(btnDoctorScheduling);
        }

        private void btnPatientRegistration_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlPatientRegistration);
            SetActiveButton(btnPatientRegistration);
        }

        // Helper method to show selected panel and hide others
        private void ShowPanel(Panel panelToShow)
        {
            pnlReports.Visible = false;
            pnlUserManagement.Visible = false;
            pnlDoctorScheduling.Visible = false;
            pnlPatientRegistration.Visible = false;

            panelToShow.Visible = true;
            panelToShow.BringToFront();
        }

        // Helper method to highlight active button
        private void SetActiveButton(Button activeButton)
        {
            // Reset all buttons to default color
            btnReports.BackColor = SIDEBAR_BG;
            btnUserManagement.BackColor = SIDEBAR_BG;
            btnDoctorScheduling.BackColor = SIDEBAR_BG;
            btnPatientRegistration.BackColor = SIDEBAR_BG;

            // Highlight the active button
            activeButton.BackColor = SIDEBAR_ACTIVE;
        }

        private void ResetForm()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            comboRoles.DataSource = Enum.GetValues(typeof(RolesEnum));
            comboRoles.SelectedIndex = -1;
            isEditMode = false;
            isPasswordChanged = false;
            btnCancel.Visible = false;
            btnDelete.Visible = false;
            try
            {
                dgvUsers.DataSource = User.GetAllUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvUsers.ClearSelection();
            btnSubmit.Text = "Create";
            grpAdminForm.Text = "Create User";
            txtPassword.UseSystemPasswordChar = true;
            btnTogglePassword.Text = "Show";
            txtPassword.BackColor = SystemColors.Window;
        }

        private void EnterEditMode()
        {
            isEditMode = true;
            btnCancel.Visible = true;
            btnDelete.Visible = true;
            txtPassword.Text = string.Empty;
            txtPassword.BackColor = SystemColors.ControlDark;
            isPasswordChanged = false;
            btnSubmit.Text = "Update";
            grpAdminForm.Text = "Edit User";
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length == 0)
            {
                txtPassword.BackColor = SystemColors.ControlDark;
            }
            else
            {
                txtPassword.BackColor = SystemColors.Window;
                if (!isPasswordChanged)
                    isPasswordChanged = true;
            }
        }

        private void dgvUsers_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                txtUsername.Text = dgvUsers.CurrentRow.Cells["Username"].Value.ToString();
                comboRoles.SelectedItem = User.StringToRole(dgvUsers.CurrentRow.Cells["Role"].Value.ToString());
                EnterEditMode();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            if (txtPassword.UseSystemPasswordChar)
            {
                btnTogglePassword.Text = "Show";
            }
            else
            {
                btnTogglePassword.Text = "Hide";
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string str_role = comboRoles.SelectedItem?.ToString() ?? string.Empty;
                RolesEnum role = User.StringToRole(str_role);
                string password = isPasswordChanged ? txtPassword.Text : null;
                if (isEditMode)
                {
                    int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["Id"].Value);
                    User updatedUser = new User(userId, username, role);
                    User.UpdateUser(updatedUser, password);
                    MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    User newUser = new User(0, username, role);
                    User.CreateUser(newUser, password);
                    MessageBox.Show("User created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dgvUsers.DataSource = User.GetAllUsers();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string username = dgvUsers.CurrentRow.Cells["Username"].Value.ToString();
                int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["Id"].Value);
                var confirmResult = MessageBox.Show("You're about to delete `" + username + "` Are you sure to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    User.DeleteUser(userId);
                    MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvUsers.DataSource = User.GetAllUsers();
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting user: " + ex.Message, "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenPassword_Click(object sender, EventArgs e)
        {
            string generatedPassword = User.GenerateRandomPassword(12);
            txtPassword.Text = generatedPassword;
        }
    }
}
