using BLL.Interface;
using DAL.Interfaces;
using static EntityMapper.Mapper;

namespace BLL.Mapper
{
    public static class BllServiceMapper
    {
        static BllServiceMapper()
        {
            AddRule<UserDalEntity, UserServiceEntity>();
        }

        public static UserServiceEntity ToServiceEntity(this UserDalEntity userDal)
        {
            return Map<UserDalEntity, UserServiceEntity>(userDal);
        }

    }
}
