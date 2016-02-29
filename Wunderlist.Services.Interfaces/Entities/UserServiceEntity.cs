namespace Wunderlist.Services.Interfaces.Entities
{
    public class UserServiceEntity : IServiceEntity
    {
        public UserServiceEntity() { }

        public UserServiceEntity(int id)
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