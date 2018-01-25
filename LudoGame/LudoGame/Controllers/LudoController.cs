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
        public static Game myGame = new Game {};
        public static int counter = 0;
        public static bool red = false;
        public static bool green = false;
        public static bool yellow = false;
        public static bool blue = false;
        public static int turnCounter = 1;

        // GET: /Ludo/
        public ActionResult StartPage()
        {
            string userGameName = Request.Form["myGametxtBox"];
            string userNickName = Request.Form["myTextBox"];
            string userColorChoice = Request.Form["colorChoice"];

            if(Request.Cookies["UserCookie"] == null)
            {
                HttpCookie myCookie = new HttpCookie("UserCookie");
                Guid guid = Guid.NewGuid();
                myCookie.Value = guid.ToString();
                myCookie.Expires = DateTime.Now.AddDays(10);
                Response.SetCookie(myCookie);
            }

            if (counter < 4 && userNickName != null && userColorChoice != null)
            {
                
                //myGame.Players.Add(new GamePlayer { Name = ""/*Example variable*/, Color = ""/*colorChoice*/ });
                myGame.Players.Add(new GamePlayer { Name = userNickName, Color = userColorChoice, PlayerID = Request.Cookies["UserCookie"].Value });
                myGame.Players[0].Turn = true;
                myGame.Players[0].CanThrow = true;
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
            if (myGame.Players.Count > 0 && userNickName != null && userColorChoice != null)
            {
                return RedirectToAction("Index");
            }
            return View(myGame);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View(myGame);
        }

        public ActionResult RollDice()
        {
            foreach (GamePlayer player in myGame.Players)
            {
                if (player.Turn == true && player.CanThrow == true)
                {
                    myGame.Dice.Value = myGame.Dice.RollTheDice();
                    player.CanThrow = false;
                    player.CanMove = true;
                }
            }
            return RedirectToAction("Index", "Ludo");
        }

        public ActionResult MovePiece1()
        {
            foreach(GamePlayer player in myGame.Players)
            {
                player.One.MovePiece(player, myGame.Dice, player.One);
                if (myGame.Dice.Value == 6 && player.Turn == true)
                {
                    player.CanThrow = true;
                    player.CanMove = false;
                }
                else
                {
                    if (player.Turn == true)
                    {
                        player.Turn = false;
                        player.CanMove = false;
                    }
                    
                    foreach(GamePlayer player2 in myGame.Players)
                    {
                        player.NextTurn(turnCounter, player);
                    }
                }
            }

            return RedirectToAction("Index", "Ludo");
        }

        public ActionResult MovePiece2()
        {
            foreach (GamePlayer player in myGame.Players)
            {
                player.Two.MovePiece(player, myGame.Dice, player.Two);
            }
            return RedirectToAction("Index", "Ludo");
        }

        public ActionResult MovePiece3()
        {
            foreach (GamePlayer player in myGame.Players)
            {
                player.Three.MovePiece(player, myGame.Dice, player.Three);
            }
            return RedirectToAction("Index", "Ludo");
        }

        public ActionResult MovePiece4()
        {
            foreach (GamePlayer player in myGame.Players)
            {
                player.Four.MovePiece(player, myGame.Dice, player.Four);
            }
            return RedirectToAction("Index", "Ludo");
        }


    }
}