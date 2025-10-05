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
        public AppointmentPanelDesign(int id, string name, DateTime date, string number, string status)
        {
            InitializeComponent();
            lblID.Text += id;
            lblName.Text = name;
            lblDate.Text = date.ToString("dd, MMMM yyyy");
            lblNumber.Text = number;
            if (status == "Completed")
            {
                this.pbStatus.Image = global::Hospital_Management_System.Properties.Resources.Done;
                btnPrescribe.Enabled = false;
            }
        }

        private void btnPrescribe_Click(object sender, EventArgs e)
        {
            Prescribe prescribe = new Prescribe(int.Parse(lblID.Text.Replace("#", "")));
            prescribe.Show(Appointments.thisPage);
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lblID.Text.Replace("#", ""));
        }
    }
}
