namespace Wunderlist.Services.Interfaces.Entities
{
    public class ToDoListServiceEntity : IServiceEntity
    {
        public ToDoListServiceEntity() { }

        public ToDoListServiceEntity(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}
