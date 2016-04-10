using System;
using System.Collections.Generic;
using Travo.BLL.DTO;
using Travo.BLL.Factories;
using Travo.BLL.Services;
using Travo.DAL.Interfaces;

namespace Travo.BLL.Services
{
    public class BoardServices : IBoardServices
    {
        private ITagRepository _tagRepository;
        private ITaskRepository _taskRepository;
        private IUserRepository _userRepository;

        public BoardServices(ITagRepository tagRepository, ITaskRepository taskRepository, IUserRepository userRepository)
        {
            _tagRepository = tagRepository;
            _taskRepository = taskRepository;
            _userRepository = userRepository;
        }

        public List<TagWithTasksDTO> GetTagsWithTasksForBoard(string userId, int boardId)
        {
            var access = _userRepository.UserHasAccessToBoard(userId, boardId);
            if (!access)
            {
                throw new UnauthorizedAccessException();
            }

            var tags = _tagRepository.GetTagsForBoard(boardId);

            var tagWithTasksList = new List<TagWithTasksDTO>(tags.Count);
            tags.ForEach(tag => {
                var tasks = _taskRepository.GetTasksForTag(tag.Id);
                var tagWithTasks = new TagWithTasksDTO
                {
                    Tag = TagFactory.createReturnDTO(tag),
                    Tasks = TaskFactory.createReturnDTOList(tasks)
                };
                tagWithTasksList.Add(tagWithTasks);
            });
            return tagWithTasksList;
        }
    }
}
