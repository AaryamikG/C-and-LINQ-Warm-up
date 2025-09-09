namespace OutpatientsAnalytics.Models.ViewModels
{
    public class NoShowRateViewModel
    {
        public string DepartmentName { get; set; } = string.Empty;
        public double NoShowRate { get; set; }
        public int TotalAppointments { get; set; }
        public int NoShowCount { get; set; }
    }
}