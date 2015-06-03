using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace TINKIN01.Chess.Pieces
{
    [DebuggerDisplay("Kniight, Owner = {Owner.Team}")]
    public class Knight : Chesspiece
    {
        public override HashSet<Move> GetValidMoves(Chessboard board)
        {
            var start = board.IndexOf(this);
            var moves = new HashSet<Move>();
            Point end;

            end = new Point(start.X + 1, start.Y + 2);
            if (board.IsValidField(end, Owner) || board.IsValidField(end, Owner, false))
                moves.Add(new Move(start, end, this));

            end = new Point(start.X + 1, start.Y - 2);
            if (board.IsValidField(end, Owner) || board.IsValidField(end, Owner, false))
                moves.Add(new Move(start, end, this));

            end = new Point(start.X - 1, start.Y + 2);
            if (board.IsValidField(end, Owner) || board.IsValidField(end, Owner, false))
                moves.Add(new Move(start, end, this));

            end = new Point(start.X - 1, start.Y - 2);
            if (board.IsValidField(end, Owner) || board.IsValidField(end, Owner, false))
                moves.Add(new Move(start, end, this));

            end = new Point(start.X + 2, start.Y + 1);
            if (board.IsValidField(end, Owner) || board.IsValidField(end, Owner, false))
                moves.Add(new Move(start, end, this));

            end = new Point(start.X + 2, start.Y - 1);
            if (board.IsValidField(end, Owner) || board.IsValidField(end, Owner, false))
                moves.Add(new Move(start, end, this));

            end = new Point(start.X - 2, start.Y + 1);
            if (board.IsValidField(end, Owner) || board.IsValidField(end, Owner, false))
                moves.Add(new Move(start, end, this));

            end = new Point(start.X - 2, start.Y - 1);
            if (board.IsValidField(end, Owner) || board.IsValidField(end, Owner, false))
                moves.Add(new Move(start, end, this));

            return moves;
        }
    }
}
