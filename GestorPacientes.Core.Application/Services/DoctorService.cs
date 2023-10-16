using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Doctor;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task Add(SaveDoctorViewModel vm)
        {
            var doctor = new Doctor
            {
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Email = vm.Email,
                Phone = vm.Phone,
                LicenseNumber = vm.LicenseNumber,
                Photo = vm.Photo,
            };

            await _doctorRepository.AddAsync(doctor);
        }

        public async Task Delete(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor != null)
            {
                await _doctorRepository.DeleteAsync(doctor);
            }
        }

        public async Task<List<DoctorViewModel>> GetAllViewModel()
        {
            var doctors = await _doctorRepository.GetAllAsync();
            var doctorViewModels = new List<DoctorViewModel>();

            foreach (var doctor in doctors)
            {
                doctorViewModels.Add(new DoctorViewModel
                {
                    Id = doctor.Id,
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    Email = doctor.Email,
                    Phone = doctor.Phone,
                    LicenseNumber = doctor.LicenseNumber,
                    Photo = doctor.Photo,
                });
            }

            return doctorViewModels;
        }

        public async Task<SaveDoctorViewModel> GetByIdSaveViewModel(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor != null)
            {
                return new SaveDoctorViewModel
                {
                    Id = doctor.Id,
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    Email = doctor.Email,
                    Phone = doctor.Phone,
                    LicenseNumber = doctor.LicenseNumber,
                    Photo = doctor.Photo,
                };
            }

            return null;
        }

        public async Task Update(SaveDoctorViewModel vm)
        {
            var doctor = await _doctorRepository.GetByIdAsync(vm.Id);

            if (doctor != null)
            {
                doctor.FirstName = vm.FirstName;
                doctor.LastName = vm.LastName;
                doctor.Email = vm.Email;
                doctor.Phone = vm.Phone;
                doctor.LicenseNumber = vm.LicenseNumber;
                doctor.Photo = vm.Photo;

                await _doctorRepository.UpdateAsync(doctor);
            }
        }
    }
}
