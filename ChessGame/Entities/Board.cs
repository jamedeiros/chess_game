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

            for (int i = 0; i < (TOTAL_ROWS * TOTAL_COLS); i++)
            {
                _board[i] = new Square
                {
                    Row = (i / TOTAL_ROWS),
                    Col = (i % TOTAL_COLS),
                    Color = color
                };
                color = (color == SquareColor.White) ? SquareColor.Black : SquareColor.White;
            }
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