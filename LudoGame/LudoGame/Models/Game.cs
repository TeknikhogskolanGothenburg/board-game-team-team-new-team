using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GameEngine;

namespace LudoGame.Models
{
    public class Game
    {
        public List<GameEngine.GamePlayer> Players;
        public GameEngine.GameDice Dice;
        public GameEngine.GamePiece Peice;
        public GameEngine.GameBoard Board;
        public GameEngine.GameSquare Square;
    }
}