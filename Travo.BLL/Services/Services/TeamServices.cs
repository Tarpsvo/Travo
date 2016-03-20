using System;
using System.Collections.Generic;
using Travo.BLL.DTO;
using Travo.DAL.Interfaces;

namespace Travo.BLL.Services
{
    public class TeamServices : ITeamServices
    {
        private IBoardRepository _boardRepository;
        private ITeamRepository _teamRepository;

        public TeamServices(IBoardRepository boardRepository, ITeamRepository teamRepository)
        {
            _boardRepository = boardRepository;
            _teamRepository = teamRepository;
        }

        public List<TeamWithBoardsDTO> GetTeamsWithBoards()
        {
            throw new NotImplementedException();
        }
    }
}
