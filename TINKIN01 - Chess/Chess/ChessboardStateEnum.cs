using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TINKIN01.Chess
{
    /// <summary>
    /// Different gamestates for a ChessGame (http://en.wikipedia.org/wiki/Chess#End_of_the_game)
    /// </summary>
    public enum ChessboardStateEnum
    {
        /// <summary>
        /// The game is paused or hasn't started
        /// </summary>
        Paused = -1,
        /// <summary>
        /// Still playing
        /// </summary>
        Playing = 0,
        /// <summary>
        /// Stopped; A player has been checkmated
        /// </summary>
        Checkmate = 10,
        /// <summary>
        /// Stopped; A player resigned
        /// </summary>
        Resigned = 11,
        /// <summary>
        /// Stopped; Out of time
        /// </summary>
        OutOfTime = 12,
        /// <summary>
        /// Stopped; A player cheated or violated games
        /// </summary>
        Fortfeit = 13,
        /// <summary>
        /// Draw; Agreed to drawa
        /// </summary>
        DrawByAgreement = 20,
        /// <summary>
        /// Draw; Neither team has no valid moves for this player
        /// </summary>
        Stalemate = 21,
        /// <summary>
        /// Draw; Neither team has
        /// </summary>
        ThreefoldRepitition = 22,
        /// <summary>
        /// Draw; A player doesn't have the myPieces to checkmate the other player ( for example, both have only a King)
        /// </summary>
        InsufficientMaterial = 23
        /*/// <summary>
        /// Draw; Fifty moves have been made and the pawns are still at the same position and now claim has been made
        /// </summary>
        FiftyRule = 24*/

    }
}
