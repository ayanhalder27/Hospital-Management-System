using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hospital_Management_System
{
    public partial class Appointments : Form
    {
        HospitalContext db = new HospitalContext();
        public static IWin32Window thisPage;
        public Appointments()
        {
            InitializeComponent();
            thisPage = this;
        }

        private Panel dynamicPanel(int id, string name, DateTime date, string number, string status)
        {
            Panel panel = new Panel();
            panel.SuspendLayout();
            panel.BackColor = Color.FromArgb(25,97, 205, 255);
            panel.Location = new Point(3, 3);
            panel.Name = "panel3";
            panel.Size = new Size(250, 250);
            panel.TabIndex = 0;

            AppointmentPanelDesign appointment = new AppointmentPanelDesign(id, name, date, number, status);
            appointment.TopLevel = false;
            appointment.FormBorderStyle = FormBorderStyle.None;
            appointment.AutoScroll = true;
            appointment.Dock = DockStyle.Fill;
            panel.Controls.Add(appointment);
            appointment.Show();

            panel.ResumeLayout(false);
            panel.PerformLayout();

            return panel;
        }

        private void Appointments2_Load(object sender, EventArgs e)
        {
            loadAppointments(cbStatus.Text);
            this.Owner.Hide();
        }

        private void loadAppointments(string status)
        {
            flowLayoutPanel1.Controls.Clear();
            var appointments = from a in db.Appointments
                               join u in db.Users on a.Patient_User_ID equals u.UserID
                               where a.Appoinment_Status == status && a.Doctor_User_ID == Login_form.userID
                               select new { a.AppointmentID, u.FullName, a.AppointmentDate, u.PhoneNumber, a.Appoinment_Status };

            foreach (var a in appointments)
            {
                flowLayoutPanel1.Controls.Add(dynamicPanel(a.AppointmentID, a.FullName, a.AppointmentDate, a.PhoneNumber, a.Appoinment_Status));
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStatus.Text == "All")
            {
                flowLayoutPanel1.Controls.Clear();
                var appointments = from a in db.Appointments
                                   join u in db.Users on a.Patient_User_ID equals u.UserID
                                   where a.Doctor_User_ID == Login_form.userID
                                   select new { a.AppointmentID, u.FullName, a.AppointmentDate, u.PhoneNumber, a.Appoinment_Status };

                foreach (var a in appointments)
                {
                    flowLayoutPanel1.Controls.Add(dynamicPanel(a.AppointmentID, a.FullName, a.AppointmentDate, a.PhoneNumber, a.Appoinment_Status));
                }
            }
            else
            {
                loadAppointments(cbStatus.Text);
            }
        }
    }
}
