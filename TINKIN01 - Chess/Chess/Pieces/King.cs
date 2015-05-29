using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace TINKIN01.Chess.Pieces
{
    [DebuggerDisplay("King, Owner = {Owner.Team}")]
    public class King : Chesspiece
    {
        public override IEnumerable<Move> GetValidMoves(Chessboard board)
        {
            return null;
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
