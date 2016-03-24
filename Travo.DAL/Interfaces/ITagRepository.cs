using System.Collections.Generic;
using System.Threading.Tasks;
using Travo.Domain.Models;

namespace Travo.DAL.Interfaces
{
    public interface ITagRepository
    {
        List<Tag> GetTagsForBoard(int boardId);
    }
}
