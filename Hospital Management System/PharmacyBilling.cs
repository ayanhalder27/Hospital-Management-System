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
    public partial class PharmacyBilling : Form
    {
        HospitalContext db = new HospitalContext();
        Dictionary<int, string> medicines;
        float subtotal = 0;
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

        }

        private void txtDrug_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQuantity.Text = "1";
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
                                   u.FullName,
                                   u.PhoneNumber
                               }).FirstOrDefault();

            if(dgvBill.Rows.Count > 0)
            {
                btnClear.PerformClick();
            }

            txtCustomerName.Text = patientInfo.FullName;
            txtContact.Text = patientInfo.PhoneNumber;

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
            if (!dgvBill.Rows[e.RowIndex].Cells[3].Value.ToString().All(char.IsDigit) && int.Parse(dgvBill.Rows[e.RowIndex].Cells[3].Value.ToString()) <= 0){
                MessageBox.Show("Invalid Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            float price = float.Parse(dgvBill.Rows[e.RowIndex].Cells[2].Value.ToString()) * float.Parse(dgvBill.Rows[e.RowIndex].Cells[3].Value.ToString());
            dgvBill.Rows[e.RowIndex].Cells[4].Value = (price).ToString();
            subtotal = subtotal + price - float.Parse(dgvBill.Rows[e.RowIndex].Cells[2].Value.ToString());
            lblSubtotal.Text = subtotal.ToString();
            lblTotal.Text = (subtotal - float.Parse(txtDiscount.Text)).ToString();
        }
    }
}
