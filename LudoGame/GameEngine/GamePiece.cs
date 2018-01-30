using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class GamePiece
    {
        public bool InPlay = true;
        public int Counter = 0;
        public int Position = 0;

        public void MovePiece( GamePlayer player, GameDice dice, GamePiece piece)
        {
            if (player.Turn == true && player.CanMove == true)
            {
                if (player.Color == "Red")
                {
                    if (piece.InPlay == true)
                    {
                        if (piece.Position == 0 && dice.Value == 6)
                        {
                           piece.Position = 40;
                        }
                        else if (piece.Position >= 40 && piece.Position <= 52)
                        {
                           piece.Position += dice.Value;
                            if (piece.Position > 52)
                            {
                                int x = piece.Position - 52;
                                piece.Position = 0;
                                piece.Position += x;
                            }
                        }
                        else if (piece.Position >= 1 && piece.Position <= 38)
                        {
                            piece.Position += dice.Value;
                            if (piece.Position > 38)
                            {
                                int x = piece.Position - 38;
                                piece.Position = 52;
                                piece.Position += x;
                            }
                        }
                        else if (piece.Position >= 53 && piece.Position <= 58)
                        {
                            piece.Position += dice.Value;
                        }

                        if (piece.Position > 58)
                        {
                            int x = ((piece.Position) - 58);
                            piece.Position = (58 - x);
                        }
                        else if (piece.Position == 58)
                        {
                            //win condition
                            piece.InPlay = false;
                        }
                    }
                }

                if (player.Color == "Green")
                {
                    if (piece.InPlay == true)
                    {
                        if (piece.Position == 0 && dice.Value == 6)
                        {
                            piece.Position = 1;
                        }
                        else if (piece.Position >= 1 && piece.Position <= 51)
                        {
                            piece.Position += dice.Value;
                            if (piece.Position >= 52)
                            {
                                int x = piece.Position - 51;
                                piece.Position = 52;
                                piece.Position += x;
                            }
                        }
                        else if (piece.Position >= 53 && piece.Position <= 58)
                        {
                            piece.Position += dice.Value;
                        }

                        if (piece.Position > 58)
                        {
                            int x = ((piece.Position) - 58);
                            piece.Position = (58 - x);
                        }
                        else if (piece.Position == 58)
                        {
                            //win condition
                            piece.InPlay = false;
                        }
                    }
                }

                if (player.Color == "Yellow")
                {
                    if (piece.InPlay == true)
                    {
                        if (piece.Position == 0 && dice.Value == 6)
                        {
                            piece.Position = 27;
                        }
                        else if (piece.Position >= 27 && piece.Position <= 52)
                        {
                            piece.Position += dice.Value;
                            if (piece.Position > 52)
                            {
                                int x = piece.Position - 52;
                                piece.Position = 0;
                                piece.Position += x;
                            }
                        }
                        else if (piece.Position >= 1 && piece.Position <= 25)
                        {
                            piece.Position += dice.Value;
                            if (piece.Position > 25)
                            {
                                int x = piece.Position - 25;
                                piece.Position = 52;
                                piece.Position += x;
                            }
                        }
                        else if (piece.Position >= 53 && piece.Position <= 58)
                        {
                            piece.Position += dice.Value;
                        }

                        if (piece.Position > 58)
                        {
                            int x = ((piece.Position) - 58);
                            piece.Position = (58 - x);
                        }
                        else if (piece.Position == 58)
                        {
                            //win condition
                            piece.InPlay = false;
                        }
                    }
                }

                if (player.Color == "Blue")
                {
                    if (piece.InPlay == true)
                    {
                        if (piece.Position == 0 && dice.Value == 6)
                        {
                            piece.Position = 14;
                        }
                        else if (piece.Position >= 14 && piece.Position <= 52)
                        {
                            piece.Position += dice.Value;
                            if (piece.Position > 52)
                            {
                                int x = piece.Position - 52;
                                piece.Position = 0;
                                piece.Position += x;
                            }
                        }
                        else if (piece.Position >= 1 && piece.Position <= 12)
                        {
                            piece.Position += dice.Value;
                            if (piece.Position > 12)
                            {
                                int x = piece.Position - 12;
                                piece.Position = 52;
                                piece.Position += x;
                            }
                        }
                        else if (piece.Position >= 53 && piece.Position <= 58)
                        {
                            piece.Position += dice.Value;
                        }

                        if (piece.Position > 58)
                        {
                            int x = ((piece.Position) - 58);
                            piece.Position = (58 - x);
                        }
                        else if (piece.Position == 58)
                        {
                            //win condition
                            piece.InPlay = false;
                        }
                    }
                }
                

            }
        }
        public void AttackPiece(GamePlayer player, List<GamePlayer> players, int x)
        {
            int blockCounter = 0;
            foreach (GamePlayer blockPlayer in players)
            {
                if (x == 1)
                {
                    if (player.One.Position == blockPlayer.One.Position ||
                       player.One.Position == blockPlayer.Two.Position ||
                       player.One.Position == blockPlayer.Three.Position ||
                       player.One.Position == blockPlayer.Four.Position)
                    {
                        blockCounter++;
                    }
                }
                else if (x == 2)
                {
                    if(player.Two.Position == blockPlayer.One.Position ||
                   player.Two.Position == blockPlayer.Two.Position ||
                   player.Two.Position == blockPlayer.Three.Position||
                   player.Two.Position == blockPlayer.Four.Position)
                    {
                        blockCounter++;
                    }
                }
                else if (x == 3)
                {
                    if(player.Three.Position == blockPlayer.One.Position ||
                   player.Three.Position == blockPlayer.Two.Position ||
                   player.Three.Position == blockPlayer.Three.Position ||
                   player.Three.Position == blockPlayer.Four.Position)
                    {
                        blockCounter++;
                    }
                }
                else if (x == 4)
                {
                    if(player.Four.Position == blockPlayer.One.Position ||
                   player.Four.Position == blockPlayer.Two.Position ||
                   player.Four.Position == blockPlayer.Three.Position ||
                   player.Four.Position == blockPlayer.Four.Position)
                    {
                        blockCounter++;
                    }
                }
                        
            }
            if (blockCounter < 2)
            {
                if (x == 1)
                {
                    foreach (GamePlayer thatPlayer in players)
                    {
                        if (thatPlayer.One.Position == player.One.Position && thatPlayer.Color != player.Color)
                        {
                            thatPlayer.One.Position = 0;
                        }
                        else if (thatPlayer.Two.Position == player.One.Position && thatPlayer.Color != player.Color)
                        {
                            thatPlayer.Two.Position = 0;
                        }
                        else if (thatPlayer.Three.Position == player.One.Position && thatPlayer.Color != player.Color)
                        {
                            thatPlayer.Three.Position = 0;
                        }
                        else if (thatPlayer.Four.Position == player.One.Position && thatPlayer.Color != player.Color)
                        {
                            thatPlayer.Four.Position = 0;
                        }
                    }
                }
                if (x == 2)
                {
                    foreach (GamePlayer thatPlayer in players)
                    {
                        if (thatPlayer.One.Position == player.Two.Position && thatPlayer.Color != player.Color)
                        {
                            thatPlayer.One.Position = 0;
                        }
                        else if (thatPlayer.Two.Position == player.Two.Position && thatPlayer.Color != player.Color)
                        {
                            thatPlayer.Two.Position = 0;
                        }
                        else if (thatPlayer.Three.Position == player.Two.Position && thatPlayer.Color != player.Color)
                        {
                            thatPlayer.Three.Position = 0;
                        }
                        else if (thatPlayer.Four.Position == player.Two.Position && thatPlayer.Color != player.Color)
                        {
                            thatPlayer.Four.Position = 0;
                        }
                    }
                }
                if (x == 3)
                {
                    foreach (GamePlayer thatPlayer in players)
                    {
                        if (thatPlayer.One.Position == player.Three.Position && thatPlayer.Color != player.Color)
                        {
                            thatPlayer.One.Position = 0;
                        }
                        else if (thatPlayer.Two.Position == player.Three.Position && thatPlayer.Color != player.Color)
                        {
                            thatPlayer.Two.Position = 0;
                        }
                        else if (thatPlayer.Three.Position == player.Three.Position && thatPlayer.Color != player.Color)
                        {
                            thatPlayer.Three.Position = 0;
                        }
                        else if (thatPlayer.Four.Position == player.Three.Position && thatPlayer.Color != player.Color)
                        {
                            thatPlayer.Four.Position = 0;
                        }
                    }
                }
                if (x == 4)
                {
                    foreach (GamePlayer thatPlayer in players)
                    {
                        if (thatPlayer.One.Position == player.Four.Position && thatPlayer.Color != player.Color)
                        {
                            thatPlayer.One.Position = 0;
                        }
                        else if (thatPlayer.Two.Position == player.Four.Position && thatPlayer.Color != player.Color)
                        {
                            thatPlayer.Two.Position = 0;
                        }
                        else if (thatPlayer.Three.Position == player.Four.Position && thatPlayer.Color != player.Color)
                        {
                            thatPlayer.Three.Position = 0;
                        }
                        else if (thatPlayer.Four.Position == player.Four.Position && thatPlayer.Color != player.Color)
                        {
                            thatPlayer.Four.Position = 0;
                        }
                    }
                }
            }
        }
    }
}
