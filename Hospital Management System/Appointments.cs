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
    public partial class Appointments : Form
    {
        public Appointments()
        {
            InitializeComponent();
        }

        private Panel dynamicPanel(int id)
        {
            Panel panel = new Panel();
            panel.SuspendLayout();
            panel.BackColor = Color.FromArgb(25,97, 205, 255);
            panel.Location = new Point(3, 3);
            panel.Name = "panel3";
            panel.Size = new Size(250, 250);
            panel.TabIndex = 0;

            AppointmentPanelDesign appointment = new AppointmentPanelDesign(id);
            appointment.TopLevel = false;
            appointment.FormBorderStyle = FormBorderStyle.None;
            appointment.AutoScroll = true;
            appointment.Dock = DockStyle.Fill;
            panel.Controls.Add(appointment);
            appointment.Show();

            panel.ResumeLayout(false);
            panel.PerformLayout();

            return panel;
        }

        private void Appointments2_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 50; i++)
            {
                flowLayoutPanel1.Controls.Add(dynamicPanel(i));
            }
        }

    }
}
