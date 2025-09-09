namespace OutpatientsAnalytics.Models.ViewModels
{
    public class TopClinicianViewModel
    {
        public string ClinicianName { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
        public int CompletedAppointments { get; set; }
    }
}