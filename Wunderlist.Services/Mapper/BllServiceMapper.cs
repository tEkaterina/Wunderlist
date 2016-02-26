using BLL.Interface.Entities;
using DAL.Interfaces.Entities;
using static BLL.Mapper.MapRules.Mapper;

namespace BLL.Mapper
{
    public static class BllDalMapper
    {
        static BllDalMapper()
        {
            AddRule<UserServiceEntity, UserDalEntity>();
        }

        public static UserDalEntity ToDalEntity(this UserServiceEntity userService)
        {
            return Map<UserServiceEntity, UserDalEntity>(userService);
        }
    }
}
