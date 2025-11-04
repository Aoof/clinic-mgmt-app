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

        private void AdjustButtonStyles(Button button)
        {
            button.Image = ResizeImage(button.Image, 30, 30);
            button.ImageAlign = ContentAlignment.MiddleLeft;
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.TextImageRelation = TextImageRelation.ImageBeforeText;
        }

        public AdminDashboard()
        {
            InitializeComponent();

            // Adjust button image sizes
            AdjustButtonStyles(btnDoctorManagement);
            AdjustButtonStyles(btnPatientRegistration);
            AdjustButtonStyles(btnReports);
            AdjustButtonStyles(btnUserManagement);

            ShowPanel(pnlUserManagement);
            SetActiveButton(btnUserManagement);
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            ResetUsrForm();
            ResetDoctorForm();
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
            ShowPanel(pnlDoctorManagement);
            SetActiveButton(btnDoctorManagement);
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
            pnlDoctorManagement.Visible = false;
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
            btnDoctorManagement.BackColor = SIDEBAR_BG;
            btnPatientRegistration.BackColor = SIDEBAR_BG;

            // Highlight the active button
            activeButton.BackColor = SIDEBAR_ACTIVE;
        }

    }
}
