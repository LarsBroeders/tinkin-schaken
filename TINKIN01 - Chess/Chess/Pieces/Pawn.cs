using System;
using System.Collections.Generic;
using System.Drawing;

namespace TINKIN01.Chess.Pieces
{
    public struct Pawn : IChesspiece
    {
        public TeamEnum Team { get; set; }

        public int Value { get; set; }

       public IEnumerable<Move> GetValidMoves(Chessboard board)
       {
           return null;
           /*return new[]
           {
               new Point(0, 1)
           };*/
       }
    }
}
