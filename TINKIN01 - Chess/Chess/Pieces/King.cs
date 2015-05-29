using System;
using System.Drawing;

namespace TINKIN01.Chess.Pieces
{
    public struct King : IChesspiece
    {
        public TeamEnum Team { get; set; }

        public int Value
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Point[] Moves
        {
            get {
                return new[] {
                    new Point(0, 1),
                    new Point(1, 0),
                    new Point(0, -1),
                    new Point(-1, 0),
                    new Point(1, 1),
                    new Point(1, -1),
                    new Point(-1, 1),
                    new Point(-1, -1)
                };
            }
            private set { throw new NotImplementedException(); }
        }
    }
}
