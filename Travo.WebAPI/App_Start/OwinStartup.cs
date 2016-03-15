using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Travo.OwinStartup))]
namespace Travo
{
    public class OwinStartup
    {
        public void Configuration(IAppBuilder app)
        {
            // TODO
            // http://www.c-sharpcorner.com/uploadfile/ff2f08/token-based-authentication-using-asp-net-web-api-owin-and-i/
        }
    }
}