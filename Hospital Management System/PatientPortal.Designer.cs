namespace Hospital_Management_System
{
    partial class PatientPortal
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
            this.components = new System.ComponentModel.Container();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.pnlSideMenu = new Guna.UI2.WinForms.Guna2Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblAppName = new System.Windows.Forms.Label();
            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.cardRecords = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cardAppointments = new Guna.UI2.WinForms.Guna2Panel();
            this.lblAppointmentCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.btnProfile = new Guna.UI2.WinForms.Guna2Button();
            this.btnDashboard = new Guna.UI2.WinForms.Guna2Button();
            this.btnMyPrescriptions = new Guna.UI2.WinForms.Guna2Button();
            this.btnAppointment = new Guna.UI2.WinForms.Guna2Button();
            this.pbProfilePic = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pnlSideMenu.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.cardRecords.SuspendLayout();
            this.cardAppointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.BorderRadius = 20;
            this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(43)))), ((int)(((byte)(132)))), ((int)(((byte)(234)))));
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // pnlSideMenu
            // 
            this.pnlSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.pnlSideMenu.Controls.Add(this.btnLogout);
            this.pnlSideMenu.Controls.Add(this.btnProfile);
            this.pnlSideMenu.Controls.Add(this.btnDashboard);
            this.pnlSideMenu.Controls.Add(this.btnMyPrescriptions);
            this.pnlSideMenu.Controls.Add(this.btnAppointment);
            this.pnlSideMenu.Controls.Add(this.lblWelcome);
            this.pnlSideMenu.Controls.Add(this.pbProfilePic);
            this.pnlSideMenu.Controls.Add(this.lblAppName);
            this.pnlSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlSideMenu.Name = "pnlSideMenu";
            this.pnlSideMenu.Size = new System.Drawing.Size(290, 700);
            this.pnlSideMenu.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(3, 177);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(284, 28);
            this.lblWelcome.TabIndex = 2;
            this.lblWelcome.Text = "Welcome, Ayan";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.Location = new System.Drawing.Point(62, 23);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(170, 32);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "Patient Portal";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.cardRecords);
            this.pnlMain.Controls.Add(this.cardAppointments);
            this.pnlMain.Controls.Add(this.lblDashboard);
            this.pnlMain.Controls.Add(this.guna2ControlBox3);
            this.pnlMain.Controls.Add(this.guna2ControlBox2);
            this.pnlMain.Controls.Add(this.guna2ControlBox1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(290, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(810, 700);
            this.pnlMain.TabIndex = 1;
            // 
            // cardRecords
            // 
            this.cardRecords.BackColor = System.Drawing.Color.Transparent;
            this.cardRecords.BorderRadius = 15;
            this.cardRecords.Controls.Add(this.lblRecordCount);
            this.cardRecords.Controls.Add(this.label6);
            this.cardRecords.Controls.Add(this.guna2PictureBox3);
            this.cardRecords.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(209)))), ((int)(((byte)(55)))));
            this.cardRecords.Location = new System.Drawing.Point(296, 126);
            this.cardRecords.Name = "cardRecords";
            this.cardRecords.ShadowDecoration.BorderRadius = 20;
            this.cardRecords.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(209)))), ((int)(((byte)(55)))));
            this.cardRecords.ShadowDecoration.Enabled = true;
            this.cardRecords.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 5, 8, 8);
            this.cardRecords.Size = new System.Drawing.Size(225, 125);
            this.cardRecords.TabIndex = 6;
            this.cardRecords.Click += new System.EventHandler(this.cardRecords_Click);
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblRecordCount.ForeColor = System.Drawing.Color.White;
            this.lblRecordCount.Location = new System.Drawing.Point(18, 59);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(39, 37);
            this.lblRecordCount.TabIndex = 2;
            this.lblRecordCount.Text = "--";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(21, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 23);
            this.label6.TabIndex = 1;
            this.label6.Text = "Medical Records";
            // 
            // cardAppointments
            // 
            this.cardAppointments.BackColor = System.Drawing.Color.Transparent;
            this.cardAppointments.BorderRadius = 15;
            this.cardAppointments.Controls.Add(this.lblAppointmentCount);
            this.cardAppointments.Controls.Add(this.label2);
            this.cardAppointments.Controls.Add(this.guna2PictureBox1);
            this.cardAppointments.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(225)))));
            this.cardAppointments.Location = new System.Drawing.Point(34, 126);
            this.cardAppointments.Name = "cardAppointments";
            this.cardAppointments.ShadowDecoration.BorderRadius = 20;
            this.cardAppointments.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(225)))));
            this.cardAppointments.ShadowDecoration.Enabled = true;
            this.cardAppointments.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 5, 8, 8);
            this.cardAppointments.Size = new System.Drawing.Size(225, 125);
            this.cardAppointments.TabIndex = 4;
            // 
            // lblAppointmentCount
            // 
            this.lblAppointmentCount.AutoSize = true;
            this.lblAppointmentCount.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblAppointmentCount.ForeColor = System.Drawing.Color.White;
            this.lblAppointmentCount.Location = new System.Drawing.Point(18, 59);
            this.lblAppointmentCount.Name = "lblAppointmentCount";
            this.lblAppointmentCount.Size = new System.Drawing.Size(39, 37);
            this.lblAppointmentCount.TabIndex = 2;
            this.lblAppointmentCount.Text = "--";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(21, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pending Appointments";
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.lblDashboard.Location = new System.Drawing.Point(26, 47);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(193, 46);
            this.lblDashboard.TabIndex = 3;
            this.lblDashboard.Text = "Dashboard";
            // 
            // guna2ControlBox3
            // 
            this.guna2ControlBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox3.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox3.IconColor = System.Drawing.Color.Gray;
            this.guna2ControlBox3.Location = new System.Drawing.Point(661, 12);
            this.guna2ControlBox3.Name = "guna2ControlBox3";
            this.guna2ControlBox3.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox3.TabIndex = 2;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.Gray;
            this.guna2ControlBox2.Location = new System.Drawing.Point(706, 12);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox2.TabIndex = 1;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.guna2ControlBox1.HoverState.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Gray;
            this.guna2ControlBox1.Location = new System.Drawing.Point(751, 12);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 0;
            // 
            // guna2PictureBox3
            // 
            this.guna2PictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox3.Image = global::Hospital_Management_System.Properties.Resources.health_report;
            this.guna2PictureBox3.ImageRotate = 0F;
            this.guna2PictureBox3.Location = new System.Drawing.Point(145, 47);
            this.guna2PictureBox3.Name = "guna2PictureBox3";
            this.guna2PictureBox3.Size = new System.Drawing.Size(64, 64);
            this.guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox3.TabIndex = 0;
            this.guna2PictureBox3.TabStop = false;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = global::Hospital_Management_System.Properties.Resources.Pending;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(145, 47);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(64, 64);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.Animated = true;
            this.btnLogout.BorderRadius = 10;
            this.btnLogout.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnLogout.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(225)))));
            this.btnLogout.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnLogout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.btnLogout.Image = global::Hospital_Management_System.Properties.Resources.logout;
            this.btnLogout.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogout.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnLogout.ImageSize = new System.Drawing.Size(30, 30);
            this.btnLogout.Location = new System.Drawing.Point(12, 630);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(265, 45);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogout.TextOffset = new System.Drawing.Point(30, 0);
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.Animated = true;
            this.btnProfile.BorderRadius = 10;
            this.btnProfile.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnProfile.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(225)))));
            this.btnProfile.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnProfile.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnProfile.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnProfile.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnProfile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnProfile.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.btnProfile.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnProfile.ForeColor = System.Drawing.Color.White;
            this.btnProfile.Image = global::Hospital_Management_System.Properties.Resources.user;
            this.btnProfile.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnProfile.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnProfile.ImageSize = new System.Drawing.Size(30, 30);
            this.btnProfile.Location = new System.Drawing.Point(12, 422);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(268, 45);
            this.btnProfile.TabIndex = 10;
            this.btnProfile.Text = "Profile";
            this.btnProfile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnProfile.TextOffset = new System.Drawing.Point(30, 0);
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Animated = true;
            this.btnDashboard.BorderRadius = 10;
            this.btnDashboard.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnDashboard.Checked = true;
            this.btnDashboard.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(225)))));
            this.btnDashboard.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDashboard.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDashboard.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDashboard.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDashboard.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Image = global::Hospital_Management_System.Properties.Resources.dashboard;
            this.btnDashboard.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDashboard.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnDashboard.ImageSize = new System.Drawing.Size(25, 25);
            this.btnDashboard.Location = new System.Drawing.Point(14, 267);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(268, 45);
            this.btnDashboard.TabIndex = 9;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDashboard.TextOffset = new System.Drawing.Point(30, 0);
            // 
            // btnMyPrescriptions
            // 
            this.btnMyPrescriptions.Animated = true;
            this.btnMyPrescriptions.BorderRadius = 10;
            this.btnMyPrescriptions.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnMyPrescriptions.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(225)))));
            this.btnMyPrescriptions.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnMyPrescriptions.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.btnMyPrescriptions.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnMyPrescriptions.ForeColor = System.Drawing.Color.White;
            this.btnMyPrescriptions.Image = global::Hospital_Management_System.Properties.Resources.file;
            this.btnMyPrescriptions.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMyPrescriptions.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnMyPrescriptions.ImageSize = new System.Drawing.Size(30, 30);
            this.btnMyPrescriptions.Location = new System.Drawing.Point(12, 366);
            this.btnMyPrescriptions.Name = "btnMyPrescriptions";
            this.btnMyPrescriptions.Size = new System.Drawing.Size(268, 45);
            this.btnMyPrescriptions.TabIndex = 6;
            this.btnMyPrescriptions.Text = "My Prescriptions";
            this.btnMyPrescriptions.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMyPrescriptions.TextOffset = new System.Drawing.Point(30, 0);
            this.btnMyPrescriptions.Click += new System.EventHandler(this.btnMyPrescriptions_Click);
            // 
            // btnAppointment
            // 
            this.btnAppointment.Animated = true;
            this.btnAppointment.BorderRadius = 10;
            this.btnAppointment.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnAppointment.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(225)))));
            this.btnAppointment.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnAppointment.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.btnAppointment.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAppointment.ForeColor = System.Drawing.Color.White;
            this.btnAppointment.Image = global::Hospital_Management_System.Properties.Resources.schedule;
            this.btnAppointment.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAppointment.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnAppointment.ImageSize = new System.Drawing.Size(30, 30);
            this.btnAppointment.Location = new System.Drawing.Point(10, 310);
            this.btnAppointment.Name = "btnAppointment";
            this.btnAppointment.Size = new System.Drawing.Size(268, 45);
            this.btnAppointment.TabIndex = 5;
            this.btnAppointment.Text = "Make Appointment";
            this.btnAppointment.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAppointment.TextOffset = new System.Drawing.Point(30, 0);
            this.btnAppointment.Click += new System.EventHandler(this.btnAppointment_Click);
            // 
            // pbProfilePic
            // 
            this.pbProfilePic.Image = global::Hospital_Management_System.Properties.Resources.blank_profile_picture_973460_1920;
            this.pbProfilePic.ImageRotate = 0F;
            this.pbProfilePic.Location = new System.Drawing.Point(95, 79);
            this.pbProfilePic.Name = "pbProfilePic";
            this.pbProfilePic.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbProfilePic.Size = new System.Drawing.Size(100, 100);
            this.pbProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProfilePic.TabIndex = 1;
            this.pbProfilePic.TabStop = false;
            // 
            // PatientPortal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSideMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PatientPortal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PatientPortal";
            this.Load += new System.EventHandler(this.PatientPortal_Load);
            this.pnlSideMenu.ResumeLayout(false);
            this.pnlSideMenu.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.cardRecords.ResumeLayout(false);
            this.cardRecords.PerformLayout();
            this.cardAppointments.ResumeLayout(false);
            this.cardAppointments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2Panel pnlSideMenu;
        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbProfilePic;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblWelcome;
        private Guna.UI2.WinForms.Guna2Button btnMyPrescriptions;
        private Guna.UI2.WinForms.Guna2Button btnAppointment;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox3;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private System.Windows.Forms.Label lblDashboard;
        private Guna.UI2.WinForms.Guna2Panel cardAppointments;
        private System.Windows.Forms.Label lblAppointmentCount;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Panel cardRecords;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox3;
        private Guna.UI2.WinForms.Guna2Button btnDashboard;
        private Guna.UI2.WinForms.Guna2Button btnProfile;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
    }
}