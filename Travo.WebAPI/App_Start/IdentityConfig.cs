using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Travo.DAL;
using Travo.Domain.Models;

namespace Travo.App_Start
{
    public class TravoUserManager : UserManager<User>
    {
        public TravoUserManager(IUserStore<User> store) : base(store)
        {
        }

        public static TravoUserManager Create(IdentityFactoryOptions<TravoUserManager> options, IOwinContext context)
        {
            var manager = new TravoUserManager(new UserStore<User>(context.Get<TravoDbContext>()));

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

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}