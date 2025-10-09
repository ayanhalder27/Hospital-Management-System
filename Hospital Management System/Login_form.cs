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
        public static int userID;
        private readonly HospitalContext context = new HospitalContext();
        public Login_form()
        {
            InitializeComponent();
        }

        public User Login(string userInput, string password)
        {
            try
            {
                var user = context.Users.FirstOrDefault(u => (u.UserID.ToString() == userInput || u.Username == userInput || u.Email == userInput || u.PhoneNumber == userInput) && u.Password == password);
                if (user != null && user.Status == true)
                {
                    return user;
                }
                else
                {
                    MessageBox.Show("Login failed! Please Check UserID or Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while logging in: " + ex.Message);
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string userInput = txt_user_ID.Text.Trim();
            string password = txt_user_password.Text.Trim();
            try
            {
                var user = Login(userInput, password);
                if (user != null)
                {
                    userID = user.UserID;
                    switch (user.RoleID)
                    {
                        case 1:
                            new AdminPortal(user.UserID).Show(this);
                            break;
                        case 2:
                            new ManagerPortal(user.UserID).Show(this);
                            break;
                        case 3:
                            new ReceptionistPortal(user.UserID).Show(this); 
                            break;
                        case 4:
                            new DoctorPortal(user.UserID).Show(this);
                            break;
                        case 5:
                            new PatientPortal(user.UserID).Show(this);
                            break;
                        case 7:
                            new PharmacistPortal(user.UserID).Show(this);
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

        private void lbl_clean_Click(object sender, EventArgs e)
        {
            txt_user_ID.Clear();
            txt_user_password.Clear();
        }

        private bool passwordVisible = false;
        private void guna2CirclePictureBox1_Click_1(object sender, EventArgs e)
        {

            if (passwordVisible)
            {
                txt_user_password.UseSystemPasswordChar = true;
                guna2CirclePictureBox1.Image = Properties.Resources.invisible1;
                passwordVisible = false;

            }
            else
            {
                txt_user_password.UseSystemPasswordChar = false;
                guna2CirclePictureBox1.Image = Properties.Resources.visible;
                passwordVisible = true;
            }

        }

        private void txt_user_password_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btn_login.PerformClick();
            }
        }
    }
}
