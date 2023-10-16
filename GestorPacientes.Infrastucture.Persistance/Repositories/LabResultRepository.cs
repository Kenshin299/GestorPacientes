using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Domain.Entities;
using GestorPacientes.Infrastucture.Persistance.Contexts;

namespace GestorPacientes.Infrastructure.Persistence.Repositories
{
    public class LabResultRepository : GenericRepository<LabResult>, ILabResultRepository
    {
        private readonly ApplicationDbContext _context;
        public LabResultRepository(ApplicationDbContext aplicationContext) : base(aplicationContext)
        {
            _context = aplicationContext;
        }
    }
}
