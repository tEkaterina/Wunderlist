using System.Collections.Generic;
using Wunderlist.Services.Interfaces.Entities;

namespace Wunderlist.Services.Interfaces.Services
{
    public interface IToDoListService
    {
        IEnumerable<ToDoListServiceEntity> GetAllToDoListEntitiesByEmail(string email, int userId);
        void Create(string name, string userEmail, int userId);
        void Delete(int listId);
        void Update(int listId, string listName);
    }
}
