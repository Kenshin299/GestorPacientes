using GestorPacientes.Core.Application.ViewModels.Patient;

namespace GestorPacientes.Core.Application.ViewModels.Appointmens
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }

        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        public string PatientName { get; set; }
        public string DoctorName { get; set; }

        public PatientViewModel Patient { get; set; }
        public PatientViewModel Doctor { get; set; }

        public List<PatientViewModel> PatientsList { get; set; }
        public List<PatientViewModel> DoctorsList { get; set; }
    }
}
