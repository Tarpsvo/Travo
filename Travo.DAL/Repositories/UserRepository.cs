using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using Travo.DAL.Interfaces;
using Travo.Domain.Models;

namespace Travo.DAL.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private TravoDbContext _dbContext;
        private UserManager<User> _userManager;

        public UserRepository(TravoDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<bool> RegisterUser(string email, string displayName, string password)
        {
            User user = new User
            {
                UserName = email,
                Email = email,
                DisplayName = displayName
            };

            var result = await _userManager.CreateAsync(user, password);
            var registeredUser = await FindUser(email, password);

            var defaultTeam = new Team
            {
                CreatedByUserId = registeredUser.Id,
                Description = "",
                isDefault = true,
                Name = "My Boards"
            };
            var team = _dbContext.Teams.Add(defaultTeam);

            var userInTeam = new UserInTeam
            {
                Role = Domain.Enums.UserRoleInTeam.Normal,
                TeamId = team.Id,
                UserId = registeredUser.Id
            };
            _dbContext.UserInTeams.Add(userInTeam);

            var welcomeBoard = new Board
            {
                CreatedByUserId = registeredUser.Id,
                Name = "Welcome Board"
            };
           var board = _dbContext.Boards.Add(welcomeBoard);

            var boardInTeam = new BoardInTeam
            {
                BoardId = board.Id,
                TeamId = team.Id
            };
            _dbContext.BoardInTeams.Add(boardInTeam);

            _dbContext.SaveChanges();

            return result.Succeeded;
        }

        public async Task<User> FindUser(string email, string password)
        {
            return await _userManager.FindAsync(email, password);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            _userManager.Dispose();
        }
    }
}
