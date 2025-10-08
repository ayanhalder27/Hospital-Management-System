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
    public partial class PharmacyBilling : Form
    {
        HospitalContext db = new HospitalContext();
        Dictionary<int, string> medicines;
        float subtotal = 0;
        int patientUserID = 0;
        public PharmacyBilling()
        {
            InitializeComponent();
        }

        private void PharmacyBilling_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("dd, MMMM yyyy");

            medicines = db.Medicines.Select(m => new
            {
                m.MedicineID,
                m.Medicine_Name,
                m.Price
            }).ToDictionary(m=>m.MedicineID, m=> m.Medicine_Name + "~" + m.Price);

            txtDrug.AutoCompleteCustomSource.AddRange(medicines.Values.ToArray());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvBill.Rows.Add(dgvBill.Rows.Count + 1, 
                            txtDrug.Text.Split('~')[0],
                            txtDrug.Text.Split('~')[1],
                            txtQuantity.Text,
                            (float.Parse(txtQuantity.Text)*float.Parse(txtDrug.Text.Split('~')[1])).ToString());
            subtotal += float.Parse(dgvBill.Rows[dgvBill.Rows.Count-1].Cells[4].Value.ToString());
            lblSubtotal.Text = subtotal.ToString();
            lblTotal.Text = (subtotal - float.Parse(txtDiscount.Text)).ToString();
            txtDrug.AutoCompleteCustomSource.Remove(txtDrug.Text);
            txtDrug.Text = txtQuantity.Text = "";
            txtDrug.Focus();
        }

        private void txtDrug_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQuantity.Text = "1";
                txtQuantity.Focus();
                txtQuantity.SelectAll();
            }
        }

        private void dgvBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0 && dgvBill.Columns[e.ColumnIndex].Name == "Remove")
            {
                txtDrug.AutoCompleteCustomSource.Add(dgvBill.Rows[e.RowIndex].Cells[1].Value + "~" + dgvBill.Rows[e.RowIndex].Cells[2].Value);
                subtotal -= float.Parse(dgvBill.Rows[e.RowIndex].Cells[4].Value.ToString());
                lblSubtotal.Text = subtotal.ToString();
                lblTotal.Text = (subtotal - float.Parse(txtDiscount.Text)).ToString();
                dgvBill.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void dgvBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0 && e.ColumnIndex >= 0)
            {
                dgvBill.BeginEdit(true);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (!txtPrescriptionId.Text.All(char.IsDigit))
            {
                lblPrescriptionWarning.Text = "*Invalid Prescription ID";
                lblPrescriptionWarning.Visible = true;
                return;
            }
            if (string.IsNullOrEmpty(txtPrescriptionId.Text))
            {
                return;
            }
            
            int id = int.Parse(txtPrescriptionId.Text);

            var medicinesList = db.Prescribed_Medicines
                                .Where(p => p.PrescriptionID == id)
                                .Select(p => new
                                {
                                    p.Medicine.Medicine_Name,
                                    p.Medicine.Price
                                }).ToList();
            if (medicinesList.Count == 0)
            {
                lblPrescriptionWarning.Text = "Prescription not found";
                lblPrescriptionWarning.Visible = true;
                return;
            }

            var patientInfo = (from p in db.Prescriptions
                               join a in db.Appointments on p.AppointmentID equals a.AppointmentID
                               join u in db.Users on a.Patient_User_ID equals u.UserID
                               where p.PrescriptionID == id
                               select new
                               {
                                   u.UserID,
                                   u.FullName,
                                   u.PhoneNumber
                               }).FirstOrDefault();
            this.patientUserID = patientInfo.UserID;
            if (dgvBill.Rows.Count > 0)
            {
                btnClear.PerformClick();
            }

            txtCustomerName.Text = patientInfo.FullName;
            txtContact.Text = patientInfo.PhoneNumber;
            txtCustomerName.ReadOnly = txtContact.ReadOnly = true;

            for (int i=0; i<medicinesList.Count; i++)
            {
                dgvBill.Rows.Add(i + 1,
                                medicinesList[i].Medicine_Name,
                                medicinesList[i].Price,
                                "1",
                                medicinesList[i].Price);
                subtotal += (float)medicinesList[i].Price;
                txtDrug.AutoCompleteCustomSource.Remove(medicinesList[i].Medicine_Name + "~" + medicinesList[i].Price);
            }
            lblSubtotal.Text = subtotal.ToString();
            lblTotal.Text = (subtotal - float.Parse(txtDiscount.Text)).ToString();

            lblPrescriptionWarning.Visible = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCustomerName.Text = txtContact.Text = txtDrug.Text = txtQuantity.Text = txtPrescriptionId.Text = "";
            txtCustomerName.ReadOnly = txtContact.ReadOnly = false;
            txtDiscount.Text = "0";
            lblSubtotal.Text = lblTotal.Text = "0.00";
            subtotal = 0;
            for (int i=0; i<dgvBill.Rows.Count; i++)
            {
                txtDrug.AutoCompleteCustomSource.Add(dgvBill.Rows[i].Cells[1].Value + "~" + dgvBill.Rows[i].Cells[2].Value);
            }
            dgvBill.Rows.Clear();
        }

        private void dgvBill_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvBill.Rows[e.RowIndex].Cells[3].Value.ToString().All(char.IsDigit) || int.Parse(dgvBill.Rows[e.RowIndex].Cells[3].Value.ToString()) <= 0){
                MessageBox.Show("Invalid Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            float price = float.Parse(dgvBill.Rows[e.RowIndex].Cells[2].Value.ToString()) * float.Parse(dgvBill.Rows[e.RowIndex].Cells[3].Value.ToString());
            dgvBill.Rows[e.RowIndex].Cells[4].Value = (price).ToString();
            subtotal = 0;
            for(int i=0; i<dgvBill.Rows.Count; i++)
            {
                subtotal += float.Parse(dgvBill.Rows[i].Cells[4].Value.ToString());
            }
            lblSubtotal.Text = subtotal.ToString();
            lblTotal.Text = (subtotal - float.Parse(txtDiscount.Text)).ToString();
        }

        private void txtDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            bool isInt = int.TryParse(txtDiscount.Text, out int discount);
            bool isFloat = float.TryParse(txtDiscount.Text, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out float discount2);
            if (!isInt && !isFloat)
            {
                lblDiscountWarning.Visible = true;
                return;
            }
            if (string.IsNullOrEmpty(txtDiscount.Text))
            {
                lblDiscountWarning.Visible = false;
                return;
            }

            float total = subtotal - float.Parse(txtDiscount.Text);
            if (total > 0)
            {
                lblTotal.Text = total.ToString();
            }
            else
            {
                txtDiscount.Text = lblSubtotal.Text;
                lblTotal.Text = "0.00";
            }
            lblDiscountWarning.Visible = false;
        }

        private async void txtDiscount_Enter(object sender, EventArgs e)
        {
            await Task.Delay(10);
            txtDiscount.SelectAll();
        }

        private void txtPrescriptionId_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLoad.PerformClick();
            }
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.PerformClick();
            }
        }

        private void btnSavePrint_Click(object sender, EventArgs e)
        {
            if(dgvBill.Rows.Count == 0)
            {
                MessageBox.Show("No items in the bill", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Pharmacy_Billing pb = new Pharmacy_Billing();
            pb.Pharmacists_User_ID = Login_form.userID;
            if (this.patientUserID != 0)
            {
                pb.Patient_User_ID = this.patientUserID;
            }
            pb.CustomerName= txtCustomerName.Text;
            pb.PhoneNumber= txtContact.Text;
            pb.Date= DateTime.Now;
            pb.Subtotal= float.Parse(lblSubtotal.Text);
            pb.Discount= float.Parse(txtDiscount.Text);
            pb.Total= float.Parse(lblTotal.Text);
            db.Pharmacy_Billing.Add(pb);
            db.SaveChanges();
            for(int i=0; i<dgvBill.Rows.Count; i++)
            {
                Medicine_Billing mb = new Medicine_Billing();
                mb.Pharmacy_Billing_ID = pb.Pharmacy_Billing_ID;
                mb.MedicineID = medicines.FirstOrDefault(x=> x.Value == dgvBill.Rows[i].Cells[1].Value + "~" + dgvBill.Rows[i].Cells[2].Value).Key;
                mb.Quantity = int.Parse(dgvBill.Rows[i].Cells[3].Value.ToString());
                db.Medicine_Billing.Add(mb);
            }
            db.SaveChanges();
            MessageBox.Show("Billing Successfull");

            InvoiceData invoiceData = new InvoiceData();
            invoiceData.InvoiceId = pb.Pharmacy_Billing_ID;
            invoiceData.CustomerName = pb.CustomerName;
            invoiceData.CustomerContact = pb.PhoneNumber;
            invoiceData.Subtotal = pb.Subtotal;
            invoiceData.Discount = pb.Discount;
            invoiceData.Total = pb.Total;

            for (int i=0; i<dgvBill.Rows.Count; i++)
            {
                InvoiceItem item = new InvoiceItem();
                item.DrugName = dgvBill.Rows[i].Cells[1].Value.ToString();
                item.PricePerUnit = double.Parse(dgvBill.Rows[i].Cells[2].Value.ToString());
                item.Quantity = int.Parse(dgvBill.Rows[i].Cells[3].Value.ToString());
                invoiceData.Items.Add(item);
            }


            string fileName = "#" + pb.Pharmacy_Billing_ID +  ".Date-" + DateTime.Now.ToString("dd-mm-yyyy") + ".pdf";
            string filePath = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName, "Documents", fileName);

            InvoiceGenerator.GenerateInvoice(invoiceData, filePath);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Owner.Refresh();
            this.Close();
        }
    }
}
