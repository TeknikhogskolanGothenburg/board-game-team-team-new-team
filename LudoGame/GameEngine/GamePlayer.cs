﻿using System;
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
            if (player.Color == "Red")
            {
                foreach (GamePlayer nextPlayer in players)
                {
                    if(nextPlayer.Color == "Green")
                    {
                        nextPlayer.Turn = true;
                    }
                }
                foreach(GamePlayer nextPlayer in players)
                {
                    if (nextPlayer.Color == "Green" && player.Turn == true)
                    {
                    }
         
                }
            }
            if (player.Color == "Green")
            {
                foreach (GamePlayer nextPlayer in players)
                {
                    if (nextPlayer.Color == "Green")
                    {
                        nextPlayer.Turn = true;
                        break;
                    }
                    else if (nextPlayer.Color == "Blue")
                    {
                        nextPlayer.Turn = true;
                        break;
                    }
                    else if (nextPlayer.Color == "Yellow")
                    {
                        nextPlayer.Turn = true;
                        break;
                    }
                }
            }
            if (player.Color == "Blue")
            {
                foreach (GamePlayer nextPlayer in players)
                {
                    if (nextPlayer.Color == "Green")
                    {
                        nextPlayer.Turn = true;
                        break;
                    }
                    else if (nextPlayer.Color == "Blue")
                    {
                        nextPlayer.Turn = true;
                        break;
                    }
                    else if (nextPlayer.Color == "Yellow")
                    {
                        nextPlayer.Turn = true;
                        break;
                    }
                }
            }
            if (player.Color == "Yellow")
            {
                foreach (GamePlayer nextPlayer in players)
                {
                    if (nextPlayer.Color == "Green")
                    {
                        nextPlayer.Turn = true;
                        break;
                    }
                    else if (nextPlayer.Color == "Blue")
                    {
                        nextPlayer.Turn = true;
                        break;
                    }
                    else if (nextPlayer.Color == "Yellow")
                    {
                        nextPlayer.Turn = true;
                        break;
                    }
                }
            }
        }
    }
}
