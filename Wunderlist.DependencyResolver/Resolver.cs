using System.Data.Entity;
using Wunderlist.Services.Interfaces.Services;
using Wunderlist.Services.Services;
using Wunderlist.DataAccess.Concrete;
using Wunderlist.DataAccess.Interfaces;
using Wunderlist.DataAccess.Interfaces.Entities;
using Wunderlist.DataAccess.Mappers;
using Wunderlist.DataAccess.Repository;
using Ninject;
using Ninject.Web.Common;
using Wunderlist.ORM;
using Wunderlist.ORM.Entities;

namespace DependencyResolver
{
    public static class ResolverSettings
    {
        public static void Configure(this IKernel kernel)
        {
            kernel.Bind<DbContext>().To<EntityContext>().InRequestScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

            kernel.Bind<IRepository<UserDalEntity>>().To<Repository<User, UserDalEntity>>();
            kernel.Bind<IRepository<TaskDalEntity>>().To<Repository<Task, TaskDalEntity>>();
            kernel.Bind<IRepository<TaskStatusDalEntity>>().To<Repository<TaskStatus, TaskStatusDalEntity>>();
            kernel.Bind<IRepository<ToDoListDalEntity>>().To<Repository<ToDoList, ToDoListDalEntity>>();

            kernel.Bind<IMapper<User, UserDalEntity>>().To<UserMapper>().InSingletonScope();
            //TODO: mappers for other
            
            kernel.Bind<IUserService>().To<UserService>();
            //TODO: bind other services
        }
    }
}
