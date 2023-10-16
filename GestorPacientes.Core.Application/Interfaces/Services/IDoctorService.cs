using GestorPacientes.Core.Application.ViewModels.Doctor;

namespace GestorPacientes.Core.Application.Interfaces.Services
{
    public interface IDoctorService : IGenericService<SaveDoctorViewModel, DoctorViewModel>
    {
    }
}
