using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace ChessGame.Entities
{
    class Board
    {
        public const int TOTAL_ROWS = 8;
        public const int TOTAL_COLS = 8;

        private Square[] _board = new Square[TOTAL_ROWS * TOTAL_COLS];
        private List<Piece> _pieces;

        public Board()
        {
            _pieces = new List<Piece>();
            SquareColor color = SquareColor.White;
            int row = -1;

            for (int i = 0; i < (TOTAL_ROWS * TOTAL_COLS); i++)
            {
                if (row != (i / TOTAL_ROWS))
                {
                    row = (i / TOTAL_ROWS);
                    color = (row % 2 == 0) ? SquareColor.White : SquareColor.Black;
                }

                _board[i] = new Square
                {
                    Row = (i / TOTAL_ROWS),
                    Col = (i % TOTAL_COLS),
                    Color = color
                };
                color = (color == SquareColor.White) ? SquareColor.Black : SquareColor.White;
            }
        }

        public void Init()
        {
            // Reset Board
            for (int i = 0; i < TOTAL_ROWS * TOTAL_COLS; i++)
                _board[i].LocalPiece = null;

            // Put Pawns
            for (int i = 0; i < TOTAL_COLS; i++)
            {
                _pieces.Add(new Pawn(Cell(1, i), PieceColor.White));
                _pieces.Add(new Pawn(Cell(6, i), PieceColor.Black));
            }

            // Put Rook
            _pieces.Add(new Rook(Cell(0, 0), PieceColor.White));
            _pieces.Add(new Rook(Cell(0, 7), PieceColor.White));
            _pieces.Add(new Rook(Cell(7, 0), PieceColor.Black));
            _pieces.Add(new Rook(Cell(7, 7), PieceColor.Black));

            // Put Knights
            _pieces.Add(new Knight(Cell(0, 1), PieceColor.White));
            _pieces.Add(new Knight(Cell(0, 6), PieceColor.White));
            _pieces.Add(new Knight(Cell(7, 1), PieceColor.Black));
            _pieces.Add(new Knight(Cell(7, 6), PieceColor.Black));

            // Put Bishops
            _pieces.Add(new Bishop(Cell(0, 2), PieceColor.White));
            _pieces.Add(new Bishop(Cell(0, 5), PieceColor.White));
            _pieces.Add(new Bishop(Cell(7, 2), PieceColor.Black));
            _pieces.Add(new Bishop(Cell(7, 5), PieceColor.Black));

            // Put Queens
            _pieces.Add(new Queen(Cell(0, 3), PieceColor.White));
            _pieces.Add(new Queen(Cell(7, 3), PieceColor.Black));

            // Put Kings
            _pieces.Add(new King(Cell(0, 4), PieceColor.White));
            _pieces.Add(new King(Cell(7, 4), PieceColor.Black));
        }

        public Square Cell(int x, int y)
        {
            return _board[x * TOTAL_ROWS + y];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < TOTAL_ROWS; i++)
            {
                sb.Append((i + 1) + ": ");

                for (int j = 0; j < TOTAL_COLS; j++)
                {
                    sb.Append(_board[(i * TOTAL_COLS) + j]);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        // Move for Pawn
        public void MoveTo(int row, int col, PieceColor color)
        {
            Square target = Cell(row, col);
            Square source = null;

            for (int i = row; i >= 0; i--) 
            {
                source = Cell(i, col);
                if (source.LocalPiece != null)
                    break;
            }

            if (source != null && source.LocalPiece != null) 
            {
                source.LocalPiece.MoveTo(target);
                source.LocalPiece = null;
            }
        }
    }
}