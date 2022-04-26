using System;
using System.Collections.Generic;
using ChessGame.Entities;

namespace ChessGame.Services
{
    class PrintBoardService
    {
        public void PrintSquare(Square square)
        {
            Console.BackgroundColor = (square.Color == SquareColor.White) ? ConsoleColor.Cyan : ConsoleColor.DarkCyan;
            if (square.LocalPiece != null)
            {
                Console.ForegroundColor = (square.LocalPiece.Color == PieceColor.White) ? ConsoleColor.White : ConsoleColor.DarkBlue;
                Console.Write(" {0} ", square);
            }
            else
            {
                Console.Write("   ");
            }
        }

        public void PrintMark<T>(T value)
        {
            Console.ResetColor();
            Console.Write(" {0} ", value);
        }

        public void PrintNewLine()
        {
            Console.WriteLine();
        }

        public void PrintBoard(Board board)
        {
            var commandBuilder = new List<Action>();

            for (int x = (Board.TOTAL_ROWS - 1); x >= 0; x--)
            {
                var idx = x + 1;
                commandBuilder.Add(() => PrintMark<int>(idx));
                for (int y = 0; y < Board.TOTAL_COLS; y++)
                {
                    Square square = board.Cell(x, y);
                    commandBuilder.Add(() => PrintSquare(square));
                }
                commandBuilder.Add(() => PrintNewLine());
            }
            commandBuilder.Add(() => PrintMark<string>(" "));
            foreach (char c in "abcdefgh")
            {
                commandBuilder.Add(() => PrintMark<char>(c));
            }
            commandBuilder.Add(() => PrintNewLine());
            commandBuilder.ForEach(cmd => cmd());
            Console.ResetColor();
        }
    }
}