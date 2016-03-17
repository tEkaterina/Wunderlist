using System.Web.Mvc;

namespace Wunderlist.WebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Main", "Main");
            }
            return View();
        }
    }
}