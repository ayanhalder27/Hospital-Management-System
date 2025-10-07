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
                            txtQuantity.Text + "×" + txtDrug.Text.Split('~')[1],
                            (float.Parse(txtQuantity.Text)*float.Parse(txtDrug.Text.Split('~')[1])).ToString());
            subtotal += float.Parse(dgvBill.Rows[dgvBill.Rows.Count-1].Cells[3].Value.ToString());
            lblSubtotal.Text = subtotal.ToString();
            lblTotal.Text = (subtotal - int.Parse(txtDiscount.Text)).ToString();
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
    }
}
