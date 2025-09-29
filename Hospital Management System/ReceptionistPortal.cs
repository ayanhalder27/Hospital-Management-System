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
        private int RoleID;
        private string Username;
        public ReceptionistPortal(int userid, int roleid, string username)
        {
            InitializeComponent();
            this.UserID = userid;
            this.RoleID = roleid;
            this.Username = username;
        }
    }
}
