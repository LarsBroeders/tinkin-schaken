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
        public override IEnumerable<Move> GetValidMoves(Chessboard board)
        {
            var start = board.IndexOf(this);
            //Straight
            for (Point end = new Point(start.X + 1, start.Y); board.IsValidDesitnationFor(end, Owner); end = new Point(end.X + 1, end.Y))
            {
                yield return new Move(start, end, this);
                if (board[end] != null)
                    break;
            }

            for (Point end = new Point(start.X - 1, start.Y); board.IsValidDesitnationFor(end, Owner); end = new Point(end.X - 1, end.Y))
            {
                yield return new Move(start, end, this);
                if (board[end] != null)
                    break;
            }

            for (Point end = new Point(start.X, start.Y + 1); board.IsValidDesitnationFor(end, Owner); end = new Point(end.X, end.Y + 1))
            {
                yield return new Move(start, end, this);
                if (board[end] != null)
                    break;
            }

            for (Point end = new Point(start.X, start.Y - 1); board.IsValidDesitnationFor(end, Owner); end = new Point(end.X, end.Y - 1))
            {
                yield return new Move(start, end, this);
                if (board[end] != null)
                    break;
            }
        }
    }
}
