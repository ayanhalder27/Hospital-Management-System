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
    public partial class AdminPortal : Form
    {
        private int UserID;
        private HospitalContext context;
        private User correntUser;
        public AdminPortal(int userid)
        {
            InitializeComponent();
            this.UserID = userid;
            context = new HospitalContext();
            correntUser = context.Users.FirstOrDefault(u => u.UserID == UserID);
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Login_form login_Form = new Login_form();
            login_Form.Show();
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                lbl_profile_user_name.Text = correntUser.FullName;

                if (!string.IsNullOrWhiteSpace(correntUser.Photo) && File.Exists(correntUser.Photo))
                {
                    using (var stream = new FileStream(correntUser.Photo, FileMode.Open, FileAccess.Read))
                    {
                        picbox_admin_portal.Image = Image.FromStream(stream);
                    }
                }
            }
            catch (Exception ex)  
            {
                MessageBox.Show("Error loading user profile: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_profile_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserProfileForm userProfileForm = new UserProfileForm(UserID);
            userProfileForm.Show();
        }

        private void btn_manage_patient_Click(object sender, EventArgs e)
        {
            this.Hide();
            var managePatientsForm = new ManageUsers(true, UserID);
            managePatientsForm.ShowDialog();         
        }

        private void btn_manage_employee_Click(object sender, EventArgs e)
        {
            this.Hide();
            var manageEmployeesForm = new ManageUsers(false, UserID); 
            manageEmployeesForm.ShowDialog();
        }

        private void btn_manage_appointment_Click(object sender, EventArgs e)
        {
            this.Hide();
            var manageAppointment = new Appointment_form(UserID);
            manageAppointment.ShowDialog();
        }

        private void btn_manage_billing_Click(object sender, EventArgs e)
        {
            this.Hide();
            var manageBilling = new Billing_form(UserID);
            manageBilling.ShowDialog();
        }

        private void btn_manage_medicine_Click(object sender, EventArgs e)
        {
            ManageMedicines manageMedicines = new ManageMedicines();
            manageMedicines.Show(this);
        }

        private void btn_profile_button_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            UserProfileForm userProfileForm = new UserProfileForm(UserID);
            userProfileForm.Show();
        }
    }
}
