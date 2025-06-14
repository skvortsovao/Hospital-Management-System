using System.Data.Entity;
using HospitalManagementSystem;
using HospitalManagementSystem.DataAccess;

public class HospitalContext : DbContext
{
    public HospitalContext() : base("name=HospitalDB") { }

    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Patient> Patients { get; set; }

}