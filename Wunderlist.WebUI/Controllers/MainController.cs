using System.Web.Mvc;

namespace Wunderlist.WebUI.Controllers
{
    public class MainController : Controller
    {
        [Authorize]
        public ActionResult Main()
        {
            return View("Main");
        }
    }
}