using GestorPacientes.Core.Application.ViewModels.Appointmens;
using GestorPacientes.Core.Application.ViewModels.Doctor;

namespace GestorPacientes.Core.Application.ViewModels.Patient
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsSmoker { get; set; }
        public string Allergies { get; set; }
        public string Photo { get; set; }
        public int DoctorId { get; set; }
        public DoctorViewModel PrimaryDoctor { get; set; }
        public List<AppointmentViewModel> Appointments { get; set; }
    }
}
