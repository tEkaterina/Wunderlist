using BLL.Interface.Entities;
using DAL.Interfaces.Entities;
using static BLL.Mapper.MapRules.Mapper;

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
