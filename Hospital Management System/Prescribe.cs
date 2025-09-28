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
    public partial class Prescribe : Form
    {
        public Prescribe()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Prescribe_Load(object sender, EventArgs e)
        {
            //HospitalModel db = new HospitalModel();
            //AutoCompleteStringCollection medicines = new AutoCompleteStringCollection();
            //medicines.AddRange(db.Medicines.Select(m => m.Medicine_Name).ToArray());

            //guna2TextBox1.AutoCompleteCustomSource = medicines;
        }
    }
}
