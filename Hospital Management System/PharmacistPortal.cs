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
        }
    }
}
