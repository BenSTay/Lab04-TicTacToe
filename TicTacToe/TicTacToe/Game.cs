using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Game
    {
        public Player Player1;
        public Player Player2;
        public Board Board;

        /// <summary>
        /// Creates a new instance of the Game class.
        /// </summary>
        public Game()
        {
            Player1 = new Player("X");
            Player2 = new Player("O");
            Board = new Board();
        }

        /// <summary>
        /// Gets the names of the players from the users.
        /// </summary>
        public void GetPlayerNames()
        {
            Console.Clear();
            Console.Write("Player 1, enter your name: ");
            Player1.Name = Console.ReadLine();
            Console.Write("Player 2, enter your name: ");
            Player2.Name = Console.ReadLine();
        }

        /// <summary>
        /// Gets a number from user input.
        /// </summary>
        /// <param name="message">The prompt displayed to the user.</param>
        /// <returns>A number entered by the user.</returns>
        public int GetNumber(string message)
        {
            int number;
            while (true)
            {
                try
                {
                    Console.Write(message);
                    number = Convert.ToInt32(Console.ReadLine());
                    if (number > 9 || number < 1)
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
                    }
                    else return number;
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
                }
            }
        }

        /// <summary>
        /// Gets the player whose turn it is.
        /// </summary>
        /// <param name="turnNum">The turn it is.</param>
        /// <returns>The player whose turn it is.</returns>
        public Player GetPlayer(int turnNum)
        {
            return turnNum % 2 == 0 ? Player1 : Player2;
        }

        /// <summary>
        /// Plays a single turn of the Tic Tac Toe game.
        /// </summary>
        /// <param name="turnNum">The turn it is.</param>
        /// <returns>The winner of the game, if any.</returns>
        public Player Turn(int turnNum)
        {
            Player player = GetPlayer(turnNum);
            Board.Display();
            int square;
            bool updated = false;
            while (!updated)
            {
                string message = $"{player.Name}, please select a square: ";
                square = GetNumber(message);
                updated = Board.Update(square, player.Marker);
                if (!updated)
                {
                    Console.WriteLine("That square is already taken!");
                }
            }
            return Board.CheckWinner() == "" ? null : player;
        }

        /// <summary>
        /// Asks the players if they want to play again.
        /// </summary>
        /// <returns>True or false depending on the user's response.</returns>
        public bool Continue()
        {
            string input;
            while (true)
            {
                Console.Write("Do you want to play again? (Y/N): ");
                input = Console.ReadLine().ToUpper();
                switch (input)
                {
                    case "Y": return true;
                    case "N": return false;
                    default:
                        Console.WriteLine("Invalid Input.");
                        break;
                }
            }
        }

    }
}
