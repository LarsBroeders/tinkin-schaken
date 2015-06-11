using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using TINKIN01.Chess.Extensions;
using TINKIN01.Chess.Pieces;
using TINKIN01.Controls;

namespace TINKIN01.Chess
{
    public class Chessboard : IDisposable
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
                if (_state != value)
                {
                    _state = value;
                    if (StateChangedEvent != null)
                        StateChangedEvent(this, EventArgs.Empty);
                }
            }
        }
        private ChessboardStateEnum _state;

        /// <summary>
        /// A log of all moves that have been made 
        /// </summary>
        public HashSet<Move> MadeMoves { get; set; }


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
        /// Gets the myPieces at a cirtain position
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
        /// Gets the myPieces at a cirtain position
        /// </summary>
        /// <param name="point"></param>
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
            return MadeMoves.All(move => move.Piece != chesspiece);
        }

        public Boolean IsValidDesitnationFor(Point point, Player owner)
        {
            if (point.X > 7 || point.Y > 7 || point.X < 0 || point.Y < 0)
                return false;

            if (Pieces[point.X, point.Y] == null)
                return true;

            if (Pieces[point.X, point.Y] != null && Pieces[point.X, point.Y].Owner != owner)
                return true;

            return false;
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
        /// Gets all valid moves of a cirtain player, including check(mate) validation
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public IEnumerable<Move> GetValidMoves(Player player)
        {
            //Get all available moves
            var myPieces = Pieces.Mine(player).Where(x => x != null).ToList();
            var myMoves = myPieces.SelectMany(x => x.GetValidMoves(this)).ToList();
            foreach (var move in myMoves)
            {
                using (var board = new Chessboard(Player1, Player2))
                {
                    //Making a replica
                    foreach (var piece in Pieces.Cast<Chesspiece>())
                        board[IndexOf(piece)] = piece;
                    foreach (var madeMoves in MadeMoves)
                        board.MadeMoves.Add(madeMoves);
                    board.CurrentPlayer = CurrentPlayer;
                    board.ExecuteMove(move, false);

                    //Calculating if the enemyPieces can take the king
                    var myPiecesLeft = board.Pieces.Mine(player).Where(x => x != null).ToList();
                    var enemyPiecesLeft = board.Pieces.Cast<Chesspiece>().Except(myPiecesLeft).Where(x => x != null).ToList();
                    var enemyPiecesLeftMoveEnds = enemyPiecesLeft.SelectMany(x => x.GetValidMoves(board));
                    var enemyKing = myPiecesLeft.FirstOrDefault(x => x is King);

                    //If there isn't a king, perfect for us!
                    if (enemyKing == null)
                    {
                        yield return move;
                        continue;
                    }

                    //If there is a king, calculating its index and seeing if no-one can take him
                    var indexOfMyNewKing = board.IndexOf(enemyKing);
                    if (enemyPiecesLeftMoveEnds.All(x => !x.End.Equals(indexOfMyNewKing)))
                    {
                        yield return move;
                    }
                }
            }        
        }


        /// <summary>
        /// Gets all valid moves of all myPieces
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
            MadeMoves = new HashSet<Move>();
        }

        ~Chessboard()
        {
            Dispose();
        }

        public void Dispose()
        {
            Pieces = new Chesspiece[0, 0];
            MadeMoves.Clear();
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

            if (State == ChessboardStateEnum.Playing)
            {
                //Getting a move
                CurrentPlayer.RequestMove(this);
            }
        }

        /// <summary>
        /// Executing a move
        /// </summary>
        /// <param name="move"></param>
        /// <param name="RaiseEvent"></param>
        public void ExecuteMove(Move move, bool RaiseEvent = true)
        {
            Console.WriteLine("Move Made: {0} {1} to {2};{3}", move.Piece.GetType().Name, move.Piece.Owner.Team,
                move.End.X, move.End.Y);
            this[move.End] = this[move.Start];
            this[move.Start] = null;
            MadeMoves.Add(move);

            if (move.SimultaneousMove != null)
                ExecuteMove(move.SimultaneousMove, false);
            else
            {
                CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;

                if (RaiseEvent)
                {
                    if (MoveMadeEvent != null)
                        MoveMadeEvent(this, new MoveEventArgs {EnteredMove = move});

                    MakeMove();
                }
            }
        }

        /// <summary>
        /// Updates the gamestate
        /// </summary>
        private void UpdateGamestate()
        {
            var moves = GetValidMoves(CurrentPlayer);

            if (!moves.Any())
                State = ChessboardStateEnum.Checkmate;

        }

        /// <summary>
        /// Raises the move made event
        /// </summary>
        public EventHandler<MoveEventArgs> MoveMadeEvent;

        /// <summary>
        /// Raises the state changed event
        /// </summary>
        public EventHandler StateChangedEvent;

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
            result.Pieces[4, 7] = new King { Owner = player1 };
            result.Pieces[3, 7] = new Queen { Owner = player1 };
            result.Pieces[5, 7] = new Bishop { Owner = player1 };
            result.Pieces[6, 7] = new Knight { Owner = player1 };
            result.Pieces[7, 7] = new Rook { Owner = player1 };

            return result;
        }
    }
}
