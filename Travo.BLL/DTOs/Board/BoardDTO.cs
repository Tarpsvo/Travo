namespace Travo.BLL.DTO
{
    public class BoardDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserDTO CreatedByUser { get; set; }
        public long Created { get; set; }
    }
}