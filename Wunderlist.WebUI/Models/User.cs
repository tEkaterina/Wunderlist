namespace Wunderlist.WebUI.Models
{
    public class User
    {
        public int Id { get; private set; }

        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public User() : this(0) { }

        public User(int id)
        {
            Id = id;
        }
    }
}