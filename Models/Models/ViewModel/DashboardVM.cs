namespace Models.Models.ViewModel
{
    public class DashboardVM
    {
        public int TotalDoctors { get; set; }
        public int TotalPatients { get; set; }
        public int TotalDepartments { get; set; }
        public int TotalAppointments { get; set; }
        public int TodayAppointments { get; set; }
        public int PendingAppointments { get; set; }
        public int CompletedAppointments { get; set; }
        public IEnumerable<Appointment> RecentAppointments { get; set; }


    }
}
