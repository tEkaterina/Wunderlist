using System.Collections.Generic;

namespace BLL.Interface
{
    public interface IUserService
    {
        UserServiceEntity GetUserEntity(int id);
        UserServiceEntity GetUserEntity(string email);
        IEnumerable<UserServiceEntity> GetAllUserEntities();

        void CreateUser(UserServiceEntity user);
        void DeleteUser(int id);
        void DeleteUser(string email);
        void UpdateUser(UserServiceEntity user);
    }
}
