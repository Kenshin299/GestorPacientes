using GestorPacientes.Core.Application.ViewModels.User;

namespace GestorPacientes.Core.Application.Interfaces.Services
{
    public interface IUserService : IGenericService<SaveUserViewModel, UserViewModel>
    {
    }
}
