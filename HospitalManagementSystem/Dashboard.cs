using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementSystem
{
    public partial class Dashboard : Form
    {
        // Store role and username for permission control and display
        private string _role;
        private string _username;
        private int _patientId;
        // Constructor receives username and role from login
        public Dashboard(string username, string role, int patientId)
        {
            InitializeComponent();
            _role = role;
            _username = username;
            _patientId = patientId;
        }
        

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Display a welcome message with user info
            lblWelcome.Text = $"Welcome, {_username} ({_role})";

            // Hide/show features by role
            //Patient — hide all admin/nurse/doctor buttons
            if (_role == "patient")
            {
                btnManagePatients.Visible = false;
                btnInventory.Visible = false;
                btnAnalytics.Visible = false;
                btnApproveUsers.Visible = false;
            }
            //Nurse — hide analytics and user approval
            else if (_role == "nurse")
            {
                btnApproveUsers.Visible = false;
                btnAnalytics.Visible = false;
            }
            //Doctor — hide inventory and approval
            else if (_role == "doctor")
            {
                btnApproveUsers.Visible = false;
                btnInventory.Visible = false;
            }
            // admin sees everything

        }
        //Open user approval form (admin only)
        private void btnApproveUsers_Click(object sender, EventArgs e)
        {
            FormApproveUsers approveForm = new FormApproveUsers();
            approveForm.ShowDialog();
        }
        //Open patient management (admin/nurse/doctor)
        private void btnManagePatients_Click(object sender, EventArgs e)
        {
            FormPatients formPatients = new FormPatients();
            formPatients.ShowDialog();
        }
        //Open appointment management form
        private void btnAppointments_Click(object sender, EventArgs e)
        {
            FormAppointments appointmentsForm = new FormAppointments(_role, _patientId);
            appointmentsForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Close current form
            this.Hide();

            // Show the login form again
            Form1 loginForm = new Form1(); 
            loginForm.Show();
        }
    }
}
