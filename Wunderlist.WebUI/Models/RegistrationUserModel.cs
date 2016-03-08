using System.ComponentModel.DataAnnotations;

namespace Wunderlist.WebUI.Models
{
    public class RegistrationUserModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}