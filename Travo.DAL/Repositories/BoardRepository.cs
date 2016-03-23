using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travo.DAL.Interfaces;
using Travo.Domain.Models;

namespace Travo.DAL.Repositories
{
    public class BoardRepository: EFRepository<Board>, IBoardRepository
    {
        public BoardRepository(TravoDbContext dbContext) : base(dbContext) {}

        public List<Board> GetTeamBoards(int teamId)
        {
            var boards = 
                from bt in DbContext.BoardInTeams
                from bd in DbContext.Boards
                where
                    bt.TeamId == teamId &&
                    bt.BoardId == bd.Id
                select bd;
            return boards.ToList();
        }
    }
}
