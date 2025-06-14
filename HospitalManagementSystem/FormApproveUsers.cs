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

namespace HospitalManagementSystem
{
    public partial class FormApproveUsers : Form
    {
        public FormApproveUsers()
        {
            InitializeComponent();
        }
        //On form load, fetch users waiting for approval
        private void FormApproveUsers_Load(object sender, EventArgs e)
        {
            LoadPendingUsers();
        }
        //Loads all users whose "Approved" field is false (not yet approved)
        private void LoadPendingUsers()
        {
            var pending = MongoHelper.UsersCollection.Find(u => u.Approved == false).ToList();
            dgvPending.DataSource = pending;
        }
        //Approves the selected user
        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvPending.CurrentRow != null)
            {
                string username = dgvPending.CurrentRow.Cells["Username"].Value.ToString();
                //Create MongoDB filter and update statement
                var filter = Builders<User>.Filter.Eq(u => u.Username, username);
                var update = Builders<User>.Update.Set(u => u.Approved, true);
                //Update in MongoDB
                MongoHelper.UsersCollection.UpdateOne(filter, update);

                MessageBox.Show($"User '{username}' approved.");
                LoadPendingUsers();
            }
        }
        //Rejects the selected user from the database
        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvPending.CurrentRow != null)
            {
                string username = dgvPending.CurrentRow.Cells["Username"].Value.ToString();

                var filter = Builders<User>.Filter.Eq(u => u.Username, username);
                MongoHelper.UsersCollection.DeleteOne(filter);

                MessageBox.Show($"User '{username}' rejected and removed.");
                LoadPendingUsers();
            }
        }
        //When a row is clicked, show the selected username in the label
        private void dgvPending_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPending.Rows[e.RowIndex];
                string selectedUsername = row.Cells["Username"].Value.ToString();
                lblSelectedUser.Text = $"Selected user: {selectedUsername}";
            }
        }
    }
}
