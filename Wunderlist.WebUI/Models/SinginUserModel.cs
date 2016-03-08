using System.ComponentModel.DataAnnotations;

namespace Wunderlist.WebUI.Models
{
    public class SinginUserModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}