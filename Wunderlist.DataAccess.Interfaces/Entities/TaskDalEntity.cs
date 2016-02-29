using System;

namespace DAL.Interfaces.Entities
{
    public class TaskDalEntity : IDalEntity
    {
        public TaskDalEntity(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public string Name { get; set; }
        public DateTime? DueDate { get; set; }
        public int ToDoListId { get; set; }
    }
}
