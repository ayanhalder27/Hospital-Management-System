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
    public partial class GenerateBillForm : Form
    {
        private HospitalContext context = new HospitalContext();
        private int billId;
        private BillingDto billingDto;

        public GenerateBillForm(int billId)
        {
            InitializeComponent();
            this.billId = billId;
        }
        public (bool Success, string Error) PayBill(int billId, decimal paidAmount, string paymentMethod, out string invoicePath)
        {
            invoicePath = null;
            try
            {
                var bill = context.Billings.FirstOrDefault(b => b.BillID == billId);
                if (bill == null) return (false, "Bill not found.");

                decimal amount = bill.Amount;

                if (paidAmount < amount)
                    return (false, "Paid amount is less than required. Full payment required.");

                // Update billing status
                bill.Status = "Paid";
                context.SaveChanges();

                // Update appointment billing/status
                var ap = context.Appointments.FirstOrDefault(a => a.AppointmentID == bill.AppointmentID);
                if (ap != null)
                {
                    ap.Billing_Status = "Paid";
                    ap.Appoinment_Status = "Confirmed";
                    context.SaveChanges();
                }

                // Generate invoice PDF — here we call a helper that uses iTextSharp (below)
                // invoicePath = InvoiceService.GenerateInvoicePdf(...);
                // For now we'll leave invoice generation to a helper method you can call from UI
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, "Error during payment: " + ex.Message);
            }
        }

        private List<BillingDto> GetBills(string search = null, string status = null)
        {
            try
            {
                var query = from b in context.Billings
                            join a in context.Appointments on b.AppointmentID equals a.AppointmentID
                            join p in context.Users on a.Patient_User_ID equals p.UserID
                            join d in context.Users on a.Doctor_User_ID equals d.UserID
                            where b.Status == "Unpaid" || b.Status == "Paid"
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

                return query.OrderByDescending(x => x.BillDate).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bills: " + ex.Message);
                return new List<BillingDto>();
            }
        }

        private void GenerateBillForm_Load(object sender, EventArgs e)
        {
            var bills = GetBills(null);
            billingDto = bills.FirstOrDefault(b => b.BillID == billId);
            if (billingDto == null) { MessageBox.Show("Bill not found."); Close(); return; }

            lblBillID.Text = billingDto.BillID.ToString();
            lblAppointmentID.Text = billingDto.AppointmentID.ToString();
            lblPatientName.Text = billingDto.PatientName;
            lblDoctorName.Text = billingDto.DoctorName;
            lblFee.Text = billingDto.Amount.ToString();
            lblBillDate.Text = billingDto.BillDate.ToString("dd-MMM-yyyy");
        }

        private void rdoCash_CheckedChanged(object sender, EventArgs e)
        {
            pnlCash.Visible = rdoCash.Checked;
            pnlCard.Visible = rdoCard.Checked;
        }


    }
}
