using BLL.Interface;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class UserService: IUserService
    {
        private IUnitOfWork uow;
        private IRepository<UserDalEntity> repository;

        public UserService(IRepository<UserDalEntity> repository, IUnitOfWork uow)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));
            if (uow == null)
                throw new ArgumentNullException(nameof(uow));

            this.repository = repository;
            this.uow = uow;
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
            return repository.GetAll().Select(user => user.ToServiceEntity());
        }

        public void CreateUser(UserServiceEntity user)
        {
            var userDalEntity = user.ToDalEntity();
            repository.Create(userDalEntity);
            uow.Commit();
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
                repository.Update(user.ToDalEntity());
                uow.Commit();
            }
        }

        private void DeleteUser(UserDalEntity user)
        {
            if (user != null)
            {
                repository.Delete(user);
                uow.Commit();
            }
        }

        private UserDalEntity GetUserById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid user id. The id must be greater than 0", nameof(id));
            return repository.GetById(id);
        }

        private UserDalEntity GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Invalid email: email is null or empty.", nameof(email));
            return repository.GetByPredicate(user => user.Email == email);
        }
    }
}
