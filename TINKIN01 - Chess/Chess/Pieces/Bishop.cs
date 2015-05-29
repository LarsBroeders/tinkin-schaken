using System;
using System.Collections.Generic;
using System.Drawing;

namespace TINKIN01.Chess.Pieces
{
    public struct Bishop : IChesspiece
    {
        public TeamEnum Team { get; set; }

        public int Value { get; set; }

        public IEnumerable<Move> GetValidMoves(Chessboard board)
        {
            return null; /*
                return new[]
                {
                    new Point(1, 1),
                    new Point(2, 2),
                    new Point(3, 3),
                    new Point(4, 4),
                    new Point(5, 5),
                    new Point(6, 6),
                    new Point(7, 7),
                    new Point(1, -1),
                    new Point(2, -2),
                    new Point(3, -3),
                    new Point(4, -4),
                    new Point(5, -5),
                    new Point(6, -6),
                    new Point(7, -7),
                    new Point(-1, 1),
                    new Point(-2, 2),
                    new Point(-3, 3),
                    new Point(-4, 4),
                    new Point(-5, 5),
                    new Point(-6, 6),
                    new Point(-7, 7),
                    new Point(-1, -1),
                    new Point(-2, -2),
                    new Point(-3, -3),
                    new Point(-4, -4),
                    new Point(-5, -5),
                    new Point(-6, -6),
                    new Point(-7, -7)
                };*/
        }
    }
}
