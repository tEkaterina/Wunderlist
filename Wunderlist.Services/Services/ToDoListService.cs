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
    public class ToDoListService : IToDoListService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<ToDoListDalEntity> _repository;
        private readonly IRepository<TaskDalEntity> _taskRepository; 

        public ToDoListService(IUnitOfWork uow, IRepository<ToDoListDalEntity> repository, IRepository<TaskDalEntity> taskRepository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));
            if (uow == null)
                throw new ArgumentNullException(nameof(uow));

            _taskRepository = taskRepository;
            _repository = repository;
            _uow = uow;
        }
        public IEnumerable<ToDoListServiceEntity> GetAllToDoListEntitiesById(int userId)
        {
            return _repository.GetAll().Select(list => list.ToServiceEntity())
                .Where(list => list.UserId == userId);
        }

        public void Create(string name, int userId)
        {
            _repository.Create(new ToDoListDalEntity
            {
                Name = name,
                UserId = userId
            });
            _uow.Commit();
        }

        public void Delete(int listId)
        {
            var listEntity = _repository.GetById(listId);
            if (listEntity != null)
            {
                var listTasks = _taskRepository.GetAll().Select(c => c)
                    .Where(c => c.ToDoListId == listId);
                foreach (var item in listTasks)
                {
                    _taskRepository.Delete(item);
                }
                _repository.Delete(listEntity);
            }
            _uow.Commit();
        }

        public void Update(int listId, string listName)
        {
            var entity = _repository.GetById(listId);
            entity.Name = listName;
            _repository.Update(entity);
            _uow.Commit();
        }
    }
}
