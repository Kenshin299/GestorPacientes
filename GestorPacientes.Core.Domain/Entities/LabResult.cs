using GestorPacientes.Core.Domain.Common;

namespace GestorPacientes.Core.Domain.Entities
{
    public class LabResult : BaseEntity
    {
        public int LabTestId { get; set; }
        public int PatientId { get; set; }
        public string Result { get; set; }
        public bool IsCompleted { get; set; }
        public LabTest Test { get; set; }
    }
}
