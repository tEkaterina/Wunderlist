using System.Collections.Generic;
using Wunderlist.Services.Interfaces.Entities;

namespace Wunderlist.Services.Interfaces.Services
{
    public interface IToDoListService
    {
        IEnumerable<ToDoListServiceEntity> GetAllToDoListEntitiesById(int userId);
        void Create(string name, int userId);
        void Delete(int listId);
        void Update(int listId, string listName);
    }
}
