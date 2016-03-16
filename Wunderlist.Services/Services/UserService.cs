using Wunderlist.DataAccess.Interfaces;
using Wunderlist.DataAccess.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Wunderlist.Services.Interfaces.Entities;
using Wunderlist.Services.Interfaces.Services;
using Wunderlist.Services.Mapper;

namespace Wunderlist.Services.Services
{
    public class UserService: IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<UserDalEntity> _repository;

        public UserService(IUnitOfWork uow, IRepository<UserDalEntity> repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));
            if (uow == null)
                throw new ArgumentNullException(nameof(uow));

            _repository = repository;
            _uow = uow;
        }

        public UserServiceEntity GetUserEntity(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("User email is null or empty.", nameof(email));

            var userDalEntity = GetUserByEmail(email);
            return userDalEntity?.ToServiceEntity();
        }

        public void CreateUser(UserServiceEntity user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var userDalEntity = user.ToDalEntity();
            _repository.Create(userDalEntity);
            _uow.Commit();
        }
        
        public void UpdateUser(UserServiceEntity user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var updatedUser = GetUserById(user.Id);

            if (updatedUser == null)
                throw  new ArgumentException($"User with id = {user.Id} cannot be found.", nameof(user));

            _repository.Update(user.ToDalEntity());
            _uow.Commit();
            
        }
        
        private UserDalEntity GetUserById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("User id must be greater than 0", nameof(id));

            return _repository.GetById(id);
        }

        private UserDalEntity GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("User email is null or empty.", nameof(email));

            return _repository.GetByPredicate(user => user.Email == email);
        }
    }
}
