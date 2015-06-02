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
           //var end = new Point();
           if (Owner.Team == TeamEnum.Black)
               if (start.Y.Equals(1))
               {
                   return new[] { new Move(start, new Point(start.X, start.Y + 1), this), new Move(start, new Point(start.X, start.Y + 2), this) };
               }
               else
               {
                   return new[] { new Move(start, new Point(start.X, start.Y + 1), this) };
               }
           else
               if (start.Y.Equals(6))
               {
                   return new[] { new Move(start, new Point(start.X, start.Y - 1), this), new Move(start, new Point(start.X, start.Y - 2), this) };
               }
               else
               {
                   return new[] { new Move(start, new Point(start.X, start.Y - 1), this) };
               }
           /*return new[]
           {
               new Point(0, 1)
           };*/
       }
    }
}
