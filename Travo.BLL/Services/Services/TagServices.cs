using System;
using System.Collections.Generic;
using Travo.BLL.DTO;
using Travo.BLL.Factories;
using Travo.DAL.Interfaces;

namespace Travo.BLL.Services
{
    public class TagServices : ITagServices
    {
        private IUserRepository _userRepository;
        private ITagRepository _tagRepository;

        public TagServices(IUserRepository userRepository, ITagRepository tagRepository)
        {
            _userRepository = userRepository;
            _tagRepository = tagRepository;
        }

        public TagDTO AddNewTag(string userId, int boardId, TagDTO tagDTO)
        {
            var access = _userRepository.UserHasAccessToBoard(userId, boardId);
            if (!access)
            {
                throw new UnauthorizedAccessException();
            }

            var tag = TagFactory.createTagFromDTO(tagDTO);
            tag.BoardId = boardId;
            var savedTag = _tagRepository.Add(tag);
            _tagRepository.Save();
            return TagFactory.createReturnDTO(savedTag);
        }
    }
}
