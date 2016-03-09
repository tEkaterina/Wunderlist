using Wunderlist.Services.Interfaces.Entities;
using Wunderlist.DataAccess.Interfaces.Entities;
using static Wunderlist.Mapper.Mapper;

namespace Wunderlist.Services.Mapper
{
    public static class BllServiceMapper
    {
        static BllServiceMapper()
        {
            AddRule<UserDalEntity, UserServiceEntity>();
            AddRule<ToDoListDalEntity, ToDoListServiceEntity>();
            AddRule<TaskDalEntity, ToDoTaskServiceEntity>();
        }

        public static UserServiceEntity ToServiceEntity(this UserDalEntity userDal)
        {
            return Map<UserDalEntity, UserServiceEntity>(userDal);
        }

        public static ToDoListServiceEntity ToServiceEntity(this ToDoListDalEntity toDoListDal)
        {
            return Map<ToDoListDalEntity, ToDoListServiceEntity>(toDoListDal);
        }

        public static ToDoTaskServiceEntity ToServiceEntity(this TaskDalEntity toDoTaskDal)
        {
            return Map<TaskDalEntity, ToDoTaskServiceEntity>(toDoTaskDal);
        }
    }
}
