using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace TINKIN01.Chess.Pieces
{
    public interface IChesspiece
    {
        /// <summary>
        /// 
        /// </summary>
        TeamEnum Team
        {
            get;
            set;
        }

        /// <summary>
        /// The value (in points) of the piece
        /// </summary>
        int Value
        {
            get;
            set;
        }

        /// <summary>
        /// The (RELATIVE) moves this move can make
        /// </summary>
        IEnumerable<Move> GetValidMoves(Chessboard board);
    }
}
