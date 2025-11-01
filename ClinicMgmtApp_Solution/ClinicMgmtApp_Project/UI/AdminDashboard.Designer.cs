using System.Drawing;

namespace ClinicMgmtApp_Project.UI
{
    partial class AdminDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnPatientRegistration = new System.Windows.Forms.Button();
            this.btnDoctorScheduling = new System.Windows.Forms.Button();
            this.btnUserManagement = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.pnlSidebarHeader = new System.Windows.Forms.Panel();
            this.lblSidebarTitle = new System.Windows.Forms.Label();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.pnlPatientRegistration = new System.Windows.Forms.Panel();
            this.lblPatientRegistrationPlaceholder = new System.Windows.Forms.Label();
            this.pnlDoctorScheduling = new System.Windows.Forms.Panel();
            this.lblDoctorSchedulingPlaceholder = new System.Windows.Forms.Label();
            this.pnlReports = new System.Windows.Forms.Panel();
            this.lblReportsPlaceholder = new System.Windows.Forms.Label();
            this.pnlUserManagement = new System.Windows.Forms.Panel();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.grpAdminForm = new System.Windows.Forms.GroupBox();
            this.pnlPassword = new System.Windows.Forms.TableLayoutPanel();
            this.btnTogglePassword = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnGenPassword = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.comboRoles = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            this.pnlSidebarHeader.SuspendLayout();
            this.pnlMainContent.SuspendLayout();
            this.pnlPatientRegistration.SuspendLayout();
            this.pnlDoctorScheduling.SuspendLayout();
            this.pnlReports.SuspendLayout();
            this.pnlUserManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.grpAdminForm.SuspendLayout();
            this.pnlPassword.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblHeader.Font = new System.Drawing.Font("Lucida Sans", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Padding = new System.Windows.Forms.Padding(280, 0, 0, 0);
            this.lblHeader.Size = new System.Drawing.Size(1842, 90);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "Admin Dashboard";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlSidebar.Controls.Add(this.btnPatientRegistration);
            this.pnlSidebar.Controls.Add(this.btnDoctorScheduling);
            this.pnlSidebar.Controls.Add(this.btnUserManagement);
            this.pnlSidebar.Controls.Add(this.btnReports);
            this.pnlSidebar.Controls.Add(this.pnlSidebarHeader);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 90);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(316, 823);
            this.pnlSidebar.TabIndex = 2;
            // 
            // btnPatientRegistration
            // 
            this.btnPatientRegistration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnPatientRegistration.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPatientRegistration.FlatAppearance.BorderSize = 0;
            this.btnPatientRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatientRegistration.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPatientRegistration.ForeColor = System.Drawing.Color.White;
            this.btnPatientRegistration.Image = global::ClinicMgmtApp_Project.Properties.Resources.patient_icon;
            this.btnPatientRegistration.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPatientRegistration.Location = new System.Drawing.Point(0, 260);
            this.btnPatientRegistration.Name = "btnPatientRegistration";
            this.btnPatientRegistration.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnPatientRegistration.Size = new System.Drawing.Size(316, 70);
            this.btnPatientRegistration.TabIndex = 4;
            this.btnPatientRegistration.Text = "    Patient Registration";
            this.btnPatientRegistration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPatientRegistration.UseVisualStyleBackColor = false;
            this.btnPatientRegistration.Click += new System.EventHandler(this.btnPatientRegistration_Click);
            // 
            // btnDoctorScheduling
            // 
            this.btnDoctorScheduling.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnDoctorScheduling.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDoctorScheduling.FlatAppearance.BorderSize = 0;
            this.btnDoctorScheduling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoctorScheduling.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoctorScheduling.ForeColor = System.Drawing.Color.White;
            this.btnDoctorScheduling.Image = global::ClinicMgmtApp_Project.Properties.Resources.schedule_icon;
            this.btnDoctorScheduling.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoctorScheduling.Location = new System.Drawing.Point(0, 190);
            this.btnDoctorScheduling.Name = "btnDoctorScheduling";
            this.btnDoctorScheduling.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnDoctorScheduling.Size = new System.Drawing.Size(316, 70);
            this.btnDoctorScheduling.TabIndex = 3;
            this.btnDoctorScheduling.Text = "    Doctor Scheduling";
            this.btnDoctorScheduling.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoctorScheduling.UseVisualStyleBackColor = false;
            this.btnDoctorScheduling.Click += new System.EventHandler(this.btnDoctorScheduling_Click);
            // 
            // btnUserManagement
            // 
            this.btnUserManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnUserManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUserManagement.FlatAppearance.BorderSize = 0;
            this.btnUserManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserManagement.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserManagement.ForeColor = System.Drawing.Color.White;
            this.btnUserManagement.Image = global::ClinicMgmtApp_Project.Properties.Resources.users_icon;
            this.btnUserManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserManagement.Location = new System.Drawing.Point(0, 120);
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnUserManagement.Size = new System.Drawing.Size(316, 70);
            this.btnUserManagement.TabIndex = 2;
            this.btnUserManagement.Text = "    User Management";
            this.btnUserManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserManagement.UseVisualStyleBackColor = false;
            this.btnUserManagement.Click += new System.EventHandler(this.btnUserManagement_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Image = global::ClinicMgmtApp_Project.Properties.Resources.reports_icon;
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Location = new System.Drawing.Point(0, 50);
            this.btnReports.Name = "btnReports";
            this.btnReports.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnReports.Size = new System.Drawing.Size(316, 70);
            this.btnReports.TabIndex = 1;
            this.btnReports.Text = "    Reports";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // pnlSidebarHeader
            // 
            this.pnlSidebarHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlSidebarHeader.Controls.Add(this.lblSidebarTitle);
            this.pnlSidebarHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSidebarHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebarHeader.Name = "pnlSidebarHeader";
            this.pnlSidebarHeader.Size = new System.Drawing.Size(316, 50);
            this.pnlSidebarHeader.TabIndex = 0;
            // 
            // lblSidebarTitle
            // 
            this.lblSidebarTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSidebarTitle.Font = new System.Drawing.Font("Lucida Sans", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSidebarTitle.ForeColor = System.Drawing.Color.White;
            this.lblSidebarTitle.Location = new System.Drawing.Point(0, 0);
            this.lblSidebarTitle.Name = "lblSidebarTitle";
            this.lblSidebarTitle.Size = new System.Drawing.Size(316, 50);
            this.lblSidebarTitle.TabIndex = 0;
            this.lblSidebarTitle.Text = "NAVIGATION";
            this.lblSidebarTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlMainContent.Controls.Add(this.pnlUserManagement);
            this.pnlMainContent.Controls.Add(this.pnlReports);
            this.pnlMainContent.Controls.Add(this.pnlDoctorScheduling);
            this.pnlMainContent.Controls.Add(this.pnlPatientRegistration);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(316, 90);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMainContent.Size = new System.Drawing.Size(1526, 823);
            this.pnlMainContent.TabIndex = 3;
            // 
            // pnlPatientRegistration
            // 
            this.pnlPatientRegistration.Controls.Add(this.lblPatientRegistrationPlaceholder);
            this.pnlPatientRegistration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPatientRegistration.Location = new System.Drawing.Point(20, 20);
            this.pnlPatientRegistration.Name = "pnlPatientRegistration";
            this.pnlPatientRegistration.Size = new System.Drawing.Size(1486, 783);
            this.pnlPatientRegistration.TabIndex = 3;
            this.pnlPatientRegistration.Visible = false;
            // 
            // lblPatientRegistrationPlaceholder
            // 
            this.lblPatientRegistrationPlaceholder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPatientRegistrationPlaceholder.Font = new System.Drawing.Font("Lucida Sans", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientRegistrationPlaceholder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblPatientRegistrationPlaceholder.Location = new System.Drawing.Point(0, 0);
            this.lblPatientRegistrationPlaceholder.Name = "lblPatientRegistrationPlaceholder";
            this.lblPatientRegistrationPlaceholder.Size = new System.Drawing.Size(1486, 783);
            this.lblPatientRegistrationPlaceholder.TabIndex = 0;
            this.lblPatientRegistrationPlaceholder.Text = "Patient Registration Module - Coming Soon";
            this.lblPatientRegistrationPlaceholder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDoctorScheduling
            // 
            this.pnlDoctorScheduling.Controls.Add(this.lblDoctorSchedulingPlaceholder);
            this.pnlDoctorScheduling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDoctorScheduling.Location = new System.Drawing.Point(20, 20);
            this.pnlDoctorScheduling.Name = "pnlDoctorScheduling";
            this.pnlDoctorScheduling.Size = new System.Drawing.Size(1486, 783);
            this.pnlDoctorScheduling.TabIndex = 2;
            this.pnlDoctorScheduling.Visible = false;
            // 
            // lblDoctorSchedulingPlaceholder
            // 
            this.lblDoctorSchedulingPlaceholder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDoctorSchedulingPlaceholder.Font = new System.Drawing.Font("Lucida Sans", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoctorSchedulingPlaceholder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblDoctorSchedulingPlaceholder.Location = new System.Drawing.Point(0, 0);
            this.lblDoctorSchedulingPlaceholder.Name = "lblDoctorSchedulingPlaceholder";
            this.lblDoctorSchedulingPlaceholder.Size = new System.Drawing.Size(1486, 783);
            this.lblDoctorSchedulingPlaceholder.TabIndex = 0;
            this.lblDoctorSchedulingPlaceholder.Text = "Doctor Scheduling Module - Coming Soon";
            this.lblDoctorSchedulingPlaceholder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlReports
            // 
            this.pnlReports.Controls.Add(this.lblReportsPlaceholder);
            this.pnlReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReports.Location = new System.Drawing.Point(20, 20);
            this.pnlReports.Name = "pnlReports";
            this.pnlReports.Size = new System.Drawing.Size(1486, 783);
            this.pnlReports.TabIndex = 1;
            this.pnlReports.Visible = false;
            // 
            // lblReportsPlaceholder
            // 
            this.lblReportsPlaceholder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReportsPlaceholder.Font = new System.Drawing.Font("Lucida Sans", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportsPlaceholder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblReportsPlaceholder.Location = new System.Drawing.Point(0, 0);
            this.lblReportsPlaceholder.Name = "lblReportsPlaceholder";
            this.lblReportsPlaceholder.Size = new System.Drawing.Size(1486, 783);
            this.lblReportsPlaceholder.TabIndex = 0;
            this.lblReportsPlaceholder.Text = "Reports Module - Coming Soon";
            this.lblReportsPlaceholder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlUserManagement
            // 
            this.pnlUserManagement.Controls.Add(this.dgvUsers);
            this.pnlUserManagement.Controls.Add(this.grpAdminForm);
            this.pnlUserManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUserManagement.Location = new System.Drawing.Point(20, 20);
            this.pnlUserManagement.Name = "pnlUserManagement";
            this.pnlUserManagement.Size = new System.Drawing.Size(1486, 783);
            this.pnlUserManagement.TabIndex = 0;
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvUsers.Location = new System.Drawing.Point(644, 3);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvUsers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvUsers.RowTemplate.Height = 24;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(839, 777);
            this.dgvUsers.TabIndex = 4;
            this.dgvUsers.Click += new System.EventHandler(this.dgvUsers_Click);
            // 
            // grpAdminForm
            // 
            this.grpAdminForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpAdminForm.BackColor = System.Drawing.Color.White;
            this.grpAdminForm.Controls.Add(this.pnlPassword);
            this.grpAdminForm.Controls.Add(this.pnlButtons);
            this.grpAdminForm.Controls.Add(this.comboRoles);
            this.grpAdminForm.Controls.Add(this.label2);
            this.grpAdminForm.Controls.Add(this.lblPassword);
            this.grpAdminForm.Controls.Add(this.txtUsername);
            this.grpAdminForm.Controls.Add(this.lblUsername);
            this.grpAdminForm.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAdminForm.Location = new System.Drawing.Point(3, 3);
            this.grpAdminForm.Name = "grpAdminForm";
            this.grpAdminForm.Padding = new System.Windows.Forms.Padding(25);
            this.grpAdminForm.Size = new System.Drawing.Size(635, 777);
            this.grpAdminForm.TabIndex = 5;
            this.grpAdminForm.TabStop = false;
            this.grpAdminForm.Text = "Create User";
            // 
            // pnlPassword
            // 
            this.pnlPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPassword.ColumnCount = 2;
            this.pnlPassword.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.01681F));
            this.pnlPassword.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.98319F));
            this.pnlPassword.Controls.Add(this.btnTogglePassword, 1, 0);
            this.pnlPassword.Controls.Add(this.txtPassword, 0, 0);
            this.pnlPassword.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.pnlPassword.Location = new System.Drawing.Point(22, 189);
            this.pnlPassword.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.RowCount = 1;
            this.pnlPassword.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlPassword.Size = new System.Drawing.Size(588, 37);
            this.pnlPassword.TabIndex = 11;
            // 
            // btnTogglePassword
            // 
            this.btnTogglePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTogglePassword.AutoSize = true;
            this.btnTogglePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnTogglePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTogglePassword.Font = new System.Drawing.Font("Lucida Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTogglePassword.ForeColor = System.Drawing.Color.White;
            this.btnTogglePassword.Location = new System.Drawing.Point(485, 3);
            this.btnTogglePassword.Name = "btnTogglePassword";
            this.btnTogglePassword.Size = new System.Drawing.Size(100, 31);
            this.btnTogglePassword.TabIndex = 8;
            this.btnTogglePassword.Text = "Show";
            this.btnTogglePassword.UseVisualStyleBackColor = false;
            this.btnTogglePassword.Click += new System.EventHandler(this.btnTogglePassword_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(5, 3);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(5, 3, 3, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(474, 31);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlButtons.ColumnCount = 4;
            this.pnlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.pnlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlButtons.Controls.Add(this.btnSubmit, 3, 0);
            this.pnlButtons.Controls.Add(this.btnGenPassword, 0, 0);
            this.pnlButtons.Controls.Add(this.btnDelete, 2, 0);
            this.pnlButtons.Controls.Add(this.btnCancel, 1, 0);
            this.pnlButtons.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.pnlButtons.Location = new System.Drawing.Point(25, 374);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.RowCount = 1;
            this.pnlButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlButtons.Size = new System.Drawing.Size(585, 56);
            this.pnlButtons.TabIndex = 10;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.AutoSize = true;
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Lucida Sans", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(471, 3);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(111, 50);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Create";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnGenPassword
            // 
            this.btnGenPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenPassword.AutoSize = true;
            this.btnGenPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnGenPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenPassword.Font = new System.Drawing.Font("Lucida Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenPassword.ForeColor = System.Drawing.Color.White;
            this.btnGenPassword.Location = new System.Drawing.Point(3, 3);
            this.btnGenPassword.Name = "btnGenPassword";
            this.btnGenPassword.Size = new System.Drawing.Size(228, 50);
            this.btnGenPassword.TabIndex = 6;
            this.btnGenPassword.Text = "Generate Password";
            this.btnGenPassword.UseVisualStyleBackColor = false;
            this.btnGenPassword.Click += new System.EventHandler(this.btnGenPassword_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.AutoSize = true;
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Lucida Sans", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(354, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(111, 50);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Lucida Sans", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(237, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 50);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // comboRoles
            // 
            this.comboRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboRoles.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboRoles.FormattingEnabled = true;
            this.comboRoles.Location = new System.Drawing.Point(25, 292);
            this.comboRoles.Name = "comboRoles";
            this.comboRoles.Size = new System.Drawing.Size(585, 31);
            this.comboRoles.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(585, 35);
            this.label2.TabIndex = 8;
            this.label2.Text = "Role";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPassword.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(25, 148);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(585, 35);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Password";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(25, 102);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(5, 3, 3, 5);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(585, 31);
            this.txtUsername.TabIndex = 5;
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsername.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(25, 60);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(585, 35);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "Username";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1842, 913);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Lucida Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard";
            this.Load += new System.EventHandler(this.AdminDashboard_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebarHeader.ResumeLayout(false);
            this.pnlMainContent.ResumeLayout(false);
            this.pnlPatientRegistration.ResumeLayout(false);
            this.pnlDoctorScheduling.ResumeLayout(false);
            this.pnlReports.ResumeLayout(false);
            this.pnlUserManagement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.grpAdminForm.ResumeLayout(false);
            this.grpAdminForm.PerformLayout();
            this.pnlPassword.ResumeLayout(false);
            this.pnlPassword.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnUserManagement;
        private System.Windows.Forms.Button btnDoctorScheduling;
        private System.Windows.Forms.Button btnPatientRegistration;
        private System.Windows.Forms.Panel pnlSidebarHeader;
        private System.Windows.Forms.Label lblSidebarTitle;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Panel pnlUserManagement;
        private System.Windows.Forms.Panel pnlReports;
        private System.Windows.Forms.Panel pnlDoctorScheduling;
        private System.Windows.Forms.Panel pnlPatientRegistration;
        private System.Windows.Forms.Label lblReportsPlaceholder;
        private System.Windows.Forms.Label lblDoctorSchedulingPlaceholder;
        private System.Windows.Forms.Label lblPatientRegistrationPlaceholder;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.GroupBox grpAdminForm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.ComboBox comboRoles;
        private System.Windows.Forms.TableLayoutPanel pnlButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnGenPassword;
        private System.Windows.Forms.TableLayoutPanel pnlPassword;
        private System.Windows.Forms.Button btnTogglePassword;
        private System.Windows.Forms.Button btnDelete;
    }
}
