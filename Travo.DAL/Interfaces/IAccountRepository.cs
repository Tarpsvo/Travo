using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using Travo.Domain.DTO;
using Travo.Domain.Models;

namespace Travo.DAL.Interfaces
{
    public interface IAccountRepository : IDisposable
    {
        Task<IdentityResult> RegisterUser(RegisterDTO RegisterDTO);
        Task<User> FindUser(string email, string password);
    }
}
