using GestorPacientes.Core.Application.ViewModels.Doctor;
using GestorPacientes.Core.Application.ViewModels.Patient;
using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Application.ViewModels.Appointmens
{
    public class SaveAppointmentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha y hora de la cita es requerida.")]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "El motivo de la cita es requerido.")]
        [StringLength(500, ErrorMessage = "El motivo de la cita no puede exceder los 500 caracteres.")]
        public string Reason { get; set; }

        [Required(ErrorMessage = "El estado de la cita es requerido.")]
        public string Status { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un paciente.")]
        public int PatientId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un médico.")]
        public int DoctorId { get; set; }

        public List<SavePatientViewModel> Patients { get; set; }
        public List<SaveDoctorViewModel> Doctors { get; set; }
    }
}
