using Wunderlist.Services.Interfaces.Entities;

namespace Wunderlist.Services.Interfaces.Services
{
    public interface IAvatarService
    {
        AvatarServiceEntity GetByUserId(int id);
        void Create(AvatarServiceEntity avatar);
        void Update(AvatarServiceEntity avatar);
    }

}
