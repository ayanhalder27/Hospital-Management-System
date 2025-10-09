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
                var visitFee = string.IsNullOrEmpty(txtVisitFee.Text) ? (double?)null : double.Parse(txtVisitFee.Text);

                var result = userService.UpdateUsers(UserID, txtFullName.Text, txtEmail.Text, txtPhoneNum.Text, txtAddress.Text, txtGender.Text, datetimeDOB.Value, txtSpecialization.Text, visitFee, photoPath);

                if (!result.Success)
                {
                    MessageBox.Show(result.ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Owner.Show();
                this.Owner.Refresh();
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number for Visit Fee.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string email = txtEmail.Text.Trim();
                var user = userService.GetUserById(UserID);
                if (email.Contains("@") && email.IndexOf('.') > email.IndexOf('@') && email != user.Email)
                {
                    lbl_warning_email_uniqueness.Visible = !userService.IsEmailUnique(email);
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
                string phone = txtPhoneNum.Text.Trim();
                var user = userService.GetUserById(UserID);
                if (phone.Length == 11)
                {
                    lbl_warning_phoneNum_uniqueness.Visible = !userService.IsPhoneUnique(phone) && phone != user.PhoneNumber;
                }
                else
                {
                    lbl_warning_phoneNum_uniqueness.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validating phone uniqueness: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtVisitFee_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtVisitFee.Text))
                {
                    return;
                }
                if (decimal.TryParse(txtVisitFee.Text, out decimal visitFee))
                {
                    if (visitFee < 0)
                    {
                        MessageBox.Show("Visit fee must be a positive value.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtVisitFee.Clear();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid decimal number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtVisitFee.Clear();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVisitFee.Clear();
            }
        }
    }
}
