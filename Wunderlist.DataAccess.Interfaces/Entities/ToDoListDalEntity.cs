namespace Wunderlist.DataAccess.Interfaces.Entities
{
    public class ToDoListDalEntity : IDalEntity
    {
        public ToDoListDalEntity(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}
