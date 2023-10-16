using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Domain.Entities;
using GestorPacientes.Infrastucture.Persistance.Contexts;

namespace GestorPacientes.Infrastructure.Persistence.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        private readonly ApplicationDbContext _context;
        public PatientRepository(ApplicationDbContext aplicationContext) : base(aplicationContext)
        {
            _context = aplicationContext;
        }
    }
}
