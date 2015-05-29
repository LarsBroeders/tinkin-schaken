using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TINKIN01.Chess.Players
{
    [DebuggerDisplay("Human, Team = {Team}")]
    public class Human : Player
    {
        /// <summary>
        /// The task that produces the move Asyncronisly
        /// </summary>
        private Func<Chessboard, Task> MoveRequester { get; set; }

        public Human(TeamEnum team, Func<Chessboard, Task> moveRequester = null)
            : base(team)
        {
            this.MoveRequester = moveRequester;
        }

        public override void RequestMove(Chessboard board)
        {
            Task task = MoveRequester(board);
        }
    }
}
