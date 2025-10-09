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
    public partial class DoctorPortal : Form
    {
        public DoctorPortal()
        {
            InitializeComponent();
        }

        private void btnAppointment_Click(object sender, EventArgs e)
        {
            Appointments appointments = new Appointments();
            appointments.Show(this);
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            UserProfileForm profile = new UserProfileForm(Login_form.userID);
            profile.Show(this);
            this.Hide();
        }

        private async void DoctorPortal_Load(object sender, EventArgs e)
        {
            await Task.Delay(100);
            HospitalContext db = new HospitalContext();
            lblWelcome.Text += db.Users.Where(u => u.UserID == Login_form.userID).Select(u => u.FullName).FirstOrDefault();
        }
    }
}
