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
    public partial class ManagerPortal : Form
    {
        private int UserID;
        private HospitalContext context;
        private User correntUser;
        private DashboardService dashboardService;
        public ManagerPortal(int userid)
        {
            InitializeComponent();
            this.UserID = userid;
            context = new HospitalContext();
            correntUser = context.Users.FirstOrDefault(u => u.UserID == UserID);
            dashboardService = new DashboardService();
            this.Load += ManagerPortal_Load;
        }

        private void RefreshDashboard()
        {
            try
            {
                var counts = dashboardService.GetDashboardCounts();

                lblActivePatients.Text = counts.ActivePatients.ToString();
                lblActiveEmployee.Text = counts.ActiveEmployees.ToString();
                lblPendingAppointments.Text = counts.PendingAppointments.ToString();
                lblConfirmedAppointments.Text = counts.ConfirmedAppointments.ToString();
                lblTotalAdmin.Text = counts.TotalAdmins.ToString();
                lblTotalDoctor.Text = counts.TotalDoctors.ToString();
                lblTotalReceptionist.Text = counts.TotalReceptionists.ToString();
                lblTotalManager.Text = counts.TotalManagers.ToString();
                lblTotalPharmacist.Text = counts.TotalPharmacists.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing dashboard: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_profile_button_Click(object sender, EventArgs e)
        {
            UserProfileForm userProfileForm = new UserProfileForm(UserID);
            userProfileForm.Show(this);
            this.Hide();
        }

        private void btn_manage_patient_Click(object sender, EventArgs e)
        {
            var managePatientsForm = new ManageUsers(true, UserID);
            managePatientsForm.Show(this);
            this.Hide();
        }

        private void btn_manage_employee_Click(object sender, EventArgs e)
        {
            var manageEmployeesForm = new ManageUsers(false, UserID);
            manageEmployeesForm.Show(this);
            this.Hide();
        }

        private void btn_manage_appointment_Click(object sender, EventArgs e)
        {
            var manageAppointment = new Appointment_form(UserID);
            manageAppointment.Show(this);
            this.Hide();
        }

        private void btn_manage_billing_Click(object sender, EventArgs e)
        {
            var manageBilling = new Billing_form(UserID);
            manageBilling.Show(this);
            this.Hide();
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

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private async void ManagerPortal_Load(object sender, EventArgs e)
        {
            await Task.Delay(100);
            RefreshDashboard();
        }
    }
}
