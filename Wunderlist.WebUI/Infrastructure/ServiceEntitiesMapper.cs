using Wunderlist.Services.Interfaces.Entities;
using Wunderlist.WebUI.Models;
using static Wunderlist.Mapper.Mapper;

namespace Wunderlist.WebUI.Infrastructure
{
    public static class ServiceEntitiesMapper
    {
        static ServiceEntitiesMapper()
        {
            AddRule<UserServiceEntity, User>();
            AddRule<User, UserServiceEntity>();
        }

        public static UserServiceEntity ToServiceEntity(this User user)
        {
            return Map<User, UserServiceEntity>(user);
        }

        public static User ToModelEntity(this UserServiceEntity user)
        {
            return Map<UserServiceEntity, User>(user);
        }
    }
}