using System.Collections.Generic;
using Wunderlist.Services.Interfaces.Entities;

namespace Wunderlist.Services.Interfaces.Services
{
    public interface IToDoTaskService
    {
        IEnumerable<ToDoTaskServiceEntity> GetAllTasksByListNameAndStatusId(int listId, int statusId);
        void Create(string name, int listId);
        void Delete(int taskId);
        void Update(int taskId, string taskName, int statusId);
        ToDoTaskServiceEntity GetTaskById(int taskId);
    }
}
