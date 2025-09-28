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
    public partial class AppointmentPanelDesign : Form
    {
        public AppointmentPanelDesign(int id)
        {
            InitializeComponent();
            lblID.Text += id;
        }

        private void btnPrescribe_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lblID.Text.Replace("#",""));
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lblID.Text.Replace("#", ""));
        }
    }
}
