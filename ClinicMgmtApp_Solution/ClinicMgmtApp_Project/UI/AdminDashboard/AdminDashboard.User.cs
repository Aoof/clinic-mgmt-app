using ClinicMgmtApp_Project.BLL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicMgmtApp_Project.UI
{
    public partial class AdminDashboard
    {
        private void ResetUsrForm()
        {
            txtUsrUsername.Text = string.Empty;
            txtUsrPassword.Text = string.Empty;
            comboRoles.DataSource = Enum.GetValues(typeof(RolesEnum));
            comboRoles.SelectedIndex = -1;
            isEditMode = false;
            isPasswordChanged = false;
            btnUsrCancel.Visible = false;
            btnUsrDelete.Visible = false;
            try
            {
                dgvUsers.DataSource = User.GetAllUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvUsers.ClearSelection();
            btnUsrSubmit.Text = "Create";
            grpAdminForm.Text = "Create User";
            txtUsrPassword.UseSystemPasswordChar = true;
            btnTogglePassword.Text = "Show";
            txtUsrPassword.BackColor = SystemColors.Window;

        }

        private void EnterUsrEditMode()
        {
            isEditMode = true;
            btnUsrCancel.Visible = true;
            btnUsrDelete.Visible = true;
            txtUsrPassword.Text = string.Empty;
            txtUsrPassword.BackColor = SystemColors.ControlDark;
            isPasswordChanged = false;
            btnUsrSubmit.Text = "Update";
            grpAdminForm.Text = "Edit User";
        }

        private void txtUsrPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtUsrPassword.Text.Length == 0)
            {
                txtUsrPassword.BackColor = SystemColors.ControlDark;
            }
            else
            {
                txtUsrPassword.BackColor = SystemColors.Window;
                if (!isPasswordChanged)
                    isPasswordChanged = true;
            }
        }

        private void dgvUsers_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                txtUsrUsername.Text = dgvUsers.CurrentRow.Cells["Username"].Value.ToString();
                comboRoles.SelectedItem = User.StringToRole(dgvUsers.CurrentRow.Cells["Role"].Value.ToString());
                EnterUsrEditMode();
            }
        }

        private void btnUsrCancel_Click(object sender, EventArgs e)
        {
            ResetUsrForm();
        }

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            txtUsrPassword.UseSystemPasswordChar = !txtUsrPassword.UseSystemPasswordChar;
            if (txtUsrPassword.UseSystemPasswordChar)
            {
                btnTogglePassword.Text = "Show";
            }
            else
            {
                btnTogglePassword.Text = "Hide";
            }
        }

        private void btnUsrSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsrUsername.Text.Trim();
                string str_role = comboRoles.SelectedItem?.ToString() ?? string.Empty;
                RolesEnum role = User.StringToRole(str_role);
                string password = isPasswordChanged ? txtUsrPassword.Text : null;
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
                ResetUsrForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUsrDelete_Click(object sender, EventArgs e)
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
                    ResetUsrForm();
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
            txtUsrPassword.Text = generatedPassword;
        }

    }
}
