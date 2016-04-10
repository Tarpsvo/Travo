﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
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

            // Repositories
            kernel.Bind<IUserRepository>()
                .To<UserRepository>()
                .WithConstructorArgument("userManager", TravoUserManager.Create()); ;
            kernel.Bind<ITeamRepository>().To<TeamRepository>();
            kernel.Bind<IBoardRepository>().To<BoardRepository>();
            kernel.Bind<ITagRepository>().To<TagRepository>();
            kernel.Bind<ITaskRepository>().To<TaskRepository>();

            // Services
            kernel.Bind<IUserServices>().To<UserServices>();
            kernel.Bind<ITeamServices>().To<TeamServices>();
            kernel.Bind<IBoardServices>().To<BoardServices>();
            kernel.Bind<ITaskServices>().To<TaskServices>();
            kernel.Bind<ITagServices>().To<TagServices>();
        }
    }
}