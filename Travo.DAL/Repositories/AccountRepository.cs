using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;
using Travo.DAL.Interfaces;
using Travo.Domain.DTO;
using Travo.Domain.Models;

namespace Travo.DAL.Repositories
{
    public class AccountRepository : IAccountRepository, IDisposable
    {
        private TravoDbContext _dbContext;
        private UserManager<User> _userManager;

        public AccountRepository(TravoDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<IdentityResult> RegisterUser(RegisterDTO RegisterDTO)
        {
            User user = new User
            {
                UserName = RegisterDTO.Email,
                Email = RegisterDTO.Email,
                DisplayName = RegisterDTO.DisplayName
            };

            var result = await _userManager.CreateAsync(user, RegisterDTO.Password);
            var registeredUser = await FindUser(RegisterDTO.Email, RegisterDTO.Password);

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

            return result;
        }

        public async Task<User> FindUser(string email, string password)
        {
            var user = await _userManager.FindAsync(email, password);
            return user;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            _userManager.Dispose();
        }
    }
}
