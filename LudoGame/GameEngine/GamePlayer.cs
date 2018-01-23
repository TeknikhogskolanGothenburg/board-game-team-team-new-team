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
        public GamePiece One = new GamePiece{InPlay = true, Counter = 0, Position = 0};
        public GamePiece Two = new GamePiece { InPlay = true, Counter = 0, Position = 0 };
        public GamePiece Three = new GamePiece { InPlay = true, Counter = 0, Position = 0 };
        public GamePiece Four = new GamePiece { InPlay = true, Counter = 0, Position = 0 };
    }
}
