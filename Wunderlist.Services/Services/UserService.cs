using DAL.Interfaces;
using DAL.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mapper;

namespace BLL.Services
{
    public class UserService: IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<UserDal> _repository;

        public UserService(IUnitOfWork uow, IRepository<UserDal> repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));
            if (uow == null)
                throw new ArgumentNullException(nameof(uow));

            _repository = repository;
            _uow = uow;
        }

        public UserServiceEntity GetUserEntity(int id)
        {
            var userDalEntity = GetUserById(id);
            return userDalEntity?.ToServiceEntity();
        }

        public UserServiceEntity GetUserEntity(string email)
        {
            var userDalEntity = GetUserByEmail(email);
            return userDalEntity?.ToServiceEntity();
        }

        public IEnumerable<UserServiceEntity> GetAllUserEntities()
        {
            return _repository.GetAll().Select(user => user.ToServiceEntity());
        }

        public void CreateUser(UserServiceEntity user)
        {
            var userDalEntity = user.ToDalEntity();
            _repository.Create(userDalEntity);
            _uow.Commit();
        }

        public void DeleteUser(int id)
        {
            DeleteUser(GetUserById(id));
        }

        public void DeleteUser(string email)
        {
            DeleteUser(GetUserByEmail(email));
        }

        public void UpdateUser(UserServiceEntity user)
        {
            var updatedUser = GetUserById(user.Id);
            if (updatedUser != null)
            {
                _repository.Update(user.ToDalEntity());
                _uow.Commit();
            }
        }

        private void DeleteUser(UserDal user)
        {
            if (user != null)
            {
                _repository.Delete(user);
                _uow.Commit();
            }
        }

        private UserDal GetUserById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid user id. The id must be greater than 0", nameof(id));
            return _repository.GetById(id);
        }

        private UserDal GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Invalid email: email is null or empty.", nameof(email));
            return _repository.GetByPredicate(user => user.Email == email);
        }
    }
}
