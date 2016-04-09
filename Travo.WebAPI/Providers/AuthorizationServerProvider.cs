using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using Travo.BLL.DTO;
using Travo.BLL.Services;
using Travo.Domain.Models;

namespace Travo.Providers
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private IUserServices _userServices;

        public AuthorizationServerProvider(IUserServices userServices)
        {
            _userServices = userServices;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async System.Threading.Tasks.Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

        public override async System.Threading.Tasks.Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
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

            var userId = await _userServices.Login(new UserDTO { Email = context.UserName, Password = context.Password });

            if (userId == null)
            {
                context.SetError("Invalid data", "The user name or password is incorrect.");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userId));

            context.Validated(identity);
        }
    }
}