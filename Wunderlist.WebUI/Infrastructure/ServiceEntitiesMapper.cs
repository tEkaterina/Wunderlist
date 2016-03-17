using Wunderlist.Services.Interfaces.Entities;
using Wunderlist.WebUI.Models;
using static Wunderlist.Mapper.Mapper;

namespace Wunderlist.WebUI.Infrastructure
{
    public static class ServiceEntitiesMapper
    {
        static ServiceEntitiesMapper()
        {
            AddRule<UserServiceEntity, UserProfileModel>();
            AddRule<UserProfileModel, UserServiceEntity>();
        }

        public static UserServiceEntity ToServiceEntity(this UserProfileModel user)
        {
            return Map<UserProfileModel, UserServiceEntity>(user);
        }

        public static UserProfileModel ToModelEntity(this UserServiceEntity user)
        {
            return Map<UserServiceEntity, UserProfileModel>(user);
        }
    }
}