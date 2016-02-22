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

            kernel.Bind<IRepository<UserDal>>().To<Repository<User, UserDal>>().InRequestScope();
            kernel.Bind<IRepository<TaskDal>>().To<Repository<Task, TaskDal>>().InRequestScope();
            kernel.Bind<IRepository<TaskStatusDal>>().To<Repository<TaskStatus, TaskStatusDal>>().InRequestScope();
            kernel.Bind<IRepository<ToDoListDal>>().To<Repository<ToDoList, ToDoListDal>>().InRequestScope();

            kernel.Bind<IMapper<User, UserDal>>().To<UserMapper>().InSingletonScope();
            //TODO: mappers for other

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

            kernel.Bind<IUserService>().To<UserService>().InRequestScope();
            //TODO: bind other services
        }
    }
}
