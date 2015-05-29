using System;
using System.Drawing;
using System.Windows.Forms.VisualStyles;
using TINKIN01.Chess.Pieces;

namespace TINKIN01.Chess
{
    public class Move
    {
        public static Point DefaultCoodtinate = new Point(-1, -1);

        public Move()
        {
            Start = DefaultCoodtinate;
            End = DefaultCoodtinate;
        }

        /// <summary>
        /// Checks wether this is a default mvoe
        /// </summary>
        /// <returns></returns>
        public Boolean IsDefault()
        {
            if (End.Equals(DefaultCoodtinate) && Start.Equals(DefaultCoodtinate))
                return true;

            return false;
        }

        public Move(Point start, Point end, Chesspiece piece) : base()
        {
            Start = start;
            End = end;
            Piece = piece;
        }

        /// <summary>
        /// The start coordinate of a move
        /// </summary>
        public Point Start { get; set; }

        /// <summary>
        /// The end coordinate of a move
        /// </summary>
        public Point End { get; set; }

        /// <summary>
        /// The piece that'll make the move
        /// </summary>
        public Chesspiece Piece { get; set; }
    }
}
