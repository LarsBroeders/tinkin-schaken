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
            return null; /*
            return new Point[] { 
                new Point(1, 2),
                new Point(1, -2),
                new Point(-1, 2),
                new Point(-1, -2),
                new Point(2, 1),
                new Point(2, -1),
                new Point(-2, 1),
                new Point(-2, -1)
            };*/
        }
    }
}
