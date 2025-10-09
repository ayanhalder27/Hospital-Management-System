using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        public (bool Success, string Error) PayBill(int billId, decimal paidAmount)
        {
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
                            where b.Status == "Unpaid"
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bill: " + ex.Message);
                Close();
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            this.Owner.Refresh();
            this.Close();
        }

        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPaidAmount.Text))
                {
                    txtChangeAmount.Text = "";
                    return;
                }
                if (decimal.TryParse(txtPaidAmount.Text, out decimal paid))
                {
                    if (paid < 0)
                    {
                        MessageBox.Show("Paid amount must be a positive value.",
                                        "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPaidAmount.Clear();
                        txtChangeAmount.Text = "";
                        return;
                    }

                    decimal change = paid - billingDto.Amount;
                    txtChangeAmount.Text = change >= 0 ? change.ToString() : "";
                }
                else
                {
                    MessageBox.Show("Please enter a valid decimal number.",
                                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPaidAmount.Clear();
                    txtChangeAmount.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPaidAmount.Clear();
                txtChangeAmount.Text = "";
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            try
            {
                decimal paid = 0;
                if (!decimal.TryParse(txtPaidAmount.Text, out paid))
                {
                    MessageBox.Show("Enter valid paid amount.");
                    return;
                }
                var (ok, err) = PayBill(billId, paid);
                if (!ok)
                {
                    MessageBox.Show(err);
                    return;
                }

                // Ask user where to save invoice
                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF Files|*.pdf";
                    sfd.FileName = $"Invoice_{billingDto.BillID}_{billingDto.PatientName}.pdf"; // default name

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        string path = InvoiceService.GenerateInvoicePdf(
                            billingDto.BillID,
                            billingDto.PatientName,
                            billingDto.DoctorName,
                            billingDto.Amount,
                            "Cash",
                            paid,
                            paid - billingDto.Amount,
                            DateTime.Now,
                            sfd.FileName // pass full file path
                        );

                        MessageBox.Show("Payment saved and invoice generated: " + path);
                        System.Diagnostics.Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
                    }
                }

                DialogResult = DialogResult.OK;
                btnBack.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing payment: " + ex.Message);
            }
        }
    }
}
