using System;
using System.Collections.Generic;
using Travo.DAL.Interfaces;
using Travo.Domain.Models;
using System.Linq;

namespace Travo.DAL.Repositories
{
    public class TeamRepository : EFRepository<Team>, ITeamRepository
    {
        public TeamRepository(TravoDbContext dbContext) : base(dbContext) { }

        public void AddBoardToTeam(int boardId, int teamId)
        {
            var boardInTeam = new BoardInTeam
            {
                BoardId = boardId,
                TeamId = teamId
            };
            DbContext.BoardInTeams.Add(boardInTeam);
            DbContext.SaveChanges();
        }

        public List<Team> GetUserTeams(string userId)
        {
            var teams =
                from ut in DbContext.UserInTeams
                from tm in DbContext.Teams
                where
                    ut.UserId == userId &&
                    tm.Id == ut.TeamId
                select tm;
            return teams.ToList();
        }
    }
}