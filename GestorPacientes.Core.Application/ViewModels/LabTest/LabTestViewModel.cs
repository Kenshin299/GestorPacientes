using GestorPacientes.Core.Application.ViewModels.LabResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.ViewModels.LabTest
{
    public class LabTestViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<LabResultViewModel> LabResults { get; set; }
    }
}
