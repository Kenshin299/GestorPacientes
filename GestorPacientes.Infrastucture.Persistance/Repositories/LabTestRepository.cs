using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Domain.Entities;
using GestorPacientes.Infrastucture.Persistance.Contexts;

namespace GestorPacientes.Infrastructure.Persistence.Repositories
{
    public class LabTestRepository : GenericRepository<LabTest>, ILabTestRepository
    {
        private readonly ApplicationDbContext _context;
        public LabTestRepository(ApplicationDbContext aplicationContext) : base(aplicationContext)
        {
            _context = aplicationContext;
        }
    }
}
