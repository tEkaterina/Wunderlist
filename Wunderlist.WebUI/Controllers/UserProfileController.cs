using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wunderlist.Services.Interfaces.Services;

namespace Wunderlist.WebUI.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly IUserService _userService;

        public UserProfileController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: UserProfile
        [HttpGet]
        public ActionResult GetUserInfo()
        {
            string userEmail = HttpContext.User.Identity.Name;
            var userProfile = _userService.GetUserEntity(userEmail);
            return Json(userProfile, JsonRequestBehavior.AllowGet);
        }
    }
}