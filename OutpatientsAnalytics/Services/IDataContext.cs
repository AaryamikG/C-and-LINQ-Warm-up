using OutpatientsAnalytics.Models;

namespace OutpatientsAnalytics.Services
{
    public interface IDataContext
    {
        IQueryable<Appointment> Appointments { get; }
        IQueryable<Clinician> Clinicians { get; }
        IQueryable<Department> Departments { get; }
    }
}