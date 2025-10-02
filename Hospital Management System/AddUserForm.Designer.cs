namespace Hospital_Management_System
{
    partial class AddUserForm
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
            this.lbl_warning_phoneNum_uniqueness = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pnlDoctorFields = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.txtVisitFee = new Guna.UI2.WinForms.Guna2TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSpecialization = new Guna.UI2.WinForms.Guna2TextBox();
            this.picPhoto = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lbl_warning_eamil_uniqueness = new System.Windows.Forms.Label();
            this.btnChangePic = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btn_add_new_user = new Guna.UI2.WinForms.Guna2GradientButton();
            this.dtpDOB = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtFullName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRoles = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbGender = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btn_close = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btn_cancel_profilePic = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btn_clearAll_form = new Guna.UI2.WinForms.Guna2GradientButton();
            this.pnlDoctorFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_warning_phoneNum_uniqueness
            // 
            this.lbl_warning_phoneNum_uniqueness.AutoSize = true;
            this.lbl_warning_phoneNum_uniqueness.BackColor = System.Drawing.Color.Transparent;
            this.lbl_warning_phoneNum_uniqueness.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_warning_phoneNum_uniqueness.ForeColor = System.Drawing.Color.Red;
            this.lbl_warning_phoneNum_uniqueness.Location = new System.Drawing.Point(222, 303);
            this.lbl_warning_phoneNum_uniqueness.Name = "lbl_warning_phoneNum_uniqueness";
            this.lbl_warning_phoneNum_uniqueness.Size = new System.Drawing.Size(371, 16);
            this.lbl_warning_phoneNum_uniqueness.TabIndex = 87;
            this.lbl_warning_phoneNum_uniqueness.Text = "*Phone num is already in use. Please use a different one.";
            this.lbl_warning_phoneNum_uniqueness.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(850, 375);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(140, 28);
            this.label13.TabIndex = 84;
            this.label13.Text = "Pofile Picture";
            // 
            // pnlDoctorFields
            // 
            this.pnlDoctorFields.BackColor = System.Drawing.Color.Transparent;
            this.pnlDoctorFields.Controls.Add(this.label12);
            this.pnlDoctorFields.Controls.Add(this.txtVisitFee);
            this.pnlDoctorFields.Controls.Add(this.label11);
            this.pnlDoctorFields.Controls.Add(this.txtSpecialization);
            this.pnlDoctorFields.Location = new System.Drawing.Point(24, 469);
            this.pnlDoctorFields.Name = "pnlDoctorFields";
            this.pnlDoctorFields.Size = new System.Drawing.Size(609, 131);
            this.pnlDoctorFields.TabIndex = 83;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(154, 28);
            this.label12.TabIndex = 24;
            this.label12.Text = "Specialization :";
            // 
            // txtVisitFee
            // 
            this.txtVisitFee.Animated = true;
            this.txtVisitFee.AutoRoundedCorners = true;
            this.txtVisitFee.BorderColor = System.Drawing.Color.Black;
            this.txtVisitFee.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtVisitFee.DefaultText = "";
            this.txtVisitFee.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtVisitFee.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtVisitFee.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtVisitFee.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtVisitFee.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtVisitFee.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVisitFee.ForeColor = System.Drawing.Color.Black;
            this.txtVisitFee.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtVisitFee.Location = new System.Drawing.Point(184, 61);
            this.txtVisitFee.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtVisitFee.Name = "txtVisitFee";
            this.txtVisitFee.PlaceholderText = "";
            this.txtVisitFee.SelectedText = "";
            this.txtVisitFee.Size = new System.Drawing.Size(389, 35);
            this.txtVisitFee.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 28);
            this.label11.TabIndex = 25;
            this.label11.Text = "Visit Fee :";
            // 
            // txtSpecialization
            // 
            this.txtSpecialization.Animated = true;
            this.txtSpecialization.AutoRoundedCorners = true;
            this.txtSpecialization.BorderColor = System.Drawing.Color.Black;
            this.txtSpecialization.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSpecialization.DefaultText = "";
            this.txtSpecialization.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSpecialization.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSpecialization.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSpecialization.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSpecialization.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSpecialization.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpecialization.ForeColor = System.Drawing.Color.Black;
            this.txtSpecialization.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSpecialization.Location = new System.Drawing.Point(184, 14);
            this.txtSpecialization.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtSpecialization.Name = "txtSpecialization";
            this.txtSpecialization.PlaceholderText = "";
            this.txtSpecialization.SelectedText = "";
            this.txtSpecialization.Size = new System.Drawing.Size(391, 35);
            this.txtSpecialization.TabIndex = 26;
            // 
            // picPhoto
            // 
            this.picPhoto.BackColor = System.Drawing.Color.Transparent;
            this.picPhoto.BorderRadius = 50;
            this.picPhoto.ImageRotate = 0F;
            this.picPhoto.Location = new System.Drawing.Point(754, 47);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(325, 325);
            this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPhoto.TabIndex = 81;
            this.picPhoto.TabStop = false;
            this.picPhoto.UseTransparentBackground = true;
            // 
            // lbl_warning_eamil_uniqueness
            // 
            this.lbl_warning_eamil_uniqueness.AutoSize = true;
            this.lbl_warning_eamil_uniqueness.BackColor = System.Drawing.Color.Transparent;
            this.lbl_warning_eamil_uniqueness.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_warning_eamil_uniqueness.ForeColor = System.Drawing.Color.Red;
            this.lbl_warning_eamil_uniqueness.Location = new System.Drawing.Point(224, 226);
            this.lbl_warning_eamil_uniqueness.Name = "lbl_warning_eamil_uniqueness";
            this.lbl_warning_eamil_uniqueness.Size = new System.Drawing.Size(334, 16);
            this.lbl_warning_eamil_uniqueness.TabIndex = 86;
            this.lbl_warning_eamil_uniqueness.Text = "*Email is already in use. Please use a different one.";
            this.lbl_warning_eamil_uniqueness.Visible = false;
            // 
            // btnChangePic
            // 
            this.btnChangePic.Animated = true;
            this.btnChangePic.AutoRoundedCorners = true;
            this.btnChangePic.BackColor = System.Drawing.Color.Transparent;
            this.btnChangePic.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChangePic.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChangePic.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChangePic.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChangePic.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChangePic.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePic.ForeColor = System.Drawing.Color.Black;
            this.btnChangePic.IndicateFocus = true;
            this.btnChangePic.Location = new System.Drawing.Point(754, 406);
            this.btnChangePic.Name = "btnChangePic";
            this.btnChangePic.Size = new System.Drawing.Size(174, 28);
            this.btnChangePic.TabIndex = 82;
            this.btnChangePic.Text = "Change profile pic";
            this.btnChangePic.UseTransparentBackground = true;
            this.btnChangePic.Click += new System.EventHandler(this.btnChangePic_Click);
            // 
            // btn_add_new_user
            // 
            this.btn_add_new_user.Animated = true;
            this.btn_add_new_user.AutoRoundedCorners = true;
            this.btn_add_new_user.BackColor = System.Drawing.Color.Transparent;
            this.btn_add_new_user.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_add_new_user.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_add_new_user.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_add_new_user.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_add_new_user.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_add_new_user.FillColor = System.Drawing.Color.LightGreen;
            this.btn_add_new_user.FillColor2 = System.Drawing.Color.DarkGreen;
            this.btn_add_new_user.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.btn_add_new_user.ForeColor = System.Drawing.Color.Black;
            this.btn_add_new_user.IndicateFocus = true;
            this.btn_add_new_user.Location = new System.Drawing.Point(225, 661);
            this.btn_add_new_user.Name = "btn_add_new_user";
            this.btn_add_new_user.Size = new System.Drawing.Size(243, 59);
            this.btn_add_new_user.TabIndex = 79;
            this.btn_add_new_user.Text = "Save and Add";
            this.btn_add_new_user.UseTransparentBackground = true;
            this.btn_add_new_user.Click += new System.EventHandler(this.btn_add_new_user_Click);
            // 
            // dtpDOB
            // 
            this.dtpDOB.Animated = true;
            this.dtpDOB.AutoRoundedCorners = true;
            this.dtpDOB.BackColor = System.Drawing.Color.Transparent;
            this.dtpDOB.BorderThickness = 1;
            this.dtpDOB.Checked = true;
            this.dtpDOB.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.dtpDOB.FocusedColor = System.Drawing.Color.White;
            this.dtpDOB.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.dtpDOB.ForeColor = System.Drawing.Color.White;
            this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpDOB.IndicateFocus = true;
            this.dtpDOB.Location = new System.Drawing.Point(208, 428);
            this.dtpDOB.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDOB.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(391, 35);
            this.dtpDOB.TabIndex = 78;
            this.dtpDOB.UseTransparentBackground = true;
            this.dtpDOB.Value = new System.DateTime(2025, 9, 28, 18, 17, 8, 22);
            // 
            // txtFullName
            // 
            this.txtFullName.Animated = true;
            this.txtFullName.AutoRoundedCorners = true;
            this.txtFullName.BorderColor = System.Drawing.Color.Black;
            this.txtFullName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFullName.DefaultText = "";
            this.txtFullName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFullName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFullName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFullName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFullName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullName.ForeColor = System.Drawing.Color.Black;
            this.txtFullName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFullName.Location = new System.Drawing.Point(208, 138);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.PlaceholderText = "";
            this.txtFullName.SelectedText = "";
            this.txtFullName.Size = new System.Drawing.Size(391, 35);
            this.txtFullName.TabIndex = 75;
            // 
            // txtAddress
            // 
            this.txtAddress.Animated = true;
            this.txtAddress.AutoRoundedCorners = true;
            this.txtAddress.BorderColor = System.Drawing.Color.Black;
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.DefaultText = "";
            this.txtAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.ForeColor = System.Drawing.Color.Black;
            this.txtAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddress.Location = new System.Drawing.Point(208, 337);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PlaceholderText = "";
            this.txtAddress.SelectedText = "";
            this.txtAddress.Size = new System.Drawing.Size(391, 35);
            this.txtAddress.TabIndex = 73;
            // 
            // txtPhone
            // 
            this.txtPhone.Animated = true;
            this.txtPhone.AutoRoundedCorners = true;
            this.txtPhone.BorderColor = System.Drawing.Color.Black;
            this.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhone.DefaultText = "";
            this.txtPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.ForeColor = System.Drawing.Color.Black;
            this.txtPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhone.Location = new System.Drawing.Point(208, 262);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PlaceholderText = "";
            this.txtPhone.SelectedText = "";
            this.txtPhone.Size = new System.Drawing.Size(391, 35);
            this.txtPhone.TabIndex = 72;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Animated = true;
            this.txtEmail.AutoRoundedCorners = true;
            this.txtEmail.BorderColor = System.Drawing.Color.Black;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Location = new System.Drawing.Point(208, 185);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(391, 35);
            this.txtEmail.TabIndex = 71;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(34, 428);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 35);
            this.label10.TabIndex = 69;
            this.label10.Text = "DOB :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(32, 382);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 35);
            this.label9.TabIndex = 68;
            this.label9.Text = "Gender :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(35, 337);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 35);
            this.label8.TabIndex = 67;
            this.label8.Text = "Address :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(32, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 35);
            this.label7.TabIndex = 66;
            this.label7.Text = "Phone Num :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(34, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 35);
            this.label6.TabIndex = 65;
            this.label6.Text = "Email :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 35);
            this.label4.TabIndex = 63;
            this.label4.Text = "Full Name :";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.Location = new System.Drawing.Point(35, 90);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(81, 35);
            this.lblRole.TabIndex = 62;
            this.lblRole.Text = "Role :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(449, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 49);
            this.label1.TabIndex = 60;
            this.label1.Text = "Add new User";
            // 
            // cmbRoles
            // 
            this.cmbRoles.AutoRoundedCorners = true;
            this.cmbRoles.BackColor = System.Drawing.Color.Transparent;
            this.cmbRoles.BorderColor = System.Drawing.Color.Black;
            this.cmbRoles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoles.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbRoles.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbRoles.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbRoles.ForeColor = System.Drawing.Color.Black;
            this.cmbRoles.ItemHeight = 30;
            this.cmbRoles.Location = new System.Drawing.Point(208, 89);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(179, 36);
            this.cmbRoles.TabIndex = 88;
            this.cmbRoles.SelectedIndexChanged += new System.EventHandler(this.cmbRoles_SelectedIndexChanged);
            // 
            // cmbGender
            // 
            this.cmbGender.AutoRoundedCorners = true;
            this.cmbGender.BackColor = System.Drawing.Color.Transparent;
            this.cmbGender.BorderColor = System.Drawing.Color.Black;
            this.cmbGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbGender.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbGender.ItemHeight = 30;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Others"});
            this.cmbGender.Location = new System.Drawing.Point(208, 381);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(179, 36);
            this.cmbGender.TabIndex = 89;
            // 
            // btn_close
            // 
            this.btn_close.Animated = true;
            this.btn_close.AutoRoundedCorners = true;
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_close.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_close.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_close.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_close.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_close.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_close.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_close.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.btn_close.ForeColor = System.Drawing.Color.Black;
            this.btn_close.IndicateFocus = true;
            this.btn_close.Location = new System.Drawing.Point(-1, 0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(117, 41);
            this.btn_close.TabIndex = 90;
            this.btn_close.Text = "Close";
            this.btn_close.UseTransparentBackground = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_cancel_profilePic
            // 
            this.btn_cancel_profilePic.Animated = true;
            this.btn_cancel_profilePic.AutoRoundedCorners = true;
            this.btn_cancel_profilePic.BackColor = System.Drawing.Color.Transparent;
            this.btn_cancel_profilePic.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_cancel_profilePic.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_cancel_profilePic.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_cancel_profilePic.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_cancel_profilePic.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_cancel_profilePic.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_cancel_profilePic.FillColor2 = System.Drawing.Color.Navy;
            this.btn_cancel_profilePic.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btn_cancel_profilePic.ForeColor = System.Drawing.Color.White;
            this.btn_cancel_profilePic.IndicateFocus = true;
            this.btn_cancel_profilePic.Location = new System.Drawing.Point(985, 406);
            this.btn_cancel_profilePic.Name = "btn_cancel_profilePic";
            this.btn_cancel_profilePic.Size = new System.Drawing.Size(94, 28);
            this.btn_cancel_profilePic.TabIndex = 91;
            this.btn_cancel_profilePic.Text = "Cancel";
            this.btn_cancel_profilePic.UseTransparentBackground = true;
            this.btn_cancel_profilePic.Click += new System.EventHandler(this.btn_cancel_profilePic_Click);
            // 
            // btn_clearAll_form
            // 
            this.btn_clearAll_form.Animated = true;
            this.btn_clearAll_form.AutoRoundedCorners = true;
            this.btn_clearAll_form.BackColor = System.Drawing.Color.Transparent;
            this.btn_clearAll_form.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_clearAll_form.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_clearAll_form.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_clearAll_form.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_clearAll_form.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_clearAll_form.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_clearAll_form.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_clearAll_form.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.btn_clearAll_form.ForeColor = System.Drawing.Color.White;
            this.btn_clearAll_form.IndicateFocus = true;
            this.btn_clearAll_form.Location = new System.Drawing.Point(724, 661);
            this.btn_clearAll_form.Name = "btn_clearAll_form";
            this.btn_clearAll_form.Size = new System.Drawing.Size(182, 59);
            this.btn_clearAll_form.TabIndex = 93;
            this.btn_clearAll_form.Text = "Clear all";
            this.btn_clearAll_form.UseTransparentBackground = true;
            this.btn_clearAll_form.Click += new System.EventHandler(this.btn_clearAll_form_Click);
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1110, 732);
            this.Controls.Add(this.btn_clearAll_form);
            this.Controls.Add(this.btn_cancel_profilePic);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.cmbRoles);
            this.Controls.Add(this.lbl_warning_phoneNum_uniqueness);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.pnlDoctorFields);
            this.Controls.Add(this.picPhoto);
            this.Controls.Add(this.lbl_warning_eamil_uniqueness);
            this.Controls.Add(this.btnChangePic);
            this.Controls.Add(this.btn_add_new_user);
            this.Controls.Add(this.dtpDOB);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddUserForm";
            this.Load += new System.EventHandler(this.AddUserForm_Load);
            this.pnlDoctorFields.ResumeLayout(false);
            this.pnlDoctorFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_warning_phoneNum_uniqueness;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel pnlDoctorFields;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2TextBox txtVisitFee;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2TextBox txtSpecialization;
        private Guna.UI2.WinForms.Guna2PictureBox picPhoto;
        private System.Windows.Forms.Label lbl_warning_eamil_uniqueness;
        private Guna.UI2.WinForms.Guna2GradientButton btnChangePic;
        private Guna.UI2.WinForms.Guna2GradientButton btn_add_new_user;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDOB;
        private Guna.UI2.WinForms.Guna2TextBox txtFullName;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private Guna.UI2.WinForms.Guna2TextBox txtPhone;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbRoles;
        private Guna.UI2.WinForms.Guna2ComboBox cmbGender;
        private Guna.UI2.WinForms.Guna2GradientButton btn_close;
        private Guna.UI2.WinForms.Guna2GradientButton btn_cancel_profilePic;
        private Guna.UI2.WinForms.Guna2GradientButton btn_clearAll_form;
    }
}