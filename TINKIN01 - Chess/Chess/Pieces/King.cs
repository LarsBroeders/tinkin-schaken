using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace TINKIN01.Chess.Pieces
{
    [DebuggerDisplay("King, Owner = {Owner.Team}")]
    public class King : Chesspiece
    {
        /* Returns all possible moves for this Piece, without a check for other pieces.
         * 
         * With the problem that the random move generator generates move off the chessboard.
         */
        public override HashSet<Move> GetValidMoves(Chessboard board)
        {
            var start = board.IndexOf(this);
            //var end = new Point();
            return null;
            //return new[] { 
            //    new Move(start, new Point(start.X - 1, start.Y - 1), this), 
            //    new Move(start, new Point(start.X + 1, start.Y + 1), this),
            //    new Move(start, new Point(start.X - 1, start.Y + 1), this), 
            //    new Move(start, new Point(start.X + 1, start.Y - 1), this),
            //    new Move(start, new Point(start.X, start.Y - 1), this), 
            //    new Move(start, new Point(start.X, start.Y + 1), this), 
            //    new Move(start, new Point(start.X - 1, start.Y), this), 
            //    new Move(start, new Point(start.X + 1, start.Y), this)};
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
