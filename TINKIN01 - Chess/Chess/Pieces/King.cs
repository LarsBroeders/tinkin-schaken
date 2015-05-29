using System;
using System.Collections.Generic;
using System.Drawing;

namespace TINKIN01.Chess.Pieces
{
    public struct King : IChesspiece
    {
        public TeamEnum Team { get; set; }

        public int Value { get; set; }

        public IEnumerable<Move> GetValidMoves(Chessboard board)
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
