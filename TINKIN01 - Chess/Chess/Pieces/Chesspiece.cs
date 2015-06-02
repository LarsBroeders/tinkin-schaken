using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace TINKIN01.Chess.Pieces
{
    public abstract class Chesspiece
    {
        /// <summary>
        /// The owner of the piece
        /// </summary>
        public Player Owner
        {
            get;
            set;
        }

        /// <summary>
        /// The value (in points) of the piece
        /// </summary>
        public  int Value
        {
            get;
            set;
        }

        /// <summary>
        /// The (RELATIVE) moves this move can make
        /// </summary>
        public abstract HashSet<Move> GetValidMoves(Chessboard board);
    }
}
