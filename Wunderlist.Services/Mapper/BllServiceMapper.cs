using BLL.Interface.Entities;
using DAL.Interfaces.Entities;
using static BLL.Mapper.MapRules.Mapper;

namespace BLL.Mapper
{
    public static class BllDalMapper
    {
        static BllDalMapper()
        {
            AddRule<UserServiceEntity, UserDal>();
        }

        public static UserDal ToDalEntity(this UserServiceEntity userService)
        {
            return Map<UserServiceEntity, UserDal>(userService);
        }
    }
}
