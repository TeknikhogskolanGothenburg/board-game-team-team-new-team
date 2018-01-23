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
        public static Game myGame = new Game { };
        public static int counter = 0;
        public static bool red = false;
        public static bool green = false;
        public static bool yellow = false;
        public static bool  blue = false;

        // GET: /Ludo/
        public ActionResult StartPage()
        {
            string userNickName = Request.Form["myTextBox"];
            string userColorChoice = Request.Form["colorChoice"];

            if (counter <= 4 && userNickName != null && userColorChoice != null)
            {
                
                //myGame.Players.Add(new GamePlayer { Name = ""/*Example variable*/, Color = ""/*colorChoice*/ });
                myGame.Players.Add(new GamePlayer { Name = userNickName, Color = userColorChoice });
                counter++;
            }
            if (myGame.Players.Count > 0)
            {
                foreach (GameEngine.GamePlayer player in LudoGame.Controllers.LudoController.myGame.Players)
                {
                    if (player.Color == "Red")
                    {
                        @LudoGame.Controllers.LudoController.red = true;
                    }
                    if (player.Color == "Yellow")
                    {
                        @LudoGame.Controllers.LudoController.yellow = true;
                    }
                    if (player.Color == "Blue")
                    {
                        @LudoGame.Controllers.LudoController.blue = true;
                    }
                    if (player.Color == "Green")
                    {
                        @LudoGame.Controllers.LudoController.green = true;
                    }
                }
            }
            return View(myGame);
            

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
            myDice.Value = myDice.RollTheDice();
            myGame.Dice = myDice;
            
            return View(myGame);
        }

       
    }
}