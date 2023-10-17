using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Domain.Entities;
using GestorPacientes.Infrastucture.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GestorPacientes.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext aplicationContext) : base(aplicationContext)
        {
            _context = aplicationContext;
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == userName);
        }
    }
}
