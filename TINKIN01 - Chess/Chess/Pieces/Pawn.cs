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
           var start = board.IndexOf(this);

           //Indicating direction
           var directionY = Owner.Team == TeamEnum.White ? -1 : 1;
           var end = new Point(start.X, start.Y + directionY);

           if (board.IsValidDesitnationFor(end, Owner) && board[end] == null)
           {
               yield return new Move(start, end, this);
               end = new Point(start.X, start.Y + directionY * 2);

               //Double jump
               if (board.IsUnmoved(this) && board.IsValidDesitnationFor(end, Owner) && board[end] == null)
                   yield return new Move(start, end, this);

           }

           //Taking
           end = new Point(start.X + 1, start.Y + directionY);
           if (board.IsValidDesitnationFor(end, Owner) && board[end] != null && board[end].Owner != Owner)
               yield return new Move(start, end, this);

           end = new Point(start.X - 1, start.Y + directionY);
           if (board.IsValidDesitnationFor(end, Owner) && board[end] != null && board[end].Owner != Owner)
               yield return new Move(start, end, this);
       }
    }
}
