using Travo.BLL.DTO;
using Travo.BLL.Helpers;
using Travo.Domain.Models;

namespace Travo.BLL.Factories
{
    public static class TagFactory
    {
        public static TagDTO createBasicDTO(Tag tag)
        {
            return new TagDTO
            {
                Created = DateTimeConverter.ConvertToUnixTimestamp(tag.Created),
                Id = tag.Id,
                Name = tag.Name
            };
        }
    }
}
