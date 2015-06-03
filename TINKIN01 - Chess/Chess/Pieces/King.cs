using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace TINKIN01.Chess.Pieces
{
    [DebuggerDisplay("King, Owner = {Owner.Team}")]
    public class King : Chesspiece
    {
        public override HashSet<Move> GetValidMoves(Chessboard board)
        {
            var start = board.IndexOf(this);
            var moves = new HashSet<Move>();
            Point end;

            end = new Point(start.X, start.Y + 1);
            if (board.IsValidField(end, Owner) || board.IsValidField(end, Owner, false))
                moves.Add(new Move(start, end, this));

            end = new Point(start.X, start.Y - 1);
            if (board.IsValidField(end, Owner) || board.IsValidField(end, Owner, false))
                moves.Add(new Move(start, end, this));

            end = new Point(start.X - 1, start.Y);
            if (board.IsValidField(end, Owner) || board.IsValidField(end, Owner, false))
                moves.Add(new Move(start, end, this));

            end = new Point(start.X + 1, start.Y);
            if (board.IsValidField(end, Owner) || board.IsValidField(end, Owner, false))
                moves.Add(new Move(start, end, this));

            end = new Point(start.X + 1, start.Y + 1);
            if (board.IsValidField(end, Owner) || board.IsValidField(end, Owner, false))
                moves.Add(new Move(start, end, this));

            end = new Point(start.X + 1, start.Y - 1);
            if (board.IsValidField(end, Owner) || board.IsValidField(end, Owner, false))
                moves.Add(new Move(start, end, this));

            end = new Point(start.X - 1, start.Y + 1);
            if (board.IsValidField(end, Owner) || board.IsValidField(end, Owner, false))
                moves.Add(new Move(start, end, this));

            end = new Point(start.X - 1, start.Y - 1);
            if (board.IsValidField(end, Owner) || board.IsValidField(end, Owner, false))
                moves.Add(new Move(start, end, this));

            if (Owner.Team == TeamEnum.Black)
            {
                if (board.IsUnmoved(this))
                {
                    if (board.IsUnmoved(board[0, 0]) &&
                        board.IsValidField(new Point(1, 0), Owner) &&
                        board.IsValidField(new Point(2, 0), Owner) &&
                        board.IsValidField(new Point(3, 0), Owner)
                        )
                    {
                        moves.Add(new Move(start, new Point(1, 0), this, new Move(new Point(0, 0), new Point(2, 0), board[0, 0])));
                    }

                    if (board.IsUnmoved(board[7, 0]) &&
                        board.IsValidField(new Point(5, 0), Owner) &&
                        board.IsValidField(new Point(6, 0), Owner)
                        )
                    {
                        moves.Add(new Move(start, new Point(6, 0), this, new Move(new Point(7, 0), new Point(5, 0), board[7, 0])));
                    }
                }
            }
            else
            {
                if (board.IsUnmoved(this))
                {
                    if (board.IsUnmoved(board[0, 7]) &&
                        board.IsValidField(new Point(1, 7), Owner) &&
                        board.IsValidField(new Point(2, 7), Owner)
                        )
                    {
                        moves.Add(new Move(start, new Point(1, 7), this, new Move(new Point(0, 7), new Point(2, 7), board[0, 7])));
                    }

                    if (board.IsUnmoved(board[7, 7]) &&
                        board.IsValidField(new Point(4, 7), Owner) &&
                        board.IsValidField(new Point(5, 7), Owner) &&
                        board.IsValidField(new Point(6, 7), Owner)
                        )
                    {
                        moves.Add(new Move(start, new Point(6, 7), this, new Move(new Point(7, 7), new Point(5, 7), board[7, 7])));
                    }
                }
            }

            return moves;
        }
    }
}
