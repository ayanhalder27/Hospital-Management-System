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
    public partial class ReceptionistPortal : Form
    {
        private int UserID;
        public ReceptionistPortal(int userid)
        {
            InitializeComponent();
            this.UserID = userid;
        }
    }
}
