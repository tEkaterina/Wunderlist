using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using Wunderlist.Services.Interfaces.Services;
using Wunderlist.WebUI.Infrastructure;
using Wunderlist.WebUI.Models;

namespace Wunderlist.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

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
        public ActionResult Singup(RegistrationUserModel user)
        {
            if (ModelState.IsValid)
            {
                var existedUser = _userService.GetUserEntity(user.Email);
                if (existedUser == null)
                {
                    var newServiceUser = user.ToServiceEntity();
                    string salt = GetSalt();

                    newServiceUser.Salt = salt;
                    newServiceUser.Password = GetPasswordHash(user.Password, salt);

                    _userService.CreateUser(newServiceUser);
                    return RedirectToAction("Main", "Main");
                }
            }
            return View(user);
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
                        return RedirectToAction("Main", "Main");
                }
                ViewBag.ErrorMessage = "Неправильный адрес электронной почты или пароль. Попробуйте ещё раз.";
            }
            return View(user);
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
    }
}