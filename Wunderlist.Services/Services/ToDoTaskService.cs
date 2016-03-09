using System;
using System.Collections.Generic;
using System.Linq;
using Wunderlist.DataAccess.Interfaces;
using Wunderlist.DataAccess.Interfaces.Entities;
using Wunderlist.Services.Interfaces.Entities;
using Wunderlist.Services.Interfaces.Services;
using Wunderlist.Services.Mapper;

namespace Wunderlist.Services.Services
{
    public class ToDoTaskService : IToDoTaskService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<TaskDalEntity> _repository;

        public ToDoTaskService(IUnitOfWork uow, IRepository<TaskDalEntity> repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));
            if (uow == null)
                throw new ArgumentNullException(nameof(uow));

            _repository = repository;
            _uow = uow;
        }
        public IEnumerable<ToDoTaskServiceEntity> GetAllTasksByListNameAndUsername(int listId)
        {
            return _repository.GetAll().Select(c => c.ToServiceEntity())
                .Where(c => c.ToDoListId == listId);
        }
    }
}
