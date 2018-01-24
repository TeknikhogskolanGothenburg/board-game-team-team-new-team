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

        // GET: /Ludo/
        public ActionResult StartPage()
        {
            string userNickName = Request.Form["myTextBox"];
            string userColorChoice = Request.Form["colorChoice"];

            if (counter < 4 && userNickName != null && userColorChoice != null)
            {
                
                //myGame.Players.Add(new GamePlayer { Name = ""/*Example variable*/, Color = ""/*colorChoice*/ });
                myGame.Players.Add(new GamePlayer { Name = userNickName, Color = userColorChoice });
                myGame.Players[0].Turn = true;
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
        }

        public ActionResult Index()
        {
            //GameBoard Board = new GameBoard{};
            //for(int i = 1; i <= 52; i++)
            //{
            //    Board.GameSquares.Add(new GameSquare { NumberedName = Convert.ToString(i), Position = i });
            //}
            //for(int i = 1; i <= 5; i++)
            //{
            //    Board.GameSquares.Add(new GameSquare { NumberedName = Convert.ToString(i) + "G", Position = 52 + i });
            //    Board.GameSquares.Add(new GameSquare { NumberedName = Convert.ToString(i) + "R", Position = 52 + i });
            //    Board.GameSquares.Add(new GameSquare { NumberedName = Convert.ToString(i) + "Y", Position = 52 + i });
            //    Board.GameSquares.Add(new GameSquare { NumberedName = Convert.ToString(i) + "B", Position = 52 + i });
            //}
            return View(myGame);
        }
        public ActionResult RollDice()
        {
            myGame.Dice.Value = myGame.Dice.RollTheDice();
            return RedirectToAction("Index", "Ludo");
        }
        public ActionResult MovePiece1()
        {
            if (myGame.Players[0].Turn == true)
            {
                if(myGame.Players[0].One.InPlay == true)
                {
                    if (myGame.Players[0].One.Position == 0 && myGame.Dice.Value == 6)
                    {
                        if (myGame.Players[0].Color == "Red")
                        {
                            myGame.Players[0].One.Position = 40;
                        }
                        else if (myGame.Players[0].Color == "Green")
                        {
                            myGame.Players[0].One.Position = 1;
                        }
                        else if (myGame.Players[0].Color == "Blue")
                        {
                            myGame.Players[0].One.Position = 14;
                        }
                        else if (myGame.Players[0].Color == "Yellow")
                        {
                            myGame.Players[0].One.Position = 27;
                        }
                    }
                    else if (myGame.Players[0].One.Position >= 1 && myGame.Players[0].One.Position  <= 52)
                    {
                        myGame.Players[0].One.Position += myGame.Dice.Value;
                    }
                    else if(myGame.Players[0].One.Position >= 53 && myGame.Players[0].One.Position <= 58)
                    {
                        myGame.Players[0].One.Position += myGame.Dice.Value;
                    }

                    if (myGame.Players[0].One.Position > 58)
                    {
                        int x = ((myGame.Players[0].One.Position) - 58);
                        myGame.Players[0].One.Position = (58 - x);
                    }
                    else if (myGame.Players[0].One.Position == 58)
                    {
                        myGame.Players[0].One.InPlay = false;
                    }
                }
            }
            return RedirectToAction("Index", "Ludo");
        }
        public ActionResult MovePiece2()
        {
            if (myGame.Players[0].Turn == true)
            {
                if (myGame.Players[0].Two.InPlay == true)
                {
                    if (myGame.Players[0].Two.Position == 0 && myGame.Dice.Value == 6)
                    {
                        if (myGame.Players[0].Color == "Red")
                        {
                            myGame.Players[0].Two.Position = 40;
                        }
                        else if (myGame.Players[0].Color == "Green")
                        {
                            myGame.Players[0].Two.Position = 1;
                        }
                        else if (myGame.Players[0].Color == "Blue")
                        {
                            myGame.Players[0].Two.Position = 14;
                        }
                        else if (myGame.Players[0].Color == "Yellow")
                        {
                            myGame.Players[0].Two.Position = 27;
                        }
                    }
                    else if (myGame.Players[0].Two.Position >= 1 && myGame.Players[0].Two.Position <= 52)
                    {
                        myGame.Players[0].Two.Position += myGame.Dice.Value;
                    }
                    else if (myGame.Players[0].Two.Position >= 53 && myGame.Players[0].Two.Position <= 58)
                    {
                        myGame.Players[0].Two.Position += myGame.Dice.Value;
                    }

                    if (myGame.Players[0].Two.Position > 58)
                    {
                        int x = ((myGame.Players[0].Two.Position) - 58);
                        myGame.Players[0].Two.Position = (58 - x);
                    }
                    else if (myGame.Players[0].Two.Position == 58)
                    {
                        myGame.Players[0].Two.InPlay = false;
                    }
                }
            }
            return RedirectToAction("Index", "Ludo");
        }
        public ActionResult MovePiece3()
        {
            if (myGame.Players[0].Turn == true)
            {
                if (myGame.Players[0].Three.InPlay == true)
                {
                    if (myGame.Players[0].Three.Position == 0 && myGame.Dice.Value == 6)
                    {
                        if (myGame.Players[0].Color == "Red")
                        {
                            myGame.Players[0].Three.Position = 40;
                        }
                        else if (myGame.Players[0].Color == "Green")
                        {
                            myGame.Players[0].Three.Position = 1;
                        }
                        else if (myGame.Players[0].Color == "Blue")
                        {
                            myGame.Players[0].Three.Position = 14;
                        }
                        else if (myGame.Players[0].Color == "Yellow")
                        {
                            myGame.Players[0].Three.Position = 27;
                        }
                    }
                    else if (myGame.Players[0].Three.Position >= 1 && myGame.Players[0].Three.Position <= 52)
                    {
                        myGame.Players[0].Three.Position += myGame.Dice.Value;
                    }
                    else if (myGame.Players[0].Three.Position >= 53 && myGame.Players[0].Three.Position <= 58)
                    {
                        myGame.Players[0].Three.Position += myGame.Dice.Value;
                    }

                    if (myGame.Players[0].Three.Position > 58)
                    {
                        int x = ((myGame.Players[0].Three.Position) - 58);
                        myGame.Players[0].Three.Position = (58 - x);
                    }
                    else if (myGame.Players[0].Three.Position == 58)
                    {
                        myGame.Players[0].Three.InPlay = false;
                    }
                }
            }
            return RedirectToAction("Index", "Ludo");
        }
        public ActionResult MovePiece4()
        {
            if (myGame.Players[0].Turn == true)
            {
                if (myGame.Players[0].Four.InPlay == true)
                {
                    if (myGame.Players[0].Four.Position == 0 && myGame.Dice.Value == 6)
                    {
                        if (myGame.Players[0].Color == "Red")
                        {
                            myGame.Players[0].Four.Position = 40;
                        }
                        else if (myGame.Players[0].Color == "Green")
                        {
                            myGame.Players[0].Four.Position = 1;
                        }
                        else if (myGame.Players[0].Color == "Blue")
                        {
                            myGame.Players[0].Four.Position = 14;
                        }
                        else if (myGame.Players[0].Color == "Yellow")
                        {
                            myGame.Players[0].Four.Position = 27;
                        }
                    }
                    else if (myGame.Players[0].Four.Position >= 1 && myGame.Players[0].Four.Position <= 52)
                    {
                        myGame.Players[0].Four.Position += myGame.Dice.Value;
                    }
                    else if (myGame.Players[0].Four.Position >= 53 && myGame.Players[0].Four.Position <= 58)
                    {
                        myGame.Players[0].Four.Position += myGame.Dice.Value;
                    }

                    if (myGame.Players[0].Four.Position > 58)
                    {
                        int x = ((myGame.Players[0].Four.Position) - 58);
                        myGame.Players[0].Four.Position = (58 - x);
                    }
                    else if (myGame.Players[0].Four.Position == 58)
                    {
                        myGame.Players[0].Four.InPlay = false;
                    }
                }
            }
            return RedirectToAction("Index", "Ludo");
        }


    }
}