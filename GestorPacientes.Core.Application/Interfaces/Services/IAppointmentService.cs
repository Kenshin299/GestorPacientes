using GestorPacientes.Core.Application.ViewModels.Appointmens;

namespace GestorPacientes.Core.Application.Interfaces.Services
{
    public interface IAppointmentService : IGenericService<SaveAppointmentViewModel, AppointmentViewModel>
    {
    }
}
