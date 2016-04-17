namespace Travo.BLL.DTO
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public TagDTO Tag { get; set; }
        public int? TagId { get; set; }
        public UserDTO CreatedByUser { get; set; }
        public int? CreatedByUserId { get; set; }
        public long Created { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
