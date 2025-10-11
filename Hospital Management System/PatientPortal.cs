using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System 
{
    public partial class PatientPortal : Form
    {
        private int UserID;
        public PatientPortal(int userid)
        {
            InitializeComponent();
            this.UserID = userid;
        }

        private async void PatientPortal_Load(object sender, EventArgs e)
        {
            await Task.Delay(100);
            HospitalContext db = new HospitalContext();

            lblWelcome.Text += db.Users.Where(u => u.UserID == Login_form.userID).Select(u => u.FullName).FirstOrDefault();

            lblAppointmentCount.Text = db.Appointments.Count(a => a.Patient_User_ID == Login_form.userID && a.Appoinment_Status != "Completed").ToString();

            lblRecordCount.Text = db.Prescriptions.Join(db.Appointments, p => p.AppointmentID, a => a.AppointmentID, (p, a) => new { p, a })
                                                  .Where(x => x.a.Patient_User_ID == Login_form.userID).Count().ToString();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            UserProfileForm p = new UserProfileForm(Login_form.userID);
            p.Show(this);
            this.Hide();
        }

        private void btnMyPrescriptions_Click(object sender, EventArgs e)
        {
            AppointmentDetails a = new AppointmentDetails(Login_form.userID);
            a.Show(this);
        }

        private void cardRecords_Click(object sender, EventArgs e)
        {
            btnMyPrescriptions.PerformClick();
        }

        private void btnAppointment_Click(object sender, EventArgs e)
        {
            AddUpdateAppointment a = new AddUpdateAppointment();
            a.Show(this);
            this.Hide();
        }
    }
}
