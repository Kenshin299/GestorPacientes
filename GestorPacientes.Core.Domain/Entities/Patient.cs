using GestorPacientes.Core.Domain.Common;

namespace GestorPacientes.Core.Domain.Entities
{
    public class Patient : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsSmoker { get; set; }
        public string Allergies { get; set; }
        public string? Photo { get; set; }
        public int DoctorId { get; set; }
        public Doctor PrimaryDoctor { get; set; }
        public ICollection<Appointment> Appointments { get; set; } // Add this navigation property
    }
}
