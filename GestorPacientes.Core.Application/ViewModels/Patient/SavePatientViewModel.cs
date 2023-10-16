using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.ViewModels.Patient
{
    public class SavePatientViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del paciente es requerido.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El apellido del paciente es requerido.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El número de teléfono del paciente es requerido.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "La dirección del paciente es requerida.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "El número de identidad del paciente es requerido.")]
        public string IdentityNumber { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento del paciente es requerida.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Indique si el paciente es fumador o no.")]
        public bool IsSmoker { get; set; }

        [Required(ErrorMessage = "Las alergias del paciente son requeridas.")]
        public string Allergies { get; set; }

        public string Photo { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un médico.")]
        public int DoctorId { get; set; }
    }
}
