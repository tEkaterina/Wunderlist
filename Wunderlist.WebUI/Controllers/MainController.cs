using System.Web.Mvc;

namespace Wunderlist.WebUI.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowTasks()
        {
            return PartialView("ShowAllTasks");
        }
    }
}