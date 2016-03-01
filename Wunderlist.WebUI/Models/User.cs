using System.ComponentModel.DataAnnotations;

namespace Wunderlist.WebUI.Models
{
    public class User
    {
        public int Id { get; private set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }

        public User() : this(0)
        {
        }

        public User(int id)
        {
            Id = id;
        }
    }
}