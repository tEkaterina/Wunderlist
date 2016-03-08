using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Wunderlist.Services.Interfaces.Entities;
using Wunderlist.Services.Interfaces.Services;

namespace Wunderlist.WebUI.Controllers
{
    public class MainController : Controller
    {
        private readonly IToDoListService _toDoListService;
        private readonly IUserService _userService;

        public MainController(IToDoListService toDoListService, IUserService userService)
        {
            _toDoListService = toDoListService;
            _userService = userService;
        }

        [Authorize]
        public ActionResult Main()
        {
            return View("Main");
        }

        [Authorize]
        [HttpGet]
        public JsonResult GetToDoLists()
        {
            var userEmail = HttpContext.User.Identity.Name;
            var userId = _userService.GetUserEntity(userEmail).Id;
            List<ToDoListServiceEntity> toDoLists = _toDoListService.GetAllToDoListEntitiesByEmail(userEmail, userId).ToList();
            return Json(toDoLists, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddToDoList(string name)
        {
            var userEmail = HttpContext.User.Identity.Name;
            var userId = _userService.GetUserEntity(userEmail).Id;
            _toDoListService.Create(name, userEmail, userId);
            List<ToDoListServiceEntity> toDoLists = _toDoListService.GetAllToDoListEntitiesByEmail(userEmail, userId).ToList();
            return Json(toDoLists, JsonRequestBehavior.AllowGet);
        }
    }
}