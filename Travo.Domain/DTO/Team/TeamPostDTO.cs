using System.ComponentModel.DataAnnotations;

namespace Travo.Domain.DTO
{
    public class TeamPostDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}