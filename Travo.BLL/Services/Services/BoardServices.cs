using System;
using System.Collections.Generic;
using Travo.BLL.DTO;
using Travo.BLL.Factories;
using Travo.DAL.Interfaces;

namespace Travo.BLL.Services
{
    public class BoardServices : IBoardServices
    {
        private ITagRepository _tagRepository;
        private ITaskRepository _taskRepository;
        private IUserRepository _userRepository;
        private IBoardRepository _boardRepository;
        private ITeamRepository _teamRepository;

        public BoardServices(ITagRepository tagRepository, ITaskRepository taskRepository, IUserRepository userRepository, IBoardRepository boardRepository, ITeamRepository teamRepository)
        {
            _tagRepository = tagRepository;
            _taskRepository = taskRepository;
            _userRepository = userRepository;
            _boardRepository = boardRepository;
            _teamRepository = teamRepository;
        }

        public BoardDTO CreateBoard(string userId, int teamId, BoardDTO boardDTO)
        {
            var access = _userRepository.UserHasAccessToTeam(userId, teamId);
            if (!access)
            {
                throw new UnauthorizedAccessException();
            }

            var board = BoardFactory.createBoardFromDTO(boardDTO);
            board.CreatedByUserId = userId;
            var savedBoard = _boardRepository.Add(board);
            _boardRepository.Save();
            _teamRepository.AddBoardToTeam(savedBoard.Id, teamId);
            return BoardFactory.createReturnDTO(savedBoard);
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
