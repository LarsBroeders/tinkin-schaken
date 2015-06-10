using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TINKIN01.Chess;
using TINKIN01.Chess.Extensions;
using TINKIN01.Chess.Players;
using TINKIN01.Controls;

namespace TINKIN01
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// The player1
        /// </summary>
        public Player Player1 { get; set; }

        /// <summary>
        /// The player2
        /// </summary>
        public Player Player2 { get; set; }

        public Form1()
        {
            Player1 = new Human(TeamEnum.White, GetMoveAsync);
            Player2 = new Human(TeamEnum.Black, GetMoveAsync);
            InitializeComponent();

            var pieces = chessComponent1.Board.Pieces.ToIEnumerable();
            chessComponent1.MoveEnteredEvent += MoveEntered;        
            chessComponent1.Board.Start();
        }

        private async Task GetMoveAsync(Chessboard board)
        {
            while (_entredMove == null)
            {
                await Task.Delay(50);
            }

            var move = _entredMove;
            _entredMove = null;
            chessComponent1.Board.ExecuteMove(move);
            // This method has no return statement, so its return type is Task.  
        }

        private Move _entredMove = null;

        public void MoveEntered(object sender, MoveEventArgs e)
        {
            _entredMove = e.EnteredMove;
        }
    }
}
