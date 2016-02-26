using DAL.Interfaces;
using DAL.Interfaces.Entities;
using DAL.Mappers.Property;
using ORM.Entities;

namespace DAL.Mappers
{
    public class UserMapper : IMapper<User, UserDalEntity>
    {
        public User ToEntity(UserDalEntity item)
        {
            return item?.ToModel();
        }

        public UserDalEntity ToDal(User item)
        {
            return item?.ToDal();
        }

        public void CopyFields(UserDalEntity dalEntity, User entity)
        {
            if (dalEntity == null || entity == null)
                return;
            entity.Id = (dalEntity.Id == 0) ? entity.Id : dalEntity.Id;
            entity.Name = dalEntity.Name ?? entity.Name;
            entity.Password = dalEntity.Password ?? entity.Password;
            entity.Salt = dalEntity.Salt ?? entity.Salt;
            entity.Email = dalEntity.Email ?? entity.Email;
            entity.Avatar = dalEntity.Avatar ?? entity.Avatar;
        }
    }
}
