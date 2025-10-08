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
    public partial class UpdateDeleteUser : Form
    {
        private HospitalContext context = new HospitalContext();
        private UserService userService = new UserService();
        private int userId;
        private string photoPath = null;
        public UpdateDeleteUser(int userID)
        {
            InitializeComponent();
            this.userId = userID;
        }

        private void LoadUserData()
        {
            try
            {
                var user = userService.GetUserById(userId);
                if (user == null) return;

                txtUserId.Text = user.UserID.ToString();       // Read-only
                txtUserName.Text = user.Username;              // Read-only
                txtRole.Text = user.Role.RoleName;             // Read-only

                txtFullName.Text = user.FullName;
                txtEmail.Text = user.Email;
                txtPhone.Text = user.PhoneNumber;
                txtAddress.Text = user.Address;
                cmbGender.Text = user.Gender;
                dtpDOB.Value = user.DOB;

                // Doctor-only fields
                if (user.RoleID == 4)
                {
                    pnlDoctorFields.Visible = true;
                    txtSpecialization.Text = user.Specialization;
                    txtVisitFee.Text = user.Visit_Fee?.ToString();
                }
                else
                {
                    pnlDoctorFields.Visible = false;
                }

                // Profile picture
                if (!string.IsNullOrEmpty(user.Photo) && File.Exists(user.Photo))
                {
                    picPhoto.Image = Image.FromFile(user.Photo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void btn_update_and_save_Click(object sender, EventArgs e)
        {
            try
            {
                var visitFee = string.IsNullOrEmpty(txtVisitFee.Text) ? (double?)null : double.Parse(txtVisitFee.Text);

                var result = userService.UpdateUsers(userId, txtFullName.Text, txtEmail.Text, txtPhone.Text, txtAddress.Text, cmbGender.Text, dtpDOB.Value, txtSpecialization.Text, visitFee, photoPath);

                if (!result.Success)
                {
                    MessageBox.Show(result.ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Error updating profile picture: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_delete_user_Click(object sender, EventArgs e)
        {
            try
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                var result = userService.DeleteUser(userId);

                if (!result.Success)
                {
                    MessageBox.Show(result.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDeleteUser_Load(object sender, EventArgs e)
        {
            LoadUserData(); 
        }

        private void btn_cancel_profilePic_Click(object sender, EventArgs e)
        {
            try
            {
                picPhoto.Image = null;
                photoPath = null;
                context.Users.Find(userId).Photo = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing profile picture: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var user = userService.GetUserById(userId);
                if (!userService.IsEmailUnique(txtEmail.Text) && txtEmail.Text != user.Email)
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

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var user = userService.GetUserById(userId);
                if (!userService.IsPhoneUnique(txtPhone.Text) && txtPhone.Text != user.PhoneNumber)
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
                MessageBox.Show("Error validating phone uniqueness: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pnlDoctorFields_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRole_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserId_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void lbl_warning_phoneNum_uniqueness_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pnlDoctorFields_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void txtSpecialization_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtVisitFee_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void picPhoto_Click(object sender, EventArgs e)
        {

        }

        private void lbl_warning_email_uniqueness_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
