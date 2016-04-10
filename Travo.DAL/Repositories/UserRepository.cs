using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using Travo.DAL.Interfaces;
using Travo.Domain.Models;
using System.Linq;

namespace Travo.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private TravoDbContext _dbContext;
        private TravoUserManager _userManager;

        public UserRepository(TravoDbContext dbContext, TravoUserManager userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<bool> RegisterUser(string email, string displayName, string password)
        {
            if (displayName == null || displayName.Length > 30)
            {
                // TODO Add proper exception
                throw new InvalidOperationException();
            }

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
                Default = true,
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

            var tag = new Tag
            {
                BoardId = board.Id,
                Name = "Getting started",
                CreatedByUserId = registeredUser.Id
            };
            _dbContext.Tags.Add(tag);

            var task1 = new Domain.Models.Task
            {
                CreatedByUserId = registeredUser.Id,
                Description = "Edit this board with tags that fit you",
                TagId = tag.Id
            };
            _dbContext.Tasks.Add(task1);

            var task21 = new Domain.Models.Task
            {
                CreatedByUserId = registeredUser.Id,
                Description = "Create to-do tasks of tasks you need to get done",
                TagId = tag.Id
            };
            _dbContext.Tasks.Add(task21);

            _dbContext.SaveChanges();

            return result.Succeeded;
        }

        public async Task<User> FindUser(string email, string password)
        {
            return await _userManager.FindAsync(email, password);
        }

        public async Task<bool> UserExists(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return (user != null);
        }

        public bool UserHasAccessToTask(string userId, int taskId)
        {
            var count =
                (from tk in _dbContext.Tasks
                 from tg in _dbContext.Tags
                 from bt in _dbContext.BoardInTeams
                 from ut in _dbContext.UserInTeams
                 where
                     tk.Id == taskId &&
                     tg.Id == tk.TagId &&
                     bt.BoardId == tg.BoardId &&
                     ut.TeamId == bt.TeamId &&
                     ut.UserId == userId
                 select ut.Id).Count();
            return (count == 1);
        }

        public bool UserHasAccessToTag(string userId, int tagId)
        {
            var count =
                    (from tg in _dbContext.Tags
                    from bt in _dbContext.BoardInTeams
                    from ut in _dbContext.UserInTeams
                    where
                        tg.Id == tagId &&
                        bt.BoardId == tg.BoardId &&
                        ut.TeamId == bt.TeamId &&
                        ut.UserId == userId
                    select ut.Id).Count();
            return (count == 1);
        }

        public bool UserHasAccessToBoard(string userId, int boardId)
        {
            var count =
                (from bt in _dbContext.BoardInTeams
                from ut in _dbContext.UserInTeams
                where
                    bt.BoardId == boardId &&
                    ut.TeamId == bt.TeamId &&
                    ut.UserId == userId
                select ut.Id).Count();
            return (count == 1);
        }
        
        public bool UserHasAccessToTeam(string userId, int teamId)
        {
            var count =
                (from ut in _dbContext.UserInTeams
                 where
                    ut.UserId == userId &&
                    ut.TeamId == teamId
                 select ut.Id).Count();
            return (count == 1);
        }

        public bool UserCanEditTeam(string userId, int teamId)
        {
            var count =
                (from ut in _dbContext.UserInTeams
                from t in _dbContext.Teams
                where
                    ut.UserId == userId &&
                    ut.TeamId == teamId &&
                    t.Id == ut.TeamId &&
                    t.Default == false
                 select ut.Id).Count();
            return (count == 1);
        }

        public Task<User> GetUser(string userId)
        {
            return _userManager.FindByIdAsync(userId);
        }
    }
}
