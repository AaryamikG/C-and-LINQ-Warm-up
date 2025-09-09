using OutpatientsAnalytics.Models;

namespace OutpatientsAnalytics.Services
{
    public class InMemoryDataContext : IDataContext
    {
        private readonly List<Department> _departments;
        private readonly List<Clinician> _clinicians;
        private readonly List<Appointment> _appointments;

        public InMemoryDataContext()
        {
            _departments = CreateSampleDepartments();
            _clinicians = CreateSampleClinicians();
            _appointments = CreateSampleAppointments();
        }

        public IQueryable<Appointment> Appointments => _appointments.AsQueryable();
        public IQueryable<Clinician> Clinicians => _clinicians.AsQueryable();
        public IQueryable<Department> Departments => _departments.AsQueryable();

        private List<Department> CreateSampleDepartments()
        {
            return new List<Department>
            {
                new Department { DepartmentId = 1, Name = "Cardiology" },
                new Department { DepartmentId = 2, Name = "Dermatology" },
                new Department { DepartmentId = 3, Name = "Orthopedics" },
                new Department { DepartmentId = 4, Name = "Neurology" }
            };
        }

        private List<Clinician> CreateSampleClinicians()
        {
            return new List<Clinician>
            {
                new Clinician { ClinicianId = 1, FullName = "Dr. Sarah Johnson", Specialty = "Cardiology" },
                new Clinician { ClinicianId = 2, FullName = "Dr. Michael Chen", Specialty = "Dermatology" },
                new Clinician { ClinicianId = 3, FullName = "Dr. Emma Wilson", Specialty = "Orthopedics" },
                new Clinician { ClinicianId = 4, FullName = "Dr. James Smith", Specialty = "Neurology" },
                new Clinician { ClinicianId = 5, FullName = "Dr. Lisa Brown", Specialty = "Cardiology" },
                new Clinician { ClinicianId = 6, FullName = "Dr. David Lee", Specialty = "Orthopedics" }
            };
        }

        private List<Appointment> CreateSampleAppointments()
        {
            var baseDate = new DateTime(2024, 1, 15, 0, 0, 0, DateTimeKind.Utc);
            
            return new List<Appointment>
            {
                // Cardiology appointments
                new Appointment { AppointmentId = 1, ClinicianId = 1, DepartmentId = 1, PatientId = 101, BookedUtc = baseDate.AddDays(-14), ScheduledStartUtc = baseDate.AddDays(-7), Outcome = Outcome.Completed },
                new Appointment { AppointmentId = 2, ClinicianId = 1, DepartmentId = 1, PatientId = 102, BookedUtc = baseDate.AddDays(-21), ScheduledStartUtc = baseDate.AddDays(-5), Outcome = Outcome.NoShow },
                new Appointment { AppointmentId = 3, ClinicianId = 5, DepartmentId = 1, PatientId = 103, BookedUtc = baseDate.AddDays(-10), ScheduledStartUtc = baseDate.AddDays(-3), Outcome = Outcome.Completed },
                new Appointment { AppointmentId = 4, ClinicianId = 5, DepartmentId = 1, PatientId = 104, BookedUtc = baseDate.AddDays(-28), ScheduledStartUtc = baseDate.AddDays(-2), Outcome = Outcome.Completed },
                
                // Dermatology appointments
                new Appointment { AppointmentId = 5, ClinicianId = 2, DepartmentId = 2, PatientId = 105, BookedUtc = baseDate.AddDays(-30), ScheduledStartUtc = baseDate.AddDays(-1), Outcome = Outcome.Completed },
                new Appointment { AppointmentId = 6, ClinicianId = 2, DepartmentId = 2, PatientId = 106, BookedUtc = baseDate.AddDays(-7), ScheduledStartUtc = baseDate, Outcome = Outcome.NoShow },
                new Appointment { AppointmentId = 7, ClinicianId = 2, DepartmentId = 2, PatientId = 107, BookedUtc = baseDate.AddDays(-14), ScheduledStartUtc = baseDate.AddDays(1), Outcome = Outcome.Cancelled },
                
                // Orthopedics appointments
                new Appointment { AppointmentId = 8, ClinicianId = 3, DepartmentId = 3, PatientId = 108, BookedUtc = baseDate.AddDays(-35), ScheduledStartUtc = baseDate.AddDays(2), Outcome = Outcome.Completed },
                new Appointment { AppointmentId = 9, ClinicianId = 3, DepartmentId = 3, PatientId = 109, BookedUtc = baseDate.AddDays(-42), ScheduledStartUtc = baseDate.AddDays(3), Outcome = Outcome.NoShow },
                new Appointment { AppointmentId = 10, ClinicianId = 6, DepartmentId = 3, PatientId = 110, BookedUtc = baseDate.AddDays(-21), ScheduledStartUtc = baseDate.AddDays(4), Outcome = Outcome.Completed },
                
                // Neurology appointments
                new Appointment { AppointmentId = 11, ClinicianId = 4, DepartmentId = 4, PatientId = 111, BookedUtc = baseDate.AddDays(-28), ScheduledStartUtc = baseDate.AddDays(5), Outcome = Outcome.Completed },
                new Appointment { AppointmentId = 12, ClinicianId = 4, DepartmentId = 4, PatientId = 112, BookedUtc = baseDate.AddDays(-35), ScheduledStartUtc = baseDate.AddDays(6), Outcome = Outcome.Completed },
                new Appointment { AppointmentId = 13, ClinicianId = 4, DepartmentId = 4, PatientId = 113, BookedUtc = baseDate.AddDays(-14), ScheduledStartUtc = baseDate.AddDays(7), Outcome = Outcome.NoShow },
                
                // More recent appointments for "this month" testing
                new Appointment { AppointmentId = 14, ClinicianId = 1, DepartmentId = 1, PatientId = 114, BookedUtc = DateTime.UtcNow.AddDays(-5), ScheduledStartUtc = DateTime.UtcNow.AddDays(-2), Outcome = Outcome.Completed },
                new Appointment { AppointmentId = 15, ClinicianId = 2, DepartmentId = 2, PatientId = 115, BookedUtc = DateTime.UtcNow.AddDays(-8), ScheduledStartUtc = DateTime.UtcNow.AddDays(-1), Outcome = Outcome.Completed },
                new Appointment { AppointmentId = 16, ClinicianId = 3, DepartmentId = 3, PatientId = 116, BookedUtc = DateTime.UtcNow.AddDays(-12), ScheduledStartUtc = DateTime.UtcNow, Outcome = Outcome.Completed }
            };
        }
    }
}