namespace Hospital_Management_System
{
    partial class UserProfileForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPhoneNum = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtGender = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtFullName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUserRoleName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUserId = new Guna.UI2.WinForms.Guna2TextBox();
            this.datetimeDOB = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btn_edit_user_info = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btn_save_updates = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnChangePic = new Guna.UI2.WinForms.Guna2GradientButton();
            this.txtVisitFee = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSpecialization = new Guna.UI2.WinForms.Guna2TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pnlDoctorFields = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_back = new Guna.UI2.WinForms.Guna2GradientButton();
            this.picPhoto = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lbl_warning_email_uniqueness = new System.Windows.Forms.Label();
            this.lbl_warning_phoneNum_uniqueness = new System.Windows.Forms.Label();
            this.UserProfilePanel = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlDoctorFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            this.UserProfilePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(440, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Profile";
//            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(143, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID :";
           // this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(117, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Role :";
            //this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 30);
            this.label4.TabIndex = 3;
            this.label4.Text = "Full Name :";
           // this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(46, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 30);
            this.label5.TabIndex = 4;
            this.label5.Text = "User name :";
           // this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(102, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 30);
            this.label6.TabIndex = 5;
            this.label6.Text = "Email :";
          //  this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(80, 349);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 30);
            this.label7.TabIndex = 6;
            this.label7.Text = "Contact :";
          //  this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(76, 427);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 30);
            this.label8.TabIndex = 7;
            this.label8.Text = "Address :";
         //   this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(87, 480);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 30);
            this.label9.TabIndex = 8;
            this.label9.Text = "Gender :";
         //   this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(112, 534);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 30);
            this.label10.TabIndex = 9;
            this.label10.Text = "DOB :";
         //   this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Animated = true;
            this.txtUserName.AutoRoundedCorners = true;
            this.txtUserName.BackColor = System.Drawing.Color.Transparent;
            this.txtUserName.BorderColor = System.Drawing.Color.Black;
            this.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserName.DefaultText = "";
            this.txtUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.txtUserName.ForeColor = System.Drawing.Color.Black;
            this.txtUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserName.Location = new System.Drawing.Point(265, 222);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PlaceholderText = "";
            this.txtUserName.SelectedText = "";
            this.txtUserName.Size = new System.Drawing.Size(391, 35);
            this.txtUserName.TabIndex = 10;
        //    this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Animated = true;
            this.txtEmail.AutoRoundedCorners = true;
            this.txtEmail.BackColor = System.Drawing.Color.Transparent;
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
            this.txtEmail.Location = new System.Drawing.Point(265, 269);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(391, 35);
            this.txtEmail.TabIndex = 11;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // txtPhoneNum
            // 
            this.txtPhoneNum.Animated = true;
            this.txtPhoneNum.AutoRoundedCorners = true;
            this.txtPhoneNum.BackColor = System.Drawing.Color.Transparent;
            this.txtPhoneNum.BorderColor = System.Drawing.Color.Black;
            this.txtPhoneNum.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhoneNum.DefaultText = "";
            this.txtPhoneNum.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPhoneNum.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPhoneNum.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhoneNum.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhoneNum.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhoneNum.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNum.ForeColor = System.Drawing.Color.Black;
            this.txtPhoneNum.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhoneNum.Location = new System.Drawing.Point(265, 349);
            this.txtPhoneNum.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtPhoneNum.Name = "txtPhoneNum";
            this.txtPhoneNum.PlaceholderText = "";
            this.txtPhoneNum.SelectedText = "";
            this.txtPhoneNum.Size = new System.Drawing.Size(391, 35);
            this.txtPhoneNum.TabIndex = 12;
            this.txtPhoneNum.TextChanged += new System.EventHandler(this.txtPhoneNum_TextChanged);
            // 
            // txtAddress
            // 
            this.txtAddress.Animated = true;
            this.txtAddress.AutoRoundedCorners = true;
            this.txtAddress.BackColor = System.Drawing.Color.Transparent;
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
            this.txtAddress.Location = new System.Drawing.Point(265, 427);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PlaceholderText = "";
            this.txtAddress.SelectedText = "";
            this.txtAddress.Size = new System.Drawing.Size(391, 35);
            this.txtAddress.TabIndex = 13;
          //  this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // txtGender
            // 
            this.txtGender.Animated = true;
            this.txtGender.AutoRoundedCorners = true;
            this.txtGender.BackColor = System.Drawing.Color.Transparent;
            this.txtGender.BorderColor = System.Drawing.Color.Black;
            this.txtGender.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGender.DefaultText = "";
            this.txtGender.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtGender.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtGender.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGender.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGender.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGender.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGender.ForeColor = System.Drawing.Color.Black;
            this.txtGender.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGender.Location = new System.Drawing.Point(265, 480);
            this.txtGender.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtGender.Name = "txtGender";
            this.txtGender.PlaceholderText = "";
            this.txtGender.SelectedText = "";
            this.txtGender.Size = new System.Drawing.Size(391, 35);
            this.txtGender.TabIndex = 14;
         //   this.txtGender.TextChanged += new System.EventHandler(this.txtGender_TextChanged);
            // 
            // txtFullName
            // 
            this.txtFullName.Animated = true;
            this.txtFullName.AutoRoundedCorners = true;
            this.txtFullName.BackColor = System.Drawing.Color.Transparent;
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
            this.txtFullName.Location = new System.Drawing.Point(265, 175);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.PlaceholderText = "";
            this.txtFullName.SelectedText = "";
            this.txtFullName.Size = new System.Drawing.Size(391, 35);
            this.txtFullName.TabIndex = 15;
        //    this.txtFullName.TextChanged += new System.EventHandler(this.txtFullName_TextChanged);
            // 
            // txtUserRoleName
            // 
            this.txtUserRoleName.Animated = true;
            this.txtUserRoleName.AutoRoundedCorners = true;
            this.txtUserRoleName.BackColor = System.Drawing.Color.Transparent;
            this.txtUserRoleName.BorderColor = System.Drawing.Color.Black;
            this.txtUserRoleName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserRoleName.DefaultText = "";
            this.txtUserRoleName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUserRoleName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUserRoleName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserRoleName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserRoleName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserRoleName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserRoleName.ForeColor = System.Drawing.Color.Black;
            this.txtUserRoleName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserRoleName.Location = new System.Drawing.Point(265, 128);
            this.txtUserRoleName.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtUserRoleName.Name = "txtUserRoleName";
            this.txtUserRoleName.PlaceholderText = "";
            this.txtUserRoleName.SelectedText = "";
            this.txtUserRoleName.Size = new System.Drawing.Size(391, 35);
            this.txtUserRoleName.TabIndex = 16;
         //   this.txtUserRoleName.TextChanged += new System.EventHandler(this.txtUserRoleName_TextChanged);
            // 
            // txtUserId
            // 
            this.txtUserId.Animated = true;
            this.txtUserId.AutoRoundedCorners = true;
            this.txtUserId.BackColor = System.Drawing.Color.Transparent;
            this.txtUserId.BorderColor = System.Drawing.Color.Black;
            this.txtUserId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserId.DefaultText = "";
            this.txtUserId.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUserId.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUserId.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserId.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserId.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserId.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserId.ForeColor = System.Drawing.Color.Black;
            this.txtUserId.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserId.Location = new System.Drawing.Point(265, 78);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.PlaceholderText = "";
            this.txtUserId.SelectedText = "";
            this.txtUserId.Size = new System.Drawing.Size(391, 35);
            this.txtUserId.TabIndex = 17;
        //    this.txtUserId.TextChanged += new System.EventHandler(this.txtUserId_TextChanged);
            // 
            // datetimeDOB
            // 
            this.datetimeDOB.Animated = true;
            this.datetimeDOB.AutoRoundedCorners = true;
            this.datetimeDOB.BackColor = System.Drawing.Color.Transparent;
            this.datetimeDOB.BorderThickness = 1;
            this.datetimeDOB.Checked = true;
            this.datetimeDOB.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.datetimeDOB.FocusedColor = System.Drawing.Color.White;
            this.datetimeDOB.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.datetimeDOB.ForeColor = System.Drawing.Color.White;
            this.datetimeDOB.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.datetimeDOB.IndicateFocus = true;
            this.datetimeDOB.Location = new System.Drawing.Point(265, 534);
            this.datetimeDOB.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.datetimeDOB.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.datetimeDOB.Name = "datetimeDOB";
            this.datetimeDOB.Size = new System.Drawing.Size(391, 35);
            this.datetimeDOB.TabIndex = 18;
            this.datetimeDOB.UseTransparentBackground = true;
            this.datetimeDOB.Value = new System.DateTime(2025, 9, 28, 18, 17, 8, 22);
          //  this.datetimeDOB.ValueChanged += new System.EventHandler(this.datetimeDOB_ValueChanged);
            // 
            // btn_edit_user_info
            // 
            this.btn_edit_user_info.Animated = true;
            this.btn_edit_user_info.AutoRoundedCorners = true;
            this.btn_edit_user_info.BackColor = System.Drawing.Color.Transparent;
            this.btn_edit_user_info.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_edit_user_info.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_edit_user_info.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_edit_user_info.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_edit_user_info.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_edit_user_info.FillColor = System.Drawing.Color.LightGreen;
            this.btn_edit_user_info.FillColor2 = System.Drawing.Color.DarkGreen;
            this.btn_edit_user_info.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit_user_info.ForeColor = System.Drawing.Color.White;
            this.btn_edit_user_info.IndicateFocus = true;
            this.btn_edit_user_info.Location = new System.Drawing.Point(731, 559);
            this.btn_edit_user_info.Name = "btn_edit_user_info";
            this.btn_edit_user_info.Size = new System.Drawing.Size(124, 47);
            this.btn_edit_user_info.TabIndex = 19;
            this.btn_edit_user_info.Text = "Edit";
            this.btn_edit_user_info.UseTransparentBackground = true;
            this.btn_edit_user_info.Click += new System.EventHandler(this.btn_edit_user_info_Click);
            // 
            // btn_save_updates
            // 
            this.btn_save_updates.Animated = true;
            this.btn_save_updates.AutoRoundedCorners = true;
            this.btn_save_updates.BackColor = System.Drawing.Color.Transparent;
            this.btn_save_updates.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_save_updates.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_save_updates.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_save_updates.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_save_updates.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_save_updates.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_save_updates.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_save_updates.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save_updates.ForeColor = System.Drawing.Color.White;
            this.btn_save_updates.IndicateFocus = true;
            this.btn_save_updates.Location = new System.Drawing.Point(945, 559);
            this.btn_save_updates.Name = "btn_save_updates";
            this.btn_save_updates.Size = new System.Drawing.Size(122, 47);
            this.btn_save_updates.TabIndex = 21;
            this.btn_save_updates.Text = "Save";
            this.btn_save_updates.UseTransparentBackground = true;
            this.btn_save_updates.Click += new System.EventHandler(this.btn_save_updates_Click);
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
            this.btnChangePic.FillColor = System.Drawing.Color.Turquoise;
            this.btnChangePic.FillColor2 = System.Drawing.Color.Teal;
            this.btnChangePic.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePic.ForeColor = System.Drawing.Color.White;
            this.btnChangePic.IndicateFocus = true;
            this.btnChangePic.Location = new System.Drawing.Point(813, 472);
            this.btnChangePic.Name = "btnChangePic";
            this.btnChangePic.Size = new System.Drawing.Size(189, 43);
            this.btnChangePic.TabIndex = 23;
            this.btnChangePic.Text = "Change profile pic";
            this.btnChangePic.UseTransparentBackground = true;
            this.btnChangePic.Visible = false;
            this.btnChangePic.Click += new System.EventHandler(this.btnChangePic_Click);
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
            this.txtVisitFee.Location = new System.Drawing.Point(240, 61);
            this.txtVisitFee.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtVisitFee.Name = "txtVisitFee";
            this.txtVisitFee.PlaceholderText = "";
            this.txtVisitFee.SelectedText = "";
            this.txtVisitFee.Size = new System.Drawing.Size(391, 35);
            this.txtVisitFee.TabIndex = 27;
            this.txtVisitFee.TextChanged += new System.EventHandler(this.txtVisitFee_TextChanged);
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
            this.txtSpecialization.Location = new System.Drawing.Point(240, 14);
            this.txtSpecialization.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtSpecialization.Name = "txtSpecialization";
            this.txtSpecialization.PlaceholderText = "";
            this.txtSpecialization.SelectedText = "";
            this.txtSpecialization.Size = new System.Drawing.Size(391, 35);
            this.txtSpecialization.TabIndex = 26;
         //   this.txtSpecialization.TextChanged += new System.EventHandler(this.txtSpecialization_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(63, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 24);
            this.label11.TabIndex = 25;
            this.label11.Text = "Visit Fee :";
          //  this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(167, 24);
            this.label12.TabIndex = 24;
            this.label12.Text = "Specialization :";
         //   this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // pnlDoctorFields
            // 
            this.pnlDoctorFields.BackColor = System.Drawing.Color.Transparent;
            this.pnlDoctorFields.Controls.Add(this.label12);
            this.pnlDoctorFields.Controls.Add(this.txtVisitFee);
            this.pnlDoctorFields.Controls.Add(this.label11);
            this.pnlDoctorFields.Controls.Add(this.txtSpecialization);
            this.pnlDoctorFields.Location = new System.Drawing.Point(25, 576);
            this.pnlDoctorFields.Name = "pnlDoctorFields";
            this.pnlDoctorFields.Size = new System.Drawing.Size(645, 119);
            this.pnlDoctorFields.TabIndex = 28;
         //   this.pnlDoctorFields.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDoctorFields_Paint);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(829, 427);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(150, 24);
            this.label13.TabIndex = 29;
            this.label13.Text = "Pofile Picture";
         //   this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // btn_back
            // 
            this.btn_back.Animated = true;
            this.btn_back.AutoRoundedCorners = true;
            this.btn_back.BackColor = System.Drawing.Color.Transparent;
            this.btn_back.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_back.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_back.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_back.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_back.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_back.FillColor = System.Drawing.Color.Red;
            this.btn_back.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_back.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_back.ForeColor = System.Drawing.Color.Black;
            this.btn_back.IndicateFocus = true;
            this.btn_back.Location = new System.Drawing.Point(37, 12);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(107, 34);
            this.btn_back.TabIndex = 30;
            this.btn_back.Text = "Back";
            this.btn_back.UseTransparentBackground = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // picPhoto
            // 
            this.picPhoto.BackColor = System.Drawing.Color.Transparent;
            this.picPhoto.BorderRadius = 50;
            this.picPhoto.Image = global::Hospital_Management_System.Properties.Resources.blank_profile_picture_973460_1920;
            this.picPhoto.ImageRotate = 0F;
            this.picPhoto.Location = new System.Drawing.Point(751, 78);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(308, 325);
            this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPhoto.TabIndex = 22;
            this.picPhoto.TabStop = false;
            this.picPhoto.UseTransparentBackground = true;
         //   this.picPhoto.Click += new System.EventHandler(this.picPhoto_Click);
            // 
            // lbl_warning_email_uniqueness
            // 
            this.lbl_warning_email_uniqueness.AutoSize = true;
            this.lbl_warning_email_uniqueness.BackColor = System.Drawing.Color.Transparent;
            this.lbl_warning_email_uniqueness.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_warning_email_uniqueness.ForeColor = System.Drawing.Color.Red;
            this.lbl_warning_email_uniqueness.Location = new System.Drawing.Point(265, 310);
            this.lbl_warning_email_uniqueness.Name = "lbl_warning_email_uniqueness";
            this.lbl_warning_email_uniqueness.Size = new System.Drawing.Size(334, 16);
            this.lbl_warning_email_uniqueness.TabIndex = 58;
            this.lbl_warning_email_uniqueness.Text = "*Email is already in use. Please use a different one.";
            this.lbl_warning_email_uniqueness.Visible = false;
        //    this.lbl_warning_email_uniqueness.Click += new System.EventHandler(this.lbl_warning_email_uniqueness_Click);
            // 
            // lbl_warning_phoneNum_uniqueness
            // 
            this.lbl_warning_phoneNum_uniqueness.AutoSize = true;
            this.lbl_warning_phoneNum_uniqueness.BackColor = System.Drawing.Color.Transparent;
            this.lbl_warning_phoneNum_uniqueness.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_warning_phoneNum_uniqueness.ForeColor = System.Drawing.Color.Red;
            this.lbl_warning_phoneNum_uniqueness.Location = new System.Drawing.Point(265, 390);
            this.lbl_warning_phoneNum_uniqueness.Name = "lbl_warning_phoneNum_uniqueness";
            this.lbl_warning_phoneNum_uniqueness.Size = new System.Drawing.Size(371, 16);
            this.lbl_warning_phoneNum_uniqueness.TabIndex = 59;
            this.lbl_warning_phoneNum_uniqueness.Text = "*Phone num is already in use. Please use a different one.";
            this.lbl_warning_phoneNum_uniqueness.Visible = false;
        //    this.lbl_warning_phoneNum_uniqueness.Click += new System.EventHandler(this.lbl_warning_phoneNum_uniqueness_Click);
            // 
            // UserProfilePanel
            // 
            this.UserProfilePanel.BackgroundImage = global::Hospital_Management_System.Properties.Resources.profilebg;
            this.UserProfilePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UserProfilePanel.Controls.Add(this.label5);
            this.UserProfilePanel.Controls.Add(this.pnlDoctorFields);
            this.UserProfilePanel.Controls.Add(this.label13);
            this.UserProfilePanel.Controls.Add(this.lbl_warning_phoneNum_uniqueness);
            this.UserProfilePanel.Controls.Add(this.btnChangePic);
            this.UserProfilePanel.Controls.Add(this.label2);
            this.UserProfilePanel.Controls.Add(this.btn_save_updates);
            this.UserProfilePanel.Controls.Add(this.lbl_warning_email_uniqueness);
            this.UserProfilePanel.Controls.Add(this.btn_edit_user_info);
            this.UserProfilePanel.Controls.Add(this.picPhoto);
            this.UserProfilePanel.Controls.Add(this.label3);
            this.UserProfilePanel.Controls.Add(this.btn_back);
            this.UserProfilePanel.Controls.Add(this.label4);
            this.UserProfilePanel.Controls.Add(this.label6);
            this.UserProfilePanel.Controls.Add(this.label7);
            this.UserProfilePanel.Controls.Add(this.label8);
            this.UserProfilePanel.Controls.Add(this.label9);
            this.UserProfilePanel.Controls.Add(this.datetimeDOB);
            this.UserProfilePanel.Controls.Add(this.label10);
            this.UserProfilePanel.Controls.Add(this.txtUserId);
            this.UserProfilePanel.Controls.Add(this.label1);
            this.UserProfilePanel.Controls.Add(this.txtUserRoleName);
            this.UserProfilePanel.Controls.Add(this.txtFullName);
            this.UserProfilePanel.Controls.Add(this.txtUserName);
            this.UserProfilePanel.Controls.Add(this.txtGender);
            this.UserProfilePanel.Controls.Add(this.txtEmail);
            this.UserProfilePanel.Controls.Add(this.txtAddress);
            this.UserProfilePanel.Controls.Add(this.txtPhoneNum);
            this.UserProfilePanel.Location = new System.Drawing.Point(-13, 0);
            this.UserProfilePanel.Name = "UserProfilePanel";
            this.UserProfilePanel.Size = new System.Drawing.Size(1161, 723);
            this.UserProfilePanel.TabIndex = 60;
            // 
            // UserProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Hospital_Management_System.Properties.Resources.profilebg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1127, 707);
            this.Controls.Add(this.UserProfilePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "UserProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Profile Form";
            this.Load += new System.EventHandler(this.UserProfileForm_Load);
            this.pnlDoctorFields.ResumeLayout(false);
            this.pnlDoctorFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            this.UserProfilePanel.ResumeLayout(false);
            this.UserProfilePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2TextBox txtUserName;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtPhoneNum;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private Guna.UI2.WinForms.Guna2TextBox txtGender;
        private Guna.UI2.WinForms.Guna2TextBox txtFullName;
        private Guna.UI2.WinForms.Guna2TextBox txtUserRoleName;
        private Guna.UI2.WinForms.Guna2TextBox txtUserId;
        private Guna.UI2.WinForms.Guna2DateTimePicker datetimeDOB;
        private Guna.UI2.WinForms.Guna2GradientButton btn_edit_user_info;
        private Guna.UI2.WinForms.Guna2GradientButton btn_save_updates;
        private Guna.UI2.WinForms.Guna2PictureBox picPhoto;
        private Guna.UI2.WinForms.Guna2GradientButton btnChangePic;
        private Guna.UI2.WinForms.Guna2TextBox txtVisitFee;
        private Guna.UI2.WinForms.Guna2TextBox txtSpecialization;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel pnlDoctorFields;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2GradientButton btn_back;
        private System.Windows.Forms.Label lbl_warning_email_uniqueness;
        private System.Windows.Forms.Label lbl_warning_phoneNum_uniqueness;
        private Guna.UI2.WinForms.Guna2Panel UserProfilePanel;
    }
}