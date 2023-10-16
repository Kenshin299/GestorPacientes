using GestorPacientes.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Domain.Entities
{
    public class LabTest : BaseEntity
    {
        public int LabTestId { get; set; }
        public string Name { get; set; }
        public ICollection<LabResult> LabResults { get; set; }
    }
}
