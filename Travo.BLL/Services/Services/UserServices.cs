using System;
using Travo.BLL.DTO;
using Travo.DAL.Interfaces;

namespace Travo.BLL.Services
{
    public class UserServices : IUserServices
    {
        private IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async System.Threading.Tasks.Task<string> Login(UserDTO userDTO)
        {
            var user = await _userRepository.FindUser(userDTO.Email, userDTO.Password);
            return (user != null) ? user.Id : null;
        }

        public async System.Threading.Tasks.Task<bool> Register(UserDTO userDTO)
        {
            return await _userRepository.RegisterUser(userDTO.Email, userDTO.DisplayName, userDTO.Password);
        }
    }
}
