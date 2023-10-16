using GestorPacientes.Core.Domain.Common;

namespace GestorPacientes.Core.Domain.Entities
{
    public class Doctor : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LicenseNumber { get; set; }
        public string? Photo { get; set; }
        public ICollection<Patient> Patients { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
