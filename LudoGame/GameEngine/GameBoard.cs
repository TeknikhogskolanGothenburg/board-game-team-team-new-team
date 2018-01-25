using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    //Class will hold all peice logic together and run in the head controller.
    public class GameBoard
    {
        public List<GameSquare> GameSquares = new List<GameSquare>();
        public List<GamePlayer> GamePlayers = new List<GamePlayer>();
    }
}
