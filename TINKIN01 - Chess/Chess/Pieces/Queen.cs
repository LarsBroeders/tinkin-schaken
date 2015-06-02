using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace TINKIN01.Chess.Pieces
{
    [DebuggerDisplay("Queen, Owner = {Owner.Team}")]
    public class Queen : Chesspiece
    {
        /* Returns all possible moves for this Piece, without a check for other pieces.
         * 
         * With the problem that the random move generator generates move off the chessboard.
         */
        public override IEnumerable<Move> GetValidMoves(Chessboard board)
        {
            var start = board.IndexOf(this);
            //var end = new Point();

            return new[] { 
                new Move(start, new Point(start.X - 1, start.Y - 1), this), 
                new Move(start, new Point(start.X - 2, start.Y - 2), this), 
                new Move(start, new Point(start.X - 3, start.Y - 3), this), 
                new Move(start, new Point(start.X - 4, start.Y - 4), this), 
                new Move(start, new Point(start.X - 5, start.Y - 5), this), 
                new Move(start, new Point(start.X - 6, start.Y - 6), this), 
                new Move(start, new Point(start.X - 7, start.Y - 7), this), 
                new Move(start, new Point(start.X + 1, start.Y + 1), this), 
                new Move(start, new Point(start.X + 2, start.Y + 2), this), 
                new Move(start, new Point(start.X + 3, start.Y + 3), this), 
                new Move(start, new Point(start.X + 4, start.Y + 4), this), 
                new Move(start, new Point(start.X + 5, start.Y + 5), this), 
                new Move(start, new Point(start.X + 6, start.Y + 6), this), 
                new Move(start, new Point(start.X + 7, start.Y + 7), this),
                new Move(start, new Point(start.X - 1, start.Y + 1), this), 
                new Move(start, new Point(start.X - 2, start.Y + 2), this), 
                new Move(start, new Point(start.X - 3, start.Y + 3), this), 
                new Move(start, new Point(start.X - 4, start.Y + 4), this), 
                new Move(start, new Point(start.X - 5, start.Y + 5), this), 
                new Move(start, new Point(start.X - 6, start.Y + 6), this), 
                new Move(start, new Point(start.X - 7, start.Y + 7), this), 
                new Move(start, new Point(start.X + 1, start.Y - 1), this), 
                new Move(start, new Point(start.X + 2, start.Y - 2), this), 
                new Move(start, new Point(start.X + 3, start.Y - 3), this), 
                new Move(start, new Point(start.X + 4, start.Y - 4), this), 
                new Move(start, new Point(start.X + 5, start.Y - 5), this), 
                new Move(start, new Point(start.X + 6, start.Y - 6), this), 
                new Move(start, new Point(start.X + 7, start.Y - 7), this),
                new Move(start, new Point(start.X, start.Y - 1), this), 
                new Move(start, new Point(start.X, start.Y - 2), this), 
                new Move(start, new Point(start.X, start.Y - 3), this), 
                new Move(start, new Point(start.X, start.Y - 4), this), 
                new Move(start, new Point(start.X, start.Y - 5), this), 
                new Move(start, new Point(start.X, start.Y - 6), this), 
                new Move(start, new Point(start.X, start.Y - 7), this), 
                new Move(start, new Point(start.X, start.Y + 1), this), 
                new Move(start, new Point(start.X, start.Y + 2), this), 
                new Move(start, new Point(start.X, start.Y + 3), this), 
                new Move(start, new Point(start.X, start.Y + 4), this), 
                new Move(start, new Point(start.X, start.Y + 5), this), 
                new Move(start, new Point(start.X, start.Y + 6), this), 
                new Move(start, new Point(start.X, start.Y + 7), this), 
                new Move(start, new Point(start.X - 1, start.Y), this), 
                new Move(start, new Point(start.X - 2, start.Y), this), 
                new Move(start, new Point(start.X - 3, start.Y), this), 
                new Move(start, new Point(start.X - 4, start.Y), this), 
                new Move(start, new Point(start.X - 5, start.Y), this), 
                new Move(start, new Point(start.X - 6, start.Y), this), 
                new Move(start, new Point(start.X - 7, start.Y), this), 
                new Move(start, new Point(start.X + 1, start.Y), this), 
                new Move(start, new Point(start.X + 2, start.Y), this), 
                new Move(start, new Point(start.X + 3, start.Y), this), 
                new Move(start, new Point(start.X + 4, start.Y), this), 
                new Move(start, new Point(start.X + 5, start.Y), this), 
                new Move(start, new Point(start.X + 6, start.Y), this), 
                new Move(start, new Point(start.X + 7, start.Y), this)};
            
            /*
return new[]
{
new Point(0, 1),
new Point(0, 2),
new Point(0, 3),
new Point(0, 4),
new Point(0, 5),
new Point(0, 6),
new Point(0, 7),
new Point(0, -1),
new Point(0, -2),
new Point(0, -3),
new Point(0, -4),
new Point(0, -5),
new Point(0, -6),
new Point(0, -7),
new Point(1, 0),
new Point(2, 0),
new Point(3, 0),
new Point(4, 0),
new Point(5, 0),
new Point(6, 0),
new Point(7, 0),
new Point(-1, 0),
new Point(-2, 0),
new Point(-3, 0),
new Point(-4, 0),
new Point(-5, 0),
new Point(-6, 0),
new Point(-7, 0),
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
}
;*/
        }
    }
}
