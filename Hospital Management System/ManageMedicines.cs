using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class ManageMedicines : Form
    {
        HospitalContext db = new HospitalContext();
        private int selectedRow;
        public ManageMedicines()
        {
            InitializeComponent();
        }

        private async void ManageMedicines_Load(object sender, EventArgs e)
        {
            await Task.Delay(100);
            reloadData();
        }

        private void reloadData()
        {
            dgvMedicines.DataSource = db.Medicines.Select(m => new
            {
                m.MedicineID,
                m.Medicine_Name,
                m.Generic_Name,
                m.Formulation,
                m.Price,
                m.Stock,
            }).ToList();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtSearch.Text))
            {
                string search = txtSearch.Text;
                dgvMedicines.DataSource = db.Medicines.Where(m => m.MedicineID.ToString() == search || m.Medicine_Name.Contains(search) || m.Generic_Name.Contains(search) || m.Formulation.Contains(search) || m.Price.ToString() == search || m.Stock.ToString() == search)
                                                      .Select(m => new
                                                      {
                                                          m.MedicineID,
                                                          m.Medicine_Name,
                                                          m.Generic_Name,
                                                          m.Formulation,
                                                          m.Price,
                                                          m.Stock
                                                      }).ToList();
            }
            else if (string.IsNullOrEmpty(txtSearch.Text))
            {
                reloadData();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblId.Text = lblName.Text = lblGenericName.Text = lblFormulation.Text = "---";
            txtPrice.Text = txtStock.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var medicine = db.Medicines.Find(int.Parse(lblId.Text));
            medicine.Price = double.Parse(txtPrice.Text);
            medicine.Stock = int.Parse(txtStock.Text);
            db.SaveChanges();
            MessageBox.Show("Medicine updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reloadData();
            dgvMedicines.ClearSelection();
            dgvMedicines.Rows[selectedRow].Selected = true;
            btnClear.PerformClick();
        }

        private void dgvMedicines_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            lblId.Text = dgvMedicines.Rows[e.RowIndex].Cells[0].Value.ToString();
            lblName.Text = dgvMedicines.Rows[e.RowIndex].Cells[1].Value.ToString();
            lblGenericName.Text = dgvMedicines.Rows[e.RowIndex].Cells[2].Value.ToString();
            lblFormulation.Text = dgvMedicines.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPrice.Text = dgvMedicines.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtStock.Text = dgvMedicines.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilter.Text == "All")
            {
                reloadData();
            }
            else if (cmbFilter.Text == "Stock Available")
            {
                dgvMedicines.DataSource = db.Medicines.Where(m => m.Stock > 0).Select(m => new
                {
                    m.MedicineID,
                    m.Medicine_Name,
                    m.Generic_Name,
                    m.Formulation,
                    m.Price,
                    m.Stock,
                }).ToList();
            }
            else if (cmbFilter.Text == "Out of Stock")
            {
                dgvMedicines.DataSource = db.Medicines.Where(m => m.Stock == 0).Select(m => new
                {
                    m.MedicineID,
                    m.Medicine_Name,
                    m.Generic_Name,
                    m.Formulation,
                    m.Price,
                    m.Stock,
                }).ToList();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Owner.Refresh();
            this.Close();
        }
    }
}
