using System.Data.Entity;
using System.Diagnostics;
using Travo.DAL.Interfaces;
using Travo.DAL.Migrations;

namespace Travo.DAL
{
    public class TravoDbContext : DbContext, IDbContext
    {
        public TravoDbContext() : base("DbConnectionString")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<TravoDbContext, MigrationConfiguration>());
                    #if DEBUG
                    Database.Log = s => Trace.Write(s);
                    #endif
        }

        // TODO: Add DbSets
    }
}
