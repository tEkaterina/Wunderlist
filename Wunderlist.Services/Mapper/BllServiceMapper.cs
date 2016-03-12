using Wunderlist.Services.Interfaces.Entities;
using Wunderlist.DataAccess.Interfaces.Entities;
using static Wunderlist.Mapper.Mapper;

namespace Wunderlist.Services.Mapper
{
    public static class BllDalMapper
    {
        static BllDalMapper()
        {
            AddRule<UserServiceEntity, UserDalEntity>();
            AddRule<AvatarServiceEntity, AvatarDalEntity>();
        }

        public static UserDalEntity ToDalEntity(this UserServiceEntity userService)
        {
            return Map<UserServiceEntity, UserDalEntity>(userService);
        }

        public static AvatarDalEntity ToDalEntity(this AvatarServiceEntity avatarService)
        {
            return Map<AvatarServiceEntity, AvatarDalEntity>(avatarService);
        }
    }
}
