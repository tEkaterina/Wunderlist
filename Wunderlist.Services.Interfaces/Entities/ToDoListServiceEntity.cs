namespace Wunderlist.Services.Interfaces.Entities
{
    public class ToDoListServiceEntity : IServiceEntity
    {
        public ToDoListServiceEntity() { }

        public ToDoListServiceEntity(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}
