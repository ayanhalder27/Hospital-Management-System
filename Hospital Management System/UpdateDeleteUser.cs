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

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_update_and_save_Click(object sender, EventArgs e)
        {
            var visitFee = string.IsNullOrEmpty(txtVisitFee.Text) ? (double?)null : double.Parse(txtVisitFee.Text);

            var result = userService.UpdateUsers(userId, txtFullName.Text, txtEmail.Text, txtPhone.Text, txtAddress.Text, cmbGender.Text, dtpDOB.Value, txtSpecialization.Text, visitFee, photoPath.ToString());

            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnChangePic_Click(object sender, EventArgs e)
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

        private void btn_delete_user_Click(object sender, EventArgs e)
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

        private void UpdateDeleteUser_Load(object sender, EventArgs e)
        {
            LoadUserData(); 
        }

        private void btn_cancel_profilePic_Click(object sender, EventArgs e)
        {
            picPhoto.Image = null;
            photoPath = null;
        }
    }
}
