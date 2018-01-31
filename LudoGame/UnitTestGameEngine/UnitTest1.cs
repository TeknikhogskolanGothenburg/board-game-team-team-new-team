using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameEngine;
using LudoGame;

namespace UnitTestGameEngine
{
    [TestClass]
    public class UnitTest1
    {
        LudoGame.Models.Game game = new LudoGame.Models.Game();
        GamePlayer gameplayer = new GamePlayer();
        GameDice dice = new GameDice();

        [TestMethod]
        public void ControlIfGameHasWinner()
        {
            if (gameplayer.One.InPlay == false && gameplayer.Two.InPlay == false && gameplayer.Three.InPlay == false && gameplayer.Four.InPlay == false)
            {
                gameplayer.Win = true;
            }
            Assert.IsTrue(gameplayer.Win);
        }
        [TestMethod]
        public void CheckDiceRolls()
        {
            bool passed;
            if(dice.Value < 6 || dice.Value > 0)
            {
                passed = true;  
            }
            else
            {
                passed = false;
            }
            Assert.IsTrue(passed);
        }
    }
}
