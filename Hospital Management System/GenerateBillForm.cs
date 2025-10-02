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
    public partial class GenerateBillForm : Form
    {
        private HospitalContext context = new HospitalContext();
        private int billId;

        public GenerateBillForm(int billId)
        {
            InitializeComponent();
            this.billId = billId;
        }
    }
}
