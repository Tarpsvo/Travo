using System.Collections.Generic;
using System.Threading.Tasks;
using Travo.Domain.Models;

namespace Travo.DAL.Interfaces
{
    public interface ITeamRepository
    {
        List<Team> GetUserTeams(string userId);
        void AddBoardToTeam(int boardId, int teamId);
    }
}
