using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class GamePlayer
    {
        public string Name;
        public string Color;
        public string PlayerID;
        public bool Turn = false;
        public bool CanThrow = false;
        public bool CanMove = false;
        public bool Win = false;
        public GamePiece One = new GamePiece { InPlay = true, Counter = 0, Position = 0 };
        public GamePiece Two = new GamePiece { InPlay = true, Counter = 0, Position = 0 };
        public GamePiece Three = new GamePiece { InPlay = true, Counter = 0, Position = 0 };
        public GamePiece Four = new GamePiece { InPlay = true, Counter = 0, Position = 0 };
        public void NextTurn(int x, GamePlayer player, List<GamePlayer> players)
        {
            if(players.Count == 4)
            {
                foreach (GamePlayer person in players)
                {
                    if (x == 1 && person.Color == "Red")
                    {
                        person.Turn = true;
                        person.CanThrow = true;
                    }
                    else if (x == 2 && person.Color == "Green")
                    {
                        person.Turn = true;
                        person.CanThrow = true;
                    }
                    else if (x == 3 && person.Color == "Blue")
                    {
                        person.Turn = true;
                        person.CanThrow = true;
                    }
                    else if (x == 4 && person.Color == "Yellow")
                    {
                        person.Turn = true;
                        person.CanThrow = true;
                    }
                }
            }
            else if(players.Count < 4)
            {
                bool red = false;
                bool green = false;
                bool blue = false;
                bool yellow = false;
                
                foreach(GamePlayer person in players)
                {
                    if (person.Color == "Red")
                    {
                        red = true;
                    }
                    if (person.Color == "Green")
                    {
                        green = true;
                    }
                    if (person.Color == "Blue")
                    {
                        blue = true;
                    }
                    if (person.Color == "Yellow")
                    {
                        yellow = true;
                    }
                }

                
                if (red == true && green == true && blue == true && yellow != true)
                {

                }// 3 players: red, green, blue
                else if (red == true && green == true && blue != true && yellow == true)
                {
                    if(x == 3)
                    {
                        x = 4;
                    }
                }// 3 players: red, green, yellow
                else if (red == true && green != true && blue == true && yellow == true)
                {
                    if(x == 2)
                    {
                        x = 3;
                    }
                    else if(x == 3)
                    {
                        x = 4;
                    }
                }// 3 players: red, blue, yellow
                else if (red != true && green == true && blue == true && yellow == true)
                {
                    if (x == 1)
                    {
                        x = 2;
                    }
                    else if (x == 2)
                    {
                        x = 3;
                    }
                    else if (x == 3)
                    {
                        x = 4;
                    }

                }// 3 players: green, blue, yellow
                else if (red == true && green == true && blue != true && yellow != true)
                {
                    
                }// 2 players: red, blue
                else if (red == true && green != true && blue != true && yellow == true)
                {
                    if (x == 2)
                    {
                        x = 4;
                    }
                }// 2 players: red, yellow
                else if (red != true && green != true && blue == true && yellow == true)
                {
                    if (x == 1)
                    {
                        x = 3;
                    }
                    else if (x == 2)
                    {
                        x = 4;
                    }
                }// 2 players: blue, yellow
                else if (red != true && green == true && blue == true && yellow != true)
                {
                    if(x == 1)
                    {
                        x = 2;
                    }
                    else if(x == 2)
                    {
                        x = 3;
                    }
                }// 2 players: green, blue
                else if (red == true && green != true && blue == true && yellow != true)
                {
                    if(x == 2)
                    {
                        x = 3;
                    }
                }// 2 players: red, blue
                else if (red != true && green == true && blue != true && yellow == true)
                {
                    if(x == 1)
                    {
                        x = 2;
                    }
                    else if(x == 2)
                    {
                        x = 4;
                    }
                }// 2 players: green, yellow


                foreach (GamePlayer person in players)
                {
                    if (x == 1 && person.Color == "Red")
                    {
                        person.Turn = true;
                        person.CanThrow = true;
                    }
                    else if (x == 2 && person.Color == "Green")
                    {
                        person.Turn = true;
                        person.CanThrow = true;
                    }
                    else if (x == 3 && person.Color == "Blue")
                    {
                        person.Turn = true;
                        person.CanThrow = true;
                    }
                    else if (x == 4 && person.Color == "Yellow")
                    {
                        person.Turn = true;
                        person.CanThrow = true;
                    }
                }
            }
        }
        public void WinCondition(GamePlayer player)
        {
            int counter = 0;
            if (player.One.InPlay == false)
            {
                counter++;
            }
            if (player.Two.InPlay == false)
            {
                counter++;
            }
            if (player.Three.InPlay == false)
            {
                counter++;
            }
            if (player.Four.InPlay == false)
            {
                counter++;
            }
        
            if (counter == 4)
            {
                player.Win = true;
            }
        }

    }
}
