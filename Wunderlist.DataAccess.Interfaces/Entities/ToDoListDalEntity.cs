namespace Wunderlist.DataAccess.Interfaces.Entities
{
    public class ToDoListDalEntity : IDalEntity
    {
        public ToDoListDalEntity() { }

        public ToDoListDalEntity(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}
