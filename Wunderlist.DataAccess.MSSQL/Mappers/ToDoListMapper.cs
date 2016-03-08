using Wunderlist.DataAccess.Interfaces;
using Wunderlist.DataAccess.Interfaces.Entities;
using Wunderlist.DataAccess.MsSql.Mappers.Property;
using Wunderlist.ORM.Entities;

namespace Wunderlist.DataAccess.MsSql.Mappers
{
    public class ToDoListMapper : IMapper<ToDoList, ToDoListDalEntity>
    {
        public ToDoList ToEntity(ToDoListDalEntity item)
        {
            return item?.ToModel();
        }

        public ToDoListDalEntity ToDal(ToDoList item)
        {
            return item?.ToDal();
        }

        public void CopyFields(ToDoListDalEntity dalEntity, ToDoList entity)
        {
            if (dalEntity == null || entity == null)
                return;
            entity.Id = (dalEntity.Id == 0) ? entity.Id : dalEntity.Id;
            entity.Name = dalEntity.Name ?? entity.Name;
            entity.UserId = (dalEntity.Id == 0) ? entity.UserId : dalEntity.UserId;
        }
    }
}
