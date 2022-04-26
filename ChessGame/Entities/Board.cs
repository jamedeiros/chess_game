using System.Text;

namespace ChessGame.Entities
{
    class Board
    {
        public const int TOTAL_ROWS = 8;
        public const int TOTAL_COLS = 8;

        private Square[] _board = new Square[TOTAL_ROWS * TOTAL_COLS];

        public Board()
        {
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
                new Pawn(Cell(1, i), PieceColor.White);
                new Pawn(Cell(6, i), PieceColor.Black);
            }

            // Put Rook
            new Rook(Cell(0, 0), PieceColor.White);
            new Rook(Cell(0, 7), PieceColor.White);
            new Rook(Cell(7, 0), PieceColor.Black);
            new Rook(Cell(7, 7), PieceColor.Black);

            // Put Knights
            new Knight(Cell(0, 1), PieceColor.White);
            new Knight(Cell(0, 6), PieceColor.White);
            new Knight(Cell(7, 1), PieceColor.Black);
            new Knight(Cell(7, 6), PieceColor.Black);

            // Put Bishops
            new Bishop(Cell(0, 2), PieceColor.White);
            new Bishop(Cell(0, 5), PieceColor.White);
            new Bishop(Cell(7, 2), PieceColor.Black);
            new Bishop(Cell(7, 5), PieceColor.Black);

            // Put Queens
            new Queen(Cell(0, 3), PieceColor.White);
            new Queen(Cell(7, 3), PieceColor.Black);

            // Put Kings
            new King(Cell(0, 4), PieceColor.White);
            new King(Cell(7, 4), PieceColor.Black);


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
    }
}