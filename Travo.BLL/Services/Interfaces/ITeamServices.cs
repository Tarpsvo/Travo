using System.Collections.Generic;
using Travo.BLL.DTO;

namespace Travo.BLL.Services
{
    public interface ITeamServices
    {
        List<TeamWithBoardsDTO> GetTeamsWithBoardsForUser(string userId);
    }
}
