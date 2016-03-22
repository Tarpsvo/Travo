using System;
using System.Collections.Generic;
using Travo.DAL.Interfaces;
using Travo.Domain.Models;

namespace Travo.DAL.Repositories
{
    public class TeamRepository : EFRepository<Team>, ITeamRepository
    {
        public TeamRepository(TravoDbContext dbContext) : base(dbContext) { }

        public System.Threading.Tasks.Task AddUserToTeam(string UserId, int TeamId)
        {
            throw new NotImplementedException();
        }

        public List<Team> GetUserTeams(string userId)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task RemoveUserFromTeam(string UserId, int TeamId)
        {
            throw new NotImplementedException();
        }
    }
}