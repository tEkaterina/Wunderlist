using System;

namespace DAL.Interfaces.Entities
{
    public class TaskDal : IDalEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DueDate { get; set; }
        public int ToDoListId { get; set; }
    }
}
