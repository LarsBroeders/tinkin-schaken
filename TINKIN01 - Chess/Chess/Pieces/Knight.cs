using System;
using System.Drawing;

namespace TINKIN01.Chess.Pieces
{
    public struct Knight : IChesspiece
    {
        public TeamEnum Team { get; set; }

        public int Value
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Point[] Moves
        {
            get
            {
                return new[] { 
                    new Point(1, 2),
                    new Point(1, -2),
                    new Point(-1, 2),
                    new Point(-1, -2),
                    new Point(2, 1),
                    new Point(2, -1),
                    new Point(-2, 1),
                    new Point(-2, -1)
                };
            }
            private set { }
        }
    }
}
