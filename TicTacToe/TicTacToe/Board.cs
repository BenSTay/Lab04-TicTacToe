using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Board
    {
        public Square[,] Squares;

        /// <summary>
        /// Creates a new instance of the Board class.
        /// </summary>
        public Board()
        {
            Squares = new Square[3, 3];

            for (int i = 0; i < 9; i++)
            {
                Squares[i % 3, i / 3] = new Square((i + 1).ToString());
            }
        }

        /// <summary>
        /// Renders the Board to the console.
        /// </summary>
        public void Display()
        {
            Console.Clear();
            for (int i = 0; i < 9; i++)
            {
                if (i > 2 && i % 3 == 0) Console.WriteLine("-----------");
                Console.Write($" {Squares[i % 3, i / 3].Content} {(i % 3 == 2 ? "\n" : "|")}");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Places a marker onto the board.
        /// </summary>
        /// <param name="squareNum">The position where the marker is being placed.</param>
        /// <param name="marker">The marker being placed.</param>
        /// <returns>True or false depending on if the update was successful.</returns>
        public bool Update(int squareNum, string marker)
        {
            squareNum--;
            Square square = Squares[squareNum % 3, squareNum / 3];
            if (square.Content != "X" && square.Content != "O")
            {
                square.Content = marker;
                return true;
            }
            else return false;
        }
        
        /// <summary>
        /// Checks to see if there is a winner.
        /// </summary>
        /// <returns>The marker of the winner, if any.</returns>
        public string CheckWinner()
        {
            string squareVal = Squares[1, 1].Content;
            if (squareVal == "X" || squareVal == "O")
            {
                if (Squares[0, 0].Content == squareVal && Squares[2, 2].Content == squareVal) return squareVal;
                if (Squares[0, 1].Content == squareVal && Squares[2, 1].Content == squareVal) return squareVal;
                if (Squares[1, 0].Content == squareVal && Squares[1, 2].Content == squareVal) return squareVal;
                if (Squares[2, 0].Content == squareVal && Squares[0, 2].Content == squareVal) return squareVal;
            }

            squareVal = Squares[0, 0].Content;
            if (squareVal == "X" || squareVal == "O")
            {
                if (Squares[0, 1].Content == squareVal && Squares[0, 2].Content == squareVal) return squareVal;
                if (Squares[1, 0].Content == squareVal && Squares[2, 0].Content == squareVal) return squareVal;
            }

            squareVal = Squares[2, 2].Content;
            if (squareVal == "X" || squareVal == "O")
            {
                if (Squares[0, 2].Content == squareVal && Squares[1, 2].Content == squareVal) return squareVal;
                if (Squares[2, 0].Content == squareVal && Squares[2, 1].Content == squareVal) return squareVal;
            }

            return "";
        }
    }
}
