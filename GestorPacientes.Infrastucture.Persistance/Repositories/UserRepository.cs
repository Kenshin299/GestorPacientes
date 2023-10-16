using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Domain.Entities;
using GestorPacientes.Infrastucture.Persistance.Contexts;
namespace GestorPacientes.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext aplicationContext) : base(aplicationContext)
        {
            _context = aplicationContext;
        }
    }
}
