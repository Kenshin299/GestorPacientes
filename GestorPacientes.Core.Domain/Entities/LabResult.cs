using GestorPacientes.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Domain.Entities
{
    public class LabResult : BaseEntity
    {
        public int LabResultId { get; set; }
        public int LabTestId { get; set; }
        public int PatientId { get; set; }
        public string Result { get; set; }
        public bool IsCompleted { get; set; }
        public LabTest Test { get; set; }
    }
}
