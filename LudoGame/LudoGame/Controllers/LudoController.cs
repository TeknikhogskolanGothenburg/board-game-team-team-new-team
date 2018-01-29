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
        public static bool gameStart = true;
        public static string UserEmail { get; set; }

        // GET: /Ludo/
        public ActionResult StartPage()
        {
            string userGameName = Request.Form["myGametxtBox"];
            string userNickName = Request.Form["myTextBox"];
            string userColorChoice = Request.Form["colorChoice"];
            UserEmail = Request.Form[""];

            if (counter < 4 && userNickName != null && userColorChoice != null)
            {
                if (Request.Cookies["Cookie"] == null)
                {
                    HttpCookie userCookie = new HttpCookie("Cookie");
                    if (userColorChoice == "Red")
                    {
                        userCookie.Value = "Red";
                    }
                    else if (userColorChoice == "Yellow")
                    {
                        userCookie.Value = "Yellow";
                    }
                    else if (userColorChoice == "Blue")
                    {
                        userCookie.Value = "Blue";
                    }
                    else if (userColorChoice == "Green")
                    {
                        userCookie.Value = "Green";
                    }
                    userCookie.Expires = DateTime.Now.AddHours(1);
                    Response.SetCookie(userCookie);
                }
                //Adding Player name, Color, and ID
                myGame.Players.Add(new GamePlayer { Name = userNickName, Color = userColorChoice, PlayerID = Request.Cookies["Cookie"].Value });
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
            string currentPlayer = Request.Cookies["Cookie"].Value;
            if (gameStart == true)
            {
                foreach (GamePlayer player in myGame.Players)
                {
                    if (player.Turn == true && player.CanThrow == true && currentPlayer == player.Color)
                    {
                        myGame.Dice.Value = myGame.Dice.RollTheDice();
                        if (myGame.Dice.Value == 6)
                        {
                            player.CanThrow = false;
                            player.CanMove = true;
                            gameStart = false;
                            break;
                        }
                        else
                        {
                            player.Turn = false;
                            player.CanThrow = false;

                            if (myGame.Players.Count == 4)
                            {
                                if (turnCounter >= 4)
                                {
                                    turnCounter = 1;
                                }
                                else
                                {
                                    turnCounter++;
                                }
                            }
                            else if (myGame.Players.Count == 3)
                            {
                                if (turnCounter >= 3)
                                {
                                    turnCounter = 1;
                                }
                                else
                                {
                                    turnCounter++;
                                }
                            }
                            else if (myGame.Players.Count == 2)
                            {
                                if (turnCounter >= 2)
                                {
                                    turnCounter = 1;
                                }
                                else
                                {
                                    turnCounter++;
                                }
                            }
                            player.NextTurn(turnCounter, player, myGame.Players);
                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (GamePlayer player in myGame.Players)
                {
                    if (player.Turn == true && player.CanThrow == true && currentPlayer == player.Color)
                    {
                        myGame.Dice.Value = myGame.Dice.RollTheDice();
                        player.CanThrow = false;
                        player.CanMove = true;
                        break;
                    }
                }
            }
            return RedirectToAction("Index", "Ludo");
        }

        public ActionResult MovePiece1()
        {
            foreach(GamePlayer player in myGame.Players)
            {
                if (player.CanMove && player.One.InPlay == true)
                {
                    player.One.MovePiece(player, myGame.Dice, player.One);
                    if (myGame.Dice.Value == 6 && player.Turn == true)
                    {
                        player.CanThrow = true;
                        player.CanMove = false;
                        break;
                    }
                    else if (player.One.Position != 0 && myGame.Dice.Value < 6 && player.Turn == true)
                    {
                        if (player.Turn == true)
                        {
                            player.Turn = false;
                            player.CanThrow = false;
                            player.CanMove = false;
                            if (myGame.Players.Count == 4)
                            {
                                if (turnCounter >= 4)
                                {
                                    turnCounter = 1;
                                }
                                else
                                {
                                    turnCounter++;
                                }
                            }
                            else if (myGame.Players.Count == 3)
                            {
                                if (turnCounter >= 3)
                                {
                                    turnCounter = 1;
                                }
                                else
                                {
                                    turnCounter++;
                                }
                            }
                            else if (myGame.Players.Count == 2)
                            {
                                if (turnCounter >= 2)
                                {
                                    turnCounter = 1;
                                }
                                else
                                {
                                    turnCounter++;
                                }
                            }
                        }
                        foreach (GamePlayer player2 in myGame.Players)
                        {
                            player.NextTurn(turnCounter, player, myGame.Players);
                        }
                        break;
                    }
                }
            }

            return RedirectToAction("Index", "Ludo");
        }

        public ActionResult MovePiece2()
        {
            foreach (GamePlayer player in myGame.Players)
            {
                if (player.CanMove && player.Two.InPlay == true)
                {
                    player.Two.MovePiece(player, myGame.Dice, player.Two);
                    if (myGame.Dice.Value == 6 && player.Turn == true)
                    {
                        player.CanThrow = true;
                        player.CanMove = false;
                        break;
                    }
                    else if (player.Two.Position != 0 && myGame.Dice.Value < 6 && player.Turn == true)
                    {
                        if (player.Turn == true)
                        {
                            player.Turn = false;
                            player.CanThrow = false;
                            player.CanMove = false;
                            if (myGame.Players.Count == 4)
                            {
                                if (turnCounter >= 4)
                                {
                                    turnCounter = 1;
                                }
                                else
                                {
                                    turnCounter++;
                                }
                            }
                            else if (myGame.Players.Count == 3)
                            {
                                if (turnCounter >= 3)
                                {
                                    turnCounter = 1;
                                }
                                else
                                {
                                    turnCounter++;
                                }
                            }
                            else if (myGame.Players.Count == 2)
                            {
                                if (turnCounter >= 2)
                                {
                                    turnCounter = 1;
                                }
                                else
                                {
                                    turnCounter++;
                                }
                            }
                        }
                        foreach (GamePlayer player2 in myGame.Players)
                        {
                            player.NextTurn(turnCounter, player, myGame.Players);
                        }
                        break;
                    }
                }
            }
            return RedirectToAction("Index", "Ludo");
        }

        public ActionResult MovePiece3()
        {
            foreach (GamePlayer player in myGame.Players)
            {
                if (player.CanMove && player.Three.InPlay == true)
                {
                    player.Three.MovePiece(player, myGame.Dice, player.Three);
                    if (myGame.Dice.Value == 6 && player.Turn == true)
                    {
                        player.CanThrow = true;
                        player.CanMove = false;
                        break;
                    }
                    else if (player.Three.Position != 0 && myGame.Dice.Value < 6 && player.Turn == true)
                    {
                        if (player.Turn == true)
                        {
                            player.Turn = false;
                            player.CanThrow = false;
                            player.CanMove = false;
                            if (myGame.Players.Count == 4)
                            {
                                if (turnCounter >= 4)
                                {
                                    turnCounter = 1;
                                }
                                else
                                {
                                    turnCounter++;
                                }
                            }
                            else if (myGame.Players.Count == 3)
                            {
                                if (turnCounter >= 3)
                                {
                                    turnCounter = 1;
                                }
                                else
                                {
                                    turnCounter++;
                                }
                            }
                            else if (myGame.Players.Count == 2)
                            {
                                if (turnCounter >= 2)
                                {
                                    turnCounter = 1;
                                }
                                else
                                {
                                    turnCounter++;
                                }
                            }
                        }
                        foreach (GamePlayer player2 in myGame.Players)
                        {
                            player.NextTurn(turnCounter, player, myGame.Players);
                        }
                        break;
                    }
                }
            }
            return RedirectToAction("Index", "Ludo");
        }

        public ActionResult MovePiece4()
        {
            foreach (GamePlayer player in myGame.Players)
            {
                if (player.CanMove && player.Four.InPlay == true)
                {
                    player.Four.MovePiece(player, myGame.Dice, player.Four);
                    if (myGame.Dice.Value == 6 && player.Turn == true)
                    {
                        player.CanThrow = true;
                        player.CanMove = false;
                        break;
                    }
                    else if (player.Four.Position != 0 && myGame.Dice.Value < 6 && player.Turn == true)
                    {
                        if (player.Turn == true)
                        {
                            player.Turn = false;
                            player.CanThrow = false;
                            player.CanMove = false;
                            if (myGame.Players.Count == 4)
                            {
                                if (turnCounter >= 4)
                                {
                                    turnCounter = 1;
                                }
                                else
                                {
                                    turnCounter++;
                                }
                            }
                            else if (myGame.Players.Count == 3)
                            {
                                if (turnCounter >= 3)
                                {
                                    turnCounter = 1;
                                }
                                else
                                {
                                    turnCounter++;
                                }
                            }
                            else if (myGame.Players.Count == 2)
                            {
                                if (turnCounter >= 2)
                                {
                                    turnCounter = 1;
                                }
                                else
                                {
                                    turnCounter++;
                                }
                            }
                        }
                        foreach (GamePlayer player2 in myGame.Players)
                        {
                            player.NextTurn(turnCounter, player, myGame.Players);
                        }
                        break;
                    }
                }
            }
            return RedirectToAction("Index", "Ludo");
        }

        public ActionResult EndTurn()
        {
            foreach (GamePlayer player in myGame.Players)
            {
                if (player.CanMove)
                {
                    player.Turn = false;
                    player.CanThrow = false;
                    player.CanMove = false;
                    if (myGame.Players.Count == 4)
                    {
                        if (turnCounter >= 4)
                        {
                            turnCounter = 1;
                        }
                        else
                        {
                            turnCounter++;
                        }
                    }
                    else if (myGame.Players.Count == 3)
                    {
                        if (turnCounter >= 3)
                        {
                            turnCounter = 1;
                        }
                        else
                        {
                            turnCounter++;
                        }
                    }
                    else if (myGame.Players.Count == 2)
                    {
                        if (turnCounter >= 2)
                        {
                            turnCounter = 1;
                        }
                        else
                        {
                            turnCounter++;
                        }
                    }
                    foreach (GamePlayer player2 in myGame.Players)
                    {
                        player.NextTurn(turnCounter, player, myGame.Players);
                    }
                }
            }
            return RedirectToAction("Index", "Ludo");
        }

        public ActionResult WinPage()
        {
            return View();
        }
        
    }

    
}