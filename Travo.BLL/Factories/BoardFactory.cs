using System.Collections.Generic;
using System.Linq;
using Travo.BLL.DTO;
using Travo.BLL.Helpers;
using Travo.Domain.Models;

namespace Travo.BLL.Factories
{
    public static class BoardFactory
    {
        public static BoardDTO createBasicDTO(Board board)
        {
            return new BoardDTO
            {
                Id = board.Id,
                Created = DateTimeConverter.ConvertToUnixTimestamp(board.Created),
                Name = board.Name
            };
        }

        public static List<BoardDTO> createBasicDTOList(List<Board> boardList)
        {
            return boardList.Select(b => createBasicDTO(b)).ToList();
        }
    }
}
