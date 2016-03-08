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

        public MainController(IToDoListService toDoListService)
        {
            _toDoListService = toDoListService;
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
            List<ToDoListServiceEntity> toDoLists = _toDoListService.GetAllToDoListEntitiesByEmail(userEmail).ToList();
            return Json(toDoLists, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddToDoList(string name)
        {
            var userEmail = HttpContext.User.Identity.Name;
            _toDoListService.Create(name, userEmail);
            List<ToDoListServiceEntity> toDoLists = _toDoListService.GetAllToDoListEntitiesByEmail(userEmail).ToList();
            return Json(toDoLists, JsonRequestBehavior.AllowGet);
        }
    }
}