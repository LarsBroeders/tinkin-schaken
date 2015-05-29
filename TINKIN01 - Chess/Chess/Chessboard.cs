using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TINKIN01.Chess.Pieces;

namespace TINKIN01.Chess
{
    public class Chessboard
    {
        /// <summary>
        /// An 8x8 array with Chesspieces
        /// </summary>
        public IChesspiece[,] Pieces { get; set; }

        public Point IndexOf(IChesspiece chesspiece){
            var pieces = Pieces;
            for(int x = 0; x <= 7; x++)
            {
                for(int y = 0; y <= 7; y++)
                {
                    if( pieces[x, y].Equals(chesspiece)){
                        return new Point(x, y);
                    }
                }
            }
            return new Point(-1, -1);
        }

        /// <summary>
        /// Validates a move
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        public Boolean IsValid(Move move)
        {
            throw new System.NotImplementedException();

        }

        /// <summary>
        /// Gets all moves of a cirtain chesspiece
        /// </summary>
        /// <param name="chesspiece"></param>
        /// <returns></returns>
        public IEnumerable<Move> GetValidMoves(IChesspiece chesspiece)
        {
            throw new System.NotImplementedException();

        }

        /// <summary>
        /// Gets all valid moves of all pieces
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Move> GetValidMoves()
        {
            return null;
        }

        /// <summary>
        /// Initializes a new instance of Chessboard
        /// </summary>
        public Chessboard()
        {
            throw new System.NotImplementedException();
        }

        public static Chessboard StartPosition()
        {
            
        }
    }
}
