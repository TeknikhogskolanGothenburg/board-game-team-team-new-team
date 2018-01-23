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


        public void PlacePiece(GamePiece piece, GameSquare square)
        {
            //do stuff
            //to initialize first square depending on piece color.
        }
        public void MovePiece(GameSquare originSquare, GameSquare targetSquare)
        {
            //do stuff
            //to move a game piece from one square to another
        }
        public void RemovePiece(GameSquare square)
        {
            //do stuff
            //to remove a game piece or peices from a specified square
        }
    }
}
