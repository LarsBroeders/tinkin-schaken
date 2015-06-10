using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using TINKIN01.Chess.Extensions;

namespace TINKIN01.Chess.Pieces
{
    [DebuggerDisplay("King, Owner = {Owner.Team}")]
    public class King : Chesspiece
    {
        public override IEnumerable<Move> GetValidMoves(Chessboard board)
        {
            var start = board.IndexOf(this);
            var ends = new [] { new Point(start.X, start.Y + 1),
                new Point(start.X, start.Y - 1),
                new Point(start.X - 1, start.Y),
                new Point(start.X + 1, start.Y),
                new Point(start.X + 1, start.Y + 1),
                new Point(start.X + 1, start.Y - 1),
                new Point(start.X - 1, start.Y + 1),
                new Point(start.X - 1, start.Y - 1)
            };

            foreach (var end in ends)
                if (board.IsValidDesitnationFor(end, Owner))
                    yield return new Move(start, end, this);

            //The swap!
            if (board.IsUnmoved(this))
            {
                var unmovedRooks = board.Pieces.Mine(Owner).Where(x => x is Rook).Where(board.IsUnmoved);
    
                foreach (var rook in unmovedRooks)
                {
                    var rookPosition = board.IndexOf(rook);
                    var between = start.Between(rookPosition).ToList();
                    if (between.Any() && between.All(point => board[point] == null))
                        yield return new Move(start, between[1], this, new Move(rookPosition, between[0], rook));
                }
            }
        }
    }
}
