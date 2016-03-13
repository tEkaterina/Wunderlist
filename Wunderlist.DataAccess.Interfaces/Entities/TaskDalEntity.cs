using System;

namespace Wunderlist.DataAccess.Interfaces.Entities
{
    public class TaskDalEntity : IDalEntity
    {
        public TaskDalEntity(){ }

        public TaskDalEntity(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public DateTime? DueDate { get; set; }
        public int ToDoListId { get; set; }
        public int TaskStatusId { get; set; }
    }
}
