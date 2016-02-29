using System.Collections.Generic;
using Wunderlist.Services.Interfaces.Entities;

namespace Wunderlist.Services.Interfaces.Services
{
    public interface IUserService
    {
        UserServiceEntity GetUserEntity(int id);
        UserServiceEntity GetUserEntity(string email);
        IEnumerable<UserServiceEntity> GetAllUserEntities();

        void CreateUser(UserServiceEntity user);
        void UpdateUser(UserServiceEntity user);
        void DeleteUser(int id);
    }
}
