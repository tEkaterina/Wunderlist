﻿using Wunderlist.DataAccess.Interfaces.Entities;
using Wunderlist.ORM.Entities;

namespace Wunderlist.DataAccess.MsSql.Mappers.Property
{
    public static class MapperProperty
    {
        #region Wunderlist.DataAccess.MsSql to Model

        public static User ToModel(this UserDalEntity item)
        {
            User userEntity = new User
            {
                Id = item.Id,
                Name = item.Name,
                Password = item.Password,
                Email = item.Email,
                Salt = item.Salt
            };
            return userEntity;
        }

        public static ToDoList ToModel(this ToDoListDalEntity item)
        {
            ToDoList toDoListEntity = new ToDoList
            {
                Id = item.Id,
                Name = item.Name,
                UserId = item.UserId
            };
            return toDoListEntity;
        }

        public static TaskDbModel ToModel(this TaskDalEntity item)
        {
            TaskDbModel toDoTaskEntity = new TaskDbModel
            {
                Id = item.Id,
                Name = item.Name,
                ToDoListId = item.ToDoListId,
                DueDate = item.DueDate,
                TaskStatusId = item.TaskStatusId,
                Note = item.Note
            };
            return toDoTaskEntity;
        }

        public static Avatar ToModel(this AvatarDalEntity avatar)
        {
            return new Avatar()
            {
                Id = avatar.Id,
                Image = avatar.Image,
                IsCustom = avatar.IsCustom,
            };
        }

        #endregion

        #region Model to Wunderlist.DataAccess.MsSql

        public static UserDalEntity ToDal(this User item)
        {
            UserDalEntity userDalEntity = new UserDalEntity(item.Id)
            {
                Name = item.Name,
                Password = item.Password,
                Email = item.Email,
                Salt = item.Salt
            };
            return userDalEntity;
        }

        public static ToDoListDalEntity ToDal(this ToDoList item)
        {
            ToDoListDalEntity toDoListDalEntity = new ToDoListDalEntity(item.Id)
            {
                Name = item.Name,
                UserId = item.UserId
            };
            return toDoListDalEntity;
        }

        public static TaskDalEntity ToDal(this TaskDbModel item)
        {
            TaskDalEntity toDoTaskEntity = new TaskDalEntity(item.Id)
            {
                Name = item.Name,
                ToDoListId = item.ToDoListId,
                DueDate = item.DueDate,
                TaskStatusId = item.TaskStatusId,
                Note = item.Note
            };
            return toDoTaskEntity;
        }

        public static AvatarDalEntity ToDal(this Avatar avatar)
        {
            var avatarDalEntity = new AvatarDalEntity(avatar.Id)
            {
                Image = avatar.Image,
                IsCustom = avatar.IsCustom,
            };
            return avatarDalEntity;
        }

        #endregion
    }
}
