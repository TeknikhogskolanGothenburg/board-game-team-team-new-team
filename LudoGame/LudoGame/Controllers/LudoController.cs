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
            GamePlayer p1 = new GamePlayer { Name = "Jakob", Color = "Red" };
            GamePlayer p2 = new GamePlayer { Name = "Joe", Color = "Blue" };
            GamePlayer p3 = new GamePlayer { Name = "Kalle", Color = "Yellow" };
            GamePlayer p4 = new GamePlayer { Name = "TheBetterJoe", Color = "Green" };

            Players onlinePlayers = new Players{};
            onlinePlayers.GamePlayers.Add(p1);
            onlinePlayers.GamePlayers.Add(p2);
            onlinePlayers.GamePlayers.Add(p3);
            onlinePlayers.GamePlayers.Add(p4);

            GameDice myDice = new GameDice();
            int diceNumber = myDice.RollTheDice();
            Dice dice = new Dice
            {
                Value = diceNumber
            };
            Overview all = new Overview { };
            all.combinedDice = dice;
            all.combinedPlayers = onlinePlayers;

            return View(all);
        }
    }
}