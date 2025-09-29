using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class AdminPortal : Form
    {
        private int UserID;
        private int RoleID;
        private string Username;
        private HospitalContext context = new HospitalContext();
        private User correntUser;
        public AdminPortal(int userid, int roleid, string username)
        {
            InitializeComponent();
            this.UserID = userid;
            this.RoleID = roleid;   
            this.Username = username;
            correntUser = context.Users.FirstOrDefault(u => u.UserID == UserID);
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Login_form login_Form = new Login_form();
            login_Form.Show();
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            lbl_profile_user_name.Text = correntUser.FullName;

            if (!string.IsNullOrWhiteSpace(correntUser.Photo) && File.Exists(correntUser.Photo))
            {
                using (var stream = new FileStream(correntUser.Photo, FileMode.Open, FileAccess.Read))
                {
                    //picbox_admin_portal.Image = Image.FromStream(stream);
                }
            }
        }

        private void btn_profile_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserProfileForm userProfileForm = new UserProfileForm(UserID, RoleID, Username);
            userProfileForm.Show();
        }
    }
}
