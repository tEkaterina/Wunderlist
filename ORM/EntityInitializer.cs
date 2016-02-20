using System.Data.Entity;

namespace ORM
{
    public class EntityInitializer : DropCreateDatabaseIfModelChanges<EntityContext>
    {
        protected override void Seed(EntityContext context)
        {
            // Add some initial values

            base.Seed(context);
        }
    }
}
