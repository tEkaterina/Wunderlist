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
        }

        public static UserServiceEntity ToServiceEntity(this UserDalEntity userDal)
        {
            return Map<UserDalEntity, UserServiceEntity>(userDal);
        }

        public static ToDoListServiceEntity ToServiceEntity(this ToDoListDalEntity toDoListDal)
        {
            return Map<ToDoListDalEntity, ToDoListServiceEntity>(toDoListDal);
        }
    }
}
