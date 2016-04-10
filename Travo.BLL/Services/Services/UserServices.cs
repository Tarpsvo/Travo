using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using Travo.BLL.DTO;
using Travo.BLL.Factories;
using Travo.DAL.Interfaces;
using Travo.Domain.Models;

namespace Travo.BLL.Services
{
    public class UserServices : IUserServices
    {
        private IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDTO> GetMe(string userId)
        {
            var user = await _userRepository.GetUser(userId);
            return UserFactory.createReturnAllDTO(user);
        }

        public async Task<UserDTO> GetUser(string userId)
        {
            var user = await _userRepository.GetUser(userId);
            return UserFactory.createReturnDTO(user);
        }

        public async System.Threading.Tasks.Task<string> Login(UserDTO userDTO)
        {
            var user = await _userRepository.FindUser(userDTO.Email, userDTO.Password);
            return (user != null) ? user.Id : null;
        }

        public async System.Threading.Tasks.Task<bool> Register(UserDTO userDTO)
        {
            if (await _userRepository.UserExists(userDTO.Email))
            {
                throw new Exception("Email already registered.");
            }
            return await _userRepository.RegisterUser(userDTO.Email, userDTO.DisplayName, userDTO.Password);
        }
    }
}
