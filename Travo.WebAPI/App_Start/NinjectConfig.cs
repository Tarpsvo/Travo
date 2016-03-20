using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;
using Ninject.Web.Common;
using Travo.BLL.Services;
using Travo.DAL;
using Travo.DAL.Interfaces;
using Travo.DAL.Repositories;
using Travo.Domain.Models;

namespace Travo
{
    public static class NinjectConfig
    {
        public static void Register(IKernel kernel)
        {
            // General
            kernel.Bind<TravoDbContext>().ToSelf().InRequestScope();
            kernel.Bind<IUserStore<User>>()
                .To<UserStore<User>>()
                .WithConstructorArgument("context", context => kernel.Get<TravoDbContext>());


            // Repositories
            kernel.Bind<IAccountRepository>().To<AccountRepository>();
            kernel.Bind<ITeamRepository>().To<TeamRepository>();
            kernel.Bind<IBoardRepository>().To<BoardRepository>();

            // Services
            kernel.Bind<IAccountServices>().To<AccountServices>();
        }
    }
}