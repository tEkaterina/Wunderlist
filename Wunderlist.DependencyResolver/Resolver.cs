using System.Data.Entity;
using BLL.Interface.Services;
using BLL.Services;
using DAL.Concrete;
using DAL.Interfaces;
using DAL.Interfaces.Entities;
using DAL.Mappers;
using DAL.Repository;
using Ninject;
using Ninject.Web.Common;
using ORM;
using ORM.Entities;

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
