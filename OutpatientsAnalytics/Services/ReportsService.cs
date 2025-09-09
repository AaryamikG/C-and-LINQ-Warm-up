using OutpatientsAnalytics.Models.ViewModels;

namespace OutpatientsAnalytics.Services
{
    public class ReportsService
    {
        private readonly IDataContext _dataContext;

        public ReportsService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<NoShowRateViewModel> GetNoShowRatesByDepartment()
        {
            // TODO: Implement LINQ query
            // Group by Department.Name
            // Count NoShow vs total appointments
            // Return department name + no-show rate
            throw new NotImplementedException("Students need to implement this LINQ query");
        }

        public List<TopClinicianViewModel> GetTopCliniciansThisMonth()
        {
            // TODO: Implement LINQ query  
            // Filter to completed appointments in current month
            // Group by clinician
            // Return top 3 with highest completed count
            throw new NotImplementedException("Students need to implement this LINQ query");
        }

        public List<WaitTimeViewModel> GetAverageWaitTimesBySpecialty()
        {
            // TODO: Implement LINQ query
            // Compute difference between ScheduledStartUtc and BookedUtc
            // Group by clinician specialty
            // Return specialty + average wait in days
            throw new NotImplementedException("Students need to implement this LINQ query");
        }
    }
}