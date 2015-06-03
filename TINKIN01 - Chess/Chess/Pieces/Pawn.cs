using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace TINKIN01.Chess.Pieces
{
    [DebuggerDisplay("Pawn, Owner = {Owner.Team}")]
    public class Pawn : Chesspiece
    {
       public override HashSet<Move> GetValidMoves(Chessboard board)
       {
           var start = board.IndexOf(this);
           var moves = new HashSet<Move>();
           Point end;
           if (Owner.Team == TeamEnum.Black)
           {
               end = new Point(start.X, start.Y + 1);
               if (board.IsValidField(end, Owner))
               {
                   moves.Add(new Move(start, end, this));
               }
               if (board.IsUnmoved(this))
               {
                   end = new Point(start.X, start.Y + 2);
                   if (board.IsValidField(end, Owner))
                   {
                       moves.Add(new Move(start, end, this));
                   }
               }
               end = new Point(start.X + 1, start.Y + 1);
               if (board.IsValidField(end, Owner, false))
               {
                   moves.Add(new Move(start, end, this));
               }
               end = new Point(start.X - 1 , start.Y + 1);
               if (board.IsValidField(end, Owner, false))
               {
                   moves.Add(new Move(start, end, this));
               }
           } else
           {
               end = new Point(start.X, start.Y - 1);
               if (board.IsValidField(end, Owner))
               {
                   moves.Add(new Move(start, end, this));
               }
               if (board.IsUnmoved(this))
               {
                   end = new Point(start.X, start.Y - 2);
                   if (board.IsValidField(end, Owner))
                   {
                       moves.Add(new Move(start, end, this));
                   }
               }
               end = new Point(start.X + 1, start.Y - 1);
               if (board.IsValidField(end, Owner, false))
               {
                   moves.Add(new Move(start, end, this));
               }
               end = new Point(start.X - 1, start.Y - 1);
               if (board.IsValidField(end, Owner, false))
               {
                   moves.Add(new Move(start, end, this));
               }
           }
           return moves;
       }
    }
}
