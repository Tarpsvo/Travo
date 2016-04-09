namespace Travo.BLL.DTO
{
    public class TagDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public long Created { get; set; }
        public UserDTO CreatedByUser { get; set; }
        public int BoardId { get; set; }
    }
}
