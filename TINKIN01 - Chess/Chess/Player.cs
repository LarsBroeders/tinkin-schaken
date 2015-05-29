using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TINKIN01.Chess.Pieces;

namespace TINKIN01.Chess
{
    public abstract class Player
    {
        protected Player(TeamEnum team)
        {
            Team = team;
        }

        /// <summary>
        /// The team the player belongs to
        /// </summary>
        public TeamEnum Team { get; set; }

        /// <summary>
        /// The requests a move to make
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public abstract void RequestMove(Chessboard board);

    }

}