using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class GameDice
    {
        public int RollTheDice()
        {
            Random num = new Random();
            int number = num.Next(1, 7);

            return number;
        }
    }
}
