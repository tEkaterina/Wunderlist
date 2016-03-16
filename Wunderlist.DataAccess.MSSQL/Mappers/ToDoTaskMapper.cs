using System;
using Wunderlist.DataAccess.Interfaces;
using Wunderlist.DataAccess.Interfaces.Entities;
using Wunderlist.DataAccess.MsSql.Mappers.Property;
using Wunderlist.ORM.Entities;

namespace Wunderlist.DataAccess.MsSql.Mappers
{
    public class ToDoTaskMapper : IMapper<TaskDbModel, TaskDalEntity>
    {
        public TaskDbModel ToEntity(TaskDalEntity item)
        {
            return item?.ToModel();
        }

        public TaskDalEntity ToDal(TaskDbModel item)
        {
            return item?.ToDal();
        }

        public void CopyFields(TaskDalEntity dalEntity, TaskDbModel entity)
        {
            if (dalEntity == null || entity == null)
                return;
            entity.Id = (dalEntity.Id == 0) ? entity.Id : dalEntity.Id;
            entity.Name = dalEntity.Name ?? entity.Name;
            entity.ToDoListId = (dalEntity.ToDoListId == 0) ? entity.ToDoListId : dalEntity.ToDoListId;
            entity.TaskStatusId = (dalEntity.TaskStatusId == 0) ? entity.TaskStatusId : dalEntity.TaskStatusId;
            entity.Note = dalEntity.Note ?? entity.Note ?? string.Empty;
            entity.DueDate = dalEntity.DueDate ?? entity.DueDate;
        }
    }
}
