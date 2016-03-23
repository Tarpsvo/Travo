using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System;
using System.Reflection;
using System.Web.Http;
using Travo.App_Start;
using Travo.BLL.Services;
using Travo.DAL;
using Travo.Domain.Models;
using Travo.Providers;

[assembly: OwinStartup(typeof(Travo.WebAPI.Startup))]
namespace Travo.WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);

            var kernel = CreateKernel();
            NinjectConfig.Register(kernel);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            ConfigureOAuth(app, kernel);

            app.UseNinjectMiddleware(() => kernel);
            app.UseNinjectWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app, IKernel kernel)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/user/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new AuthorizationServerProvider(kernel.Get<IUserServices>())
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        public IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel;
        }
    }
}