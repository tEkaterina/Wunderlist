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
        private readonly IUserService _userService;

        public ToDoListService(IUnitOfWork uow, IRepository<ToDoListDalEntity> repository, IUserService userService)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));
            if (uow == null)
                throw new ArgumentNullException(nameof(uow));

            _repository = repository;
            _userService = userService;
            _uow = uow;
        }
        public IEnumerable<ToDoListServiceEntity> GetAllToDoListEntitiesByEmail(string email)
        {
            var userId = _userService.GetUserEntity(email);
            return _repository.GetAll().Select(list => list.ToServiceEntity()).Where(list => list.UserId == userId.Id);
        }
    }
}
