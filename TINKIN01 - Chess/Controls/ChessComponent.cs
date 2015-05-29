using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using TINKIN01.Chess;
using TINKIN01.Chess.Pieces;

namespace TINKIN01.Controls
{
    public partial class ChessComponent : UserControl
    {
        /// <summary>
        /// The board 
        /// </summary>
        public Chessboard Board {
            get { return board; }
            set
            {
                board = value;
                if (board.MoveMadeEvent == null)
                    board.MoveMadeEvent += MoveMadeEvent;
            } }

        private Chessboard board;

        /// <summary>
        /// The size of the board
        /// </summary>
        private Size BoardSize { get; set; }

        /// <summary>
        /// The location of the board
        /// </summary>
        private Point BoardLocation { get; set; }

        /// <summary>
        /// The size of a tile
        /// </summary>
        private SizeF TileSize { get; set; }

        /// <summary>
        /// The move to draw
        /// </summary>
        public Move SelectedMove { get; set; }

        /// <summary>
        /// MoveEntered event
        /// </summary>
        public EventHandler<MoveEventArgs> MoveEnteredEvent;

        public ChessComponent(Player player1, Player player2)
        {
            Board = Chessboard.StartPosition(player1, player2);
            Board.MoveMadeEvent += MoveMadeEvent;
            InitializeComponent();
        }

        public void MoveMadeEvent(object sender, MoveEventArgs e)
        {
            this.SelectedMove = e.EnteredMove;
            this.Refresh();
        }

        /// <summary>
        /// Updates size properties when the component's size has changed
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            //Determining the isze and t
            var size = Math.Min(Width, Height);
            BoardLocation = new Point((Width - size) / 2, (Height - size) / 2);
            BoardSize = new Size(size, size);
            TileSize = new SizeF(size / 8f, size/8f);

            //Calling the base
            base.OnSizeChanged(e);
        }

        /// <summary>
        /// Updates the visual
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            using (var boardImage = new Bitmap(Width, Height))
            {
                using (var boardGraphics = Graphics.FromImage(boardImage))
                {
                    //Defining the colors
                    var tileSelectedStart = new SolidBrush(Color.FromArgb(250, 250, 170));
                    var tileSelectedEnd = new SolidBrush(Color.FromArgb(250, 250, 100));
                    var tileBgBlack = new SolidBrush(Color.FromArgb(77, 109, 146));
                    var tileBgWhite = new SolidBrush(Color.FromArgb(220, 220, 220));
                    var tileHighlight = new SolidBrush(Color.FromArgb(100, 100, 100));
                    var imageAttr = new ImageAttributes();
                    var elipseMargin = TileSize.Width * 0.3f;
                    var squareMargin = TileSize.Width * 0.1f;

                    //Preparing the highlighted moves
                    var highlightedCoordinates = new List<Point>();
                    if (SelectedMove != null && SelectedMove.Piece != null && SelectedMove.End.Equals(Chess.Move.DefaultCoodtinate))
                        highlightedCoordinates.AddRange(SelectedMove.Piece.GetValidMoves(Board).Select(move => move.End));

                    //Draw the game on boardgraphics, using floats for less conversion
                    for (int x = 0; x < 8f; x += 1)
                    {
                        for (int y = 0; y < 8f; y += 1)
                        {
                            var piecePt = new Point(x, y);
                            
                            var brush = tileBgBlack;
                            if (((y%2) + x)%2 == 0)
                                brush = tileBgWhite;

                            //Fill background Color
                            var destRectF = new RectangleF(x * TileSize.Width, y * TileSize.Height, TileSize.Width, TileSize.Height);
                            boardGraphics.FillRectangle(brush, destRectF);

                            //Drawing select,
                            if (SelectedMove != null)
                            {
                                if (SelectedMove.Start.Equals(piecePt))
                                    boardGraphics.FillRectangle(tileSelectedStart, destRectF);

                                if (SelectedMove.End.Equals(piecePt) || (SelectedMove.Start.Equals(piecePt) && !SelectedMove.Start.Equals(Chess.Move.DefaultCoodtinate) && SelectedMove.End.Equals(Chess.Move.DefaultCoodtinate)))
                                    boardGraphics.FillRectangle(tileSelectedEnd, destRectF);
                            }

                            if (highlightedCoordinates.Any(pt => pt == piecePt))
                                boardGraphics.FillEllipse(tileHighlight,
                                    RectangleF.Inflate(destRectF, -elipseMargin, -elipseMargin));

                            //Draw piece
                            if (Board != null && Board[x, y] != null)
                            {
                                var piece = Board[x, y];
                                var pieceBmp = piece.GetBitmap();

                                var destRect = Rectangle.Round(RectangleF.Inflate(destRectF, -squareMargin, -squareMargin));
                                boardGraphics.DrawImage(pieceBmp, destRect, 0, 0, pieceBmp.Width,
                                    pieceBmp.Height, GraphicsUnit.Pixel, imageAttr);
                            }
                        }
                    }

                    //Drawing the board on control graphics
                    using (var controlGraphics = CreateGraphics())
                    {
                        controlGraphics.FillRectangle(new SolidBrush(BackColor), 0, 0, Width, Height);
                        controlGraphics.DrawImage(boardImage, BoardLocation);
                        controlGraphics.DrawRectangle(new Pen(tileBgBlack.Color), BoardLocation.X, BoardLocation.Y, BoardSize.Width, BoardSize.Height);
                    }
                     
                }
            }

