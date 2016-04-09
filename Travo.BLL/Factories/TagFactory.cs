using Travo.BLL.DTO;
using Travo.BLL.Helpers;
using Travo.Domain.Models;

namespace Travo.BLL.Factories
{
    public static class TagFactory
    {
        public static TagDTO createReturnDTO(Tag tag)
        {
            return new TagDTO
            {
                Id = tag.Id,
                Name = tag.Name,
                Color = null, // TODO! Tag colors
                Created = DateTimeConverter.ConvertToUnixTimestamp(tag.Created)
            };
        }

        public static Tag createTagFromDTO(TagDTO tagDTO)
        {
            return new Tag
            {
                Id = tagDTO.Id,
                Name = tagDTO.Name,
                Color = null // TODO! Tag colors
            };
        }
    }
}
