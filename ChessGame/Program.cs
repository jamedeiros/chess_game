using System;
using ChessGame.Entities;
using ChessGame.Services;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            PrintBoardService printService = new PrintBoardService();

            Console.WriteLine("Chess Board!");
            printService.PrintBoard(board);
        }
    }
}