            base.OnPaint(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            var local = new PointF(e.X - BoardLocation.X, e.Y - BoardLocation.X);
            var coordinate = new Point((int)Math.Floor(local.X / TileSize.Width), (int)Math.Floor(local.Y / TileSize.Height));

            if (coordinate.X < 0 || coordinate.Y < 0 || coordinate.X > 8 || coordinate.Y > 8)
                return;

            //Coordinate is valid
            if (SelectedMove == null || SelectedMove.IsDefault() || (!SelectedMove.Start.Equals(Chess.Move.DefaultCoodtinate) && !SelectedMove.End.Equals(Chess.Move.DefaultCoodtinate)))
                SelectedMove = new Move();

            if (SelectedMove.Start.Equals(Chess.Move.DefaultCoodtinate) || (board[coordinate] != null &&
                board[coordinate].Owner == Board.CurrentPlayer))
            {
                //Selected our start
                SelectedMove.Start = coordinate;
                SelectedMove.Piece = board[coordinate];
                Refresh();
                return;
            }

            if (SelectedMove.End.Equals(Chess.Move.DefaultCoodtinate) && !SelectedMove.Start.Equals(Chess.Move.DefaultCoodtinate))
            {
                var moves = SelectedMove.Piece.GetValidMoves(Board);
                if (SelectedMove.Piece.GetValidMoves(Board).Any(x => x.End.Equals(coordinate)))
                {
                    //Selected end
                    SelectedMove.End = coordinate;
                    Refresh();
                    //Make move
                    if (MoveEnteredEvent != null)
                        MoveEnteredEvent(this, new MoveEventArgs {EnteredMove = SelectedMove});
                }

            }
        }
    }

    internal static class ChessPieceExtensions
    {
        /// <summary>
        /// A cache like dictionary for bitmaps
        /// </summary>
        private static Dictionary<string, Bitmap> _bitmapCache;

        /// <summary>
        /// Gets the bitmap for this ICHesspiece
        /// </summary>
        /// <param name="piece"></param>
        /// <returns></returns>
        public static Bitmap GetBitmap(this Chesspiece piece)
        {
            if (_bitmapCache == null)
            {
                List<string> files = new List<string>
                {
                    "BBishop.png",
                    "BKing.png",
                    "BKnight.png",
                    "BPawn.png",
                    "BQueen.png",
                    "BRook.png",
                    "WBishop.png",
                    "WKing.png",
                    "WKnight.png",
                    "WPawn.png",
                    "WQueen.png",
                    "WRook.png"
                };

                _bitmapCache = new Dictionary<string, Bitmap>();
                var imageDir = Path.GetDirectoryName(Application.ExecutablePath) + "\\Images\\";
                foreach (var file in files)
                {
                    string name = Path.GetFileNameWithoutExtension(file).ToLower();
                    string url = Path.Combine(imageDir, file);

                    _bitmapCache.Add(name, new Bitmap(url));
                }
            }

            string bitmapName = piece.Owner.Team.ToString().Substring(0, 1) + piece.GetType().Name;

            return _bitmapCache[bitmapName.ToLower()];
        }
    }
}
