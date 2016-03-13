using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wunderlist.Services.Interfaces.Services;
using Wunderlist.WebUI.Models;

namespace Wunderlist.WebUI.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAvatarService _avatarService;

        public UserProfileController(IUserService userService, IAvatarService avatarService)
        {
            _userService = userService;
            _avatarService = avatarService;
        }
        
        public ActionResult GetUserInfo()
        {
            string userEmail = HttpContext.User.Identity.Name;
            var user = _userService.GetUserEntity(userEmail);
            var avatar = _avatarService.GetByUserId(user.Id);

            var userProfile = new UserProfileModel()
            {
                Name = user.Name,
                Avatar = Convert.ToBase64String(avatar.Image),
            };

            return Json(userProfile, JsonRequestBehavior.AllowGet);
        }
    }
}