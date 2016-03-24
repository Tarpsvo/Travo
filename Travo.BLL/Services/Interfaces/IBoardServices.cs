using System.Collections.Generic;
using Travo.BLL.DTO;

namespace Travo.BLL.Services
{
    public interface IBoardServices
    {
        List<TagWithTasksDTO> GetTagsWithTasksForBoard(string userId, int boardId);
    }
}
