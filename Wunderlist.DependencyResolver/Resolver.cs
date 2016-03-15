using System.Data.Entity;
using Wunderlist.Services.Interfaces.Services;
using Wunderlist.Services.Services;
using Wunderlist.DataAccess.MsSql.Concrete;
using Wunderlist.DataAccess.Interfaces;
using Wunderlist.DataAccess.Interfaces.Entities;
using Wunderlist.DataAccess.MsSql.Mappers;
using Wunderlist.DataAccess.MsSql.Repository;
using Ninject;
using Ninject.Web.Common;
using Wunderlist.ORM;
using Wunderlist.ORM.Entities;

namespace Wunderlist.DependencyResolver
{
    public static class ResolverSettings
    {
        public static void Configure(this IKernel kernel)
        {
            kernel.Bind<DbContext>().To<EntityContext>().InRequestScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

            kernel.Bind<IRepository<UserDalEntity>>().To<Repository<User, UserDalEntity>>();
            kernel.Bind<IRepository<TaskDalEntity>>().To<Repository<TaskDbModel, TaskDalEntity>>();
            kernel.Bind<IRepository<TaskStatusDalEntity>>().To<Repository<TaskStatus, TaskStatusDalEntity>>();
            kernel.Bind<IRepository<ToDoListDalEntity>>().To<Repository<ToDoList, ToDoListDalEntity>>();
            kernel.Bind<IRepository<AvatarDalEntity>>().To<Repository<Avatar, AvatarDalEntity>>();

            kernel.Bind<IMapper<User, UserDalEntity>>().To<UserMapper>().InSingletonScope();
            kernel.Bind<IMapper<ToDoList, ToDoListDalEntity>>().To<ToDoListMapper>().InSingletonScope();
            kernel.Bind<IMapper<TaskDbModel, TaskDalEntity>>().To<ToDoTaskMapper>().InSingletonScope();
            kernel.Bind<IMapper<Avatar, AvatarDalEntity>>().To<AvatarMapper>().InSingletonScope();
            //TODO: mappers for other

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IToDoListService>().To<ToDoListService>();
            kernel.Bind<IToDoTaskService>().To<ToDoTaskService>();
            kernel.Bind<IAvatarService>().To<AvatarService>();
            //TODO: bind other services
        }
    }
}
