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
    public partial class AddUserForm : Form
    {
        private readonly HospitalContext context = new HospitalContext();
        private User currentUser;
        private readonly UserService userService = new UserService();
        private readonly bool isPatient;
        private string photoPath;
        public AddUserForm(bool isPatient)
        {
            InitializeComponent();
            this.isPatient = isPatient;
            photoPath = null;
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

        private void btn_add_new_user_Click(object sender, EventArgs e)
        {
            try
            {
                int roleId = 0;
                if (isPatient)
                {
                    roleId = 5;
                }
                else
                {
                    roleId = Convert.ToInt32(cmbRoles.SelectedValue);
                }

                double? visitFee = null;
                string specialization = null;

                if (pnlDoctorFields.Visible)
                {
                    visitFee = Convert.ToDouble(txtVisitFee.Text);
                    specialization = txtSpecialization.Text;
                }

                var result = userService.CreateUser(txtFullName.Text, txtEmail.Text, txtPhone.Text, txtAddress.Text, cmbGender.Text, dtpDOB.Value, roleId, specialization, visitFee, photoPath);
                if (!result.Success)
                {
                    MessageBox.Show(result.ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("A new user added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_close.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Load roles only if Employee
                if (!isPatient)
                {
                    cmbRoles.DataSource = userService.GetRoles();
                    cmbRoles.DisplayMember = "RoleName";
                    cmbRoles.ValueMember = "RoleID";
                }
                else
                {
                    cmbRoles.Visible = false;
                    lblRole.Visible = false;
                }
                pnlDoctorFields.Visible = false; // hide doctor fields initially
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbRoles.SelectedItem is Role selectedRole && selectedRole.RoleName == "Doctor")
                {
                    pnlDoctorFields.Visible = true;
                }
                else
                {
                    pnlDoctorFields.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error handling role selection: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!userService.IsEmailUnique(txtEmail.Text))
                {
                    lbl_warning_eamil_uniqueness.Visible = true;
                }
                else
                {
                    lbl_warning_eamil_uniqueness.Visible = false; 
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validating email: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!userService.IsPhoneUnique(txtPhone.Text))
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
                MessageBox.Show("Error validating phone number: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void btn_cancel_profilePic_Click(object sender, EventArgs e)
        {
            try
            {
                picPhoto.Image = null;
                photoPath = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing profile picture: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_clearAll_form_Click(object sender, EventArgs e)
        {
            try
            {
                cmbRoles.SelectedIndex = -1;
                txtFullName.Clear();
                txtEmail.Clear();
                txtPhone.Clear();
                txtAddress.Clear();
                cmbGender.SelectedIndex = -1;
                dtpDOB.Value = DateTime.Now;
                txtSpecialization.Clear();
                txtVisitFee.Clear();
                picPhoto.Image = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
