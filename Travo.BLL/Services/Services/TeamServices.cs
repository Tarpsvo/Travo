using System;
using System.Collections.Generic;
using Travo.BLL.DTO;
using Travo.BLL.Factories;
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

        public List<TeamWithBoardsDTO> GetTeamsWithBoardsForUser(string userId)
        {
            var teams = _teamRepository.GetUserTeams(userId);

            var teamWithBoardsList = new List<TeamWithBoardsDTO>(teams.Count);
            teams.ForEach(team => {
                var boards = _boardRepository.GetTeamBoards(team.Id);
                var teamWithBoards = new TeamWithBoardsDTO
                {
                    Team = TeamFactory.createReturnMinimalDTO(team),
                    Boards = BoardFactory.createReturnDTOList(boards)
                };
                teamWithBoardsList.Add(teamWithBoards);
            });
            return teamWithBoardsList;
        }
    }
}
