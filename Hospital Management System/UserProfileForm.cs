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
        private  UserService userService = new UserService();
        private User currentUser;
        private int UserID;
        private int RoleID;
        private string Username;
        public UserProfileForm(int userid, int roleid, string username)
        {
            InitializeComponent();;
            this.UserID = userid;
            this.RoleID = roleid;
            this.Username = username;
            currentUser = context.Users.FirstOrDefault(u => u.UserID == UserID);
        }

        private void UserProfileForm_Load(object sender, EventArgs e)
        {
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
                    string roleName = GetRoleName(RoleID);
                    txtUserId.Text = UserID.ToString();
                    txtUserRoleName.Text = roleName;
                    txtFullName.Text = currentUser.FullName;
                    txtUserName.Text = currentUser.Username;
                    txtEmail.Text = currentUser.Email;
                    txtPhoneNum.Text = currentUser.PhoneNumber;
                    txtAddress.Text = currentUser.Address;
                    txtGender.Text = currentUser.Gender;
                    datetimeDOB.Text = currentUser.DOB.ToString("dd-MM-yyyy");

                    if (RoleID == 4) // Doctor
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
                        picProfileBox.Image = Image.FromFile(currentUser.Photo);
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

        private void btnChangePic_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    currentUser.Photo = ofd.FileName;
                    picProfileBox.Image = Image.FromFile(ofd.FileName);
                }
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

                if (RoleID == 4) // Doctor
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
            this.Hide();
            new AdminPortal(UserID, RoleID, Username).Show();
        }
    }
}
