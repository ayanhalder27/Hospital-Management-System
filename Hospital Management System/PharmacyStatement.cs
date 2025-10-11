using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class PharmacyStatement : Form
    {
        HospitalContext db = new HospitalContext();
        public PharmacyStatement()
        {
            InitializeComponent();
        }

        private async void PharmacyStatement_Load(object sender, EventArgs e)
        {
            await Task.Delay(100);

            reloadData();
        }

        private void reloadData()
        {
            dgvStatement.DataSource = db.Pharmacy_Billing.Join(db.Users, pb => pb.Pharmacists_User_ID, u => u.UserID, (pb, u) => new
            {
                pb.Pharmacy_Billing_ID,
                pb.CustomerName,
                pb.PhoneNumber,
                biller = u.FullName,
                pb.Date,
                pb.Subtotal,
                pb.Discount,
                pb.Total,
                pb.Invoice
            }).ToList();

            lblTotalProfitValue.Text = Math.Round(db.Pharmacy_Billing.Sum(pb => pb.Total), 2).ToString();
        }

        private void dgvStatement_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dgvStatement.Columns[8].Index && e.RowIndex >= 0)
            {
                string filePath = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName, "Documents", dgvStatement.Rows[e.RowIndex].Cells[8].Value.ToString());
                Process.Start(filePath);
            }
        }

        private void comboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            if (comboFilter.Text == "All")
            {
                reloadData();
            }
            else if (comboFilter.Text == "This Month")
            {
                dgvStatement.DataSource = db.Pharmacy_Billing
                    .Join(db.Users,
                        pb => pb.Pharmacists_User_ID,
                        u => u.UserID,
                        (pb, u) => new
                        {
                            pb.Pharmacy_Billing_ID,
                            pb.CustomerName,
                            pb.PhoneNumber,
                            biller = u.FullName,
                            pb.Date,
                            pb.Subtotal,
                            pb.Discount,
                            pb.Total,
                            pb.Invoice
                        })
                    .Where(x => x.Date.Month == currentMonth && x.Date.Year == currentYear)
                    .ToList();
            }
            else if(comboFilter.Text == "This Year")
            {
                                dgvStatement.DataSource = db.Pharmacy_Billing
                    .Join(db.Users,
                        pb => pb.Pharmacists_User_ID,
                        u => u.UserID,
                        (pb, u) => new
                        {
                            pb.Pharmacy_Billing_ID,
                            pb.CustomerName,
                            pb.PhoneNumber,
                            biller = u.FullName,
                            pb.Date,
                            pb.Subtotal,
                            pb.Discount,
                            pb.Total,
                            pb.Invoice
                        })
                    .Where(x => x.Date.Year == currentYear)
                    .ToList();
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
