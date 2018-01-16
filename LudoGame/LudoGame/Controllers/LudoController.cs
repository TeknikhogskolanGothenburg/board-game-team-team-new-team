using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LudoGame.Controllers
{
    public class LudoController : Controller
    {
        // GET: /Ludo/
        public ActionResult Index()
        {
            return View();
        }

        // 
        // GET: /Ludo/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}