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
