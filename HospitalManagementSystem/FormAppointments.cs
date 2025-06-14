// FormAppointments.cs - full code for managing appointments
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using HospitalManagementSystem.DataAccess;
using Microsoft.AspNet.SignalR.Client;
using System.Net;
using System.Threading.Tasks;

namespace HospitalManagementSystem
{
    public partial class FormAppointments : Form
    {
        HubConnection connection;
        IHubProxy hub;
        public FormAppointments()
        {
            InitializeComponent();
        }

        private async void FormAppointments_Load(object sender, EventArgs e)
        {
            
            LoadPatients();
            LoadAppointments();
            cmbStatus.Items.AddRange(new string[] { "Scheduled", "Completed", "Cancelled" });
            cmbStatus.SelectedIndex = 0;

            //Setup SignalR connection
            connection = new HubConnection("http://localhost:8080");
            hub = connection.CreateHubProxy("AppointmentHub");

            //When a broadcast is received, reload the data grid
            hub.On<string>("receiveAppointment", (message) =>
            {
                
                LoadAppointments();
            });

            try
            {
                await connection.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SignalR connection failed: " + ex.Message);
            }
        }
        private void LoadPatients()
        {
            using (var context = new HospitalContext())
            {
                var patients = context.Patients
                    .Select(p => new { p.Id, FullName = p.FirstName + " " + p.LastName })
                    .ToList();
                cmbPatient.DataSource = patients;
                cmbPatient.DisplayMember = "FullName";
                cmbPatient.ValueMember = "Id";
                cmbPatient.SelectedIndex = -1;
            }
        }

        private void LoadAppointments()
        {
            Task.Run(() =>
            {
                using (var context = new HospitalContext())
                {
                    var appointments = context.Appointments
                        .Include(a => a.Patient)
                        .Select(a => new
                        {
                            a.Id,
                            a.DoctorName,
                            a.AppointmentDate,
                            a.Status,
                            a.Reason,
                            PatientName = a.Patient.FirstName + " " + a.Patient.LastName
                        })
                        .ToList();

                    if (dgvAppointments.InvokeRequired)
                    {
                        dgvAppointments.Invoke(new Action(() =>
                        {
                            dgvAppointments.DataSource = appointments;
                        }));
                    }
                    else
                    {
                        dgvAppointments.DataSource = appointments;
                    }
                }
            });
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDoctorName.Text) ||
                string.IsNullOrWhiteSpace(txtReason.Text) ||
                cmbPatient.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            using (var context = new HospitalContext())
            {
                var appointment = new Appointment
                {
                    DoctorName = txtDoctorName.Text,
                    AppointmentDate = dtpAppointmentDate.Value,
                    Status = cmbStatus.Text,
                    Reason = txtReason.Text,
                    PatientId = (int)cmbPatient.SelectedValue
                };

                context.Appointments.Add(appointment);
                context.SaveChanges();
                if (hub != null)
                {
                    hub.Invoke("SendAppointmentUpdate").Wait();
                }
            }

            LoadAppointments();
            ClearFields();
            MessageBox.Show("Appointment added.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvAppointments.CurrentRow.Cells["Id"].Value);

                using (var context = new HospitalContext())
                {
                    var appointment = context.Appointments.Find(id);
                    if (appointment != null)
                    {
                        // Validate required fields
                        if (string.IsNullOrWhiteSpace(txtDoctorName.Text) ||
                            string.IsNullOrWhiteSpace(txtReason.Text) ||
                            cmbStatus.SelectedItem == null ||
                            cmbPatient.SelectedValue == null)
                        {
                            MessageBox.Show("Please fill in all fields and select a patient.");
                            return;
                        }

                        appointment.DoctorName = txtDoctorName.Text;
                        appointment.AppointmentDate = dtpAppointmentDate.Value;
                        appointment.Status = cmbStatus.Text;
                        appointment.Reason = txtReason.Text;
                        appointment.PatientId = Convert.ToInt32(cmbPatient.SelectedValue);

                        context.SaveChanges();

                        // SignalR update (non-async way with exception handling)
                        if (hub != null)
                        {
                            try
                            {
                                hub.Invoke("SendAppointmentUpdate").Wait(); // blocks until done
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Failed to notify SignalR hub: " + ex.Message);
                            }
                        }

                        LoadAppointments();
                        ClearFields();
                        MessageBox.Show("Appointment updated.");
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvAppointments.CurrentRow.Cells["Id"].Value);

                using (var context = new HospitalContext())
                {
                    var appointment = context.Appointments.Find(id);
                    if (appointment != null)
                    {
                        context.Appointments.Remove(appointment);
                        context.SaveChanges();
                    }
                }

                LoadAppointments();
                ClearFields();
                MessageBox.Show("Appointment deleted.");
            }
            if (hub != null)
            {
                hub.Invoke("SendAppointmentUpdate").Wait();
            }
        }

        private void dgvAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvAppointments.Rows[e.RowIndex];

                txtDoctorName.Text = row.Cells["DoctorName"].Value?.ToString();
                dtpAppointmentDate.Value = Convert.ToDateTime(row.Cells["AppointmentDate"].Value);
                cmbStatus.Text = row.Cells["Status"].Value?.ToString();
                txtReason.Text = row.Cells["Reason"].Value?.ToString();

                string fullName = row.Cells["PatientName"].Value?.ToString();

                for (int i = 0; i < cmbPatient.Items.Count; i++)
                {
                    var item = cmbPatient.Items[i];
                    var type = item.GetType();
                    var fullNameProperty = type.GetProperty("FullName");

                    if (fullNameProperty != null)
                    {
                        string value = fullNameProperty.GetValue(item)?.ToString();
                        if (value == fullName)
                        {
                            cmbPatient.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            if (hub != null)
            {
                hub.Invoke("SendAppointmentUpdate").Wait();
            }
        }

        private void ClearFields()
        {
            txtDoctorName.Clear();
            dtpAppointmentDate.Value = DateTime.Now;
            txtReason.Clear();
            cmbStatus.SelectedIndex = 0;
            cmbPatient.SelectedIndex = -1;
        }
    }
}
