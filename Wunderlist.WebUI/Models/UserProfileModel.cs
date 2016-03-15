using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wunderlist.WebUI.Models
{
    public class UserProfileModel
    {
        public string Name { get; set; }
        /// <summary>
        /// Base64String
        /// </summary>
        public string Avatar { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}