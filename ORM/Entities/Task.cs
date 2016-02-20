using System.Collections.Generic;

namespace ORM
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ToDoListId { get; set; }
        public virtual ToDoList ToDoList { get; set; }

        public virtual ICollection<TaskStatus> TaskStatuses { get; set; }

        public Task()
        {
            TaskStatuses = new List<TaskStatus>();
        }
    }
}
