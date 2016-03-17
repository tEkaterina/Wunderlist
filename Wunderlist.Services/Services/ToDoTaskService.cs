﻿using System;
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
        public IEnumerable<ToDoTaskServiceEntity> GetAllTasksByListIdAndStatusId(int listId, int statusId)
        {
            return _repository.GetAll().Select(c => c.ToServiceEntity())
                .Where(c => c.ToDoListId == listId)
                .Where(c => c.TaskStatusId == statusId);
        }

        public void Create(string name, int listId)
        {
            _repository.Create(new TaskDalEntity
            {
                DueDate = DateTime.Now,
                Name = name,
                ToDoListId = listId,
                TaskStatusId = 1
            });
            _uow.Commit();
        }

        public void Delete(int taskId)
        {
            var task = _repository.GetById(taskId);
            if (task != null)
                _repository.Delete(task);
            _uow.Commit();
        }

        public void Update(int taskId, string taskName, int statusId)
        {
            var entity = _repository.GetById(taskId);
            entity.Name = taskName;
            entity.TaskStatusId = statusId;
            _repository.Update(entity);
            _uow.Commit();
        }

        public void SaveDueDate(int taskId)
        {
            var entity = _repository.GetById(taskId);
            DateTime time = DateTime.Now;
            entity.DueDate = time;
            _repository.Update(entity);
            _uow.Commit();
        }

        public void SaveNote(int taskId, string note)
        {
            var entity = _repository.GetById(taskId);
            entity.Note = note;
            _repository.Update(entity);
            _uow.Commit();
        }

        public ToDoTaskServiceEntity GetTaskById(int taskId)
        {
            return _repository.GetById(taskId).ToServiceEntity();
        }
    }
}
