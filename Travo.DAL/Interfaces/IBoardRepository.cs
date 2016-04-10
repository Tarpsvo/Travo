using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travo.Domain.Models;

namespace Travo.DAL.Interfaces
{
    public interface IBoardRepository : IEFRepository<Board>
    {
        List<Board> GetTeamBoards(int teamId);
    }
}
