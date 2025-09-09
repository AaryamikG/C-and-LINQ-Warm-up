namespace OutpatientsAnalytics.Models
{
    public class Clinician
    {
        public int ClinicianId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
    }
}