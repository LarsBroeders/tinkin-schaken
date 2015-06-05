using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace TINKIN01.Chess.Pieces
{
    [DebuggerDisplay("Bishop, Owner = {Owner.Team}")]
    public class Bishop : Chesspiece
    {
        public override IEnumerable<Move> GetValidMoves(Chessboard board)
        {
            var start = board.IndexOf(this);
            var moves = new HashSet<Move>();
            Point end;

            for (int xy = 1; xy < 8; xy++)
            {
                end = new Point(start.X + xy, start.Y + xy);
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

            for (int xy = 1; xy < 8; xy++)
            {
                end = new Point(start.X + xy, start.Y - xy);
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

            for (int xy = 1; xy < 8; xy++)
            {
                end = new Point(start.X - xy, start.Y + xy);
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

            for (int xy = 1; xy < 8; xy++)
            {
                end = new Point(start.X - xy, start.Y - xy);
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
