using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wunderlist.Services.Interfaces.Entities
{
    public class AvatarServiceEntity: IServiceEntity
    {
        public int Id { get; private set; }
        public bool IsCustom { get; set; }
        public byte[] Image { get; set; }

        public AvatarServiceEntity(int id)
        {
            Id = id;
        }

        public AvatarServiceEntity()
        {
        }
    }
}
