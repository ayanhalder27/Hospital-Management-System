using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
        private int userID;
        public Appointment_form(int userid)
        {
            InitializeComponent();
            currentUser = context.Users.FirstOrDefault(u => u.UserID == userid);
            this.userID = userid;
        }

        private void LoadAppointments()
        {
            var list = GetAppointments(txtSearch.Text);
            dgvAppointments.DataSource = list;
        }

        private void pic_back_button_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var addAppointmentForm = new AddUpdateAppointment();
                addAppointmentForm.Show();
                //this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening add appointment form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Appointment_form_Load(object sender, EventArgs e)
        {
            await Task.Delay(100);
            try
            {
                AutoCancelExpiredAppointments();
                LoadAppointments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading appointments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<AppointmentDto> GetAppointments(string search = null)
        {
            var query = from a in context.Appointments
                        join p in context.Users on a.Patient_User_ID equals p.UserID
                        join d in context.Users on a.Doctor_User_ID equals d.UserID
                        where a.Appoinment_Status != "Cancelled"
                        select new AppointmentDto
                        {
                            AppointmentID = a.AppointmentID,
                            PatientName = p.FullName,
                            PatientPhone = p.PhoneNumber,
                            DoctorName = d.FullName,
                            AppointmentDate = a.AppointmentDate,
                            Billing_Status = a.Billing_Status,
                            Appoinment_Status = a.Appoinment_Status
                        };

            if (!string.IsNullOrWhiteSpace(search))
            {
                string s = search.Trim().ToLower();
                query = query.Where(x =>
                    x.AppointmentID.ToString().Contains(s) ||
                    x.PatientName.ToLower().Contains(s) ||
                    x.PatientPhone.ToLower().Contains(s) ||
                    x.DoctorName.ToLower().Contains(s) ||
                    x.AppointmentDate.ToString().Contains(s)
                );
            }

            return query.OrderByDescending(a => a.AppointmentID).ToList();
        }
     
        private void AutoCancelExpiredAppointments()
        {
            var now = DateTime.Now;
            var pendings = context.Appointments.Where(a => a.Appoinment_Status == "Pending").ToList();

            foreach (var ap in pendings)
            {
                var cancelDeadline = ap.AppointmentDate.Date.AddHours(48);
                if (now > cancelDeadline)
                {
                    ap.Appoinment_Status = "Cancelled";
                }
            }
            context.SaveChanges();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void btnRefresh_Click(object sender, EventArgs e) 
        {
            try
            {
                LoadAppointments();
                txtSearch.Clear();
                dgvAppointments.ClearSelection();
                dgvAppointments.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing appointments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAppointments_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var selectedAppointment = (AppointmentDto)dgvAppointments.Rows[e.RowIndex].DataBoundItem;
                    var updateAppointmentForm = new AddUpdateAppointment(selectedAppointment.AppointmentID,selectedAppointment.AppointmentDate);
                    updateAppointmentForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening update appointment form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class AppointmentDto
    {
        public int AppointmentID { get; set; }
        public string PatientName { get; set; }
        public string PatientPhone { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Billing_Status { get; set; }
        public string Appoinment_Status { get; set; }
    }
}
