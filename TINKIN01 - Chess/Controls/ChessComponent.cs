using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public Chessboard Board { get; set; }

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

        public ChessComponent()
        {
 
            InitializeComponent();
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
            TileSize = new SizeF((float)size / 8f, (float)size/8f);

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
                    var tilteBgColor = new SolidBrush(Color.FromArgb(77, 109, 146));
                    var titleBgWhite = new SolidBrush(Color.FromArgb(236, 236, 236));

                    //Draw the game on boardgraphics, using floats for less conversion
                    for (int x = 0; x < 8f; x += 1)
                    {
                        for (int y = 0; y < 8f; y += 1)
                        {
                            var brush = tilteBgColor;
                            if (((y%2) + x)%2 == 0)
                                brush = titleBgWhite;

                            boardGraphics.FillRectangle(brush, x * TileSize.Width, y * TileSize.Height, TileSize.Width, TileSize.Height);
                        }
                    }

                    Board.Pieces[0, 0].GetBitmap();

                    //Drawing the board on control graphics
                    using (var controlGraphics = CreateGraphics())
                    {
                        controlGraphics.FillRectangle(new SolidBrush(BackColor), 0, 0, Width, Height);
                        controlGraphics.DrawImage(boardImage, BoardLocation);
                        controlGraphics.DrawRectangle(new Pen(tilteBgColor.Color), BoardLocation.X, BoardLocation.Y, BoardSize.Width, BoardSize.Height);
                    }
                     
                }
            }

            base.OnPaint(e);
        }
    }

    internal static class ChessPieceExtensions
    {
        /// <summary>
        /// A cache like dictionary for bitmaps
        /// </summary>
        private static Dictionary<Type, Bitmap> BitmapCache;

        public static Bitmap GetBitmap(this IChesspiece piece)
        {
            if (BitmapCache == null)
            {
                
            }

            return null;
        }
    }
}
