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
            kernel.Bind<UserManager<User>>().ToSelf();


            // Repositories
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<ITeamRepository>().To<TeamRepository>();
            kernel.Bind<IBoardRepository>().To<BoardRepository>();
            kernel.Bind<ITagRepository>().To<TagRepository>();
            kernel.Bind<ITaskRepository>().To<TaskRepository>();

            // Services
            kernel.Bind<IUserServices>().To<UserServices>();
            kernel.Bind<ITeamServices>().To<TeamServices>();
            kernel.Bind<IBoardServices>().To<BoardServices>();
        }
    }
}