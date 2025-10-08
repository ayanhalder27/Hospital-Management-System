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
    public partial class PharmacistPortal : Form
    {
        public PharmacistPortal()
        {
            InitializeComponent();
        }

        private void btnViewMedicine_Click(object sender, EventArgs e)
        {
            ManageMedicines manageMedicinesForm = new ManageMedicines();
            manageMedicinesForm.Show(this);
            this.Hide();
        }

        private void btnSellMedicine_Click(object sender, EventArgs e)
        {
            PharmacyBilling pharmacyBillingForm = new PharmacyBilling();
            pharmacyBillingForm.Show(this);
            this.Hide();
        }

        private void PharmacistPortal_Load(object sender, EventArgs e)
        {
            HospitalContext db = new HospitalContext();
            lblWelcome.Text += db.Users.Where(u=>u.UserID == Login_form.userID).Select(u=>u.FullName).FirstOrDefault();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            UserProfileForm userProfileForm = new UserProfileForm(Login_form.userID);
            userProfileForm.Show(this);
            this.Hide();
        }
    }
}
