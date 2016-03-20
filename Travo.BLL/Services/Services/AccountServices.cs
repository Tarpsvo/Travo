using System;
using Travo.BLL.DTO;
using Travo.DAL.Interfaces;

namespace Travo.BLL.Services
{
    public class AccountServices : IAccountServices
    {
        private IAccountRepository _accountRepository;

        public AccountServices(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public bool Login(UserDTO userDTO)
        {
            var user = _accountRepository.FindUser(userDTO.Email, userDTO.Password);
            return (user != null);
        }

        public async System.Threading.Tasks.Task<bool> Register(UserDTO userDTO)
        {
            return await _accountRepository.RegisterUser(userDTO.Email, userDTO.DisplayName, userDTO.Password);
        }
    }
}
