using Microsoft.AspNetCore.Mvc;
using OutpatientsAnalytics.Services;

namespace OutpatientsAnalytics.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ReportsService _reportsService;

        public ReportsController(ReportsService reportsService)
        {
            _reportsService = reportsService;
        }

        public IActionResult NoShowRates()
        {
            // TODO: Students implement this action
            // Call _reportsService.GetNoShowRatesByDepartment()
            // Return Json result
            throw new NotImplementedException("Students need to implement this action");
        }

        public IActionResult TopClinicians()
        {
            // TODO: Students implement this action  
            // Call _reportsService.GetTopCliniciansThisMonth()
            // Return Json result
            throw new NotImplementedException("Students need to implement this action");
        }

        public IActionResult WaitTimes()
        {
            // TODO: Students implement this action
            // Call _reportsService.GetAverageWaitTimesBySpecialty()
            // Return Json result
            throw new NotImplementedException("Students need to implement this action");
        }
    }
}