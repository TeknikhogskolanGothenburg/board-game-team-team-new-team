using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameEngine;
using System.Net;
using System.Net.Mail;
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
        public static string UserNickName { get; set; }

        // GET: /Ludo/
        public ActionResult StartPage()
        {
            string userGameName = Request.Form["myGametxtBox"];
            UserNickName = Request.Form["myTextBox"];
            string userColorChoice = Request.Form["colorChoice"];
            UserEmail = Request.Form["myEmailBox"];

            if (counter < 4 && UserNickName != null && userColorChoice != null)
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
                    userCookie.Expires = DateTime.Now.AddDays(1);
                    Response.SetCookie(userCookie);
                }
                //Adding Player name, Color, ID, and Email.
                myGame.Players.Add(new GamePlayer { Name = UserNickName, Color = userColorChoice, PlayerID = Request.Cookies["Cookie"].Value, Email = UserEmail });
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
            if (myGame.Players.Count > 0 && UserNickName != null && userColorChoice != null)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Email()
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("Ludoblizzard@hotmail.com");
            mailMessage.To.Add(UserEmail);
            mailMessage.Subject = "Hello from Ludogame";
            mailMessage.Body = "Hello there " + UserNickName + " its your turn, cmon wake up!!!!!!";

            using (var smtp = new SmtpClient())
            {
                //await smtp.SendMailAsync(mailMessage);
            }

            return View();
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
            foreach (GamePlayer player in myGame.Players)
            {
                player.WinCondition(player);
                if (player.Win == true)
                {
                    return RedirectToAction("WinPage");
                }
                else
                {
                    return RedirectToAction("Index", "Ludo");
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
            foreach (GamePlayer player in myGame.Players)
            {
                player.WinCondition(player);
                if (player.Win == true)
                {
                    return RedirectToAction("WinPage");
                }
                else
                {
                    return RedirectToAction("Index", "Ludo");
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
            foreach (GamePlayer player in myGame.Players)
            {
                player.WinCondition(player);
                if (player.Win == true)
                {
                    return RedirectToAction("WinPage");
                }
                else
                {
                    return RedirectToAction("Index", "Ludo");
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

            foreach (GamePlayer player in myGame.Players)
            {
                player.WinCondition(player);
                if (player.Win == true)
                {
                    return RedirectToAction("WinPage");
                }
                else
                {
                    return RedirectToAction("Index", "Ludo");
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
            if (myGame.Players.Count == 0)
            {
                return RedirectToAction("StartPage");
            }
            else if(myGame.Players.Count > 0)
            {
                foreach(GamePlayer player in myGame.Players)
                {
                    if(player.Win == true)
                    {
                        return View(myGame);
                    }
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(myGame);
            }
        }
        
        public ActionResult NewGame()
        {
            if (myGame.Players.Count == 0)
            {
                return RedirectToAction("StartPage");
            }
            else
            {
                if (Request.Cookies["Cookie"] != null)
                {
                    var cookie = new HttpCookie("Cookie");
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(cookie);
                }
                myGame = new Game { };
                counter = 0;
                red = false;
                green = false;
                yellow = false;
                blue = false;
                turnCounter = 1;
                gameStart = true;
                UserEmail = "";

                return RedirectToAction("StartPage");
            }
        }

    }

    
}