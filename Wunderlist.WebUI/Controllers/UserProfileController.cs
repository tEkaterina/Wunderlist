using System;
using System.Web.Mvc;
using Wunderlist.Services.Interfaces.Entities;
using Wunderlist.Services.Interfaces.Services;
using Wunderlist.WebUI.Infrastructure;
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

        [HttpGet]
        public ActionResult GetUserInfo()
        {
            string userEmail = HttpContext.User.Identity.Name;
            var user = _userService.GetUserEntity(userEmail);
            var avatar = _avatarService.GetByUserId(user.Id);
            if (avatar == null)
            {
                avatar = new AvatarServiceEntity()
                {
                    Image = AvatarCreator.Get(user.Name),
                };
            }

            var userProfile = new UserProfileModel()
            {
                Name = user.Name,
                Avatar = Convert.ToBase64String(avatar.Image),
            };

            return Json(userProfile, JsonRequestBehavior.AllowGet);
        }
    }
}