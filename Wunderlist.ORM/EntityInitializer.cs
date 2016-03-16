using System.Data.Entity;
using Wunderlist.ORM.Entities;

namespace Wunderlist.ORM
{
    public class EntityInitializer : DropCreateDatabaseIfModelChanges<EntityContext>
    {
        protected override void Seed(EntityContext context)
        {
            context.Set<TaskStatus>().Add(new TaskStatus() { Name = "Wait" });
            context.Set<TaskStatus>().Add(new TaskStatus() { Name = "Completed" });

            base.Seed(context);
        }
    }
}
