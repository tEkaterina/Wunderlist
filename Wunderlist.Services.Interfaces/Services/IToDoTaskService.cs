using System.Collections.Generic;
using Wunderlist.Services.Interfaces.Entities;

namespace Wunderlist.Services.Interfaces.Services
{
    public interface IToDoTaskService
    {
        IEnumerable<ToDoTaskServiceEntity> GetAllTasksByListNameAndUsername(int listId);
    }
}
