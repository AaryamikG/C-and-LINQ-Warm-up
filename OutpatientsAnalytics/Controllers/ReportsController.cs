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
            return Json(_reportsService.GetNoShowRatesByDepartment());
        }

        public IActionResult TopClinicians()
        {
            return Json(_reportsService.GetTopCliniciansThisMonth());
        }

        public IActionResult WaitTimes()
        {
            return Json(_reportsService.GetAverageWaitTimesBySpecialty());
        }
    }
}