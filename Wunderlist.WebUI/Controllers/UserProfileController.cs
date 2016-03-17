using System;
using System.Web.Mvc;
using Wunderlist.Services.Interfaces.Entities;
using Wunderlist.Services.Interfaces.Services;
using Wunderlist.WebUI.Infrastructure;
using Wunderlist.WebUI.Models;

namespace Wunderlist.WebUI.Controllers
{
    [Authorize]
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

        [System.Web.Mvc.HttpPut]
        public ActionResult ChangeAvatar(string image)
        {
            var avatarImg = Convert.FromBase64String(image);
            var email = HttpContext.User.Identity.Name;
            var user = _userService.GetUserEntity(email);

            var avatarEntity = _avatarService.GetByUserId(user.Id);
            if (avatarEntity == null)
            {
                CreateNewAvatar(user.Id, avatarImg);
            }
            else
            {
                UpdateAvatar(avatarEntity, avatarImg);
            }
            return Json(true);
        }

        [System.Web.Mvc.HttpPut]
        public ActionResult ChangeUsername(string newUsername)
        {
            var email = HttpContext.User.Identity.Name;
            var user = _userService.GetUserEntity(email);
            if (user.Name != newUsername)
            {
                user.Name = newUsername;
                _userService.UpdateUser(user);
            }
            return Json(true);
        }

        private void CreateNewAvatar(int userId, byte[] img)
        {
            var avatarEntity = new AvatarServiceEntity(userId)
            {
                Image = img,
                IsCustom = true
            };
            _avatarService.Create(avatarEntity);
        }

        private void UpdateAvatar(AvatarServiceEntity avatarEntity, byte[] img)
        {
            avatarEntity.Image = img;
            avatarEntity.IsCustom = true;

            _avatarService.Update(avatarEntity);
        }
    }
}