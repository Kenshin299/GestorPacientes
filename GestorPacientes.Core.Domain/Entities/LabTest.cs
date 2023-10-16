using GestorPacientes.Core.Domain.Common;

namespace GestorPacientes.Core.Domain.Entities
{
    public class LabTest : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<LabResult> LabResults { get; set; }
    }

}
