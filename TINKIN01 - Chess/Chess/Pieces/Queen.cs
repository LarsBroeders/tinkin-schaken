using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace TINKIN01.Chess.Pieces
{
    [DebuggerDisplay("Queen, Owner = {Owner.Team}")]
    public class Queen : Chesspiece
    {
        public override IEnumerable<Move> GetValidMoves(Chessboard board)
        {
            var start = board.IndexOf(this);

            //Diagnol
            for (Point end = new Point(start.X + 1, start.Y + 1); board.IsValidDesitnationFor(end, Owner); end = new Point(end.X + 1, end.Y + 1))
            {
                yield return new Move(start, end, this);
                if (board[end] != null)
                    break;
            }

            for (Point end = new Point(start.X + 1, start.Y - 1); board.IsValidDesitnationFor(end, Owner); end = new Point(end.X + 1, end.Y - 1))
            {
                yield return new Move(start, end, this);
                if (board[end] != null)
                    break;
            }

            for (Point end = new Point(start.X - 1, start.Y + 1); board.IsValidDesitnationFor(end, Owner); end = new Point(end.X - 1, end.Y + 1))
            {
                yield return new Move(start, end, this);
                if (board[end] != null)
                    break;
            }

            for (Point end = new Point(start.X - 1, start.Y - 1); board.IsValidDesitnationFor(end, Owner); end = new Point(end.X - 1, end.Y - 1))
            {
                yield return new Move(start, end, this);
                if (board[end] != null)
                    break;
            }

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
