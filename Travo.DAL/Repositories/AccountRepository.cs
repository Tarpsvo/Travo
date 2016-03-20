using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travo.Domain.DTO;
using Travo.Domain.Models;

namespace Travo.DAL.Repositories
{
    public class AccountRepository: IDisposable
    {
        private TravoDbContext _ctx;
        private UserManager<User> _userManager;

        public AccountRepository()
        {
            _ctx = new TravoDbContext();
            _userManager = new UserManager<User>(new UserStore<User>(_ctx));
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
            var team = _ctx.Teams.Add(defaultTeam);

            var userInTeam = new UserInTeam
            {
                Role = Domain.Enums.UserRoleInTeam.Normal,
                TeamId = team.Id,
                UserId = registeredUser.Id
            };
            _ctx.UserInTeams.Add(userInTeam);

            var welcomeBoard = new Board
            {
                CreatedByUserId = registeredUser.Id,
                Name = "Welcome Board"
            };
           var board = _ctx.Boards.Add(welcomeBoard);

            var boardInTeam = new BoardInTeam
            {
                BoardId = board.Id,
                TeamId = team.Id
            };
            _ctx.BoardInTeams.Add(boardInTeam);

            _ctx.SaveChanges();

            return result;
        }

        public async Task<User> FindUser(string email, string password)
        {
            var user = await _userManager.FindAsync(email, password);
            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}
