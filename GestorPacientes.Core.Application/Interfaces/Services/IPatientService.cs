using GestorPacientes.Core.Application.ViewModels.Patient;

namespace GestorPacientes.Core.Application.Interfaces.Services
{
    public interface IPatientService : IGenericService<SavePatientViewModel, PatientViewModel>
    {
    }
}
