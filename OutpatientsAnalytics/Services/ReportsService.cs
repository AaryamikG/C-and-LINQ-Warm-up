using OutpatientsAnalytics.Models;
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
            return (from appointment in _dataContext.Appointments
                    join department in _dataContext.Departments
                        on appointment.DepartmentId equals department.DepartmentId
                    group appointment by department.Name into departmentGroup
                    select new NoShowRateViewModel
                    {
                        DepartmentName = departmentGroup.Key,
                        TotalAppointments = departmentGroup.Count(),
                        NoShowCount = departmentGroup.Count(a => a.Outcome == Outcome.NoShow),
                        NoShowRate = departmentGroup.Count(a => a.Outcome == Outcome.NoShow) / (double)departmentGroup.Count()
                    })
                    .ToList();
        }

        public List<TopClinicianViewModel> GetTopCliniciansThisMonth()
        {
            var now = DateTime.UtcNow;

            return (from appointment in _dataContext.Appointments
                    where appointment.Outcome == Outcome.Completed
                        && appointment.ScheduledStartUtc.Month == now.Month
                        && appointment.ScheduledStartUtc.Year == now.Year
                    join clinician in _dataContext.Clinicians
                        on appointment.ClinicianId equals clinician.ClinicianId
                    group appointment by clinician into clinicianGroup
                    orderby clinicianGroup.Count() descending
                    select new TopClinicianViewModel
                    {
                        ClinicianName = clinicianGroup.Key.FullName,
                        Specialty = clinicianGroup.Key.Specialty,
                        CompletedAppointments = clinicianGroup.Count()
                    })
                    .Take(3)
                    .ToList();
        }

        public List<WaitTimeViewModel> GetAverageWaitTimesBySpecialty()
        {
            return (from appointment in _dataContext.Appointments
                    join clinician in _dataContext.Clinicians
                        on appointment.ClinicianId equals clinician.ClinicianId
                    group (appointment.ScheduledStartUtc - appointment.BookedUtc).TotalDays
                        by clinician.Specialty into specialtyGroup
                    select new WaitTimeViewModel
                    {
                        Specialty = specialtyGroup.Key,
                        AverageWaitTimeDays = specialtyGroup.Average()
                    })
                    .ToList();
        }
    }
}