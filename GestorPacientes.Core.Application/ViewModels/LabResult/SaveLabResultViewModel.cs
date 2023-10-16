using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.ViewModels.LabResult
{
    public class SaveLabResultViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La prueba de laboratorio es requerida.")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una prueba de laboratorio válida.")]
        public int LabTestId { get; set; }

        [Required(ErrorMessage = "El paciente es requerido.")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un paciente válido.")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "El resultado del laboratorio es requerido.")]
        [StringLength(500, ErrorMessage = "El resultado del laboratorio no puede exceder los 500 caracteres.")]
        public string Result { get; set; }

        [Required(ErrorMessage = "El estado de completado es requerido.")]
        public bool IsCompleted { get; set; }
    }
}
