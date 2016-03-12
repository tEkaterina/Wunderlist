using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wunderlist.DataAccess.Interfaces;
using Wunderlist.DataAccess.Interfaces.Entities;
using Wunderlist.DataAccess.MsSql.Mappers.Property;
using Wunderlist.ORM.Entities;
using static Wunderlist.Mapper.Mapper;

namespace Wunderlist.DataAccess.MsSql.Mappers
{
    public class AvatarMapper : IMapper<Avatar, AvatarDalEntity>
    {
        static AvatarMapper()
        {
            AddRule<AvatarDalEntity, Avatar>(
                (entity, avatar) =>
                {
                    avatar.UserId = entity.Id;
                });
        }

        public void CopyFields(AvatarDalEntity dalEntity, Avatar entity)
        {
            Map(dalEntity, entity);
        }

        public AvatarDalEntity ToDal(Avatar item)
        {
            return item?.ToDal();
        }

        public Avatar ToEntity(AvatarDalEntity item)
        {
            return item?.ToModel();
        }
    }
}
