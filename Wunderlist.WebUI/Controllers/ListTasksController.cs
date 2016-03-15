using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Wunderlist.Services.Interfaces.Entities;
using Wunderlist.Services.Interfaces.Services;

namespace Wunderlist.WebUI.Controllers
{
    [Authorize]
    public class ListTasksController : Controller
    {
        private readonly IToDoListService _toDoListService;
        private readonly IUserService _userService;

        public ListTasksController(IToDoListService toDoListService, IUserService userService)
        {
            _toDoListService = toDoListService;
            _userService = userService;
        }

        [HttpGet]
        public JsonResult GetToDoLists()
        {
            var userEmail = HttpContext.User.Identity.Name;
            var userId = _userService.GetUserEntity(userEmail).Id;
            List<ToDoListServiceEntity> toDoLists = _toDoListService.GetAllToDoListEntitiesById(userId).ToList();
            return Json(toDoLists, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddToDoList(string name)
        {
            var userEmail = HttpContext.User.Identity.Name;
            var userId = _userService.GetUserEntity(userEmail).Id;
            _toDoListService.Create(name, userId);

            List<ToDoListServiceEntity> toDoLists = _toDoListService
                .GetAllToDoListEntitiesById(userId)
                .ToList();
            return Json(toDoLists, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult DeleteToDoList(int listItemId, string listname)
        {
            _toDoListService.Delete(listItemId);
            return GetToDoLists();
        }

        [HttpPost]
        public JsonResult RenameToDoList(int listItemId, string listname)
        {
            _toDoListService.Update(listItemId, listname);
            return GetToDoLists();
        }
    }
}