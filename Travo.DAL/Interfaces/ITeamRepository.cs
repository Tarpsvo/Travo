using System.Collections.Generic;
using System.Threading.Tasks;
using Travo.Domain.DTO;

namespace Travo.DAL.Interfaces
{
    public interface ITeamRepository
    {
        List<TeamWithBoardsDTO> GetTeamsWithBoards();
        Task AddUserToTeam(string UserId, int TeamId);
        Task RemoveUserFromTeam(string UserId, int TeamId);
    }
}
