using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using Travo.Domain.Models;

namespace Travo.DAL.Interfaces
{
    public interface IAccountRepository : IDisposable
    {
        Task<bool> RegisterUser(string email, string displayName, string password);
        Task<User> FindUser(string email, string password);
    }
}
