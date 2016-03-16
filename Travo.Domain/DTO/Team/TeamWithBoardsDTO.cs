using System.Collections.Generic;
using Travo.Domain.Models;

namespace Travo.Domain.DTO
{
    class TeamWithBoardsDTO
    {
        public Team Team { get; set; }
        public List<Board> Boards { get; set; }
    }
}
