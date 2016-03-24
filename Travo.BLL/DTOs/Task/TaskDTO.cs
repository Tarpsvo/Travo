namespace Travo.BLL.DTO
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public virtual TagDTO Tag { get; set; }
        public UserDTO CreatedByUser { get; set; }
        public long Created { get; set; }
        public string Description { get; set; }
    }
}
