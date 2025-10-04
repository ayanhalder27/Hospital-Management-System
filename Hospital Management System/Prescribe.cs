using iTextSharp.text;
using iTextSharp.text.pdf;
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
    public partial class Prescribe : Form
    {
        HospitalContext db = new HospitalContext();
        public Prescribe()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Prescribe_Load(object sender, EventArgs e)
        {
            lblDate.Text += DateTime.Now.ToString("dd MMMM yyyy");

            AutoCompleteStringCollection medicines = new AutoCompleteStringCollection();
            medicines.AddRange(db.Medicines.Select(m => m.Medicine_Name + "~" + m.Formulation).ToArray());
            txtMedicine.AutoCompleteCustomSource = medicines;

            AutoCompleteStringCollection tests = new AutoCompleteStringCollection();
            tests.AddRange(db.MedicalTests.Select(t => t.TestName).ToArray());
            txtTest.AutoCompleteCustomSource = tests;

        }

        private void txtTest_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                dgvTest.Rows.Add(txtTest.Text);
                txtTest.Clear();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvMedicines.Rows.Add(txtMedicine.Text,cbDosage.Text,cbInstructions.Text,txtFeedDays.Text + " days");
            txtMedicine.Clear();
            cbDosage.SelectedIndex = -1;
            cbInstructions.SelectedIndex = -1;
            txtFeedDays.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvTest.Rows.Clear();
            dgvMedicines.Rows.Clear();
            txtTest.Clear();
            txtMedicine.Clear();
            cbDosage.SelectedIndex = -1;
            cbInstructions.SelectedIndex = -1;
            txtFeedDays.Clear();
        }

        private void btnSavePrescription_Click(object sender, EventArgs e)
        {
            prescribe();
        }

        private void prescribe()
        {
            string filepath = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName, "Documents", "Prescription.pdf");
            Document doc = new Document(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(doc, new System.IO.FileStream(filepath, System.IO.FileMode.Create));
            doc.Open();
            Paragraph header = new Paragraph("Hospital Management System.");
            doc.Add(header);
            doc.Close();
            Process.Start(filepath);
        }



    }
}
