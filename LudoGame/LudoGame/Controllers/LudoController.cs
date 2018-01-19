using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameEngine;
using LudoGame.Models;

namespace LudoGame.Controllers
{
    public class LudoController : Controller
    {
        // GET: /Ludo/
        public ActionResult Index()
        {
            GameDice myDice = new GameDice();
            int diceNumber = myDice.RollTheDice();
            Dice dice = new Dice
            {
                Value = diceNumber
            };

            return View(dice);
        }
    }
}