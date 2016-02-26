using BLL.Interface.Entities;
using DAL.Interfaces.Entities;
using static BLL.Mapper.MapRules.Mapper;

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
