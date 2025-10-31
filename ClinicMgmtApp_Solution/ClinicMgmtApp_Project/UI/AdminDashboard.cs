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

        public AdminDashboard()
        {
            InitializeComponent();
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
        }

        private void EnterEditMode()
        {
            isEditMode = true;
            btnCancel.Visible = true;
            btnDelete.Visible = true;
            txtPassword.Text = string.Empty;
            isPasswordChanged = false;
            btnSubmit.Text = "Update";
            grpAdminForm.Text = "Edit User";
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            ResetForm();
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
                int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["Id"].Value);
                var confirmResult = MessageBox.Show("Are you sure to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
