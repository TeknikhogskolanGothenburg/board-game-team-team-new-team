using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GameEngine;

namespace LudoGame.Models
{
    public class Game
    {
        public List<GameEngine.GamePlayer> Players = new List<GameEngine.GamePlayer> { };
        public GameEngine.GameDice Dice = new GameDice { };
        public bool buttonPressed = false;
    }
}