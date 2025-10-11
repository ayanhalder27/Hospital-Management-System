using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class AppointmentDetails : Form
    {
        HospitalContext db = new HospitalContext();
        int patientID;
        public AppointmentDetails(int id)
        {
            InitializeComponent();
            this.patientID = id;
        }

        private void loadPatientData()
        {
            var patient = db.Users.Where(u => u.UserID == patientID)
                             .Select(u=> new
                             {
                                 u.FullName,
                                 u.DOB,
                                 u.Gender,
                                 u.PhoneNumber
                             }).FirstOrDefault();

            lblName.Text = patient.FullName;
            lblPatientID.Text += patientID;
            lblAgeValue.Text = (DateTime.Now.Year - patient.DOB.Year).ToString();
            lblGenderValue.Text = patient.Gender;
            lblContactValue.Text = patient.PhoneNumber;
        }

        private async void AppointmentDetails_Load(object sender, EventArgs e)
        {
            await Task.Delay(100);
            loadPatientData();
            var result = db.Prescriptions.Join(db.Appointments, p=>p.AppointmentID, a=>a.AppointmentID, (p,a)=> new { p, a })
                                         .Join(db.Users, pa=>pa.a.Doctor_User_ID, u=>u.UserID, (pa,u)=> new {pa.p,pa.a,u})
                                         .Where(x => x.a.Patient_User_ID == patientID)
                                         .Select(x => new
                                            {
                                                x.p.PrescriptionID,
                                                x.u.FullName,
                                                x.p.Date,
                                                x.p.Prescription_File
                                            }).ToList();
            dgvPrescriptions.DataSource = result;
            this.Owner.Hide();
        }

        private void dgvPrescriptions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dgvPrescriptions.Columns["Prescription"].Index && e.RowIndex >= 0)
            {
                string filePath = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName, "Documents", dgvPrescriptions.Rows[e.RowIndex].Cells[3].Value.ToString());
                Process.Start(filePath);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
