using System.Collections.Generic;

namespace Wunderlist.ORM.Entities
{
    public class TaskStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TaskDbModel> Tasks { get; set; }

        public TaskStatus()
        {
            Tasks = new List<TaskDbModel>();
        }
    }
}
