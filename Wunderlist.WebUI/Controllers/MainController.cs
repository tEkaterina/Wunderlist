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
        private readonly IToDoTaskService _toDoTaskService;

        public MainController(IToDoListService toDoListService, IUserService userService, IToDoTaskService toDoTaskService)
        {
            _toDoListService = toDoListService;
            _userService = userService;
            _toDoTaskService = toDoTaskService;
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

        [HttpPost]
        public JsonResult GetToDoItems(string listName)
        {
            var userEmail = HttpContext.User.Identity.Name;
            var userId = _userService.GetUserEntity(userEmail).Id;
            var toDoList = _toDoListService.GetAllToDoListEntitiesByEmail(userEmail, userId)
                    .FirstOrDefault(c => c.Name == listName);
            if (toDoList != null)
            {
                var tasks = _toDoTaskService.GetAllTasksByListNameAndUsername(toDoList.Id).ToList();
                return Json(tasks, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddToDoItem(string name, string listname)
        {
            var userEmail = HttpContext.User.Identity.Name;
            var userId = _userService.GetUserEntity(userEmail).Id;
            var toDoListServiceEntity = _toDoListService.GetAllToDoListEntitiesByEmail(userEmail, userId)
                .FirstOrDefault(c => c.Name == listname);
            if (toDoListServiceEntity == null)
                return Json(null, JsonRequestBehavior.AllowGet);
            var toDoListId = toDoListServiceEntity.Id;
            _toDoTaskService.Create(name, toDoListId);
            return GetToDoItems(listname);
        }

        [HttpPost]
        public JsonResult DeleteToDoItem(int taskId, string listname)
        {
            _toDoTaskService.Delete(taskId);
            var userEmail = HttpContext.User.Identity.Name;
            var userId = _userService.GetUserEntity(userEmail).Id;
            var toDoListServiceEntity = _toDoListService.GetAllToDoListEntitiesByEmail(userEmail, userId)
                .FirstOrDefault(c => c.Name == listname);
            if (toDoListServiceEntity == null)
                return Json(null, JsonRequestBehavior.AllowGet);
            return GetToDoItems(listname);
        }
    }
}