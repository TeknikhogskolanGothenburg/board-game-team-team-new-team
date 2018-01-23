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
        public ActionResult StartPage()
        {
            return View();
            //GamePlayer p1 = new GamePlayer { Name = "Jakob", Color = "Red" };
            //GamePlayer p2 = new GamePlayer { Name = "Joe", Color = "Blue" };
            //GamePlayer p3 = new GamePlayer { Name = "Kalle", Color = "Yellow" };
            //GamePlayer p4 = new GamePlayer { Name = "TheBetterJoe", Color = "Green" };

            //List<GamePlayer> onlinePlayers = new List<GamePlayer> { };
            //onlinePlayers.Add(p1);
            //onlinePlayers.Add(p2);
            //onlinePlayers.Add(p3);
            //onlinePlayers.Add(p4);
            //myGame.Players = onlinePlayers;
        }

        public ActionResult Index()
        {
            GameBoard Board = new GameBoard{};
            for(int i = 1; i <= 52; i++)
            {
                Board.GameSquares.Add(new GameSquare { NumberedName = Convert.ToString(i), Position = i });
            }
            for(int i = 1; i <= 5; i++)
            {
                Board.GameSquares.Add(new GameSquare { NumberedName = Convert.ToString(i) + "G" });
                Board.GameSquares.Add(new GameSquare { NumberedName = Convert.ToString(i) + "R"});
                Board.GameSquares.Add(new GameSquare { NumberedName = Convert.ToString(i) + "Y"});
                Board.GameSquares.Add(new GameSquare { NumberedName = Convert.ToString(i) + "B"});
            }
            
            GameDice myDice = new GameDice();
            int diceNumber = myDice.RollTheDice();
            
            Game myGame = new Game { };
            myGame.Dice = myDice;
            
            return View(myGame);
        }

       
    }
}