using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HospitalManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnShowLogin_Click(object sender, EventArgs e)//Show Register Panel
        {
            panelLogin.Visible = true;
            panelRegister.Visible = false;
            btnShowLogin.Visible = false;
            btnShowRegister.Visible = false;
        }

        private void btnShowRegister_Click(object sender, EventArgs e)//Registration Logic
        {
            panelLogin.Visible = false;
            panelRegister.Visible = true;
            btnShowLogin.Visible = false;
            btnShowRegister.Visible = false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtRegisterUsername.Text.Trim();// Gather user input
            string password = txtRegisterPassword.Text;
            string role = cmbRole.SelectedItem?.ToString();
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password); // Hash the password securely

            bool isAutoApproved = role == "patient"; // Everyone else needs admin approval

            var newUser = new User
            {
                Username = username,
                PasswordHash = passwordHash,
                Role = role,
                Approved = isAutoApproved
            };

            MongoHelper.UsersCollection.InsertOne(newUser); // Insert user to MongoDB

            if (!isAutoApproved)
            {
                MessageBox.Show("Your account is under review. An admin must approve your access.");
            }
            else
            {
                MessageBox.Show("Registration successful!");
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string inputUsername = txtLoginUsername.Text.Trim();
            string inputPassword = txtLoginPassword.Text;

            var user = MongoHelper.UsersCollection.Find(u => u.Username == inputUsername).FirstOrDefault();// Search for user in MongoDB

            if (user == null)
            {
                MessageBox.Show("User not found.");
                return;
            }

            bool match = BCrypt.Net.BCrypt.Verify(inputPassword, user.PasswordHash);// Verify password using bcrypt

            if (!match)
            {
                MessageBox.Show("Invalid password.");
                return;
            }

            if (!user.Approved)  // Check if user is approved
            {
                MessageBox.Show("Your request is still pending or was denied.");
                return;
            }

            MessageBox.Show($"Welcome {user.Role}, {user.Username}!");
            Dashboard dashboard = new Dashboard(user.Username, user.Role);
            dashboard.Show();
            this.Hide();// hide login window
        }

        private void btnBackFromLogin_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = false;
            btnShowLogin.Visible = true;
            btnShowRegister.Visible = true;
        }

        private void btnBackFromRegister_Click(object sender, EventArgs e)
        {
            panelRegister.Visible = false;
            btnShowLogin.Visible = true;
            btnShowRegister.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
