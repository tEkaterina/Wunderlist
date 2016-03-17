using System;
using System.Web.Mvc;
using NLog;

namespace Wunderlist.WebUI.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        private static readonly Logger Logger = LogManager.GetLogger("logfile");

        private readonly string _configErrorMessage = "Oops! Что-то пошло не так :(. Сайт временно недоступен.";
        private readonly string _notFoundErrorMessage = "Запрашиваемый файл или страница не существуют или удалены. :(";
        private readonly string _internalServerErrorMessage = "Oops! Что-то пошло не так :(. Невозможно выполнить запрашиваемую операцию.";

        public ActionResult ConfigError()
        {
            var e = Server.GetLastError();
            Server.ClearError();
            Logger.Fatal(e, "The application cannot properly complete configure: " + e?.Message ?? String.Empty);
            return View("ErrorPage", (object)_configErrorMessage);
        }
        
        public ActionResult NotFound404()
        {
            var e = Server.GetLastError();
            Server.ClearError();
            Logger.Info(e, "Cannot found a resource: " + e?.Message ?? String.Empty);
            return View("ErrorPage", (object)_notFoundErrorMessage);
        }

        public ActionResult InternalServerError500()
        {
            var e = Server.GetLastError();
            Server.ClearError();
            Logger.Error(e, e?.Message ?? String.Empty);
            return View("ErrorPage", (object)_internalServerErrorMessage);
        }
    }
}