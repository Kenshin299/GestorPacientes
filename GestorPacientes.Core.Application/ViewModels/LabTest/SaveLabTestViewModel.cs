using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.ViewModels.LabTest
{
    public class SaveLabTestViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la prueba de laboratorio es requerido.")]
        public string Name { get; set; }
    }
}
