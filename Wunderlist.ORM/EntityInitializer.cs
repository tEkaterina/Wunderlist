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
            context.Set<User>().Add(new User()
            {
                Email = "admin1@mail.com",
                Password = "s3232",
                Salt = "3213"
            });
            base.Seed(context);
        }
    }
}
