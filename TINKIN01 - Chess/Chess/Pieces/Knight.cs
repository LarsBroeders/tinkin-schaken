using System;
using System.Collections.Generic;
using System.Drawing;

namespace TINKIN01.Chess.Pieces
{
    public struct Knight : IChesspiece
    {
        public TeamEnum Team { get; set; }

        public int Value { get; set; }

        public IEnumerable<Move> GetValidMoves(Chessboard board)
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
