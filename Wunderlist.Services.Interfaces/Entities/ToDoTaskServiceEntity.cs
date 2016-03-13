using System;

namespace Wunderlist.Services.Interfaces.Entities
{
    public class ToDoTaskServiceEntity : IServiceEntity
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public DateTime? DueDate { get; set; }
        public int ToDoListId { get; set; }
        public int TaskStatusId { get; set; }
    }
}
