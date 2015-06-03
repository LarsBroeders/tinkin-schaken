using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace TINKIN01.Chess.Pieces
{
    [DebuggerDisplay("King, Owner = {Owner.Team}")]
    public class King : Chesspiece
    {
        public override HashSet<Move> GetValidMoves(Chessboard board)
        {
            var start = board.IndexOf(this);
            var moves = new HashSet<Move>();
            Point end;

            end = new Point(start.X, start.Y + 1);
            if (board.IsValidField(end, Owner))
            {
                moves.Add(new Move(start, end, this));
            }

            end = new Point(start.X + 1, start.Y);
            if (board.IsValidField(end, Owner))
            {
                moves.Add(new Move(start, end, this));
            }

            end = new Point(start.X, start.Y - 1);
            if (board.IsValidField(end, Owner))
            {
                moves.Add(new Move(start, end, this));
            }

            end = new Point(start.X - 1, start.Y);
            if (board.IsValidField(end, Owner))
            {
                moves.Add(new Move(start, end, this));
            }

            end = new Point(start.X + 1, start.Y + 1);
            if (board.IsValidField(end, Owner))
            {
                moves.Add(new Move(start, end, this));
            }

            end = new Point(start.X + 1, start.Y - 1);
            if (board.IsValidField(end, Owner))
            {
                moves.Add(new Move(start, end, this));
            }

            end = new Point(start.X - 1, start.Y + 1);
            if (board.IsValidField(end, Owner))
            {
                moves.Add(new Move(start, end, this));
            }

            end = new Point(start.X - 1, start.Y - 1);
            if (board.IsValidField(end, Owner))
            {
                moves.Add(new Move(start, end, this));
            }

            end = new Point(start.X, start.Y + 1);
            if (board.IsValidField(end, Owner, false))
            {
                moves.Add(new Move(start, end, this));
            }

            end = new Point(start.X + 1, start.Y);
            if (board.IsValidField(end, Owner, false))
            {
                moves.Add(new Move(start, end, this));
            }

            end = new Point(start.X, start.Y - 1);
            if (board.IsValidField(end, Owner, false))
            {
                moves.Add(new Move(start, end, this));
            }

            end = new Point(start.X - 1, start.Y);
            if (board.IsValidField(end, Owner, false))
            {
                moves.Add(new Move(start, end, this));
            }

            end = new Point(start.X + 1, start.Y + 1);
            if (board.IsValidField(end, Owner, false))
            {
                moves.Add(new Move(start, end, this));
            }

            end = new Point(start.X + 1, start.Y - 1);
            if (board.IsValidField(end, Owner, false))
            {
                moves.Add(new Move(start, end, this));
            }

            end = new Point(start.X - 1, start.Y + 1);
            if (board.IsValidField(end, Owner, false))
            {
                moves.Add(new Move(start, end, this));
            }

            end = new Point(start.X - 1, start.Y - 1);
            if (board.IsValidField(end, Owner, false))
            {
                moves.Add(new Move(start, end, this));
            }

            return moves;
            /*return new[] {
                new Point(0, 1),
                new Point(1, 0),
                new Point(0, -1),
                new Point(-1, 0),
                new Point(1, 1),
                new Point(1, -1),
                new Point(-1, 1),
                new Point(-1, -1)
            };*/
        }
    }
}
