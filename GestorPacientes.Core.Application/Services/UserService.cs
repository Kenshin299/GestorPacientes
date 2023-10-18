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

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

                await _userRepository.UpdateAsync(user);
            }
        }

        public async Task<bool> VerifyPassword(LoginViewModel user)
        {
            var validate = await _userRepository.GetByUserNameAsync(user.Username);

            if (user != null)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UsernameExists(string userName)
        {
            // Check if a user with the provided username already exists
            var user = await _userRepository.GetByUserNameAsync(userName);

            // Return true if a user with the username exists, otherwise, return false
            return user != null;
        }
    }
}
