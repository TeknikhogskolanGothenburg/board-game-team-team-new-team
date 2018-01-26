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

                  // 3 players no yellow
                if (red == true && green == true && blue == true && yellow != true)
                {

                } // 3 players no blue
                else if (red == true && green == true && blue != true && yellow == true)
                {
                    if(x == 3)
                    {
                        x = 4;
                    }
                } // 3 players no green
                else if (red == true && green != true && blue == true && yellow == true)
                {
                    if(x == 2)
                    {
                        x = 3;
                    }
                    if(x == 3)
                    {
                        x = 4;
                    }
                } // 3 players no red
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

                } // 2 players no blue or yellow
                else if (red == true && green == true && blue != true && yellow != true)
                {
                    
                } // 2 players no green or blue
                else if (red == true && green != true && blue != true && yellow == true)
                {
                    if (x == 2)
                    {
                        x = 4;
                    }
                } // 2 players no red or green
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
                } // 2 players no red or yellow
                else if (red != true && green == true && blue == true && yellow != true)
                {
                    if(x == 1)
                    {
                        x = 2;
                    }
                    if(x == 2)
                    {
                        x = 3;
                    }
                } // 2 players no blue or yellow

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

    }
}
