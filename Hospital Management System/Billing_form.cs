using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class Billing_form : Form
    {
        private int userID;
        private HospitalContext context = new HospitalContext();
        private User currentUser;

        public Billing_form(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        private void LoadBills()
        {
            dgvBills.DataSource = GetBills(txtSearch.Text, null);
        }

        private List<BillingDto> GetBills(string search = null, string status = null)
        {
            try
            {
                var query = from b in context.Billings
                            join a in context.Appointments on b.AppointmentID equals a.AppointmentID
                            join p in context.Users on a.Patient_User_ID equals p.UserID
                            join d in context.Users on a.Doctor_User_ID equals d.UserID
                            where  b.Status == "Unpaid" && a.Appoinment_Status == "Pending"
                            select new BillingDto
                            {
                                BillID = b.BillID,
                                AppointmentID = b.AppointmentID,
                                PatientName = p.FullName,
                                PatientPhone = p.PhoneNumber,
                                DoctorName = d.FullName,
                                BillDate = b.BillDate,
                                Amount = (decimal)b.Amount,
                                Status = b.Status
                            };

                // filter by status if provided
                if (!string.IsNullOrWhiteSpace(status))
                {
                    query = query.Where(x => x.Status == status);
                }

                // filter by search text if provided
                if (!string.IsNullOrWhiteSpace(search))
                {
                    string s = search.Trim().ToLower();
                    query = query.Where(x =>
                        x.BillID.ToString().Contains(s) ||
                        x.PatientName.ToLower().Contains(s) ||
                        x.PatientPhone.ToLower().Contains(s) ||
                        x.DoctorName.ToLower().Contains(s)
                    );
                }

                return query.OrderByDescending(x => x.BillID).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bills: " + ex.Message);
                return new List<BillingDto>();
            }
        }

        private void pic_back_button_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Owner.Refresh();
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadBills();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBills();
            txtSearch.Clear();           
            dgvBills.Refresh();          
            dgvBills.ClearSelection();
        }

        private void Billing_form_Load(object sender, EventArgs e)
        {
            LoadBills();
        }

        private void dgvBills_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int billId = (int)dgvBills.Rows[e.RowIndex].Cells["BillID"].Value;
            var form = new GenerateBillForm(billId);
            form.Show(this);
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
