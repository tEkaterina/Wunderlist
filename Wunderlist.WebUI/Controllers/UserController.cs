﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wunderlist.WebUI.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Singup()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Singin()
        {
            return View();
        }
    }
}