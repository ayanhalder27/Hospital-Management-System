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
    public partial class Appointment_form : Form
    {
        private HospitalContext context = new HospitalContext();
        private User currentUser;
        public Appointment_form(int userid)
        {
            InitializeComponent();
            currentUser = context.Users.FirstOrDefault(u => u.UserID == userid);
        }

        private void pic_back_button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                var adminPortal = new AdminPortal(currentUser.UserID);
                adminPortal.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error returning to admin portal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addAppointmentForm = new AddUpdateAppointment(null); 
            addAppointmentForm.Show();
        }
    }
}
