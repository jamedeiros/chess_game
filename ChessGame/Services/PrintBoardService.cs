using System;
using System.Collections.Generic;
using ChessGame.Entities;

namespace ChessGame.Services
{
    class PrintBoardService
    {
        public void PrintSquare(Square square)
        {
            Console.ForegroundColor = (square.Color == SquareColor.White) ? ConsoleColor.White : ConsoleColor.DarkBlue;
            Console.Write(square);
        }

        public void PrintNewLine()
        {
            Console.WriteLine();
        }

        public void PrintBoard(Board board)
        {
            var commandBuilder = new List<Action>();

            for (int x = 0; x < Board.TOTAL_ROWS; x++)
            {
                for (int y = 0; y < Board.TOTAL_COLS; y++)
                {
                    Square square = board.Cell(x, y);
                    commandBuilder.Add(() => PrintSquare(square));
                }
                commandBuilder.Add(() => PrintNewLine());
            }
            commandBuilder.ForEach(cmd => cmd());
        }
    }
}