﻿using System.Threading.Tasks;
using Travo.BLL.DTO;

namespace Travo.BLL.Services
{
    public interface IUserServices
    {
        Task<bool> Register(UserDTO userDTO);
        Task<string> Login(UserDTO userDTO);
        Task<UserDTO> GetUser(string userId);
        Task<UserDTO> GetMe(string userId);
    }
}
