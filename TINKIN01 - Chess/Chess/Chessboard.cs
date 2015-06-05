using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            return !MadeMoves.Any(move => move.Piece == chesspiece);
        }

        public Boolean IsValidField(Point point, Player owner, Boolean nil = true)
        {
            if (point.X > 7 || point.Y > 7 || point.X < 0 || point.Y < 0)
                return false;

            var IsNull = (Pieces[point.X, point.Y] == null || Pieces[point.X, point.Y].Owner == null);

            if (nil)
            {
                return IsNull;
            }
            else
            {
                if (IsNull)
                    return false;
                else
                    return Pieces[point.X, point.Y].Owner != owner;
            }
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
        /// Gets all valid moves of a cirtain player, including check(mate) validation
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public IEnumerable<Move> GetValidMoves(Player player)
        {
            //Get all available moves
            var myPieces = Pieces.Mine(player).Where(x => x != null).ToList();
            var enemyPieces = Pieces.Cast<Chesspiece>().Except(myPieces).Where(x => x != null);

            var myMoves = myPieces.Select(x => GetValidMoves(x)).Where(x => x != null).SelectMany(x => x);
            var enemyMoves = enemyPieces.Select(x => GetValidMoves(x)).Where(x => x != null).SelectMany(x => x);
            var enemyMoveEnds = enemyMoves.Select(x => x.End).OrderBy(x => x.X).ThenBy(x => x.Y);

            var myKing = myPieces.Where(x => x is King).FirstOrDefault();
            var indexOfMyKing = this.IndexOf(myKing);
            var enemyThreatMoves = enemyMoves.Where(x => x.End.Equals(indexOfMyKing));

            //Remove moves that are in a 'line of fire' (1. Dodge line of fire)
            var kingMoves = myMoves.Where(x => x.Piece is King);
            var kingMovesInLineOfFire = kingMoves.Where(x => enemyMoveEnds.Count(y => y.Equals(x.End)) > 0);
            var dodgeMoves = kingMoves.Where(x => !kingMovesInLineOfFire.Any(y => x.Equals(y)));

            //We have a trouble; we 
            if (enemyThreatMoves.Any())
            {
                var result = new List<Move>();

                //Getting all coordinates that will block the check(mate)
                var blockablePoints = enemyThreatMoves.SelectMany(x => x.BetweenStartEnd());
                var blockableMoves = myMoves.Where(x => !(x.Piece is King)).Where(x => blockablePoints.Any(y => x.End.Equals(y)));
                var takeoutMoves = myMoves.Where(x => enemyThreatMoves.Any(y => x.End.Equals(y.Start) ));

                result.AddRange(blockableMoves);
                result.AddRange(dodgeMoves);
                result.AddRange(takeoutMoves);

                return result;
                //1. Dodge line of fire
                //2. Interrupt line of fire
                //3. Take threat away
            }

            return myMoves;

            //return Pieces.Mine(player).Where(x => x.GetValidMoves(this) != null).SelectMany(x => x.GetValidMoves(this)).Where(x => x != null);
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
            
            MadeMoves.Add(move);

            if (move.SimultaneousMove != null)
                ExecuteMoveSilent(move.SimultaneousMove);

            MakeMove();
        }

        public void ExecuteMoveSilent(Move move)
        {
            Console.WriteLine("Move Made: {0} {1} to {2};{3}", move.Piece.GetType().Name, move.Piece.Owner.Team, move.End.X, move.End.Y);
            this[move.End] = this[move.Start];
            this[move.Start] = null;

            if (MoveMadeEvent != null)
                MoveMadeEvent(this, new MoveEventArgs { EnteredMove = move });

            MadeMoves.Add(move);
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
                //result.Pieces[i, 1] = new Pawn { Owner = player2 };
                //result.Pieces[i, 6] = new Pawn { Owner = player1 };
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
