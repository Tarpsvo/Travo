using System.Collections.Generic;

namespace Travo.BLL.DTO
{
    public class TeamWithBoardsDTO
    {
        public TeamDTO Team { get; set; }
        public List<BoardDTO> Boards { get; set; }
    }
}
