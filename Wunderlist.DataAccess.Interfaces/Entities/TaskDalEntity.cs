using System;

namespace Wunderlist.DataAccess.Interfaces.Entities
{
    public class TaskDalEntity : IDalEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DueDate { get; set; }
        public int ToDoListId { get; set; }
    }
}
