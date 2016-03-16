using System.Collections.Generic;
using Wunderlist.Services.Interfaces.Entities;

namespace Wunderlist.Services.Interfaces.Services
{
    public interface IUserService
    {
        UserServiceEntity GetUserEntity(string email);

        void CreateUser(UserServiceEntity user);
        void UpdateUser(UserServiceEntity user);
    }
}
