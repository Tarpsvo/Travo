﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Diagnostics;
using Travo.DAL.Interfaces;
using Travo.DAL.Migrations;
using Travo.Domain.Models;

namespace Travo.DAL
{
    public class TravoDbContext : IdentityDbContext, IDbContext
    {
        public TravoDbContext() : base("LocalDbConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TravoDbContext, Configuration>());
            #if DEBUG
                Database.Log = s => Trace.Write(s);
            #endif
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
