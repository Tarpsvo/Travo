using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travo.Domain.Models;

namespace Travo.DAL.Repositories
{
    public class TeamRepository : EFRepository<Team> 
    {
        public TeamRepository(TravoDbContext dbContext) : base(dbContext) { }
    }
}
