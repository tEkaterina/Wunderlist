namespace Wunderlist.DataAccess.Interfaces.Entities
{
    public class UserDalEntity : IDalEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public byte[] Avatar { get; set; }
    }
}
