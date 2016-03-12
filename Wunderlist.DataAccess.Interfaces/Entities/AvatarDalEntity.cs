namespace Wunderlist.DataAccess.Interfaces.Entities
{
    public class AvatarDalEntity: IDalEntity
    {
        public int Id { get; private set; }
        public byte[] Image { get; set; }
        public bool IsCustom { get; set; }

        public AvatarDalEntity(int id)
        {
            Id = id;
        }

        public AvatarDalEntity() { }
    }
}
