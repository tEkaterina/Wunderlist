using System;
using System.Collections.Generic;

namespace Wunderlist.ORM.Entities
{
    public class TaskDbModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DueDate { get; set; }

        public int ToDoListId { get; set; }
        public virtual ToDoList ToDoList { get; set; }

        public virtual ICollection<TaskStatus> TaskStatuses { get; set; }

        public TaskDbModel()
        {
            TaskStatuses = new List<TaskStatus>();
        }
    }
}
