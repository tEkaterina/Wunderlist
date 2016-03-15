using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using Wunderlist.Services.Interfaces.Entities;
using Wunderlist.Services.Interfaces.Services;
using Wunderlist.WebUI.Infrastructure;
using Wunderlist.WebUI.Models;

namespace Wunderlist.WebUI.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAvatarService _avatarService;

        public UserController(IUserService userService, IAvatarService avatarService)
        {
            _userService = userService;
            _avatarService = avatarService;
        }

        // GET: User
        [HttpGet]
        public ActionResult Singup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Singup(RegistrationUserModel user)
        {
            if (ModelState.IsValid)
            {
                var existedUser = _userService.GetUserEntity(user.Email);
                if (existedUser == null)
                {
                    CreateUser(user);

                    var createdUser = _userService.GetUserEntity(user.Email);
                    CreateUserAvatar(createdUser);
                }
            }
            FormsAuthentication.SetAuthCookie(user.Email, true);
            return RedirectToAction("Main", "Main");
        }

        [HttpGet]
        public ActionResult Singin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Singin(SinginUserModel user)
        {
            if (ModelState.IsValid)
            {
                var existedUser = _userService.GetUserEntity(user.Email);
                if (existedUser != null)
                {
                    var singinPassHash = GetPasswordHash(user.Password, existedUser.Salt);
                    if (singinPassHash == existedUser.Password)
                    {
                        FormsAuthentication.SetAuthCookie(user.Email, true);
                        return RedirectToAction("Main", "Main");
                    }
                    ViewBag.ErrorMessage = "Неправильный адрес электронной почты или пароль. Попробуйте ещё раз.";
                }
                return RedirectToAction("Singup");
            }
            return View(user);
        }

        [HttpPut]
        public JsonResult Logout()
        {
            FormsAuthentication.SignOut();
            return Json("/Home/Index");
        }

        private string GetSalt()
        {
            var random = new Random();
            var saltBytes = new byte[sizeof(int)];

            random.NextBytes(saltBytes);

            return Encoding.Unicode.GetString(saltBytes);
        }

        private string GetPasswordHash(string password, string salt)
        {
            password += salt;
            var sha1 = new SHA1CryptoServiceProvider();
            var hash = sha1.ComputeHash(Encoding.Unicode.GetBytes(password));

            return Encoding.Unicode.GetString(hash);
        }

        private void CreateUser(RegistrationUserModel user)
        {
            var newServiceUser = user.ToServiceEntity();
            string salt = GetSalt();

            newServiceUser.Salt = salt;
            newServiceUser.Password = GetPasswordHash(user.Password, salt);

            _userService.CreateUser(newServiceUser);
        }

        private void CreateUserAvatar(UserServiceEntity user)
        {
            var avatar = new AvatarServiceEntity(user.Id)
            {
                Image = AvatarCreator.Get(user.Name),
                IsCustom = false
            };
            _avatarService.Create(avatar);
        }
    }
}