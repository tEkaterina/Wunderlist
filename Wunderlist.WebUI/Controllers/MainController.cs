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

        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowTasks()
        {
            return PartialView("ShowAllTasks");
        }

        public ActionResult Main()
        {
            return View("Main");
        }

        public JsonResult GetToDoLists()
        {
            List<ToDoListServiceEntity> toDoLists = _toDoListService.GetAllToDoListEntities().ToList();
            return Json(toDoLists, JsonRequestBehavior.AllowGet);
        }
    }
}