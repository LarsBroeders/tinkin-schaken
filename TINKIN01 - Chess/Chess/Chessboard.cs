using System;
using System.Collections;
using System.Collections.Generic;
using TINKIN01.Chess.Pieces;

namespace TINKIN01.Chess
{
    public class Chessboard
    {
        /// <summary>
        /// An 8x8 array with Chesspieces
        /// </summary>
        public IChesspiece[,] Pieces { get; set; }

        /// <summary>
        /// Gets the pieces at a cirtain position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public IChesspiece this[int x, int y]
        {
            get { return Pieces[x, y]; }
            set { Pieces[x, y] = value; } 
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
            return null;
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
            Pieces = new IChesspiece[8,8];
        }

        public static Chessboard StartPosition()
        {
            var result = new Chessboard();

            for (int i = 0; i < 8; i ++)
            {
                result.Pieces[i, 1] = new Pawn {Team = TeamEnum.Black};
                result.Pieces[i, 6] = new Pawn {Team = TeamEnum.White};
            }

            result.Pieces[0, 0] = new Rook { Team = TeamEnum.Black };
            result.Pieces[1, 0] = new Knight { Team = TeamEnum.Black };
            result.Pieces[2, 0] = new Bishop { Team = TeamEnum.Black };
            result.Pieces[3, 0] = new Queen { Team = TeamEnum.Black };
            result.Pieces[4, 0] = new King { Team = TeamEnum.Black };
            result.Pieces[5, 0] = new Bishop { Team = TeamEnum.Black };
            result.Pieces[6, 0] = new Knight { Team = TeamEnum.Black };
            result.Pieces[7, 0] = new Rook { Team = TeamEnum.Black };

            result.Pieces[0, 7] = new Rook { Team = TeamEnum.White };
            result.Pieces[1, 7] = new Knight { Team = TeamEnum.White };
            result.Pieces[2, 7] = new Bishop { Team = TeamEnum.White };
            result.Pieces[3, 7] = new King { Team = TeamEnum.White };
            result.Pieces[4, 7] = new Queen { Team = TeamEnum.White };
            result.Pieces[5, 7] = new Bishop { Team = TeamEnum.White };
            result.Pieces[6, 7] = new Knight { Team = TeamEnum.White };
            result.Pieces[7, 7] = new Rook { Team = TeamEnum.White };

            return result;
        }
    }
}
