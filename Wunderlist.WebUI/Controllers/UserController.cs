using Wunderlist.Services.Interfaces;
using System.Web.Mvc;
using Wunderlist.Services.Interfaces.Services;
using Wunderlist.WebUI.Models;

namespace Wunderlist.WebUI.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: User
        [HttpGet]
        public ActionResult Singup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Singup(User user)
        {
            if (ModelState.IsValid)
            {
                var existedUser = _userService.GetUserEntity(user.Email);
                if (existedUser == null)
                {
                    _userService.CreateUser(null);
                }
            }
            return new EmptyResult();
        }

        [HttpGet]
        public ActionResult Singin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Singin(User user)
        {
            if (ModelState.IsValid)
            {

            }
            return new EmptyResult();
        }
    }
}