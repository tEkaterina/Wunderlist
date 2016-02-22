using BLL.Interface;
using BLL.Interface.Entities;
using DAL.Interfaces.Entities;
using static EntityMapper.Mapper;

namespace BLL.Mapper
{
    public static class BllServiceMapper
    {
        static BllServiceMapper()
        {
            AddRule<UserDal, UserServiceEntity>();
        }

        public static UserServiceEntity ToServiceEntity(this UserDal userDal)
        {
            return Map<UserDal, UserServiceEntity>(userDal);
        }

    }
}
