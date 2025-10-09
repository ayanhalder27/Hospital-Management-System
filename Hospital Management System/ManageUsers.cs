using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class ManageUsers : Form
    {
        private HospitalContext context = new HospitalContext();
        private readonly UserService userService;
        private User currentUser;
        private readonly bool isPatientView;
        public ManageUsers(bool isPatientView, int userid)
        {
            InitializeComponent();
            this.isPatientView = isPatientView;
            userService = new UserService();
            currentUser = context.Users.FirstOrDefault(u => u.UserID == userid);
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRoles();
                LoadUsers();
                if (isPatientView)
                {
                    lbl_manage_user_type.Text = "Manage Patients";
                    cmbRoles.Visible = false;
                }
                else
                {
                    lbl_manage_user_type.Text = "Manage Users";
                    cmbRoles.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadRoles()
        {
            var roles = userService.GetRoles();
            cmbRoles.DataSource = roles;
            cmbRoles.DisplayMember = "RoleName";
            cmbRoles.ValueMember = "RoleID";
            cmbRoles.SelectedIndex = -1;

            cmbRoles.Visible = !isPatientView;
            lblRoleFilter.Visible = !isPatientView;
        }

        private void LoadUsers()
        {
            dgvUsers.DataSource = userService.GetUsers(isPatientView);
        }

        private void ApplyFilters()
        {
            try
            {
                int? selectedRoleId = cmbRoles.SelectedValue as int?;
                string searchText = txtSearch.Text;

                dgvUsers.DataSource = userService.GetUsers(isPatientView, selectedRoleId, searchText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error applying filters: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btn_add_new_user_Click(object sender, EventArgs e)
        {
            try
            {
                if (isPatientView)
                {
                    var addPatientForm = new AddUserForm(true);
                    addPatientForm.Show(this);
                }
                else
                {
                    var addEmployeeForm = new AddUserForm(false);
                    addEmployeeForm.Show(this);
                }
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening add user form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbRoles.SelectedIndex = -1;
            LoadUsers();
            dgvUsers.ClearSelection();
            dgvUsers.Refresh();
        }

        private void pic_back_button_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void dgvUsers_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // make sure it’s not a header row
                {
                    int userId = (int)dgvUsers.Rows[e.RowIndex].Cells["UserID"].Value;

                    var form = new UpdateDeleteUser(userId);
                    form.Show(this);
                    this.Hide();

                    LoadUsers(); // Refresh DataGridView after update/delete
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening user details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
