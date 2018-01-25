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
    }
}
