using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System
{

    public class DashboardCounts
    {
        public int ActivePatients { get; set; }
        public int ActiveEmployees { get; set; }
        public int PendingAppointments { get; set; }
        public int ConfirmedAppointments { get; set; }
        public int TotalAdmins { get; set; }
        public int TotalDoctors { get; set; }
        public int TotalReceptionists { get; set; }
        public int TotalManagers { get; set; }
        public int TotalPharmacists { get; set; }
    }

    internal class DashboardService
    {
        private readonly HospitalContext context;
        public DashboardService()
        {
            this.context = new HospitalContext();
        }

        public DashboardCounts GetDashboardCounts()
        {
            var counts = new DashboardCounts();

            counts.ActivePatients = context.Users.Count(u => u.Role.RoleName == "Patient" && u.Status == true);
            counts.ActiveEmployees = context.Users.Count(u => u.Role.RoleName != "Patient" && u.Status == true);
            counts.TotalAdmins = context.Users.Count(u => u.Role.RoleName == "Admin" && u.Status == true);
            counts.TotalDoctors = context.Users.Count(u => u.Role.RoleName == "Doctor" && u.Status == true);
            counts.TotalReceptionists = context.Users.Count(u => u.Role.RoleName == "Receptionist" && u.Status == true);
            counts.TotalManagers = context.Users.Count(u => u.Role.RoleName == "Manager" && u.Status == true);
            counts.TotalPharmacists = context.Users.Count(u => u.Role.RoleName == "Pharmacist" && u.Status == true);

            counts.PendingAppointments = context.Appointments.Count(a => a.Appoinment_Status == "Pending");
            counts.ConfirmedAppointments = context.Appointments.Count(a => a.Appoinment_Status == "Confirmed");

            return counts;
        }


    }


}
