using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.LabTest;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Services
{
    public class LabTestService : ILabTestService
    {
        private readonly ILabTestRepository _labTestRepository;

        public LabTestService(ILabTestRepository labTestRepository)
        {
            _labTestRepository = labTestRepository;
        }

        public async Task Add(SaveLabTestViewModel vm)
        {
            var labTest = new LabTest
            {
                Name = vm.Name,
            };

            await _labTestRepository.AddAsync(labTest);
        }

        public async Task Delete(int id)
        {
            var labTest = await _labTestRepository.GetByIdAsync(id);
            if (labTest != null)
            {
                await _labTestRepository.DeleteAsync(labTest);
            }
        }

        public async Task<List<LabTestViewModel>> GetAllViewModel()
        {
            var labTests = await _labTestRepository.GetAllAsync();
            var labTestViewModels = new List<LabTestViewModel>();

            foreach (var labTest in labTests)
            {
                labTestViewModels.Add(new LabTestViewModel
                {
                    Id = labTest.Id,
                    Name = labTest.Name,
                });
            }

            return labTestViewModels;
        }

        public async Task<SaveLabTestViewModel> GetByIdSaveViewModel(int id)
        {
            var labTest = await _labTestRepository.GetByIdAsync(id);
            if (labTest != null)
            {
                return new SaveLabTestViewModel
                {
                    Id = labTest.Id,
                    Name = labTest.Name,
                };
            }

            return null;
        }

        public async Task Update(SaveLabTestViewModel vm)
        {
            var labTest = await _labTestRepository.GetByIdAsync(vm.Id);

            if (labTest != null)
            {
                labTest.Name = vm.Name;

                await _labTestRepository.UpdateAsync(labTest);
            }
        }
    }
}
