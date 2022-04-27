using System;
using System.Collections;
using ChessGame.Entities;
using ChessGame.Services;

namespace ChessGame.Application
{
    class Engine
    {
        private Board _board;
        private PrintBoardService _printService;
        private Stack _messages;

        public Engine()
        {
            _board = new Board();
            _printService = new PrintBoardService();
            _messages = new Stack();

            NewGame();
        }

        private void PrintMessages()
        {
            if (_messages.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                while (_messages.Count > 0)
                {
                    Console.WriteLine(_messages.Pop());
                }
                Console.ResetColor();
            }
        }

        private int ConvertCol(char pos)
        {
            return pos - 'a';
        }

        public void NewGame()
        {
            _board.Init();
        }

        public void Draw()
        {
            Console.Clear();
            Console.WriteLine("        Chess Game");
            Console.WriteLine("---------------------------");
            Console.WriteLine();

            _printService.PrintBoard(_board);
        }

        public void ReadMove()
        {
            PrintMessages();
            Console.Write("Enter your move: ");
            var move = Console.ReadLine();

            if (move == "exit") 
            {
                Environment.Exit(0);
            }


            int col = (int) ConvertCol((char) move[0]);
            int row = (int) move[1] - '1';

            if (col > 7 || col < 0 || row > 7 || row < 0)
            {
                _messages.Push("Invalid move");
                return;
            } 

            _board.MoveTo(row, col, PieceColor.White);

        }

        public void Run()
        {
            while (true)
            {
                Draw();
                ReadMove();
            }
        }
    }
}