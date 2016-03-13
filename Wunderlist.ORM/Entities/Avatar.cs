using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wunderlist.ORM.Entities
{
    public class Avatar
    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }
        public virtual User User { get; set; }

        public bool IsCustom { get; set; }
        public byte[] Image { get; set; }

    }
}
