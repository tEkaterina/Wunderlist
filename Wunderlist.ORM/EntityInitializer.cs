using System.Data.Entity;
using Wunderlist.ORM.Entities;

namespace Wunderlist.ORM
{
    public class EntityInitializer : DropCreateDatabaseIfModelChanges<EntityContext>
    {
        protected override void Seed(EntityContext context)
        {
            context.Set<User>().Add(new User()
            {
                Email = "admin@mail.com",
                Password = "sdgsd",
                Salt = "12345"
            });
            base.Seed(context);
        }
    }
}
