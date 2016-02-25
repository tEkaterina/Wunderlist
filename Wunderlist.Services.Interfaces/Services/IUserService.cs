using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
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
