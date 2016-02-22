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

            kernel.Bind<IRepository<UserDal>>().To<Repository<User, UserDal>>();
            kernel.Bind<IRepository<TaskDal>>().To<Repository<Task, TaskDal>>();
            kernel.Bind<IRepository<TaskStatusDal>>().To<Repository<TaskStatus, TaskStatusDal>>();
            kernel.Bind<IRepository<ToDoListDal>>().To<Repository<ToDoList, ToDoListDal>>();

            kernel.Bind<IMapper<User, UserDal>>().To<UserMapper>().InSingletonScope();
            //TODO: mappers for other
            
            kernel.Bind<IUserService>().To<UserService>();
            //TODO: bind other services
        }
    }
}
