﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.DataAccess
{
    public class Appointment
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }

        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }  // navigation
    }
}
