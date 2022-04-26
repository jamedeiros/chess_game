using System;
using ChessGame.Application;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine game = new Engine();
            game.Run();
        }
    }
}
