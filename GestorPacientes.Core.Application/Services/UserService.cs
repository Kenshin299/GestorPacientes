using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.User;
using GestorPacientes.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace GestorPacientes.Core.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(IUserRepository userRepository, UserManager<User> userManager, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }

        public async Task Add(SaveUserViewModel vm)
        {
            var user = new User
            {
                UserName = vm.UserName,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Email = vm.Email,
                PasswordHash = vm.Password,
                IsAdmin = vm.IsAdmin
            };

            // Hashea la contraseña para mayor seguridad
            var hashedPassword = _passwordHasher.HashPassword(user, vm.Password);
            user.PasswordHash = hashedPassword;

            await _userRepository.AddAsync(user);
        }

        public async Task Delete(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
            {
                await _userRepository.DeleteAsync(user);
            }
        }

        public async Task<List<UserViewModel>> GetAllViewModel()
        {
            var users = await _userRepository.GetAllAsync();
            var userViewModels = new List<UserViewModel>();

            foreach (var user in users)
            {
                userViewModels.Add(new UserViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    IsAdmin = user.IsAdmin
                });
            }

            return userViewModels;
        }

        public async Task<SaveUserViewModel> GetByIdSaveViewModel(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
            {
                return new SaveUserViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    IsAdmin = user.IsAdmin
                };
            }

            return null;
        }

        public async Task Update(SaveUserViewModel vm)
        {
            var user = await _userRepository.GetByIdAsync(vm.Id);

            if (user != null)
            {
                user.UserName = vm.UserName;
                user.FirstName = vm.FirstName;
                user.LastName = vm.LastName;
                user.Email = vm.Email;
                user.PasswordHash = vm.Password;
                user.IsAdmin = vm.IsAdmin;

                // Hashea la contraseña para mayor seguridad
                var hashedPassword = _passwordHasher.HashPassword(user, vm.Password);
                user.PasswordHash = hashedPassword;

                await _userRepository.UpdateAsync(user);
            }
        }

        public async Task<bool> VerifyPassword(int userId, string password)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user != null)
            {
                var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

                return result == PasswordVerificationResult.Success;
            }

            return false;
        }
    }
}
