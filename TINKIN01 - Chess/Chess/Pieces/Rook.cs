using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using TINKIN01.Chess.Pieces;


namespace TINKIN01.Chess.Pieces
{
    [DebuggerDisplay("Rook, Owner = {Owner.Team}")]
    public class Rook : Chesspiece
    {
        public override HashSet<Move> GetValidMoves(Chessboard board)
        {
            var start = board.IndexOf(this);
            var moves = new HashSet<Move>();
            Point end;

            for (int x = 1; x < (8 - start.X); x++)
            {
                end = new Point(start.X + x, start.Y);
                if (board.IsValidField(end, Owner, false))
                {
                    moves.Add(new Move(start, end, this));
                    break;
                }
                if (board.IsValidField(end, Owner))
                    moves.Add(new Move(start, end, this));
                else
                    break;
            }

            for (int x = 1; x <= (start.X); x++)
            {
                end = new Point(start.X - x, start.Y);
                if (board.IsValidField(end, Owner, false))
                {
                    moves.Add(new Move(start, end, this));
                    break;
                }
                if (board.IsValidField(end, Owner))
                    moves.Add(new Move(start, end, this));
                else
                    break;
            }

            for (int y = 1; y < (8 - start.Y); y++)
            {
                end = new Point(start.X, start.Y + y);
                if (board.IsValidField(end, Owner, false))
                {
                    moves.Add(new Move(start, end, this));
                    break;
                }
                if (board.IsValidField(end, Owner))
                    moves.Add(new Move(start, end, this));
                else
                    break;
            }

            for (int y = 1; y <= (start.Y); y++)
            {
                end = new Point(start.X, start.Y - y);
                if (board.IsValidField(end, Owner, false))
                {
                    moves.Add(new Move(start, end, this));
                    break;
                }
                if (board.IsValidField(end, Owner))
                    moves.Add(new Move(start, end, this));
                else
                    break;
            }

            return moves;
        }
    }
}
