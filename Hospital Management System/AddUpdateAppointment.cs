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

    

    public partial class AddUpdateAppointment : Form
    {
        private readonly HospitalContext context = new HospitalContext();

        // Lists to hold patients and doctors
        private List<PatientDto> allPatients;
        private List<DoctorDto> allDoctors;

        // Selected IDs
        private int? selectedPatientId;
        private int? selectedDoctorId;

        // If updating an appointment
        private int? appointmentId;

        public AddUpdateAppointment(int? appointmentId)
        {
            InitializeComponent();
            this.appointmentId = appointmentId;
        }

        private (bool Success, string Error) CreateAppointment(int patientId, int doctorId, DateTime appointmentDate)
        {
            try
            {
                var today = DateTime.Now.Date;
                var tomorrow = today.AddDays(1);
                var dateOnly = appointmentDate.Date;

                if (dateOnly != today && dateOnly != tomorrow)
                    return (false, "Appointment must be for today or tomorrow.");

                var appointment = new Appointment
                {
                    Patient_User_ID = patientId,
                    Doctor_User_ID = doctorId,
                    AppointmentDate = appointmentDate,
                    Billing_Status = "Unpaid",
                    Appoinment_Status = "Pending"
                };

                context.Appointments.Add(appointment);
                context.SaveChanges();

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, "Error creating appointment: " + ex.Message);
            }
        }

        private (bool Success, string Error) UpdateAppointmentDate(int appointmentId, DateTime newDate)
        {
            try
            {
                var appointment = context.Appointments.FirstOrDefault(a => a.AppointmentID == appointmentId);
                if (appointment == null)
                    return (false, "Appointment not found.");

                // Only allow update if not cancelled
                if (appointment.Appoinment_Status == "Cancelled")
                    return (false, "Cannot update a cancelled appointment.");

                var today = DateTime.Now.Date;
                var tomorrow = today.AddDays(1);
                var dateOnly = newDate.Date;

                if (dateOnly != today && dateOnly != tomorrow)
                    return (false, "Appointment must be for today or tomorrow.");

                appointment.AppointmentDate = newDate;
                context.SaveChanges();

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, "Error updating appointment: " + ex.Message);
            }
        }


        private void LoadPatients()
        {
            allPatients = context.Users.Where(u => u.RoleID == 5).Select(u => new PatientDto
                {
                    UserID = u.UserID,
                    FullName = u.FullName,
                    Phone = u.PhoneNumber
                }).ToList();

            dgvPatients.DataSource = allPatients;
        }

        private void LoadDoctors()
        {
            allDoctors = context.Users
                .Where(u => u.RoleID == 4) // Doctor role
                .Select(u => new DoctorDto
                {
                    UserID = u.UserID,
                    FullName = u.FullName,
                    Specialization = u.Specialization
                }).ToList();

            dgvDoctors.DataSource = allDoctors;
        }

        private void LoadAppointmentForUpdate(int appointmentId)
        {
            var appointment = context.Appointments.Find(appointmentId);
            if (appointment == null) return;

            // Fill patient panel
            var patient = context.Users.Find(appointment.Patient_User_ID);
            selectedPatientId = patient.UserID;
            lblPatientID.Text = patient.UserID.ToString();
            lblPatientName.Text = patient.FullName;
            lblPatientPhone.Text = patient.PhoneNumber;
            lblPatientDOB.Text = patient.DOB.ToShortDateString();

            // Fill doctor panel
            var doctor = context.Users.Find(appointment.Doctor_User_ID);
            selectedDoctorId = doctor.UserID;
            lblDoctorID.Text = doctor.UserID.ToString();
            lblDoctorName.Text = doctor.FullName;
            lblDoctorSpecialization.Text = doctor.Specialization;
            lblDoctorVisitFee.Text = doctor.Visit_Fee.ToString();

            // Appointment date
            dtpAppointment.Value = appointment.AppointmentDate;
        }


        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddUpdateAppointment_Load(object sender, EventArgs e)
        {
            LoadPatients();
            LoadDoctors();

            if (appointmentId.HasValue)
            {
                // Update mode
                LoadAppointmentForUpdate(appointmentId.Value);
                txtPatientSearch.Enabled = false;
                txtDoctorSearch.Enabled = false;
            }
        }

        private void txtPatientSearch_TextChanged(object sender, EventArgs e)
        {
            string text = txtPatientSearch.Text.ToLower();
            dgvPatients.DataSource = allPatients.Where(p => p.UserID.ToString().Contains(text)|| p.FullName.ToLower().Contains(text)|| p.Phone.Contains(text)).ToList();
        }

        private void txtDoctorSearch_TextChanged(object sender, EventArgs e)
        {
            string text = txtDoctorSearch.Text.ToLower();
            dgvDoctors.DataSource = allDoctors.Where(d => d.UserID.ToString().Contains(text)|| d.FullName.ToLower().Contains(text)|| d.Specialization.ToLower().Contains(text)).ToList();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!selectedPatientId.HasValue || !selectedDoctorId.HasValue)
            {
                MessageBox.Show("Please select both patient and doctor.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime apDate = dtpAppointment.Value;
            (bool Success, string Error) result;

            if (appointmentId.HasValue)
            {
                // Update appointment
                result = UpdateAppointmentDate(appointmentId.Value, apDate);
            }
            else
            {
                // Create new appointment
                result = CreateAppointment(selectedPatientId.Value, selectedDoctorId.Value, apDate);
            }

            if (result.Success)
            {
                MessageBox.Show("Saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Clear selections
            selectedPatientId = null;
            selectedDoctorId = null;

            txtPatientSearch.Text = "";
            txtDoctorSearch.Text = "";

            dgvPatients.DataSource = allPatients;
            dgvDoctors.DataSource = allDoctors;

            lblPatientID.Text = "";
            lblPatientName.Text = "";
            lblPatientPhone.Text = "";
            lblPatientDOB.Text = "";

            lblDoctorID.Text = "";
            lblDoctorName.Text = "";
            lblDoctorSpecialization.Text = "";
            lblDoctorVisitFee.Text = "";

            dtpAppointment.Value = DateTime.Now;
        }

        private void dgvPatients_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvPatients.Rows[e.RowIndex];
            selectedPatientId = Convert.ToInt32(row.Cells["UserID"].Value);

            var patient = context.Users.Find(selectedPatientId);


            // Fill patient panel
            lblPatientID.Text = row.Cells["UserID"].Value.ToString();
            lblPatientName.Text = row.Cells["FullName"].Value.ToString();
            lblPatientPhone.Text = row.Cells["Phone"].Value.ToString();
            lblPatientDOB.Text = patient.DOB.ToShortDateString();

            // Clear search & grid
            txtPatientSearch.Text = "";
            dgvPatients.Refresh();
        }

        private void dgvDoctors_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvDoctors.Rows[e.RowIndex];
            selectedDoctorId = Convert.ToInt32(row.Cells["UserID"].Value);

            var doctor = context.Users.Find(selectedDoctorId);

            // Fill doctor panel
            lblDoctorID.Text = doctor.UserID.ToString();
            lblDoctorName.Text = doctor.FullName;
            lblDoctorSpecialization.Text = doctor.Specialization;
            lblDoctorVisitFee.Text = doctor.Visit_Fee.ToString();

            // Clear search & grid
            txtDoctorSearch.Text = "";
            dgvDoctors.Refresh();
        }
    }

    public class PatientDto
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
    }

    public class DoctorDto
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Specialization { get; set; }
    }
}
