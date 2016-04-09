using System.Collections.Generic;
using Travo.BLL.DTO;

namespace Travo.BLL.Services
{
    public interface ITagServices
    {
        TagDTO AddNewTag(string userId, int boardId, TagDTO tagDTO);
    }
}
