using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace TINKIN01.Chess.Pieces
{
    [DebuggerDisplay("Knight, Owner = {Owner.Team}")]
    public class Knight : Chesspiece
    {
        public override IEnumerable<Move> GetValidMoves(Chessboard board)
        {
            var start = board.IndexOf(this);
            var ends = new[]
            {
                new Point(start.X + 1, start.Y + 2),
                new Point(start.X + 1, start.Y - 2),
                new Point(start.X - 1, start.Y + 2),
                new Point(start.X - 1, start.Y - 2),
                new Point(start.X + 2, start.Y + 1),
                new Point(start.X + 2, start.Y - 1),
                new Point(start.X - 2, start.Y + 1),
                new Point(start.X - 2, start.Y - 1)
            };

            foreach (var end in ends)
            {
                if (board.IsValidDesitnationFor(end, Owner))
                    yield return new Move(start, end, this);
            }
        }
    }
}
