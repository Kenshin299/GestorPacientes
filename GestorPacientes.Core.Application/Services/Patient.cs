using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Patient;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task Add(SavePatientViewModel vm)
        {
            var patient = new Patient
            {
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Phone = vm.Phone,
                Address = vm.Address,
                IdentityNumber = vm.IdentityNumber,
                DateOfBirth = vm.DateOfBirth,
                IsSmoker = vm.IsSmoker,
                Allergies = vm.Allergies,
                Photo = vm.Photo,
                DoctorId = vm.DoctorId,
            };

            await _patientRepository.AddAsync(patient);
        }

        public async Task Delete(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient != null)
            {
                await _patientRepository.DeleteAsync(patient);
            }
        }

        public async Task<List<PatientViewModel>> GetAllViewModel()
        {
            var patients = await _patientRepository.GetAllAsync();
            var patientViewModels = new List<PatientViewModel>();

            foreach (var patient in patients)
            {
                patientViewModels.Add(new PatientViewModel
                {
                    Id = patient.Id,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    Phone = patient.Phone,
                    Address = patient.Address,
                    IdentityNumber = patient.IdentityNumber,
                    DateOfBirth = patient.DateOfBirth,
                    IsSmoker = patient.IsSmoker,
                    Allergies = patient.Allergies,
                    Photo = patient.Photo,
                    DoctorId = patient.DoctorId,
                });
            }

            return patientViewModels;
        }

        public async Task<SavePatientViewModel> GetByIdSaveViewModel(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient != null)
            {
                return new SavePatientViewModel
                {
                    Id = patient.Id,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    Phone = patient.Phone,
                    Address = patient.Address,
                    IdentityNumber = patient.IdentityNumber,
                    DateOfBirth = patient.DateOfBirth,
                    IsSmoker = patient.IsSmoker,
                    Allergies = patient.Allergies,
                    Photo = patient.Photo,
                    DoctorId = patient.DoctorId,
                };
            }

            return null;
        }

        public async Task Update(SavePatientViewModel vm)
        {
            var patient = await _patientRepository.GetByIdAsync(vm.Id);

            if (patient != null)
            {
                patient.FirstName = vm.FirstName;
                patient.LastName = vm.LastName;
                patient.Phone = vm.Phone;
                patient.Address = vm.Address;
                patient.IdentityNumber = vm.IdentityNumber;
                patient.DateOfBirth = vm.DateOfBirth;
                patient.IsSmoker = vm.IsSmoker;
                patient.Allergies = vm.Allergies;
                patient.Photo = vm.Photo;
                patient.DoctorId = vm.DoctorId;

                await _patientRepository.UpdateAsync(patient);
            }
        }
    }
}
