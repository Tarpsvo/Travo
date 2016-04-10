using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Travo.DAL;
using Travo.Domain.Models;

namespace Travo.DAL
{
    public class TravoUserManager : UserManager<User>
    {
        public TravoUserManager(IUserStore<User> store) : base(store) {}

        public static TravoUserManager Create()
        {
            var manager = new TravoUserManager(new UserStore<User>(new TravoDbContext()));

            // Configure validation logic for usernames
            // NB! Username == Email
            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false
            };

            return manager;
        }
    }
}