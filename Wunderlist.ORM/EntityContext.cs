using System.Data.Entity;
using Wunderlist.ORM.Entities;

namespace Wunderlist.ORM
{
    public class EntityContext: DbContext
    {
        static EntityContext()
        {
            Database.SetInitializer<EntityContext>(new EntityInitializer());
        }

        public EntityContext()
            : base("name=EntityContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ToDoList> ToDoLists { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TaskStatus> TaskStatuses { get; set; }
        
    }
}
