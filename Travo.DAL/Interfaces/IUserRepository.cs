using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using Travo.Domain.Models;

namespace Travo.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> RegisterUser(string email, string displayName, string password);
        Task<User> FindUser(string email, string password);
        Task<bool> UserExists(string email);
        Task<User> GetUser(string userId);

        bool UserHasAccessToTask(string userId, int taskId);
        bool UserHasAccessToTag(string userId, int tagId);
        bool UserHasAccessToBoard(string userId, int boardId);
        bool UserHasReadAccessToTeam(string userId, int teamId);
        bool UserHasWriteAccessToTeam(string userId, int teamId);
    }
}
