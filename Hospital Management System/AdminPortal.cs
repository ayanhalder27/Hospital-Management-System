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
        private readonly DashboardService dashboardService;
        private Timer timer = new Timer();
        public AdminPortal(int userid)
        {
            InitializeComponent();
            this.UserID = userid;
            context = new HospitalContext();
            correntUser = context.Users.FirstOrDefault(u => u.UserID == UserID);
            dashboardService = new DashboardService(context);
            this.Load += AdminPortal_Load;

        }
        private void RefreshDashboard()
        {
            try
            {
                var c = dashboardService.GetDashboardCounts();

                lblActivePatients.Text = c.ActivePatients.ToString();
                lblActiveEmployee.Text = c.ActiveEmployees.ToString();
                lblPendingAppointments.Text = c.PendingAppointments.ToString();
                lblConfirmedAppointments.Text = c.ConfirmedAppointments.ToString();
                lblTotalAdmin.Text = c.TotalAdmins.ToString();
                lblTotalDoctor.Text = c.TotalDoctors.ToString();
                lblTotalReceptionist.Text = c.TotalReceptionists.ToString();
                lblTotalManager.Text = c.TotalManagers.ToString();
                lblTotalPharmacist.Text = c.TotalPharmacists.ToString();
            }
            catch (Exception ex)
            {
                timer.Stop();
                MessageBox.Show("Error refreshing dashboard: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
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
            UserProfileForm userProfileForm = new UserProfileForm(UserID);
            userProfileForm.Show();
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

        private void btn_manage_medicine_Click(object sender, EventArgs e)
        {
            ManageMedicines manageMedicines = new ManageMedicines();
            manageMedicines.Show(this);
            this.Hide();
        }

        private void btn_profile_button_Click_1(object sender, EventArgs e)
        {
            UserProfileForm userProfileForm = new UserProfileForm(UserID);
            userProfileForm.Show(this);
            this.Hide();
        }

        private void AdminPortal_Load(object sender, EventArgs e)
        {
            timer.Interval = 5000; 
            timer.Tick += (s, ev) => RefreshDashboard();
            timer.Start();
            RefreshDashboard(); 
        }
    }

   
}
