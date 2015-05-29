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

namespace TINKIN01.Controls
{
    public partial class ChessComponent : UserControl
    {
        /// <summary>
        /// The board 
        /// </summary>
        public Chessboard Board { get; set; }


        public ChessComponent()
        {
            InitializeComponent();
        }
    }
}
