using System.Collections.Generic;

namespace ORM.Entities
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public ToDoList()
        {
            Tasks = new List<Task>();
        }
    }
}
