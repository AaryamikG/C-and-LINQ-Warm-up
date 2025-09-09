namespace OutpatientsAnalytics.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int ClinicianId { get; set; }
        public int DepartmentId { get; set; }
        public int PatientId { get; set; }
        public DateTime ScheduledStartUtc { get; set; }
        public DateTime BookedUtc { get; set; }
        public Outcome Outcome { get; set; }
    }
}