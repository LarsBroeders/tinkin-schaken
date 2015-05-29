
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TINKIN01.Chess.Extensions;

namespace TINKIN01.Chess.Players
{
    public class ChessAI : Player
    {
        public ChessAI(TeamEnum team) : base(team)
        {
        }

        public override void RequestMove(Chessboard board)
        {
            Task moveRequest = RequestMoveTask(board);
        }

        public async Task RequestMoveTask(Chessboard board)
        {
            await Task.Delay(1000);
            var random = new Random();

            //Picking a random piece which makes a random move
            var moves = board.GetValidMoves(this).ToArray();
            var move = moves[random.Next(moves.Length)];
            
            board.ExecuteMove(move);
        }

    }
}
