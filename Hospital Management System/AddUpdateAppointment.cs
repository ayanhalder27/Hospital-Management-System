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
        private DateTime? appointmentDate;
        private int? userId;

        public AddUpdateAppointment(int? appointmentId = null, DateTime? dateTime = null, int? userId = null)
        {
            InitializeComponent();
            this.appointmentId = appointmentId;
            this.appointmentDate = dateTime;
            this.userId = userId;
            if (dateTime.HasValue)
            {
                dtpAppointment.Value = dateTime.Value;
            }
        }

        private (bool Success, string Error) CreateAppointment(int patientId, int doctorId, DateTime appointmentDate)
        {
            try
            {
                var today = DateTime.Now.Date;
                var tomorrow = today.AddDays(1);
                var dayAfterTomorrow = today.AddDays(2);
                var dateOnly = appointmentDate.Date;

                if (dateOnly != today && dateOnly != tomorrow && dateOnly != dayAfterTomorrow)
                    return (false, "Appointment must be for today or tomorrow or day after tomorrow.");

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

                var doctorFee = context.Users.Where(u => u.UserID == doctorId).Select(u => u.Visit_Fee).FirstOrDefault() ?? 0;
                var billing = new Billing
                {
                    Biller_User_ID = patientId, 
                    AppointmentID = appointment.AppointmentID,
                    Amount = (decimal)doctorFee,
                    Status = "Unpaid",
                    BillDate = appointmentDate
                };
                context.Billings.Add(billing);
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

                if (appointment.Appoinment_Status == "Cancelled")
                    return (false, "Cannot update a cancelled appointment.");
                if(appointment.Appoinment_Status == "Completed")
                    return (false, "Cannot update a completed appointment.");
                if(appointment.Appoinment_Status == "Confirmed")
                    return (false, "Cannot update an Confirmed appointment.");

                var today = DateTime.Now.Date;
                var tomorrow = today.AddDays(1);
                var dayAfterTomorrow = today.AddDays(2);
                var dateOnly = newDate.Date;

                if (dateOnly != today && dateOnly != tomorrow && dateOnly != dayAfterTomorrow)
                    return (false, "Appointment must be for today or tomorrow or day after tomorrow.");

                appointment.AppointmentDate = newDate;
                context.SaveChanges();

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, "Error updating appointment: " + ex.Message);
            }
        }

        public (bool Success, string Error) CancelAppointment(int appointmentId)
        {
            try
            {
                var ap = context.Appointments.FirstOrDefault(a => a.AppointmentID == appointmentId);
                if (ap == null) return (false, "Appointment not found.");

                ap.Appoinment_Status = "Cancelled";
                context.SaveChanges();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, "Error cancelling appointment: " + ex.Message);
            }
        }


        private void LoadPatients()
        {
            try
            {
                allPatients = context.Users.Where(u => u.RoleID == 5).Select(u => new PatientDto
                {
                    UserID = u.UserID,
                    FullName = u.FullName,
                    Phone = u.PhoneNumber
                }).ToList();

                dgvPatients.DataSource = allPatients;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading patients: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDoctors()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Error loading doctors: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAppointmentForUpdate(int appointmentId)
        {
            try
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
                dtpAppointment.Value = appointmentDate ?? DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading appointment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            //this.Owner.Show();
            //this.Owner.Refresh();
            this.Close();
        }

        private void AddUpdateAppointment_Load(object sender, EventArgs e)
        {
            try
            {
                LoadPatients();
                LoadDoctors();
                var appointment = context.Appointments.Find(appointmentId);
                if (appointmentId.HasValue && appointment.Appoinment_Status == "Pending" && userId == null)
                {
                    // Update mode      
                    txtPatientSearch.Enabled = false;
                    txtDoctorSearch.Enabled = false;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnCancel.Visible = true;
                    dtpAppointment.Value = appointmentDate ?? DateTime.Now;
                    LoadAppointmentForUpdate(appointmentId.Value);
                }
                else if (appointmentId.HasValue && (appointment.Appoinment_Status == "Confirmed" || appointment.Appoinment_Status == "Completed") && userId == null)
                {
                    // View mode      
                    txtPatientSearch.Enabled = false;
                    txtDoctorSearch.Enabled = false;
                    btnSave.Visible = false;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    dtpAppointment.Value = appointmentDate ?? DateTime.Now;
                    LoadAppointmentForUpdate(appointmentId.Value);
                }
                else if (userId.HasValue)
                {
                    // Add mode with preselected patient
                    txtPatientSearch.Enabled = false;
                    txtDoctorSearch.Enabled = true;
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    dtpAppointment.Value = DateTime.Now;
                    dgvPatients.Visible = false;
                    var patient = context.Users.Find(userId.Value);
                    if (patient != null)
                    {
                        selectedPatientId = patient.UserID;
                        lblPatientID.Text = patient.UserID.ToString();
                        lblPatientName.Text = patient.FullName;
                        lblPatientPhone.Text = patient.PhoneNumber;
                        lblPatientDOB.Text = patient.DOB.ToShortDateString();
                    }
                }
                else
                {
                    // Add mode
                    txtPatientSearch.Enabled = true;
                    txtDoctorSearch.Enabled = true;
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    dtpAppointment.Value = DateTime.Now;
                }
                }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPatientSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string text = txtPatientSearch.Text.ToLower();
                dgvPatients.DataSource = allPatients.Where(p => p.UserID.ToString().Contains(text) || p.FullName.ToLower().Contains(text) || p.Phone.Contains(text)).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching patients: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDoctorSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string text = txtDoctorSearch.Text.ToLower();
                dgvDoctors.DataSource = allDoctors.Where(d => d.UserID.ToString().Contains(text) || d.FullName.ToLower().Contains(text) || d.Specialization.ToLower().Contains(text)).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching doctors: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!selectedPatientId.HasValue || !selectedDoctorId.HasValue)
                {
                    MessageBox.Show("Please select both patient and doctor.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DateTime apDate = dtpAppointment.Value;
                (bool Success, string Error) result;
                result = CreateAppointment(selectedPatientId.Value, selectedDoctorId.Value, apDate);
                if (result.Success)
                {
                    MessageBox.Show("A new Appointment is added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnBack.PerformClick();
                }
                else
                {
                    MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving appointment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
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

            dgvDoctors.ClearSelection();
            dgvPatients.ClearSelection();
            dgvDoctors.Refresh();
            dgvPatients.Refresh();
        }

        private void dgvPatients_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting patient: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDoctors_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting doctor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime apDate = dtpAppointment.Value;
                (bool Success, string Error) result;

                if (appointmentId.HasValue)
                {
                    // Update appointment
                    result = UpdateAppointmentDate(appointmentId.Value, apDate);
                    if (result.Success)
                    {
                        MessageBox.Show("Appointment updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating appointment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                var confirm = MessageBox.Show("Cancel this appointment?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var res = CancelAppointment(appointmentId.Value);

                    if (res.Success)
                    {
                        MessageBox.Show("Appointment cancelled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(res.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cancelling appointment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
