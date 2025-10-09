using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class UserProfileForm : Form
    {
        private HospitalContext context = new HospitalContext();
        private UserService userService = new UserService();
        private string photoPath;
        private User currentUser;
        private int UserID;
        public UserProfileForm(int userid)
        {
            InitializeComponent(); ;
            this.UserID = userid;
            currentUser = context.Users.FirstOrDefault(u => u.UserID == UserID);
        }

        private async void UserProfileForm_Load(object sender, EventArgs e)
        {
            await Task.Delay(100);
            LoadUserProfile();
            SetReadOnlyMode(true);
        }

        private string GetRoleName(int roleId)
        {
            try
            {
                return context.Roles.Where(r => r.RoleID == roleId).Select(r => r.RoleName).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading role name: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        private void LoadUserProfile()
        {
            try
            {
                if (currentUser != null)
                {
                    string roleName = GetRoleName(currentUser.RoleID);
                    txtUserId.Text = UserID.ToString();
                    txtUserRoleName.Text = roleName;
                    txtFullName.Text = currentUser.FullName;
                    txtUserName.Text = currentUser.Username;
                    txtEmail.Text = currentUser.Email;
                    txtPhoneNum.Text = currentUser.PhoneNumber;
                    txtAddress.Text = currentUser.Address;
                    txtGender.Text = currentUser.Gender;
                    datetimeDOB.Text = currentUser.DOB.ToString("dd-MM-yyyy");

                    if (currentUser.RoleID == 4) // Doctor
                    {
                        txtSpecialization.Text = currentUser.Specialization;
                        txtVisitFee.Text = currentUser.Visit_Fee?.ToString();
                        pnlDoctorFields.Visible = true;
                    }
                    else
                    {
                        pnlDoctorFields.Visible = false;
                    }

                    if (!string.IsNullOrEmpty(currentUser.Photo) && File.Exists(currentUser.Photo))
                    {
                        picPhoto.Image = Image.FromFile(currentUser.Photo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user profile: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SetReadOnlyMode(bool isReadOnly)
        {
            try
            {
                txtUserId.ReadOnly = true; // Always read-only
                txtUserRoleName.ReadOnly = true; // Always read-only
                txtFullName.ReadOnly = isReadOnly;
                txtUserName.ReadOnly = true; // Username should not be editable
                txtEmail.ReadOnly = isReadOnly;
                txtPhoneNum.ReadOnly = isReadOnly;
                txtAddress.ReadOnly = isReadOnly;
                txtGender.ReadOnly = isReadOnly;
                datetimeDOB.Enabled = !isReadOnly;

                txtSpecialization.ReadOnly = isReadOnly;
                txtVisitFee.ReadOnly = isReadOnly;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setting read-only mode: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChangePic_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        string sourceFilePath = ofd.FileName;
                        string relativePath = userService.SaveProfilePicture(sourceFilePath);
                        photoPath = relativePath;
                        if (!string.IsNullOrEmpty(relativePath))
                        {
                            picPhoto.Image = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile picture: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_save_updates_Click(object sender, EventArgs e)
        {
            try
            {
                currentUser.FullName = txtFullName.Text;
                currentUser.Email = txtEmail.Text;
                currentUser.PhoneNumber = txtPhoneNum.Text;
                currentUser.Address = txtAddress.Text;
                currentUser.Gender = txtGender.Text;
                currentUser.DOB = DateTime.Parse(datetimeDOB.Text);
                if (!string.IsNullOrEmpty(photoPath))
                {
                    currentUser.Photo = photoPath;
                }

                if (currentUser.RoleID == 4) // Doctor
                {
                    currentUser.Specialization = txtSpecialization.Text;
                    currentUser.Visit_Fee = double.TryParse(txtVisitFee.Text, out double fee) ? fee : 0;
                }

                userService.UpdateUser(currentUser);
                MessageBox.Show("Profile updated successfully!");

                SetReadOnlyMode(true);
                btnChangePic.Visible = false;
                LoadUserProfile();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating profile: " + ex.Message);
            }
        }

        private void btn_edit_user_info_Click(object sender, EventArgs e)
        {
            SetReadOnlyMode(false);
            btnChangePic.Visible = true;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Owner.Refresh();
            this.Close();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!userService.IsEmailUnique(txtEmail.Text) && txtEmail.Text != currentUser.Email)
                {
                    lbl_warning_email_uniqueness.Visible = true;
                }
                else
                {
                    lbl_warning_email_uniqueness.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validating email uniqueness: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPhoneNum_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!userService.IsPhoneUnique(txtPhoneNum.Text) && txtPhoneNum.Text != currentUser.PhoneNumber)
                {
                    lbl_warning_phoneNum_uniqueness.Visible = true;
                }
                else
                {
                    lbl_warning_phoneNum_uniqueness.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validating phone number uniqueness: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGender_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserRoleName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserId_TextChanged(object sender, EventArgs e)
        {

        }

        private void datetimeDOB_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtVisitFee_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSpecialization_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void pnlDoctorFields_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void picPhoto_Click(object sender, EventArgs e)
        {

        }

        private void lbl_warning_email_uniqueness_Click(object sender, EventArgs e)
        {

        }

        private void lbl_warning_phoneNum_uniqueness_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
