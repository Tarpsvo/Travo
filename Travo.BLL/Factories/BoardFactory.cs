using System.Collections.Generic;
using System.Linq;
using Travo.BLL.DTO;
using Travo.BLL.Helpers;
using Travo.Domain.Models;

namespace Travo.BLL.Factories
{
    public static class BoardFactory
    {
        public static BoardDTO createReturnDTO(Board board)
        {
            return new BoardDTO
            {
                Id = board.Id,
                Name = board.Name,
                Created = DateTimeConverter.ConvertToUnixTimestamp(board.Created),
                CreatedByUser = (board.CreatedByUser != null) ? UserFactory.createReturnDTO(board.CreatedByUser) : null
            };
        }

        public static List<BoardDTO> createReturnDTOList(List<Board> boardList)
        {
            return boardList.Select(b => createReturnDTO(b)).ToList();
        }

        public static Board createBoardFromDTO(BoardDTO boardDTO)
        {
            return new Board
            {
                Id = boardDTO.Id,
                Name = boardDTO.Name
            };
        }
    }
}
