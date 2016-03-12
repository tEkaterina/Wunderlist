using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wunderlist.ORM.Entities
{
    public class Avatar
    {
        [Key]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public bool IsCustom { get; set; }
        public byte[] Image { get; set; }

    }
}
