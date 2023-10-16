using GestorPacientes.Core.Application.ViewModels.Appointmens;
using GestorPacientes.Core.Application.ViewModels.Patient;

namespace GestorPacientes.Core.Application.ViewModels.Doctor
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LicenseNumber { get; set; }
        public string Photo { get; set; }
        public List<PatientViewModel> Patients { get; set; }
        public List<AppointmentViewModel> Appointments { get; set; }
    }
}
