using DAL.Interfaces.Entities;
using ORM.Entities;

namespace DAL.Mappers.Property
{
    public static class MapperProperty
    {
        #region DAL to Model

        public static User ToModel(this UserDalEntity item)
        {
            User userEntity = new User
            {
                Id = item.Id,
                Name = item.Name,
                Password = item.Password,
                Avatar = item.Avatar,
                Email = item.Email,
                Salt = item.Salt
            };
            return userEntity;
        }

        #endregion

        #region Model to DAL

        public static UserDalEntity ToDal(this User item)
        {
            UserDalEntity userDalEntity = new UserDalEntity
            {
                Id = item.Id,
                Name = item.Name,
                Password = item.Password,
                Avatar = item.Avatar,
                Email = item.Email,
                Salt = item.Salt
            };
            return userDalEntity;
        }

        #endregion
    }
}
