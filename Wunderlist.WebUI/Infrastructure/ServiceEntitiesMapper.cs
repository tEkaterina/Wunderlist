using Wunderlist.Services.Interfaces.Entities;
using Wunderlist.WebUI.Models;
using static Wunderlist.Mapper.Mapper;

namespace Wunderlist.WebUI.Infrastructure
{
    public static class ServiceEntitiesMapper
    {
        static ServiceEntitiesMapper()
        {
            AddRule<UserServiceEntity, RegistrationUserModel>();
            AddRule<RegistrationUserModel, UserServiceEntity>();
        }

        public static UserServiceEntity ToServiceEntity(this RegistrationUserModel user)
        {
            return Map<RegistrationUserModel, UserServiceEntity>(user);
        }

        public static RegistrationUserModel ToModelEntity(this UserServiceEntity user)
        {
            return Map<UserServiceEntity, RegistrationUserModel>(user);
        }
    }
}