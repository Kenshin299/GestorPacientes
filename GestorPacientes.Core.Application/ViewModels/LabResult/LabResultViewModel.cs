using GestorPacientes.Core.Application.ViewModels.LabTest;

namespace GestorPacientes.Core.Application.ViewModels.LabResult
{
    public class LabResultViewModel
    {
        public int Id { get; set; }
        public int LabTestId { get; set; }
        public int PatientId { get; set; }
        public string Result { get; set; }
        public bool IsCompleted { get; set; }
        public LabTestViewModel LabTest { get; set; }
    }
}
