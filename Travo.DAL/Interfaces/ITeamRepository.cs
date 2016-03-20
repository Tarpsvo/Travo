using System.Collections.Generic;
using System.Threading.Tasks;
namespace Travo.DAL.Interfaces
{
    public interface ITeamRepository
    {
        Task AddUserToTeam(string UserId, int TeamId);
        Task RemoveUserFromTeam(string UserId, int TeamId);
    }
}
