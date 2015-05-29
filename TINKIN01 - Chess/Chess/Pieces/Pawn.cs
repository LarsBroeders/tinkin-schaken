using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace TINKIN01.Chess.Pieces
{
    [DebuggerDisplay("Pawn, Owner = {Owner.Team}")]
    public class Pawn : Chesspiece
    {
       public override IEnumerable<Move> GetValidMoves(Chessboard board)
        {
            //JUST FOR DEVEOPMENT PURPOSES
           var start = board.IndexOf(this);
           var end = new Point();
           if (Owner.Team == TeamEnum.Black)
               end = new Point(start.X, start.Y + 1);
           else
               end = new Point(start.X, start.Y - 1);

           return new[] {new Move(start, end, this)};
           /*return new[]
           {
               new Point(0, 1)
           };*/
       }
    }
}
