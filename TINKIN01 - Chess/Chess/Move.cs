using System;
using System.Drawing;
using TINKIN01.Chess.Pieces;

namespace TINKIN01.Chess
{
    public class Move
    {
        /// <summary>
        /// The start coordinate of a move
        /// </summary>
        public Point Start
        {
            get { throw new NotImplementedException(); }
            set
            {throw new NotImplementedException();
            }
        }

        /// <summary>
        /// The end coordinate of a move
        /// </summary>
        public Point End
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// The piece that'll make the move
        /// </summary>
        public IChesspiece Piece
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
