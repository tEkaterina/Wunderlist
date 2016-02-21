namespace DAL.Interfaces.Entities
{
    public class UserDal : IDalEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public byte[] Avatar { get; set; }
    }
}
