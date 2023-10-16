using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Appointmens;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task Add(SaveAppointmentViewModel vm)
        {
            var appointment = new Appointment
            {
                PatientId = vm.PatientId,
                DoctorId = vm.DoctorId,
                AppointmentDate = vm.AppointmentDate,
                Reason = vm.Reason,
                Status = vm.Status,
            };

            await _appointmentRepository.AddAsync(appointment);
        }

        public async Task Delete(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment != null)
            {
                await _appointmentRepository.DeleteAsync(appointment);
            }
        }

        public async Task<List<AppointmentViewModel>> GetAllViewModel()
        {
            var appointments = await _appointmentRepository.GetAllAsync();
            var appointmentViewModels = new List<AppointmentViewModel>();

            foreach (var appointment in appointments)
            {
                appointmentViewModels.Add(new AppointmentViewModel
                {
                    Id = appointment.Id,
                    PatientId = appointment.PatientId,
                    DoctorId = appointment.DoctorId,
                    AppointmentDate = appointment.AppointmentDate,
                    Reason = appointment.Reason,
                    Status = appointment.Status,
                });
            }

            return appointmentViewModels;
        }

        public async Task<SaveAppointmentViewModel> GetByIdSaveViewModel(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment != null)
            {
                return new SaveAppointmentViewModel
                {
                    Id = appointment.Id,
                    PatientId = appointment.PatientId,
                    DoctorId = appointment.DoctorId,
                    AppointmentDate = appointment.AppointmentDate,
                    Reason = appointment.Reason,
                    Status = appointment.Status,
                };
            }

            return null;
        }

        public async Task Update(SaveAppointmentViewModel vm)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(vm.Id);

            if (appointment != null)
            {
                appointment.PatientId = vm.PatientId;
                appointment.DoctorId = vm.DoctorId;
                appointment.AppointmentDate = vm.AppointmentDate;
                appointment.Reason = vm.Reason;
                appointment.Status = vm.Status;

                await _appointmentRepository.UpdateAsync(appointment);
            }
        }
    }
}
