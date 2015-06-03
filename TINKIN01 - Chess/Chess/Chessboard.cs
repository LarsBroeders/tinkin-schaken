using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml.Schema;
using TINKIN01.Chess.Extensions;
using TINKIN01.Chess.Pieces;

namespace TINKIN01.Chess
{
    public class Chessboard
    {
        /// <summary>
        /// An 8x8 array with Chesspieces
        /// </summary>
        public Chesspiece[,] Pieces { get; set; }

        /// <summary>
        /// The player that is currently playing
        /// </summary>
        public Player CurrentPlayer { get; set; }

        /// <summary>
        /// The second player
        /// </summary>
        public Player Player1 { get; set; }
        
        /// <summary>
        /// The first player
        /// </summary>
        public Player Player2{ get; set; }

        /// <summary>
        /// The gamestate the game is currently in
        /// </summary>
        public ChessboardStateEnum State
        {
            get { return _state; }
            set
            {
                //todo: RaiseStateChangedEvent?
                _state = value;   
            }
        }
        private ChessboardStateEnum _state;

        public HashSet<Move> madeMoves { get; set; }
    
        /// <summary>
        /// Gets the index of a piece
        /// </summary>
        /// <param name="chesspiece"></param>
        /// <returns></returns>
        public Point IndexOf(Chesspiece chesspiece){
            for(int x = 0; x < 8; x++)
            {
                for(int y = 0; y < 8; y++)
                {
                    if (chesspiece == Pieces[x, y])
                        return new Point(x, y);
                    
                }
            }
            return new Point(-1, -1);
        }

        /// <summary>
        /// Gets the pieces at a cirtain position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Chesspiece this[int x, int y]
        {
            get { return Pieces[x, y]; }
            set { Pieces[x, y] = value; } 
        }


        /// <summary>
        /// Gets the pieces at a cirtain position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Chesspiece this[Point point]
        {
            get { return Pieces[point.X, point.Y]; }
            set { Pieces[point.X, point.Y] = value; }
        }

        /// <summary>
        /// Wether a move has been moved yet
        /// </summary>
        /// <param name="chesspiece"></param>
        /// <returns></returns>
        public Boolean IsUnmoved(Chesspiece chesspiece)
        {
            return madeMoves.All(move => move.Piece != chesspiece);
        }


        public Boolean IsValidField(Point point, Player owner)
        {
            if (point.X > 8 || point.Y > 8 || point.X < 0 || point.Y < 0)
                return false;

            if (Pieces[point.X, point.Y].Owner == null)
                return false;

            return Pieces[point.X, point.Y].Owner == owner;
        }

        /// <summary>
        /// Validates a move
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        public Boolean IsValid(Move move)
        {
            if (move != null && move.Piece.GetValidMoves(this).Contains(move))
                return true;

            return false;
        }

        
        /// <summary>
        /// Gets all valid moves of a cirtain chesspiece
        /// </summary>
        /// <param name="chesspiece"></param>
        /// <returns></returns>
        public IEnumerable<Move> GetValidMoves(Chesspiece chesspiece)
        {
            return chesspiece.GetValidMoves(this);
        }

        /// <summary>
        /// Gets all valid moves of a cirtain player
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public IEnumerable<Move> GetValidMoves(Player player)
        {
            var pieces = Pieces.Mine(player).ToList();
            var piecesCanMakeMove = pieces.Where(x => x.GetValidMoves(this) != null);
            var moves = piecesCanMakeMove.SelectMany(x => x.GetValidMoves(this));
            return moves.Where(x => x != null);
            //return Pieces.Mine(player).Where(x => x.GetValidMoves(this) != null).SelectMany(x => x.GetValidMoves(this)).Where(x => x != null);
        }

        /// <summary>
        /// Gets all valid moves of all pieces
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Move> GetValidMoves()
        {
            return Pieces.ToIEnumerable().SelectMany(x => x.GetValidMoves(this));
        }

        /// <summary>
        /// Initializes a new instance of Chessboard
        /// </summary>
        public Chessboard(Player player1, Player player2)
        {
            
            Player1 = player1;
            Player2 = player2;
            Pieces = new Chesspiece[8,8];
            State = ChessboardStateEnum.Paused;
            madeMoves = new HashSet<Move>();
        }

        /// <summary>
        /// Starts playing
        /// </summary>
        public void Start()
        {
            //Starting or resuming?
            if (State == ChessboardStateEnum.Paused)
            {
                if (CurrentPlayer == null)
                    CurrentPlayer = Player1;
                State = ChessboardStateEnum.Playing;
                MakeMove();
            }
        }

        /// <summary>
        /// Makes move
        /// </summary>
        private void MakeMove()
        {
            //Checks if w're still playing
            UpdateGamestate();
            if (State != ChessboardStateEnum.Playing)
                return;

            //Getting a move
            CurrentPlayer.RequestMove(this);
        }

        /// <summary>
        /// Executing a move
        /// </summary>
        /// <param name="move"></param>
        public void ExecuteMove(Move move)
        {
            //Executing the move
            Console.WriteLine("Move Made: {0} {1} to {2};{3}", move.Piece.GetType().Name, move.Piece.Owner.Team, move.End.X, move.End.Y);
            CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;
            this[move.End] = this[move.Start];
            this[move.Start] = null;

            if (MoveMadeEvent != null)
                MoveMadeEvent(this, new MoveEventArgs{EnteredMove =  move});
            
            madeMoves.Add(move);
            MakeMove();
        }

        /// <summary>
        /// Updates the gamestate
        /// </summary>
        private void UpdateGamestate()
        {
            //TODO: Pattern recognition to update gamestate
        }

        /// <summary>
        /// Raises the move made event
        /// </summary>
        public EventHandler<MoveEventArgs> MoveMadeEvent;

        /// <summary>
        /// Returns a new chessboard with default position
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <returns></returns>
        public static Chessboard StartPosition(Player player1, Player player2 ) 
        {
            var result = new Chessboard(player1, player2);
            

            for (int i = 0; i < 8; i ++)
            {
                result.Pieces[i, 1] = new Pawn { Owner = player2 };
                result.Pieces[i, 6] = new Pawn { Owner = player1 };
            }

            result.Pieces[0, 0] = new Rook { Owner = player2 };
            result.Pieces[1, 0] = new Knight { Owner = player2 };
            result.Pieces[2, 0] = new Bishop { Owner = player2 };
            result.Pieces[3, 0] = new Queen { Owner = player2 };
            result.Pieces[4, 0] = new King { Owner = player2 };
            result.Pieces[5, 0] = new Bishop { Owner = player2 };
            result.Pieces[6, 0] = new Knight { Owner = player2 };
            result.Pieces[7, 0] = new Rook { Owner = player2 };

            result.Pieces[0, 7] = new Rook { Owner = player1 };
            result.Pieces[1, 7] = new Knight { Owner = player1 };
            result.Pieces[2, 7] = new Bishop { Owner = player1 };
            result.Pieces[3, 7] = new King { Owner = player1 };
            result.Pieces[4, 7] = new Queen { Owner = player1 };
            result.Pieces[5, 7] = new Bishop { Owner = player1 };
            result.Pieces[6, 7] = new Knight { Owner = player1 };
            result.Pieces[7, 7] = new Rook { Owner = player1 };

            return result;
        }
    }
}
