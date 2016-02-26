namespace DAL.Interfaces.Entities
{
    public class ToDoListDalEntity : IDalEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}
