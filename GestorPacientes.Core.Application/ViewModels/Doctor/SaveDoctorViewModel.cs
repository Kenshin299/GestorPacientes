using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Application.ViewModels.Doctor
{
    public class SaveDoctorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del médico es requerido.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El apellido del médico es requerido.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El correo electrónico del médico es requerido.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El número de teléfono del médico es requerido.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "El número de licencia del médico es requerido.")]
        public string LicenseNumber { get; set; }

        public string Photo { get; set; }
    }
}
