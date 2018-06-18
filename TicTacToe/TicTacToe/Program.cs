using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game;
            int turn;
            Player winner;
            do
            {
                game = new Game();
                turn = 0;
                winner = null;
                game.GetPlayerNames();
                while (turn < 9 && winner == null)
                {
                    winner = game.Turn(turn);
                    turn++;
                }
                game.Board.Display();
                if (winner == null)
                {
                    Console.WriteLine("It's a draw!");
                }
                else
                {
                    Console.WriteLine($"{winner.Name} Wins!");
                }
            } while (game.Continue());
        }
    }
}
