using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travo.DAL.Interfaces;
using Travo.Domain.Models;

namespace Travo.DAL.Repositories
{
    class BoardRepository: EFRepository<Board>, IBoardRepository
    {
        public BoardRepository(TravoDbContext dbContext) : base(dbContext) {}
    }
}
