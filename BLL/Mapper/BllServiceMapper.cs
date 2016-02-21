using BLL.Interface;
using DAL.Interfaces;
using static EntityMapper.Mapper;

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
