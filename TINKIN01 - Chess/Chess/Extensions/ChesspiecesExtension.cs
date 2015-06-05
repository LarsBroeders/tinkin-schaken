using System.Collections.Generic;
using System.Linq;
using TINKIN01.Chess.Pieces;

namespace TINKIN01.Chess.Extensions
{

    public static class ChesspiecesExtension
    {
        /// <summary>
        /// Returns a IEnumerable of piecese
        /// </summary>
        /// <param name="myPieces"></param>
        /// <returns></returns>
        public static IEnumerable<Chesspiece> ToIEnumerable(this Chesspiece[,] pieces)
        {
            return pieces.Cast<Chesspiece>().Where(x => x != null);
        }

        /// <summary>
        /// Returns a IEnumerable of piecese
        /// </summary>
        /// <param name="myPieces"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        public static IEnumerable<Chesspiece> Mine(this Chesspiece[,] pieces, Player player)
        {
            return pieces.ToIEnumerable().Where(x => x.Owner == player);
        }
    }
}
