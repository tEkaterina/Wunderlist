namespace Wunderlist.DataAccess.Interfaces.Entities
{
    public class UserDalEntity : IDalEntity
    {
        public UserDalEntity() { }

        public UserDalEntity(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public byte[] Avatar { get; set; }
    }
}
