using System.Collections.Generic;
using Wunderlist.Services.Interfaces.Entities;

namespace Wunderlist.Services.Interfaces.Services
{
    public interface IToDoTaskService
    {
        IEnumerable<ToDoTaskServiceEntity> GetAllTasksByListNameAndUsername(int listId);
        void Create(string name, int listId);
        void Delete(int taskId);
    }
}
