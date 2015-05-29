﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace TINKIN01.Chess.Pieces
{
    [DebuggerDisplay("Queen, Owner = {Owner.Team}")]
    public class Queen : Chesspiece
    {
        public override IEnumerable<Move> GetValidMoves(Chessboard board)
        {
            return null; /*
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
