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

namespace HospitalManagementSystem
{
    public partial class FormPatients : Form
    {
        public FormPatients()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormPatients_Load(object sender, EventArgs e)
        {
            LoadPatients();
        }
        //Adds a new patient to the database
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
        string.IsNullOrWhiteSpace(txtLastName.Text) ||
        string.IsNullOrWhiteSpace(cmbGender.Text) ||
        string.IsNullOrWhiteSpace(txtContact.Text))
            {
                MessageBox.Show("Please fill in all required fields (First Name, Last Name, Gender, Contact).");
                return;
            }

            using (var context = new HospitalContext())
            {
                var patient = new Patient
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    DateOfBirth = dtpDOB.Value,
                    Gender = cmbGender.SelectedItem?.ToString(),
                    ContactInfo = txtContact.Text,
                    MedicalHistory = txtHistory.Text
                };

                context.Patients.Add(patient);
                context.SaveChanges();
                LoadPatients();
                MessageBox.Show("Patient added.");
                btnClear_Click(sender, e); 
            }
        }
        //Loads all patients into the DataGridView
        private void LoadPatients()
        {
            using (var context = new HospitalContext())
            {
                var patients = context.Patients.ToList();
                dgvPatients.DataSource = patients; // Bind directly to List<Patient>
            }

            
            dgvPatients.Refresh();
        }
        //Populates fields when a patient row is clicked
        private void dgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                var row = dgvPatients.Rows[e.RowIndex];
                txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtLastName.Text = row.Cells["LastName"].Value.ToString();
                dtpDOB.Value = Convert.ToDateTime(row.Cells["DateOfBirth"].Value);
                cmbGender.Text = row.Cells["Gender"].Value.ToString();
                txtContact.Text = row.Cells["ContactInfo"].Value.ToString();
                txtHistory.Text = row.Cells["MedicalHistory"].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvPatients.CurrentRow == null)
            {
                MessageBox.Show("Please select a patient to update.");
                return;
            }

            
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(cmbGender.Text) ||
                string.IsNullOrWhiteSpace(txtContact.Text))
            {
                MessageBox.Show("Please fill in all required fields (First Name, Last Name, Gender, Contact).");
                return;
            }

            int id = Convert.ToInt32(dgvPatients.CurrentRow.Cells["Id"].Value);

            using (var context = new HospitalContext())
            {
                var patient = context.Patients.Find(id);
                if (patient != null)
                {
                    patient.FirstName = txtFirstName.Text;
                    patient.LastName = txtLastName.Text;
                    patient.DateOfBirth = dtpDOB.Value;
                    patient.Gender = cmbGender.Text;
                    patient.ContactInfo = txtContact.Text;
                    patient.MedicalHistory = txtHistory.Text;

                    context.SaveChanges();
                    LoadPatients();
                    MessageBox.Show("Patient updated.");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPatients.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvPatients.CurrentRow.Cells["Id"].Value);
                using (var context = new HospitalContext())
                {
                    var patient = context.Patients.Find(id);
                    if (patient != null)
                    {
                        context.Patients.Remove(patient);
                        context.SaveChanges();
                        LoadPatients();
                        MessageBox.Show("Patient deleted.");
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtContact.Clear();
            txtHistory.Clear();
            cmbGender.SelectedIndex = -1;
            dtpDOB.Value = DateTime.Today;
        }

        private void btnImportHistory_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select a medical history file";
            ofd.Filter = "Text or CSV Files (*.txt;*.csv)|*.txt;*.csv|All Files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string extension = Path.GetExtension(ofd.FileName).ToLower();

                if (extension == ".csv")
                {
                    var lines = File.ReadAllLines(ofd.FileName);
                    if (lines.Length >= 2)
                    {
                        // Assuming 1st line is header and 2nd is data
                        var values = lines[1].Split(',');

                        // Remove surrounding quotes and trim
                        txtFirstName.Text = values[0].Trim('"');
                        txtLastName.Text = values[1].Trim('"');
                        dtpDOB.Value = DateTime.Parse(values[2].Trim('"'));
                        cmbGender.Text = values[3].Trim('"');
                        txtContact.Text = values[4].Trim('"');
                        txtHistory.Text = values[5].Trim('"');
                    }
                }
                else
                {
                    // .txt logic
                    var lines = File.ReadAllLines(ofd.FileName);

                    foreach (var line in lines)
                    {
                        if (line.StartsWith("FirstName:"))
                            txtFirstName.Text = line.Substring("FirstName:".Length).Trim();
                        else if (line.StartsWith("LastName:"))
                            txtLastName.Text = line.Substring("LastName:".Length).Trim();
                        else if (line.StartsWith("DateOfBirth:"))
                            dtpDOB.Value = DateTime.Parse(line.Substring("DateOfBirth:".Length).Trim());
                        else if (line.StartsWith("Gender:"))
                            cmbGender.Text = line.Substring("Gender:".Length).Trim();
                        else if (line.StartsWith("ContactInfo:"))
                            txtContact.Text = line.Substring("ContactInfo:".Length).Trim();
                        else if (line.StartsWith("MedicalHistory:"))
                            txtHistory.Text = line.Substring("MedicalHistory:".Length).Trim();
                    }
                }

                MessageBox.Show("Patient data imported successfully!");
            }
        }
        //Exports selected patient data as plain text file
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Please select a patient to export.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Export Patient Data";
            sfd.Filter = "Text Files (*.txt)|*.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string exportData = $"FirstName: {txtFirstName.Text}\n" +
                                    $"LastName: {txtLastName.Text}\n" +
                                    $"DateOfBirth: {dtpDOB.Value.ToShortDateString()}\n" +
                                    $"Gender: {cmbGender.Text}\n" +
                                    $"ContactInfo: {txtContact.Text}\n" +
                                    $"MedicalHistory: {txtHistory.Text}";

                File.WriteAllText(sfd.FileName, exportData);
                MessageBox.Show("Patient data exported successfully!");
            }
        }
        //Exports selected patient as CSV
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
        string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Please select a patient to export.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Export Selected Patient to CSV";
            sfd.Filter = "CSV Files (*.csv)|*.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
               
                var csvLines = new List<string>();

                
                csvLines.Add("FirstName,LastName,DateOfBirth,Gender,ContactInfo,MedicalHistory");

                
                string line = $"\"{txtFirstName.Text}\",\"{txtLastName.Text}\",\"{dtpDOB.Value:MM/dd/yyyy}\",\"{cmbGender.Text}\",\"{txtContact.Text}\",\"{txtHistory.Text.Replace("\"", "\"\"")}\"";
                csvLines.Add(line);

                // Save the file
                File.WriteAllLines(sfd.FileName, csvLines);

                MessageBox.Show("Selected patient exported to CSV successfully!");
            }
        }
    }
}
