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
    public partial class Login_form : Form
    {
        private readonly Check_login_authorization checkLoginAuthorization;
        public Login_form()
        {
            InitializeComponent();
            checkLoginAuthorization = new Check_login_authorization();
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            string userInput = txt_user_ID.Text.Trim();
            string password = txt_user_password.Text.Trim();
            try
            {
                User user = checkLoginAuthorization.Login(userInput, password);
                if (user != null)
                {
                    MessageBox.Show($"Login Successful! Welcome {user.FullName}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    switch (user.RoleID)
                    {
                        case 1:
                            new AdminPortal(user.UserID, user.RoleID, user.FullName).Show();
                            break;
                        case 2:
                            new ManagerPortal(user.UserID, user.RoleID, user.FullName).Show();
                            break;
                        case 3:
                            new ReceptionistPortal(user.UserID, user.RoleID, user.FullName).Show(); 
                            break;
                        case 4:
                            new DoctorPortal(user.UserID, user.RoleID, user.FullName).Show();
                            break;
                        case 5:
                            new PatientPortal(user.UserID, user.RoleID, user.FullName).Show();
                            break;
                        default:
                            MessageBox.Show("Role not recognized!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login failed! Please Check UserID or Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_form_Load(object sender, EventArgs e)
        {

        }
    }
}
