﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms.VisualStyles;
using TINKIN01.Chess.Pieces;

namespace TINKIN01.Chess
{
    [DebuggerDisplay("Move, Piece={Piece}, Start={Start}, End={End}")]
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

        public Move(Point start, Point end, Chesspiece piece, Move simultaneous = null) : base()
        {
            Start = start;
            End = end;
            Piece = piece;
            SimultaneousMove = simultaneous;
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

        public override bool Equals(object obj)
        {
            if (obj is Move)
            {
                var m1 = obj as Move;
                if (m1.End.Equals(End) && m1.Start.Equals(Start) && m1.Piece == Piece)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Determins wether a move is in a line
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Point> BetweenStartEnd()
        {
            if (this.Piece is Rook || this.Piece is Queen || this.Piece is Bishop)
            {
                var deltaX = Math.Abs(Start.X - End.X);
                var deltaY = Math.Abs(Start.Y - End.Y);

                var stepX  = 0;
                if (Start.X - End.X < 0)
                    stepX = 1;
                else if (Start.X - End.X > 0)
                    stepX = -1;

                var stepY = 0;
                if (Start.Y - End.Y < 0)
                    stepY = 1;
                else if (Start.Y - End.Y > 0)
                    stepY = -1;


                var step = new Point(stepX, stepY);

                for (int i = 1; i < Math.Max(deltaX, deltaY); i++)
                {
                    yield return new Point(Start.X + step.X * i, Start.Y + step.Y * i);
                }

            }
        }

        public Move SimultaneousMove { get; set; }
    }
}
