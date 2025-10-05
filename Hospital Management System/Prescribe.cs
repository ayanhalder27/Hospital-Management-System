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
        int appointmentID, prescriptionID;
        public Prescribe(int id)
        {
            InitializeComponent();
            this.appointmentID = id;
            var patient = db.Appointments.Where(a => a.AppointmentID == id).Join(db.Users, a=>a.Patient_User_ID, u=> u.UserID, (a,u)=> new
            {
                u.FullName,
                u.DOB,
                u.Gender
            }).FirstOrDefault();

            lblName.Text = patient.FullName;
            lblAge.Text = (DateTime.Now.Year - patient.DOB.Year) + " Years";
            lblSex.Text = patient.Gender;

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
            
            this.Owner.Hide();
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
            if(dgvMedicines.Rows.Count <=1 && dgvTest.Rows.Count <=1)
            {
                MessageBox.Show("Please add at least one medicine or test to prescribe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            savePrescription();
            prescribe();
            this.Owner.Show();
            ((Appointments)this.Owner).loadAppointments("Confirmed");
            this.Close();
        }

        private void savePrescription()
        {
            var prescription = new Prescription
            {
                AppointmentID = this.appointmentID,
                Date = DateTime.Now
            };

            db.Prescriptions.Add(prescription);
            db.SaveChanges();
            prescriptionID = prescription.PrescriptionID;

            List<string> testNames = new List<string>();

            for (int i = 0; i < dgvTest.Rows.Count; i++)
            {
                testNames.Add(dgvTest.Rows[i].Cells[0].Value.ToString());
            }
            var testMap = db.MedicalTests.Where(t => testNames.Contains(t.TestName))
                .ToDictionary(t => t.TestName, t => t.TestID);
            foreach (string name in testNames)
            {
                if (testMap.TryGetValue(name, out int testID))
                {
                    db.Prescribed_Tests.Add(new Prescribed_Tests
                    {
                        PrescriptionID = prescription.PrescriptionID,
                        TestID = testID
                    });
                }
            }

            List<string> medicineNames = new List<string>();
            for (int i = 0; i < dgvMedicines.Rows.Count; i++)
            {
                medicineNames.Add(dgvMedicines.Rows[i].Cells[0].Value.ToString().Split('~')[0]);
            }
            var medicineMap = db.Medicines.Where(m => medicineNames.Contains(m.Medicine_Name))
                .ToDictionary(m => m.Medicine_Name, m => m.MedicineID);
            foreach (string name in medicineNames)
            {
                if (medicineMap.TryGetValue(name, out int medicineID))
                {
                    int i = 0;
                    db.Prescribed_Medicines.Add(new Prescribed_Medicines
                    {
                        PrescriptionID = prescription.PrescriptionID,
                        MedicineID = medicineID,
                        Dosage = dgvMedicines.Rows[i].Cells[1].Value.ToString(),
                        Instructions = dgvMedicines.Rows[i].Cells[2].Value.ToString(),
                        Feed_Days = dgvMedicines.Rows[i].Cells[3].Value.ToString()
                    });
                    i++;
                }
            }

            Appointment a = db.Appointments.Find(appointmentID);
            a.Appoinment_Status = "Completed";

            db.SaveChanges();

            MessageBox.Show("Prescription Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void prescribe()
        {

            List testList = new List(List.ORDERED,10f);
            testList.IndentationLeft = 20f;
            for(int i=0; i<dgvTest.Rows.Count; i++)
            {
                testList.Add(new ListItem(dgvTest.Rows[i].Cells[0].Value.ToString()));
            }

            List<string> medicineList = new List<string>();
            for (int i=0; i<dgvMedicines.Rows.Count; i++)
            {
                medicineList.Add(dgvMedicines.Rows[i].Cells[0].Value + "~" +
                                 dgvMedicines.Rows[i].Cells[1].Value + "~" +
                                 dgvMedicines.Rows[i].Cells[2].Value + "~" +
                                 dgvMedicines.Rows[i].Cells[3].Value);
            }
            PrescriptionGenerator.CreatePrescription(prescriptionID,lblName.Text, lblAge.Text, lblSex.Text,testList , medicineList);

        }

        private void dgvTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvTest.Columns[e.ColumnIndex].Name == "remove")
            {
                dgvTest.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void dgvMedicines_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if( e.RowIndex >= 0 && dgvMedicines.Columns[e.ColumnIndex].Name == "removeDrug")
            {
                dgvMedicines.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
