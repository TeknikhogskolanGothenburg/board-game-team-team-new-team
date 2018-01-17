using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameEngine;

namespace LudoGame.Controllers
{
    public class LudoController : Controller
    {
        // GET: /Ludo/
        public ActionResult Index()
        {
            return View();
        }
    }
}