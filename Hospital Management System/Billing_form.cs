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
    public partial class Billing_form : Form
    {
        private int userID;
        private HospitalContext _ctx = new HospitalContext();
        private User currentUser;

        public Billing_form(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        public List<BillingDto> GetBills(string search = null,
            int? patientId = null, int? doctorId = null, DateTime? date = null, string status = null)
        {
            try
            {
                var q = _ctx.Billing.AsQueryable();

                if (patientId.HasValue)
                    q = q.Where(b => b.Appointment.Patient_User_ID == patientId.Value);

                if (doctorId.HasValue)
                    q = q.Where(b => b.Appointment.Doctor_User_ID == doctorId.Value);

                if (date.HasValue)
                {
                    var d = date.Value.Date;
                    q = q.Where(b => System.Data.Entity.DbFunctions.TruncateTime(b.BillDate) == d);
                }

                if (!string.IsNullOrWhiteSpace(status))
                    q = q.Where(b => b.Status == status);

                if (!string.IsNullOrWhiteSpace(search))
                {
                    string s = search.Trim().ToLower();
                    q = q.Where(b =>
                        b.BillID.ToString().Contains(s) ||
                        b.Appointment.Patient.FullName.ToLower().Contains(s) ||
                        b.Appointment.Patient.PhoneNumber.ToLower().Contains(s) ||
                        b.Appointment.Doctor.FullName.ToLower().Contains(s)
                    );
                }

                var list = q.Select(b => new BillingDto
                {
                    BillID = b.BillID,
                    AppointmentID = b.AppointmentID,
                    PatientName = b.Appointment.Patient.FullName,
                    PatientPhone = b.Appointment.Patient.PhoneNumber,
                    DoctorName = b.Appointment.Doctor.FullName,
                    BillDate = b.BillDate,
                    Amount = (decimal)b.Amount,
                    Status = b.Status
                }).OrderByDescending(x => x.BillDate).ToList();

                return list;
            }
            catch
            {
                throw;
            }
        }


        private void pic_back_button_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminPortal adminPortal = new AdminPortal(userID);
            adminPortal.Show();
        }
    }
    public class BillingDto
    {
        public int BillID { get; set; }
        public int AppointmentID { get; set; }
        public string PatientName { get; set; }
        public string PatientPhone { get; set; }
        public string DoctorName { get; set; }
        public DateTime BillDate { get; set; }
        public decimal Amount { get; set; } // doctor visit fee
        public string Status { get; set; }  // Paid/Unpaid
    }
}
