using System.Collections.Generic;
using System.Threading.Tasks;
using Travo.Domain.Models;

namespace Travo.DAL.Interfaces
{
    public interface ITeamRepository
    {
        List<Team> GetUserTeams(string userId);
        System.Threading.Tasks.Task AddUserToTeam(string UserId, int TeamId);
        System.Threading.Tasks.Task RemoveUserFromTeam(string UserId, int TeamId);
    }
}
