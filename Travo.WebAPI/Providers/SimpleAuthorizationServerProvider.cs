using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Travo.DAL.Repositories;
using Travo.Domain.Models;

namespace Travo.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async System.Threading.Tasks.Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async System.Threading.Tasks.Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using (AccountRepository _repo = new AccountRepository())
            {
                if (context.UserName == null)
                {
                    context.SetError("Invalid data", "Username field was empty.");
                    return;
                }

                if (context.UserName == null)
                {
                    context.SetError("Invalid data", "Password field was empty.");
                    return;
                }

                User user = await _repo.FindUser(context.UserName, context.Password);

                if (user == null)
                {
                    context.SetError("Invalid data", "The user name or password is incorrect.");
                    return;
                }
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            context.Validated(identity);
        }
    }
}