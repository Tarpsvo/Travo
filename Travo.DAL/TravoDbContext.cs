using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Diagnostics;
using Travo.DAL.Interfaces;
using Travo.DAL.Migrations;
using Travo.Domain.Models;
using System;

namespace Travo.DAL
{
    public class TravoDbContext : IdentityDbContext
    {
        public TravoDbContext() : base("LocalDbConnectionString")
        {
#if DEBUG
            Database.Log = s => Trace.Write(s);
#endif

            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<BoardInTeam> BoardInTeams { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskActivity> TaskActivities { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TimeTrack> TimeTracks { get; set; }
        public DbSet<UserInTeam> UserInTeams { get; set; }
    }
}
