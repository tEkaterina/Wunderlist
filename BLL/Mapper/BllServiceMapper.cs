using BLL.Interface;
using DAL.Interfaces;
using DAL.Interfaces.Entities;
using static EntityMapper.Mapper;

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
