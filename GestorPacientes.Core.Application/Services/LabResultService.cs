using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.LabResult;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Services
{
    public class LabResultService : ILabResultService
    {
        private readonly ILabResultRepository _labResultRepository;

        public LabResultService(ILabResultRepository labResultRepository)
        {
            _labResultRepository = labResultRepository;
        }

        public async Task Add(SaveLabResultViewModel vm)
        {
            var labResult = new LabResult
            {
                LabTestId = vm.LabTestId,
                PatientId = vm.PatientId,
                Result = vm.Result,
                IsCompleted = vm.IsCompleted,
            };

            await _labResultRepository.AddAsync(labResult);
        }

        public async Task Delete(int id)
        {
            var labResult = await _labResultRepository.GetByIdAsync(id);
            if (labResult != null)
            {
                await _labResultRepository.DeleteAsync(labResult);
            }
        }

        public async Task<List<LabResultViewModel>> GetAllViewModel()
        {
            var labResults = await _labResultRepository.GetAllAsync();
            var labResultViewModels = new List<LabResultViewModel>();

            foreach (var labResult in labResults)
            {
                labResultViewModels.Add(new LabResultViewModel
                {
                    Id = labResult.Id,
                    LabTestId = labResult.LabTestId,
                    PatientId = labResult.PatientId,
                    Result = labResult.Result,
                    IsCompleted = labResult.IsCompleted,
                });
            }

            return labResultViewModels;
        }

        public async Task<SaveLabResultViewModel> GetByIdSaveViewModel(int id)
        {
            var labResult = await _labResultRepository.GetByIdAsync(id);
            if (labResult != null)
            {
                return new SaveLabResultViewModel
                {
                    Id = labResult.Id,
                    LabTestId = labResult.LabTestId,
                    PatientId = labResult.PatientId,
                    Result = labResult.Result,
                    IsCompleted = labResult.IsCompleted,
                };
            }

            return null;
        }

        public async Task Update(SaveLabResultViewModel vm)
        {
            var labResult = await _labResultRepository.GetByIdAsync(vm.Id);

            if (labResult != null)
            {
                labResult.LabTestId = vm.LabTestId;
                labResult.PatientId = vm.PatientId;
                labResult.Result = vm.Result;
                labResult.IsCompleted = vm.IsCompleted;

                await _labResultRepository.UpdateAsync(labResult);
            }
        }
    }
}
